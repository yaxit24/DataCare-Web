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
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class UT_SET_ADMIN : Form
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
	[AccessedThroughProperty("btnCounterStk")]
	private QButton _btnCounterStk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnEstmateBank")]
	private QButton _btnEstmateBank;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOldPurcTch")]
	private QButton _btnOldPurcTch;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnNegativeStk")]
	private QButton _btnNegativeStk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSlNwtLock")]
	private QButton _btnSlNwtLock;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("QButton1")]
	private QButton _QButton1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnPurcLot")]
	private QButton _btnPurcLot;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSlYearSale")]
	private QButton _btnSlYearSale;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnGlYearSale")]
	private QButton _btnGlYearSale;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnKrTouchHide")]
	private QButton _btnKrTouchHide;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnStkLimitWithDesign")]
	private QButton _BtnStkLimitWithDesign;

	private string EntryMode;

	private Control CurActCtrl;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

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

	internal virtual QButton btnCounterStk
	{
		[CompilerGenerated]
		get
		{
			return _btnCounterStk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnCounterStk_Click;
			QButton val = _btnCounterStk;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnCounterStk = value;
			val = _btnCounterStk;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCounterStk")]
	private virtual ComboBox _cboCounterStk;

	internal virtual ComboBox cboCounterStk
	{
		get
		{
			return _cboCounterStk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboCounterStk = value;
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

	internal virtual QButton btnEstmateBank
	{
		[CompilerGenerated]
		get
		{
			return _btnEstmateBank;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnEstmateBank_Click;
			QButton val = _btnEstmateBank;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnEstmateBank = value;
			val = _btnEstmateBank;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboEstmatBank")]
	private virtual ComboBox _cboEstmatBank;

	internal virtual ComboBox cboEstmatBank
	{
		get
		{
			return _cboEstmatBank;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboEstmatBank = value;
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

	internal virtual QButton btnOldPurcTch
	{
		[CompilerGenerated]
		get
		{
			return _btnOldPurcTch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnOldPurcTch_Click;
			QButton val = _btnOldPurcTch;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOldPurcTch = value;
			val = _btnOldPurcTch;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboOldPurcTch")]
	private virtual ComboBox _cboOldPurcTch;

	internal virtual ComboBox cboOldPurcTch
	{
		get
		{
			return _cboOldPurcTch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboOldPurcTch = value;
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

	internal virtual QButton btnNegativeStk
	{
		[CompilerGenerated]
		get
		{
			return _btnNegativeStk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnNegativeStk_Click;
			QButton val = _btnNegativeStk;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnNegativeStk = value;
			val = _btnNegativeStk;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboNegativeStk")]
	private virtual ComboBox _cboNegativeStk;

	internal virtual ComboBox cboNegativeStk
	{
		get
		{
			return _cboNegativeStk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboNegativeStk = value;
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

	internal virtual QButton btnSlNwtLock
	{
		[CompilerGenerated]
		get
		{
			return _btnSlNwtLock;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnSlNwtLock_Click;
			QButton val = _btnSlNwtLock;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSlNwtLock = value;
			val = _btnSlNwtLock;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboSlNwtLock")]
	private virtual ComboBox _cboSlNwtLock;

	internal virtual ComboBox cboSlNwtLock
	{
		get
		{
			return _cboSlNwtLock;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboSlNwtLock = value;
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

	internal virtual QButton QButton1
	{
		[CompilerGenerated]
		get
		{
			return _QButton1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = QButton1_Click;
			QButton val = _QButton1;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_QButton1 = value;
			val = _QButton1;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cbobillprofit")]
	private virtual ComboBox _cbobillprofit;

	internal virtual ComboBox cbobillprofit
	{
		get
		{
			return _cbobillprofit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cbobillprofit = value;
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

	internal virtual QButton btnPurcLot
	{
		[CompilerGenerated]
		get
		{
			return _btnPurcLot;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnPurcLot_Click;
			QButton val = _btnPurcLot;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnPurcLot = value;
			val = _btnPurcLot;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboPurcLot")]
	private virtual ComboBox _cboPurcLot;

	internal virtual ComboBox cboPurcLot
	{
		get
		{
			return _cboPurcLot;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboPurcLot = value;
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

	internal virtual QButton btnSlYearSale
	{
		[CompilerGenerated]
		get
		{
			return _btnSlYearSale;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnSlYearSale_Click;
			QButton val = _btnSlYearSale;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSlYearSale = value;
			val = _btnSlYearSale;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboSlYearSale")]
	private virtual ComboBox _cboSlYearSale;

	internal virtual ComboBox cboSlYearSale
	{
		get
		{
			return _cboSlYearSale;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboSlYearSale = value;
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

	internal virtual QButton btnGlYearSale
	{
		[CompilerGenerated]
		get
		{
			return _btnGlYearSale;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnGlYearSale_Click;
			QButton val = _btnGlYearSale;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnGlYearSale = value;
			val = _btnGlYearSale;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboGlYearSale")]
	private virtual ComboBox _cboGlYearSale;

	internal virtual ComboBox cboGlYearSale
	{
		get
		{
			return _cboGlYearSale;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboGlYearSale = value;
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

	internal virtual QButton btnKrTouchHide
	{
		[CompilerGenerated]
		get
		{
			return _btnKrTouchHide;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnKrTouchHide_Click;
			QButton val = _btnKrTouchHide;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnKrTouchHide = value;
			val = _btnKrTouchHide;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboKrTouchHide")]
	private virtual ComboBox _cboKrTouchHide;

	internal virtual ComboBox cboKrTouchHide
	{
		get
		{
			return _cboKrTouchHide;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboKrTouchHide = value;
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

	internal virtual QButton BtnStkLimitWithDesign
	{
		[CompilerGenerated]
		get
		{
			return _BtnStkLimitWithDesign;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnStkLimitWithDesign_Click;
			QButton val = _BtnStkLimitWithDesign;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnStkLimitWithDesign = value;
			val = _BtnStkLimitWithDesign;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboStklimitWithDesign")]
	private virtual ComboBox _cboStklimitWithDesign;

	internal virtual ComboBox cboStklimitWithDesign
	{
		get
		{
			return _cboStklimitWithDesign;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboStklimitWithDesign = value;
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

	public UT_SET_ADMIN()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((Form)this).Load += UT_SET_ADMIN_Load;
		((Form)this).Activated += UT_SET_ADMIN_Activated;
		((Form)this).Deactivate += UT_SET_ADMIN_Deactivate;
		((Control)this).KeyDown += new KeyEventHandler(UT_SET_ADMIN_KeyDown);
		((Form)this).Closed += UT_SET_ADMIN_Closed;
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
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Expected O, but got Unknown
		//IL_0463: Unknown result type (might be due to invalid IL or missing references)
		//IL_04be: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c8: Expected O, but got Unknown
		//IL_052b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Expected O, but got Unknown
		//IL_05dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e7: Expected O, but got Unknown
		//IL_06f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fb: Expected O, but got Unknown
		//IL_0817: Unknown result type (might be due to invalid IL or missing references)
		//IL_0821: Expected O, but got Unknown
		//IL_0884: Unknown result type (might be due to invalid IL or missing references)
		//IL_088e: Expected O, but got Unknown
		//IL_0936: Unknown result type (might be due to invalid IL or missing references)
		//IL_0940: Expected O, but got Unknown
		//IL_09a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ad: Expected O, but got Unknown
		//IL_0b61: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6b: Expected O, but got Unknown
		//IL_0bb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbb: Expected O, but got Unknown
		//IL_121e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1242: Unknown result type (might be due to invalid IL or missing references)
		//IL_1266: Unknown result type (might be due to invalid IL or missing references)
		//IL_128a: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_12bd: Expected O, but got Unknown
		//IL_12e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1364: Unknown result type (might be due to invalid IL or missing references)
		//IL_136e: Expected O, but got Unknown
		//IL_13ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f6: Expected O, but got Unknown
		//IL_1697: Unknown result type (might be due to invalid IL or missing references)
		//IL_16bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_16df: Unknown result type (might be due to invalid IL or missing references)
		//IL_1703: Unknown result type (might be due to invalid IL or missing references)
		//IL_172c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1736: Expected O, but got Unknown
		//IL_175c: Unknown result type (might be due to invalid IL or missing references)
		//IL_17dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e7: Expected O, but got Unknown
		//IL_1865: Unknown result type (might be due to invalid IL or missing references)
		//IL_186f: Expected O, but got Unknown
		//IL_1b10: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b34: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b58: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1baf: Expected O, but got Unknown
		//IL_1bd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c56: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c60: Expected O, but got Unknown
		//IL_1cde: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce8: Expected O, but got Unknown
		//IL_1f89: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fad: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff5: Unknown result type (might be due to invalid IL or missing references)
		//IL_201e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2028: Expected O, but got Unknown
		//IL_204e: Unknown result type (might be due to invalid IL or missing references)
		//IL_20cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d9: Expected O, but got Unknown
		//IL_2157: Unknown result type (might be due to invalid IL or missing references)
		//IL_2161: Expected O, but got Unknown
		//IL_2402: Unknown result type (might be due to invalid IL or missing references)
		//IL_2426: Unknown result type (might be due to invalid IL or missing references)
		//IL_244a: Unknown result type (might be due to invalid IL or missing references)
		//IL_246e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2497: Unknown result type (might be due to invalid IL or missing references)
		//IL_24a1: Expected O, but got Unknown
		//IL_24c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2548: Unknown result type (might be due to invalid IL or missing references)
		//IL_2552: Expected O, but got Unknown
		//IL_25d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_25da: Expected O, but got Unknown
		//IL_287b: Unknown result type (might be due to invalid IL or missing references)
		//IL_289f: Unknown result type (might be due to invalid IL or missing references)
		//IL_28c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_28e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2910: Unknown result type (might be due to invalid IL or missing references)
		//IL_291a: Expected O, but got Unknown
		//IL_2940: Unknown result type (might be due to invalid IL or missing references)
		//IL_29c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_29cb: Expected O, but got Unknown
		//IL_2a49: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a53: Expected O, but got Unknown
		//IL_2cf4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d18: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d60: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d89: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d93: Expected O, but got Unknown
		//IL_2db9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e44: Expected O, but got Unknown
		//IL_2ec2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ecc: Expected O, but got Unknown
		//IL_316d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3191: Unknown result type (might be due to invalid IL or missing references)
		//IL_31b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_31d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3202: Unknown result type (might be due to invalid IL or missing references)
		//IL_320c: Expected O, but got Unknown
		//IL_322f: Unknown result type (might be due to invalid IL or missing references)
		//IL_32b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_32ba: Expected O, but got Unknown
		//IL_3335: Unknown result type (might be due to invalid IL or missing references)
		//IL_333f: Expected O, but got Unknown
		//IL_35dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3601: Unknown result type (might be due to invalid IL or missing references)
		//IL_3625: Unknown result type (might be due to invalid IL or missing references)
		//IL_3649: Unknown result type (might be due to invalid IL or missing references)
		//IL_3672: Unknown result type (might be due to invalid IL or missing references)
		//IL_367c: Expected O, but got Unknown
		//IL_369f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3720: Unknown result type (might be due to invalid IL or missing references)
		//IL_372a: Expected O, but got Unknown
		//IL_37a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_37af: Expected O, but got Unknown
		//IL_3a4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a71: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a95: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ab9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ae2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3aec: Expected O, but got Unknown
		//IL_3b0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b90: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b9a: Expected O, but got Unknown
		//IL_3c15: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c1f: Expected O, but got Unknown
		//IL_416c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4190: Unknown result type (might be due to invalid IL or missing references)
		//IL_41b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_41d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_4201: Unknown result type (might be due to invalid IL or missing references)
		//IL_420b: Expected O, but got Unknown
		//IL_422e: Unknown result type (might be due to invalid IL or missing references)
		//IL_42af: Unknown result type (might be due to invalid IL or missing references)
		//IL_42b9: Expected O, but got Unknown
		//IL_4334: Unknown result type (might be due to invalid IL or missing references)
		//IL_433e: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UT_SET_ADMIN));
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
		btnKrTouchHide = new QButton();
		cboKrTouchHide = new ComboBox();
		Label10 = new Label();
		btnSlYearSale = new QButton();
		cboSlYearSale = new ComboBox();
		Label9 = new Label();
		btnGlYearSale = new QButton();
		cboGlYearSale = new ComboBox();
		Label8 = new Label();
		btnPurcLot = new QButton();
		cboPurcLot = new ComboBox();
		Label7 = new Label();
		QButton1 = new QButton();
		cbobillprofit = new ComboBox();
		Label6 = new Label();
		btnSlNwtLock = new QButton();
		cboSlNwtLock = new ComboBox();
		Label5 = new Label();
		btnNegativeStk = new QButton();
		cboNegativeStk = new ComboBox();
		Label4 = new Label();
		btnOldPurcTch = new QButton();
		cboOldPurcTch = new ComboBox();
		Label3 = new Label();
		btnEstmateBank = new QButton();
		cboEstmatBank = new ComboBox();
		Label2 = new Label();
		btnCounterStk = new QButton();
		cboCounterStk = new ComboBox();
		Label1 = new Label();
		Tab1 = new SuperTabItem();
		TabPanel2 = new SuperTabControlPanel();
		Pnl2 = new Panel();
		Tab2 = new SuperTabItem();
		TabPanel3 = new SuperTabControlPanel();
		Pnl3 = new Panel();
		Tab3 = new SuperTabItem();
		BtnStkLimitWithDesign = new QButton();
		cboStklimitWithDesign = new ComboBox();
		Label11 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)TabMenu).BeginInit();
		((Control)TabMenu).SuspendLayout();
		((Control)TabPanel1).SuspendLayout();
		((Control)Pnl1).SuspendLayout();
		((Control)TabPanel2).SuspendLayout();
		((Control)TabPanel3).SuspendLayout();
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
		lblBook.Text = "Admin Setting";
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
		((Control)TabMenu).Controls.Add((Control)(object)TabPanel2);
		((Control)TabMenu).Controls.Add((Control)(object)TabPanel3);
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
		((Control)Pnl1).Controls.Add((Control)(object)BtnStkLimitWithDesign);
		((Control)Pnl1).Controls.Add((Control)(object)cboStklimitWithDesign);
		((Control)Pnl1).Controls.Add((Control)(object)Label11);
		((Control)Pnl1).Controls.Add((Control)(object)btnKrTouchHide);
		((Control)Pnl1).Controls.Add((Control)(object)cboKrTouchHide);
		((Control)Pnl1).Controls.Add((Control)(object)Label10);
		((Control)Pnl1).Controls.Add((Control)(object)btnSlYearSale);
		((Control)Pnl1).Controls.Add((Control)(object)cboSlYearSale);
		((Control)Pnl1).Controls.Add((Control)(object)Label9);
		((Control)Pnl1).Controls.Add((Control)(object)btnGlYearSale);
		((Control)Pnl1).Controls.Add((Control)(object)cboGlYearSale);
		((Control)Pnl1).Controls.Add((Control)(object)Label8);
		((Control)Pnl1).Controls.Add((Control)(object)btnPurcLot);
		((Control)Pnl1).Controls.Add((Control)(object)cboPurcLot);
		((Control)Pnl1).Controls.Add((Control)(object)Label7);
		((Control)Pnl1).Controls.Add((Control)(object)QButton1);
		((Control)Pnl1).Controls.Add((Control)(object)cbobillprofit);
		((Control)Pnl1).Controls.Add((Control)(object)Label6);
		((Control)Pnl1).Controls.Add((Control)(object)btnSlNwtLock);
		((Control)Pnl1).Controls.Add((Control)(object)cboSlNwtLock);
		((Control)Pnl1).Controls.Add((Control)(object)Label5);
		((Control)Pnl1).Controls.Add((Control)(object)btnNegativeStk);
		((Control)Pnl1).Controls.Add((Control)(object)cboNegativeStk);
		((Control)Pnl1).Controls.Add((Control)(object)Label4);
		((Control)Pnl1).Controls.Add((Control)(object)btnOldPurcTch);
		((Control)Pnl1).Controls.Add((Control)(object)cboOldPurcTch);
		((Control)Pnl1).Controls.Add((Control)(object)Label3);
		((Control)Pnl1).Controls.Add((Control)(object)btnEstmateBank);
		((Control)Pnl1).Controls.Add((Control)(object)cboEstmatBank);
		((Control)Pnl1).Controls.Add((Control)(object)Label2);
		((Control)Pnl1).Controls.Add((Control)(object)btnCounterStk);
		((Control)Pnl1).Controls.Add((Control)(object)cboCounterStk);
		((Control)Pnl1).Controls.Add((Control)(object)Label1);
		((Control)Pnl1).Dock = (DockStyle)5;
		((Control)Pnl1).Location = new Point(0, 0);
		((Control)Pnl1).Name = "Pnl1";
		((Control)Pnl1).Size = new Size(1309, 507);
		((Control)Pnl1).TabIndex = 0;
		((QControl)btnKrTouchHide).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnKrTouchHide).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnKrTouchHide).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnKrTouchHide).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnKrTouchHide).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnKrTouchHide).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnKrTouchHide).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnKrTouchHide).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnKrTouchHide).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnKrTouchHide).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnKrTouchHide).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnKrTouchHide).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnKrTouchHide).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnKrTouchHide).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnKrTouchHide.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrTouchHide.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrTouchHide.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrTouchHide.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnKrTouchHide.Image = null;
		((QControl)btnKrTouchHide).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnKrTouchHide).Location = new Point(413, 419);
		((Control)btnKrTouchHide).Margin = new Padding(3, 6, 3, 6);
		((Control)btnKrTouchHide).Name = "btnKrTouchHide";
		((Control)btnKrTouchHide).Size = new Size(121, 32);
		((Control)btnKrTouchHide).TabIndex = 1160;
		btnKrTouchHide.Text = "Kr Tch Hide";
		cboKrTouchHide.AutoCompleteMode = (AutoCompleteMode)2;
		cboKrTouchHide.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboKrTouchHide).Font = new Font("Tahoma", 9f);
		((ListControl)cboKrTouchHide).FormattingEnabled = true;
		((Control)cboKrTouchHide).Location = new Point(299, 425);
		cboKrTouchHide.MaxLength = 25;
		((Control)cboKrTouchHide).Name = "cboKrTouchHide";
		((Control)cboKrTouchHide).Size = new Size(106, 22);
		((Control)cboKrTouchHide).TabIndex = 1159;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(23, 425);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(264, 20);
		((Control)Label10).TabIndex = 1158;
		Label10.Text = "Tag Entry Then User Kr Touch Hide";
		Label10.TextAlign = (ContentAlignment)64;
		((QControl)btnSlYearSale).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSlYearSale).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSlYearSale).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSlYearSale).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSlYearSale).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSlYearSale).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSlYearSale).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnSlYearSale).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSlYearSale).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSlYearSale).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSlYearSale).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSlYearSale).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSlYearSale).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSlYearSale).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSlYearSale.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlYearSale.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlYearSale.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlYearSale.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlYearSale.Image = null;
		((QControl)btnSlYearSale).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnSlYearSale).Location = new Point(413, 375);
		((Control)btnSlYearSale).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSlYearSale).Name = "btnSlYearSale";
		((Control)btnSlYearSale).Size = new Size(121, 32);
		((Control)btnSlYearSale).TabIndex = 1157;
		btnSlYearSale.Text = "Silver Sale Set";
		cboSlYearSale.AutoCompleteMode = (AutoCompleteMode)2;
		cboSlYearSale.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboSlYearSale).Font = new Font("Tahoma", 9f);
		((ListControl)cboSlYearSale).FormattingEnabled = true;
		((Control)cboSlYearSale).Location = new Point(299, 381);
		cboSlYearSale.MaxLength = 25;
		((Control)cboSlYearSale).Name = "cboSlYearSale";
		((Control)cboSlYearSale).Size = new Size(106, 22);
		((Control)cboSlYearSale).TabIndex = 1156;
		((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(23, 381);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(264, 20);
		((Control)Label9).TabIndex = 1155;
		Label9.Text = "Yearly Silver Sale Target  In (kg)";
		Label9.TextAlign = (ContentAlignment)64;
		((QControl)btnGlYearSale).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnGlYearSale).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnGlYearSale).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnGlYearSale).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnGlYearSale).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnGlYearSale).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnGlYearSale).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnGlYearSale).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnGlYearSale).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnGlYearSale).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnGlYearSale).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnGlYearSale).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnGlYearSale).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnGlYearSale).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnGlYearSale.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGlYearSale.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGlYearSale.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGlYearSale.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGlYearSale.Image = null;
		((QControl)btnGlYearSale).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnGlYearSale).Location = new Point(413, 331);
		((Control)btnGlYearSale).Margin = new Padding(3, 6, 3, 6);
		((Control)btnGlYearSale).Name = "btnGlYearSale";
		((Control)btnGlYearSale).Size = new Size(121, 32);
		((Control)btnGlYearSale).TabIndex = 1154;
		btnGlYearSale.Text = "Gold Sale Set";
		cboGlYearSale.AutoCompleteMode = (AutoCompleteMode)2;
		cboGlYearSale.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboGlYearSale).Font = new Font("Tahoma", 9f);
		((ListControl)cboGlYearSale).FormattingEnabled = true;
		((Control)cboGlYearSale).Location = new Point(299, 337);
		cboGlYearSale.MaxLength = 25;
		((Control)cboGlYearSale).Name = "cboGlYearSale";
		((Control)cboGlYearSale).Size = new Size(106, 22);
		((Control)cboGlYearSale).TabIndex = 1153;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(23, 337);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(264, 20);
		((Control)Label8).TabIndex = 1152;
		Label8.Text = "Yearly Gold Sale Target  In (kg)";
		Label8.TextAlign = (ContentAlignment)64;
		((QControl)btnPurcLot).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnPurcLot).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPurcLot).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnPurcLot).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnPurcLot).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnPurcLot).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPurcLot).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnPurcLot).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnPurcLot).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnPurcLot).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnPurcLot).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnPurcLot).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnPurcLot).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnPurcLot).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnPurcLot.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcLot.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcLot.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcLot.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurcLot.Image = null;
		((QControl)btnPurcLot).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnPurcLot).Location = new Point(413, 287);
		((Control)btnPurcLot).Margin = new Padding(3, 6, 3, 6);
		((Control)btnPurcLot).Name = "btnPurcLot";
		((Control)btnPurcLot).Size = new Size(121, 32);
		((Control)btnPurcLot).TabIndex = 1151;
		btnPurcLot.Text = "Lot Gen Set";
		cboPurcLot.AutoCompleteMode = (AutoCompleteMode)2;
		cboPurcLot.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboPurcLot).Font = new Font("Tahoma", 9f);
		((ListControl)cboPurcLot).FormattingEnabled = true;
		((Control)cboPurcLot).Location = new Point(299, 293);
		cboPurcLot.MaxLength = 25;
		((Control)cboPurcLot).Name = "cboPurcLot";
		((Control)cboPurcLot).Size = new Size(106, 22);
		((Control)cboPurcLot).TabIndex = 1150;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(23, 293);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(264, 20);
		((Control)Label7).TabIndex = 1149;
		Label7.Text = "Lot Wise Purc and Tag Gen";
		Label7.TextAlign = (ContentAlignment)64;
		((QControl)QButton1).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)QButton1).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)QButton1).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)QButton1).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)QButton1).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)QButton1).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)QButton1).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)QButton1).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)QButton1).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)QButton1).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)QButton1).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)QButton1).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)QButton1).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)QButton1).ColorScheme).InheritCurrentThemeFromGlobal = false;
		QButton1.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		QButton1.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		QButton1.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		QButton1.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		QButton1.Image = null;
		((QControl)QButton1).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)QButton1).Location = new Point(413, 243);
		((Control)QButton1).Margin = new Padding(3, 6, 3, 6);
		((Control)QButton1).Name = "QButton1";
		((Control)QButton1).Size = new Size(121, 32);
		((Control)QButton1).TabIndex = 1148;
		QButton1.Text = "Bill Profit Set";
		cbobillprofit.AutoCompleteMode = (AutoCompleteMode)2;
		cbobillprofit.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cbobillprofit).Font = new Font("Tahoma", 9f);
		((ListControl)cbobillprofit).FormattingEnabled = true;
		((Control)cbobillprofit).Location = new Point(299, 249);
		cbobillprofit.MaxLength = 25;
		((Control)cbobillprofit).Name = "cbobillprofit";
		((Control)cbobillprofit).Size = new Size(106, 22);
		((Control)cbobillprofit).TabIndex = 1147;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(23, 249);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(264, 20);
		((Control)Label6).TabIndex = 1146;
		Label6.Text = "Sales Bill Profit Display";
		Label6.TextAlign = (ContentAlignment)64;
		((QControl)btnSlNwtLock).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSlNwtLock).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSlNwtLock).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSlNwtLock).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSlNwtLock).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSlNwtLock).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSlNwtLock).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnSlNwtLock).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSlNwtLock).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSlNwtLock).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSlNwtLock).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSlNwtLock).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSlNwtLock).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSlNwtLock).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSlNwtLock.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlNwtLock.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlNwtLock.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlNwtLock.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlNwtLock.Image = null;
		((QControl)btnSlNwtLock).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnSlNwtLock).Location = new Point(413, 199);
		((Control)btnSlNwtLock).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSlNwtLock).Name = "btnSlNwtLock";
		((Control)btnSlNwtLock).Size = new Size(121, 32);
		((Control)btnSlNwtLock).TabIndex = 1145;
		btnSlNwtLock.Text = "Nwt Wt Lock";
		cboSlNwtLock.AutoCompleteMode = (AutoCompleteMode)2;
		cboSlNwtLock.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboSlNwtLock).Font = new Font("Tahoma", 9f);
		((ListControl)cboSlNwtLock).FormattingEnabled = true;
		((Control)cboSlNwtLock).Location = new Point(299, 205);
		cboSlNwtLock.MaxLength = 25;
		((Control)cboSlNwtLock).Name = "cboSlNwtLock";
		((Control)cboSlNwtLock).Size = new Size(106, 22);
		((Control)cboSlNwtLock).TabIndex = 1144;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(33, 205);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(254, 20);
		((Control)Label5).TabIndex = 1143;
		Label5.Text = "Tag Wise Sale Then Entry Lock";
		Label5.TextAlign = (ContentAlignment)64;
		((QControl)btnNegativeStk).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnNegativeStk).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnNegativeStk).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnNegativeStk).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnNegativeStk).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnNegativeStk).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnNegativeStk).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnNegativeStk).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnNegativeStk).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnNegativeStk).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnNegativeStk).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnNegativeStk).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnNegativeStk).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnNegativeStk).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnNegativeStk.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnNegativeStk.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnNegativeStk.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnNegativeStk.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnNegativeStk.Image = null;
		((QControl)btnNegativeStk).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnNegativeStk).Location = new Point(413, 155);
		((Control)btnNegativeStk).Margin = new Padding(3, 6, 3, 6);
		((Control)btnNegativeStk).Name = "btnNegativeStk";
		((Control)btnNegativeStk).Size = new Size(121, 32);
		((Control)btnNegativeStk).TabIndex = 1142;
		btnNegativeStk.Text = "Sales Allow";
		cboNegativeStk.AutoCompleteMode = (AutoCompleteMode)2;
		cboNegativeStk.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboNegativeStk).Font = new Font("Tahoma", 9f);
		((ListControl)cboNegativeStk).FormattingEnabled = true;
		((Control)cboNegativeStk).Location = new Point(299, 161);
		cboNegativeStk.MaxLength = 25;
		((Control)cboNegativeStk).Name = "cboNegativeStk";
		((Control)cboNegativeStk).Size = new Size(106, 22);
		((Control)cboNegativeStk).TabIndex = 1141;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(33, 161);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(254, 20);
		((Control)Label4).TabIndex = 1140;
		Label4.Text = "Negative Stock Sales Allow";
		Label4.TextAlign = (ContentAlignment)64;
		((QControl)btnOldPurcTch).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOldPurcTch).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOldPurcTch).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOldPurcTch).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOldPurcTch).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOldPurcTch).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOldPurcTch).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnOldPurcTch).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOldPurcTch).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOldPurcTch).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOldPurcTch).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOldPurcTch).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnOldPurcTch).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOldPurcTch).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOldPurcTch.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOldPurcTch.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOldPurcTch.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOldPurcTch.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOldPurcTch.Image = null;
		((QControl)btnOldPurcTch).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnOldPurcTch).Location = new Point(413, 111);
		((Control)btnOldPurcTch).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOldPurcTch).Name = "btnOldPurcTch";
		((Control)btnOldPurcTch).Size = new Size(121, 32);
		((Control)btnOldPurcTch).TabIndex = 1139;
		btnOldPurcTch.Text = "Bank Entry Set";
		cboOldPurcTch.AutoCompleteMode = (AutoCompleteMode)2;
		cboOldPurcTch.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboOldPurcTch).Font = new Font("Tahoma", 9f);
		((ListControl)cboOldPurcTch).FormattingEnabled = true;
		((Control)cboOldPurcTch).Location = new Point(299, 117);
		cboOldPurcTch.MaxLength = 25;
		((Control)cboOldPurcTch).Name = "cboOldPurcTch";
		((Control)cboOldPurcTch).Size = new Size(106, 22);
		((Control)cboOldPurcTch).TabIndex = 1138;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(33, 117);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(254, 20);
		((Control)Label3).TabIndex = 1137;
		Label3.Text = "Old Purchase Touch Genrate";
		Label3.TextAlign = (ContentAlignment)64;
		((QControl)btnEstmateBank).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnEstmateBank).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnEstmateBank).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnEstmateBank).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnEstmateBank).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnEstmateBank).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnEstmateBank).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnEstmateBank).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnEstmateBank).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnEstmateBank).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnEstmateBank).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnEstmateBank).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnEstmateBank).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnEstmateBank).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnEstmateBank.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEstmateBank.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEstmateBank.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEstmateBank.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnEstmateBank.Image = null;
		((QControl)btnEstmateBank).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnEstmateBank).Location = new Point(413, 67);
		((Control)btnEstmateBank).Margin = new Padding(3, 6, 3, 6);
		((Control)btnEstmateBank).Name = "btnEstmateBank";
		((Control)btnEstmateBank).Size = new Size(121, 32);
		((Control)btnEstmateBank).TabIndex = 1136;
		btnEstmateBank.Text = "Bank Entry Set";
		cboEstmatBank.AutoCompleteMode = (AutoCompleteMode)2;
		cboEstmatBank.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboEstmatBank).Font = new Font("Tahoma", 9f);
		((ListControl)cboEstmatBank).FormattingEnabled = true;
		((Control)cboEstmatBank).Location = new Point(299, 73);
		cboEstmatBank.MaxLength = 25;
		((Control)cboEstmatBank).Name = "cboEstmatBank";
		((Control)cboEstmatBank).Size = new Size(106, 22);
		((Control)cboEstmatBank).TabIndex = 1135;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(16, 73);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(271, 20);
		((Control)Label2).TabIndex = 1134;
		Label2.Text = "Estmate Then Bank Rec Lock";
		Label2.TextAlign = (ContentAlignment)64;
		((QControl)btnCounterStk).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnCounterStk).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCounterStk).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnCounterStk).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnCounterStk).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnCounterStk).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCounterStk).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnCounterStk).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnCounterStk).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnCounterStk).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnCounterStk).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnCounterStk).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnCounterStk).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnCounterStk).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnCounterStk.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCounterStk.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCounterStk.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCounterStk.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCounterStk.Image = null;
		((QControl)btnCounterStk).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnCounterStk).Location = new Point(413, 23);
		((Control)btnCounterStk).Margin = new Padding(3, 6, 3, 6);
		((Control)btnCounterStk).Name = "btnCounterStk";
		((Control)btnCounterStk).Size = new Size(121, 32);
		((Control)btnCounterStk).TabIndex = 1133;
		btnCounterStk.Text = "Cntr Stk Set";
		cboCounterStk.AutoCompleteMode = (AutoCompleteMode)2;
		cboCounterStk.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboCounterStk).Font = new Font("Tahoma", 9f);
		((ListControl)cboCounterStk).FormattingEnabled = true;
		((Control)cboCounterStk).Location = new Point(299, 29);
		cboCounterStk.MaxLength = 25;
		((Control)cboCounterStk).Name = "cboCounterStk";
		((Control)cboCounterStk).Size = new Size(106, 22);
		((Control)cboCounterStk).TabIndex = 1132;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(16, 29);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(273, 20);
		((Control)Label1).TabIndex = 1131;
		Label1.Text = "Tag Entry Counter Mandatory";
		Label1.TextAlign = (ContentAlignment)64;
		Tab1.AttachedControl = (Control)(object)TabPanel1;
		((BaseItem)Tab1).GlobalItem = false;
		((BaseItem)Tab1).Name = "Tab1";
		Tab1.Text = "Setting1";
		Tab1.TextAlignment = (eItemAlignment)2;
		((Control)TabPanel2).Controls.Add((Control)(object)Pnl2);
		TabPanel2.Dock = (DockStyle)5;
		((Control)TabPanel2).Location = new Point(0, 0);
		((Control)TabPanel2).Name = "TabPanel2";
		((Control)TabPanel2).Size = new Size(1309, 507);
		((Control)TabPanel2).TabIndex = 0;
		TabPanel2.TabItem = Tab2;
		((Control)Pnl2).Dock = (DockStyle)5;
		((Control)Pnl2).Location = new Point(0, 0);
		((Control)Pnl2).Name = "Pnl2";
		((Control)Pnl2).Size = new Size(1309, 507);
		((Control)Pnl2).TabIndex = 0;
		Tab2.AttachedControl = (Control)(object)TabPanel2;
		((BaseItem)Tab2).GlobalItem = false;
		((BaseItem)Tab2).Name = "Tab2";
		Tab2.Text = "Setting2";
		Tab2.TextAlignment = (eItemAlignment)2;
		((Control)TabPanel3).Controls.Add((Control)(object)Pnl3);
		TabPanel3.Dock = (DockStyle)5;
		((Control)TabPanel3).Location = new Point(0, 0);
		((Control)TabPanel3).Name = "TabPanel3";
		((Control)TabPanel3).Size = new Size(1309, 507);
		((Control)TabPanel3).TabIndex = 0;
		TabPanel3.TabItem = Tab3;
		((Control)Pnl3).Dock = (DockStyle)5;
		((Control)Pnl3).Location = new Point(0, 0);
		((Control)Pnl3).Name = "Pnl3";
		((Control)Pnl3).Size = new Size(1309, 507);
		((Control)Pnl3).TabIndex = 1;
		Tab3.AttachedControl = (Control)(object)TabPanel3;
		((BaseItem)Tab3).GlobalItem = false;
		((BaseItem)Tab3).Name = "Tab3";
		Tab3.Text = "Setting3";
		Tab3.TextAlignment = (eItemAlignment)2;
		((QControl)BtnStkLimitWithDesign).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnStkLimitWithDesign).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnStkLimitWithDesign).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnStkLimitWithDesign).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnStkLimitWithDesign).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnStkLimitWithDesign).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnStkLimitWithDesign).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnStkLimitWithDesign).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnStkLimitWithDesign).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnStkLimitWithDesign).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnStkLimitWithDesign).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnStkLimitWithDesign).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnStkLimitWithDesign).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnStkLimitWithDesign).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnStkLimitWithDesign.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnStkLimitWithDesign.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnStkLimitWithDesign.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnStkLimitWithDesign.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnStkLimitWithDesign.Image = null;
		((QControl)BtnStkLimitWithDesign).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnStkLimitWithDesign).Location = new Point(1011, 23);
		((Control)BtnStkLimitWithDesign).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnStkLimitWithDesign).Name = "BtnStkLimitWithDesign";
		((Control)BtnStkLimitWithDesign).Size = new Size(121, 32);
		((Control)BtnStkLimitWithDesign).TabIndex = 1163;
		BtnStkLimitWithDesign.Text = "With Design Set";
		cboStklimitWithDesign.AutoCompleteMode = (AutoCompleteMode)2;
		cboStklimitWithDesign.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboStklimitWithDesign).Font = new Font("Tahoma", 9f);
		((ListControl)cboStklimitWithDesign).FormattingEnabled = true;
		((Control)cboStklimitWithDesign).Location = new Point(897, 29);
		cboStklimitWithDesign.MaxLength = 25;
		((Control)cboStklimitWithDesign).Name = "cboStklimitWithDesign";
		((Control)cboStklimitWithDesign).Size = new Size(106, 22);
		((Control)cboStklimitWithDesign).TabIndex = 1162;
		((Control)Label11).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(556, 29);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(331, 20);
		((Control)Label11).TabIndex = 1161;
		Label11.Text = "ItStk Limit Master With Design";
		Label11.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)TabMenu);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "UT_SET_ADMIN";
		((Form)this).Text = "Admin Setting";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)TabMenu).EndInit();
		((Control)TabMenu).ResumeLayout(false);
		((Control)TabPanel1).ResumeLayout(false);
		((Control)Pnl1).ResumeLayout(false);
		((Control)TabPanel2).ResumeLayout(false);
		((Control)TabPanel3).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	private void UT_SET_ADMIN_Load(object sender, EventArgs e)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_0e53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e5a: Expected O, but got Unknown
		//IL_0ec5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed4: Expected O, but got Unknown
		//IL_0f40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4b: Expected O, but got Unknown
		//IL_0fb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc4: Expected O, but got Unknown
		//IL_1032: Unknown result type (might be due to invalid IL or missing references)
		//IL_1037: Unknown result type (might be due to invalid IL or missing references)
		//IL_103d: Expected O, but got Unknown
		//IL_10ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b6: Expected O, but got Unknown
		//IL_113e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1143: Unknown result type (might be due to invalid IL or missing references)
		//IL_114d: Expected O, but got Unknown
		//IL_11bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ca: Expected O, but got Unknown
		//IL_1255: Unknown result type (might be due to invalid IL or missing references)
		//IL_125a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1260: Expected O, but got Unknown
		//IL_12b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_12bb: Expected O, but got Unknown
		//IL_12ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d8: Expected O, but got Unknown
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
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj8 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj9 = lblBook;
				object? obj10 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj9).ForeColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj11 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
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
				Font font3 = ((BaseStyleControl)BtnSave).Font;
				try
				{
					foreach (object control13 in ((Control)PnlBotam).Controls)
					{
						object objectValue11 = RuntimeHelpers.GetObjectValue(control13);
						NewLateBinding.LateSet(objectValue11, (Type)null, "Font", new object[1] { (object)new Font(font3.FontFamily, (float)num3, font3.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font3)?.Dispose();
				}
				TabMenu.SelectedTabFont = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				TabMenu.TabFont = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			CLEAR_DATA();
			cboCounterStk.Items.Add((object)"No");
			cboCounterStk.Items.Add((object)"Yes");
			cboEstmatBank.Items.Add((object)"No");
			cboEstmatBank.Items.Add((object)"Yes");
			cboOldPurcTch.Items.Add((object)"No");
			cboOldPurcTch.Items.Add((object)"Yes");
			cboNegativeStk.Items.Add((object)"No");
			cboNegativeStk.Items.Add((object)"Yes");
			cboSlNwtLock.Items.Add((object)"No");
			cboSlNwtLock.Items.Add((object)"Yes");
			cbobillprofit.Items.Add((object)"No");
			cbobillprofit.Items.Add((object)"Yes");
			cboPurcLot.Items.Add((object)"No");
			cboPurcLot.Items.Add((object)"Yes");
			cboKrTouchHide.Items.Add((object)"No");
			cboKrTouchHide.Items.Add((object)"Yes");
			cboStklimitWithDesign.Items.Add((object)"No");
			cboStklimitWithDesign.Items.Add((object)"Yes");
			DC_Main.RsQry = "SELECT * From CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboCounterStk.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["COUNTER_STK"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboEstmatBank.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ESTMATE_BANK_LOCK"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboOldPurcTch.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OLD_PURC_TOUCH"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboNegativeStk.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["NEGATIVE_STK_SALE"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboSlNwtLock.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_NWT_LOCK"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cbobillprofit.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BILL_PROFIT"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboPurcLot.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PURC_LOT"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboGlYearSale.Text = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["YEAR_GOLD_SL"], (object)"")), "0.000");
				cboSlYearSale.Text = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["YEAR_SILVER_SL"], (object)"")), "0.000");
				cboKrTouchHide.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["USER_KR_TOUCH_HIDE"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
				cboStklimitWithDesign.Text = Conversions.ToString(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["STK_LMIT_WITH_DESIGN"], (object)""), (object)"Y", false), (object)"Yes", (object)"No"));
			}
			EntryMode = "A";
		}
	}

	private void UT_SET_ADMIN_Activated(object sender, EventArgs e)
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

	private void UT_SET_ADMIN_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void UT_SET_ADMIN_KeyDown(object sender, KeyEventArgs e)
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

	private void UT_SET_ADMIN_Closed(object sender, EventArgs e)
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

	private void btnCounterStk_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET COUNTER_STK = '" + Strings.Mid(cboCounterStk.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsCntrStk = Strings.Mid(cboCounterStk.Text, 1, 1);
		Interaction.MsgBox((object)"Counter Wise Fild Mandatory....Set", (MsgBoxStyle)0, (object)null);
	}

	private void btnEstmateBank_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET ESTMATE_BANK_LOCK = '" + Strings.Mid(cboEstmatBank.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsEstmateBankLock = Strings.Mid(cboEstmatBank.Text, 1, 1);
		Interaction.MsgBox((object)"Estmate Entry Bank and Card Entry Locked....Set", (MsgBoxStyle)0, (object)null);
	}

	private void btnOldPurcTch_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET OLD_PURC_TOUCH = '" + Strings.Mid(cboOldPurcTch.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsOldPurcTchGen = Strings.Mid(cboOldPurcTch.Text, 1, 1);
		Interaction.MsgBox((object)"Old Gold Or Silver Purchase Then Touch Auto Generate....Set", (MsgBoxStyle)0, (object)null);
	}

	private void btnNegativeStk_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET NEGATIVE_STK_SALE = '" + Strings.Mid(cboNegativeStk.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsNegativeStkSale = Strings.Mid(cboNegativeStk.Text, 1, 1);
		Interaction.MsgBox((object)"Negative Stock Then Sales Allow....Set", (MsgBoxStyle)0, (object)null);
	}

	private void btnSlNwtLock_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET SL_NWT_LOCK = '" + Strings.Mid(cboSlNwtLock.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsSlNwtLock = Strings.Mid(cboSlNwtLock.Text, 1, 1);
		Interaction.MsgBox((object)"If Tag Sales Entry Then Net Wt and Gr Wt Is Locked....Set", (MsgBoxStyle)0, (object)null);
	}

	private void QButton1_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET BILL_PROFIT = '" + Strings.Mid(cbobillprofit.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsBillProfit = Strings.Mid(cbobillprofit.Text, 1, 1);
		Interaction.MsgBox((object)"Bill Profit display Set...", (MsgBoxStyle)0, (object)null);
	}

	private void BtnPurcLot_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET PURC_LOT = '" + Strings.Mid(cboPurcLot.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsPurcLot = Strings.Mid(cboPurcLot.Text, 1, 1);
		Interaction.MsgBox((object)"Lot Wise Purchase and Tag Manage...", (MsgBoxStyle)0, (object)null);
	}

	private void btnGlYearSale_Click(object sender, EventArgs e)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET YEAR_GOLD_SL = " + Conversions.ToString(Conversion.Val(cboGlYearSale.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsYearGoldSl = Conversion.Val(cboGlYearSale.Text);
		Interaction.MsgBox((object)"Yearly Gold Sales Value Set...You Can Show This Value In Main Screen...", (MsgBoxStyle)0, (object)null);
	}

	private void btnSlYearSale_Click(object sender, EventArgs e)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET YEAR_SILVER_SL = " + Conversions.ToString(Conversion.Val(cboSlYearSale.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsYearSilverSl = Conversion.Val(cboSlYearSale.Text);
		Interaction.MsgBox((object)"Yearly Silver Sales Value Set...You Can Show This Value In Main Screen...", (MsgBoxStyle)0, (object)null);
	}

	private void btnKrTouchHide_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET USER_KR_TOUCH_HIDE = '" + Strings.Mid(cboKrTouchHide.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsUserKrTouchHide = Strings.Mid(cboKrTouchHide.Text, 1, 1);
		Interaction.MsgBox((object)"Lot Wise Tag Entry and Software Open Wisth User Thne Kr Touch And Kr Fine Colum Hide...", (MsgBoxStyle)0, (object)null);
	}

	private void BtnStkLimitWithDesign_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET STK_LMIT_WITH_DESIGN = '" + Strings.Mid(cboStklimitWithDesign.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsStkLimitWithDesign = Strings.Mid(cboStklimitWithDesign.Text, 1, 1);
		Interaction.MsgBox((object)"Stock Limit Master With Design (tag Labour Set With ItCode + Desigh + From To to Weight) Set...", (MsgBoxStyle)0, (object)null);
	}
}
