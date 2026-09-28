#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraTabbedMdi;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;

namespace DataCareNext;

[DesignerGenerated]
public class MDI_FORM : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnTran")]
	private ToolStripButton _BtnTran;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnKrgr")]
	private ToolStripButton _BtnKrgr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnOth")]
	private ToolStripButton _BtnOth;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSchm")]
	private ToolStripButton _BtnSchm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnRpt")]
	private ToolStripButton _BtnRpt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDhrn")]
	private ToolStripButton _BtnDhrn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExit")]
	private ToolStripButton _BtnExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnMast")]
	private ToolStripButton _BtnMast;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("elementMail")]
	private AccordionControlElement _elementMail;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SLMain")]
	private AccordionControlElement _SLMain;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL0")]
	private AccordionControlElement _SL0;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL1")]
	private AccordionControlElement _SL1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL2")]
	private AccordionControlElement _SL2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL3")]
	private AccordionControlElement _SL3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL4")]
	private AccordionControlElement _SL4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL5")]
	private AccordionControlElement _SL5;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL6")]
	private AccordionControlElement _SL6;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL7")]
	private AccordionControlElement _SL7;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL8")]
	private AccordionControlElement _SL8;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL9")]
	private AccordionControlElement _SL9;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL10")]
	private AccordionControlElement _SL10;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL14")]
	private AccordionControlElement _SL14;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL15")]
	private AccordionControlElement _SL15;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL16")]
	private AccordionControlElement _SL16;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL17")]
	private AccordionControlElement _SL17;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL18")]
	private AccordionControlElement _SL18;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL19")]
	private AccordionControlElement _SL19;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL20")]
	private AccordionControlElement _SL20;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("elementCalendar")]
	private AccordionControlElement _elementCalendar;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("elementPeople")]
	private AccordionControlElement _elementPeople;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnComp")]
	private ToolStripButton _BtnComp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkLiveRate")]
	private CheckBox _chkLiveRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Timer1")]
	private Timer _Timer1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboTheme")]
	private ComboBox _cboTheme;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL11")]
	private AccordionControlElement _SL11;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL12")]
	private AccordionControlElement _SL12;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL13")]
	private AccordionControlElement _SL13;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL21")]
	private AccordionControlElement _SL21;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL22")]
	private AccordionControlElement _SL22;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL23")]
	private AccordionControlElement _SL23;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL24")]
	private AccordionControlElement _SL24;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL25")]
	private AccordionControlElement _SL25;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL26")]
	private AccordionControlElement _SL26;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL27")]
	private AccordionControlElement _SL27;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL28")]
	private AccordionControlElement _SL28;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL29")]
	private AccordionControlElement _SL29;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL30")]
	private AccordionControlElement _SL30;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL31")]
	private AccordionControlElement _SL31;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL32")]
	private AccordionControlElement _SL32;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL33")]
	private AccordionControlElement _SL33;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL34")]
	private AccordionControlElement _SL34;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL35")]
	private AccordionControlElement _SL35;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ShoF2Ledger")]
	private ToolStripMenuItem _ShoF2Ledger;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ShoF3Stock")]
	private ToolStripMenuItem _ShoF3Stock;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ShoF4SalesOrder")]
	private ToolStripMenuItem _ShoF4SalesOrder;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ShoF5SalesBill")]
	private ToolStripMenuItem _ShoF5SalesBill;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ShoF6WhSales")]
	private ToolStripMenuItem _ShoF6WhSales;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ShoF7Purc")]
	private ToolStripMenuItem _ShoF7Purc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ShoF8CashRec")]
	private ToolStripMenuItem _ShoF8CashRec;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ShoF9CashPayment")]
	private ToolStripMenuItem _ShoF9CashPayment;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ShoF11Rojmel")]
	private ToolStripMenuItem _ShoF11Rojmel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Shof12TagWiseStock")]
	private ToolStripMenuItem _Shof12TagWiseStock;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mMainDt")]
	private ToolStripTextBox _mMainDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnTran2")]
	private ToolStripButton _BtnTran2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ShoCtrlF12TagEstmate")]
	private ToolStripMenuItem _ShoCtrlF12TagEstmate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnHome")]
	private ToolStripButton _btnHome;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("F1CtrlDailyRateToolStripMenuItem")]
	private ToolStripMenuItem _F1CtrlDailyRateToolStripMenuItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL51")]
	private AccordionControlElement _SL51;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL52")]
	private AccordionControlElement _SL52;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL53")]
	private AccordionControlElement _SL53;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL54")]
	private AccordionControlElement _SL54;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL55")]
	private AccordionControlElement _SL55;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL56")]
	private AccordionControlElement _SL56;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL57")]
	private AccordionControlElement _SL57;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL58")]
	private AccordionControlElement _SL58;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL59")]
	private AccordionControlElement _SL59;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL60")]
	private AccordionControlElement _SL60;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("F11CtrlCashBankToolStripMenuItem")]
	private ToolStripMenuItem _F11CtrlCashBankToolStripMenuItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL75")]
	private AccordionControlElement _SL75;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL76")]
	private AccordionControlElement _SL76;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL77")]
	private AccordionControlElement _SL77;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL78")]
	private AccordionControlElement _SL78;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL79")]
	private AccordionControlElement _SL79;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL80")]
	private AccordionControlElement _SL80;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL81")]
	private AccordionControlElement _SL81;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL82")]
	private AccordionControlElement _SL82;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL83")]
	private AccordionControlElement _SL83;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL84")]
	private AccordionControlElement _SL84;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("F2CtrlOrderZoomToolStripMenuItem")]
	private ToolStripMenuItem _F2CtrlOrderZoomToolStripMenuItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkWappId")]
	private CheckBox _chkWappId;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnMfg")]
	private ToolStripButton _BtnMfg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LblUserRequest")]
	private Label _LblUserRequest;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL85")]
	private AccordionControlElement _SL85;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL86")]
	private AccordionControlElement _SL86;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL87")]
	private AccordionControlElement _SL87;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL88")]
	private AccordionControlElement _SL88;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL89")]
	private AccordionControlElement _SL89;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL90")]
	private AccordionControlElement _SL90;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL61")]
	private AccordionControlElement _SL61;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL62")]
	private AccordionControlElement _SL62;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL63")]
	private AccordionControlElement _SL63;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL64")]
	private AccordionControlElement _SL64;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SL65")]
	private AccordionControlElement _SL65;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ShoCtrlF8BankRec")]
	private ToolStripMenuItem _ShoCtrlF8BankRec;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ShoCtrlF9BankPay")]
	private ToolStripMenuItem _ShoCtrlF9BankPay;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ShoCtrlF6RateCut")]
	private ToolStripMenuItem _ShoCtrlF6RateCut;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ShoCtrlF5BillRec")]
	private ToolStripMenuItem _ShoCtrlF5BillRec;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkNextAi")]
	private CheckBox _chkNextAi;

	private bool FirstTimeLodMdi;

	private string MsSideBtn;

	private bool RptAnalysis;

	private double ColCon;

	private DataTable RsMenu;

	private DataTable RsRight;

	private bool TileMenuOpen;

	private int Lr;

	private bool RjkDate;

	private string CodVal;

	private bool FooterMenuClick;

	private string LcMenuOpen;

	private bool ScreenSet;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("myTimer")]
	private Timer _myTimer;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bar6")]
	private virtual Bar _bar6;

	private virtual Bar bar6
	{
		get
		{
			return _bar6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_bar6 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MainTrip")]
	private virtual ToolStrip _MainTrip;

	internal virtual ToolStrip MainTrip
	{
		get
		{
			return _MainTrip;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_MainTrip = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Sp1")]
	private virtual ToolStripSeparator _Sp1;

	internal virtual ToolStripSeparator Sp1
	{
		get
		{
			return _Sp1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Sp1 = value;
		}
	}

	internal virtual ToolStripButton BtnTran
	{
		[CompilerGenerated]
		get
		{
			return _BtnTran;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTran_Click;
			ToolStripButton val = _BtnTran;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_BtnTran = value;
			val = _BtnTran;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Sp3")]
	private virtual ToolStripSeparator _Sp3;

	internal virtual ToolStripSeparator Sp3
	{
		get
		{
			return _Sp3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Sp3 = value;
		}
	}

	internal virtual ToolStripButton BtnKrgr
	{
		[CompilerGenerated]
		get
		{
			return _BtnKrgr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnKrgr_Click;
			ToolStripButton val = _BtnKrgr;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_BtnKrgr = value;
			val = _BtnKrgr;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Sp4")]
	private virtual ToolStripSeparator _Sp4;

	internal virtual ToolStripSeparator Sp4
	{
		get
		{
			return _Sp4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Sp4 = value;
		}
	}

	internal virtual ToolStripButton BtnOth
	{
		[CompilerGenerated]
		get
		{
			return _BtnOth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOth_Click;
			ToolStripButton val = _BtnOth;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_BtnOth = value;
			val = _BtnOth;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Sp5")]
	private virtual ToolStripSeparator _Sp5;

	internal virtual ToolStripSeparator Sp5
	{
		get
		{
			return _Sp5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Sp5 = value;
		}
	}

	internal virtual ToolStripButton BtnSchm
	{
		[CompilerGenerated]
		get
		{
			return _BtnSchm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSchm_Click;
			ToolStripButton val = _BtnSchm;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_BtnSchm = value;
			val = _BtnSchm;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Sp6")]
	private virtual ToolStripSeparator _Sp6;

	internal virtual ToolStripSeparator Sp6
	{
		get
		{
			return _Sp6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Sp6 = value;
		}
	}

	internal virtual ToolStripButton BtnRpt
	{
		[CompilerGenerated]
		get
		{
			return _BtnRpt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnRpt_Click;
			ToolStripButton val = _BtnRpt;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_BtnRpt = value;
			val = _BtnRpt;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Sp7")]
	private virtual ToolStripSeparator _Sp7;

	internal virtual ToolStripSeparator Sp7
	{
		get
		{
			return _Sp7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Sp7 = value;
		}
	}

	internal virtual ToolStripButton BtnDhrn
	{
		[CompilerGenerated]
		get
		{
			return _BtnDhrn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDhrn_Click;
			ToolStripButton val = _BtnDhrn;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_BtnDhrn = value;
			val = _BtnDhrn;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Sp8")]
	private virtual ToolStripSeparator _Sp8;

	internal virtual ToolStripSeparator Sp8
	{
		get
		{
			return _Sp8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Sp8 = value;
		}
	}

	internal virtual ToolStripButton BtnExit
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
			ToolStripButton val = _BtnExit;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_BtnExit = value;
			val = _BtnExit;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Panel_Side")]
	private virtual Panel _Panel_Side;

	internal virtual Panel Panel_Side
	{
		get
		{
			return _Panel_Side;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Panel_Side = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("xtraTabbedMdiManager1")]
	private virtual XtraTabbedMdiManager _xtraTabbedMdiManager1;

	internal virtual XtraTabbedMdiManager xtraTabbedMdiManager1
	{
		get
		{
			return _xtraTabbedMdiManager1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_xtraTabbedMdiManager1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("bsiRecordsCount")]
	private virtual BarStaticItem _bsiRecordsCount;

	private virtual BarStaticItem bsiRecordsCount
	{
		get
		{
			return _bsiRecordsCount;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_bsiRecordsCount = value;
		}
	}

	internal virtual ToolStripButton BtnMast
	{
		[CompilerGenerated]
		get
		{
			return _BtnMast;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnMast_Click;
			ToolStripButton val = _BtnMast;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_BtnMast = value;
			val = _BtnMast;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripSeparator1")]
	private virtual ToolStripSeparator _ToolStripSeparator1;

	internal virtual ToolStripSeparator ToolStripSeparator1
	{
		get
		{
			return _ToolStripSeparator1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_ToolStripSeparator1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SideTrip")]
	private virtual AccordionControl _SideTrip;

	private virtual AccordionControl SideTrip
	{
		get
		{
			return _SideTrip;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_SideTrip = value;
		}
	}

	private virtual AccordionControlElement elementMail
	{
		[CompilerGenerated]
		get
		{
			return _elementMail;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = elementMail_Click;
			AccordionControlElement val = _elementMail;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_elementMail = value;
			val = _elementMail;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	private virtual AccordionControlElement SLMain
	{
		[CompilerGenerated]
		get
		{
			return _SLMain;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SLMain_Click;
			AccordionControlElement val = _SLMain;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SLMain = value;
			val = _SLMain;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL0
	{
		[CompilerGenerated]
		get
		{
			return _SL0;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL0_Click;
			AccordionControlElement val = _SL0;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL0 = value;
			val = _SL0;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL1
	{
		[CompilerGenerated]
		get
		{
			return _SL1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL1_Click;
			AccordionControlElement val = _SL1;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL1 = value;
			val = _SL1;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL2
	{
		[CompilerGenerated]
		get
		{
			return _SL2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL2_Click;
			AccordionControlElement val = _SL2;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL2 = value;
			val = _SL2;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL3
	{
		[CompilerGenerated]
		get
		{
			return _SL3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL3_Click;
			AccordionControlElement val = _SL3;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL3 = value;
			val = _SL3;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL4
	{
		[CompilerGenerated]
		get
		{
			return _SL4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL4_Click;
			AccordionControlElement val = _SL4;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL4 = value;
			val = _SL4;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL5
	{
		[CompilerGenerated]
		get
		{
			return _SL5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL5_Click;
			AccordionControlElement val = _SL5;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL5 = value;
			val = _SL5;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SLMain2")]
	private virtual AccordionControlElement _SLMain2;

	private virtual AccordionControlElement SLMain2
	{
		get
		{
			return _SLMain2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_SLMain2 = value;
		}
	}

	internal virtual AccordionControlElement SL6
	{
		[CompilerGenerated]
		get
		{
			return _SL6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL6_Click;
			AccordionControlElement val = _SL6;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL6 = value;
			val = _SL6;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL7
	{
		[CompilerGenerated]
		get
		{
			return _SL7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL7_Click;
			AccordionControlElement val = _SL7;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL7 = value;
			val = _SL7;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL8
	{
		[CompilerGenerated]
		get
		{
			return _SL8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL8_Click;
			AccordionControlElement val = _SL8;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL8 = value;
			val = _SL8;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL9
	{
		[CompilerGenerated]
		get
		{
			return _SL9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL9_Click;
			AccordionControlElement val = _SL9;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL9 = value;
			val = _SL9;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL10
	{
		[CompilerGenerated]
		get
		{
			return _SL10;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL10_Click;
			AccordionControlElement val = _SL10;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL10 = value;
			val = _SL10;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SLMain3")]
	private virtual AccordionControlElement _SLMain3;

	private virtual AccordionControlElement SLMain3
	{
		get
		{
			return _SLMain3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_SLMain3 = value;
		}
	}

	internal virtual AccordionControlElement SL14
	{
		[CompilerGenerated]
		get
		{
			return _SL14;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL14_Click;
			AccordionControlElement val = _SL14;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL14 = value;
			val = _SL14;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL15
	{
		[CompilerGenerated]
		get
		{
			return _SL15;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL15_Click;
			AccordionControlElement val = _SL15;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL15 = value;
			val = _SL15;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL16
	{
		[CompilerGenerated]
		get
		{
			return _SL16;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL16_Click;
			AccordionControlElement val = _SL16;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL16 = value;
			val = _SL16;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL17
	{
		[CompilerGenerated]
		get
		{
			return _SL17;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL17_Click;
			AccordionControlElement val = _SL17;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL17 = value;
			val = _SL17;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL18
	{
		[CompilerGenerated]
		get
		{
			return _SL18;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL18_Click;
			AccordionControlElement val = _SL18;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL18 = value;
			val = _SL18;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL19
	{
		[CompilerGenerated]
		get
		{
			return _SL19;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL19_Click;
			AccordionControlElement val = _SL19;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL19 = value;
			val = _SL19;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL20
	{
		[CompilerGenerated]
		get
		{
			return _SL20;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL20_Click;
			AccordionControlElement val = _SL20;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL20 = value;
			val = _SL20;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	private virtual AccordionControlElement elementCalendar
	{
		[CompilerGenerated]
		get
		{
			return _elementCalendar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = elementCalendar_Click;
			AccordionControlElement val = _elementCalendar;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_elementCalendar = value;
			val = _elementCalendar;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	private virtual AccordionControlElement elementPeople
	{
		[CompilerGenerated]
		get
		{
			return _elementPeople;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = elementPeople_Click;
			AccordionControlElement val = _elementPeople;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_elementPeople = value;
			val = _elementPeople;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripSeparator2")]
	private virtual ToolStripSeparator _ToolStripSeparator2;

	internal virtual ToolStripSeparator ToolStripSeparator2
	{
		get
		{
			return _ToolStripSeparator2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_ToolStripSeparator2 = value;
		}
	}

	internal virtual ToolStripButton BtnComp
	{
		[CompilerGenerated]
		get
		{
			return _BtnComp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnComp_Click;
			ToolStripButton val = _BtnComp;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_BtnComp = value;
			val = _BtnComp;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PanelImage")]
	private virtual Panel _PanelImage;

	internal virtual Panel PanelImage
	{
		get
		{
			return _PanelImage;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PanelImage = value;
		}
	}

	internal virtual CheckBox chkLiveRate
	{
		[CompilerGenerated]
		get
		{
			return _chkLiveRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkLiveRate_Click;
			CheckBox val = _chkLiveRate;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_chkLiveRate = value;
			val = _chkLiveRate;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Timer Timer1
	{
		[CompilerGenerated]
		get
		{
			return _Timer1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Timer1_Tick;
			Timer val = _Timer1;
			if (val != null)
			{
				val.Tick -= eventHandler;
			}
			_Timer1 = value;
			val = _Timer1;
			if (val != null)
			{
				val.Tick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCurrncyRate")]
	private virtual TextBox _nCurrncyRate;

	internal virtual TextBox nCurrncyRate
	{
		get
		{
			return _nCurrncyRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nCurrncyRate = value;
		}
	}

	internal virtual ComboBox cboTheme
	{
		[CompilerGenerated]
		get
		{
			return _cboTheme;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = CboTheme_SelectedIndexChanged;
			ComboBox val = _cboTheme;
			if (val != null)
			{
				val.SelectedIndexChanged -= eventHandler;
			}
			_cboTheme = value;
			val = _cboTheme;
			if (val != null)
			{
				val.SelectedIndexChanged += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL11
	{
		[CompilerGenerated]
		get
		{
			return _SL11;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL11_Click;
			AccordionControlElement val = _SL11;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL11 = value;
			val = _SL11;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL12
	{
		[CompilerGenerated]
		get
		{
			return _SL12;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL12_Click;
			AccordionControlElement val = _SL12;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL12 = value;
			val = _SL12;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL13
	{
		[CompilerGenerated]
		get
		{
			return _SL13;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL13_Click;
			AccordionControlElement val = _SL13;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL13 = value;
			val = _SL13;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL21
	{
		[CompilerGenerated]
		get
		{
			return _SL21;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL21_Click;
			AccordionControlElement val = _SL21;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL21 = value;
			val = _SL21;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL22
	{
		[CompilerGenerated]
		get
		{
			return _SL22;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL22_Click;
			AccordionControlElement val = _SL22;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL22 = value;
			val = _SL22;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL23
	{
		[CompilerGenerated]
		get
		{
			return _SL23;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL23_Click;
			AccordionControlElement val = _SL23;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL23 = value;
			val = _SL23;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL24
	{
		[CompilerGenerated]
		get
		{
			return _SL24;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL24_Click;
			AccordionControlElement val = _SL24;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL24 = value;
			val = _SL24;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL25
	{
		[CompilerGenerated]
		get
		{
			return _SL25;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL25_Click;
			AccordionControlElement val = _SL25;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL25 = value;
			val = _SL25;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL26
	{
		[CompilerGenerated]
		get
		{
			return _SL26;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL26_Click;
			AccordionControlElement val = _SL26;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL26 = value;
			val = _SL26;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL27
	{
		[CompilerGenerated]
		get
		{
			return _SL27;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL27_Click;
			AccordionControlElement val = _SL27;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL27 = value;
			val = _SL27;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL28
	{
		[CompilerGenerated]
		get
		{
			return _SL28;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL28_Click;
			AccordionControlElement val = _SL28;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL28 = value;
			val = _SL28;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL29
	{
		[CompilerGenerated]
		get
		{
			return _SL29;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL29_Click;
			AccordionControlElement val = _SL29;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL29 = value;
			val = _SL29;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL30
	{
		[CompilerGenerated]
		get
		{
			return _SL30;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL30_Click;
			AccordionControlElement val = _SL30;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL30 = value;
			val = _SL30;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL31
	{
		[CompilerGenerated]
		get
		{
			return _SL31;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL31_Click;
			AccordionControlElement val = _SL31;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL31 = value;
			val = _SL31;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL32
	{
		[CompilerGenerated]
		get
		{
			return _SL32;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL32_Click;
			AccordionControlElement val = _SL32;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL32 = value;
			val = _SL32;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL33
	{
		[CompilerGenerated]
		get
		{
			return _SL33;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL33_Click;
			AccordionControlElement val = _SL33;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL33 = value;
			val = _SL33;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL34
	{
		[CompilerGenerated]
		get
		{
			return _SL34;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL34_Click;
			AccordionControlElement val = _SL34;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL34 = value;
			val = _SL34;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL35
	{
		[CompilerGenerated]
		get
		{
			return _SL35;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL35_Click;
			AccordionControlElement val = _SL35;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL35 = value;
			val = _SL35;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MenuShort")]
	private virtual ToolStripDropDownButton _MenuShort;

	internal virtual ToolStripDropDownButton MenuShort
	{
		get
		{
			return _MenuShort;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_MenuShort = value;
		}
	}

	internal virtual ToolStripMenuItem ShoF2Ledger
	{
		[CompilerGenerated]
		get
		{
			return _ShoF2Ledger;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ShoF2Ledger_Click;
			ToolStripMenuItem val = _ShoF2Ledger;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ShoF2Ledger = value;
			val = _ShoF2Ledger;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripMenuItem ShoF3Stock
	{
		[CompilerGenerated]
		get
		{
			return _ShoF3Stock;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ShoF3Stock_Click;
			ToolStripMenuItem val = _ShoF3Stock;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ShoF3Stock = value;
			val = _ShoF3Stock;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripMenuItem ShoF4SalesOrder
	{
		[CompilerGenerated]
		get
		{
			return _ShoF4SalesOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ShoF4SalesOrder_Click;
			ToolStripMenuItem val = _ShoF4SalesOrder;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ShoF4SalesOrder = value;
			val = _ShoF4SalesOrder;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripMenuItem ShoF5SalesBill
	{
		[CompilerGenerated]
		get
		{
			return _ShoF5SalesBill;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ShoF5SalesBill_Click;
			ToolStripMenuItem val = _ShoF5SalesBill;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ShoF5SalesBill = value;
			val = _ShoF5SalesBill;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripMenuItem ShoF6WhSales
	{
		[CompilerGenerated]
		get
		{
			return _ShoF6WhSales;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ShoF6WhSales_Click;
			ToolStripMenuItem val = _ShoF6WhSales;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ShoF6WhSales = value;
			val = _ShoF6WhSales;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripMenuItem ShoF7Purc
	{
		[CompilerGenerated]
		get
		{
			return _ShoF7Purc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ShoF7Purc_Click;
			ToolStripMenuItem val = _ShoF7Purc;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ShoF7Purc = value;
			val = _ShoF7Purc;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripMenuItem ShoF8CashRec
	{
		[CompilerGenerated]
		get
		{
			return _ShoF8CashRec;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ShoF8CashRec_Click;
			ToolStripMenuItem val = _ShoF8CashRec;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ShoF8CashRec = value;
			val = _ShoF8CashRec;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripMenuItem ShoF9CashPayment
	{
		[CompilerGenerated]
		get
		{
			return _ShoF9CashPayment;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ShoF9CashPayment_Click;
			ToolStripMenuItem val = _ShoF9CashPayment;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ShoF9CashPayment = value;
			val = _ShoF9CashPayment;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ShoF10Reminder")]
	private virtual ToolStripMenuItem _ShoF10Reminder;

	internal virtual ToolStripMenuItem ShoF10Reminder
	{
		get
		{
			return _ShoF10Reminder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_ShoF10Reminder = value;
		}
	}

	internal virtual ToolStripMenuItem ShoF11Rojmel
	{
		[CompilerGenerated]
		get
		{
			return _ShoF11Rojmel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ShoF11Rojmel_Click;
			ToolStripMenuItem val = _ShoF11Rojmel;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ShoF11Rojmel = value;
			val = _ShoF11Rojmel;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripMenuItem Shof12TagWiseStock
	{
		[CompilerGenerated]
		get
		{
			return _Shof12TagWiseStock;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Shof12TagWiseStock_Click;
			ToolStripMenuItem val = _Shof12TagWiseStock;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_Shof12TagWiseStock = value;
			val = _Shof12TagWiseStock;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSoftDemoType")]
	private virtual TextBox _tSoftDemoType;

	internal virtual TextBox tSoftDemoType
	{
		get
		{
			return _tSoftDemoType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tSoftDemoType = value;
		}
	}

	internal virtual ToolStripTextBox mMainDt
	{
		[CompilerGenerated]
		get
		{
			return _mMainDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mMainDt_KeyDown);
			KeyEventHandler val2 = new KeyEventHandler(mMainDt_KeyUp);
			EventHandler eventHandler = mMainDt_Click;
			ToolStripTextBox val3 = _mMainDt;
			if (val3 != null)
			{
				((ToolStripControlHost)val3).KeyDown -= val;
				((ToolStripControlHost)val3).KeyUp -= val2;
				((ToolStripItem)val3).Click -= eventHandler;
			}
			_mMainDt = value;
			val3 = _mMainDt;
			if (val3 != null)
			{
				((ToolStripControlHost)val3).KeyDown += val;
				((ToolStripControlHost)val3).KeyUp += val2;
				((ToolStripItem)val3).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripLabel1")]
	private virtual ToolStripLabel _ToolStripLabel1;

	internal virtual ToolStripLabel ToolStripLabel1
	{
		get
		{
			return _ToolStripLabel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_ToolStripLabel1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ToolStripLabel2")]
	private virtual ToolStripLabel _ToolStripLabel2;

	internal virtual ToolStripLabel ToolStripLabel2
	{
		get
		{
			return _ToolStripLabel2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_ToolStripLabel2 = value;
		}
	}

	internal virtual ToolStripButton BtnTran2
	{
		[CompilerGenerated]
		get
		{
			return _BtnTran2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTran2_Click;
			ToolStripButton val = _BtnTran2;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_BtnTran2 = value;
			val = _BtnTran2;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SpTran2")]
	private virtual ToolStripSeparator _SpTran2;

	internal virtual ToolStripSeparator SpTran2
	{
		get
		{
			return _SpTran2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_SpTran2 = value;
		}
	}

	internal virtual ToolStripMenuItem ShoCtrlF12TagEstmate
	{
		[CompilerGenerated]
		get
		{
			return _ShoCtrlF12TagEstmate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ShoCtrlF12TagEstmate_Click;
			ToolStripMenuItem val = _ShoCtrlF12TagEstmate;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ShoCtrlF12TagEstmate = value;
			val = _ShoCtrlF12TagEstmate;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FolderBrowserDialog1")]
	private virtual FolderBrowserDialog _FolderBrowserDialog1;

	internal virtual FolderBrowserDialog FolderBrowserDialog1
	{
		get
		{
			return _FolderBrowserDialog1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_FolderBrowserDialog1 = value;
		}
	}

	internal virtual ToolStripButton btnHome
	{
		[CompilerGenerated]
		get
		{
			return _btnHome;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnHome_Click;
			ToolStripButton val = _btnHome;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_btnHome = value;
			val = _btnHome;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripMenuItem F1CtrlDailyRateToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _F1CtrlDailyRateToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = F1CtrlDailyRateToolStripMenuItem_Click;
			ToolStripMenuItem val = _F1CtrlDailyRateToolStripMenuItem;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_F1CtrlDailyRateToolStripMenuItem = value;
			val = _F1CtrlDailyRateToolStripMenuItem;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL51
	{
		[CompilerGenerated]
		get
		{
			return _SL51;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL51_Click;
			AccordionControlElement val = _SL51;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL51 = value;
			val = _SL51;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL52
	{
		[CompilerGenerated]
		get
		{
			return _SL52;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL52_Click;
			AccordionControlElement val = _SL52;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL52 = value;
			val = _SL52;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL53
	{
		[CompilerGenerated]
		get
		{
			return _SL53;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL53_Click;
			AccordionControlElement val = _SL53;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL53 = value;
			val = _SL53;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL54
	{
		[CompilerGenerated]
		get
		{
			return _SL54;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL54_Click;
			AccordionControlElement val = _SL54;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL54 = value;
			val = _SL54;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL55
	{
		[CompilerGenerated]
		get
		{
			return _SL55;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL55_Click;
			AccordionControlElement val = _SL55;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL55 = value;
			val = _SL55;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL56
	{
		[CompilerGenerated]
		get
		{
			return _SL56;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL56_Click;
			AccordionControlElement val = _SL56;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL56 = value;
			val = _SL56;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL57
	{
		[CompilerGenerated]
		get
		{
			return _SL57;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL57_Click;
			AccordionControlElement val = _SL57;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL57 = value;
			val = _SL57;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL58
	{
		[CompilerGenerated]
		get
		{
			return _SL58;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL58_Click;
			AccordionControlElement val = _SL58;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL58 = value;
			val = _SL58;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL59
	{
		[CompilerGenerated]
		get
		{
			return _SL59;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL59_Click;
			AccordionControlElement val = _SL59;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL59 = value;
			val = _SL59;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL60
	{
		[CompilerGenerated]
		get
		{
			return _SL60;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL60_Click;
			AccordionControlElement val = _SL60;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL60 = value;
			val = _SL60;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SLMain4")]
	private virtual AccordionControlElement _SLMain4;

	private virtual AccordionControlElement SLMain4
	{
		get
		{
			return _SLMain4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_SLMain4 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Rate_1")]
	private virtual Label _Rate_1;

	internal virtual Label Rate_1
	{
		get
		{
			return _Rate_1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Rate_1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Rate_4")]
	private virtual Label _Rate_4;

	internal virtual Label Rate_4
	{
		get
		{
			return _Rate_4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Rate_4 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Rate_3")]
	private virtual Label _Rate_3;

	internal virtual Label Rate_3
	{
		get
		{
			return _Rate_3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Rate_3 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Rate_2")]
	private virtual Label _Rate_2;

	internal virtual Label Rate_2
	{
		get
		{
			return _Rate_2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Rate_2 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Rate_5")]
	private virtual Label _Rate_5;

	internal virtual Label Rate_5
	{
		get
		{
			return _Rate_5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Rate_5 = value;
		}
	}

	internal virtual ToolStripMenuItem F11CtrlCashBankToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _F11CtrlCashBankToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = F11CtrlCashBankToolStripMenuItem_Click;
			ToolStripMenuItem val = _F11CtrlCashBankToolStripMenuItem;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_F11CtrlCashBankToolStripMenuItem = value;
			val = _F11CtrlCashBankToolStripMenuItem;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Rate_7")]
	private virtual Label _Rate_7;

	internal virtual Label Rate_7
	{
		get
		{
			return _Rate_7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Rate_7 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Rate_6")]
	private virtual Label _Rate_6;

	internal virtual Label Rate_6
	{
		get
		{
			return _Rate_6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Rate_6 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SLMain5")]
	private virtual AccordionControlElement _SLMain5;

	internal virtual AccordionControlElement SLMain5
	{
		get
		{
			return _SLMain5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_SLMain5 = value;
		}
	}

	internal virtual AccordionControlElement SL75
	{
		[CompilerGenerated]
		get
		{
			return _SL75;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL75_Click;
			AccordionControlElement val = _SL75;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL75 = value;
			val = _SL75;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL76
	{
		[CompilerGenerated]
		get
		{
			return _SL76;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL76_Click;
			AccordionControlElement val = _SL76;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL76 = value;
			val = _SL76;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL77
	{
		[CompilerGenerated]
		get
		{
			return _SL77;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL77_Click;
			AccordionControlElement val = _SL77;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL77 = value;
			val = _SL77;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL78
	{
		[CompilerGenerated]
		get
		{
			return _SL78;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL78_Click;
			AccordionControlElement val = _SL78;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL78 = value;
			val = _SL78;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL79
	{
		[CompilerGenerated]
		get
		{
			return _SL79;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL79_Click;
			AccordionControlElement val = _SL79;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL79 = value;
			val = _SL79;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL80
	{
		[CompilerGenerated]
		get
		{
			return _SL80;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL80_Click;
			AccordionControlElement val = _SL80;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL80 = value;
			val = _SL80;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL81
	{
		[CompilerGenerated]
		get
		{
			return _SL81;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL81_Click;
			AccordionControlElement val = _SL81;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL81 = value;
			val = _SL81;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL82
	{
		[CompilerGenerated]
		get
		{
			return _SL82;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL82_Click;
			AccordionControlElement val = _SL82;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL82 = value;
			val = _SL82;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL83
	{
		[CompilerGenerated]
		get
		{
			return _SL83;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL83_Click;
			AccordionControlElement val = _SL83;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL83 = value;
			val = _SL83;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL84
	{
		[CompilerGenerated]
		get
		{
			return _SL84;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL84_Click;
			AccordionControlElement val = _SL84;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL84 = value;
			val = _SL84;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("AccordionControlElement1")]
	private virtual AccordionControlElement _AccordionControlElement1;

	internal virtual AccordionControlElement AccordionControlElement1
	{
		get
		{
			return _AccordionControlElement1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_AccordionControlElement1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("AccordionControlElement2")]
	private virtual AccordionControlElement _AccordionControlElement2;

	internal virtual AccordionControlElement AccordionControlElement2
	{
		get
		{
			return _AccordionControlElement2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_AccordionControlElement2 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("AccordionControlElement3")]
	private virtual AccordionControlElement _AccordionControlElement3;

	internal virtual AccordionControlElement AccordionControlElement3
	{
		get
		{
			return _AccordionControlElement3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_AccordionControlElement3 = value;
		}
	}

	internal virtual ToolStripMenuItem F2CtrlOrderZoomToolStripMenuItem
	{
		[CompilerGenerated]
		get
		{
			return _F2CtrlOrderZoomToolStripMenuItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = F2CtrlOrderZoomToolStripMenuItem_Click;
			ToolStripMenuItem val = _F2CtrlOrderZoomToolStripMenuItem;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_F2CtrlOrderZoomToolStripMenuItem = value;
			val = _F2CtrlOrderZoomToolStripMenuItem;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual CheckBox chkWappId
	{
		[CompilerGenerated]
		get
		{
			return _chkWappId;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkWappId_Click;
			EventHandler eventHandler2 = chkWappId_CheckedChanged;
			CheckBox val = _chkWappId;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
				val.CheckedChanged -= eventHandler2;
			}
			_chkWappId = value;
			val = _chkWappId;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
				val.CheckedChanged += eventHandler2;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Sp9")]
	private virtual ToolStripSeparator _Sp9;

	internal virtual ToolStripSeparator Sp9
	{
		get
		{
			return _Sp9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Sp9 = value;
		}
	}

	internal virtual ToolStripButton BtnMfg
	{
		[CompilerGenerated]
		get
		{
			return _BtnMfg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnMfg_Click;
			ToolStripButton val = _BtnMfg;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_BtnMfg = value;
			val = _BtnMfg;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual Label LblUserRequest
	{
		[CompilerGenerated]
		get
		{
			return _LblUserRequest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = LblUserRequest_Click;
			Label val = _LblUserRequest;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_LblUserRequest = value;
			val = _LblUserRequest;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblLiveRate")]
	private virtual Label _lblLiveRate;

	internal virtual Label lblLiveRate
	{
		get
		{
			return _lblLiveRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblLiveRate = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAmcDate")]
	private virtual Label _tAmcDate;

	internal virtual Label tAmcDate
	{
		get
		{
			return _tAmcDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tAmcDate = value;
		}
	}

	internal virtual AccordionControlElement SL85
	{
		[CompilerGenerated]
		get
		{
			return _SL85;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL85_Click;
			AccordionControlElement val = _SL85;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL85 = value;
			val = _SL85;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL86
	{
		[CompilerGenerated]
		get
		{
			return _SL86;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL86_Click;
			AccordionControlElement val = _SL86;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL86 = value;
			val = _SL86;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL87
	{
		[CompilerGenerated]
		get
		{
			return _SL87;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL87_Click;
			AccordionControlElement val = _SL87;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL87 = value;
			val = _SL87;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL88
	{
		[CompilerGenerated]
		get
		{
			return _SL88;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL88_Click;
			AccordionControlElement val = _SL88;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL88 = value;
			val = _SL88;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL89
	{
		[CompilerGenerated]
		get
		{
			return _SL89;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL89_Click;
			AccordionControlElement val = _SL89;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL89 = value;
			val = _SL89;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL90
	{
		[CompilerGenerated]
		get
		{
			return _SL90;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL90_Click;
			AccordionControlElement val = _SL90;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL90 = value;
			val = _SL90;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LblSilverSl")]
	private virtual Label _LblSilverSl;

	internal virtual Label LblSilverSl
	{
		get
		{
			return _LblSilverSl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LblSilverSl = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LblGoldSl")]
	private virtual Label _LblGoldSl;

	internal virtual Label LblGoldSl
	{
		get
		{
			return _LblGoldSl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LblGoldSl = value;
		}
	}

	internal virtual AccordionControlElement SL61
	{
		[CompilerGenerated]
		get
		{
			return _SL61;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL61_Click;
			AccordionControlElement val = _SL61;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL61 = value;
			val = _SL61;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL62
	{
		[CompilerGenerated]
		get
		{
			return _SL62;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL62_Click;
			AccordionControlElement val = _SL62;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL62 = value;
			val = _SL62;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL63
	{
		[CompilerGenerated]
		get
		{
			return _SL63;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL63_Click;
			AccordionControlElement val = _SL63;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL63 = value;
			val = _SL63;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL64
	{
		[CompilerGenerated]
		get
		{
			return _SL64;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL64_Click;
			AccordionControlElement val = _SL64;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL64 = value;
			val = _SL64;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	internal virtual AccordionControlElement SL65
	{
		[CompilerGenerated]
		get
		{
			return _SL65;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SL65_Click;
			AccordionControlElement val = _SL65;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click -= eventHandler;
			}
			_SL65 = value;
			val = _SL65;
			if (val != null)
			{
				((AccordionControlElementBase)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SLMain6")]
	private virtual AccordionControlElement _SLMain6;

	internal virtual AccordionControlElement SLMain6
	{
		get
		{
			return _SLMain6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_SLMain6 = value;
		}
	}

	internal virtual ToolStripMenuItem ShoCtrlF8BankRec
	{
		[CompilerGenerated]
		get
		{
			return _ShoCtrlF8BankRec;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ShoCtrlF8BankRec_Click;
			ToolStripMenuItem val = _ShoCtrlF8BankRec;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ShoCtrlF8BankRec = value;
			val = _ShoCtrlF8BankRec;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripMenuItem ShoCtrlF9BankPay
	{
		[CompilerGenerated]
		get
		{
			return _ShoCtrlF9BankPay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ShoCtrlF9BankPay_Click;
			ToolStripMenuItem val = _ShoCtrlF9BankPay;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ShoCtrlF9BankPay = value;
			val = _ShoCtrlF9BankPay;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripMenuItem ShoCtrlF6RateCut
	{
		[CompilerGenerated]
		get
		{
			return _ShoCtrlF6RateCut;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ShoCtrlF6RateCut_Click;
			ToolStripMenuItem val = _ShoCtrlF6RateCut;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ShoCtrlF6RateCut = value;
			val = _ShoCtrlF6RateCut;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual ToolStripMenuItem ShoCtrlF5BillRec
	{
		[CompilerGenerated]
		get
		{
			return _ShoCtrlF5BillRec;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ShoCtrlF5BillRec_Click;
			ToolStripMenuItem val = _ShoCtrlF5BillRec;
			if (val != null)
			{
				((ToolStripItem)val).Click -= eventHandler;
			}
			_ShoCtrlF5BillRec = value;
			val = _ShoCtrlF5BillRec;
			if (val != null)
			{
				((ToolStripItem)val).Click += eventHandler;
			}
		}
	}

	internal virtual CheckBox chkNextAi
	{
		[CompilerGenerated]
		get
		{
			return _chkNextAi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkNextAi_Click;
			EventHandler eventHandler2 = chkNextAi_CheckedChanged;
			CheckBox val = _chkNextAi;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
				val.CheckedChanged -= eventHandler2;
			}
			_chkNextAi = value;
			val = _chkNextAi;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
				val.CheckedChanged += eventHandler2;
			}
		}
	}

	private virtual Timer myTimer
	{
		[CompilerGenerated]
		get
		{
			return _myTimer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = myTimer_Tick;
			Timer val = _myTimer;
			if (val != null)
			{
				val.Tick -= eventHandler;
			}
			_myTimer = value;
			val = _myTimer;
			if (val != null)
			{
				val.Tick += eventHandler;
			}
		}
	}

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = ((Form)this).CreateParams;
			createParams.ClassStyle |= 0x200;
			return createParams;
		}
	}

	public MDI_FORM()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		((Form)this).Load += MDI_FORM_Load;
		((Control)this).KeyDown += new KeyEventHandler(MDI_FORM_KeyDown);
		((Form)this).FormClosed += new FormClosedEventHandler(MDI_FORM_FormClosed);
		((Form)this).Activated += MDI_FORM_Activated;
		((Control)this).KeyUp += new KeyEventHandler(MDI_FORM_KeyUp);
		CodVal = "";
		myTimer = new Timer();
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
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected O, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Expected O, but got Unknown
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected O, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected O, but got Unknown
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected O, but got Unknown
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected O, but got Unknown
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Expected O, but got Unknown
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected O, but got Unknown
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Expected O, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected O, but got Unknown
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected O, but got Unknown
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Expected O, but got Unknown
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Expected O, but got Unknown
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected O, but got Unknown
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Expected O, but got Unknown
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Expected O, but got Unknown
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Expected O, but got Unknown
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Expected O, but got Unknown
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Expected O, but got Unknown
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Expected O, but got Unknown
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Expected O, but got Unknown
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Expected O, but got Unknown
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0399: Expected O, but got Unknown
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Expected O, but got Unknown
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Expected O, but got Unknown
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Expected O, but got Unknown
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Expected O, but got Unknown
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Expected O, but got Unknown
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Expected O, but got Unknown
		//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ed: Expected O, but got Unknown
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Expected O, but got Unknown
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Expected O, but got Unknown
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Expected O, but got Unknown
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Expected O, but got Unknown
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Expected O, but got Unknown
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Expected O, but got Unknown
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Expected O, but got Unknown
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Expected O, but got Unknown
		//IL_044f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Expected O, but got Unknown
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Expected O, but got Unknown
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Expected O, but got Unknown
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_047d: Expected O, but got Unknown
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Expected O, but got Unknown
		//IL_048b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0495: Expected O, but got Unknown
		//IL_0497: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a1: Expected O, but got Unknown
		//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Expected O, but got Unknown
		//IL_04af: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b9: Expected O, but got Unknown
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c5: Expected O, but got Unknown
		//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d1: Expected O, but got Unknown
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dd: Expected O, but got Unknown
		//IL_04df: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e9: Expected O, but got Unknown
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f5: Expected O, but got Unknown
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0501: Expected O, but got Unknown
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		//IL_050d: Expected O, but got Unknown
		//IL_050f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0519: Expected O, but got Unknown
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0525: Expected O, but got Unknown
		//IL_0527: Unknown result type (might be due to invalid IL or missing references)
		//IL_0531: Expected O, but got Unknown
		//IL_0533: Unknown result type (might be due to invalid IL or missing references)
		//IL_053d: Expected O, but got Unknown
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Expected O, but got Unknown
		//IL_054b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Expected O, but got Unknown
		//IL_0557: Unknown result type (might be due to invalid IL or missing references)
		//IL_0561: Expected O, but got Unknown
		//IL_0563: Unknown result type (might be due to invalid IL or missing references)
		//IL_056d: Expected O, but got Unknown
		//IL_056f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Expected O, but got Unknown
		//IL_057b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0585: Expected O, but got Unknown
		//IL_0587: Unknown result type (might be due to invalid IL or missing references)
		//IL_0591: Expected O, but got Unknown
		//IL_0593: Unknown result type (might be due to invalid IL or missing references)
		//IL_059d: Expected O, but got Unknown
		//IL_059f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a9: Expected O, but got Unknown
		//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b5: Expected O, but got Unknown
		//IL_05b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c1: Expected O, but got Unknown
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cd: Expected O, but got Unknown
		//IL_05cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d9: Expected O, but got Unknown
		//IL_05db: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Expected O, but got Unknown
		//IL_05e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f1: Expected O, but got Unknown
		//IL_05f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fd: Expected O, but got Unknown
		//IL_05ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0609: Expected O, but got Unknown
		//IL_060b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0615: Expected O, but got Unknown
		//IL_0617: Unknown result type (might be due to invalid IL or missing references)
		//IL_0621: Expected O, but got Unknown
		//IL_0623: Unknown result type (might be due to invalid IL or missing references)
		//IL_062d: Expected O, but got Unknown
		//IL_062f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Expected O, but got Unknown
		//IL_063b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0645: Expected O, but got Unknown
		//IL_0647: Unknown result type (might be due to invalid IL or missing references)
		//IL_0651: Expected O, but got Unknown
		//IL_0653: Unknown result type (might be due to invalid IL or missing references)
		//IL_065d: Expected O, but got Unknown
		//IL_065f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0669: Expected O, but got Unknown
		//IL_066b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0675: Expected O, but got Unknown
		//IL_0677: Unknown result type (might be due to invalid IL or missing references)
		//IL_0681: Expected O, but got Unknown
		//IL_0683: Unknown result type (might be due to invalid IL or missing references)
		//IL_068d: Expected O, but got Unknown
		//IL_068f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0699: Expected O, but got Unknown
		//IL_069b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a5: Expected O, but got Unknown
		//IL_06a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b1: Expected O, but got Unknown
		//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bd: Expected O, but got Unknown
		//IL_06bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c9: Expected O, but got Unknown
		//IL_06cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d5: Expected O, but got Unknown
		//IL_06d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e1: Expected O, but got Unknown
		//IL_06e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ed: Expected O, but got Unknown
		//IL_06ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f9: Expected O, but got Unknown
		//IL_06fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0705: Expected O, but got Unknown
		//IL_0707: Unknown result type (might be due to invalid IL or missing references)
		//IL_0711: Expected O, but got Unknown
		//IL_0713: Unknown result type (might be due to invalid IL or missing references)
		//IL_071d: Expected O, but got Unknown
		//IL_0725: Unknown result type (might be due to invalid IL or missing references)
		//IL_072f: Expected O, but got Unknown
		//IL_0731: Unknown result type (might be due to invalid IL or missing references)
		//IL_073b: Expected O, but got Unknown
		//IL_073d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0747: Expected O, but got Unknown
		//IL_0749: Unknown result type (might be due to invalid IL or missing references)
		//IL_0753: Expected O, but got Unknown
		//IL_0755: Unknown result type (might be due to invalid IL or missing references)
		//IL_075f: Expected O, but got Unknown
		//IL_1016: Unknown result type (might be due to invalid IL or missing references)
		//IL_1020: Expected O, but got Unknown
		//IL_10e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f2: Expected O, but got Unknown
		//IL_11c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ca: Expected O, but got Unknown
		//IL_12a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b0: Expected O, but got Unknown
		//IL_137b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1385: Expected O, but got Unknown
		//IL_1442: Unknown result type (might be due to invalid IL or missing references)
		//IL_144c: Expected O, but got Unknown
		//IL_1509: Unknown result type (might be due to invalid IL or missing references)
		//IL_1513: Expected O, but got Unknown
		//IL_15d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_15da: Expected O, but got Unknown
		//IL_1697: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a1: Expected O, but got Unknown
		//IL_175e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1768: Expected O, but got Unknown
		//IL_1825: Unknown result type (might be due to invalid IL or missing references)
		//IL_182f: Expected O, but got Unknown
		//IL_18ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f6: Expected O, but got Unknown
		//IL_19b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_19bd: Expected O, but got Unknown
		//IL_1a84: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b79: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b83: Expected O, but got Unknown
		//IL_1cca: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd4: Expected O, but got Unknown
		//IL_1d54: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d5e: Expected O, but got Unknown
		//IL_1dde: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de8: Expected O, but got Unknown
		//IL_1f59: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f63: Expected O, but got Unknown
		//IL_1f9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fa4: Expected O, but got Unknown
		//IL_1fdb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fe5: Expected O, but got Unknown
		//IL_201c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2026: Expected O, but got Unknown
		//IL_208c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2096: Expected O, but got Unknown
		//IL_20cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d7: Expected O, but got Unknown
		//IL_210e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2118: Expected O, but got Unknown
		//IL_214f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2159: Expected O, but got Unknown
		//IL_21bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_21c9: Expected O, but got Unknown
		//IL_2200: Unknown result type (might be due to invalid IL or missing references)
		//IL_220a: Expected O, but got Unknown
		//IL_2241: Unknown result type (might be due to invalid IL or missing references)
		//IL_224b: Expected O, but got Unknown
		//IL_2282: Unknown result type (might be due to invalid IL or missing references)
		//IL_228c: Expected O, but got Unknown
		//IL_22f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_22fc: Expected O, but got Unknown
		//IL_2333: Unknown result type (might be due to invalid IL or missing references)
		//IL_233d: Expected O, but got Unknown
		//IL_2374: Unknown result type (might be due to invalid IL or missing references)
		//IL_237e: Expected O, but got Unknown
		//IL_23b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_23bf: Expected O, but got Unknown
		//IL_2425: Unknown result type (might be due to invalid IL or missing references)
		//IL_242f: Expected O, but got Unknown
		//IL_2466: Unknown result type (might be due to invalid IL or missing references)
		//IL_2470: Expected O, but got Unknown
		//IL_24a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_24b1: Expected O, but got Unknown
		//IL_24e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_24f2: Expected O, but got Unknown
		//IL_2558: Unknown result type (might be due to invalid IL or missing references)
		//IL_2562: Expected O, but got Unknown
		//IL_2599: Unknown result type (might be due to invalid IL or missing references)
		//IL_25a3: Expected O, but got Unknown
		//IL_25da: Unknown result type (might be due to invalid IL or missing references)
		//IL_25e4: Expected O, but got Unknown
		//IL_261b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2625: Expected O, but got Unknown
		//IL_268b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2695: Expected O, but got Unknown
		//IL_26cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_26d6: Expected O, but got Unknown
		//IL_270d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2717: Expected O, but got Unknown
		//IL_274e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2758: Expected O, but got Unknown
		//IL_27be: Unknown result type (might be due to invalid IL or missing references)
		//IL_27c8: Expected O, but got Unknown
		//IL_27ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_2809: Expected O, but got Unknown
		//IL_2840: Unknown result type (might be due to invalid IL or missing references)
		//IL_284a: Expected O, but got Unknown
		//IL_2881: Unknown result type (might be due to invalid IL or missing references)
		//IL_288b: Expected O, but got Unknown
		//IL_28f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_28fb: Expected O, but got Unknown
		//IL_2932: Unknown result type (might be due to invalid IL or missing references)
		//IL_293c: Expected O, but got Unknown
		//IL_2973: Unknown result type (might be due to invalid IL or missing references)
		//IL_297d: Expected O, but got Unknown
		//IL_29b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_29be: Expected O, but got Unknown
		//IL_2a24: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a2e: Expected O, but got Unknown
		//IL_2a65: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a6f: Expected O, but got Unknown
		//IL_2aa6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ab0: Expected O, but got Unknown
		//IL_2ae7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2af1: Expected O, but got Unknown
		//IL_2b57: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b61: Expected O, but got Unknown
		//IL_2b98: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ba2: Expected O, but got Unknown
		//IL_2bd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2be3: Expected O, but got Unknown
		//IL_2c1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c24: Expected O, but got Unknown
		//IL_2c8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c94: Expected O, but got Unknown
		//IL_2ccb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cd5: Expected O, but got Unknown
		//IL_2d0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d16: Expected O, but got Unknown
		//IL_2d4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d57: Expected O, but got Unknown
		//IL_2dbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dc7: Expected O, but got Unknown
		//IL_2dfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e08: Expected O, but got Unknown
		//IL_2e3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e49: Expected O, but got Unknown
		//IL_2e80: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e8a: Expected O, but got Unknown
		//IL_2ef0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2efa: Expected O, but got Unknown
		//IL_2f31: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f3b: Expected O, but got Unknown
		//IL_2f72: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f7c: Expected O, but got Unknown
		//IL_2fb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fbd: Expected O, but got Unknown
		//IL_3023: Unknown result type (might be due to invalid IL or missing references)
		//IL_302d: Expected O, but got Unknown
		//IL_3064: Unknown result type (might be due to invalid IL or missing references)
		//IL_306e: Expected O, but got Unknown
		//IL_30a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_30af: Expected O, but got Unknown
		//IL_30e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_30f0: Expected O, but got Unknown
		//IL_3156: Unknown result type (might be due to invalid IL or missing references)
		//IL_3160: Expected O, but got Unknown
		//IL_3197: Unknown result type (might be due to invalid IL or missing references)
		//IL_31a1: Expected O, but got Unknown
		//IL_31d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_31e2: Expected O, but got Unknown
		//IL_3219: Unknown result type (might be due to invalid IL or missing references)
		//IL_3223: Expected O, but got Unknown
		//IL_32b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_32bc: Expected O, but got Unknown
		//IL_3326: Unknown result type (might be due to invalid IL or missing references)
		//IL_3330: Expected O, but got Unknown
		//IL_3368: Unknown result type (might be due to invalid IL or missing references)
		//IL_3372: Expected O, but got Unknown
		//IL_33f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_33fa: Expected O, but got Unknown
		//IL_3477: Unknown result type (might be due to invalid IL or missing references)
		//IL_3481: Expected O, but got Unknown
		//IL_356e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3574: Expected O, but got Unknown
		//IL_3578: Unknown result type (might be due to invalid IL or missing references)
		//IL_357e: Expected O, but got Unknown
		//IL_3581: Unknown result type (might be due to invalid IL or missing references)
		//IL_3587: Expected O, but got Unknown
		//IL_358a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3590: Expected O, but got Unknown
		//IL_35ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_35b6: Expected O, but got Unknown
		//IL_361e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3628: Expected O, but got Unknown
		//IL_365f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3669: Expected O, but got Unknown
		//IL_36a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_36aa: Expected O, but got Unknown
		//IL_36db: Unknown result type (might be due to invalid IL or missing references)
		//IL_36e1: Expected O, but got Unknown
		//IL_36e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_36ea: Expected O, but got Unknown
		//IL_36ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_36f3: Expected O, but got Unknown
		//IL_36f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_36fc: Expected O, but got Unknown
		//IL_374b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3755: Expected O, but got Unknown
		//IL_378c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3796: Expected O, but got Unknown
		//IL_37cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_37d7: Expected O, but got Unknown
		//IL_383d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3847: Expected O, but got Unknown
		//IL_387e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3888: Expected O, but got Unknown
		//IL_38bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_38c9: Expected O, but got Unknown
		//IL_392f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3939: Expected O, but got Unknown
		//IL_3970: Unknown result type (might be due to invalid IL or missing references)
		//IL_397a: Expected O, but got Unknown
		//IL_39b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_39bb: Expected O, but got Unknown
		//IL_3a21: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a2b: Expected O, but got Unknown
		//IL_3a62: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a6c: Expected O, but got Unknown
		//IL_3aa3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3aad: Expected O, but got Unknown
		//IL_3b13: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b1d: Expected O, but got Unknown
		//IL_3b54: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b5e: Expected O, but got Unknown
		//IL_3b95: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b9f: Expected O, but got Unknown
		//IL_3c05: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c0f: Expected O, but got Unknown
		//IL_3c46: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c50: Expected O, but got Unknown
		//IL_3c87: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c91: Expected O, but got Unknown
		//IL_3cf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d01: Expected O, but got Unknown
		//IL_3d38: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d42: Expected O, but got Unknown
		//IL_3d79: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d83: Expected O, but got Unknown
		//IL_3de9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3df3: Expected O, but got Unknown
		//IL_3e2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e34: Expected O, but got Unknown
		//IL_3e6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e75: Expected O, but got Unknown
		//IL_3edb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ee5: Expected O, but got Unknown
		//IL_3f1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f26: Expected O, but got Unknown
		//IL_3f5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f67: Expected O, but got Unknown
		//IL_3fce: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fd8: Expected O, but got Unknown
		//IL_4056: Unknown result type (might be due to invalid IL or missing references)
		//IL_4060: Expected O, but got Unknown
		//IL_40de: Unknown result type (might be due to invalid IL or missing references)
		//IL_40e8: Expected O, but got Unknown
		//IL_4141: Unknown result type (might be due to invalid IL or missing references)
		//IL_414b: Expected O, but got Unknown
		//IL_4182: Unknown result type (might be due to invalid IL or missing references)
		//IL_418c: Expected O, but got Unknown
		//IL_41c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_41cd: Expected O, but got Unknown
		//IL_4233: Unknown result type (might be due to invalid IL or missing references)
		//IL_423d: Expected O, but got Unknown
		//IL_4274: Unknown result type (might be due to invalid IL or missing references)
		//IL_427e: Expected O, but got Unknown
		//IL_42b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_42bf: Expected O, but got Unknown
		//IL_4325: Unknown result type (might be due to invalid IL or missing references)
		//IL_432f: Expected O, but got Unknown
		//IL_4366: Unknown result type (might be due to invalid IL or missing references)
		//IL_4370: Expected O, but got Unknown
		//IL_43a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_43b1: Expected O, but got Unknown
		//IL_4417: Unknown result type (might be due to invalid IL or missing references)
		//IL_4421: Expected O, but got Unknown
		//IL_4458: Unknown result type (might be due to invalid IL or missing references)
		//IL_4462: Expected O, but got Unknown
		//IL_4499: Unknown result type (might be due to invalid IL or missing references)
		//IL_44a3: Expected O, but got Unknown
		//IL_4509: Unknown result type (might be due to invalid IL or missing references)
		//IL_4513: Expected O, but got Unknown
		//IL_454a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4554: Expected O, but got Unknown
		//IL_458b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4595: Expected O, but got Unknown
		//IL_46c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_46d1: Expected O, but got Unknown
		//IL_473d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4747: Expected O, but got Unknown
		//IL_4781: Unknown result type (might be due to invalid IL or missing references)
		//IL_478b: Expected O, but got Unknown
		//IL_480b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4815: Expected O, but got Unknown
		//IL_4895: Unknown result type (might be due to invalid IL or missing references)
		//IL_489f: Expected O, but got Unknown
		//IL_4a05: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a0b: Expected O, but got Unknown
		//IL_4a0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a14: Expected O, but got Unknown
		//IL_4a17: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a1d: Expected O, but got Unknown
		//IL_4a20: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a26: Expected O, but got Unknown
		//IL_4a4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a59: Expected O, but got Unknown
		//IL_4ac5: Unknown result type (might be due to invalid IL or missing references)
		//IL_4acf: Expected O, but got Unknown
		//IL_4b09: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b13: Expected O, but got Unknown
		//IL_4b4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b57: Expected O, but got Unknown
		//IL_4b91: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b9b: Expected O, but got Unknown
		//IL_4c5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c66: Expected O, but got Unknown
		//IL_4ca0: Unknown result type (might be due to invalid IL or missing references)
		//IL_4caa: Expected O, but got Unknown
		//IL_4ce4: Unknown result type (might be due to invalid IL or missing references)
		//IL_4cee: Expected O, but got Unknown
		//IL_4d65: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d6b: Expected O, but got Unknown
		//IL_4d6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d74: Expected O, but got Unknown
		//IL_4d77: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d7d: Expected O, but got Unknown
		//IL_4d80: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d86: Expected O, but got Unknown
		//IL_4dea: Unknown result type (might be due to invalid IL or missing references)
		//IL_4df4: Expected O, but got Unknown
		//IL_4e2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4e38: Expected O, but got Unknown
		//IL_4e72: Unknown result type (might be due to invalid IL or missing references)
		//IL_4e7c: Expected O, but got Unknown
		//IL_4ef3: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ef9: Expected O, but got Unknown
		//IL_4efc: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f02: Expected O, but got Unknown
		//IL_4f05: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f0b: Expected O, but got Unknown
		//IL_4f0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f14: Expected O, but got Unknown
		//IL_4f66: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f70: Expected O, but got Unknown
		//IL_4faa: Unknown result type (might be due to invalid IL or missing references)
		//IL_4fb4: Expected O, but got Unknown
		//IL_4fee: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ff8: Expected O, but got Unknown
		//IL_50a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_50b1: Expected O, but got Unknown
		//IL_50eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_50f5: Expected O, but got Unknown
		//IL_512f: Unknown result type (might be due to invalid IL or missing references)
		//IL_5139: Expected O, but got Unknown
		//IL_51e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_51f2: Expected O, but got Unknown
		//IL_522c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5236: Expected O, but got Unknown
		//IL_5270: Unknown result type (might be due to invalid IL or missing references)
		//IL_527a: Expected O, but got Unknown
		//IL_5329: Unknown result type (might be due to invalid IL or missing references)
		//IL_5333: Expected O, but got Unknown
		//IL_536d: Unknown result type (might be due to invalid IL or missing references)
		//IL_5377: Expected O, but got Unknown
		//IL_53b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_53bb: Expected O, but got Unknown
		//IL_546a: Unknown result type (might be due to invalid IL or missing references)
		//IL_5474: Expected O, but got Unknown
		//IL_54ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_54b8: Expected O, but got Unknown
		//IL_54f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_54fc: Expected O, but got Unknown
		//IL_55ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_55b5: Expected O, but got Unknown
		//IL_55ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_55f9: Expected O, but got Unknown
		//IL_5633: Unknown result type (might be due to invalid IL or missing references)
		//IL_563d: Expected O, but got Unknown
		//IL_56ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_56f6: Expected O, but got Unknown
		//IL_5730: Unknown result type (might be due to invalid IL or missing references)
		//IL_573a: Expected O, but got Unknown
		//IL_5774: Unknown result type (might be due to invalid IL or missing references)
		//IL_577e: Expected O, but got Unknown
		//IL_582d: Unknown result type (might be due to invalid IL or missing references)
		//IL_5837: Expected O, but got Unknown
		//IL_5871: Unknown result type (might be due to invalid IL or missing references)
		//IL_587b: Expected O, but got Unknown
		//IL_58b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_58bf: Expected O, but got Unknown
		//IL_596e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5978: Expected O, but got Unknown
		//IL_59b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_59bc: Expected O, but got Unknown
		//IL_59f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_5a00: Expected O, but got Unknown
		//IL_5aaf: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ab9: Expected O, but got Unknown
		//IL_5af3: Unknown result type (might be due to invalid IL or missing references)
		//IL_5afd: Expected O, but got Unknown
		//IL_5b37: Unknown result type (might be due to invalid IL or missing references)
		//IL_5b41: Expected O, but got Unknown
		//IL_5baa: Unknown result type (might be due to invalid IL or missing references)
		//IL_5bb4: Expected O, but got Unknown
		//IL_5bee: Unknown result type (might be due to invalid IL or missing references)
		//IL_5bf8: Expected O, but got Unknown
		//IL_5c32: Unknown result type (might be due to invalid IL or missing references)
		//IL_5c3c: Expected O, but got Unknown
		//IL_5ceb: Unknown result type (might be due to invalid IL or missing references)
		//IL_5cf5: Expected O, but got Unknown
		//IL_5d2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_5d39: Expected O, but got Unknown
		//IL_5d73: Unknown result type (might be due to invalid IL or missing references)
		//IL_5d7d: Expected O, but got Unknown
		//IL_5e2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e36: Expected O, but got Unknown
		//IL_5e70: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e7a: Expected O, but got Unknown
		//IL_5eb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ebe: Expected O, but got Unknown
		//IL_5f6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f77: Expected O, but got Unknown
		//IL_5fb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_5fbb: Expected O, but got Unknown
		//IL_5ff5: Unknown result type (might be due to invalid IL or missing references)
		//IL_5fff: Expected O, but got Unknown
		//IL_60ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_60b8: Expected O, but got Unknown
		//IL_60f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_60fc: Expected O, but got Unknown
		//IL_6136: Unknown result type (might be due to invalid IL or missing references)
		//IL_6140: Expected O, but got Unknown
		//IL_61ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_61f9: Expected O, but got Unknown
		//IL_6233: Unknown result type (might be due to invalid IL or missing references)
		//IL_623d: Expected O, but got Unknown
		//IL_6277: Unknown result type (might be due to invalid IL or missing references)
		//IL_6281: Expected O, but got Unknown
		//IL_6330: Unknown result type (might be due to invalid IL or missing references)
		//IL_633a: Expected O, but got Unknown
		//IL_6374: Unknown result type (might be due to invalid IL or missing references)
		//IL_637e: Expected O, but got Unknown
		//IL_63b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_63c2: Expected O, but got Unknown
		//IL_642b: Unknown result type (might be due to invalid IL or missing references)
		//IL_6435: Expected O, but got Unknown
		//IL_646f: Unknown result type (might be due to invalid IL or missing references)
		//IL_6479: Expected O, but got Unknown
		//IL_64b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_64bd: Expected O, but got Unknown
		//IL_656c: Unknown result type (might be due to invalid IL or missing references)
		//IL_6576: Expected O, but got Unknown
		//IL_65b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_65ba: Expected O, but got Unknown
		//IL_663a: Unknown result type (might be due to invalid IL or missing references)
		//IL_6644: Expected O, but got Unknown
		//IL_66c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_66ce: Expected O, but got Unknown
		//IL_671b: Unknown result type (might be due to invalid IL or missing references)
		//IL_6725: Expected O, but got Unknown
		//IL_679e: Unknown result type (might be due to invalid IL or missing references)
		//IL_67a8: Expected O, but got Unknown
		//IL_67e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_67ec: Expected O, but got Unknown
		//IL_6826: Unknown result type (might be due to invalid IL or missing references)
		//IL_6830: Expected O, but got Unknown
		//IL_6899: Unknown result type (might be due to invalid IL or missing references)
		//IL_68a3: Expected O, but got Unknown
		//IL_68dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_68e7: Expected O, but got Unknown
		//IL_6921: Unknown result type (might be due to invalid IL or missing references)
		//IL_692b: Expected O, but got Unknown
		//IL_6994: Unknown result type (might be due to invalid IL or missing references)
		//IL_699e: Expected O, but got Unknown
		//IL_69d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_69e2: Expected O, but got Unknown
		//IL_6a1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_6a26: Expected O, but got Unknown
		//IL_6a8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_6a99: Expected O, but got Unknown
		//IL_6ad3: Unknown result type (might be due to invalid IL or missing references)
		//IL_6add: Expected O, but got Unknown
		//IL_6b17: Unknown result type (might be due to invalid IL or missing references)
		//IL_6b21: Expected O, but got Unknown
		//IL_6b8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_6b94: Expected O, but got Unknown
		//IL_6bce: Unknown result type (might be due to invalid IL or missing references)
		//IL_6bd8: Expected O, but got Unknown
		//IL_6c12: Unknown result type (might be due to invalid IL or missing references)
		//IL_6c1c: Expected O, but got Unknown
		//IL_6c85: Unknown result type (might be due to invalid IL or missing references)
		//IL_6c8f: Expected O, but got Unknown
		//IL_6cc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_6cd3: Expected O, but got Unknown
		//IL_6d0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_6d17: Expected O, but got Unknown
		//IL_6d80: Unknown result type (might be due to invalid IL or missing references)
		//IL_6d8a: Expected O, but got Unknown
		//IL_6dc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_6dce: Expected O, but got Unknown
		//IL_6e08: Unknown result type (might be due to invalid IL or missing references)
		//IL_6e12: Expected O, but got Unknown
		//IL_6e7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_6e85: Expected O, but got Unknown
		//IL_6ebf: Unknown result type (might be due to invalid IL or missing references)
		//IL_6ec9: Expected O, but got Unknown
		//IL_6f03: Unknown result type (might be due to invalid IL or missing references)
		//IL_6f0d: Expected O, but got Unknown
		//IL_6f76: Unknown result type (might be due to invalid IL or missing references)
		//IL_6f80: Expected O, but got Unknown
		//IL_6fba: Unknown result type (might be due to invalid IL or missing references)
		//IL_6fc4: Expected O, but got Unknown
		//IL_6ffe: Unknown result type (might be due to invalid IL or missing references)
		//IL_7008: Expected O, but got Unknown
		//IL_7071: Unknown result type (might be due to invalid IL or missing references)
		//IL_707b: Expected O, but got Unknown
		//IL_70b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_70bf: Expected O, but got Unknown
		//IL_70f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_7103: Expected O, but got Unknown
		//IL_716c: Unknown result type (might be due to invalid IL or missing references)
		//IL_7176: Expected O, but got Unknown
		//IL_71b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_71ba: Expected O, but got Unknown
		//IL_71f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_71fe: Expected O, but got Unknown
		//IL_7267: Unknown result type (might be due to invalid IL or missing references)
		//IL_7271: Expected O, but got Unknown
		//IL_72ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_72b5: Expected O, but got Unknown
		//IL_72ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_72f9: Expected O, but got Unknown
		//IL_7362: Unknown result type (might be due to invalid IL or missing references)
		//IL_736c: Expected O, but got Unknown
		//IL_73a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_73b0: Expected O, but got Unknown
		//IL_73ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_73f4: Expected O, but got Unknown
		//IL_745d: Unknown result type (might be due to invalid IL or missing references)
		//IL_7467: Expected O, but got Unknown
		//IL_74a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_74ab: Expected O, but got Unknown
		//IL_74e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_74ef: Expected O, but got Unknown
		//IL_7558: Unknown result type (might be due to invalid IL or missing references)
		//IL_7562: Expected O, but got Unknown
		//IL_759c: Unknown result type (might be due to invalid IL or missing references)
		//IL_75a6: Expected O, but got Unknown
		//IL_75e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_75ea: Expected O, but got Unknown
		//IL_7653: Unknown result type (might be due to invalid IL or missing references)
		//IL_765d: Expected O, but got Unknown
		//IL_7697: Unknown result type (might be due to invalid IL or missing references)
		//IL_76a1: Expected O, but got Unknown
		//IL_7721: Unknown result type (might be due to invalid IL or missing references)
		//IL_772b: Expected O, but got Unknown
		//IL_77ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_77b5: Expected O, but got Unknown
		//IL_7802: Unknown result type (might be due to invalid IL or missing references)
		//IL_780c: Expected O, but got Unknown
		//IL_7921: Unknown result type (might be due to invalid IL or missing references)
		//IL_7ae6: Unknown result type (might be due to invalid IL or missing references)
		//IL_7b59: Unknown result type (might be due to invalid IL or missing references)
		//IL_7b63: Expected O, but got Unknown
		//IL_7bad: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_7c35: Expected O, but got Unknown
		//IL_7c65: Unknown result type (might be due to invalid IL or missing references)
		//IL_7d0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_7d17: Expected O, but got Unknown
		//IL_7dad: Unknown result type (might be due to invalid IL or missing references)
		//IL_7db7: Expected O, but got Unknown
		//IL_7dea: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e68: Unknown result type (might be due to invalid IL or missing references)
		//IL_7e72: Expected O, but got Unknown
		//IL_7ea5: Unknown result type (might be due to invalid IL or missing references)
		//IL_7f30: Unknown result type (might be due to invalid IL or missing references)
		//IL_7f3a: Expected O, but got Unknown
		//IL_7f6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_7fef: Unknown result type (might be due to invalid IL or missing references)
		//IL_7ff9: Expected O, but got Unknown
		//IL_802c: Unknown result type (might be due to invalid IL or missing references)
		//IL_80bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_80c7: Expected O, but got Unknown
		//IL_80fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_8195: Unknown result type (might be due to invalid IL or missing references)
		//IL_819f: Expected O, but got Unknown
		//IL_81d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_8240: Unknown result type (might be due to invalid IL or missing references)
		//IL_824a: Expected O, but got Unknown
		//IL_83a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_83b0: Expected O, but got Unknown
		//IL_8464: Unknown result type (might be due to invalid IL or missing references)
		//IL_846e: Expected O, but got Unknown
		//IL_8522: Unknown result type (might be due to invalid IL or missing references)
		//IL_852c: Expected O, but got Unknown
		//IL_85e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_85f0: Expected O, but got Unknown
		//IL_86aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_86b4: Expected O, but got Unknown
		//IL_876e: Unknown result type (might be due to invalid IL or missing references)
		//IL_8778: Expected O, but got Unknown
		//IL_882f: Unknown result type (might be due to invalid IL or missing references)
		//IL_8839: Expected O, but got Unknown
		//IL_88f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_88fa: Expected O, but got Unknown
		//IL_89b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_89bb: Expected O, but got Unknown
		//IL_8a8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_8a94: Expected O, but got Unknown
		//IL_8acb: Unknown result type (might be due to invalid IL or missing references)
		//IL_8ad5: Expected O, but got Unknown
		//IL_8b0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_8b16: Expected O, but got Unknown
		//IL_8b7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_8b86: Expected O, but got Unknown
		//IL_8bbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_8bc7: Expected O, but got Unknown
		//IL_8bfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_8c08: Expected O, but got Unknown
		//IL_8c6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_8c78: Expected O, but got Unknown
		//IL_8caf: Unknown result type (might be due to invalid IL or missing references)
		//IL_8cb9: Expected O, but got Unknown
		//IL_8cf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_8cfa: Expected O, but got Unknown
		//IL_8e10: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e1a: Expected O, but got Unknown
		//IL_8e2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_8e39: Expected O, but got Unknown
		//IL_8e4f: Unknown result type (might be due to invalid IL or missing references)
		components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MDI_FORM));
		bar6 = new Bar();
		MainTrip = new ToolStrip();
		MenuShort = new ToolStripDropDownButton();
		ShoF2Ledger = new ToolStripMenuItem();
		ShoF3Stock = new ToolStripMenuItem();
		ShoF4SalesOrder = new ToolStripMenuItem();
		ShoF5SalesBill = new ToolStripMenuItem();
		ShoF6WhSales = new ToolStripMenuItem();
		ShoF7Purc = new ToolStripMenuItem();
		ShoF8CashRec = new ToolStripMenuItem();
		ShoF9CashPayment = new ToolStripMenuItem();
		ShoF10Reminder = new ToolStripMenuItem();
		ShoF11Rojmel = new ToolStripMenuItem();
		Shof12TagWiseStock = new ToolStripMenuItem();
		F1CtrlDailyRateToolStripMenuItem = new ToolStripMenuItem();
		ShoCtrlF12TagEstmate = new ToolStripMenuItem();
		F11CtrlCashBankToolStripMenuItem = new ToolStripMenuItem();
		F2CtrlOrderZoomToolStripMenuItem = new ToolStripMenuItem();
		ShoCtrlF5BillRec = new ToolStripMenuItem();
		ShoCtrlF6RateCut = new ToolStripMenuItem();
		ShoCtrlF8BankRec = new ToolStripMenuItem();
		ShoCtrlF9BankPay = new ToolStripMenuItem();
		ToolStripLabel2 = new ToolStripLabel();
		mMainDt = new ToolStripTextBox();
		ToolStripLabel1 = new ToolStripLabel();
		btnHome = new ToolStripButton();
		ToolStripSeparator2 = new ToolStripSeparator();
		BtnComp = new ToolStripButton();
		Sp1 = new ToolStripSeparator();
		BtnMast = new ToolStripButton();
		ToolStripSeparator1 = new ToolStripSeparator();
		BtnTran = new ToolStripButton();
		Sp3 = new ToolStripSeparator();
		BtnTran2 = new ToolStripButton();
		SpTran2 = new ToolStripSeparator();
		BtnOth = new ToolStripButton();
		Sp4 = new ToolStripSeparator();
		BtnKrgr = new ToolStripButton();
		Sp6 = new ToolStripSeparator();
		BtnRpt = new ToolStripButton();
		Sp5 = new ToolStripSeparator();
		BtnSchm = new ToolStripButton();
		Sp7 = new ToolStripSeparator();
		BtnDhrn = new ToolStripButton();
		Sp8 = new ToolStripSeparator();
		BtnMfg = new ToolStripButton();
		Sp9 = new ToolStripSeparator();
		BtnExit = new ToolStripButton();
		Panel_Side = new Panel();
		Panel1 = new Panel();
		xtraTabbedMdiManager1 = new XtraTabbedMdiManager(components);
		bsiRecordsCount = new BarStaticItem();
		elementPeople = new AccordionControlElement();
		SLMain5 = new AccordionControlElement();
		SL75 = new AccordionControlElement();
		SL76 = new AccordionControlElement();
		SL77 = new AccordionControlElement();
		SL78 = new AccordionControlElement();
		SL79 = new AccordionControlElement();
		SL80 = new AccordionControlElement();
		SL81 = new AccordionControlElement();
		SL82 = new AccordionControlElement();
		SL83 = new AccordionControlElement();
		SL84 = new AccordionControlElement();
		SL85 = new AccordionControlElement();
		SL86 = new AccordionControlElement();
		SL87 = new AccordionControlElement();
		SL88 = new AccordionControlElement();
		SL89 = new AccordionControlElement();
		SL90 = new AccordionControlElement();
		elementCalendar = new AccordionControlElement();
		SLMain4 = new AccordionControlElement();
		SL51 = new AccordionControlElement();
		SL52 = new AccordionControlElement();
		SL53 = new AccordionControlElement();
		SL54 = new AccordionControlElement();
		SL55 = new AccordionControlElement();
		SL56 = new AccordionControlElement();
		SL57 = new AccordionControlElement();
		SL58 = new AccordionControlElement();
		SL59 = new AccordionControlElement();
		SL60 = new AccordionControlElement();
		SLMain6 = new AccordionControlElement();
		SL61 = new AccordionControlElement();
		SL62 = new AccordionControlElement();
		SL63 = new AccordionControlElement();
		SL64 = new AccordionControlElement();
		SL65 = new AccordionControlElement();
		elementMail = new AccordionControlElement();
		SLMain = new AccordionControlElement();
		SL0 = new AccordionControlElement();
		SL1 = new AccordionControlElement();
		SL2 = new AccordionControlElement();
		SL3 = new AccordionControlElement();
		SL4 = new AccordionControlElement();
		SL5 = new AccordionControlElement();
		SL6 = new AccordionControlElement();
		SL7 = new AccordionControlElement();
		SL8 = new AccordionControlElement();
		SL9 = new AccordionControlElement();
		SL10 = new AccordionControlElement();
		SL11 = new AccordionControlElement();
		SL12 = new AccordionControlElement();
		SL13 = new AccordionControlElement();
		SL14 = new AccordionControlElement();
		SL15 = new AccordionControlElement();
		SL16 = new AccordionControlElement();
		SL17 = new AccordionControlElement();
		SL18 = new AccordionControlElement();
		SL19 = new AccordionControlElement();
		SL20 = new AccordionControlElement();
		SLMain2 = new AccordionControlElement();
		SL21 = new AccordionControlElement();
		SL22 = new AccordionControlElement();
		SL23 = new AccordionControlElement();
		SL24 = new AccordionControlElement();
		SL25 = new AccordionControlElement();
		SL26 = new AccordionControlElement();
		SL27 = new AccordionControlElement();
		SL28 = new AccordionControlElement();
		SL29 = new AccordionControlElement();
		SL30 = new AccordionControlElement();
		SL31 = new AccordionControlElement();
		SL32 = new AccordionControlElement();
		SL33 = new AccordionControlElement();
		SL34 = new AccordionControlElement();
		SL35 = new AccordionControlElement();
		SLMain3 = new AccordionControlElement();
		SideTrip = new AccordionControl();
		PnlBotam = new FlowLayoutPanel();
		cboTheme = new ComboBox();
		chkLiveRate = new CheckBox();
		nCurrncyRate = new TextBox();
		lblLiveRate = new Label();
		LblUserRequest = new Label();
		tAmcDate = new Label();
		chkWappId = new CheckBox();
		chkNextAi = new CheckBox();
		tSoftDemoType = new TextBox();
		PanelImage = new Panel();
		LblSilverSl = new Label();
		LblGoldSl = new Label();
		Rate_7 = new Label();
		Rate_6 = new Label();
		Rate_5 = new Label();
		Rate_4 = new Label();
		Rate_3 = new Label();
		Rate_2 = new Label();
		Rate_1 = new Label();
		Timer1 = new Timer(components);
		FolderBrowserDialog1 = new FolderBrowserDialog();
		AccordionControlElement1 = new AccordionControlElement();
		AccordionControlElement2 = new AccordionControlElement();
		AccordionControlElement3 = new AccordionControlElement();
		((Control)MainTrip).SuspendLayout();
		((ISupportInitialize)xtraTabbedMdiManager1).BeginInit();
		((ISupportInitialize)SideTrip).BeginInit();
		((Control)PnlBotam).SuspendLayout();
		((Control)PanelImage).SuspendLayout();
		((Control)this).SuspendLayout();
		bar6.BarName = "PaintStyle";
		bar6.DockCol = 2;
		bar6.DockRow = 1;
		bar6.DockStyle = (BarDockStyle)2;
		bar6.Offset = 515;
		bar6.OptionsBar.AllowQuickCustomization = false;
		bar6.OptionsBar.RotateWhenVertical = false;
		bar6.Text = "PaintStyle";
		MainTrip.AutoSize = false;
		MainTrip.BackColor = Color.FromArgb(255, 145, 0);
		((Control)MainTrip).BackgroundImageLayout = (ImageLayout)3;
		MainTrip.GripStyle = (ToolStripGripStyle)0;
		MainTrip.ImageScalingSize = new Size(24, 24);
		MainTrip.Items.AddRange((ToolStripItem[])(object)new ToolStripItem[27]
		{
			(ToolStripItem)MenuShort,
			(ToolStripItem)ToolStripLabel2,
			(ToolStripItem)mMainDt,
			(ToolStripItem)ToolStripLabel1,
			(ToolStripItem)btnHome,
			(ToolStripItem)ToolStripSeparator2,
			(ToolStripItem)BtnComp,
			(ToolStripItem)Sp1,
			(ToolStripItem)BtnMast,
			(ToolStripItem)ToolStripSeparator1,
			(ToolStripItem)BtnTran,
			(ToolStripItem)Sp3,
			(ToolStripItem)BtnTran2,
			(ToolStripItem)SpTran2,
			(ToolStripItem)BtnOth,
			(ToolStripItem)Sp4,
			(ToolStripItem)BtnKrgr,
			(ToolStripItem)Sp6,
			(ToolStripItem)BtnRpt,
			(ToolStripItem)Sp5,
			(ToolStripItem)BtnSchm,
			(ToolStripItem)Sp7,
			(ToolStripItem)BtnDhrn,
			(ToolStripItem)Sp8,
			(ToolStripItem)BtnMfg,
			(ToolStripItem)Sp9,
			(ToolStripItem)BtnExit
		});
		((Control)MainTrip).Location = new Point(0, 0);
		((Control)MainTrip).Name = "MainTrip";
		((Control)MainTrip).Size = new Size(1350, 38);
		((Control)MainTrip).TabIndex = 11;
		MainTrip.TabStop = true;
		((Control)MainTrip).Text = "Main Menu";
		((ToolStripItem)MenuShort).DisplayStyle = (ToolStripItemDisplayStyle)2;
		((ToolStripDropDownItem)MenuShort).DropDownItems.AddRange((ToolStripItem[])(object)new ToolStripItem[19]
		{
			(ToolStripItem)ShoF2Ledger,
			(ToolStripItem)ShoF3Stock,
			(ToolStripItem)ShoF4SalesOrder,
			(ToolStripItem)ShoF5SalesBill,
			(ToolStripItem)ShoF6WhSales,
			(ToolStripItem)ShoF7Purc,
			(ToolStripItem)ShoF8CashRec,
			(ToolStripItem)ShoF9CashPayment,
			(ToolStripItem)ShoF10Reminder,
			(ToolStripItem)ShoF11Rojmel,
			(ToolStripItem)Shof12TagWiseStock,
			(ToolStripItem)F1CtrlDailyRateToolStripMenuItem,
			(ToolStripItem)ShoCtrlF12TagEstmate,
			(ToolStripItem)F11CtrlCashBankToolStripMenuItem,
			(ToolStripItem)F2CtrlOrderZoomToolStripMenuItem,
			(ToolStripItem)ShoCtrlF5BillRec,
			(ToolStripItem)ShoCtrlF6RateCut,
			(ToolStripItem)ShoCtrlF8BankRec,
			(ToolStripItem)ShoCtrlF9BankPay
		});
		((ToolStripItem)MenuShort).Image = (Image)(object)Resources.ArrowRight;
		((ToolStripItem)MenuShort).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)MenuShort).Name = "MenuShort";
		((ToolStripItem)MenuShort).Size = new Size(37, 35);
		((ToolStripItem)ShoF2Ledger).Name = "ShoF2Ledger";
		((ToolStripItem)ShoF2Ledger).Size = new Size(188, 22);
		((ToolStripItem)ShoF2Ledger).Text = "F2     Ledger Report";
		((ToolStripItem)ShoF3Stock).Name = "ShoF3Stock";
		((ToolStripItem)ShoF3Stock).Size = new Size(188, 22);
		((ToolStripItem)ShoF3Stock).Text = "F3     Stock Report ";
		((ToolStripItem)ShoF4SalesOrder).Name = "ShoF4SalesOrder";
		((ToolStripItem)ShoF4SalesOrder).Size = new Size(188, 22);
		((ToolStripItem)ShoF4SalesOrder).Text = "F4     Sales Order";
		((ToolStripItem)ShoF5SalesBill).Name = "ShoF5SalesBill";
		((ToolStripItem)ShoF5SalesBill).Size = new Size(188, 22);
		((ToolStripItem)ShoF5SalesBill).Text = "F5     Sales Bill";
		((ToolStripItem)ShoF6WhSales).Name = "ShoF6WhSales";
		((ToolStripItem)ShoF6WhSales).Size = new Size(188, 22);
		((ToolStripItem)ShoF6WhSales).Text = "F6     Wh Sales";
		((ToolStripItem)ShoF7Purc).Name = "ShoF7Purc";
		((ToolStripItem)ShoF7Purc).Size = new Size(188, 22);
		((ToolStripItem)ShoF7Purc).Text = "F7    Purchase Bill";
		((ToolStripItem)ShoF8CashRec).Name = "ShoF8CashRec";
		((ToolStripItem)ShoF8CashRec).Size = new Size(188, 22);
		((ToolStripItem)ShoF8CashRec).Text = "F8    Cash Received";
		((ToolStripItem)ShoF9CashPayment).Name = "ShoF9CashPayment";
		((ToolStripItem)ShoF9CashPayment).Size = new Size(188, 22);
		((ToolStripItem)ShoF9CashPayment).Text = "F9    Cash Payment";
		((ToolStripItem)ShoF10Reminder).Name = "ShoF10Reminder";
		((ToolStripItem)ShoF10Reminder).Size = new Size(188, 22);
		((ToolStripItem)ShoF10Reminder).Text = "F10    Reminder";
		((ToolStripItem)ShoF11Rojmel).Name = "ShoF11Rojmel";
		((ToolStripItem)ShoF11Rojmel).Size = new Size(188, 22);
		((ToolStripItem)ShoF11Rojmel).Text = "F11    Rojmel";
		((ToolStripItem)Shof12TagWiseStock).Name = "Shof12TagWiseStock";
		((ToolStripItem)Shof12TagWiseStock).Size = new Size(188, 22);
		((ToolStripItem)Shof12TagWiseStock).Text = "F12    Tag Wise Stock";
		((ToolStripItem)F1CtrlDailyRateToolStripMenuItem).Name = "F1CtrlDailyRateToolStripMenuItem";
		((ToolStripItem)F1CtrlDailyRateToolStripMenuItem).Size = new Size(188, 22);
		((ToolStripItem)F1CtrlDailyRateToolStripMenuItem).Text = "F1 + Ctrl Daily Rate";
		((ToolStripItem)ShoCtrlF12TagEstmate).Name = "ShoCtrlF12TagEstmate";
		ShoCtrlF12TagEstmate.ShowShortcutKeys = false;
		((ToolStripItem)ShoCtrlF12TagEstmate).Size = new Size(188, 22);
		((ToolStripItem)ShoCtrlF12TagEstmate).Text = "F12 + Ctrl TagEstmate";
		((ToolStripItem)F11CtrlCashBankToolStripMenuItem).Name = "F11CtrlCashBankToolStripMenuItem";
		((ToolStripItem)F11CtrlCashBankToolStripMenuItem).Size = new Size(188, 22);
		((ToolStripItem)F11CtrlCashBankToolStripMenuItem).Text = "F11+ Ctrl CashBank";
		((ToolStripItem)F2CtrlOrderZoomToolStripMenuItem).Name = "F2CtrlOrderZoomToolStripMenuItem";
		((ToolStripItem)F2CtrlOrderZoomToolStripMenuItem).Size = new Size(188, 22);
		((ToolStripItem)F2CtrlOrderZoomToolStripMenuItem).Text = "F2 + Ctrl Order Zoom";
		((ToolStripItem)F2CtrlOrderZoomToolStripMenuItem).Visible = false;
		((ToolStripItem)ShoCtrlF5BillRec).Name = "ShoCtrlF5BillRec";
		((ToolStripItem)ShoCtrlF5BillRec).Size = new Size(188, 22);
		((ToolStripItem)ShoCtrlF5BillRec).Text = "F5 + Ctrl Bill Wise Rec";
		((ToolStripItem)ShoCtrlF6RateCut).Name = "ShoCtrlF6RateCut";
		((ToolStripItem)ShoCtrlF6RateCut).Size = new Size(188, 22);
		((ToolStripItem)ShoCtrlF6RateCut).Text = "F6 + Ctrl Rate Cut";
		((ToolStripItem)ShoCtrlF8BankRec).Name = "ShoCtrlF8BankRec";
		((ToolStripItem)ShoCtrlF8BankRec).Size = new Size(188, 22);
		((ToolStripItem)ShoCtrlF8BankRec).Text = "F8 + Ctrl Bank Rec";
		((ToolStripItem)ShoCtrlF9BankPay).Name = "ShoCtrlF9BankPay";
		((ToolStripItem)ShoCtrlF9BankPay).Size = new Size(188, 22);
		((ToolStripItem)ShoCtrlF9BankPay).Text = "F9 + Ctrl Bank Pay";
		((ToolStripItem)ToolStripLabel2).Name = "ToolStripLabel2";
		((ToolStripItem)ToolStripLabel2).Size = new Size(16, 35);
		((ToolStripItem)ToolStripLabel2).Tag = " ";
		((ToolStripItem)ToolStripLabel2).Text = "   ";
		((ToolStripItem)mMainDt).AutoSize = false;
		((ToolStripControlHost)mMainDt).BackColor = Color.FromArgb(255, 145, 0);
		mMainDt.BorderStyle = (BorderStyle)0;
		((ToolStripControlHost)mMainDt).Font = new Font("Bahnschrift", 14.25f);
		((ToolStripControlHost)mMainDt).ForeColor = Color.White;
		mMainDt.MaxLength = 10;
		((ToolStripItem)mMainDt).Name = "mMainDt";
		((ToolStripControlHost)mMainDt).Size = new Size(100, 38);
		((ToolStripControlHost)mMainDt).Text = "01/11/2019";
		mMainDt.TextBoxTextAlign = (HorizontalAlignment)2;
		((ToolStripItem)ToolStripLabel1).Name = "ToolStripLabel1";
		((ToolStripItem)ToolStripLabel1).Size = new Size(16, 35);
		((ToolStripItem)ToolStripLabel1).Text = "   ";
		((ToolStripItem)btnHome).AutoSize = false;
		((ToolStripItem)btnHome).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)btnHome).Font = new Font("Bahnschrift SemiBold", 12.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)btnHome).ForeColor = Color.White;
		((ToolStripItem)btnHome).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)btnHome).Name = "btnHome";
		((ToolStripItem)btnHome).Size = new Size(80, 30);
		((ToolStripItem)btnHome).Text = "Home";
		((ToolStripItem)btnHome).ToolTipText = " H - Home";
		((ToolStripItem)ToolStripSeparator2).Name = "ToolStripSeparator2";
		((ToolStripItem)ToolStripSeparator2).Size = new Size(6, 38);
		((ToolStripItem)BtnComp).AutoSize = false;
		((ToolStripItem)BtnComp).BackColor = Color.Transparent;
		((ToolStripItem)BtnComp).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)BtnComp).Font = new Font("Bahnschrift SemiBold", 12.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)BtnComp).ForeColor = Color.White;
		((ToolStripItem)BtnComp).ImageAlign = (ContentAlignment)16;
		((ToolStripItem)BtnComp).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)BtnComp).Name = "BtnComp";
		((ToolStripItem)BtnComp).Size = new Size(90, 30);
		((ToolStripItem)BtnComp).Text = "Company";
		((ToolStripItem)BtnComp).ToolTipText = "C - Company";
		((ToolStripItem)Sp1).Name = "Sp1";
		((ToolStripItem)Sp1).Size = new Size(6, 38);
		((ToolStripItem)BtnMast).AutoSize = false;
		((ToolStripItem)BtnMast).BackColor = Color.Transparent;
		((ToolStripItem)BtnMast).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)BtnMast).Font = new Font("Bahnschrift SemiBold", 12.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)BtnMast).ForeColor = Color.White;
		((ToolStripItem)BtnMast).ImageAlign = (ContentAlignment)16;
		((ToolStripItem)BtnMast).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)BtnMast).Name = "BtnMast";
		((ToolStripItem)BtnMast).Size = new Size(85, 30);
		((ToolStripItem)BtnMast).Text = "Master";
		((ToolStripItem)BtnMast).ToolTipText = "M - Master";
		((ToolStripItem)ToolStripSeparator1).Name = "ToolStripSeparator1";
		((ToolStripItem)ToolStripSeparator1).Size = new Size(6, 38);
		((ToolStripItem)BtnTran).AutoSize = false;
		((ToolStripItem)BtnTran).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)BtnTran).Font = new Font("Bahnschrift SemiBold", 12.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)BtnTran).ForeColor = Color.White;
		((ToolStripItem)BtnTran).ImageTransparentColor = Color.MediumVioletRed;
		((ToolStripItem)BtnTran).Name = "BtnTran";
		((ToolStripItem)BtnTran).Size = new Size(85, 30);
		((ToolStripItem)BtnTran).Text = "Tran 1";
		((ToolStripItem)BtnTran).ToolTipText = "T - Transaction";
		((ToolStripItem)Sp3).Name = "Sp3";
		((ToolStripItem)Sp3).Size = new Size(6, 38);
		((ToolStripItem)BtnTran2).AutoSize = false;
		((ToolStripItem)BtnTran2).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)BtnTran2).Font = new Font("Bahnschrift SemiBold", 12.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)BtnTran2).ForeColor = Color.White;
		((ToolStripItem)BtnTran2).ImageTransparentColor = Color.MediumVioletRed;
		((ToolStripItem)BtnTran2).Name = "BtnTran2";
		((ToolStripItem)BtnTran2).Size = new Size(85, 30);
		((ToolStripItem)BtnTran2).Text = "Tran 2";
		((ToolStripItem)BtnTran2).ToolTipText = "N - Transaction 2";
		((ToolStripItem)SpTran2).Name = "SpTran2";
		((ToolStripItem)SpTran2).Size = new Size(6, 38);
		((ToolStripItem)BtnOth).AutoSize = false;
		((ToolStripItem)BtnOth).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)BtnOth).Font = new Font("Bahnschrift SemiBold", 12.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)BtnOth).ForeColor = Color.White;
		((ToolStripItem)BtnOth).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)BtnOth).Name = "BtnOth";
		((ToolStripItem)BtnOth).Size = new Size(85, 30);
		((ToolStripItem)BtnOth).Text = "Other";
		((ToolStripItem)BtnOth).ToolTipText = "O - Other";
		((ToolStripItem)Sp4).Name = "Sp4";
		((ToolStripItem)Sp4).Size = new Size(6, 38);
		((ToolStripItem)BtnKrgr).AutoSize = false;
		((ToolStripItem)BtnKrgr).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)BtnKrgr).Font = new Font("Bahnschrift SemiBold", 12.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)BtnKrgr).ForeColor = Color.White;
		((ToolStripItem)BtnKrgr).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)BtnKrgr).Name = "BtnKrgr";
		((ToolStripItem)BtnKrgr).Size = new Size(85, 30);
		((ToolStripItem)BtnKrgr).Text = "Karigar";
		((ToolStripItem)BtnKrgr).ToolTipText = "K - Karigar";
		((ToolStripItem)Sp6).Name = "Sp6";
		((ToolStripItem)Sp6).Size = new Size(6, 38);
		((ToolStripItem)BtnRpt).AutoSize = false;
		((ToolStripItem)BtnRpt).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)BtnRpt).Font = new Font("Bahnschrift SemiBold", 12.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)BtnRpt).ForeColor = Color.White;
		((ToolStripItem)BtnRpt).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)BtnRpt).Name = "BtnRpt";
		((ToolStripItem)BtnRpt).Size = new Size(85, 30);
		((ToolStripItem)BtnRpt).Text = "Reports";
		((ToolStripItem)BtnRpt).ToolTipText = "R - Reports";
		((ToolStripItem)Sp5).Name = "Sp5";
		((ToolStripItem)Sp5).Size = new Size(6, 38);
		((ToolStripItem)BtnSchm).AutoSize = false;
		((ToolStripItem)BtnSchm).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)BtnSchm).Font = new Font("Bahnschrift SemiBold", 12.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)BtnSchm).ForeColor = Color.White;
		((ToolStripItem)BtnSchm).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)BtnSchm).Name = "BtnSchm";
		((ToolStripItem)BtnSchm).Size = new Size(85, 30);
		((ToolStripItem)BtnSchm).Text = "Scheme";
		((ToolStripItem)BtnSchm).ToolTipText = "S - Scheme";
		((ToolStripItem)Sp7).Name = "Sp7";
		((ToolStripItem)Sp7).Size = new Size(6, 38);
		((ToolStripItem)BtnDhrn).AutoSize = false;
		((ToolStripItem)BtnDhrn).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)BtnDhrn).Font = new Font("Bahnschrift SemiBold", 12.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)BtnDhrn).ForeColor = Color.White;
		((ToolStripItem)BtnDhrn).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)BtnDhrn).Name = "BtnDhrn";
		((ToolStripItem)BtnDhrn).Size = new Size(85, 30);
		((ToolStripItem)BtnDhrn).Text = "Dhiran";
		((ToolStripItem)BtnDhrn).ToolTipText = "D - Dhiran ";
		((ToolStripItem)Sp8).Name = "Sp8";
		((ToolStripItem)Sp8).Size = new Size(6, 38);
		((ToolStripItem)BtnMfg).AutoSize = false;
		((ToolStripItem)BtnMfg).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)BtnMfg).Font = new Font("Bahnschrift SemiBold", 12.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)BtnMfg).ForeColor = Color.White;
		((ToolStripItem)BtnMfg).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)BtnMfg).Name = "BtnMfg";
		((ToolStripItem)BtnMfg).Size = new Size(85, 30);
		((ToolStripItem)BtnMfg).Text = "M&fg";
		((ToolStripItem)BtnMfg).ToolTipText = "F - Mfg";
		((ToolStripItem)Sp9).Name = "Sp9";
		((ToolStripItem)Sp9).Size = new Size(6, 38);
		((ToolStripItem)BtnExit).AutoSize = false;
		((ToolStripItem)BtnExit).DisplayStyle = (ToolStripItemDisplayStyle)1;
		((ToolStripItem)BtnExit).Font = new Font("Bahnschrift SemiBold", 12.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ToolStripItem)BtnExit).ForeColor = Color.White;
		((ToolStripItem)BtnExit).ImageTransparentColor = Color.Magenta;
		((ToolStripItem)BtnExit).Name = "BtnExit";
		((ToolStripItem)BtnExit).Size = new Size(85, 30);
		((ToolStripItem)BtnExit).Text = "&Exit";
		((ToolStripItem)BtnExit).ToolTipText = "E - Exit";
		Panel_Side.AutoSize = true;
		((Control)Panel_Side).BackColor = Color.FromArgb(64, 64, 64);
		((Control)Panel_Side).BackgroundImageLayout = (ImageLayout)3;
		((Control)Panel_Side).Dock = (DockStyle)3;
		((Control)Panel_Side).Location = new Point(0, 38);
		((Control)Panel_Side).Margin = new Padding(3, 4, 3, 4);
		((Control)Panel_Side).Name = "Panel_Side";
		((Control)Panel_Side).Size = new Size(0, 673);
		((Control)Panel_Side).TabIndex = 13;
		Panel1.AutoSize = true;
		((Control)Panel1).BackColor = Color.DarkGray;
		((Control)Panel1).BackgroundImageLayout = (ImageLayout)3;
		((Control)Panel1).Dock = (DockStyle)3;
		((Control)Panel1).Location = new Point(0, 38);
		((Control)Panel1).Margin = new Padding(3, 4, 3, 4);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(0, 673);
		((Control)Panel1).TabIndex = 14;
		xtraTabbedMdiManager1.AppearancePage.Header.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		xtraTabbedMdiManager1.AppearancePage.Header.ForeColor = Color.Maroon;
		xtraTabbedMdiManager1.AppearancePage.Header.Options.UseFont = true;
		xtraTabbedMdiManager1.AppearancePage.Header.Options.UseForeColor = true;
		xtraTabbedMdiManager1.ClosePageButtonShowMode = (ClosePageButtonShowMode)4;
		xtraTabbedMdiManager1.HeaderButtonsShowMode = (TabButtonShowMode)2;
		xtraTabbedMdiManager1.MdiParent = (Form)(object)this;
		((BarItem)bsiRecordsCount).Caption = "RECORDS : 0";
		((BarItem)bsiRecordsCount).Id = 15;
		((BarItem)bsiRecordsCount).Name = "bsiRecordsCount";
		elementPeople.Elements.AddRange((AccordionControlElement[])(object)new AccordionControlElement[1] { SLMain5 });
		((AccordionControlElementBase)elementPeople).Expanded = true;
		((ImageCollectionImageOptions)((AccordionControlElementBase)elementPeople).ImageOptions).SvgImage = Resources.bo_user;
		((ImageOptions)((AccordionControlElementBase)elementPeople).ImageOptions).SvgImageSize = new Size(24, 24);
		((AccordionControlElementBase)elementPeople).Name = "elementPeople";
		((AccordionControlElementBase)elementPeople).Text = "People";
		SLMain5.Appearance.Hovered.Font = new Font("Bahnschrift SemiBold", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		SLMain5.Appearance.Hovered.ForeColor = Color.FromArgb(255, 255, 192);
		SLMain5.Appearance.Hovered.Options.UseFont = true;
		SLMain5.Appearance.Hovered.Options.UseForeColor = true;
		SLMain5.Appearance.Normal.Font = new Font("Bahnschrift SemiBold", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		SLMain5.Appearance.Normal.ForeColor = Color.FromArgb(255, 255, 192);
		SLMain5.Appearance.Normal.Options.UseFont = true;
		SLMain5.Appearance.Normal.Options.UseForeColor = true;
		SLMain5.Appearance.Pressed.Font = new Font("Bahnschrift SemiBold", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		SLMain5.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 192);
		SLMain5.Appearance.Pressed.Options.UseFont = true;
		SLMain5.Appearance.Pressed.Options.UseForeColor = true;
		SLMain5.Elements.AddRange((AccordionControlElement[])(object)new AccordionControlElement[16]
		{
			SL75, SL76, SL77, SL78, SL79, SL80, SL81, SL82, SL83, SL84,
			SL85, SL86, SL87, SL88, SL89, SL90
		});
		((AccordionControlElementBase)SLMain5).Expanded = true;
		((ImageCollectionImageOptions)((AccordionControlElementBase)SLMain5).ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		((AccordionControlElementBase)SLMain5).Name = "SLMain5";
		((AccordionControlElementBase)SLMain5).Text = "More";
		SL75.Appearance.Disabled.Font = new Font("Bahnschrift", 11.25f);
		SL75.Appearance.Disabled.Options.UseFont = true;
		SL75.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL75.Appearance.Hovered.Options.UseFont = true;
		SL75.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL75.Appearance.Normal.Options.UseFont = true;
		SL75.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL75.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL75).Name = "SL75";
		SL75.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL75).Text = "75";
		SL76.Appearance.Disabled.Font = new Font("Bahnschrift", 11.25f);
		SL76.Appearance.Disabled.Options.UseFont = true;
		SL76.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL76.Appearance.Hovered.Options.UseFont = true;
		SL76.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL76.Appearance.Normal.Options.UseFont = true;
		SL76.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL76.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL76).Name = "SL76";
		SL76.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL76).Text = "76";
		SL77.Appearance.Disabled.Font = new Font("Bahnschrift", 11.25f);
		SL77.Appearance.Disabled.Options.UseFont = true;
		SL77.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL77.Appearance.Hovered.Options.UseFont = true;
		SL77.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL77.Appearance.Normal.Options.UseFont = true;
		SL77.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL77.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL77).Name = "SL77";
		SL77.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL77).Text = "77";
		SL78.Appearance.Disabled.Font = new Font("Bahnschrift", 11.25f);
		SL78.Appearance.Disabled.Options.UseFont = true;
		SL78.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL78.Appearance.Hovered.Options.UseFont = true;
		SL78.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL78.Appearance.Normal.Options.UseFont = true;
		SL78.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL78.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL78).Name = "SL78";
		SL78.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL78).Text = "78";
		SL79.Appearance.Disabled.Font = new Font("Bahnschrift", 11.25f);
		SL79.Appearance.Disabled.Options.UseFont = true;
		SL79.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL79.Appearance.Hovered.Options.UseFont = true;
		SL79.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL79.Appearance.Normal.Options.UseFont = true;
		SL79.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL79.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL79).Name = "SL79";
		SL79.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL79).Text = "79";
		SL80.Appearance.Disabled.Font = new Font("Bahnschrift", 11.25f);
		SL80.Appearance.Disabled.Options.UseFont = true;
		SL80.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL80.Appearance.Hovered.Options.UseFont = true;
		SL80.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL80.Appearance.Normal.Options.UseFont = true;
		SL80.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL80.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL80).Name = "SL80";
		SL80.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL80).Text = "80";
		SL81.Appearance.Disabled.Font = new Font("Bahnschrift", 11.25f);
		SL81.Appearance.Disabled.Options.UseFont = true;
		SL81.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL81.Appearance.Hovered.Options.UseFont = true;
		SL81.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL81.Appearance.Normal.Options.UseFont = true;
		SL81.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL81.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL81).Name = "SL81";
		SL81.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL81).Text = "81";
		SL82.Appearance.Disabled.Font = new Font("Bahnschrift", 11.25f);
		SL82.Appearance.Disabled.Options.UseFont = true;
		SL82.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL82.Appearance.Hovered.Options.UseFont = true;
		SL82.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL82.Appearance.Normal.Options.UseFont = true;
		SL82.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL82.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL82).Name = "SL82";
		SL82.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL82).Text = "82";
		SL83.Appearance.Disabled.Font = new Font("Bahnschrift", 11.25f);
		SL83.Appearance.Disabled.Options.UseFont = true;
		SL83.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL83.Appearance.Hovered.Options.UseFont = true;
		SL83.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL83.Appearance.Normal.Options.UseFont = true;
		SL83.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL83.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL83).Name = "SL83";
		SL83.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL83).Text = "83";
		SL84.Appearance.Disabled.Font = new Font("Bahnschrift", 11.25f);
		SL84.Appearance.Disabled.Options.UseFont = true;
		SL84.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL84.Appearance.Hovered.Options.UseFont = true;
		SL84.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL84.Appearance.Normal.Options.UseFont = true;
		SL84.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL84.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL84).Name = "SL84";
		SL84.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL84).Text = "84";
		SL85.Appearance.Disabled.Font = new Font("Bahnschrift", 11.25f);
		SL85.Appearance.Disabled.Options.UseFont = true;
		SL85.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL85.Appearance.Hovered.Options.UseFont = true;
		SL85.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL85.Appearance.Normal.Options.UseFont = true;
		SL85.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL85.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL85).Name = "SL85";
		SL85.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL85).Text = "85";
		SL86.Appearance.Disabled.Font = new Font("Bahnschrift", 11.25f);
		SL86.Appearance.Disabled.Options.UseFont = true;
		SL86.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL86.Appearance.Hovered.Options.UseFont = true;
		SL86.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL86.Appearance.Normal.Options.UseFont = true;
		SL86.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL86.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL86).Name = "SL86";
		SL86.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL86).Text = "86";
		SL87.Appearance.Disabled.Font = new Font("Bahnschrift", 11.25f);
		SL87.Appearance.Disabled.Options.UseFont = true;
		SL87.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL87.Appearance.Hovered.Options.UseFont = true;
		SL87.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL87.Appearance.Normal.Options.UseFont = true;
		SL87.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL87.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL87).Name = "SL87";
		SL87.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL87).Text = "87";
		SL88.Appearance.Disabled.Font = new Font("Bahnschrift", 11.25f);
		SL88.Appearance.Disabled.Options.UseFont = true;
		SL88.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL88.Appearance.Hovered.Options.UseFont = true;
		SL88.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL88.Appearance.Normal.Options.UseFont = true;
		SL88.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL88.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL88).Name = "SL88";
		SL88.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL88).Text = "88";
		SL89.Appearance.Disabled.Font = new Font("Bahnschrift", 11.25f);
		SL89.Appearance.Disabled.Options.UseFont = true;
		SL89.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL89.Appearance.Hovered.Options.UseFont = true;
		SL89.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL89.Appearance.Normal.Options.UseFont = true;
		SL89.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL89.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL89).Name = "SL89";
		SL89.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL89).Text = "89";
		SL90.Appearance.Disabled.Font = new Font("Bahnschrift", 11.25f);
		SL90.Appearance.Disabled.Options.UseFont = true;
		SL90.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL90.Appearance.Hovered.Options.UseFont = true;
		SL90.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL90.Appearance.Normal.Options.UseFont = true;
		SL90.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL90.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL90).Name = "SL90";
		SL90.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL90).Text = "90";
		elementCalendar.Elements.AddRange((AccordionControlElement[])(object)new AccordionControlElement[1] { SLMain4 });
		((AccordionControlElementBase)elementCalendar).Expanded = true;
		((ImageCollectionImageOptions)((AccordionControlElementBase)elementCalendar).ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("elementCalendar.ImageOptions.SvgImage");
		((ImageOptions)((AccordionControlElementBase)elementCalendar).ImageOptions).SvgImageSize = new Size(24, 24);
		((AccordionControlElementBase)elementCalendar).Name = "elementCalendar";
		((AccordionControlElementBase)elementCalendar).Tag = 15;
		((AccordionControlElementBase)elementCalendar).Text = "Calendar";
		SLMain4.Appearance.Disabled.Font = new Font("Bahnschrift", 12.75f);
		SLMain4.Appearance.Disabled.Options.UseFont = true;
		SLMain4.Appearance.Hovered.Font = new Font("Bahnschrift SemiBold", 14.25f, (FontStyle)1);
		SLMain4.Appearance.Hovered.ForeColor = Color.FromArgb(255, 255, 192);
		SLMain4.Appearance.Hovered.Options.UseFont = true;
		SLMain4.Appearance.Hovered.Options.UseForeColor = true;
		SLMain4.Appearance.Normal.Font = new Font("Bahnschrift SemiBold", 14.25f, (FontStyle)1);
		SLMain4.Appearance.Normal.ForeColor = Color.FromArgb(255, 255, 192);
		SLMain4.Appearance.Normal.Options.UseFont = true;
		SLMain4.Appearance.Normal.Options.UseForeColor = true;
		SLMain4.Appearance.Pressed.Font = new Font("Bahnschrift", 12.75f);
		SLMain4.Appearance.Pressed.Options.UseFont = true;
		SLMain4.Elements.AddRange((AccordionControlElement[])(object)new AccordionControlElement[16]
		{
			SL51, SL52, SL53, SL54, SL55, SL56, SL57, SL58, SL59, SL60,
			SLMain6, SL61, SL62, SL63, SL64, SL65
		});
		((AccordionControlElementBase)SLMain4).Expanded = true;
		SLMain4.HeaderTemplate.AddRange((HeaderElementInfo[])(object)new HeaderElementInfo[4]
		{
			new HeaderElementInfo((HeaderElementType)2),
			new HeaderElementInfo((HeaderElementType)1, (HeaderElementAlignment)0),
			new HeaderElementInfo((HeaderElementType)3),
			new HeaderElementInfo((HeaderElementType)0)
		});
		((ImageCollectionImageOptions)((AccordionControlElementBase)SLMain4).ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("SLMain4.ImageOptions.SvgImage");
		((ImageOptions)((AccordionControlElementBase)SLMain4).ImageOptions).SvgImageSize = new Size(24, 24);
		((AccordionControlElementBase)SLMain4).Name = "SLMain4";
		((AccordionControlElementBase)SLMain4).Tag = "4";
		((AccordionControlElementBase)SLMain4).Text = "Analysis   ";
		SL51.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL51.Appearance.Hovered.Options.UseFont = true;
		SL51.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL51.Appearance.Normal.Options.UseFont = true;
		SL51.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL51.Appearance.Pressed.Options.UseFont = true;
		SL51.HeaderTemplate.AddRange((HeaderElementInfo[])(object)new HeaderElementInfo[4]
		{
			new HeaderElementInfo((HeaderElementType)3),
			new HeaderElementInfo((HeaderElementType)2),
			new HeaderElementInfo((HeaderElementType)0),
			new HeaderElementInfo((HeaderElementType)1)
		});
		((AccordionControlElementBase)SL51).Name = "SL51";
		SL51.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL51).Text = "51";
		SL52.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL52.Appearance.Hovered.Options.UseFont = true;
		SL52.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL52.Appearance.Normal.Options.UseFont = true;
		SL52.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL52.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL52).Name = "SL52";
		SL52.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL52).Text = "52";
		SL53.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL53.Appearance.Hovered.Options.UseFont = true;
		SL53.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL53.Appearance.Normal.Options.UseFont = true;
		SL53.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL53.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL53).Name = "SL53";
		SL53.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL53).Text = "53";
		SL54.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL54.Appearance.Hovered.Options.UseFont = true;
		SL54.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL54.Appearance.Normal.Options.UseFont = true;
		SL54.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL54.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL54).Name = "SL54";
		SL54.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL54).Text = "54";
		SL55.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL55.Appearance.Hovered.Options.UseFont = true;
		SL55.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL55.Appearance.Normal.Options.UseFont = true;
		SL55.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL55.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL55).Name = "SL55";
		SL55.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL55).Text = "55";
		SL56.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL56.Appearance.Hovered.Options.UseFont = true;
		SL56.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL56.Appearance.Normal.Options.UseFont = true;
		SL56.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL56.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL56).Name = "SL56";
		SL56.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL56).Text = "56";
		SL57.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL57.Appearance.Hovered.Options.UseFont = true;
		SL57.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL57.Appearance.Normal.Options.UseFont = true;
		SL57.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL57.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL57).Name = "SL57";
		SL57.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL57).Text = "57";
		SL58.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL58.Appearance.Hovered.Options.UseFont = true;
		SL58.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL58.Appearance.Normal.Options.UseFont = true;
		SL58.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL58.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL58).Name = "SL58";
		SL58.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL58).Text = "58";
		SL59.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL59.Appearance.Hovered.Options.UseFont = true;
		SL59.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL59.Appearance.Normal.Options.UseFont = true;
		SL59.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL59.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL59).Name = "SL59";
		SL59.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL59).Text = "59";
		SL60.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL60.Appearance.Hovered.Options.UseFont = true;
		SL60.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL60.Appearance.Normal.Options.UseFont = true;
		SL60.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL60.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL60).Name = "SL60";
		SL60.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL60).Text = "60";
		SLMain6.Appearance.Hovered.Font = new Font("Bahnschrift SemiBold", 14.25f, (FontStyle)1);
		SLMain6.Appearance.Hovered.ForeColor = Color.FromArgb(255, 255, 192);
		SLMain6.Appearance.Hovered.Options.UseFont = true;
		SLMain6.Appearance.Hovered.Options.UseForeColor = true;
		SLMain6.Appearance.Normal.Font = new Font("Bahnschrift SemiBold", 14.25f, (FontStyle)1);
		SLMain6.Appearance.Normal.ForeColor = Color.FromArgb(255, 255, 192);
		SLMain6.Appearance.Normal.Options.UseFont = true;
		SLMain6.Appearance.Normal.Options.UseForeColor = true;
		SLMain6.Appearance.Pressed.Font = new Font("Bahnschrift SemiBold", 14.25f, (FontStyle)1);
		SLMain6.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SLMain6).Name = "SLMain6";
		((AccordionControlElementBase)SLMain6).Text = "Advanced";
		SL61.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL61.Appearance.Hovered.Options.UseFont = true;
		SL61.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL61.Appearance.Normal.Options.UseFont = true;
		SL61.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL61.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL61).Name = "SL61";
		SL61.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL61).Text = "61";
		SL62.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL62.Appearance.Hovered.Options.UseFont = true;
		SL62.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL62.Appearance.Normal.Options.UseFont = true;
		SL62.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL62.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL62).Name = "SL62";
		SL62.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL62).Text = "62";
		SL63.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL63.Appearance.Hovered.Options.UseFont = true;
		SL63.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL63.Appearance.Normal.Options.UseFont = true;
		SL63.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL63.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL63).Name = "SL63";
		SL63.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL63).Text = "63";
		SL64.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL64.Appearance.Hovered.Options.UseFont = true;
		SL64.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL64.Appearance.Normal.Options.UseFont = true;
		SL64.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL64.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL64).Name = "SL64";
		SL64.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL64).Text = "64";
		SL65.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		SL65.Appearance.Hovered.Options.UseFont = true;
		SL65.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		SL65.Appearance.Normal.Options.UseFont = true;
		SL65.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		SL65.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL65).Name = "SL65";
		SL65.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL65).Text = "65";
		elementMail.Elements.AddRange((AccordionControlElement[])(object)new AccordionControlElement[18]
		{
			SLMain, SLMain2, SL21, SL22, SL23, SL24, SL25, SL26, SL27, SL28,
			SL29, SL30, SL31, SL32, SL33, SL34, SL35, SLMain3
		});
		((AccordionControlElementBase)elementMail).Expanded = true;
		((ImageCollectionImageOptions)((AccordionControlElementBase)elementMail).ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("elementMail.ImageOptions.SvgImage");
		((ImageOptions)((AccordionControlElementBase)elementMail).ImageOptions).SvgImageSize = new Size(24, 24);
		((AccordionControlElementBase)elementMail).Name = "elementMail";
		((AccordionControlElementBase)elementMail).Tag = 3;
		((AccordionControlElementBase)elementMail).Text = "MainMenu";
		SLMain.Appearance.Disabled.Font = new Font("Bahnschrift", 12.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SLMain.Appearance.Disabled.Options.UseFont = true;
		SLMain.Appearance.Hovered.Font = new Font("Bahnschrift SemiBold", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		SLMain.Appearance.Hovered.ForeColor = Color.FromArgb(255, 255, 192);
		SLMain.Appearance.Hovered.Options.UseFont = true;
		SLMain.Appearance.Hovered.Options.UseForeColor = true;
		SLMain.Appearance.Normal.Font = new Font("Bahnschrift SemiBold", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		SLMain.Appearance.Normal.ForeColor = Color.FromArgb(255, 255, 192);
		SLMain.Appearance.Normal.Options.UseFont = true;
		SLMain.Appearance.Normal.Options.UseForeColor = true;
		SLMain.Appearance.Pressed.Font = new Font("Bahnschrift SemiBold", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		SLMain.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 192);
		SLMain.Appearance.Pressed.Options.UseFont = true;
		SLMain.Appearance.Pressed.Options.UseForeColor = true;
		SLMain.Elements.AddRange((AccordionControlElement[])(object)new AccordionControlElement[21]
		{
			SL0, SL1, SL2, SL3, SL4, SL5, SL6, SL7, SL8, SL9,
			SL10, SL11, SL12, SL13, SL14, SL15, SL16, SL17, SL18, SL19,
			SL20
		});
		((AccordionControlElementBase)SLMain).Expanded = true;
		SLMain.HeaderTemplate.AddRange((HeaderElementInfo[])(object)new HeaderElementInfo[4]
		{
			new HeaderElementInfo((HeaderElementType)1, (HeaderElementAlignment)0),
			new HeaderElementInfo((HeaderElementType)2),
			new HeaderElementInfo((HeaderElementType)3),
			new HeaderElementInfo((HeaderElementType)0)
		});
		((AccordionControlElementBase)SLMain).Height = -1;
		((ImageCollectionImageOptions)((AccordionControlElementBase)SLMain).ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("SLMain.ImageOptions.SvgImage");
		((ImageOptions)((AccordionControlElementBase)SLMain).ImageOptions).SvgImageSize = new Size(24, 24);
		((AccordionControlElementBase)SLMain).Name = "SLMain";
		((AccordionControlElementBase)SLMain).Tag = 1;
		((AccordionControlElementBase)SLMain).Text = "Lite";
		SL0.Appearance.Disabled.Font = new Font("Calibri", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL0.Appearance.Disabled.Options.UseFont = true;
		SL0.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL0.Appearance.Hovered.Options.UseFont = true;
		SL0.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL0.Appearance.Normal.Options.UseFont = true;
		SL0.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL0.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL0.Appearance.Pressed.Options.UseFont = true;
		SL0.Appearance.Pressed.Options.UseForeColor = true;
		((AccordionControlElementBase)SL0).ImageOptions.ImageLayoutMode = (ImageLayoutMode)2;
		((AccordionControlElementBase)SL0).Name = "SL0";
		SL0.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL0).Text = "0";
		SL1.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL1.Appearance.Hovered.Options.UseFont = true;
		SL1.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL1.Appearance.Normal.Options.UseFont = true;
		SL1.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL1.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL1.Appearance.Pressed.Options.UseFont = true;
		SL1.Appearance.Pressed.Options.UseForeColor = true;
		SL1.HeaderTemplate.AddRange((HeaderElementInfo[])(object)new HeaderElementInfo[4]
		{
			new HeaderElementInfo((HeaderElementType)2),
			new HeaderElementInfo((HeaderElementType)3),
			new HeaderElementInfo((HeaderElementType)1),
			new HeaderElementInfo((HeaderElementType)0)
		});
		((AccordionControlElementBase)SL1).ImageOptions.ImageLayoutMode = (ImageLayoutMode)1;
		((AccordionControlElementBase)SL1).Name = "SL1";
		SL1.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL1).Text = "1";
		SL2.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL2.Appearance.Hovered.Options.UseFont = true;
		SL2.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL2.Appearance.Normal.Options.UseFont = true;
		SL2.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL2.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL2.Appearance.Pressed.Options.UseFont = true;
		SL2.Appearance.Pressed.Options.UseForeColor = true;
		SL2.HeaderTemplate.AddRange((HeaderElementInfo[])(object)new HeaderElementInfo[4]
		{
			new HeaderElementInfo((HeaderElementType)3),
			new HeaderElementInfo((HeaderElementType)2),
			new HeaderElementInfo((HeaderElementType)0),
			new HeaderElementInfo((HeaderElementType)1)
		});
		((AccordionControlElementBase)SL2).Name = "SL2";
		SL2.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL2).Text = "2";
		SL3.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL3.Appearance.Hovered.Options.UseFont = true;
		SL3.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL3.Appearance.Normal.Options.UseFont = true;
		SL3.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL3.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL3.Appearance.Pressed.Options.UseFont = true;
		SL3.Appearance.Pressed.Options.UseForeColor = true;
		((AccordionControlElementBase)SL3).Name = "SL3";
		SL3.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL3).Text = "3";
		SL4.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL4.Appearance.Hovered.Options.UseFont = true;
		SL4.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL4.Appearance.Normal.Options.UseFont = true;
		SL4.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL4.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL4.Appearance.Pressed.Options.UseFont = true;
		SL4.Appearance.Pressed.Options.UseForeColor = true;
		((AccordionControlElementBase)SL4).Name = "SL4";
		SL4.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL4).Text = "4";
		SL5.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL5.Appearance.Hovered.Options.UseFont = true;
		SL5.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL5.Appearance.Normal.Options.UseFont = true;
		SL5.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL5.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL5.Appearance.Pressed.Options.UseFont = true;
		SL5.Appearance.Pressed.Options.UseForeColor = true;
		((AccordionControlElementBase)SL5).Name = "SL5";
		SL5.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL5).Text = "5";
		SL6.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL6.Appearance.Hovered.Options.UseFont = true;
		SL6.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL6.Appearance.Normal.Options.UseFont = true;
		SL6.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL6.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL6.Appearance.Pressed.Options.UseFont = true;
		SL6.Appearance.Pressed.Options.UseForeColor = true;
		((AccordionControlElementBase)SL6).Name = "SL6";
		SL6.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL6).Text = "6";
		SL7.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL7.Appearance.Hovered.Options.UseFont = true;
		SL7.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL7.Appearance.Normal.Options.UseFont = true;
		SL7.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL7.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL7.Appearance.Pressed.Options.UseFont = true;
		SL7.Appearance.Pressed.Options.UseForeColor = true;
		((AccordionControlElementBase)SL7).Name = "SL7";
		SL7.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL7).Text = "7";
		SL8.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL8.Appearance.Hovered.Options.UseFont = true;
		SL8.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL8.Appearance.Normal.Options.UseFont = true;
		SL8.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL8.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL8.Appearance.Pressed.Options.UseFont = true;
		SL8.Appearance.Pressed.Options.UseForeColor = true;
		((AccordionControlElementBase)SL8).Name = "SL8";
		SL8.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL8).Text = "8";
		SL9.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL9.Appearance.Hovered.Options.UseFont = true;
		SL9.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL9.Appearance.Normal.Options.UseFont = true;
		SL9.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL9.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL9.Appearance.Pressed.Options.UseFont = true;
		SL9.Appearance.Pressed.Options.UseForeColor = true;
		((AccordionControlElementBase)SL9).Name = "SL9";
		SL9.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL9).Text = "9";
		SL10.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL10.Appearance.Hovered.Options.UseFont = true;
		SL10.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL10.Appearance.Normal.Options.UseFont = true;
		SL10.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL10.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL10.Appearance.Pressed.Options.UseFont = true;
		SL10.Appearance.Pressed.Options.UseForeColor = true;
		((AccordionControlElementBase)SL10).Name = "SL10";
		SL10.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL10).Text = "10";
		SL11.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL11.Appearance.Hovered.Options.UseFont = true;
		SL11.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL11.Appearance.Normal.Options.UseFont = true;
		SL11.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL11.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL11.Appearance.Pressed.Options.UseFont = true;
		SL11.Appearance.Pressed.Options.UseForeColor = true;
		((AccordionControlElementBase)SL11).Name = "SL11";
		SL11.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL11).Text = "11";
		SL12.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL12.Appearance.Hovered.Options.UseFont = true;
		SL12.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL12.Appearance.Normal.Options.UseFont = true;
		SL12.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL12.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL12).Name = "SL12";
		SL12.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL12).Text = "12";
		SL13.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL13.Appearance.Hovered.Options.UseFont = true;
		SL13.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL13.Appearance.Normal.Options.UseFont = true;
		SL13.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL13.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL13.Appearance.Pressed.Options.UseFont = true;
		SL13.Appearance.Pressed.Options.UseForeColor = true;
		((AccordionControlElementBase)SL13).Name = "SL13";
		SL13.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL13).Text = "13";
		SL14.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL14.Appearance.Hovered.Options.UseFont = true;
		SL14.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL14.Appearance.Normal.Options.UseFont = true;
		SL14.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL14.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL14.Appearance.Pressed.Options.UseFont = true;
		SL14.Appearance.Pressed.Options.UseForeColor = true;
		((AccordionControlElementBase)SL14).Name = "SL14";
		SL14.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL14).Text = "14";
		SL15.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL15.Appearance.Hovered.Options.UseFont = true;
		SL15.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL15.Appearance.Normal.Options.UseFont = true;
		SL15.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL15.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL15.Appearance.Pressed.Options.UseFont = true;
		SL15.Appearance.Pressed.Options.UseForeColor = true;
		((AccordionControlElementBase)SL15).Name = "SL15";
		SL15.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL15).Text = "15";
		SL16.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL16.Appearance.Hovered.Options.UseFont = true;
		SL16.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL16.Appearance.Normal.Options.UseFont = true;
		SL16.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL16.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL16.Appearance.Pressed.Options.UseFont = true;
		SL16.Appearance.Pressed.Options.UseForeColor = true;
		((AccordionControlElementBase)SL16).Name = "SL16";
		SL16.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL16).Text = "16";
		SL17.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL17.Appearance.Hovered.Options.UseFont = true;
		SL17.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL17.Appearance.Normal.Options.UseFont = true;
		SL17.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL17.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL17.Appearance.Pressed.Options.UseFont = true;
		SL17.Appearance.Pressed.Options.UseForeColor = true;
		((AccordionControlElementBase)SL17).Name = "SL17";
		SL17.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL17).Text = "17";
		SL18.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL18.Appearance.Hovered.Options.UseFont = true;
		SL18.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL18.Appearance.Normal.Options.UseFont = true;
		SL18.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL18.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL18.Appearance.Pressed.Options.UseFont = true;
		SL18.Appearance.Pressed.Options.UseForeColor = true;
		((AccordionControlElementBase)SL18).Name = "SL18";
		SL18.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL18).Text = "18";
		SL19.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL19.Appearance.Hovered.Options.UseFont = true;
		SL19.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL19.Appearance.Normal.Options.UseFont = true;
		SL19.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL19.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL19).Name = "SL19";
		SL19.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL19).Text = "19";
		SL20.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL20.Appearance.Hovered.Options.UseFont = true;
		SL20.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL20.Appearance.Normal.Options.UseFont = true;
		SL20.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL20.Appearance.Pressed.ForeColor = Color.FromArgb(255, 255, 128);
		SL20.Appearance.Pressed.Options.UseFont = true;
		SL20.Appearance.Pressed.Options.UseForeColor = true;
		((AccordionControlElementBase)SL20).Name = "SL20";
		SL20.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL20).Text = "20";
		SLMain2.Appearance.Disabled.Font = new Font("Bahnschrift", 12.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SLMain2.Appearance.Disabled.Options.UseFont = true;
		SLMain2.Appearance.Hovered.Font = new Font("Bahnschrift SemiBold", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		SLMain2.Appearance.Hovered.ForeColor = Color.FromArgb(255, 255, 192);
		SLMain2.Appearance.Hovered.Options.UseFont = true;
		SLMain2.Appearance.Hovered.Options.UseForeColor = true;
		SLMain2.Appearance.Normal.Font = new Font("Bahnschrift SemiBold", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		SLMain2.Appearance.Normal.ForeColor = Color.FromArgb(255, 255, 192);
		SLMain2.Appearance.Normal.Options.UseFont = true;
		SLMain2.Appearance.Normal.Options.UseForeColor = true;
		SLMain2.Appearance.Pressed.Font = new Font("Bahnschrift", 12.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SLMain2.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SLMain2).Expanded = true;
		((AccordionControlElementBase)SLMain2).Height = -1;
		((ImageCollectionImageOptions)((AccordionControlElementBase)SLMain2).ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("SLMain2.ImageOptions.SvgImage");
		((ImageOptions)((AccordionControlElementBase)SLMain2).ImageOptions).SvgImageSize = new Size(24, 24);
		((AccordionControlElementBase)SLMain2).Name = "SLMain2";
		((AccordionControlElementBase)SLMain2).Tag = 2;
		((AccordionControlElementBase)SLMain2).Text = "Standard";
		((AccordionControlElementBase)SLMain2).Visible = false;
		SL21.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL21.Appearance.Hovered.Options.UseFont = true;
		SL21.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL21.Appearance.Normal.Options.UseFont = true;
		SL21.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL21.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL21).Name = "SL21";
		SL21.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL21).Text = "21";
		SL22.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL22.Appearance.Hovered.Options.UseFont = true;
		SL22.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL22.Appearance.Normal.Options.UseFont = true;
		SL22.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL22.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL22).Name = "SL22";
		SL22.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL22).Text = "22";
		SL23.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL23.Appearance.Hovered.Options.UseFont = true;
		SL23.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL23.Appearance.Normal.Options.UseFont = true;
		SL23.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL23.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL23).Name = "SL23";
		SL23.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL23).Text = "23";
		SL24.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL24.Appearance.Hovered.Options.UseFont = true;
		SL24.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL24.Appearance.Normal.Options.UseFont = true;
		SL24.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL24.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL24).Name = "SL24";
		SL24.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL24).Text = "24";
		SL25.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL25.Appearance.Hovered.Options.UseFont = true;
		SL25.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL25.Appearance.Normal.Options.UseFont = true;
		SL25.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL25.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL25).Name = "SL25";
		SL25.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL25).Text = "25";
		SL26.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL26.Appearance.Hovered.Options.UseFont = true;
		SL26.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL26.Appearance.Normal.Options.UseFont = true;
		SL26.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL26.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL26).Name = "SL26";
		SL26.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL26).Text = "26";
		SL27.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL27.Appearance.Hovered.Options.UseFont = true;
		SL27.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL27.Appearance.Normal.Options.UseFont = true;
		SL27.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL27.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL27).Name = "SL27";
		SL27.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL27).Text = "27";
		SL28.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL28.Appearance.Hovered.Options.UseFont = true;
		SL28.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL28.Appearance.Normal.Options.UseFont = true;
		SL28.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL28.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL28).Name = "SL28";
		SL28.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL28).Text = "28";
		SL29.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL29.Appearance.Hovered.Options.UseFont = true;
		SL29.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL29.Appearance.Normal.Options.UseFont = true;
		SL29.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL29.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL29).Name = "SL29";
		SL29.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL29).Text = "29";
		SL30.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL30.Appearance.Hovered.Options.UseFont = true;
		SL30.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL30.Appearance.Normal.Options.UseFont = true;
		SL30.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL30.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL30).Name = "SL30";
		SL30.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL30).Text = "30";
		SL31.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL31.Appearance.Hovered.Options.UseFont = true;
		SL31.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL31.Appearance.Normal.Options.UseFont = true;
		SL31.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL31.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL31).Name = "SL31";
		SL31.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL31).Text = "31";
		SL32.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL32.Appearance.Hovered.Options.UseFont = true;
		SL32.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL32.Appearance.Normal.Options.UseFont = true;
		SL32.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL32.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL32).Name = "SL32";
		SL32.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL32).Text = "32";
		SL33.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL33.Appearance.Hovered.Options.UseFont = true;
		SL33.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL33.Appearance.Normal.Options.UseFont = true;
		SL33.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL33.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL33).Name = "SL33";
		SL33.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL33).Text = "33";
		SL34.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL34.Appearance.Hovered.Options.UseFont = true;
		SL34.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL34.Appearance.Normal.Options.UseFont = true;
		SL34.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL34.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL34).Name = "SL34";
		SL34.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL34).Text = "34";
		SL35.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL35.Appearance.Hovered.Options.UseFont = true;
		SL35.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL35.Appearance.Normal.Options.UseFont = true;
		SL35.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SL35.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SL35).Name = "SL35";
		SL35.Style = (ElementStyle)1;
		((AccordionControlElementBase)SL35).Text = "35";
		SLMain3.Appearance.Disabled.Font = new Font("Bahnschrift", 12.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SLMain3.Appearance.Disabled.Options.UseFont = true;
		SLMain3.Appearance.Hovered.Font = new Font("Bahnschrift SemiBold", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		SLMain3.Appearance.Hovered.ForeColor = Color.FromArgb(255, 255, 192);
		SLMain3.Appearance.Hovered.Options.UseFont = true;
		SLMain3.Appearance.Hovered.Options.UseForeColor = true;
		SLMain3.Appearance.Normal.Font = new Font("Bahnschrift SemiBold", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		SLMain3.Appearance.Normal.ForeColor = Color.FromArgb(255, 255, 192);
		SLMain3.Appearance.Normal.Options.UseFont = true;
		SLMain3.Appearance.Normal.Options.UseForeColor = true;
		SLMain3.Appearance.Pressed.Font = new Font("Bahnschrift", 12.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		SLMain3.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)SLMain3).Expanded = true;
		((AccordionControlElementBase)SLMain3).Height = -1;
		((ImageCollectionImageOptions)((AccordionControlElementBase)SLMain3).ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("SLMain3.ImageOptions.SvgImage");
		((ImageOptions)((AccordionControlElementBase)SLMain3).ImageOptions).SvgImageSize = new Size(24, 24);
		((AccordionControlElementBase)SLMain3).Name = "SLMain3";
		((AccordionControlElementBase)SLMain3).Tag = 3;
		((AccordionControlElementBase)SLMain3).Text = "Pro";
		((AccordionControlElementBase)SLMain3).Visible = false;
		SideTrip.AllowItemSelection = true;
		((Control)SideTrip).Dock = (DockStyle)3;
		SideTrip.Elements.AddRange((AccordionControlElement[])(object)new AccordionControlElement[3] { elementMail, elementCalendar, elementPeople });
		SideTrip.ExpandElementMode = (ExpandElementMode)0;
		SideTrip.ExpandGroupOnHeaderClick = false;
		SideTrip.ExpandItemOnHeaderClick = false;
		((Control)SideTrip).Location = new Point(0, 38);
		((BaseControl)SideTrip).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)SideTrip).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)SideTrip).Margin = new Padding(2, 3, 2, 3);
		((Control)SideTrip).Name = "SideTrip";
		SideTrip.OptionsMinimizing.NormalWidth = 170;
		SideTrip.RootDisplayMode = (AccordionControlRootDisplayMode)1;
		SideTrip.ScrollBarMode = (ScrollBarMode)0;
		SideTrip.ShowFilterControl = (ShowFilterControl)0;
		SideTrip.ShowGroupExpandButtons = false;
		SideTrip.ShowItemExpandButtons = false;
		((BaseControl)SideTrip).ShowToolTips = false;
		((Control)SideTrip).Size = new Size(170, 673);
		((Control)SideTrip).TabIndex = 15;
		SideTrip.ViewType = (AccordionControlViewType)1;
		((Control)PnlBotam).BackColor = SystemColors.ButtonHighlight;
		((Control)PnlBotam).Controls.Add((Control)(object)cboTheme);
		((Control)PnlBotam).Controls.Add((Control)(object)chkLiveRate);
		((Control)PnlBotam).Controls.Add((Control)(object)nCurrncyRate);
		((Control)PnlBotam).Controls.Add((Control)(object)lblLiveRate);
		((Control)PnlBotam).Controls.Add((Control)(object)LblUserRequest);
		((Control)PnlBotam).Controls.Add((Control)(object)tAmcDate);
		((Control)PnlBotam).Controls.Add((Control)(object)chkWappId);
		((Control)PnlBotam).Controls.Add((Control)(object)tSoftDemoType);
		((Control)PnlBotam).Controls.Add((Control)(object)chkNextAi);
		((Control)PnlBotam).Dock = (DockStyle)2;
		((Control)PnlBotam).Location = new Point(170, 693);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1180, 18);
		((Control)PnlBotam).TabIndex = 17;
		cboTheme.BackColor = SystemColors.ButtonHighlight;
		cboTheme.FlatStyle = (FlatStyle)0;
		((Control)cboTheme).Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		cboTheme.ForeColor = Color.Navy;
		((ListControl)cboTheme).FormattingEnabled = true;
		cboTheme.ItemHeight = 17;
		((Control)cboTheme).Location = new Point(3, 0);
		((Control)cboTheme).Margin = new Padding(3, 0, 3, 3);
		((Control)cboTheme).Name = "cboTheme";
		((Control)cboTheme).RightToLeft = (RightToLeft)1;
		((Control)cboTheme).Size = new Size(72, 25);
		((Control)cboTheme).TabIndex = 19;
		((ButtonBase)chkLiveRate).BackColor = Color.Transparent;
		chkLiveRate.CheckAlign = (ContentAlignment)64;
		((Control)chkLiveRate).Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkLiveRate).ForeColor = Color.Navy;
		((Control)chkLiveRate).Location = new Point(81, 1);
		((Control)chkLiveRate).Margin = new Padding(3, 1, 3, 3);
		((Control)chkLiveRate).Name = "chkLiveRate";
		((Control)chkLiveRate).RightToLeft = (RightToLeft)0;
		((Control)chkLiveRate).Size = new Size(93, 19);
		((Control)chkLiveRate).TabIndex = 4;
		((ButtonBase)chkLiveRate).Text = "Live Rate";
		chkLiveRate.TextAlign = (ContentAlignment)32;
		((ButtonBase)chkLiveRate).UseVisualStyleBackColor = false;
		((TextBoxBase)nCurrncyRate).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)nCurrncyRate).BorderStyle = (BorderStyle)0;
		((Control)nCurrncyRate).Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)nCurrncyRate).ForeColor = Color.Navy;
		((Control)nCurrncyRate).Location = new Point(180, 3);
		((Control)nCurrncyRate).Name = "nCurrncyRate";
		((TextBoxBase)nCurrncyRate).ReadOnly = true;
		((Control)nCurrncyRate).Size = new Size(11, 18);
		((Control)nCurrncyRate).TabIndex = 5;
		((Control)nCurrncyRate).Visible = false;
		lblLiveRate.AutoSize = true;
		((Control)lblLiveRate).Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblLiveRate).ForeColor = Color.Navy;
		((Control)lblLiveRate).Location = new Point(197, 1);
		((Control)lblLiveRate).Margin = new Padding(3, 1, 3, 0);
		((Control)lblLiveRate).Name = "lblLiveRate";
		((Control)lblLiveRate).Size = new Size(77, 17);
		((Control)lblLiveRate).TabIndex = 25;
		lblLiveRate.Text = "Live Rate :";
		lblLiveRate.TextAlign = (ContentAlignment)32;
		LblUserRequest.AutoSize = true;
		((Control)LblUserRequest).Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LblUserRequest).ForeColor = Color.Navy;
		((Control)LblUserRequest).Location = new Point(280, 1);
		((Control)LblUserRequest).Margin = new Padding(3, 1, 3, 0);
		((Control)LblUserRequest).Name = "LblUserRequest";
		((Control)LblUserRequest).Size = new Size(53, 17);
		((Control)LblUserRequest).TabIndex = 24;
		LblUserRequest.Text = "UReq :";
		LblUserRequest.TextAlign = (ContentAlignment)32;
		((Control)LblUserRequest).Visible = false;
		tAmcDate.AutoSize = true;
		((Control)tAmcDate).Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAmcDate).ForeColor = Color.Navy;
		((Control)tAmcDate).Location = new Point(339, 1);
		((Control)tAmcDate).Margin = new Padding(3, 1, 3, 0);
		((Control)tAmcDate).Name = "tAmcDate";
		((Control)tAmcDate).Size = new Size(81, 17);
		((Control)tAmcDate).TabIndex = 26;
		tAmcDate.Text = "Amc Date :";
		tAmcDate.TextAlign = (ContentAlignment)32;
		((ButtonBase)chkWappId).BackColor = Color.Transparent;
		((Control)chkWappId).Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkWappId).ForeColor = Color.Navy;
		((Control)chkWappId).Location = new Point(426, 0);
		((Control)chkWappId).Margin = new Padding(3, 0, 3, 1);
		((Control)chkWappId).Name = "chkWappId";
		((Control)chkWappId).RightToLeft = (RightToLeft)0;
		((Control)chkWappId).Size = new Size(153, 19);
		((Control)chkWappId).TabIndex = 22;
		((ButtonBase)chkWappId).Text = "Whatsapp Open";
		((ButtonBase)chkWappId).UseVisualStyleBackColor = false;
		((ButtonBase)chkNextAi).BackColor = Color.Transparent;
		((Control)chkNextAi).Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkNextAi).ForeColor = Color.Navy;
		((Control)chkNextAi).Location = new Point(641, 0);
		((Control)chkNextAi).Margin = new Padding(3, 0, 3, 1);
		((Control)chkNextAi).Name = "chkNextAi";
		((Control)chkNextAi).RightToLeft = (RightToLeft)0;
		((Control)chkNextAi).Size = new Size(84, 19);
		((Control)chkNextAi).TabIndex = 27;
		((ButtonBase)chkNextAi).Text = "Next Ai";
		((ButtonBase)chkNextAi).UseVisualStyleBackColor = false;
		((TextBoxBase)tSoftDemoType).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)tSoftDemoType).BorderStyle = (BorderStyle)0;
		((Control)tSoftDemoType).Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tSoftDemoType).ForeColor = Color.Navy;
		((Control)tSoftDemoType).Location = new Point(585, 0);
		((Control)tSoftDemoType).Margin = new Padding(3, 0, 3, 3);
		((Control)tSoftDemoType).Name = "tSoftDemoType";
		((TextBoxBase)tSoftDemoType).ReadOnly = true;
		((Control)tSoftDemoType).Size = new Size(50, 18);
		((Control)tSoftDemoType).TabIndex = 21;
		((Control)PanelImage).BackColor = Color.Transparent;
		((Control)PanelImage).BackgroundImage = (Image)componentResourceManager.GetObject("PanelImage.BackgroundImage");
		((Control)PanelImage).BackgroundImageLayout = (ImageLayout)3;
		PanelImage.BorderStyle = (BorderStyle)2;
		((Control)PanelImage).Controls.Add((Control)(object)LblSilverSl);
		((Control)PanelImage).Controls.Add((Control)(object)LblGoldSl);
		((Control)PanelImage).Controls.Add((Control)(object)Rate_7);
		((Control)PanelImage).Controls.Add((Control)(object)Rate_6);
		((Control)PanelImage).Controls.Add((Control)(object)Rate_5);
		((Control)PanelImage).Controls.Add((Control)(object)Rate_4);
		((Control)PanelImage).Controls.Add((Control)(object)Rate_3);
		((Control)PanelImage).Controls.Add((Control)(object)Rate_2);
		((Control)PanelImage).Controls.Add((Control)(object)Rate_1);
		((Control)PanelImage).Location = new Point(171, 39);
		((Control)PanelImage).Name = "PanelImage";
		((Control)PanelImage).Size = new Size(1181, 650);
		((Control)PanelImage).TabIndex = 19;
		((Control)PanelImage).Visible = false;
		((Control)LblSilverSl).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LblSilverSl).ForeColor = Color.FromArgb(192, 0, 0);
		LblSilverSl.ImeMode = (ImeMode)0;
		((Control)LblSilverSl).Location = new Point(46, 69);
		((Control)LblSilverSl).Name = "LblSilverSl";
		((Control)LblSilverSl).Size = new Size(511, 20);
		((Control)LblSilverSl).TabIndex = 1145;
		LblSilverSl.Text = "Silver Sales :";
		LblSilverSl.TextAlign = (ContentAlignment)16;
		((Control)LblSilverSl).Visible = false;
		((Control)LblGoldSl).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LblGoldSl).ForeColor = Color.FromArgb(192, 0, 0);
		LblGoldSl.ImeMode = (ImeMode)0;
		((Control)LblGoldSl).Location = new Point(45, 42);
		((Control)LblGoldSl).Name = "LblGoldSl";
		((Control)LblGoldSl).Size = new Size(511, 20);
		((Control)LblGoldSl).TabIndex = 1144;
		LblGoldSl.Text = "Gold Sales  :";
		LblGoldSl.TextAlign = (ContentAlignment)16;
		((Control)LblGoldSl).Visible = false;
		((Control)Rate_7).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Rate_7).ForeColor = Color.FromArgb(192, 0, 0);
		Rate_7.ImeMode = (ImeMode)0;
		((Control)Rate_7).Location = new Point(826, 180);
		((Control)Rate_7).Name = "Rate_7";
		((Control)Rate_7).Size = new Size(340, 20);
		((Control)Rate_7).TabIndex = 1143;
		Rate_7.Text = "Ac Group";
		Rate_7.TextAlign = (ContentAlignment)64;
		((Control)Rate_7).Visible = false;
		((Control)Rate_6).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Rate_6).ForeColor = Color.FromArgb(192, 0, 0);
		Rate_6.ImeMode = (ImeMode)0;
		((Control)Rate_6).Location = new Point(826, 157);
		((Control)Rate_6).Name = "Rate_6";
		((Control)Rate_6).Size = new Size(340, 20);
		((Control)Rate_6).TabIndex = 1142;
		Rate_6.Text = "Ac Group";
		Rate_6.TextAlign = (ContentAlignment)64;
		((Control)Rate_6).Visible = false;
		((Control)Rate_5).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Rate_5).ForeColor = Color.FromArgb(192, 0, 0);
		Rate_5.ImeMode = (ImeMode)0;
		((Control)Rate_5).Location = new Point(826, 134);
		((Control)Rate_5).Name = "Rate_5";
		((Control)Rate_5).Size = new Size(340, 20);
		((Control)Rate_5).TabIndex = 1141;
		Rate_5.Text = "Ac Group";
		Rate_5.TextAlign = (ContentAlignment)64;
		((Control)Rate_5).Visible = false;
		((Control)Rate_4).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Rate_4).ForeColor = Color.FromArgb(192, 0, 0);
		Rate_4.ImeMode = (ImeMode)0;
		((Control)Rate_4).Location = new Point(826, 111);
		((Control)Rate_4).Name = "Rate_4";
		((Control)Rate_4).Size = new Size(340, 20);
		((Control)Rate_4).TabIndex = 1140;
		Rate_4.Text = "Ac Group";
		Rate_4.TextAlign = (ContentAlignment)64;
		((Control)Rate_4).Visible = false;
		((Control)Rate_3).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Rate_3).ForeColor = Color.FromArgb(192, 0, 0);
		Rate_3.ImeMode = (ImeMode)0;
		((Control)Rate_3).Location = new Point(826, 88);
		((Control)Rate_3).Name = "Rate_3";
		((Control)Rate_3).Size = new Size(340, 20);
		((Control)Rate_3).TabIndex = 1139;
		Rate_3.Text = "Ac Group";
		Rate_3.TextAlign = (ContentAlignment)64;
		((Control)Rate_3).Visible = false;
		((Control)Rate_2).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Rate_2).ForeColor = Color.FromArgb(192, 0, 0);
		Rate_2.ImeMode = (ImeMode)0;
		((Control)Rate_2).Location = new Point(826, 65);
		((Control)Rate_2).Name = "Rate_2";
		((Control)Rate_2).Size = new Size(340, 20);
		((Control)Rate_2).TabIndex = 1138;
		Rate_2.Text = "Ac Group";
		Rate_2.TextAlign = (ContentAlignment)64;
		((Control)Rate_2).Visible = false;
		((Control)Rate_1).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Rate_1).ForeColor = Color.FromArgb(192, 0, 0);
		Rate_1.ImeMode = (ImeMode)0;
		((Control)Rate_1).Location = new Point(826, 42);
		((Control)Rate_1).Name = "Rate_1";
		((Control)Rate_1).Size = new Size(340, 20);
		((Control)Rate_1).TabIndex = 1137;
		Rate_1.Text = "Ac Group";
		Rate_1.TextAlign = (ContentAlignment)64;
		((Control)Rate_1).Visible = false;
		Timer1.Interval = 10000;
		AccordionControlElement1.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		AccordionControlElement1.Appearance.Hovered.Options.UseFont = true;
		AccordionControlElement1.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		AccordionControlElement1.Appearance.Normal.Options.UseFont = true;
		AccordionControlElement1.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		AccordionControlElement1.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)AccordionControlElement1).Name = "AccordionControlElement1";
		AccordionControlElement1.Style = (ElementStyle)1;
		((AccordionControlElementBase)AccordionControlElement1).Text = "51";
		AccordionControlElement2.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		AccordionControlElement2.Appearance.Hovered.Options.UseFont = true;
		AccordionControlElement2.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		AccordionControlElement2.Appearance.Normal.Options.UseFont = true;
		AccordionControlElement2.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		AccordionControlElement2.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)AccordionControlElement2).Name = "AccordionControlElement2";
		AccordionControlElement2.Style = (ElementStyle)1;
		((AccordionControlElementBase)AccordionControlElement2).Text = "51";
		AccordionControlElement3.Appearance.Hovered.Font = new Font("Bahnschrift", 11.25f);
		AccordionControlElement3.Appearance.Hovered.Options.UseFont = true;
		AccordionControlElement3.Appearance.Normal.Font = new Font("Bahnschrift", 11.25f);
		AccordionControlElement3.Appearance.Normal.Options.UseFont = true;
		AccordionControlElement3.Appearance.Pressed.Font = new Font("Bahnschrift", 11.25f);
		AccordionControlElement3.Appearance.Pressed.Options.UseFont = true;
		((AccordionControlElementBase)AccordionControlElement3).Name = "AccordionControlElement3";
		AccordionControlElement3.Style = (ElementStyle)1;
		((AccordionControlElementBase)AccordionControlElement3).Text = "51";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).AutoSize = true;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Control)this).BackgroundImageLayout = (ImageLayout)3;
		((Form)this).ClientSize = new Size(1350, 711);
		((Control)this).Controls.Add((Control)(object)PanelImage);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)SideTrip);
		((Control)this).Controls.Add((Control)(object)Panel1);
		((Control)this).Controls.Add((Control)(object)Panel_Side);
		((Control)this).Controls.Add((Control)(object)MainTrip);
		((Control)this).Font = new Font("Corbel", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).IsMdiContainer = true;
		((Form)this).KeyPreview = true;
		((Form)this).Margin = new Padding(3, 4, 3, 4);
		((Control)this).Name = "MDI_FORM";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "MDI_FORM";
		((Form)this).WindowState = (FormWindowState)2;
		((Control)MainTrip).ResumeLayout(false);
		((Control)MainTrip).PerformLayout();
		((ISupportInitialize)xtraTabbedMdiManager1).EndInit();
		((ISupportInitialize)SideTrip).EndInit();
		((Control)PnlBotam).ResumeLayout(false);
		((Control)PnlBotam).PerformLayout();
		((Control)PanelImage).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void myTimer_Tick(object sender, EventArgs e)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		if (!CheckForInternetConnection())
		{
			return;
		}
		try
		{
			if (!Module_Schm.bgWorker.IsBusy)
			{
				Module_Schm.bgWorker.RunWorkerAsync();
			}
			else
			{
				Debug.WriteLine("bgWorker is already running, skipping this tick...");
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("Timer error: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void PanalImage_Hide()
	{
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 1)
		{
			((Control)PanelImage).Visible = true;
		}
		else
		{
			((Control)PanelImage).Visible = false;
		}
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 2)
		{
			DC_Main.TotOpenForm = 0;
			((Control)SideTrip).Focus();
		}
	}

	private void AllBtn()
	{
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		PanalImage_Hide();
		if (Operators.CompareString(MsSideBtn, "", false) != 0)
		{
			DC_Main.MsUserRightForm = MsSideBtn;
			if ((Operators.CompareString(DC_Main.MCo_User, "ABC", false) == 0) & (Operators.CompareString(DC_Main.MsUserRightForm, "User Create", false) == 0))
			{
				DC_Main.RsQry = "Select * From USER_SET WHERE USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + MsSideBtn + "' AND FRM_VIEW = 'Y'";
			}
			else
			{
				DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + MsSideBtn + "' AND FRM_VIEW = 'Y'";
			}
			RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			if (RsRight.Rows.Count == 0)
			{
				DC_Main.MsUserRightForm = "";
				Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
				((Control)PanelImage).Visible = true;
				return;
			}
		}
		switch (DC_Main.MsMainBtn)
		{
		case "Company":
			Company_Form();
			break;
		case "Master":
			Master_Form();
			break;
		case "Transaction":
			Transaction_Form();
			break;
		case "ExtraTran":
			ExtraTran_Form();
			break;
		case "Other":
			Other_Form();
			break;
		case "Report":
			Report_Form();
			break;
		case "Karigar":
			Karigar_Form();
			break;
		case "Scheme":
			Scheme_Form();
			break;
		case "Dhiran":
			Dhiran_Form();
			break;
		case "Jadtar":
			Jadtar_Form();
			break;
		case "Mfg":
			Mfg_Form();
			break;
		case "Crm":
			Crm_Form();
			break;
		}
	}

	private void Analysis_Form()
	{
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 1)
		{
			((Control)PanelImage).Visible = true;
		}
		else
		{
			((Control)PanelImage).Visible = false;
		}
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 2)
		{
			DC_Main.TotOpenForm = 0;
		}
		DC_Main.MsUserRightForm = MsSideBtn;
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + MsSideBtn + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)PanelImage).Visible = true;
			return;
		}
		checked
		{
			switch (MsSideBtn)
			{
			case "Last Visit":
			{
				RP_CUST rP_CUST = new RP_CUST();
				((Form)rP_CUST).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((XtraForm)rP_CUST).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_CUST).Show();
				((Control)rP_CUST).Focus();
				break;
			}
			case "Stock Ledger":
			{
				RP_INOUT rP_INOUT5 = new RP_INOUT();
				((Form)rP_INOUT5).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_INOUT5).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_INOUT5).Show();
				((Control)rP_INOUT5).Focus();
				break;
			}
			case "Order Zoom":
			{
				RP_ORDER rP_ORDER2 = new RP_ORDER();
				((Form)rP_ORDER2).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ORDER2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ORDER2).Show();
				((Control)rP_ORDER2).Focus();
				break;
			}
			case "Tag Detail":
			{
				RP_TAG rP_TAG = new RP_TAG();
				((Form)rP_TAG).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((XtraForm)rP_TAG).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_TAG).Show();
				((Control)rP_TAG).Focus();
				break;
			}
			case "Stock Move":
			{
				RP_STK_MOVE rP_STK_MOVE = new RP_STK_MOVE();
				((Form)rP_STK_MOVE).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_STK_MOVE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_STK_MOVE).Show();
				((Control)rP_STK_MOVE).Focus();
				break;
			}
			case "Delete Data":
			{
				RP_ORDER rP_ORDER = new RP_ORDER();
				((Form)rP_ORDER).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ORDER).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ORDER).Show();
				((Control)rP_ORDER).Focus();
				break;
			}
			case "Party InOut":
			{
				RP_INOUT rP_INOUT4 = new RP_INOUT();
				((Form)rP_INOUT4).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_INOUT4).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_INOUT4).Show();
				((Control)rP_INOUT4).Focus();
				break;
			}
			case "Item Balance":
			{
				RP_INOUT rP_INOUT3 = new RP_INOUT();
				((Form)rP_INOUT3).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_INOUT3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_INOUT3).Show();
				((Control)rP_INOUT3).Focus();
				break;
			}
			case "Day Work":
			{
				RP_DAY_WORK rP_DAY_WORK = new RP_DAY_WORK();
				((Form)rP_DAY_WORK).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_DAY_WORK).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_DAY_WORK).Show();
				((Control)rP_DAY_WORK).Focus();
				break;
			}
			case "Bill Os Day":
			{
				RP_INOUT rP_INOUT2 = new RP_INOUT();
				((Form)rP_INOUT2).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_INOUT2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_INOUT2).Show();
				((Control)rP_INOUT2).Focus();
				break;
			}
			case "Bill Interest":
			{
				RP_INOUT rP_INOUT = new RP_INOUT();
				((Form)rP_INOUT).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_INOUT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_INOUT).Show();
				((Control)rP_INOUT).Focus();
				break;
			}
			}
		}
	}

	private void More_Form()
	{
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 1)
		{
			((Control)PanelImage).Visible = true;
		}
		else
		{
			((Control)PanelImage).Visible = false;
		}
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 2)
		{
			DC_Main.TotOpenForm = 0;
		}
		DC_Main.MsUserRightForm = MsSideBtn;
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + MsSideBtn + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)PanelImage).Visible = true;
			return;
		}
		checked
		{
			switch (MsSideBtn)
			{
			case "Order Track":
			{
				RP_ORD_TRACK rP_ORD_TRACK = new RP_ORD_TRACK();
				((Form)rP_ORD_TRACK).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ORD_TRACK).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ORD_TRACK).Show();
				((Control)rP_ORD_TRACK).Focus();
				break;
			}
			case "Graph Report":
			{
				RP_GRAPH rP_GRAPH = new RP_GRAPH();
				((Form)rP_GRAPH).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_GRAPH).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_GRAPH).Show();
				((Control)rP_GRAPH).Focus();
				break;
			}
			case "ItStk Level":
			{
				RP_STK_LEVEL rP_STK_LEVEL = new RP_STK_LEVEL();
				((Form)rP_STK_LEVEL).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_STK_LEVEL).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_STK_LEVEL).Show();
				((Control)rP_STK_LEVEL).Focus();
				break;
			}
			case "Bill Wise Profit":
			{
				RP_BILL_PROFIT rP_BILL_PROFIT = new RP_BILL_PROFIT();
				((Form)rP_BILL_PROFIT).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_BILL_PROFIT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_BILL_PROFIT).Show();
				((Control)rP_BILL_PROFIT).Focus();
				break;
			}
			case "User Report":
			{
				RP_USER rP_USER2 = new RP_USER();
				((Form)rP_USER2).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_USER2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_USER2).Show();
				((Control)rP_USER2).Focus();
				break;
			}
			case "Deisgn Move":
			{
				RP_STK_MOVE rP_STK_MOVE = new RP_STK_MOVE();
				((Form)rP_STK_MOVE).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_STK_MOVE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_STK_MOVE).Show();
				((Control)rP_STK_MOVE).Focus();
				break;
			}
			case "Point Report":
			{
				RP_ORDER rP_ORDER2 = new RP_ORDER();
				((Form)rP_ORDER2).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ORDER2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ORDER2).Show();
				((Control)rP_ORDER2).Focus();
				break;
			}
			case "Movement":
			{
				RP_MOVEMENT rP_MOVEMENT = new RP_MOVEMENT();
				((Form)rP_MOVEMENT).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_MOVEMENT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_MOVEMENT).Show();
				((Control)rP_MOVEMENT).Focus();
				break;
			}
			case "Entry Check":
			{
				RP_USER rP_USER = new RP_USER();
				((Form)rP_USER).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_USER).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_USER).Show();
				((Control)rP_USER).Focus();
				break;
			}
			case "Lot Report":
			{
				RP_ORDER rP_ORDER = new RP_ORDER();
				((Form)rP_ORDER).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ORDER).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ORDER).Show();
				((Control)rP_ORDER).Focus();
				break;
			}
			case "Emp Sale":
			{
				RP_EMP rP_EMP = new RP_EMP();
				((Form)rP_EMP).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_EMP).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_EMP).Show();
				((Control)rP_EMP).Focus();
				break;
			}
			case "Oth Itm Rpt":
			{
				RP_OTH_DETL rP_OTH_DETL = new RP_OTH_DETL();
				((Form)rP_OTH_DETL).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_OTH_DETL).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_OTH_DETL).Show();
				((Control)rP_OTH_DETL).Focus();
				break;
			}
			}
		}
	}

	private void Company_Form()
	{
		//IL_0746: Unknown result type (might be due to invalid IL or missing references)
		//IL_072f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0609: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			switch (MsSideBtn)
			{
			case "Company":
			{
				MS_COMPANY mS_COMPANY = new MS_COMPANY();
				((Form)mS_COMPANY).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_COMPANY).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_COMPANY).Show();
				((Control)mS_COMPANY).Focus();
				break;
			}
			case "Year Create":
			{
				MS_YEAR mS_YEAR = new MS_YEAR();
				((Form)mS_YEAR).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_YEAR).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_YEAR).Show();
				((Control)mS_YEAR).Focus();
				break;
			}
			case "Balance TrFr":
			{
				BtmSchm btmSchm = new BtmSchm();
				((Form)btmSchm).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)btmSchm).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)btmSchm).Show();
				((Control)btmSchm).Focus();
				break;
			}
			case "Books":
			{
				MS_BOOK mS_BOOK = new MS_BOOK();
				((Form)mS_BOOK).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_BOOK).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_BOOK).Show();
				((Control)mS_BOOK).Focus();
				break;
			}
			case "User Create":
			{
				MS_USER mS_USER = new MS_USER();
				((Form)mS_USER).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_USER).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_USER).Show();
				((Control)mS_USER).Focus();
				break;
			}
			case "Data Refresh":
			{
				MS_UPDATE mS_UPDATE = new MS_UPDATE();
				((Form)mS_UPDATE).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_UPDATE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_UPDATE).Show();
				((Control)mS_UPDATE).Focus();
				break;
			}
			case "Data Backup":
			{
				UT_BKP uT_BKP = new UT_BKP();
				((Form)uT_BKP).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)uT_BKP).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)uT_BKP).Show();
				((Control)uT_BKP).Focus();
				break;
			}
			case "Account Group":
			{
				MS_AC_GROUP mS_AC_GROUP = new MS_AC_GROUP();
				((Form)mS_AC_GROUP).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_AC_GROUP).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_AC_GROUP).Show();
				((Control)mS_AC_GROUP).Focus();
				break;
			}
			case "Trade Master":
			{
				MS_TRADE mS_TRADE = new MS_TRADE();
				((Form)mS_TRADE).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_TRADE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_TRADE).Show();
				((Control)mS_TRADE).Focus();
				break;
			}
			case "Setting":
			{
				UT_SETTING uT_SETTING = new UT_SETTING();
				((Form)uT_SETTING).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)uT_SETTING).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)uT_SETTING).Show();
				((Control)uT_SETTING).Focus();
				break;
			}
			case "Setting Main":
			{
				UT_SETTING_MAIN uT_SETTING_MAIN = new UT_SETTING_MAIN();
				((Form)uT_SETTING_MAIN).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)uT_SETTING_MAIN).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)uT_SETTING_MAIN).Show();
				((Control)uT_SETTING_MAIN).Focus();
				break;
			}
			case "Admin Setting":
			{
				if (Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0)
				{
					Interaction.MsgBox((object)"User Cant Open This Form...", (MsgBoxStyle)0, (object)null);
					break;
				}
				UT_SET_ADMIN uT_SET_ADMIN = new UT_SET_ADMIN();
				((Form)uT_SET_ADMIN).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)uT_SET_ADMIN).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)uT_SET_ADMIN).Show();
				((Control)uT_SET_ADMIN).Focus();
				break;
			}
			case "Menu Set":
			{
				MS_WINDOW_SET mS_WINDOW_SET = new MS_WINDOW_SET();
				((Form)mS_WINDOW_SET).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_WINDOW_SET).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_WINDOW_SET).Show();
				((Control)mS_WINDOW_SET).Focus();
				break;
			}
			case "Location":
			{
				MS_LOCT mS_LOCT = new MS_LOCT();
				((Form)mS_LOCT).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_LOCT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_LOCT).Show();
				((Control)mS_LOCT).Focus();
				break;
			}
			case "Year Select":
				if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count > 2)
				{
					Interaction.MsgBox((object)"Please First Close All Open Form And Try...", (MsgBoxStyle)0, (object)null);
					break;
				}
				((Form)MyProject.Forms.MS_OPNCOMP).ShowDialog();
				((Control)MyProject.Forms.MS_OPNCOMP).Focus();
				if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)
				{
					((Control)PanelImage).Visible = true;
				}
				else
				{
					((Control)PanelImage).Visible = false;
				}
				MainTripButton_Color();
				((ToolStripItem)BtnTran).BackColor = Color.BlanchedAlmond;
				((ToolStripItem)BtnTran).ForeColor = Color.DarkRed;
				((AccordionControlElementBase)SLMain2).Visible = false;
				RptAnalysis = false;
				DC_Main.MsMainBtn = "Transaction";
				Side_Menu_Fill();
				break;
			}
		}
	}

	private void Master_Form()
	{
		checked
		{
			switch (MsSideBtn)
			{
			case "Party":
			{
				MS_ACCT mS_ACCT = new MS_ACCT();
				((Form)mS_ACCT).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_ACCT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_ACCT).Show();
				((Control)mS_ACCT).Focus();
				break;
			}
			case "Address":
			{
				MS_ADD_MAST mS_ADD_MAST = new MS_ADD_MAST();
				((Form)mS_ADD_MAST).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_ADD_MAST).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_ADD_MAST).Show();
				((Control)mS_ADD_MAST).Focus();
				break;
			}
			case "Product":
			{
				MS_PRODUCT mS_PRODUCT2 = new MS_PRODUCT();
				((Form)mS_PRODUCT2).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_PRODUCT2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_PRODUCT2).Show();
				((Control)mS_PRODUCT2).Focus();
				break;
			}
			case "Group":
			{
				MS_GROUP mS_GROUP = new MS_GROUP();
				((Form)mS_GROUP).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_GROUP).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_GROUP).Show();
				((Control)mS_GROUP).Focus();
				break;
			}
			case "AutoItem":
			{
				MS_AUTO_ITEM mS_AUTO_ITEM4 = new MS_AUTO_ITEM();
				((Form)mS_AUTO_ITEM4).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_AUTO_ITEM4).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_AUTO_ITEM4).Show();
				((Control)mS_AUTO_ITEM4).Focus();
				break;
			}
			case "Item":
			{
				MS_ITEM mS_ITEM = new MS_ITEM();
				((Form)mS_ITEM).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_ITEM).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_ITEM).Show();
				((Control)mS_ITEM).Focus();
				break;
			}
			case "Employee":
			{
				MS_EMP mS_EMP = new MS_EMP();
				((Form)mS_EMP).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_EMP).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_EMP).Show();
				((Control)mS_EMP).Focus();
				break;
			}
			case "Tax":
			{
				MS_TAX mS_TAX = new MS_TAX();
				((Form)mS_TAX).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_TAX).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_TAX).Show();
				((Control)mS_TAX).Focus();
				break;
			}
			case "Party Opening":
			{
				TR_AC_OPBL tR_AC_OPBL = new TR_AC_OPBL();
				((Form)tR_AC_OPBL).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)tR_AC_OPBL).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_AC_OPBL).Show();
				((Control)tR_AC_OPBL).Focus();
				break;
			}
			case "Item Opening":
			{
				TR_ITM_OPBL tR_ITM_OPBL = new TR_ITM_OPBL();
				((Form)tR_ITM_OPBL).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)tR_ITM_OPBL).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_ITM_OPBL).Show();
				((Control)tR_ITM_OPBL).Focus();
				break;
			}
			case "Tag Opening":
				DC_Main.CurBookHelp("OPSTK");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					Form tR_TAG_OPBL = (Form)(object)MyProject.Forms.TR_TAG_OPBL;
					tR_TAG_OPBL.MdiParent = (Form)(object)this;
					tR_TAG_OPBL.Text = MsSideBtn;
					((Control)tR_TAG_OPBL).Show();
					((Control)tR_TAG_OPBL).Focus();
				}
				break;
			case "Lot Opening":
				DC_Main.CurBookHelp("ITM LOT");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					Form tR_ITM_LOT = (Form)(object)MyProject.Forms.TR_ITM_LOT;
					tR_ITM_LOT.MdiParent = (Form)(object)this;
					tR_ITM_LOT.Text = MsSideBtn;
					((Control)tR_ITM_LOT).Show();
					((Control)tR_ITM_LOT).Focus();
				}
				break;
			case "Design Book":
			{
				Form mS_DESIGN_BOOK = (Form)(object)MyProject.Forms.MS_DESIGN_BOOK;
				mS_DESIGN_BOOK.MdiParent = (Form)(object)this;
				mS_DESIGN_BOOK.Text = MsSideBtn;
				((Control)mS_DESIGN_BOOK).Show();
				((Control)mS_DESIGN_BOOK).Focus();
				break;
			}
			case "Counter":
			{
				MS_PRODUCT mS_PRODUCT = new MS_PRODUCT();
				((Form)mS_PRODUCT).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_PRODUCT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_PRODUCT).Show();
				((Control)mS_PRODUCT).Focus();
				break;
			}
			case "Labour":
			{
				MS_AUTO_ITEM mS_AUTO_ITEM3 = new MS_AUTO_ITEM();
				((Form)mS_AUTO_ITEM3).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_AUTO_ITEM3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_AUTO_ITEM3).Show();
				((Control)mS_AUTO_ITEM3).Focus();
				break;
			}
			case "Item Touch":
			{
				MS_AUTO_ITEM mS_AUTO_ITEM2 = new MS_AUTO_ITEM();
				((Form)mS_AUTO_ITEM2).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_AUTO_ITEM2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_AUTO_ITEM2).Show();
				((Control)mS_AUTO_ITEM2).Focus();
				break;
			}
			case "ItStk Limit":
			{
				MS_STK_LIMIT mS_STK_LIMIT2 = new MS_STK_LIMIT();
				((Form)mS_STK_LIMIT2).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_STK_LIMIT2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_STK_LIMIT2).Show();
				((Control)mS_STK_LIMIT2).Focus();
				break;
			}
			case "Point Mast":
			{
				MS_POINT mS_POINT = new MS_POINT();
				((Form)mS_POINT).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_POINT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_POINT).Show();
				((Control)mS_POINT).Focus();
				break;
			}
			case "Diamond":
			{
				MS_DM mS_DM = new MS_DM();
				((Form)mS_DM).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_DM).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_DM).Show();
				((Control)mS_DM).Focus();
				break;
			}
			case "Labour Type":
			{
				MS_LBR_TYPE mS_LBR_TYPE = new MS_LBR_TYPE();
				((Form)mS_LBR_TYPE).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_LBR_TYPE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_LBR_TYPE).Show();
				((Control)mS_LBR_TYPE).Focus();
				break;
			}
			case "Labour Disc":
			{
				MS_AUTO_ITEM mS_AUTO_ITEM = new MS_AUTO_ITEM();
				((Form)mS_AUTO_ITEM).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_AUTO_ITEM).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_AUTO_ITEM).Show();
				((Control)mS_AUTO_ITEM).Focus();
				break;
			}
			case "Design":
			{
				MS_STYLE mS_STYLE3 = new MS_STYLE();
				((Form)mS_STYLE3).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_STYLE3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_STYLE3).Show();
				((Control)mS_STYLE3).Focus();
				break;
			}
			case "Style":
			{
				MS_STYLE mS_STYLE2 = new MS_STYLE();
				((Form)mS_STYLE2).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_STYLE2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_STYLE2).Show();
				((Control)mS_STYLE2).Focus();
				break;
			}
			case "Item City":
			{
				MS_STYLE mS_STYLE = new MS_STYLE();
				((Form)mS_STYLE).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_STYLE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_STYLE).Show();
				((Control)mS_STYLE).Focus();
				break;
			}
			case "Dm Size":
			{
				MS_STK_LIMIT mS_STK_LIMIT = new MS_STK_LIMIT();
				((Form)mS_STK_LIMIT).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_STK_LIMIT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_STK_LIMIT).Show();
				((Control)mS_STK_LIMIT).Focus();
				break;
			}
			}
		}
	}

	private void Transaction_Form()
	{
		//IL_0f35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f3c: Expected O, but got Unknown
		//IL_0e6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e75: Expected O, but got Unknown
		checked
		{
			switch (MsSideBtn)
			{
			case "Purchase":
				if (Operators.CompareString(DC_Main.MsPurcWithHmTax, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("PURCHASE");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_PURC_HM tR_PURC_HM = new TR_PURC_HM();
						((Form)tR_PURC_HM).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_PURC_HM).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_PURC_HM).Show();
						((Control)tR_PURC_HM).Focus();
					}
				}
				else
				{
					DC_Main.CurBookHelp("PURCHASE");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_PURC tR_PURC2 = new TR_PURC();
						((Form)tR_PURC2).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_PURC2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_PURC2).Show();
						((Control)tR_PURC2).Focus();
					}
				}
				break;
			case "Purchase Rtn":
				if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
				{
					DC_Main.CurBookHelp("PURC RETURN");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						Form tR_SALE_RTN_UAE2 = (Form)(object)MyProject.Forms.TR_SALE_RTN_UAE;
						tR_SALE_RTN_UAE2.MdiParent = (Form)(object)this;
						tR_SALE_RTN_UAE2.Text = MsSideBtn;
						((Control)tR_SALE_RTN_UAE2).Show();
						((Control)tR_SALE_RTN_UAE2).Focus();
					}
					break;
				}
				DC_Main.CurBookHelp("PURC RETURN");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_KR_ISU tR_KR_ISU = new TR_KR_ISU();
					((Form)tR_KR_ISU).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_KR_ISU).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_KR_ISU).Show();
					((Control)tR_KR_ISU).Focus();
				}
				break;
			case "Sales":
				DC_Main.CurBookHelp("SALES");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					if (Operators.CompareString(DC_Main.MsSalesWithHmTax, "Y", false) == 0)
					{
						TR_SALE_HM tR_SALE_HM = new TR_SALE_HM();
						((Form)tR_SALE_HM).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_SALE_HM).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_SALE_HM).Show();
						((Control)tR_SALE_HM).Focus();
					}
					else
					{
						TR_SALE tR_SALE = new TR_SALE();
						((Form)tR_SALE).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_SALE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_SALE).Show();
						((Control)tR_SALE).Focus();
					}
				}
				break;
			case "E Invoice":
				DC_Main.CurBookHelp("E INVOICE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_SL_EBILL tR_SL_EBILL2 = new TR_SL_EBILL();
					((Form)tR_SL_EBILL2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_SL_EBILL2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_SL_EBILL2).Show();
					((Control)tR_SL_EBILL2).Focus();
				}
				break;
			case "E CrntNote":
				DC_Main.CurBookHelp("E CRNT");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_SL_EBILL tR_SL_EBILL = new TR_SL_EBILL();
					((Form)tR_SL_EBILL).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_SL_EBILL).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_SL_EBILL).Show();
					((Control)tR_SL_EBILL).Focus();
				}
				break;
			case "Sales Return":
				if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
				{
					DC_Main.CurBookHelp("SALES RETURNE");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						Form tR_SALE_RTN_UAE = (Form)(object)MyProject.Forms.TR_SALE_RTN_UAE;
						tR_SALE_RTN_UAE.MdiParent = (Form)(object)this;
						tR_SALE_RTN_UAE.Text = MsSideBtn;
						((Control)tR_SALE_RTN_UAE).Show();
						((Control)tR_SALE_RTN_UAE).Focus();
					}
				}
				else
				{
					DC_Main.CurBookHelp("SALES RETURNE");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						Form tR_SALE_RTN = (Form)(object)MyProject.Forms.TR_SALE_RTN;
						tR_SALE_RTN.MdiParent = (Form)(object)this;
						tR_SALE_RTN.Text = MsSideBtn;
						((Control)tR_SALE_RTN).Show();
						((Control)tR_SALE_RTN).Focus();
					}
				}
				break;
			case "Sales Order":
				DC_Main.CurBookHelp("SALES ORDER");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_SALE_ORD tR_SALE_ORD = new TR_SALE_ORD();
					((Form)tR_SALE_ORD).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_SALE_ORD).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_SALE_ORD).Show();
					((Control)tR_SALE_ORD).Focus();
				}
				break;
			case "B2B Sales":
				DC_Main.CurBookHelp("B2B SALES");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_PR_SL_UAE tR_PR_SL_UAE2 = new TR_PR_SL_UAE();
					((Form)tR_PR_SL_UAE2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_PR_SL_UAE2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_PR_SL_UAE2).Show();
					((Control)tR_PR_SL_UAE2).Focus();
				}
				break;
			case "B2B Purc":
				DC_Main.CurBookHelp("B2B PURC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_PR_SL_UAE tR_PR_SL_UAE = new TR_PR_SL_UAE();
					((Form)tR_PR_SL_UAE).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_PR_SL_UAE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_PR_SL_UAE).Show();
					((Control)tR_PR_SL_UAE).Focus();
				}
				break;
			case "Hedging Fix":
				DC_Main.CurBookHelp("HEDGING FIX");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_PR_SL_HEDG tR_PR_SL_HEDG = new TR_PR_SL_HEDG();
					((Form)tR_PR_SL_HEDG).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_PR_SL_HEDG).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_PR_SL_HEDG).Show();
					((Control)tR_PR_SL_HEDG).Focus();
				}
				break;
			case "Wh Sales":
				DC_Main.CurBookHelp("WH SALES");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_WH_SALE tR_WH_SALE2 = new TR_WH_SALE();
					((Form)tR_WH_SALE2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_WH_SALE2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_WH_SALE2).Show();
					((Control)tR_WH_SALE2).Focus();
				}
				break;
			case "Cash Received":
				DC_Main.CurBookHelp("CASH REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_CASH tR_CASH3 = new TR_CASH();
					((Form)tR_CASH3).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_CASH3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_CASH3).Show();
					((Control)tR_CASH3).Focus();
				}
				break;
			case "Cash Payment":
				DC_Main.CurBookHelp("CASH PAY");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_CASH tR_CASH2 = new TR_CASH();
					((Form)tR_CASH2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_CASH2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_CASH2).Show();
					((Control)tR_CASH2).Focus();
				}
				break;
			case "Bank Received":
				DC_Main.CurBookHelp("BANK REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_CASH tR_CASH = new TR_CASH();
					((Form)tR_CASH).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_CASH).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_CASH).Show();
					((Control)tR_CASH).Focus();
				}
				break;
			case "Bank Payment":
				DC_Main.CurBookHelp("BANK PAY");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_CASH tR_CASH4 = new TR_CASH();
					((Form)tR_CASH4).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_CASH4).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_CASH4).Show();
					((Control)tR_CASH4).Focus();
				}
				break;
			case "Contra Entry":
				DC_Main.CurBookHelp("CONTRA");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_CONTRA tR_CONTRA = new TR_CONTRA();
					((Form)tR_CONTRA).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_CONTRA).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_CONTRA).Show();
					((Control)tR_CONTRA).Focus();
				}
				break;
			case "Rate Cut":
				DC_Main.CurBookHelp("RATE CUT");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_WH_SALE tR_WH_SALE3 = new TR_WH_SALE();
					((Form)tR_WH_SALE3).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_WH_SALE3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_WH_SALE3).Show();
					((Control)tR_WH_SALE3).Focus();
				}
				break;
			case "Stock Out":
			{
				TR_INOUT tR_INOUT3 = null;
				foreach (Form item in (ReadOnlyCollectionBase)(object)Application.OpenForms)
				{
					Form val2 = item;
					if (val2 is TR_INOUT)
					{
						tR_INOUT3 = (TR_INOUT)(object)val2;
						return;
					}
				}
				DC_Main.CurBookHelp("OUTWORD");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					Form tR_INOUT4 = (Form)(object)MyProject.Forms.TR_INOUT;
					tR_INOUT4.MdiParent = (Form)(object)this;
					tR_INOUT4.Text = MsSideBtn;
					((Control)tR_INOUT4).Show();
					((Control)tR_INOUT4).Focus();
				}
				break;
			}
			case "Stock In":
			{
				TR_INOUT tR_INOUT = null;
				foreach (Form item2 in (ReadOnlyCollectionBase)(object)Application.OpenForms)
				{
					Form val = item2;
					if (val is TR_INOUT)
					{
						tR_INOUT = (TR_INOUT)(object)val;
						return;
					}
				}
				DC_Main.CurBookHelp("INWORD");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					Form tR_INOUT2 = (Form)(object)MyProject.Forms.TR_INOUT;
					tR_INOUT2.MdiParent = (Form)(object)this;
					tR_INOUT2.Text = MsSideBtn;
					((Control)tR_INOUT2).Show();
					((Control)tR_INOUT2).Focus();
				}
				break;
			}
			case "Sale Booking":
				DC_Main.CurBookHelp("BUL SALE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_BUL_BOOKING tR_BUL_BOOKING3 = new TR_BUL_BOOKING();
					((Form)tR_BUL_BOOKING3).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_BUL_BOOKING3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_BUL_BOOKING3).Show();
					((Control)tR_BUL_BOOKING3).Focus();
				}
				break;
			case "Purc Booking":
				DC_Main.CurBookHelp("BUL PURC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_BUL_BOOKING tR_BUL_BOOKING2 = new TR_BUL_BOOKING();
					((Form)tR_BUL_BOOKING2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_BUL_BOOKING2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_BUL_BOOKING2).Show();
					((Control)tR_BUL_BOOKING2).Focus();
				}
				break;
			case "Bul LcBook":
				DC_Main.CurBookHelp("BUL LC SALE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_BUL_BOOKING tR_BUL_BOOKING = new TR_BUL_BOOKING();
					((Form)tR_BUL_BOOKING).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_BUL_BOOKING).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_BUL_BOOKING).Show();
					((Control)tR_BUL_BOOKING).Focus();
				}
				break;
			case "Bul Sales":
				DC_Main.CurBookHelp("BUL WH SALE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_BUL_SALE tR_BUL_SALE = new TR_BUL_SALE();
					((Form)tR_BUL_SALE).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_BUL_SALE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_BUL_SALE).Show();
					((Control)tR_BUL_SALE).Focus();
				}
				break;
			case "Sl Quotation":
				DC_Main.CurBookHelp("SL QUOT");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_SALE tR_SALE2 = new TR_SALE();
					((Form)tR_SALE2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_SALE2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_SALE2).Show();
					((Control)tR_SALE2).Focus();
				}
				break;
			case "Pr Quotation":
				DC_Main.CurBookHelp("PR QUOT");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_PURC tR_PURC = new TR_PURC();
					((Form)tR_PURC).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_PURC).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_PURC).Show();
					((Control)tR_PURC).Focus();
				}
				break;
			case "Wh Quotation":
				DC_Main.CurBookHelp("Wh QUOT");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_WH_SALE tR_WH_SALE = new TR_WH_SALE();
					((Form)tR_WH_SALE).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_WH_SALE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_WH_SALE).Show();
					((Control)tR_WH_SALE).Focus();
				}
				break;
			case "Wh Sl Return":
				DC_Main.CurBookHelp("WH RTN");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_WH_SALE_RTN tR_WH_SALE_RTN = new TR_WH_SALE_RTN();
					((Form)tR_WH_SALE_RTN).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_WH_SALE_RTN).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_WH_SALE_RTN).Show();
					((Control)tR_WH_SALE_RTN).Focus();
				}
				break;
			}
		}
	}

	private void ExtraTran_Form()
	{
		checked
		{
			switch (MsSideBtn)
			{
			case "Item Purc":
				DC_Main.CurBookHelp("ITEM PURC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_SL_PR_ITEM tR_SL_PR_ITEM = new TR_SL_PR_ITEM();
					((Form)tR_SL_PR_ITEM).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_SL_PR_ITEM).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_SL_PR_ITEM).Show();
					((Control)tR_SL_PR_ITEM).Focus();
				}
				break;
			case "Item Sales":
				DC_Main.CurBookHelp("ITEM SALES");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_SL_PR_ITEM tR_SL_PR_ITEM2 = new TR_SL_PR_ITEM();
					((Form)tR_SL_PR_ITEM2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_SL_PR_ITEM2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_SL_PR_ITEM2).Show();
					((Control)tR_SL_PR_ITEM2).Focus();
				}
				break;
			case "Approval Isu":
				DC_Main.CurBookHelp("APR ISU");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_APR_ISU tR_APR_ISU = new TR_APR_ISU();
					((Form)tR_APR_ISU).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_APR_ISU).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_APR_ISU).Show();
					((Control)tR_APR_ISU).Focus();
				}
				break;
			case "Approval Rtn":
				DC_Main.CurBookHelp("APR RTN");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_APR_ISU tR_APR_ISU3 = new TR_APR_ISU();
					((Form)tR_APR_ISU3).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_APR_ISU3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_APR_ISU3).Show();
					((Control)tR_APR_ISU3).Focus();
				}
				break;
			case "Labour Work":
				DC_Main.CurBookHelp("LABOUR WORK");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_SALE_LBR tR_SALE_LBR = new TR_SALE_LBR();
					((Form)tR_SALE_LBR).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_SALE_LBR).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_SALE_LBR).Show();
					((Control)tR_SALE_LBR).Focus();
				}
				break;
			case "Old Item Sales":
				DC_Main.CurBookHelp("OLD ITEM SALES");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_PURC tR_PURC = new TR_PURC();
					((Form)tR_PURC).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_PURC).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_PURC).Show();
					((Control)tR_PURC).Focus();
				}
				break;
			case "Bill Wise Rec":
				DC_Main.CurBookHelp("BILL REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_BILL_TO tR_BILL_TO = new TR_BILL_TO();
					((Form)tR_BILL_TO).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_BILL_TO).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_BILL_TO).Show();
					((Control)tR_BILL_TO).Focus();
				}
				break;
			case "Fine Jv Entry":
				DC_Main.CurBookHelp("FINE JV");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_CONTRA tR_CONTRA = new TR_CONTRA();
					((Form)tR_CONTRA).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_CONTRA).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_CONTRA).Show();
					((Control)tR_CONTRA).Focus();
				}
				break;
			case "Other Expenses":
				DC_Main.CurBookHelp("OTH EXP");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_OTH_PURC tR_OTH_PURC2 = new TR_OTH_PURC();
					((Form)tR_OTH_PURC2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_OTH_PURC2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_OTH_PURC2).Show();
					((Control)tR_OTH_PURC2).Focus();
				}
				break;
			case "Other Income":
				DC_Main.CurBookHelp("OTH INC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_OTH_PURC tR_OTH_PURC = new TR_OTH_PURC();
					((Form)tR_OTH_PURC).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_OTH_PURC).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_OTH_PURC).Show();
					((Control)tR_OTH_PURC).Focus();
				}
				break;
			case "Vp Parcel":
				DC_Main.CurBookHelp("VP PARCEL");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_VP tR_VP = new TR_VP();
					((Form)tR_VP).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_VP).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_VP).Show();
					((Control)tR_VP).Focus();
				}
				break;
			case "Vp Adjust":
				DC_Main.CurBookHelp("VP REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_VP_ADJ tR_VP_ADJ = new TR_VP_ADJ();
					((Form)tR_VP_ADJ).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_VP_ADJ).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_VP_ADJ).Show();
					((Control)tR_VP_ADJ).Focus();
				}
				break;
			case "Consi Rec":
				DC_Main.CurBookHelp("CON REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_APR_ISU tR_APR_ISU4 = new TR_APR_ISU();
					((Form)tR_APR_ISU4).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_APR_ISU4).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_APR_ISU4).Show();
					((Control)tR_APR_ISU4).Focus();
				}
				break;
			case "Consi Purc":
				DC_Main.CurBookHelp("CON PUR");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_PR_SL_UAE tR_PR_SL_UAE = new TR_PR_SL_UAE();
					((Form)tR_PR_SL_UAE).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_PR_SL_UAE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_PR_SL_UAE).Show();
					((Control)tR_PR_SL_UAE).Focus();
				}
				break;
			case "Consi Isu":
				DC_Main.CurBookHelp("CON ISU");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_APR_ISU tR_APR_ISU2 = new TR_APR_ISU();
					((Form)tR_APR_ISU2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_APR_ISU2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_APR_ISU2).Show();
					((Control)tR_APR_ISU2).Focus();
				}
				break;
			case "Card Rec":
				DC_Main.CurBookHelp("CARD ADJUST");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_CARD_REC tR_CARD_REC = new TR_CARD_REC();
					((Form)tR_CARD_REC).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_CARD_REC).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_CARD_REC).Show();
					((Control)tR_CARD_REC).Focus();
				}
				break;
			case "Amt Out":
				DC_Main.CurBookHelp("AMT OUT");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_LOCT_AMT tR_LOCT_AMT2 = new TR_LOCT_AMT();
					((Form)tR_LOCT_AMT2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_LOCT_AMT2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_LOCT_AMT2).Show();
					((Control)tR_LOCT_AMT2).Focus();
				}
				break;
			case "Amt In":
				DC_Main.CurBookHelp("AMT IN");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_LOCT_AMT tR_LOCT_AMT = new TR_LOCT_AMT();
					((Form)tR_LOCT_AMT).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_LOCT_AMT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_LOCT_AMT).Show();
					((Control)tR_LOCT_AMT).Focus();
				}
				break;
			case "Fine Purc":
				DC_Main.CurBookHelp("FINE PURC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_FINE_SL_PR tR_FINE_SL_PR2 = new TR_FINE_SL_PR();
					((Form)tR_FINE_SL_PR2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_FINE_SL_PR2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_FINE_SL_PR2).Show();
					((Control)tR_FINE_SL_PR2).Focus();
				}
				break;
			case "Fine Sales":
				DC_Main.CurBookHelp("FINE SALE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_FINE_SL_PR tR_FINE_SL_PR = new TR_FINE_SL_PR();
					((Form)tR_FINE_SL_PR).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_FINE_SL_PR).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_FINE_SL_PR).Show();
					((Control)tR_FINE_SL_PR).Focus();
				}
				break;
			case "Employee Jv":
				DC_Main.CurBookHelp("EMP JV");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_EMP_JV tR_EMP_JV = new TR_EMP_JV();
					((Form)tR_EMP_JV).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_EMP_JV).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_EMP_JV).Show();
					((Control)tR_EMP_JV).Focus();
				}
				break;
			case "Service Comm":
				DC_Main.CurBookHelp("OTH COMM");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_OTH_COMM tR_OTH_COMM = new TR_OTH_COMM();
					((Form)tR_OTH_COMM).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_OTH_COMM).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_OTH_COMM).Show();
					((Control)tR_OTH_COMM).Focus();
				}
				break;
			case "Tag Wise Purc":
				DC_Main.CurBookHelp("TAG PURCHASE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_PURC_HM tR_PURC_HM = new TR_PURC_HM();
					((Form)tR_PURC_HM).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_PURC_HM).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_PURC_HM).Show();
					((Control)tR_PURC_HM).Focus();
				}
				break;
			}
		}
	}

	private void Other_Form()
	{
		//IL_0aa8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aae: Invalid comparison between Unknown and I4
		checked
		{
			switch (MsSideBtn)
			{
			case "Daily Rate":
			{
				MS_RATE mS_RATE = new MS_RATE();
				((Form)mS_RATE).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_RATE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_RATE).Show();
				((Control)mS_RATE).Focus();
				break;
			}
			case "Only Tag Entry":
				DC_Main.CurBookHelp("TAG GEN");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					Form tR_TAG_OPBL = (Form)(object)MyProject.Forms.TR_TAG_OPBL;
					tR_TAG_OPBL.MdiParent = (Form)(object)this;
					tR_TAG_OPBL.Text = MsSideBtn;
					((Control)tR_TAG_OPBL).Show();
					((Control)tR_TAG_OPBL).Focus();
				}
				break;
			case "Tag Cancel":
				DC_Main.CurBookHelp("TAG CANCEL");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					Form tR_TAG_CAN4 = (Form)(object)MyProject.Forms.TR_TAG_CAN;
					tR_TAG_CAN4.MdiParent = (Form)(object)this;
					tR_TAG_CAN4.Text = MsSideBtn;
					((Control)tR_TAG_CAN4).Show();
					((Control)tR_TAG_CAN4).Focus();
				}
				break;
			case "Tag Print":
			{
				UT_TAG_PRINT uT_TAG_PRINT = new UT_TAG_PRINT();
				((Form)uT_TAG_PRINT).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)uT_TAG_PRINT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)uT_TAG_PRINT).Show();
				((Control)uT_TAG_PRINT).Focus();
				break;
			}
			case "Data Import":
			{
				UT_IMPORT uT_IMPORT2 = new UT_IMPORT();
				((Form)uT_IMPORT2).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)uT_IMPORT2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)uT_IMPORT2).Show();
				((Control)uT_IMPORT2).Focus();
				break;
			}
			case "Stock Adjust":
				DC_Main.CurBookHelp("STOCK ADJUST");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_TAG_CAN tR_TAG_CAN = new TR_TAG_CAN();
					((Form)tR_TAG_CAN).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_TAG_CAN).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_TAG_CAN).Show();
					((Control)tR_TAG_CAN).Focus();
				}
				break;
			case "Order Cancel":
				DC_Main.CurBookHelp("ORDER CANCEL");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_SL_ORD_ADJ tR_SL_ORD_ADJ = new TR_SL_ORD_ADJ();
					((Form)tR_SL_ORD_ADJ).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_SL_ORD_ADJ).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_SL_ORD_ADJ).Show();
					((Control)tR_SL_ORD_ADJ).Focus();
				}
				break;
			case "Reminder Entry":
				DC_Main.CurBookHelp("REM ENTRY");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					UT_REMINDER uT_REMINDER = new UT_REMINDER();
					((Form)uT_REMINDER).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)uT_REMINDER).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)uT_REMINDER).Show();
					((Control)uT_REMINDER).Focus();
				}
				break;
			case "Physical Stock":
				DC_Main.CurBookHelp("PHY STOCK");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					Form tR_PHYSTK2 = (Form)(object)MyProject.Forms.TR_PHYSTK;
					tR_PHYSTK2.MdiParent = (Form)(object)this;
					tR_PHYSTK2.Text = MsSideBtn;
					((Control)tR_PHYSTK2).Show();
					((Control)tR_PHYSTK2).Focus();
				}
				break;
			case "Tag Transfer":
				DC_Main.CurBookHelp("TAG TRFR");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					Form tR_TAG_CAN3 = (Form)(object)MyProject.Forms.TR_TAG_CAN;
					tR_TAG_CAN3.MdiParent = (Form)(object)this;
					tR_TAG_CAN3.Text = MsSideBtn;
					((Control)tR_TAG_CAN3).Show();
					((Control)tR_TAG_CAN3).Focus();
				}
				break;
			case "Tag Adjust":
				DC_Main.CurBookHelp("TAG ADJ");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_TAG_CAN tR_TAG_CAN2 = new TR_TAG_CAN();
					((Form)tR_TAG_CAN2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_TAG_CAN2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_TAG_CAN2).Show();
					((Control)tR_TAG_CAN2).Focus();
				}
				break;
			case "Tag Split":
				DC_Main.CurBookHelp("TAG SPLIT");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					Form tR_TAG_SPLIT = (Form)(object)MyProject.Forms.TR_TAG_SPLIT;
					tR_TAG_SPLIT.MdiParent = (Form)(object)this;
					tR_TAG_SPLIT.Text = MsSideBtn;
					((Control)tR_TAG_SPLIT).Show();
					((Control)tR_TAG_SPLIT).Focus();
				}
				break;
			case "Tag Wt Change":
				DC_Main.CurBookHelp("TAG WT CHANGE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					Form tR_TAG_WT_DIFF = (Form)(object)MyProject.Forms.TR_TAG_WT_DIFF;
					tR_TAG_WT_DIFF.MdiParent = (Form)(object)this;
					tR_TAG_WT_DIFF.Text = MsSideBtn;
					((Control)tR_TAG_WT_DIFF).Show();
					((Control)tR_TAG_WT_DIFF).Focus();
				}
				break;
			case "Mrp Update":
				DC_Main.CurBookHelp("MRP UPDATE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					Form tR_PHYSTK4 = (Form)(object)MyProject.Forms.TR_PHYSTK;
					tR_PHYSTK4.MdiParent = (Form)(object)this;
					tR_PHYSTK4.Text = MsSideBtn;
					((Control)tR_PHYSTK4).Show();
					((Control)tR_PHYSTK4).Focus();
				}
				break;
			case "Ledger Adjust":
				DC_Main.CurBookHelp("LD ADJUST");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					Form tR_LEDR_ADJ = (Form)(object)MyProject.Forms.TR_LEDR_ADJ;
					tR_LEDR_ADJ.MdiParent = (Form)(object)this;
					tR_LEDR_ADJ.Text = MsSideBtn;
					((Control)tR_LEDR_ADJ).Show();
					((Control)tR_LEDR_ADJ).Focus();
				}
				break;
			case "E-Excel":
			{
				UT_E_INVOICE uT_E_INVOICE = new UT_E_INVOICE();
				((Form)uT_E_INVOICE).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)uT_E_INVOICE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)uT_E_INVOICE).Show();
				((Control)uT_E_INVOICE).Focus();
				break;
			}
			case "Stone/Dm-Cf":
				DC_Main.CurBookHelp("SF PRINT");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_PHYSTK tR_PHYSTK3 = new TR_PHYSTK();
					((Form)tR_PHYSTK3).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_PHYSTK3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_PHYSTK3).Show();
					((Control)tR_PHYSTK3).Focus();
				}
				break;
			case "Whatsapp":
				if (unchecked((int)((Form)MyProject.Forms.UT_WAPP_WITH_API).WindowState) == 0)
				{
					if (Operators.CompareString(DC_Main.MsWappApiActive, "Y", false) == 0)
					{
						Form uT_WAPP_WITH_API = (Form)(object)MyProject.Forms.UT_WAPP_WITH_API;
						uT_WAPP_WITH_API.MdiParent = (Form)(object)this;
						uT_WAPP_WITH_API.Text = MsSideBtn;
						((Control)uT_WAPP_WITH_API).Show();
						((Control)uT_WAPP_WITH_API).Focus();
					}
					else
					{
						Form uT_WHATSAPP = (Form)(object)MyProject.Forms.UT_WHATSAPP;
						uT_WHATSAPP.MdiParent = (Form)(object)this;
						uT_WHATSAPP.Text = MsSideBtn;
						((Control)uT_WHATSAPP).Show();
						((Control)uT_WHATSAPP).Focus();
					}
				}
				else if (Operators.CompareString(DC_Main.MsWappApiActive, "Y", false) == 0)
				{
					Form uT_WAPP_WITH_API2 = (Form)(object)MyProject.Forms.UT_WAPP_WITH_API;
					uT_WAPP_WITH_API2.MdiParent = (Form)(object)this;
					uT_WAPP_WITH_API2.Text = MsSideBtn;
					((Control)uT_WAPP_WITH_API2).Show();
					((Control)uT_WAPP_WITH_API2).Focus();
				}
				else
				{
					Form uT_WHATSAPP2 = (Form)(object)MyProject.Forms.UT_WHATSAPP;
					uT_WHATSAPP2.MdiParent = (Form)(object)this;
					uT_WHATSAPP2.Text = MsSideBtn;
					((Control)uT_WHATSAPP2).Show();
					((Control)uT_WHATSAPP2).Focus();
				}
				break;
			case "Sms":
			{
				UT_SMS uT_SMS = new UT_SMS();
				((Form)uT_SMS).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)uT_SMS).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)uT_SMS).Show();
				((Control)uT_SMS).Focus();
				break;
			}
			case "Labour Update":
			{
				MS_AUTO_ITEM mS_AUTO_ITEM = new MS_AUTO_ITEM();
				((Form)mS_AUTO_ITEM).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_AUTO_ITEM).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_AUTO_ITEM).Show();
				((Control)mS_AUTO_ITEM).Focus();
				break;
			}
			case "Counter Trfr":
				DC_Main.CurBookHelp("COUNTER TRFR");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_PHYSTK tR_PHYSTK = new TR_PHYSTK();
					((Form)tR_PHYSTK).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_PHYSTK).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_PHYSTK).Show();
					((Control)tR_PHYSTK).Focus();
				}
				break;
			case "Bank Reconcile":
			{
				UT_BANK uT_BANK = new UT_BANK();
				((Form)uT_BANK).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)uT_BANK).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)uT_BANK).Show();
				((Control)uT_BANK).Focus();
				break;
			}
			case "Vch ReNumber":
			{
				UT_VCH_RE_NUMBR uT_VCH_RE_NUMBR = new UT_VCH_RE_NUMBR();
				((Form)uT_VCH_RE_NUMBR).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)uT_VCH_RE_NUMBR).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)uT_VCH_RE_NUMBR).Show();
				((Control)uT_VCH_RE_NUMBR).Focus();
				break;
			}
			case "Estimate Reset":
			{
				UT_IMPORT uT_IMPORT = new UT_IMPORT();
				((Form)uT_IMPORT).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)uT_IMPORT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)uT_IMPORT).Show();
				((Control)uT_IMPORT).Focus();
				break;
			}
			case "Data Export":
			{
				UT_EXPORT uT_EXPORT = new UT_EXPORT();
				((Form)uT_EXPORT).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)uT_EXPORT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)uT_EXPORT).Show();
				((Control)uT_EXPORT).Focus();
				break;
			}
			}
		}
	}

	private void Report_Form()
	{
		checked
		{
			switch (MsSideBtn)
			{
			case "Ledger Report":
			{
				RP_LEDR rP_LEDR = new RP_LEDR();
				((Form)rP_LEDR).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_LEDR).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_LEDR).Show();
				((Control)rP_LEDR).Focus();
				break;
			}
			case "Stock Report":
			{
				RP_STOCK rP_STOCK = new RP_STOCK();
				((Form)rP_STOCK).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_STOCK).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_STOCK).Show();
				((Control)rP_STOCK).Focus();
				break;
			}
			case "Tag Stock":
			{
				RP_TAG rP_TAG = new RP_TAG();
				((Form)rP_TAG).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((XtraForm)rP_TAG).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_TAG).Show();
				((Control)rP_TAG).Focus();
				break;
			}
			case "Sales Report":
			{
				RP_ALL rP_ALL7 = new RP_ALL();
				((Form)rP_ALL7).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ALL7).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ALL7).Show();
				((Control)rP_ALL7).Focus();
				break;
			}
			case "Purchase Rpt":
			{
				RP_ALL rP_ALL6 = new RP_ALL();
				((Form)rP_ALL6).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ALL6).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ALL6).Show();
				((Control)rP_ALL6).Focus();
				break;
			}
			case "Approval Rpt":
			{
				RP_ALL rP_ALL5 = new RP_ALL();
				((Form)rP_ALL5).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ALL5).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ALL5).Show();
				((Control)rP_ALL5).Focus();
				break;
			}
			case "Order Report":
			{
				RP_ALL rP_ALL4 = new RP_ALL();
				((Form)rP_ALL4).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ALL4).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ALL4).Show();
				((Control)rP_ALL4).Focus();
				break;
			}
			case "Cash Bank":
			{
				RP_CASH_BANK rP_CASH_BANK = new RP_CASH_BANK();
				((Form)rP_CASH_BANK).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_CASH_BANK).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_CASH_BANK).Show();
				((Control)rP_CASH_BANK).Focus();
				break;
			}
			case "Gst Report":
			case "Tax Report":
				if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
				{
					RP_TAX rP_TAX = new RP_TAX();
					((Form)rP_TAX).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)rP_TAX).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)rP_TAX).Show();
					((Control)rP_TAX).Focus();
				}
				else
				{
					RP_GST rP_GST = new RP_GST();
					((Form)rP_GST).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)rP_GST).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)rP_GST).Show();
					((Control)rP_GST).Focus();
				}
				break;
			case "Party Os":
			{
				RP_OS rP_OS = new RP_OS();
				((Form)rP_OS).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_OS).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_OS).Show();
				((Control)rP_OS).Focus();
				break;
			}
			case "Final Reports":
			{
				RP_BALANCE rP_BALANCE = new RP_BALANCE();
				((Form)rP_BALANCE).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_BALANCE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_BALANCE).Show();
				((Control)rP_BALANCE).Focus();
				break;
			}
			case "Tag Estmate":
			{
				RP_TAG_ESTMATE rP_TAG_ESTMATE = new RP_TAG_ESTMATE();
				((Form)rP_TAG_ESTMATE).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((XtraForm)rP_TAG_ESTMATE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_TAG_ESTMATE).Show();
				((Control)rP_TAG_ESTMATE).Focus();
				break;
			}
			case "Tag Image":
			{
				RP_TAG_IMAGE rP_TAG_IMAGE = new RP_TAG_IMAGE();
				((Form)rP_TAG_IMAGE).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((XtraForm)rP_TAG_IMAGE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_TAG_IMAGE).Show();
				((Control)rP_TAG_IMAGE).Focus();
				break;
			}
			case "Consi Report":
			{
				RP_CONSI_APR rP_CONSI_APR = new RP_CONSI_APR();
				((Form)rP_CONSI_APR).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_CONSI_APR).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_CONSI_APR).Show();
				((Control)rP_CONSI_APR).Focus();
				break;
			}
			case "Trading Report":
			{
				RP_TRADING rP_TRADING = new RP_TRADING();
				((Form)rP_TRADING).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_TRADING).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_TRADING).Show();
				((Control)rP_TRADING).Focus();
				break;
			}
			case "HuId Report":
			{
				RP_HUID rP_HUID = new RP_HUID();
				((Form)rP_HUID).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((XtraForm)rP_HUID).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_HUID).Show();
				((Control)rP_HUID).Focus();
				break;
			}
			case "Bul Report":
			{
				RP_ALL rP_ALL3 = new RP_ALL();
				((Form)rP_ALL3).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ALL3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ALL3).Show();
				((Control)rP_ALL3).Focus();
				break;
			}
			case "Rojmel":
			{
				RP_ROJMEL rP_ROJMEL = new RP_ROJMEL();
				((Form)rP_ROJMEL).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ROJMEL).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ROJMEL).Show();
				((Control)rP_ROJMEL).Focus();
				break;
			}
			case "Stock With Fine":
			{
				RP_STOCK_FINE rP_STOCK_FINE = new RP_STOCK_FINE();
				((Form)rP_STOCK_FINE).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_STOCK_FINE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_STOCK_FINE).Show();
				((Control)rP_STOCK_FINE).Focus();
				break;
			}
			case "Sale Zoom":
			{
				RP_SLPR_ZOOM rP_SLPR_ZOOM3 = new RP_SLPR_ZOOM();
				((Form)rP_SLPR_ZOOM3).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_SLPR_ZOOM3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_SLPR_ZOOM3).Show();
				((Control)rP_SLPR_ZOOM3).Focus();
				break;
			}
			case "Purc Zoom":
			{
				RP_SLPR_ZOOM rP_SLPR_ZOOM2 = new RP_SLPR_ZOOM();
				((Form)rP_SLPR_ZOOM2).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_SLPR_ZOOM2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_SLPR_ZOOM2).Show();
				((Control)rP_SLPR_ZOOM2).Focus();
				break;
			}
			case "Old Stock":
			{
				RP_SLPR_ZOOM rP_SLPR_ZOOM = new RP_SLPR_ZOOM();
				((Form)rP_SLPR_ZOOM).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_SLPR_ZOOM).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_SLPR_ZOOM).Show();
				((Control)rP_SLPR_ZOOM).Focus();
				break;
			}
			case "Item InOut":
			{
				RP_ALL rP_ALL2 = new RP_ALL();
				((Form)rP_ALL2).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ALL2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ALL2).Show();
				((Control)rP_ALL2).Focus();
				break;
			}
			case "Reminder Rpt":
			{
				RP_REMINDER rP_REMINDER = new RP_REMINDER();
				((Form)rP_REMINDER).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_REMINDER).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_REMINDER).Show();
				((Control)rP_REMINDER).Focus();
				break;
			}
			case "Address Print":
			{
				RP_ADDRESS rP_ADDRESS = new RP_ADDRESS();
				((Form)rP_ADDRESS).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ADDRESS).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ADDRESS).Show();
				((Control)rP_ADDRESS).Focus();
				break;
			}
			case "Vp Report":
			{
				RP_ALL rP_ALL = new RP_ALL();
				((Form)rP_ALL).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ALL).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ALL).Show();
				((Control)rP_ALL).Focus();
				break;
			}
			}
		}
	}

	private void Karigar_Form()
	{
		checked
		{
			switch (MsSideBtn)
			{
			case "Kr Issue":
				DC_Main.CurBookHelp("KARIGAR ISSUE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_KR_ISU tR_KR_ISU = new TR_KR_ISU();
					((Form)tR_KR_ISU).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_KR_ISU).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_KR_ISU).Show();
					((Control)tR_KR_ISU).Focus();
				}
				break;
			case "Kr Received":
				DC_Main.CurBookHelp("KARIGAR RECEIPT");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_PURC tR_PURC = new TR_PURC();
					((Form)tR_PURC).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_PURC).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_PURC).Show();
					((Control)tR_PURC).Focus();
				}
				break;
			case "Kr Design Isu":
				DC_Main.CurBookHelp("KARIGAR ORDER");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_APR_ISU tR_APR_ISU = new TR_APR_ISU();
					((Form)tR_APR_ISU).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_APR_ISU).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_APR_ISU).Show();
					((Control)tR_APR_ISU).Focus();
				}
				break;
			case "Cust Repar Rec":
				DC_Main.CurBookHelp("CUSTREP RECEIPT");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_REP_REC tR_REP_REC3 = new TR_REP_REC();
					((Form)tR_REP_REC3).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_REP_REC3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_REP_REC3).Show();
					((Control)tR_REP_REC3).Focus();
				}
				break;
			case "Kr Repar Isu":
				DC_Main.CurBookHelp("KRREP ISSUE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_REP_REC tR_REP_REC2 = new TR_REP_REC();
					((Form)tR_REP_REC2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_REP_REC2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_REP_REC2).Show();
					((Control)tR_REP_REC2).Focus();
				}
				break;
			case "Kr Repar Rec":
				DC_Main.CurBookHelp("KRREP RECEIPT");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_REP_REC tR_REP_REC = new TR_REP_REC();
					((Form)tR_REP_REC).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_REP_REC).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_REP_REC).Show();
					((Control)tR_REP_REC).Focus();
				}
				break;
			case "Cust Repar Isu":
				DC_Main.CurBookHelp("CUSTREP ISSUE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_REP_REC tR_REP_REC4 = new TR_REP_REC();
					((Form)tR_REP_REC4).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_REP_REC4).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_REP_REC4).Show();
					((Control)tR_REP_REC4).Focus();
				}
				break;
			case "Kr Report":
			{
				RP_ALL rP_ALL2 = new RP_ALL();
				((Form)rP_ALL2).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ALL2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ALL2).Show();
				((Control)rP_ALL2).Focus();
				break;
			}
			case "Reparing Rpt":
			{
				RP_ALL rP_ALL = new RP_ALL();
				((Form)rP_ALL).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ALL).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ALL).Show();
				((Control)rP_ALL).Focus();
				break;
			}
			case "Mfg Isu":
				DC_Main.CurBookHelp("MFG ISU ITEM");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					Form tR_MFG_ITEM2 = (Form)(object)MyProject.Forms.TR_MFG_ITEM;
					tR_MFG_ITEM2.MdiParent = (Form)(object)this;
					tR_MFG_ITEM2.Text = MsSideBtn;
					((Control)tR_MFG_ITEM2).Show();
					((Control)tR_MFG_ITEM2).Focus();
				}
				break;
			case "Mfg Rec":
				DC_Main.CurBookHelp("MFG REC ITEM");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					Form tR_MFG_ITEM = (Form)(object)MyProject.Forms.TR_MFG_ITEM;
					tR_MFG_ITEM.MdiParent = (Form)(object)this;
					tR_MFG_ITEM.Text = MsSideBtn;
					((Control)tR_MFG_ITEM).Show();
					((Control)tR_MFG_ITEM).Focus();
				}
				break;
			case "Mfg Ledger":
			{
				RP_MFG_LEDR rP_MFG_LEDR = new RP_MFG_LEDR();
				((Form)rP_MFG_LEDR).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_MFG_LEDR).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_MFG_LEDR).Show();
				((Control)rP_MFG_LEDR).Focus();
				break;
			}
			case "Lot Report":
			{
				RP_ORDER rP_ORDER = new RP_ORDER();
				((Form)rP_ORDER).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ORDER).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ORDER).Show();
				((Control)rP_ORDER).Focus();
				break;
			}
			case "Stock Isu":
				DC_Main.CurBookHelp("EMP ISU");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_TOUR tR_TOUR2 = new TR_TOUR();
					((Form)tR_TOUR2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_TOUR2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_TOUR2).Show();
					((Control)tR_TOUR2).Focus();
				}
				break;
			case "Tour Order":
				DC_Main.CurBookHelp("TOUR ORDER");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					Form tR_TOUR_ORD = (Form)(object)MyProject.Forms.TR_TOUR_ORD;
					tR_TOUR_ORD.MdiParent = (Form)(object)this;
					tR_TOUR_ORD.Text = MsSideBtn;
					((Control)tR_TOUR_ORD).Show();
					((Control)tR_TOUR_ORD).Focus();
				}
				break;
			case "Tour Sales":
				DC_Main.CurBookHelp("TOUR SALES");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					Form tR_TOUR_SALE = (Form)(object)MyProject.Forms.TR_TOUR_SALE;
					tR_TOUR_SALE.MdiParent = (Form)(object)this;
					tR_TOUR_SALE.Text = MsSideBtn;
					((Control)tR_TOUR_SALE).Show();
					((Control)tR_TOUR_SALE).Focus();
				}
				break;
			case "Stock Rec":
				DC_Main.CurBookHelp("EMP REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_TOUR tR_TOUR = new TR_TOUR();
					((Form)tR_TOUR).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_TOUR).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_TOUR).Show();
					((Control)tR_TOUR).Focus();
				}
				break;
			case "Tour Report":
			{
				RP_TOUR_ZOOM rP_TOUR_ZOOM2 = new RP_TOUR_ZOOM();
				((Form)rP_TOUR_ZOOM2).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_TOUR_ZOOM2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_TOUR_ZOOM2).Show();
				((Control)rP_TOUR_ZOOM2).Focus();
				break;
			}
			case "Tour Tag":
			{
				RP_TOUR_ZOOM rP_TOUR_ZOOM = new RP_TOUR_ZOOM();
				((Form)rP_TOUR_ZOOM).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_TOUR_ZOOM).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_TOUR_ZOOM).Show();
				((Control)rP_TOUR_ZOOM).Focus();
				break;
			}
			}
		}
	}

	private void Scheme_Form()
	{
		checked
		{
			switch (MsSideBtn)
			{
			case "Scheme Mast":
			{
				MS_PRODUCT mS_PRODUCT = new MS_PRODUCT();
				((Form)mS_PRODUCT).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_PRODUCT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_PRODUCT).Show();
				((Control)mS_PRODUCT).Focus();
				break;
			}
			case "Member Mast":
			{
				MS_MEMB mS_MEMB = new MS_MEMB();
				((Form)mS_MEMB).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_MEMB).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_MEMB).Show();
				((Control)mS_MEMB).Focus();
				break;
			}
			case "Memb Opening":
				DC_Main.CurBookHelp("MEMB OPENING");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_MEMB_ENT tR_MEMB_ENT = new TR_MEMB_ENT();
					((Form)tR_MEMB_ENT).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_MEMB_ENT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_MEMB_ENT).Show();
					((Control)tR_MEMB_ENT).Focus();
				}
				break;
			case "Memb Entry":
				DC_Main.CurBookHelp("MEMB ENTRY");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_MEMB_ENT tR_MEMB_ENT2 = new TR_MEMB_ENT();
					((Form)tR_MEMB_ENT2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_MEMB_ENT2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_MEMB_ENT2).Show();
					((Control)tR_MEMB_ENT2).Focus();
				}
				break;
			case "Memb Adjust":
				DC_Main.CurBookHelp("MEMB ADJUST");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_MEMB_ADJ tR_MEMB_ADJ2 = new TR_MEMB_ADJ();
					((Form)tR_MEMB_ADJ2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_MEMB_ADJ2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_MEMB_ADJ2).Show();
					((Control)tR_MEMB_ADJ2).Focus();
				}
				break;
			case "Gold Adjust":
				DC_Main.CurBookHelp("MEMB GOLD ADJ");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_MEMB_ADJ tR_MEMB_ADJ = new TR_MEMB_ADJ();
					((Form)tR_MEMB_ADJ).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_MEMB_ADJ).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_MEMB_ADJ).Show();
					((Control)tR_MEMB_ADJ).Focus();
				}
				break;
			case "Scheme Report":
			{
				RP_ALL rP_ALL = new RP_ALL();
				((Form)rP_ALL).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ALL).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ALL).Show();
				((Control)rP_ALL).Focus();
				break;
			}
			case "Scheme Ledger":
			{
				RP_CASH_BANK rP_CASH_BANK = new RP_CASH_BANK();
				((Form)rP_CASH_BANK).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_CASH_BANK).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_CASH_BANK).Show();
				((Control)rP_CASH_BANK).Focus();
				break;
			}
			case "Monthly Report":
			{
				RP_STK_LEVEL rP_STK_LEVEL = new RP_STK_LEVEL();
				((Form)rP_STK_LEVEL).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_STK_LEVEL).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_STK_LEVEL).Show();
				((Control)rP_STK_LEVEL).Focus();
				break;
			}
			case "Gold Mast":
			{
				MS_GOLD_MAST mS_GOLD_MAST = new MS_GOLD_MAST();
				((Form)mS_GOLD_MAST).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_GOLD_MAST).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_GOLD_MAST).Show();
				((Control)mS_GOLD_MAST).Focus();
				break;
			}
			case "Digital Gold":
				DC_Main.CurBookHelp("DG GOLD");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_GOLD_BOOK tR_GOLD_BOOK = new TR_GOLD_BOOK();
					((Form)tR_GOLD_BOOK).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_GOLD_BOOK).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_GOLD_BOOK).Show();
					((Control)tR_GOLD_BOOK).Focus();
				}
				break;
			case "Dg Gold Adj":
				break;
			case "Day Sales":
			{
				RP_LC_SALE rP_LC_SALE = new RP_LC_SALE();
				((Form)rP_LC_SALE).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_LC_SALE).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_LC_SALE).Show();
				((Control)rP_LC_SALE).Focus();
				break;
			}
			case "Branch InOut":
			{
				RP_LC_INOUT rP_LC_INOUT = new RP_LC_INOUT();
				((Form)rP_LC_INOUT).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_LC_INOUT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_LC_INOUT).Show();
				((Control)rP_LC_INOUT).Focus();
				break;
			}
			}
		}
	}

	private void Dhiran_Form()
	{
		checked
		{
			switch (MsSideBtn)
			{
			case "Dhrn Issue":
				DC_Main.CurBookHelp("DHIRAN ISSUE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_DHRN_ISU tR_DHRN_ISU2 = new TR_DHRN_ISU();
					((Form)tR_DHRN_ISU2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_DHRN_ISU2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_DHRN_ISU2).Show();
					((Control)tR_DHRN_ISU2).Focus();
				}
				break;
			case "Dhrn Rec":
				DC_Main.CurBookHelp("DHIRAN RECEIVED");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_DHRN_REC tR_DHRN_REC2 = new TR_DHRN_REC();
					((Form)tR_DHRN_REC2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_DHRN_REC2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_DHRN_REC2).Show();
					((Control)tR_DHRN_REC2).Focus();
				}
				break;
			case "Intrest Rec":
				DC_Main.CurBookHelp("INTREST RECIVED");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_DHRN_INTREC tR_DHRN_INTREC2 = new TR_DHRN_INTREC();
					((Form)tR_DHRN_INTREC2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_DHRN_INTREC2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_DHRN_INTREC2).Show();
					((Control)tR_DHRN_INTREC2).Focus();
				}
				break;
			case "Dhiran Report":
				if (!((Operators.CompareString(DC_Main.SSRegSrNo, "VK047NEHR", false) == 0) & (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)))
				{
					RP_DHRN_LOAN rP_DHRN_LOAN2 = new RP_DHRN_LOAN();
					((Form)rP_DHRN_LOAN2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)rP_DHRN_LOAN2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)rP_DHRN_LOAN2).Show();
					((Control)rP_DHRN_LOAN2).Focus();
				}
				break;
			case "Intrest All":
			{
				RP_DHRN_OS rP_DHRN_OS3 = new RP_DHRN_OS();
				((Form)rP_DHRN_OS3).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_DHRN_OS3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_DHRN_OS3).Show();
				((Control)rP_DHRN_OS3).Focus();
				break;
			}
			case "Dhrn Os Letter":
				DC_Main.CurBookHelp("OS LETTER");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_DHRN_INTREC tR_DHRN_INTREC3 = new TR_DHRN_INTREC();
					((Form)tR_DHRN_INTREC3).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_DHRN_INTREC3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_DHRN_INTREC3).Show();
					((Control)tR_DHRN_INTREC3).Focus();
				}
				break;
			case "Dhrn Due":
			{
				RP_DHRN_OS rP_DHRN_OS2 = new RP_DHRN_OS();
				((Form)rP_DHRN_OS2).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_DHRN_OS2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_DHRN_OS2).Show();
				((Control)rP_DHRN_OS2).Focus();
				break;
			}
			case "Loan Received":
				DC_Main.CurBookHelp("LOAN REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_DHRN_ISU tR_DHRN_ISU = new TR_DHRN_ISU();
					((Form)tR_DHRN_ISU).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_DHRN_ISU).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_DHRN_ISU).Show();
					((Control)tR_DHRN_ISU).Focus();
				}
				break;
			case "Loan Intrest":
				DC_Main.CurBookHelp("LOAN INT ENTRY");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_DHRN_INTREC tR_DHRN_INTREC = new TR_DHRN_INTREC();
					((Form)tR_DHRN_INTREC).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_DHRN_INTREC).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_DHRN_INTREC).Show();
					((Control)tR_DHRN_INTREC).Focus();
				}
				break;
			case "Loan Issue":
				DC_Main.CurBookHelp("LOAN ISSUE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_DHRN_REC tR_DHRN_REC = new TR_DHRN_REC();
					((Form)tR_DHRN_REC).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_DHRN_REC).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_DHRN_REC).Show();
					((Control)tR_DHRN_REC).Focus();
				}
				break;
			case "Loan Report":
			{
				RP_DHRN_LOAN rP_DHRN_LOAN = new RP_DHRN_LOAN();
				((Form)rP_DHRN_LOAN).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_DHRN_LOAN).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_DHRN_LOAN).Show();
				((Control)rP_DHRN_LOAN).Focus();
				break;
			}
			case "Intrest Isu All":
			{
				RP_DHRN_OS rP_DHRN_OS = new RP_DHRN_OS();
				((Form)rP_DHRN_OS).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_DHRN_OS).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_DHRN_OS).Show();
				((Control)rP_DHRN_OS).Focus();
				break;
			}
			}
		}
	}

	private void Jadtar_Form()
	{
		checked
		{
			switch (MsSideBtn)
			{
			case "Melting Work":
				DC_Main.CurBookHelp("MLT PRO");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_MLT_PRO tR_MLT_PRO = new TR_MLT_PRO();
					((Form)tR_MLT_PRO).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_MLT_PRO).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_MLT_PRO).Show();
					((Control)tR_MLT_PRO).Focus();
				}
				break;
			case "Kr Order Isu":
				DC_Main.CurBookHelp("KARIGAR ORDER");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_APR_ISU tR_APR_ISU = new TR_APR_ISU();
					((Form)tR_APR_ISU).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_APR_ISU).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_APR_ISU).Show();
					((Control)tR_APR_ISU).Focus();
				}
				break;
			case "Metal Isu":
				DC_Main.CurBookHelp("KARIGAR ISSUE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_KR_ISU tR_KR_ISU = new TR_KR_ISU();
					((Form)tR_KR_ISU).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_KR_ISU).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_KR_ISU).Show();
					((Control)tR_KR_ISU).Focus();
				}
				break;
			case "Ghat Rec":
				DC_Main.CurBookHelp("GHAT REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					((Form)MyProject.Forms.TR_JDT_REC).MdiParent = (Form)(object)this;
					((Control)MyProject.Forms.TR_JDT_REC).Show();
					((Control)MyProject.Forms.TR_JDT_REC).Focus();
				}
				break;
			case "Jadtar Isu":
				DC_Main.CurBookHelp("JDTR ISU");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					((Form)MyProject.Forms.TR_JDT_REC).MdiParent = (Form)(object)this;
					((Control)MyProject.Forms.TR_JDT_REC).Show();
					((Control)MyProject.Forms.TR_JDT_REC).Focus();
				}
				break;
			case "Jadtar Rec":
				DC_Main.CurBookHelp("JDTR REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					((Form)MyProject.Forms.TR_JDT_REC).MdiParent = (Form)(object)this;
					((Control)MyProject.Forms.TR_JDT_REC).Show();
					((Control)MyProject.Forms.TR_JDT_REC).Focus();
				}
				break;
			case "Fitting Isu":
				DC_Main.CurBookHelp("FTNG ISU");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					((Form)MyProject.Forms.TR_JDT_REC).MdiParent = (Form)(object)this;
					((Control)MyProject.Forms.TR_JDT_REC).Show();
					((Control)MyProject.Forms.TR_JDT_REC).Focus();
				}
				break;
			case "Fitting Rec":
				DC_Main.CurBookHelp("FTNG REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					((Form)MyProject.Forms.TR_JDT_REC).MdiParent = (Form)(object)this;
					((Control)MyProject.Forms.TR_JDT_REC).Show();
					((Control)MyProject.Forms.TR_JDT_REC).Focus();
				}
				break;
			case "Chediya Isu":
				DC_Main.CurBookHelp("CHEDIYA ISU");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					((Form)MyProject.Forms.TR_JDT_REC).MdiParent = (Form)(object)this;
					((Control)MyProject.Forms.TR_JDT_REC).Show();
					((Control)MyProject.Forms.TR_JDT_REC).Focus();
				}
				break;
			case "Chediya Rec":
				DC_Main.CurBookHelp("CHEDIYA REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					((Form)MyProject.Forms.TR_JDT_REC).MdiParent = (Form)(object)this;
					((Control)MyProject.Forms.TR_JDT_REC).Show();
					((Control)MyProject.Forms.TR_JDT_REC).Focus();
				}
				break;
			case "Para Isu":
				DC_Main.CurBookHelp("PARA ISU");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					((Form)MyProject.Forms.TR_JDT_REC).MdiParent = (Form)(object)this;
					((Control)MyProject.Forms.TR_JDT_REC).Show();
					((Control)MyProject.Forms.TR_JDT_REC).Focus();
				}
				break;
			case "Para Rec":
				DC_Main.CurBookHelp("PARA REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					((Form)MyProject.Forms.TR_JDT_REC).MdiParent = (Form)(object)this;
					((Control)MyProject.Forms.TR_JDT_REC).Show();
					((Control)MyProject.Forms.TR_JDT_REC).Focus();
				}
				break;
			case "JdtTag Entry":
				DC_Main.CurBookHelp("JDTR TAG");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					((Form)MyProject.Forms.TR_TAG_OPBL).MdiParent = (Form)(object)this;
					((Control)MyProject.Forms.TR_TAG_OPBL).Show();
					((Control)MyProject.Forms.TR_TAG_OPBL).Focus();
				}
				break;
			case "Jadtar Ledr":
			{
				RP_JDTR_ZOOM rP_JDTR_ZOOM = new RP_JDTR_ZOOM();
				((Form)rP_JDTR_ZOOM).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_JDTR_ZOOM).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_JDTR_ZOOM).Show();
				((Control)rP_JDTR_ZOOM).Focus();
				break;
			}
			case "Jadtar Rpt":
			{
				RP_MFG rP_MFG = new RP_MFG();
				((Form)rP_MFG).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_MFG).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_MFG).Show();
				((Control)rP_MFG).Focus();
				break;
			}
			case "JdtTag Dtl":
			{
				RP_TAG rP_TAG = new RP_TAG();
				((Form)rP_TAG).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((XtraForm)rP_TAG).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_TAG).Show();
				((Control)rP_TAG).Focus();
				break;
			}
			case "Jadtar Ord":
			{
				RP_ORD_TRACK rP_ORD_TRACK = new RP_ORD_TRACK();
				((Form)rP_ORD_TRACK).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ORD_TRACK).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ORD_TRACK).Show();
				((Control)rP_ORD_TRACK).Focus();
				break;
			}
			}
		}
	}

	private void Mfg_Form()
	{
		checked
		{
			if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
			{
				switch (MsSideBtn)
				{
				case "Setting Isu":
					DC_Main.CurBookHelp("MFG STNG ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_WITH_LOT tR_MFG_WITH_LOT = new TR_MFG_WITH_LOT();
						((Form)tR_MFG_WITH_LOT).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_WITH_LOT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_WITH_LOT).Show();
						((Control)tR_MFG_WITH_LOT).Focus();
					}
					break;
				case "Setting Rec":
					DC_Main.CurBookHelp("MFG STNG REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_WITH_LOT tR_MFG_WITH_LOT3 = new TR_MFG_WITH_LOT();
						((Form)tR_MFG_WITH_LOT3).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_WITH_LOT3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_WITH_LOT3).Show();
						((Control)tR_MFG_WITH_LOT3).Focus();
					}
					break;
				case "Polish Isu":
					DC_Main.CurBookHelp("MFG POLISH ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_WITH_LOT tR_MFG_WITH_LOT4 = new TR_MFG_WITH_LOT();
						((Form)tR_MFG_WITH_LOT4).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_WITH_LOT4).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_WITH_LOT4).Show();
						((Control)tR_MFG_WITH_LOT4).Focus();
					}
					break;
				case "Polish Rec":
					DC_Main.CurBookHelp("MFG POLISH REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_WITH_LOT tR_MFG_WITH_LOT2 = new TR_MFG_WITH_LOT();
						((Form)tR_MFG_WITH_LOT2).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_WITH_LOT2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_WITH_LOT2).Show();
						((Control)tR_MFG_WITH_LOT2).Focus();
					}
					break;
				case "MfgTag Entry":
					DC_Main.CurBookHelp("MFG TAG");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						((Form)MyProject.Forms.TR_TAG_OPBL).MdiParent = (Form)(object)this;
						((Control)MyProject.Forms.TR_TAG_OPBL).Show();
						((Control)MyProject.Forms.TR_TAG_OPBL).Focus();
					}
					break;
				case "Mfg Mast":
				{
					MS_MFG_MAST mS_MFG_MAST = new MS_MFG_MAST();
					((Form)mS_MFG_MAST).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)mS_MFG_MAST).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)mS_MFG_MAST).Show();
					((Control)mS_MFG_MAST).Focus();
					break;
				}
				case "Lot IsuRec":
				{
					RP_MFG_ZOOM rP_MFG_ZOOM2 = new RP_MFG_ZOOM();
					((Form)rP_MFG_ZOOM2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)rP_MFG_ZOOM2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)rP_MFG_ZOOM2).Show();
					((Control)rP_MFG_ZOOM2).Focus();
					break;
				}
				case "Mfg Ledger":
				{
					RP_MFG_LEDR rP_MFG_LEDR = new RP_MFG_LEDR();
					((Form)rP_MFG_LEDR).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)rP_MFG_LEDR).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)rP_MFG_LEDR).Show();
					((Control)rP_MFG_LEDR).Focus();
					break;
				}
				case "Mfg InOut":
				{
					RP_MFG_ZOOM rP_MFG_ZOOM = new RP_MFG_ZOOM();
					((Form)rP_MFG_ZOOM).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)rP_MFG_ZOOM).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)rP_MFG_ZOOM).Show();
					((Control)rP_MFG_ZOOM).Focus();
					break;
				}
				}
				return;
			}
			switch (MsSideBtn)
			{
			case "Melting Work":
				DC_Main.CurBookHelp("MLT PRO");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_MLT_PRO tR_MLT_PRO = new TR_MLT_PRO();
					((Form)tR_MLT_PRO).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_MLT_PRO).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_MLT_PRO).Show();
					((Control)tR_MLT_PRO).Focus();
				}
				break;
			case "Metl Isu":
				DC_Main.CurBookHelp("METAL ISU");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC13 = new TR_MFG_KR_ISU_REC();
					((Form)tR_MFG_KR_ISU_REC13).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_MFG_KR_ISU_REC13).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_MFG_KR_ISU_REC13).Show();
					((Control)tR_MFG_KR_ISU_REC13).Focus();
				}
				break;
			case "Metal Isu":
				DC_Main.CurBookHelp("MTL ISU");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_KR_ISU tR_KR_ISU = new TR_KR_ISU();
					((Form)tR_KR_ISU).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_KR_ISU).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_KR_ISU).Show();
					((Control)tR_KR_ISU).Focus();
				}
				break;
			case "Design Isu":
				DC_Main.CurBookHelp("DESIGN ISU");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC7 = new TR_MFG_KR_ISU_REC();
					((Form)tR_MFG_KR_ISU_REC7).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_MFG_KR_ISU_REC7).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_MFG_KR_ISU_REC7).Show();
					((Control)tR_MFG_KR_ISU_REC7).Focus();
				}
				break;
			case "Wex Rec":
				DC_Main.CurBookHelp("MFG WEX REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC = new TR_MFG_KR_ISU_REC();
					((Form)tR_MFG_KR_ISU_REC).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_MFG_KR_ISU_REC).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_MFG_KR_ISU_REC).Show();
					((Control)tR_MFG_KR_ISU_REC).Focus();
				}
				break;
			case "Casting Isu":
				DC_Main.CurBookHelp("MFG CAST ISU");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC14 = new TR_MFG_KR_ISU_REC();
					((Form)tR_MFG_KR_ISU_REC14).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_MFG_KR_ISU_REC14).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_MFG_KR_ISU_REC14).Show();
					((Control)tR_MFG_KR_ISU_REC14).Focus();
				}
				break;
			case "Casting Rec":
				DC_Main.CurBookHelp("MFG CAST REC");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC2 = new TR_MFG_KR_ISU_REC();
					((Form)tR_MFG_KR_ISU_REC2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_MFG_KR_ISU_REC2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_MFG_KR_ISU_REC2).Show();
					((Control)tR_MFG_KR_ISU_REC2).Focus();
				}
				break;
			case "Ghat Isu":
				if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("GHAT ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ORD_ISU tR_MFG_ORD_ISU = new TR_MFG_ORD_ISU();
						((Form)tR_MFG_ORD_ISU).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ORD_ISU).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ORD_ISU).Show();
						((Control)tR_MFG_ORD_ISU).Focus();
					}
				}
				else
				{
					DC_Main.CurBookHelp("GHAT ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ISU_REC tR_MFG_ISU_REC15 = new TR_MFG_ISU_REC();
						((Form)tR_MFG_ISU_REC15).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ISU_REC15).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ISU_REC15).Show();
						((Control)tR_MFG_ISU_REC15).Focus();
					}
				}
				break;
			case "Ghat Rec":
				if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					if (Operators.CompareString(DC_Main.SSRegSrNo, "VS205NSBU", false) == 0)
					{
						DC_Main.CurBookHelp("MFG GHAT REC");
						if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
						{
							TR_MFG_ORD_REC tR_MFG_ORD_REC7 = new TR_MFG_ORD_REC();
							((Form)tR_MFG_ORD_REC7).MdiParent = (Form)(object)this;
							DC_Main.TotOpenForm++;
							((Form)tR_MFG_ORD_REC7).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
							((Control)tR_MFG_ORD_REC7).Show();
							((Control)tR_MFG_ORD_REC7).Focus();
						}
					}
					else
					{
						DC_Main.CurBookHelp("MFG GHAT REC");
						if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
						{
							TR_MFG_GHAT_REC tR_MFG_GHAT_REC3 = new TR_MFG_GHAT_REC();
							((Form)tR_MFG_GHAT_REC3).MdiParent = (Form)(object)this;
							DC_Main.TotOpenForm++;
							((Form)tR_MFG_GHAT_REC3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
							((Control)tR_MFG_GHAT_REC3).Show();
							((Control)tR_MFG_GHAT_REC3).Focus();
						}
					}
				}
				else
				{
					DC_Main.CurBookHelp("MFG GHAT REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ISU_REC tR_MFG_ISU_REC10 = new TR_MFG_ISU_REC();
						((Form)tR_MFG_ISU_REC10).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ISU_REC10).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ISU_REC10).Show();
						((Control)tR_MFG_ISU_REC10).Focus();
					}
				}
				break;
			case "Filling Isu":
				if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG FILE ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC12 = new TR_MFG_KR_ISU_REC();
						((Form)tR_MFG_KR_ISU_REC12).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_KR_ISU_REC12).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_KR_ISU_REC12).Show();
						((Control)tR_MFG_KR_ISU_REC12).Focus();
					}
				}
				else
				{
					DC_Main.CurBookHelp("MFG FILE ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ISU_REC tR_MFG_ISU_REC7 = new TR_MFG_ISU_REC();
						((Form)tR_MFG_ISU_REC7).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ISU_REC7).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ISU_REC7).Show();
						((Control)tR_MFG_ISU_REC7).Focus();
					}
				}
				break;
			case "Filling Rec":
				if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG FILE REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC16 = new TR_MFG_KR_ISU_REC();
						((Form)tR_MFG_KR_ISU_REC16).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_KR_ISU_REC16).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_KR_ISU_REC16).Show();
						((Control)tR_MFG_KR_ISU_REC16).Focus();
					}
				}
				else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG FILE REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ORD_REC tR_MFG_ORD_REC6 = new TR_MFG_ORD_REC();
						((Form)tR_MFG_ORD_REC6).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ORD_REC6).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ORD_REC6).Show();
						((Control)tR_MFG_ORD_REC6).Focus();
					}
				}
				else
				{
					DC_Main.CurBookHelp("MFG FILE REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ISU_REC tR_MFG_ISU_REC9 = new TR_MFG_ISU_REC();
						((Form)tR_MFG_ISU_REC9).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ISU_REC9).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ISU_REC9).Show();
						((Control)tR_MFG_ISU_REC9).Focus();
					}
				}
				break;
			case "Pre Polish Isu":
				if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG PREP ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC18 = new TR_MFG_KR_ISU_REC();
						((Form)tR_MFG_KR_ISU_REC18).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_KR_ISU_REC18).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_KR_ISU_REC18).Show();
						((Control)tR_MFG_KR_ISU_REC18).Focus();
					}
				}
				else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG PREP ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ORD_REC tR_MFG_ORD_REC10 = new TR_MFG_ORD_REC();
						((Form)tR_MFG_ORD_REC10).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ORD_REC10).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ORD_REC10).Show();
						((Control)tR_MFG_ORD_REC10).Focus();
					}
				}
				else
				{
					DC_Main.CurBookHelp("MFG PREP ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ISU_REC tR_MFG_ISU_REC13 = new TR_MFG_ISU_REC();
						((Form)tR_MFG_ISU_REC13).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ISU_REC13).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ISU_REC13).Show();
						((Control)tR_MFG_ISU_REC13).Focus();
					}
				}
				break;
			case "Pre Polish Rec":
				if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG PREP REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC9 = new TR_MFG_KR_ISU_REC();
						((Form)tR_MFG_KR_ISU_REC9).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_KR_ISU_REC9).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_KR_ISU_REC9).Show();
						((Control)tR_MFG_KR_ISU_REC9).Focus();
					}
				}
				else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG PREP REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ORD_REC tR_MFG_ORD_REC3 = new TR_MFG_ORD_REC();
						((Form)tR_MFG_ORD_REC3).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ORD_REC3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ORD_REC3).Show();
						((Control)tR_MFG_ORD_REC3).Focus();
					}
				}
				else
				{
					DC_Main.CurBookHelp("MFG PREP REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ISU_REC tR_MFG_ISU_REC4 = new TR_MFG_ISU_REC();
						((Form)tR_MFG_ISU_REC4).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ISU_REC4).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ISU_REC4).Show();
						((Control)tR_MFG_ISU_REC4).Focus();
					}
				}
				break;
			case "Nakshi isu":
				if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG NAKSHI ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC17 = new TR_MFG_KR_ISU_REC();
						((Form)tR_MFG_KR_ISU_REC17).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_KR_ISU_REC17).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_KR_ISU_REC17).Show();
						((Control)tR_MFG_KR_ISU_REC17).Focus();
					}
				}
				else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG NAKSHI ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ORD_REC tR_MFG_ORD_REC9 = new TR_MFG_ORD_REC();
						((Form)tR_MFG_ORD_REC9).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ORD_REC9).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ORD_REC9).Show();
						((Control)tR_MFG_ORD_REC9).Focus();
					}
				}
				else
				{
					DC_Main.CurBookHelp("MFG NAKSHI ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ISU_REC tR_MFG_ISU_REC12 = new TR_MFG_ISU_REC();
						((Form)tR_MFG_ISU_REC12).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ISU_REC12).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ISU_REC12).Show();
						((Control)tR_MFG_ISU_REC12).Focus();
					}
				}
				break;
			case "Nakshi Rec":
				if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG NAKSHI REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC4 = new TR_MFG_KR_ISU_REC();
						((Form)tR_MFG_KR_ISU_REC4).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_KR_ISU_REC4).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_KR_ISU_REC4).Show();
						((Control)tR_MFG_KR_ISU_REC4).Focus();
					}
				}
				else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG NAKSHI REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ORD_REC tR_MFG_ORD_REC2 = new TR_MFG_ORD_REC();
						((Form)tR_MFG_ORD_REC2).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ORD_REC2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ORD_REC2).Show();
						((Control)tR_MFG_ORD_REC2).Focus();
					}
				}
				else
				{
					DC_Main.CurBookHelp("MFG NAKSHI REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ISU_REC tR_MFG_ISU_REC2 = new TR_MFG_ISU_REC();
						((Form)tR_MFG_ISU_REC2).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ISU_REC2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ISU_REC2).Show();
						((Control)tR_MFG_ISU_REC2).Focus();
					}
				}
				break;
			case "Mino Isu":
				if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG MINO ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC15 = new TR_MFG_KR_ISU_REC();
						((Form)tR_MFG_KR_ISU_REC15).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_KR_ISU_REC15).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_KR_ISU_REC15).Show();
						((Control)tR_MFG_KR_ISU_REC15).Focus();
					}
				}
				else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG MINO ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_GHAT_REC tR_MFG_GHAT_REC2 = new TR_MFG_GHAT_REC();
						((Form)tR_MFG_GHAT_REC2).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_GHAT_REC2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_GHAT_REC2).Show();
						((Control)tR_MFG_GHAT_REC2).Focus();
					}
				}
				else
				{
					DC_Main.CurBookHelp("MFG MINO ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ISU_REC tR_MFG_ISU_REC8 = new TR_MFG_ISU_REC();
						((Form)tR_MFG_ISU_REC8).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ISU_REC8).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ISU_REC8).Show();
						((Control)tR_MFG_ISU_REC8).Focus();
					}
				}
				break;
			case "Mino Rec":
				if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG MINO REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC6 = new TR_MFG_KR_ISU_REC();
						((Form)tR_MFG_KR_ISU_REC6).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_KR_ISU_REC6).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_KR_ISU_REC6).Show();
						((Control)tR_MFG_KR_ISU_REC6).Focus();
					}
				}
				else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG MINO REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_GHAT_REC tR_MFG_GHAT_REC = new TR_MFG_GHAT_REC();
						((Form)tR_MFG_GHAT_REC).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_GHAT_REC).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_GHAT_REC).Show();
						((Control)tR_MFG_GHAT_REC).Focus();
					}
				}
				else
				{
					DC_Main.CurBookHelp("MFG MINO REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ISU_REC tR_MFG_ISU_REC3 = new TR_MFG_ISU_REC();
						((Form)tR_MFG_ISU_REC3).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ISU_REC3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ISU_REC3).Show();
						((Control)tR_MFG_ISU_REC3).Focus();
					}
				}
				break;
			case "Setting Isu":
				if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG STNG ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC19 = new TR_MFG_KR_ISU_REC();
						((Form)tR_MFG_KR_ISU_REC19).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_KR_ISU_REC19).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_KR_ISU_REC19).Show();
						((Control)tR_MFG_KR_ISU_REC19).Focus();
					}
				}
				else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG STNG ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ORD_REC tR_MFG_ORD_REC11 = new TR_MFG_ORD_REC();
						((Form)tR_MFG_ORD_REC11).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ORD_REC11).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ORD_REC11).Show();
						((Control)tR_MFG_ORD_REC11).Focus();
					}
				}
				else
				{
					DC_Main.CurBookHelp("MFG STNG ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ISU_REC tR_MFG_ISU_REC14 = new TR_MFG_ISU_REC();
						((Form)tR_MFG_ISU_REC14).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ISU_REC14).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ISU_REC14).Show();
						((Control)tR_MFG_ISU_REC14).Focus();
					}
				}
				break;
			case "Setting Rec":
				if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG STNG REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC11 = new TR_MFG_KR_ISU_REC();
						((Form)tR_MFG_KR_ISU_REC11).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_KR_ISU_REC11).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_KR_ISU_REC11).Show();
						((Control)tR_MFG_KR_ISU_REC11).Focus();
					}
				}
				else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG STNG REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ORD_REC tR_MFG_ORD_REC5 = new TR_MFG_ORD_REC();
						((Form)tR_MFG_ORD_REC5).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ORD_REC5).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ORD_REC5).Show();
						((Control)tR_MFG_ORD_REC5).Focus();
					}
				}
				else
				{
					DC_Main.CurBookHelp("MFG STNG REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ISU_REC tR_MFG_ISU_REC6 = new TR_MFG_ISU_REC();
						((Form)tR_MFG_ISU_REC6).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ISU_REC6).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ISU_REC6).Show();
						((Control)tR_MFG_ISU_REC6).Focus();
					}
				}
				break;
			case "Assemble Isu":
				if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG ASMBL ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC8 = new TR_MFG_KR_ISU_REC();
						((Form)tR_MFG_KR_ISU_REC8).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_KR_ISU_REC8).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_KR_ISU_REC8).Show();
						((Control)tR_MFG_KR_ISU_REC8).Focus();
					}
				}
				break;
			case "Assemble Rec":
				if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG ASMBL REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC5 = new TR_MFG_KR_ISU_REC();
						((Form)tR_MFG_KR_ISU_REC5).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_KR_ISU_REC5).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_KR_ISU_REC5).Show();
						((Control)tR_MFG_KR_ISU_REC5).Focus();
					}
				}
				break;
			case "Filling2 Isu":
				if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG GHAT REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ORD_REC tR_MFG_ORD_REC12 = new TR_MFG_ORD_REC();
						((Form)tR_MFG_ORD_REC12).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ORD_REC12).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ORD_REC12).Show();
						((Control)tR_MFG_ORD_REC12).Focus();
					}
				}
				else
				{
					DC_Main.CurBookHelp("MFG GHAT REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ISU_REC tR_MFG_ISU_REC16 = new TR_MFG_ISU_REC();
						((Form)tR_MFG_ISU_REC16).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ISU_REC16).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ISU_REC16).Show();
						((Control)tR_MFG_ISU_REC16).Focus();
					}
				}
				break;
			case "Filling2 Rec":
				if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG GHAT REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ORD_REC tR_MFG_ORD_REC8 = new TR_MFG_ORD_REC();
						((Form)tR_MFG_ORD_REC8).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ORD_REC8).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ORD_REC8).Show();
						((Control)tR_MFG_ORD_REC8).Focus();
					}
				}
				else
				{
					DC_Main.CurBookHelp("MFG GHAT REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ISU_REC tR_MFG_ISU_REC11 = new TR_MFG_ISU_REC();
						((Form)tR_MFG_ISU_REC11).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ISU_REC11).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ISU_REC11).Show();
						((Control)tR_MFG_ISU_REC11).Focus();
					}
				}
				break;
			case "Polish Isu":
				if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG POLISH ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC10 = new TR_MFG_KR_ISU_REC();
						((Form)tR_MFG_KR_ISU_REC10).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_KR_ISU_REC10).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_KR_ISU_REC10).Show();
						((Control)tR_MFG_KR_ISU_REC10).Focus();
					}
				}
				else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG POLISH ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ORD_REC tR_MFG_ORD_REC4 = new TR_MFG_ORD_REC();
						((Form)tR_MFG_ORD_REC4).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ORD_REC4).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ORD_REC4).Show();
						((Control)tR_MFG_ORD_REC4).Focus();
					}
				}
				else
				{
					DC_Main.CurBookHelp("MFG POLISH ISU");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ISU_REC tR_MFG_ISU_REC5 = new TR_MFG_ISU_REC();
						((Form)tR_MFG_ISU_REC5).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ISU_REC5).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ISU_REC5).Show();
						((Control)tR_MFG_ISU_REC5).Focus();
					}
				}
				break;
			case "Polish Rec":
				if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG POLISH REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC3 = new TR_MFG_KR_ISU_REC();
						((Form)tR_MFG_KR_ISU_REC3).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_KR_ISU_REC3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_KR_ISU_REC3).Show();
						((Control)tR_MFG_KR_ISU_REC3).Focus();
					}
				}
				else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
				{
					DC_Main.CurBookHelp("MFG POLISH REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ORD_REC tR_MFG_ORD_REC = new TR_MFG_ORD_REC();
						((Form)tR_MFG_ORD_REC).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ORD_REC).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ORD_REC).Show();
						((Control)tR_MFG_ORD_REC).Focus();
					}
				}
				else
				{
					DC_Main.CurBookHelp("MFG POLISH REC");
					if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
					{
						TR_MFG_ISU_REC tR_MFG_ISU_REC = new TR_MFG_ISU_REC();
						((Form)tR_MFG_ISU_REC).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)tR_MFG_ISU_REC).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)tR_MFG_ISU_REC).Show();
						((Control)tR_MFG_ISU_REC).Focus();
					}
				}
				break;
			case "MfgTag Entry":
				DC_Main.CurBookHelp("MFG TAG");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					((Form)MyProject.Forms.TR_TAG_OPBL).MdiParent = (Form)(object)this;
					((Control)MyProject.Forms.TR_TAG_OPBL).Show();
					((Control)MyProject.Forms.TR_TAG_OPBL).Focus();
				}
				break;
			case "Mfg Mast":
			{
				MS_MFG_MAST mS_MFG_MAST2 = new MS_MFG_MAST();
				((Form)mS_MFG_MAST2).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_MFG_MAST2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_MFG_MAST2).Show();
				((Control)mS_MFG_MAST2).Focus();
				break;
			}
			case "Lot IsuRec":
			{
				RP_MFG_ZOOM rP_MFG_ZOOM4 = new RP_MFG_ZOOM();
				((Form)rP_MFG_ZOOM4).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_MFG_ZOOM4).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_MFG_ZOOM4).Show();
				((Control)rP_MFG_ZOOM4).Focus();
				break;
			}
			case "Mfg Ledger":
				if (Operators.CompareString(DC_Main.MsMfgWithLedger, "Y", false) == 0)
				{
					RP_LEDR rP_LEDR = new RP_LEDR();
					((Form)rP_LEDR).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)rP_LEDR).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)rP_LEDR).Show();
					((Control)rP_LEDR).Focus();
				}
				else
				{
					RP_MFG_LEDR rP_MFG_LEDR2 = new RP_MFG_LEDR();
					((Form)rP_MFG_LEDR2).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)rP_MFG_LEDR2).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)rP_MFG_LEDR2).Show();
					((Control)rP_MFG_LEDR2).Focus();
				}
				break;
			case "Mfg Order":
			{
				RP_ORD_TRACK rP_ORD_TRACK = new RP_ORD_TRACK();
				((Form)rP_ORD_TRACK).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ORD_TRACK).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ORD_TRACK).Show();
				((Control)rP_ORD_TRACK).Focus();
				break;
			}
			case "Mfg InOut":
			{
				RP_MFG_ZOOM rP_MFG_ZOOM3 = new RP_MFG_ZOOM();
				((Form)rP_MFG_ZOOM3).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_MFG_ZOOM3).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_MFG_ZOOM3).Show();
				((Control)rP_MFG_ZOOM3).Focus();
				break;
			}
			case "Dm Size":
			{
				MS_STK_LIMIT mS_STK_LIMIT = new MS_STK_LIMIT();
				((Form)mS_STK_LIMIT).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_STK_LIMIT).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_STK_LIMIT).Show();
				((Control)mS_STK_LIMIT).Focus();
				break;
			}
			}
		}
	}

	private void Crm_Form()
	{
		string msSideBtn = MsSideBtn;
		checked
		{
			if (Operators.CompareString(msSideBtn, "Cust Entry", false) != 0)
			{
				if (Operators.CompareString(msSideBtn, "Cust Report", false) == 0)
				{
					RP_CUST_CRM rP_CUST_CRM = new RP_CUST_CRM();
					((Form)rP_CUST_CRM).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)rP_CUST_CRM).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)rP_CUST_CRM).Show();
					((Control)rP_CUST_CRM).Focus();
				}
			}
			else
			{
				UT_CUST_ENTRY uT_CUST_ENTRY = new UT_CUST_ENTRY();
				((Form)uT_CUST_ENTRY).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)uT_CUST_ENTRY).Text = MsSideBtn + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)uT_CUST_ENTRY).Show();
				((Control)uT_CUST_ENTRY).Focus();
			}
		}
	}

	private void SideFooterMenuSet()
	{
		if (FooterMenuClick)
		{
			FooterMenuClick = false;
			SideTrip.RootDisplayMode = (AccordionControlRootDisplayMode)0;
			SideTrip.RootDisplayMode = (AccordionControlRootDisplayMode)1;
		}
	}

	private void BtnComp_Click(object sender, EventArgs e)
	{
		MainTripButton_Color();
		SideFooterMenuSet();
		((ToolStripItem)BtnComp).BackColor = Color.BlanchedAlmond;
		((ToolStripItem)BtnComp).ForeColor = Color.DarkRed;
		((AccordionControlElementBase)SLMain2).Visible = false;
		RptAnalysis = false;
		DC_Main.MsMainBtn = "Company";
		Side_Menu_Fill();
	}

	private void BtnMast_Click(object sender, EventArgs e)
	{
		MainTripButton_Color();
		SideFooterMenuSet();
		((ToolStripItem)BtnMast).BackColor = Color.BlanchedAlmond;
		((ToolStripItem)BtnMast).ForeColor = Color.DarkRed;
		((AccordionControlElementBase)SLMain2).Visible = false;
		RptAnalysis = false;
		DC_Main.MsMainBtn = "Master";
		Side_Menu_Fill();
	}

	private void BtnTran_Click(object sender, EventArgs e)
	{
		MainTripButton_Color();
		SideFooterMenuSet();
		((ToolStripItem)BtnTran).BackColor = Color.BlanchedAlmond;
		((ToolStripItem)BtnTran).ForeColor = Color.DarkRed;
		((AccordionControlElementBase)SLMain2).Visible = false;
		RptAnalysis = false;
		DC_Main.MsMainBtn = "Transaction";
		Side_Menu_Fill();
	}

	private void BtnTran2_Click(object sender, EventArgs e)
	{
		MainTripButton_Color();
		SideFooterMenuSet();
		((ToolStripItem)BtnTran2).BackColor = Color.BlanchedAlmond;
		((ToolStripItem)BtnTran2).ForeColor = Color.DarkRed;
		if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
		{
			((AccordionControlElementBase)SLMain2).Text = "Extra";
			((AccordionControlElementBase)SLMain2).Visible = true;
		}
		else
		{
			((AccordionControlElementBase)SLMain2).Visible = false;
		}
		RptAnalysis = false;
		DC_Main.MsMainBtn = "ExtraTran";
		Side_Menu_Fill();
	}

	private void BtnOth_Click(object sender, EventArgs e)
	{
		MainTripButton_Color();
		SideFooterMenuSet();
		((ToolStripItem)BtnOth).BackColor = Color.BlanchedAlmond;
		((ToolStripItem)BtnOth).ForeColor = Color.DarkRed;
		if (!((Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "B", false) == 0)))
		{
			((AccordionControlElementBase)SLMain2).Text = "Extra";
			((AccordionControlElementBase)SLMain2).Visible = true;
		}
		RptAnalysis = false;
		DC_Main.MsMainBtn = "Other";
		Side_Menu_Fill();
	}

	private void BtnKrgr_Click(object sender, EventArgs e)
	{
		MainTripButton_Color();
		SideFooterMenuSet();
		((ToolStripItem)BtnKrgr).BackColor = Color.BlanchedAlmond;
		((ToolStripItem)BtnKrgr).ForeColor = Color.DarkRed;
		((AccordionControlElementBase)SLMain2).Visible = false;
		if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
		{
			((AccordionControlElementBase)SLMain2).Text = "Tour";
			((AccordionControlElementBase)SLMain2).Visible = true;
		}
		RptAnalysis = false;
		DC_Main.MsMainBtn = "Karigar";
		Side_Menu_Fill();
	}

	private void BtnRpt_Click(object sender, EventArgs e)
	{
		MainTripButton_Color();
		SideFooterMenuSet();
		((ToolStripItem)BtnRpt).BackColor = Color.BlanchedAlmond;
		((ToolStripItem)BtnRpt).ForeColor = Color.DarkRed;
		if (!((Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "B", false) == 0)))
		{
			((AccordionControlElementBase)SLMain2).Text = "Extra";
			((AccordionControlElementBase)SLMain2).Visible = true;
		}
		RptAnalysis = false;
		DC_Main.MsMainBtn = "Report";
		Side_Menu_Fill();
	}

	private void BtnSchm_Click(object sender, EventArgs e)
	{
		MainTripButton_Color();
		SideFooterMenuSet();
		((ToolStripItem)BtnSchm).BackColor = Color.BlanchedAlmond;
		((ToolStripItem)BtnSchm).ForeColor = Color.DarkRed;
		DC_Main.RsQry = "SELECT LC_CODE FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 1)
		{
			((AccordionControlElementBase)SLMain2).Text = "Branch";
			((AccordionControlElementBase)SLMain2).Visible = true;
		}
		else
		{
			((AccordionControlElementBase)SLMain2).Visible = false;
		}
		RptAnalysis = false;
		DC_Main.MsMainBtn = "Scheme";
		Side_Menu_Fill();
	}

	private void BtnDhrn_Click(object sender, EventArgs e)
	{
		MainTripButton_Color();
		SideFooterMenuSet();
		((ToolStripItem)BtnDhrn).BackColor = Color.BlanchedAlmond;
		((ToolStripItem)BtnDhrn).ForeColor = Color.DarkRed;
		((AccordionControlElementBase)SLMain2).Text = "Loan";
		((AccordionControlElementBase)SLMain2).Visible = true;
		RptAnalysis = false;
		DC_Main.MsMainBtn = "Dhiran";
		Side_Menu_Fill();
	}

	private void BtnMfg_Click(object sender, EventArgs e)
	{
		MainTripButton_Color();
		SideFooterMenuSet();
		((ToolStripItem)BtnMfg).BackColor = Color.BlanchedAlmond;
		((ToolStripItem)BtnMfg).ForeColor = Color.DarkRed;
		((AccordionControlElementBase)SLMain2).Text = "Report";
		((AccordionControlElementBase)SLMain2).Visible = true;
		RptAnalysis = false;
		if (Operators.CompareString(DC_Main.MsMfgType, "J", false) == 0)
		{
			DC_Main.MsMainBtn = "Jadtar";
		}
		else if (Operators.CompareString(DC_Main.MsMfgType, "M", false) == 0)
		{
			DC_Main.MsMainBtn = "Mfg";
		}
		Side_Menu_Fill();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Invalid comparison between Unknown and I4
		if (DC_Main.TakeBkp)
		{
			Application.Exit();
		}
		else if ((int)Interaction.MsgBox((object)"Do your Want to Take Backup Now", (MsgBoxStyle)36, (object)null) == 6)
		{
			DC_Main.TakeBkp = true;
			PanalImage_Hide();
			DC_Main.MsUserRightForm = "Data Backup";
			UT_BKP uT_BKP = new UT_BKP();
			((Form)uT_BKP).MdiParent = (Form)(object)this;
			checked
			{
				DC_Main.TotOpenForm++;
				((Form)uT_BKP).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)uT_BKP).Show();
				((Control)uT_BKP).Focus();
			}
		}
		else
		{
			Application.Exit();
		}
	}

	private void MainTripButton_Color()
	{
		((ToolStripItem)btnHome).BackColor = Color.Transparent;
		((ToolStripItem)BtnComp).BackColor = Color.Transparent;
		((ToolStripItem)BtnMast).BackColor = Color.Transparent;
		((ToolStripItem)BtnTran).BackColor = Color.Transparent;
		((ToolStripItem)BtnTran2).BackColor = Color.Transparent;
		((ToolStripItem)BtnKrgr).BackColor = Color.Transparent;
		((ToolStripItem)BtnOth).BackColor = Color.Transparent;
		((ToolStripItem)BtnSchm).BackColor = Color.Transparent;
		((ToolStripItem)BtnRpt).BackColor = Color.Transparent;
		((ToolStripItem)BtnDhrn).BackColor = Color.Transparent;
		((ToolStripItem)BtnMfg).BackColor = Color.Transparent;
		((ToolStripItem)BtnExit).BackColor = Color.Transparent;
		((ToolStripItem)btnHome).ForeColor = Color.White;
		((ToolStripItem)BtnComp).ForeColor = Color.White;
		((ToolStripItem)BtnMast).ForeColor = Color.White;
		((ToolStripItem)BtnTran).ForeColor = Color.White;
		((ToolStripItem)BtnTran2).ForeColor = Color.White;
		((ToolStripItem)BtnKrgr).ForeColor = Color.White;
		((ToolStripItem)BtnOth).ForeColor = Color.White;
		((ToolStripItem)BtnSchm).ForeColor = Color.White;
		((ToolStripItem)BtnRpt).ForeColor = Color.White;
		((ToolStripItem)BtnDhrn).ForeColor = Color.White;
		((ToolStripItem)BtnMfg).ForeColor = Color.White;
		((ToolStripItem)BtnExit).ForeColor = Color.White;
	}

	private void MDI_FORM_Load(object sender, EventArgs e)
	{
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		FirstTimeLodMdi = true;
		string path = DC_Main.MSImageSavePath + "\\DhranImage";
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		string path2 = DC_Main.MSImageSavePath + "\\AcImage";
		if (!Directory.Exists(path2))
		{
			Directory.CreateDirectory(path2);
		}
		string path3 = DC_Main.MSImageSavePath + "\\SmallImage";
		if (!Directory.Exists(path3))
		{
			Directory.CreateDirectory(path3);
		}
		string path4 = DC_Main.MSImageSavePath + "\\ReparingImage";
		if (!Directory.Exists(path4))
		{
			Directory.CreateDirectory(path4);
		}
		string path5 = DC_Main.MSImageSavePath + "\\FtpImage";
		if (!Directory.Exists(path5))
		{
			Directory.CreateDirectory(path5);
		}
		string path6 = DC_Main.MSImageSavePath + "\\SchemeImg";
		if (!Directory.Exists(path6))
		{
			Directory.CreateDirectory(path6);
		}
		((Control)this).SuspendLayout();
		((Control)this).ResumeLayout();
		double num = (DC_Main.PcW - DC_Main.MainPcW) / DC_Main.MainPcW;
		double num2 = (DC_Main.PcH - DC_Main.MainPcH) / DC_Main.MainPcH;
		DC_Main.ScreenHight = 1.0 + num2;
		checked
		{
			DC_Main.HaderFont = (int)Math.Round(9.0 * DC_Main.ScreenHight);
			ColCon = 1.0 + num;
			double num3 = 1.0 + num2;
			foreach (Control control in ((Control)this).Controls)
			{
				Control val = control;
				Control val2;
				(val2 = val).Width = val2.Width + (int)Math.Round((double)val.Width * num);
				(val2 = val).Height = val2.Height + (int)Math.Round((double)val.Height * num2);
				(val2 = val).Left = val2.Left + (int)Math.Round((double)val.Left * num);
				(val2 = val).Top = val2.Top + (int)Math.Round((double)val.Top * num2);
			}
			foreach (object control2 in ((Control)SideTrip).Controls)
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
			foreach (object control3 in ((Control)PanelImage).Controls)
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
			foreach (object control4 in ((Control)PnlBotam).Controls)
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
			((ToolStripControlHost)mMainDt).Text = Strings.Format((object)DateAndTime.Now, "dd/MM/yyyy");
			DC_Main.MsSysDate = Conversions.ToDate(((ToolStripControlHost)mMainDt).Text);
			tAmcDate.Text = "Service End :  " + Strings.Format((object)DC_Main.AmcEndDate, "dd/MM/yyyy");
			tSoftDemoType.Text = DC_Main.MsSoftDemoName;
			Module_Schm.bgWorker.WorkerReportsProgress = true;
			Module_Schm.bgWorker.WorkerSupportsCancellation = true;
			if (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT * FROM BOOK_IDTL WHERE SR_NO = 150";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					Module_Schm.SchmServerIp = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_BOOK"], (object)""));
					Module_Schm.SchmServerPwd = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SVR_PWD"], (object)""));
					Module_Schm.SchmServerDb = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM025NSDM", false) == 0 && DateTime.Compare(DateAndTime.Now, Conversions.ToDate("26/08/2024")) < 0)
			{
				DC_Main.MsSoftType = "E";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS138NPBU", false) == 0 && DateTime.Compare(DateAndTime.Now, Conversions.ToDate("20/11/2024")) < 0)
			{
				DC_Main.MsSoftType = "E";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM241NSHP", false) == 0 && DateTime.Compare(DateAndTime.Now, Conversions.ToDate("22/12/2024")) < 0)
			{
				DC_Main.MsSoftType = "E";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS161NSVS", false) == 0 && DateTime.Compare(DateAndTime.Now, Conversions.ToDate("02/01/2025")) < 0)
			{
				DC_Main.MsSoftType = "A";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM053NSDM", false) == 0 && DateTime.Compare(DateAndTime.Now, Conversions.ToDate("12/03/2025")) < 0)
			{
				DC_Main.MsSoftType = "E";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM058NUDM", false) == 0 && DateTime.Compare(DateAndTime.Now, Conversions.ToDate("25/05/2025")) < 0)
			{
				DC_Main.MsSoftType = "U";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM093NBDM", false) == 0 && DateTime.Compare(DateAndTime.Now, Conversions.ToDate("27/09/2025")) < 0)
			{
				DC_Main.MsSoftType = "E";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK005NPAK", false) == 0 && DateTime.Compare(DateAndTime.Now, Conversions.ToDate("25/11/2025")) < 0)
			{
				DC_Main.MsSoftType = "A";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM147NEKU", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APTHNU028JJY0K0Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APPJEH0D8JJ80FIZ", false) == 0)))
			{
				DC_Main.MsSoftType = "P";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS288NEBU", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2G6QZ4Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A Z", false) == 0)))
			{
				DC_Main.MsSoftType = "P";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS288NEBU", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/953XBZ2/CNFCW0097502A5/Z", false) == 0)
			{
				DC_Main.MsSoftType = "P";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS084NEBU", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/G1L83F3/CNCMK0017E06AC/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/J5W2813/CNPE1009A70A2G/Z", false) == 0)))
			{
				DC_Main.MsSoftType = "U";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ005NEKJ", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APGXAR038JC53IEZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.3YZ4D32.CN7620653J05H2.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APDXVV00WB7X0COZ", false) == 0)))
			{
				DC_Main.MsSoftType = "P";
			}
			if ((Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0) & (Operators.CompareString(DC_Main.MsMainFontChange, "N", false) == 0))
			{
				SideMenuFontSize();
			}
			if (Operators.CompareString(DC_Main.MsMfgType, "J", false) == 0)
			{
				((ToolStripItem)BtnMfg).Text = "Jadtar";
				if (Strings.Len(DC_Main.SSRegSrNo) == 1)
				{
					DC_Main.MsSoftType = "S";
				}
			}
			else if (Operators.CompareString(DC_Main.MsMfgType, "M", false) == 0)
			{
				((ToolStripItem)BtnMfg).Text = "Mfg";
				if (Strings.Len(DC_Main.SSRegSrNo) == 1)
				{
					DC_Main.MsSoftType = "S";
				}
			}
			else
			{
				((ToolStripItem)BtnMfg).Visible = false;
				((ToolStripItem)Sp9).Visible = false;
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "I", false) == 0 && Strings.Len(DC_Main.SSRegSrNo) == 1)
			{
				DC_Main.MsSoftType = "S";
			}
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
				if (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0)
				{
					((Control)LblUserRequest).Visible = true;
				}
				((AccordionControlElementBase)SLMain).Text = "Enterprise";
				((ToolStripItem)F2CtrlOrderZoomToolStripMenuItem).Visible = true;
				DC_Main.RsQry = "Select * From MENU_DATA WHERE SM_MAIN_CODE <> '00' AND SM_VIEW = 'Y' AND SM_TYPE IN ('E','A','P','U','S','B','L') ORDER BY BTN_NAME,SM_CODE";
			}
			else if (Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0)
			{
				((AccordionControlElementBase)SLMain).Text = "Advance";
				((ToolStripItem)F2CtrlOrderZoomToolStripMenuItem).Visible = true;
				DC_Main.RsQry = "Select * From MENU_DATA WHERE SM_MAIN_CODE <> '00' AND SM_VIEW = 'Y' AND SM_TYPE IN ('A','P','U','S','B','L') ORDER BY BTN_NAME,SM_CODE";
			}
			else if (Operators.CompareString(DC_Main.MsSoftType, "P", false) == 0)
			{
				((AccordionControlElementBase)SLMain).Text = "Pro";
				((ToolStripItem)F2CtrlOrderZoomToolStripMenuItem).Visible = true;
				DC_Main.RsQry = "Select * From MENU_DATA WHERE SM_MAIN_CODE <> '00' AND SM_VIEW = 'Y' AND SM_TYPE IN ('P','U','S','B','L') ORDER BY BTN_NAME,SM_CODE";
			}
			else if (Operators.CompareString(DC_Main.MsSoftType, "U", false) == 0)
			{
				((AccordionControlElementBase)SLMain).Text = "Ultra";
				DC_Main.RsQry = "Select * From MENU_DATA WHERE SM_MAIN_CODE <> '00' AND SM_VIEW = 'Y' AND SM_TYPE IN ('U','S','B','L') ORDER BY BTN_NAME,SM_CODE";
				((ToolStripItem)BtnDhrn).Visible = false;
				((ToolStripItem)Sp8).Visible = false;
			}
			else if (Operators.CompareString(DC_Main.MsSoftType, "S", false) == 0)
			{
				((AccordionControlElementBase)SLMain).Text = "Standard";
				DC_Main.RsQry = "Select * From MENU_DATA WHERE SM_MAIN_CODE <> '00' AND SM_VIEW = 'Y' AND SM_TYPE IN ('S','B','L') ORDER BY BTN_NAME,SM_CODE";
				((ToolStripItem)BtnSchm).Visible = false;
				((ToolStripItem)Sp7).Visible = false;
				((ToolStripItem)BtnDhrn).Visible = false;
				((ToolStripItem)Sp8).Visible = false;
			}
			else if (Operators.CompareString(DC_Main.MsSoftType, "B", false) == 0)
			{
				((AccordionControlElementBase)SLMain).Text = "Basic";
				DC_Main.RsQry = "Select * From MENU_DATA WHERE SM_MAIN_CODE <> '00' AND SM_VIEW = 'Y' AND SM_TYPE IN ('B','L') ORDER BY BTN_NAME,SM_CODE";
				((ToolStripItem)BtnSchm).Visible = false;
				((ToolStripItem)Sp7).Visible = false;
				((ToolStripItem)BtnDhrn).Visible = false;
				((ToolStripItem)Sp8).Visible = false;
			}
			else if (Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0)
			{
				((AccordionControlElementBase)SLMain).Text = "Lite";
				DC_Main.RsQry = "Select * From MENU_DATA WHERE SM_MAIN_CODE <> '00' AND SM_VIEW = 'Y' AND SM_TYPE = 'L' ORDER BY BTN_NAME,SM_CODE";
				((ToolStripItem)BtnKrgr).Visible = false;
				((ToolStripItem)Sp4).Visible = false;
				((ToolStripItem)BtnKrgr).Visible = false;
				((ToolStripItem)Sp5).Visible = false;
				((ToolStripItem)BtnSchm).Visible = false;
				((ToolStripItem)Sp7).Visible = false;
				((ToolStripItem)BtnDhrn).Visible = false;
			}
			RsMenu = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			if (Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0)
			{
				((ToolStripItem)ShoF10Reminder).Visible = false;
				((ToolStripItem)ShoF11Rojmel).Visible = false;
				((ToolStripItem)btnHome).Visible = false;
				((ToolStripItem)ToolStripSeparator2).Visible = false;
			}
			else if (Operators.CompareString(DC_Main.MsSoftType, "B", false) == 0)
			{
				((AccordionControlElementBase)SLMain3).Visible = false;
			}
			else if (Operators.CompareString(DC_Main.MsSoftType, "S", false) == 0)
			{
				((AccordionControlElementBase)SLMain3).Visible = false;
			}
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				((ToolStripItem)BtnSchm).Visible = false;
				((ToolStripItem)Sp7).Visible = false;
				if (Operators.CompareString(DC_Main.SSRegSrNo, "VK281NAST", false) != 0)
				{
					((ToolStripItem)BtnDhrn).Visible = false;
					((ToolStripItem)Sp8).Visible = false;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK035NLVK", false) == 0)
			{
				((ToolStripItem)btnHome).Visible = true;
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM428NAKU", false) == 0)
			{
				DC_Main.MsBillProfit = "Y";
			}
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM594NEKU", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0))
			{
				((Control)chkLiveRate).Visible = false;
				((Control)lblLiveRate).Visible = false;
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK195NEPH", false) == 0)
			{
				((ToolStripItem)BtnSchm).Visible = false;
				((ToolStripItem)Sp7).Visible = false;
				((ToolStripItem)BtnDhrn).Visible = false;
				((ToolStripItem)Sp8).Visible = false;
			}
			DC_Main.RsQry = "SELECT LC_CODE FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count <= 1)
			{
				LcMenuOpen = "N";
			}
			else
			{
				LcMenuOpen = "Y";
			}
			Side_Menu_Fill();
			Country_Rate();
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				((Control)chkLiveRate).Visible = false;
				((Control)lblLiveRate).Visible = false;
			}
			cboTheme.Items.Add((object)"Orange");
			cboTheme.Items.Add((object)"Dark");
			cboTheme.Items.Add((object)"Blue");
			cboTheme.Items.Add((object)"Green");
			if (DC_Main.MsCoTheme == 1)
			{
				cboTheme.SelectedIndex = 0;
			}
			if (DC_Main.MsCoTheme == 2)
			{
				cboTheme.SelectedIndex = 1;
			}
			if (DC_Main.MsCoTheme == 3)
			{
				cboTheme.SelectedIndex = 2;
			}
			if (DC_Main.MsCoTheme == 4)
			{
				cboTheme.SelectedIndex = 3;
			}
			DC_Main.Rshlp.Clear();
			((Control)PanelImage).Dock = (DockStyle)5;
			((Control)PanelImage).Visible = true;
			DC_Main.RsQry = "SELECT A.GR_CODE,A.GR_RATE,B.GR_NAME FROM RATE_MAST AS A INNER JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.VCH_DATE = '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "' AND B.RATE_DISPLAY = 'Y' ORDER BY A.SR_NO";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.M = 0;
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				((Control)Rate_1).Visible = true;
				Rate_1.Text = "ToDays Rate :";
			}
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				if (DC_Main.M == 0)
				{
					((Control)Rate_1).Visible = true;
					Rate_1.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));
				}
				if (DC_Main.M == 1)
				{
					((Control)Rate_2).Visible = true;
					Rate_2.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));
				}
				if (DC_Main.M == 2)
				{
					((Control)Rate_3).Visible = true;
					Rate_3.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));
				}
				if (DC_Main.M == 3)
				{
					((Control)Rate_4).Visible = true;
					Rate_4.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));
				}
				if (DC_Main.M == 4)
				{
					((Control)Rate_5).Visible = true;
					Rate_5.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));
				}
				if (DC_Main.M == 5)
				{
					((Control)Rate_6).Visible = true;
					Rate_6.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));
				}
				if (DC_Main.M == 6)
				{
					((Control)Rate_7).Visible = true;
					Rate_7.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"], (object)"  -  "), (object)Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["GR_RATE"]), "0.00")));
				}
				DC_Main.M++;
			}
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0 && DC_Main.MsYearGoldSl + DC_Main.MsYearSilverSl != 0.0)
			{
				((Control)LblGoldSl).Visible = true;
				((Control)LblSilverSl).Visible = true;
				if (DC_Main.MsYearGoldSl != 0.0)
				{
					LblGoldSl.Text = "Gold Target Gm : " + Strings.Format((object)Math.Round(DC_Main.MsYearGoldSl / 12.0 * 1000.0, 0), "0.00");
				}
				if (DC_Main.MsYearSilverSl != 0.0)
				{
					LblSilverSl.Text = "Silver Target Gm : " + Strings.Format((object)Math.Round(DC_Main.MsYearSilverSl / 12.0 * 1000.0, 0), "0.00");
				}
				double num4 = 0.0;
				double num5 = 0.0;
				DC_Main.RsQry = "SELECT B.IT_TYPE,SUM(CASE WHEN ITM_SIGN = '-' THEN ITM_NWT ELSE 0 END) As SlWt FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND C.MAIN_BOOK IN ('WH SALES','SALES','LABOUR WORK','SALES RETURNE','TOUR SALES') AND A.IT_CODE NOT IN ('999','OG','FSL','OS') AND MONTH(VCH_DATE) = " + Conversions.ToString(DateAndTime.Month(DateAndTime.Now)) + " GROUP BY B.IT_TYPE ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				int num6 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num6)
				{
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["IT_TYPE"], (object)""), (object)"G", false))
					{
						num4 += Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["SlWt"])), "0.000"));
					}
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["IT_TYPE"], (object)""), (object)"S", false))
					{
						num5 += Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["SlWt"])), "0.000"));
					}
					DC_Main.M++;
				}
				if (DC_Main.MsYearGoldSl != 0.0)
				{
					LblGoldSl.Text = " Gold Target Gm : " + Strings.Format((object)Math.Round(DC_Main.MsYearGoldSl / 12.0 * 1000.0, 0), "0.00") + "    Sales : " + Strings.Format((object)num4, "0.00") + "  Diff  : " + Strings.Format((object)(num4 - Conversions.ToDouble(Strings.Format((object)Math.Round(DC_Main.MsYearGoldSl / 12.0 * 1000.0, 0), "0.00"))), "0.00");
				}
				if (DC_Main.MsYearSilverSl != 0.0)
				{
					LblSilverSl.Text = "Silver Target Gm : " + Strings.Format((object)Math.Round(DC_Main.MsYearSilverSl / 12.0 * 1000.0, 0), "0.00") + "  Sales : " + Strings.Format((object)num5, "0.00") + "  Diff  : " + Strings.Format((object)(num5 - Conversions.ToDouble(Strings.Format((object)Math.Round(DC_Main.MsYearSilverSl / 12.0 * 1000.0, 0), "0.00"))), "0.00");
				}
			}
			FirstTimeLodMdi = false;
			TileMenuOpen = true;
			if (Operators.CompareString(DC_Main.MsReminderOpen, "Y", false) == 0)
			{
				DC_Main.MsUserRightForm = "Reminder Rpt";
				RP_REMINDER rP_REMINDER = new RP_REMINDER();
				((Form)rP_REMINDER).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_REMINDER).Text = "Reminder Rpt " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_REMINDER).Show();
				((Control)rP_REMINDER).Focus();
				PanalImage_Hide();
			}
			if (DC_Main.MsDailyRateGen)
			{
				DC_Main.MsUserRightForm = "Daily Rate";
				MS_RATE mS_RATE = new MS_RATE();
				((Form)mS_RATE).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)mS_RATE).Text = "Rate Mast " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)mS_RATE).Show();
				((Control)mS_RATE).Focus();
				PanalImage_Hide();
			}
			if (Operators.CompareString(Module_Schm.SchmServerIp, "", false) != 0)
			{
				myTimer.Interval = 300000;
				myTimer.Start();
			}
		}
	}

	private void Side_Menu_Fill()
	{
		DataView dataView = new DataView(RsMenu);
		dataView.RowFilter = "BTN_NAME = '" + DC_Main.MsMainBtn + "'";
		checked
		{
			if (dataView.Count > 0)
			{
				((AccordionControlElementBase)SL0).Visible = false;
				((AccordionControlElementBase)SL1).Visible = false;
				((AccordionControlElementBase)SL2).Visible = false;
				((AccordionControlElementBase)SL3).Visible = false;
				((AccordionControlElementBase)SL4).Visible = false;
				((AccordionControlElementBase)SL5).Visible = false;
				((AccordionControlElementBase)SL6).Visible = false;
				((AccordionControlElementBase)SL7).Visible = false;
				((AccordionControlElementBase)SL8).Visible = false;
				((AccordionControlElementBase)SL9).Visible = false;
				((AccordionControlElementBase)SL10).Visible = false;
				((AccordionControlElementBase)SL11).Visible = false;
				((AccordionControlElementBase)SL12).Visible = false;
				((AccordionControlElementBase)SL13).Visible = false;
				((AccordionControlElementBase)SL14).Visible = false;
				((AccordionControlElementBase)SL15).Visible = false;
				((AccordionControlElementBase)SL16).Visible = false;
				((AccordionControlElementBase)SL17).Visible = false;
				((AccordionControlElementBase)SL18).Visible = false;
				((AccordionControlElementBase)SL19).Visible = false;
				((AccordionControlElementBase)SL20).Visible = false;
				((AccordionControlElementBase)SL21).Visible = false;
				((AccordionControlElementBase)SL22).Visible = false;
				((AccordionControlElementBase)SL23).Visible = false;
				((AccordionControlElementBase)SL24).Visible = false;
				((AccordionControlElementBase)SL25).Visible = false;
				((AccordionControlElementBase)SL26).Visible = false;
				((AccordionControlElementBase)SL27).Visible = false;
				((AccordionControlElementBase)SL28).Visible = false;
				((AccordionControlElementBase)SL29).Visible = false;
				((AccordionControlElementBase)SL30).Visible = false;
				((AccordionControlElementBase)SL31).Visible = false;
				((AccordionControlElementBase)SL32).Visible = false;
				((AccordionControlElementBase)SL33).Visible = false;
				((AccordionControlElementBase)SL34).Visible = false;
				((AccordionControlElementBase)SL35).Visible = false;
				int num = dataView.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 35.0)
					{
						((AccordionControlElementBase)SL35).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL35).Visible = true;
						((AccordionControlElementBase)SL35).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 34.0)
					{
						((AccordionControlElementBase)SL34).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL34).Visible = true;
						((AccordionControlElementBase)SL34).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 33.0)
					{
						((AccordionControlElementBase)SL33).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL33).Visible = true;
						((AccordionControlElementBase)SL33).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 32.0)
					{
						((AccordionControlElementBase)SL32).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL32).Visible = true;
						((AccordionControlElementBase)SL32).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 31.0)
					{
						((AccordionControlElementBase)SL31).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL31).Visible = true;
						((AccordionControlElementBase)SL31).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 30.0)
					{
						((AccordionControlElementBase)SL30).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL30).Visible = true;
						((AccordionControlElementBase)SL30).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 29.0)
					{
						((AccordionControlElementBase)SL29).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL29).Visible = true;
						((AccordionControlElementBase)SL29).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 28.0)
					{
						((AccordionControlElementBase)SL28).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL28).Visible = true;
						((AccordionControlElementBase)SL28).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 27.0)
					{
						((AccordionControlElementBase)SL27).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL27).Visible = true;
						((AccordionControlElementBase)SL27).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 26.0)
					{
						((AccordionControlElementBase)SL26).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL26).Visible = true;
						((AccordionControlElementBase)SL26).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 25.0)
					{
						((AccordionControlElementBase)SL25).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL25).Visible = true;
						((AccordionControlElementBase)SL25).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 24.0)
					{
						((AccordionControlElementBase)SL24).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL24).Visible = true;
						((AccordionControlElementBase)SL24).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 23.0)
					{
						((AccordionControlElementBase)SL23).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL23).Visible = true;
						((AccordionControlElementBase)SL23).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 22.0)
					{
						((AccordionControlElementBase)SL22).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL22).Visible = true;
						((AccordionControlElementBase)SL22).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 21.0)
					{
						((AccordionControlElementBase)SL21).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL21).Visible = true;
						((AccordionControlElementBase)SL21).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 20.0)
					{
						((AccordionControlElementBase)SL20).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL20).Visible = true;
						((AccordionControlElementBase)SL20).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 19.0)
					{
						((AccordionControlElementBase)SL19).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL19).Visible = true;
						((AccordionControlElementBase)SL19).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 18.0)
					{
						((AccordionControlElementBase)SL18).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL18).Visible = true;
						((AccordionControlElementBase)SL18).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 17.0)
					{
						((AccordionControlElementBase)SL17).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL17).Visible = true;
						((AccordionControlElementBase)SL17).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 16.0)
					{
						((AccordionControlElementBase)SL16).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL16).Visible = true;
						((AccordionControlElementBase)SL16).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 15.0)
					{
						((AccordionControlElementBase)SL15).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL15).Visible = true;
						((AccordionControlElementBase)SL15).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 14.0)
					{
						((AccordionControlElementBase)SL14).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL14).Visible = true;
						((AccordionControlElementBase)SL14).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 13.0)
					{
						((AccordionControlElementBase)SL13).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL13).Visible = true;
						((AccordionControlElementBase)SL13).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 12.0)
					{
						((AccordionControlElementBase)SL12).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL12).Visible = true;
						((AccordionControlElementBase)SL12).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 11.0)
					{
						((AccordionControlElementBase)SL11).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL11).Visible = true;
						((AccordionControlElementBase)SL11).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 10.0)
					{
						((AccordionControlElementBase)SL10).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL10).Visible = true;
						((AccordionControlElementBase)SL10).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 9.0)
					{
						((AccordionControlElementBase)SL9).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL9).Visible = true;
						((AccordionControlElementBase)SL9).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 8.0)
					{
						((AccordionControlElementBase)SL8).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL8).Visible = true;
						((AccordionControlElementBase)SL8).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 7.0)
					{
						((AccordionControlElementBase)SL7).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL7).Visible = true;
						((AccordionControlElementBase)SL7).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 6.0)
					{
						((AccordionControlElementBase)SL6).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL6).Visible = true;
						((AccordionControlElementBase)SL6).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 5.0)
					{
						((AccordionControlElementBase)SL5).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL5).Visible = true;
						((AccordionControlElementBase)SL5).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 4.0)
					{
						((AccordionControlElementBase)SL4).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL4).Visible = true;
						((AccordionControlElementBase)SL4).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 3.0)
					{
						((AccordionControlElementBase)SL3).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL3).Visible = true;
						((AccordionControlElementBase)SL3).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 2.0)
					{
						((AccordionControlElementBase)SL2).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL2).Visible = true;
						((AccordionControlElementBase)SL2).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 1.0)
					{
						((AccordionControlElementBase)SL1).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL1).Visible = true;
						((AccordionControlElementBase)SL1).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 0.0)
					{
						((AccordionControlElementBase)SL0).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL0).Visible = true;
						((AccordionControlElementBase)SL0).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					DC_Main.M++;
				}
			}
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
			}
			if (Operators.CompareString(DC_Main.MsBulProcess, "N", false) == 0 && Operators.CompareString(DC_Main.MsMainBtn, "Transaction", false) == 0)
			{
				if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
				{
					((AccordionControlElementBase)SL18).Visible = false;
					((AccordionControlElementBase)SL19).Visible = false;
					((AccordionControlElementBase)SL20).Visible = false;
					((AccordionControlElementBase)SL21).Visible = false;
				}
				else
				{
					((AccordionControlElementBase)SL17).Visible = false;
					((AccordionControlElementBase)SL18).Visible = false;
					((AccordionControlElementBase)SL19).Visible = false;
					((AccordionControlElementBase)SL20).Visible = false;
				}
			}
			if (Operators.CompareString(DC_Main.MsAppDgGold, "Y", false) != 0 && Operators.CompareString(DC_Main.MsMainBtn, "Scheme", false) == 0)
			{
				((AccordionControlElementBase)SL13).Visible = false;
				((AccordionControlElementBase)SL14).Visible = false;
				((AccordionControlElementBase)SL15).Visible = false;
				((AccordionControlElementBase)SL16).Visible = false;
			}
			if (Operators.CompareString(LcMenuOpen, "N", false) == 0)
			{
				if (Operators.CompareString(DC_Main.MsMainBtn, "Transaction", false) == 0)
				{
					if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
					{
						((AccordionControlElementBase)SL16).Visible = false;
						((AccordionControlElementBase)SL17).Visible = false;
						((AccordionControlElementBase)SL21).Visible = false;
					}
					else
					{
						((AccordionControlElementBase)SL15).Visible = false;
						((AccordionControlElementBase)SL16).Visible = false;
						((AccordionControlElementBase)SL20).Visible = false;
					}
				}
				if (Operators.CompareString(DC_Main.MsMainBtn, "ExtraTran", false) == 0)
				{
					if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
					{
						((AccordionControlElementBase)SL15).Visible = false;
						((AccordionControlElementBase)SL16).Visible = false;
					}
					else
					{
						((AccordionControlElementBase)SL15).Visible = false;
						((AccordionControlElementBase)SL16).Visible = false;
					}
				}
				if (Operators.CompareString(DC_Main.MsMainBtn, "Scheme", false) == 0)
				{
					((AccordionControlElementBase)SL25).Visible = false;
					((AccordionControlElementBase)SL26).Visible = false;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM122NEPK", false) == 0 && Operators.CompareString(DC_Main.MsMainBtn, "Scheme", false) == 0)
			{
				((AccordionControlElementBase)SL25).Visible = true;
			}
			if (Operators.CompareString(DC_Main.MsWhatsAppOpen, "N", false) == 0 && Operators.CompareString(DC_Main.MsMainBtn, "Other", false) == 0)
			{
				((AccordionControlElementBase)SL20).Visible = false;
			}
			if (Operators.CompareString(((AccordionControlElementBase)SL15).Hint, "Data Import", false) == 0)
			{
				((AccordionControlElementBase)SL15).Visible = false;
			}
			if (Operators.CompareString(((AccordionControlElementBase)SL35).Hint, "Estimate Reset", false) == 0)
			{
				((AccordionControlElementBase)SL35).Visible = false;
			}
			if (Operators.CompareString(((AccordionControlElementBase)SL34).Hint, "Data Export", false) == 0)
			{
				((AccordionControlElementBase)SL34).Visible = false;
			}
			if (Operators.CompareString(DC_Main.MsMainBtn, "Other", false) == 0)
			{
				((AccordionControlElementBase)SL25).Visible = false;
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM360NAPK", false) == 0 && Operators.CompareString(DC_Main.MsMainBtn, "Dhiran", false) == 0)
			{
				((AccordionControlElementBase)SL4).Visible = false;
				((AccordionControlElementBase)SL5).Visible = false;
				((AccordionControlElementBase)SL6).Visible = false;
				((AccordionControlElementBase)SL7).Visible = false;
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS280NUBU", false) == 0)
			{
				DC_Main.MsPurcLot = "Y";
				if (Operators.CompareString(DC_Main.MsMainBtn, "Master", false) == 0)
				{
					((AccordionControlElementBase)SL12).Visible = true;
					((AccordionControlElementBase)SL12).Text = "Lot Opening";
					((AccordionControlElementBase)SL12).Hint = "Lot Opening";
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK197NSVK", false) == 0 && Operators.CompareString(DC_Main.MsMainBtn, "Master", false) == 0)
			{
				((AccordionControlElementBase)SL20).Visible = true;
				((AccordionControlElementBase)SL20).Text = "Labour Disc";
				((AccordionControlElementBase)SL20).Hint = "Labour Disc";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK219NLVK", false) == 0 && Operators.CompareString(DC_Main.MsMainBtn, "Report", false) == 0)
			{
				((AccordionControlElementBase)SL12).Visible = true;
				((AccordionControlElementBase)SL12).Text = "Tag Estmate";
				((AccordionControlElementBase)SL12).Hint = "Tag Estmate";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK222NAPH", false) == 0 && Operators.CompareString(DC_Main.MsMainBtn, "Other", false) == 0)
			{
				((AccordionControlElementBase)SL12).Visible = true;
				((AccordionControlElementBase)SL12).Text = "Ledger Adjust";
				((AccordionControlElementBase)SL12).Hint = "Ledger Adjust";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM029NADM", false) == 0 && Operators.CompareString(DC_Main.MsMainBtn, "ExtraTran", false) == 0)
			{
				((AccordionControlElementBase)SL17).Visible = true;
				((AccordionControlElementBase)SL17).Text = "Fine Purc";
				((AccordionControlElementBase)SL17).Hint = "Fine Purc";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS136NSBU", false) == 0 && Operators.CompareString(DC_Main.MsMainBtn, "Other", false) == 0)
			{
				((AccordionControlElementBase)SL34).Visible = true;
				((AccordionControlElementBase)SL34).Text = "Data Export";
				((AccordionControlElementBase)SL34).Hint = "Data Export";
			}
			((Control)SideTrip).Focus();
		}
	}

	private void SideMenuFontSize()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Expected O, but got Unknown
		((ToolStripControlHost)mMainDt).Font = new Font("Bahnschrift SemiBold", 15f, DC_Main.MsFontStyle);
		((ToolStripItem)btnHome).Font = new Font("Bahnschrift SemiBold", 15f, DC_Main.MsFontStyle);
		((ToolStripItem)BtnComp).Font = new Font("Bahnschrift SemiBold", 15f, DC_Main.MsFontStyle);
		((ToolStripItem)BtnMast).Font = new Font("Bahnschrift SemiBold", 15f, DC_Main.MsFontStyle);
		((ToolStripItem)BtnTran).Font = new Font("Bahnschrift SemiBold", 15f, DC_Main.MsFontStyle);
		((ToolStripItem)BtnTran2).Font = new Font("Bahnschrift SemiBold", 15f, DC_Main.MsFontStyle);
		((ToolStripItem)BtnOth).Font = new Font("Bahnschrift SemiBold", 15f, DC_Main.MsFontStyle);
		((ToolStripItem)BtnKrgr).Font = new Font("Bahnschrift SemiBold", 15f, DC_Main.MsFontStyle);
		((ToolStripItem)BtnRpt).Font = new Font("Bahnschrift SemiBold", 15f, DC_Main.MsFontStyle);
		((ToolStripItem)BtnSchm).Font = new Font("Bahnschrift SemiBold", 15f, DC_Main.MsFontStyle);
		((ToolStripItem)BtnDhrn).Font = new Font("Bahnschrift SemiBold", 15f, DC_Main.MsFontStyle);
		((ToolStripItem)BtnMfg).Font = new Font("Bahnschrift SemiBold", 15f, DC_Main.MsFontStyle);
		((ToolStripItem)BtnExit).Font = new Font("Bahnschrift SemiBold", 15f, DC_Main.MsFontStyle);
	}

	private void SLMain_Click(object sender, EventArgs e)
	{
		if (!((AccordionControlElementBase)SLMain).Expanded)
		{
			((AccordionControlElementBase)SLMain).Expanded = true;
		}
		else
		{
			((AccordionControlElementBase)SLMain).Expanded = false;
		}
	}

	private void SL0_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL0).Hint;
		AllBtn();
	}

	private void SL1_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL1).Hint;
		AllBtn();
	}

	private void SL2_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL2).Hint;
		AllBtn();
	}

	private void SL3_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL3).Hint;
		AllBtn();
	}

	private void SL4_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL4).Hint;
		AllBtn();
	}

	private void SL5_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL5).Hint;
		AllBtn();
	}

	private void SL6_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL6).Hint;
		AllBtn();
	}

	private void SL7_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL7).Hint;
		AllBtn();
	}

	private void SL8_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL8).Hint;
		AllBtn();
	}

	private void SL9_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL9).Hint;
		AllBtn();
	}

	private void SL10_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL10).Hint;
		AllBtn();
	}

	private void SL11_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL11).Hint;
		AllBtn();
	}

	private void SL12_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL12).Hint;
		AllBtn();
	}

	private void SL13_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL13).Hint;
		AllBtn();
	}

	private void SL14_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL14).Hint;
		AllBtn();
	}

	private void SL15_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL15).Hint;
		AllBtn();
	}

	private void SL16_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL16).Hint;
		AllBtn();
	}

	private void SL17_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL17).Hint;
		AllBtn();
	}

	private void SL18_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL18).Hint;
		AllBtn();
	}

	private void SL19_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL19).Hint;
		AllBtn();
	}

	private void SL20_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL20).Hint;
		AllBtn();
	}

	private void SL21_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL21).Hint;
		AllBtn();
	}

	private void SL22_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL22).Hint;
		AllBtn();
	}

	private void SL23_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL23).Hint;
		AllBtn();
	}

	private void SL24_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL24).Hint;
		AllBtn();
	}

	private void SL25_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL25).Hint;
		AllBtn();
	}

	private void SL26_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL26).Hint;
		AllBtn();
	}

	private void SL27_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL27).Hint;
		AllBtn();
	}

	private void SL28_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL28).Hint;
		AllBtn();
	}

	private void SL29_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL29).Hint;
		AllBtn();
	}

	private void SL30_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL30).Hint;
		AllBtn();
	}

	private void SL31_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL31).Hint;
		AllBtn();
	}

	private void SL32_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL32).Hint;
		AllBtn();
	}

	private void SL33_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL33).Hint;
		AllBtn();
	}

	private void SL34_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL34).Hint;
		AllBtn();
	}

	private void SL35_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL35).Hint;
		AllBtn();
	}

	private void SL51_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL51).Hint;
		Analysis_Form();
	}

	private void SL52_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL52).Hint;
		Analysis_Form();
	}

	private void SL53_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL53).Hint;
		Analysis_Form();
	}

	private void SL54_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL54).Hint;
		Analysis_Form();
	}

	private void SL55_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL55).Hint;
		Analysis_Form();
	}

	private void SL56_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL56).Hint;
		Analysis_Form();
	}

	private void SL57_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL57).Hint;
		Analysis_Form();
	}

	private void SL58_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL58).Hint;
		Analysis_Form();
	}

	private void SL59_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL59).Hint;
		Analysis_Form();
	}

	private void SL60_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL60).Hint;
		Analysis_Form();
	}

	private void SL61_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL61).Hint;
		Analysis_Form();
	}

	private void SL62_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL62).Hint;
		Analysis_Form();
	}

	private void SL63_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL63).Hint;
		Analysis_Form();
	}

	private void SL64_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL64).Hint;
		Analysis_Form();
	}

	private void SL65_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL65).Hint;
		Analysis_Form();
	}

	private void MDI_FORM_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Invalid comparison between Unknown and I4
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Invalid comparison between Unknown and I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Invalid comparison between Unknown and I4
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Invalid comparison between Unknown and I4
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Invalid comparison between Unknown and I4
		//IL_0a35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4b: Invalid comparison between Unknown and I4
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Invalid comparison between Unknown and I4
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Invalid comparison between Unknown and I4
		//IL_0a4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5c: Invalid comparison between Unknown and I4
		//IL_0352: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Invalid comparison between Unknown and I4
		//IL_0586: Unknown result type (might be due to invalid IL or missing references)
		//IL_058d: Invalid comparison between Unknown and I4
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Invalid comparison between Unknown and I4
		//IL_0a5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6d: Invalid comparison between Unknown and I4
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Invalid comparison between Unknown and I4
		//IL_0647: Unknown result type (might be due to invalid IL or missing references)
		//IL_064e: Invalid comparison between Unknown and I4
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Invalid comparison between Unknown and I4
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Invalid comparison between Unknown and I4
		//IL_068e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0695: Invalid comparison between Unknown and I4
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Invalid comparison between Unknown and I4
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Invalid comparison between Unknown and I4
		//IL_06b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b7: Invalid comparison between Unknown and I4
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Invalid comparison between Unknown and I4
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Invalid comparison between Unknown and I4
		//IL_06d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d9: Invalid comparison between Unknown and I4
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Invalid comparison between Unknown and I4
		//IL_0d94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9e: Expected O, but got Unknown
		//IL_0438: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Invalid comparison between Unknown and I4
		//IL_06f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fb: Invalid comparison between Unknown and I4
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Invalid comparison between Unknown and I4
		//IL_0466: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Invalid comparison between Unknown and I4
		//IL_0716: Unknown result type (might be due to invalid IL or missing references)
		//IL_071d: Invalid comparison between Unknown and I4
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Invalid comparison between Unknown and I4
		//IL_0bf1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfb: Expected O, but got Unknown
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a3: Invalid comparison between Unknown and I4
		//IL_0738: Unknown result type (might be due to invalid IL or missing references)
		//IL_073f: Invalid comparison between Unknown and I4
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Invalid comparison between Unknown and I4
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d1: Invalid comparison between Unknown and I4
		//IL_075a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0761: Invalid comparison between Unknown and I4
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Invalid comparison between Unknown and I4
		//IL_04f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ff: Invalid comparison between Unknown and I4
		//IL_077c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0783: Invalid comparison between Unknown and I4
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Invalid comparison between Unknown and I4
		//IL_079e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a5: Invalid comparison between Unknown and I4
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Invalid comparison between Unknown and I4
		//IL_07c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c7: Invalid comparison between Unknown and I4
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Invalid comparison between Unknown and I4
		//IL_07e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e9: Invalid comparison between Unknown and I4
		//IL_0804: Unknown result type (might be due to invalid IL or missing references)
		//IL_080b: Invalid comparison between Unknown and I4
		//IL_0826: Unknown result type (might be due to invalid IL or missing references)
		//IL_082d: Invalid comparison between Unknown and I4
		//IL_0848: Unknown result type (might be due to invalid IL or missing references)
		//IL_084f: Invalid comparison between Unknown and I4
		//IL_086a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0871: Invalid comparison between Unknown and I4
		//IL_088c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0893: Invalid comparison between Unknown and I4
		//IL_08ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b5: Invalid comparison between Unknown and I4
		//IL_08d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d7: Invalid comparison between Unknown and I4
		//IL_08f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f9: Invalid comparison between Unknown and I4
		//IL_0914: Unknown result type (might be due to invalid IL or missing references)
		//IL_091b: Invalid comparison between Unknown and I4
		//IL_0936: Unknown result type (might be due to invalid IL or missing references)
		//IL_093d: Invalid comparison between Unknown and I4
		//IL_0958: Unknown result type (might be due to invalid IL or missing references)
		//IL_095f: Invalid comparison between Unknown and I4
		//IL_097a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0981: Invalid comparison between Unknown and I4
		//IL_099c: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a3: Invalid comparison between Unknown and I4
		//IL_09be: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c5: Invalid comparison between Unknown and I4
		//IL_09e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e7: Invalid comparison between Unknown and I4
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == 27)
		{
			if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 2)
			{
				DC_Main.TotOpenForm = 0;
				((Control)SideTrip).Focus();
			}
		}
		else if ((int)keyCode == (0x71 & (0 - (e.Control ? 1 : 0))))
		{
			F2CtrlOrderZoomToolStripMenuItem_Click(ShoCtrlF12TagEstmate, new EventArgs());
		}
		else if ((int)keyCode == 113)
		{
			ShoF2Ledger_Click(ShoF2Ledger, new EventArgs());
		}
		else if ((int)keyCode == 114)
		{
			ShoF3Stock_Click(ShoF3Stock, new EventArgs());
		}
		else if ((int)keyCode == 115)
		{
			ShoF4SalesOrder_Click(ShoF3Stock, new EventArgs());
		}
		else if ((int)keyCode == (0x74 & (0 - (e.Control ? 1 : 0))))
		{
			ShoCtrlF5BillRec_Click(ShoCtrlF5BillRec, new EventArgs());
		}
		else if ((int)keyCode == 116)
		{
			ShoF5SalesBill_Click(ShoF3Stock, new EventArgs());
		}
		else if ((int)keyCode == (0x75 & (0 - (e.Control ? 1 : 0))))
		{
			ShoCtrlF6RateCut_Click(ShoCtrlF6RateCut, new EventArgs());
		}
		else if ((int)keyCode == 117)
		{
			ShoF6WhSales_Click(ShoF6WhSales, new EventArgs());
		}
		else if ((int)keyCode == 118)
		{
			ShoF7Purc_Click(ShoF7Purc, new EventArgs());
		}
		else if ((int)keyCode == (0x77 & (0 - (e.Control ? 1 : 0))))
		{
			ShoCtrlF8BankRec_Click(ShoCtrlF8BankRec, new EventArgs());
		}
		else if ((int)keyCode == 119)
		{
			ShoF8CashRec_Click(ShoF7Purc, new EventArgs());
		}
		else if ((int)keyCode == (0x78 & (0 - (e.Control ? 1 : 0))))
		{
			ShoCtrlF9BankPay_Click(ShoCtrlF9BankPay, new EventArgs());
		}
		else if ((int)keyCode == 120)
		{
			ShoF9CashPayment_Click(ShoF7Purc, new EventArgs());
		}
		else if ((int)keyCode == (0x7A & (0 - (e.Control ? 1 : 0))))
		{
			F11CtrlCashBankToolStripMenuItem_Click(F11CtrlCashBankToolStripMenuItem, new EventArgs());
		}
		else if ((int)keyCode == 122)
		{
			ShoF11Rojmel_Click(ShoF11Rojmel, new EventArgs());
		}
		else if ((int)keyCode == (0x7B & (0 - (e.Control ? 1 : 0))))
		{
			ShoCtrlF12TagEstmate_Click(ShoCtrlF12TagEstmate, new EventArgs());
		}
		else if ((int)keyCode == 123)
		{
			Shof12TagWiseStock_Click(ShoF3Stock, new EventArgs());
		}
		else if ((int)keyCode == (0x70 & (0 - (e.Control ? 1 : 0))))
		{
			F1CtrlDailyRateToolStripMenuItem_Click(F1CtrlDailyRateToolStripMenuItem, new EventArgs());
		}
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 2)
		{
			Keys keyCode2 = e.KeyCode;
			if ((int)keyCode2 == (0x43 & (0 - (e.Alt ? 1 : 0))))
			{
				BtnComp_Click(BtnComp, new EventArgs());
			}
			else if ((int)keyCode2 == (0x4D & (0 - (e.Alt ? 1 : 0))))
			{
				BtnMast_Click(BtnMast, new EventArgs());
			}
			else if ((int)keyCode2 == (0x54 & (0 - (e.Alt ? 1 : 0))))
			{
				BtnTran_Click(BtnTran, new EventArgs());
			}
			else if ((int)keyCode2 == (0x4E & (0 - (e.Alt ? 1 : 0))))
			{
				BtnTran2_Click(BtnTran2, new EventArgs());
			}
			else if ((int)keyCode2 == (0x4B & (0 - (e.Alt ? 1 : 0))))
			{
				BtnKrgr_Click(BtnKrgr, new EventArgs());
			}
			else if ((int)keyCode2 == (0x4F & (0 - (e.Alt ? 1 : 0))))
			{
				BtnOth_Click(BtnOth, new EventArgs());
			}
			else if ((int)keyCode2 == (0x53 & (0 - (e.Alt ? 1 : 0))))
			{
				BtnSchm_Click(BtnSchm, new EventArgs());
			}
			else if ((int)keyCode2 == (0x52 & (0 - (e.Alt ? 1 : 0))))
			{
				BtnRpt_Click(BtnRpt, new EventArgs());
			}
			else if ((int)keyCode2 == (0x43 & (0 - (e.Alt ? 1 : 0))))
			{
				BtnSchm_Click(BtnSchm, new EventArgs());
			}
			else if ((int)keyCode2 == (0x44 & (0 - (e.Alt ? 1 : 0))))
			{
				BtnDhrn_Click(BtnDhrn, new EventArgs());
			}
			else if ((int)keyCode2 == (0x45 & (0 - (e.Alt ? 1 : 0))))
			{
				BtnExit_Click(BtnExit, new EventArgs());
			}
			else if ((int)keyCode2 == (0x57 & (0 - (e.Alt ? 1 : 0))))
			{
				checked
				{
					if (Operators.CompareString(DC_Main.MsTileMenuShow, "W", false) == 0)
					{
						PanalImage_Hide();
						UT_WINDOW uT_WINDOW = new UT_WINDOW();
						((Form)uT_WINDOW).MdiParent = (Form)(object)this;
						DC_Main.TotOpenForm++;
						((Form)uT_WINDOW).Text = "Window " + Conversions.ToString(DC_Main.TotOpenForm);
						((Control)uT_WINDOW).Show();
						((Control)uT_WINDOW).Focus();
					}
					else
					{
						((Control)MyProject.Forms.UT_WINDOW).Show();
					}
				}
			}
			if (((int)e.KeyCode == 79) & e.Control)
			{
				if (Operators.CompareString(((AccordionControlElementBase)SL15).Hint, "Data Import", false) == 0)
				{
					((AccordionControlElementBase)SL15).Visible = true;
				}
				if (Operators.CompareString(DC_Main.MsEstmateReset, "Y", false) == 0 && Operators.CompareString(((AccordionControlElementBase)SL35).Hint, "Estimate Reset", false) == 0)
				{
					((AccordionControlElementBase)SL35).Visible = true;
				}
				if (Operators.CompareString(((AccordionControlElementBase)SL25).Hint, "Vch ReNumber", false) == 0)
				{
					((AccordionControlElementBase)SL25).Visible = true;
				}
			}
			if ((((int)e.KeyCode == 66) & e.Control) && Operators.CompareString(((AccordionControlElementBase)SL34).Hint, "Data Export", false) == 0)
			{
				((AccordionControlElementBase)SL34).Visible = true;
			}
			if (((int)e.KeyCode == 65) & e.Control)
			{
				CodVal = "A";
			}
			if (((int)e.KeyCode == 66) & e.Control)
			{
				CodVal = "B";
			}
			if (((int)e.KeyCode == 67) & e.Control)
			{
				CodVal = "C";
			}
			if (((int)e.KeyCode == 68) & e.Control)
			{
				CodVal = "D";
			}
			if (((int)e.KeyCode == 69) & e.Control)
			{
				CodVal = "E";
			}
			if (((int)e.KeyCode == 70) & e.Control)
			{
				CodVal = "F";
			}
			if (((int)e.KeyCode == 71) & e.Control)
			{
				CodVal = "G";
			}
			if (((int)e.KeyCode == 72) & e.Control)
			{
				CodVal = "H";
			}
			if (((int)e.KeyCode == 73) & e.Control)
			{
				CodVal = "I";
			}
			if (((int)e.KeyCode == 74) & e.Control)
			{
				CodVal = "J";
			}
			if (((int)e.KeyCode == 75) & e.Control)
			{
				CodVal = "K";
			}
			if (((int)e.KeyCode == 76) & e.Control)
			{
				CodVal = "L";
			}
			if (((int)e.KeyCode == 77) & e.Control)
			{
				CodVal = "M";
			}
			if (((int)e.KeyCode == 78) & e.Control)
			{
				CodVal = "N";
			}
			if (((int)e.KeyCode == 79) & e.Control)
			{
				CodVal = "O";
			}
			if (((int)e.KeyCode == 80) & e.Control)
			{
				CodVal = "P";
			}
			if (((int)e.KeyCode == 81) & e.Control)
			{
				CodVal = "Q";
			}
			if (((int)e.KeyCode == 82) & e.Control)
			{
				CodVal = "R";
			}
			if (((int)e.KeyCode == 83) & e.Control)
			{
				CodVal = "S";
			}
			if (((int)e.KeyCode == 84) & e.Control)
			{
				CodVal = "T";
			}
			if (((int)e.KeyCode == 85) & e.Control)
			{
				CodVal = "U";
			}
			if (((int)e.KeyCode == 86) & e.Control)
			{
				CodVal = "V";
			}
			if (((int)e.KeyCode == 87) & e.Control)
			{
				CodVal = "W";
			}
			if (((int)e.KeyCode == 88) & e.Control)
			{
				CodVal = "X";
			}
			if (((int)e.KeyCode == 89) & e.Control)
			{
				CodVal = "Y";
			}
			if (((int)e.KeyCode == 90) & e.Control)
			{
				CodVal = "Z";
			}
		}
		if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
		{
			Keys keyCode3 = e.KeyCode;
			if ((int)keyCode3 == (0x41 & (0 - (e.Control ? 1 : 0))) || (int)keyCode3 == (0x42 & (0 - (e.Control ? 1 : 0))) || (int)keyCode3 == (0x43 & (0 - (e.Control ? 1 : 0))))
			{
				DC_Main.RsQry = "SELECT CON_NAME FROM CONV_MAST WHERE CO_CODE = '01' AND CON_CODE = 'A'";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count == 0)
				{
					if (Operators.CompareString(CodVal, "A", false) == 0)
					{
						DC_Main.MsDataType = "A";
					}
					else if (Operators.CompareString(CodVal, "B", false) == 0)
					{
						DC_Main.MsDataType = "B";
					}
					else if (Operators.CompareString(CodVal, "C", false) == 0)
					{
						DC_Main.MsDataType = "C";
					}
					else
					{
						DC_Main.MsDataType = "A";
					}
				}
				else
				{
					DC_Main.RsQry = "SELECT CON_CODE FROM CONV_MAST WHERE CO_CODE = '01' AND CON_NAME = '" + CodVal + "'";
					dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable.Rows.Count > 0)
					{
						DC_Main.MsDataType = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["CON_CODE"], (object)""));
					}
					else
					{
						DC_Main.MsDataType = "A";
					}
				}
				if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
				{
					tSoftDemoType.Text = "- -";
					((Control)tSoftDemoType).Font = new Font("Arial", 12f, (FontStyle)1);
					if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
					{
						((Control)tSoftDemoType).Visible = false;
					}
					if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
					{
						((Control)tSoftDemoType).Visible = true;
						((TextBoxBase)tSoftDemoType).ForeColor = Color.Red;
					}
					if (Operators.CompareString(DC_Main.MsDataType, "C", false) == 0)
					{
						((Control)tSoftDemoType).Visible = true;
						((TextBoxBase)tSoftDemoType).ForeColor = Color.Green;
					}
				}
				else if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
				{
					((Control)tSoftDemoType).Visible = false;
				}
			}
			else if (Operators.CompareString(CodVal, "", false) != 0)
			{
				DC_Main.RsQry = "SELECT CON_CODE FROM CONV_MAST WHERE CO_CODE = '01' AND CON_NAME = '" + CodVal + "'";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					DC_Main.MsDataType = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["CON_CODE"], (object)""));
				}
				if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
				{
					tSoftDemoType.Text = "- -";
					((Control)tSoftDemoType).Font = new Font("Arial", 12f, (FontStyle)1);
					if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
					{
						((Control)tSoftDemoType).Visible = false;
					}
					if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
					{
						((Control)tSoftDemoType).Visible = true;
						((TextBoxBase)tSoftDemoType).ForeColor = Color.Red;
					}
					if (Operators.CompareString(DC_Main.MsDataType, "C", false) == 0)
					{
						((Control)tSoftDemoType).Visible = true;
						((TextBoxBase)tSoftDemoType).ForeColor = Color.LightSeaGreen;
					}
				}
				else if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
				{
					((Control)tSoftDemoType).Visible = false;
				}
			}
		}
		if (((Operators.CompareString(DC_Main.SSRegSrNo, "HM360NAPK", false) == 0) & (Operators.CompareString(DC_Main.MsDataType, "C", false) == 0)) && Operators.CompareString(DC_Main.MsMainBtn, "Dhiran", false) == 0)
		{
			((AccordionControlElementBase)SL4).Visible = true;
			((AccordionControlElementBase)SL5).Visible = true;
			((AccordionControlElementBase)SL6).Visible = true;
			((AccordionControlElementBase)SL7).Visible = true;
		}
		CodVal = "";
	}

	private void MDI_FORM_FormClosed(object sender, FormClosedEventArgs e)
	{
		myTimer.Stop();
		if (Module_Schm.bgWorker.IsBusy && Module_Schm.bgWorker.WorkerSupportsCancellation)
		{
			Module_Schm.bgWorker.CancelAsync();
		}
		Application.Exit();
	}

	private void CboTheme_SelectedIndexChanged(object sender, EventArgs e)
	{
		ColorConverter colorConverter = new ColorConverter();
		if (cboTheme.SelectedIndex == 0)
		{
			DC_Main.MsCoTheme = 1;
			DC_Main.RsQry = "UPDATE CO_SET SET THEME = 1 WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			object? obj = colorConverter.ConvertFromString("ButtonHighlight");
			((Form)this).BackColor = ((obj != null) ? ((Color)obj) : default(Color));
			ToolStrip mainTrip = MainTrip;
			object? obj2 = colorConverter.ConvertFromString("255, 145, 0");
			mainTrip.BackColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
			ToolStripTextBox obj3 = mMainDt;
			object? obj4 = colorConverter.ConvertFromString("255, 145, 0");
			((ToolStripControlHost)obj3).BackColor = ((obj4 != null) ? ((Color)obj4) : default(Color));
			((BaseControl)SideTrip).LookAndFeel.SkinName = "Office 2019 Colorful";
			AppearanceObject normal = SLMain.Appearance.Normal;
			object? obj5 = colorConverter.ConvertFromString("");
			normal.BackColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
			AppearanceObject normal2 = SLMain2.Appearance.Normal;
			object? obj6 = colorConverter.ConvertFromString("");
			normal2.BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
			AppearanceObject normal3 = SLMain3.Appearance.Normal;
			object? obj7 = colorConverter.ConvertFromString("");
			normal3.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
			AppearanceObject normal4 = SLMain4.Appearance.Normal;
			object? obj8 = colorConverter.ConvertFromString("");
			normal4.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
			AppearanceObject normal5 = SLMain5.Appearance.Normal;
			object? obj9 = colorConverter.ConvertFromString("");
			normal5.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
			AppearanceObject normal6 = SLMain6.Appearance.Normal;
			object? obj10 = colorConverter.ConvertFromString("");
			normal6.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
			FlowLayoutPanel pnlBotam = PnlBotam;
			object? obj11 = colorConverter.ConvertFromString("ButtonHighlight");
			((Control)pnlBotam).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
			TextBox obj12 = nCurrncyRate;
			object? obj13 = colorConverter.ConvertFromString("ButtonHighlight");
			((TextBoxBase)obj12).BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
			Label obj14 = lblLiveRate;
			object? obj15 = colorConverter.ConvertFromString("ButtonHighlight");
			((Control)obj14).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
			Label obj16 = tAmcDate;
			object? obj17 = colorConverter.ConvertFromString("ButtonHighlight");
			((Control)obj16).BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
			TextBox obj18 = tSoftDemoType;
			object? obj19 = colorConverter.ConvertFromString("ButtonHighlight");
			((TextBoxBase)obj18).BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
			ComboBox obj20 = cboTheme;
			object? obj21 = colorConverter.ConvertFromString("ButtonHighlight");
			obj20.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
		}
		else if (cboTheme.SelectedIndex == 1)
		{
			DC_Main.MsCoTheme = 2;
			DC_Main.RsQry = "UPDATE CO_SET SET THEME = 2 WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			object? obj22 = colorConverter.ConvertFromString("Control");
			((Form)this).BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
			ToolStrip mainTrip2 = MainTrip;
			object? obj23 = colorConverter.ConvertFromString("115, 115, 115");
			mainTrip2.BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
			ToolStripTextBox obj24 = mMainDt;
			object? obj25 = colorConverter.ConvertFromString("115, 115, 115");
			((ToolStripControlHost)obj24).BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
			((BaseControl)SideTrip).LookAndFeel.SkinName = "Office 2016 Dark";
			AppearanceObject normal7 = SLMain.Appearance.Normal;
			object? obj26 = colorConverter.ConvertFromString("115, 115, 115");
			normal7.BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
			AppearanceObject normal8 = SLMain2.Appearance.Normal;
			object? obj27 = colorConverter.ConvertFromString("115, 115, 115");
			normal8.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
			AppearanceObject normal9 = SLMain3.Appearance.Normal;
			object? obj28 = colorConverter.ConvertFromString("115, 115, 115");
			normal9.BackColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
			AppearanceObject normal10 = SLMain4.Appearance.Normal;
			object? obj29 = colorConverter.ConvertFromString("115, 115, 115");
			normal10.BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
			AppearanceObject normal11 = SLMain5.Appearance.Normal;
			object? obj30 = colorConverter.ConvertFromString("115, 115, 115");
			normal11.BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
			AppearanceObject normal12 = SLMain6.Appearance.Normal;
			object? obj31 = colorConverter.ConvertFromString("115, 115, 115");
			normal12.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
			FlowLayoutPanel pnlBotam2 = PnlBotam;
			object? obj32 = colorConverter.ConvertFromString("Control");
			((Control)pnlBotam2).BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
			TextBox obj33 = nCurrncyRate;
			object? obj34 = colorConverter.ConvertFromString("Control");
			((TextBoxBase)obj33).BackColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
			Label obj35 = lblLiveRate;
			object? obj36 = colorConverter.ConvertFromString("Control");
			((Control)obj35).BackColor = ((obj36 != null) ? ((Color)obj36) : default(Color));
			Label obj37 = tAmcDate;
			object? obj38 = colorConverter.ConvertFromString("Control");
			((Control)obj37).BackColor = ((obj38 != null) ? ((Color)obj38) : default(Color));
			TextBox obj39 = tSoftDemoType;
			object? obj40 = colorConverter.ConvertFromString("Control");
			((TextBoxBase)obj39).BackColor = ((obj40 != null) ? ((Color)obj40) : default(Color));
			ComboBox obj41 = cboTheme;
			object? obj42 = colorConverter.ConvertFromString("Control");
			obj41.BackColor = ((obj42 != null) ? ((Color)obj42) : default(Color));
		}
		else if (cboTheme.SelectedIndex == 2)
		{
			DC_Main.MsCoTheme = 3;
			DC_Main.RsQry = "UPDATE CO_SET SET THEME = 3 WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			object? obj43 = colorConverter.ConvertFromString("224, 224, 224");
			((Form)this).BackColor = ((obj43 != null) ? ((Color)obj43) : default(Color));
			MainTrip.BackColor = Color.LightSlateGray;
			((ToolStripControlHost)mMainDt).BackColor = Color.LightSlateGray;
			((BaseControl)SideTrip).LookAndFeel.SkinName = "VS2010";
			AppearanceObject normal13 = SLMain.Appearance.Normal;
			object? obj44 = colorConverter.ConvertFromString("185, 200, 210");
			normal13.BackColor = ((obj44 != null) ? ((Color)obj44) : default(Color));
			AppearanceObject normal14 = SLMain2.Appearance.Normal;
			object? obj45 = colorConverter.ConvertFromString("185, 200, 210");
			normal14.BackColor = ((obj45 != null) ? ((Color)obj45) : default(Color));
			AppearanceObject normal15 = SLMain3.Appearance.Normal;
			object? obj46 = colorConverter.ConvertFromString("185, 200, 210");
			normal15.BackColor = ((obj46 != null) ? ((Color)obj46) : default(Color));
			AppearanceObject normal16 = SLMain4.Appearance.Normal;
			object? obj47 = colorConverter.ConvertFromString("185, 200, 210");
			normal16.BackColor = ((obj47 != null) ? ((Color)obj47) : default(Color));
			AppearanceObject hovered = SLMain.Appearance.Hovered;
			object? obj48 = colorConverter.ConvertFromString("LightSlateGray");
			hovered.BackColor = ((obj48 != null) ? ((Color)obj48) : default(Color));
			AppearanceObject hovered2 = SLMain2.Appearance.Hovered;
			object? obj49 = colorConverter.ConvertFromString("LightSlateGray");
			hovered2.BackColor = ((obj49 != null) ? ((Color)obj49) : default(Color));
			AppearanceObject hovered3 = SLMain3.Appearance.Hovered;
			object? obj50 = colorConverter.ConvertFromString("LightSlateGray");
			hovered3.BackColor = ((obj50 != null) ? ((Color)obj50) : default(Color));
			AppearanceObject hovered4 = SLMain4.Appearance.Hovered;
			object? obj51 = colorConverter.ConvertFromString("LightSlateGray");
			hovered4.BackColor = ((obj51 != null) ? ((Color)obj51) : default(Color));
			AppearanceObject normal17 = SLMain5.Appearance.Normal;
			object? obj52 = colorConverter.ConvertFromString("185, 200, 210");
			normal17.BackColor = ((obj52 != null) ? ((Color)obj52) : default(Color));
			AppearanceObject normal18 = SLMain6.Appearance.Normal;
			object? obj53 = colorConverter.ConvertFromString("185, 200, 210");
			normal18.BackColor = ((obj53 != null) ? ((Color)obj53) : default(Color));
			AppearanceObject hovered5 = SLMain5.Appearance.Hovered;
			object? obj54 = colorConverter.ConvertFromString("LightSlateGray");
			hovered5.BackColor = ((obj54 != null) ? ((Color)obj54) : default(Color));
			AppearanceObject hovered6 = SLMain6.Appearance.Hovered;
			object? obj55 = colorConverter.ConvertFromString("LightSlateGray");
			hovered6.BackColor = ((obj55 != null) ? ((Color)obj55) : default(Color));
			AppearanceObject hovered7 = SL0.Appearance.Hovered;
			object? obj56 = colorConverter.ConvertFromString("233, 235, 240");
			hovered7.BackColor = ((obj56 != null) ? ((Color)obj56) : default(Color));
			AppearanceObject hovered8 = SL1.Appearance.Hovered;
			object? obj57 = colorConverter.ConvertFromString("233, 235, 240");
			hovered8.BackColor = ((obj57 != null) ? ((Color)obj57) : default(Color));
			AppearanceObject hovered9 = SL2.Appearance.Hovered;
			object? obj58 = colorConverter.ConvertFromString("233, 235, 240");
			hovered9.BackColor = ((obj58 != null) ? ((Color)obj58) : default(Color));
			AppearanceObject hovered10 = SL3.Appearance.Hovered;
			object? obj59 = colorConverter.ConvertFromString("233, 235, 240");
			hovered10.BackColor = ((obj59 != null) ? ((Color)obj59) : default(Color));
			AppearanceObject hovered11 = SL4.Appearance.Hovered;
			object? obj60 = colorConverter.ConvertFromString("233, 235, 240");
			hovered11.BackColor = ((obj60 != null) ? ((Color)obj60) : default(Color));
			AppearanceObject hovered12 = SL5.Appearance.Hovered;
			object? obj61 = colorConverter.ConvertFromString("233, 235, 240");
			hovered12.BackColor = ((obj61 != null) ? ((Color)obj61) : default(Color));
			AppearanceObject hovered13 = SL6.Appearance.Hovered;
			object? obj62 = colorConverter.ConvertFromString("233, 235, 240");
			hovered13.BackColor = ((obj62 != null) ? ((Color)obj62) : default(Color));
			AppearanceObject hovered14 = SL7.Appearance.Hovered;
			object? obj63 = colorConverter.ConvertFromString("233, 235, 240");
			hovered14.BackColor = ((obj63 != null) ? ((Color)obj63) : default(Color));
			AppearanceObject hovered15 = SL8.Appearance.Hovered;
			object? obj64 = colorConverter.ConvertFromString("233, 235, 240");
			hovered15.BackColor = ((obj64 != null) ? ((Color)obj64) : default(Color));
			AppearanceObject hovered16 = SL9.Appearance.Hovered;
			object? obj65 = colorConverter.ConvertFromString("233, 235, 240");
			hovered16.BackColor = ((obj65 != null) ? ((Color)obj65) : default(Color));
			AppearanceObject hovered17 = SL10.Appearance.Hovered;
			object? obj66 = colorConverter.ConvertFromString("233, 235, 240");
			hovered17.BackColor = ((obj66 != null) ? ((Color)obj66) : default(Color));
			AppearanceObject hovered18 = SL11.Appearance.Hovered;
			object? obj67 = colorConverter.ConvertFromString("233, 235, 240");
			hovered18.BackColor = ((obj67 != null) ? ((Color)obj67) : default(Color));
			AppearanceObject hovered19 = SL12.Appearance.Hovered;
			object? obj68 = colorConverter.ConvertFromString("233, 235, 240");
			hovered19.BackColor = ((obj68 != null) ? ((Color)obj68) : default(Color));
			AppearanceObject hovered20 = SL13.Appearance.Hovered;
			object? obj69 = colorConverter.ConvertFromString("233, 235, 240");
			hovered20.BackColor = ((obj69 != null) ? ((Color)obj69) : default(Color));
			AppearanceObject hovered21 = SL14.Appearance.Hovered;
			object? obj70 = colorConverter.ConvertFromString("233, 235, 240");
			hovered21.BackColor = ((obj70 != null) ? ((Color)obj70) : default(Color));
			AppearanceObject hovered22 = SL15.Appearance.Hovered;
			object? obj71 = colorConverter.ConvertFromString("233, 235, 240");
			hovered22.BackColor = ((obj71 != null) ? ((Color)obj71) : default(Color));
			AppearanceObject hovered23 = SL16.Appearance.Hovered;
			object? obj72 = colorConverter.ConvertFromString("233, 235, 240");
			hovered23.BackColor = ((obj72 != null) ? ((Color)obj72) : default(Color));
			AppearanceObject hovered24 = SL17.Appearance.Hovered;
			object? obj73 = colorConverter.ConvertFromString("233, 235, 240");
			hovered24.BackColor = ((obj73 != null) ? ((Color)obj73) : default(Color));
			AppearanceObject hovered25 = SL18.Appearance.Hovered;
			object? obj74 = colorConverter.ConvertFromString("233, 235, 240");
			hovered25.BackColor = ((obj74 != null) ? ((Color)obj74) : default(Color));
			AppearanceObject hovered26 = SL19.Appearance.Hovered;
			object? obj75 = colorConverter.ConvertFromString("233, 235, 240");
			hovered26.BackColor = ((obj75 != null) ? ((Color)obj75) : default(Color));
			AppearanceObject hovered27 = SL20.Appearance.Hovered;
			object? obj76 = colorConverter.ConvertFromString("233, 235, 240");
			hovered27.BackColor = ((obj76 != null) ? ((Color)obj76) : default(Color));
			AppearanceObject pressed = SL0.Appearance.Pressed;
			object? obj77 = colorConverter.ConvertFromString("174, 184, 194");
			pressed.BackColor = ((obj77 != null) ? ((Color)obj77) : default(Color));
			AppearanceObject pressed2 = SL1.Appearance.Pressed;
			object? obj78 = colorConverter.ConvertFromString("174, 184, 194");
			pressed2.BackColor = ((obj78 != null) ? ((Color)obj78) : default(Color));
			AppearanceObject pressed3 = SL2.Appearance.Pressed;
			object? obj79 = colorConverter.ConvertFromString("174, 184, 194");
			pressed3.BackColor = ((obj79 != null) ? ((Color)obj79) : default(Color));
			AppearanceObject pressed4 = SL3.Appearance.Pressed;
			object? obj80 = colorConverter.ConvertFromString("174, 184, 194");
			pressed4.BackColor = ((obj80 != null) ? ((Color)obj80) : default(Color));
			AppearanceObject pressed5 = SL4.Appearance.Pressed;
			object? obj81 = colorConverter.ConvertFromString("174, 184, 194");
			pressed5.BackColor = ((obj81 != null) ? ((Color)obj81) : default(Color));
			AppearanceObject pressed6 = SL5.Appearance.Pressed;
			object? obj82 = colorConverter.ConvertFromString("174, 184, 194");
			pressed6.BackColor = ((obj82 != null) ? ((Color)obj82) : default(Color));
			AppearanceObject pressed7 = SL6.Appearance.Pressed;
			object? obj83 = colorConverter.ConvertFromString("174, 184, 194");
			pressed7.BackColor = ((obj83 != null) ? ((Color)obj83) : default(Color));
			AppearanceObject pressed8 = SL7.Appearance.Pressed;
			object? obj84 = colorConverter.ConvertFromString("174, 184, 194");
			pressed8.BackColor = ((obj84 != null) ? ((Color)obj84) : default(Color));
			AppearanceObject pressed9 = SL8.Appearance.Pressed;
			object? obj85 = colorConverter.ConvertFromString("174, 184, 194");
			pressed9.BackColor = ((obj85 != null) ? ((Color)obj85) : default(Color));
			AppearanceObject pressed10 = SL9.Appearance.Pressed;
			object? obj86 = colorConverter.ConvertFromString("174, 184, 194");
			pressed10.BackColor = ((obj86 != null) ? ((Color)obj86) : default(Color));
			AppearanceObject pressed11 = SL10.Appearance.Pressed;
			object? obj87 = colorConverter.ConvertFromString("174, 184, 194");
			pressed11.BackColor = ((obj87 != null) ? ((Color)obj87) : default(Color));
			AppearanceObject pressed12 = SL11.Appearance.Pressed;
			object? obj88 = colorConverter.ConvertFromString("174, 184, 194");
			pressed12.BackColor = ((obj88 != null) ? ((Color)obj88) : default(Color));
			AppearanceObject pressed13 = SL12.Appearance.Pressed;
			object? obj89 = colorConverter.ConvertFromString("174, 184, 194");
			pressed13.BackColor = ((obj89 != null) ? ((Color)obj89) : default(Color));
			AppearanceObject pressed14 = SL13.Appearance.Pressed;
			object? obj90 = colorConverter.ConvertFromString("174, 184, 194");
			pressed14.BackColor = ((obj90 != null) ? ((Color)obj90) : default(Color));
			AppearanceObject pressed15 = SL14.Appearance.Pressed;
			object? obj91 = colorConverter.ConvertFromString("174, 184, 194");
			pressed15.BackColor = ((obj91 != null) ? ((Color)obj91) : default(Color));
			AppearanceObject pressed16 = SL15.Appearance.Pressed;
			object? obj92 = colorConverter.ConvertFromString("174, 184, 194");
			pressed16.BackColor = ((obj92 != null) ? ((Color)obj92) : default(Color));
			AppearanceObject pressed17 = SL16.Appearance.Pressed;
			object? obj93 = colorConverter.ConvertFromString("174, 184, 194");
			pressed17.BackColor = ((obj93 != null) ? ((Color)obj93) : default(Color));
			AppearanceObject pressed18 = SL17.Appearance.Pressed;
			object? obj94 = colorConverter.ConvertFromString("174, 184, 194");
			pressed18.BackColor = ((obj94 != null) ? ((Color)obj94) : default(Color));
			AppearanceObject pressed19 = SL18.Appearance.Pressed;
			object? obj95 = colorConverter.ConvertFromString("174, 184, 194");
			pressed19.BackColor = ((obj95 != null) ? ((Color)obj95) : default(Color));
			AppearanceObject pressed20 = SL19.Appearance.Pressed;
			object? obj96 = colorConverter.ConvertFromString("174, 184, 194");
			pressed20.BackColor = ((obj96 != null) ? ((Color)obj96) : default(Color));
			AppearanceObject pressed21 = SL20.Appearance.Pressed;
			object? obj97 = colorConverter.ConvertFromString("174, 184, 194");
			pressed21.BackColor = ((obj97 != null) ? ((Color)obj97) : default(Color));
			AppearanceObject hovered28 = SL51.Appearance.Hovered;
			object? obj98 = colorConverter.ConvertFromString("233, 235, 240");
			hovered28.BackColor = ((obj98 != null) ? ((Color)obj98) : default(Color));
			AppearanceObject hovered29 = SL52.Appearance.Hovered;
			object? obj99 = colorConverter.ConvertFromString("233, 235, 240");
			hovered29.BackColor = ((obj99 != null) ? ((Color)obj99) : default(Color));
			AppearanceObject hovered30 = SL53.Appearance.Hovered;
			object? obj100 = colorConverter.ConvertFromString("233, 235, 240");
			hovered30.BackColor = ((obj100 != null) ? ((Color)obj100) : default(Color));
			AppearanceObject hovered31 = SL54.Appearance.Hovered;
			object? obj101 = colorConverter.ConvertFromString("233, 235, 240");
			hovered31.BackColor = ((obj101 != null) ? ((Color)obj101) : default(Color));
			AppearanceObject hovered32 = SL55.Appearance.Hovered;
			object? obj102 = colorConverter.ConvertFromString("233, 235, 240");
			hovered32.BackColor = ((obj102 != null) ? ((Color)obj102) : default(Color));
			AppearanceObject hovered33 = SL56.Appearance.Hovered;
			object? obj103 = colorConverter.ConvertFromString("233, 235, 240");
			hovered33.BackColor = ((obj103 != null) ? ((Color)obj103) : default(Color));
			AppearanceObject hovered34 = SL57.Appearance.Hovered;
			object? obj104 = colorConverter.ConvertFromString("233, 235, 240");
			hovered34.BackColor = ((obj104 != null) ? ((Color)obj104) : default(Color));
			AppearanceObject hovered35 = SL58.Appearance.Hovered;
			object? obj105 = colorConverter.ConvertFromString("233, 235, 240");
			hovered35.BackColor = ((obj105 != null) ? ((Color)obj105) : default(Color));
			AppearanceObject hovered36 = SL59.Appearance.Hovered;
			object? obj106 = colorConverter.ConvertFromString("233, 235, 240");
			hovered36.BackColor = ((obj106 != null) ? ((Color)obj106) : default(Color));
			AppearanceObject hovered37 = SL60.Appearance.Hovered;
			object? obj107 = colorConverter.ConvertFromString("233, 235, 240");
			hovered37.BackColor = ((obj107 != null) ? ((Color)obj107) : default(Color));
			AppearanceObject hovered38 = SL61.Appearance.Hovered;
			object? obj108 = colorConverter.ConvertFromString("233, 235, 240");
			hovered38.BackColor = ((obj108 != null) ? ((Color)obj108) : default(Color));
			AppearanceObject hovered39 = SL62.Appearance.Hovered;
			object? obj109 = colorConverter.ConvertFromString("233, 235, 240");
			hovered39.BackColor = ((obj109 != null) ? ((Color)obj109) : default(Color));
			AppearanceObject hovered40 = SL63.Appearance.Hovered;
			object? obj110 = colorConverter.ConvertFromString("233, 235, 240");
			hovered40.BackColor = ((obj110 != null) ? ((Color)obj110) : default(Color));
			AppearanceObject hovered41 = SL64.Appearance.Hovered;
			object? obj111 = colorConverter.ConvertFromString("233, 235, 240");
			hovered41.BackColor = ((obj111 != null) ? ((Color)obj111) : default(Color));
			AppearanceObject hovered42 = SL65.Appearance.Hovered;
			object? obj112 = colorConverter.ConvertFromString("233, 235, 240");
			hovered42.BackColor = ((obj112 != null) ? ((Color)obj112) : default(Color));
			AppearanceObject pressed22 = SL51.Appearance.Pressed;
			object? obj113 = colorConverter.ConvertFromString("174, 184, 194");
			pressed22.BackColor = ((obj113 != null) ? ((Color)obj113) : default(Color));
			AppearanceObject pressed23 = SL52.Appearance.Pressed;
			object? obj114 = colorConverter.ConvertFromString("174, 184, 194");
			pressed23.BackColor = ((obj114 != null) ? ((Color)obj114) : default(Color));
			AppearanceObject pressed24 = SL53.Appearance.Pressed;
			object? obj115 = colorConverter.ConvertFromString("174, 184, 194");
			pressed24.BackColor = ((obj115 != null) ? ((Color)obj115) : default(Color));
			AppearanceObject pressed25 = SL54.Appearance.Pressed;
			object? obj116 = colorConverter.ConvertFromString("174, 184, 194");
			pressed25.BackColor = ((obj116 != null) ? ((Color)obj116) : default(Color));
			AppearanceObject pressed26 = SL55.Appearance.Pressed;
			object? obj117 = colorConverter.ConvertFromString("174, 184, 194");
			pressed26.BackColor = ((obj117 != null) ? ((Color)obj117) : default(Color));
			AppearanceObject pressed27 = SL56.Appearance.Pressed;
			object? obj118 = colorConverter.ConvertFromString("174, 184, 194");
			pressed27.BackColor = ((obj118 != null) ? ((Color)obj118) : default(Color));
			AppearanceObject pressed28 = SL57.Appearance.Pressed;
			object? obj119 = colorConverter.ConvertFromString("174, 184, 194");
			pressed28.BackColor = ((obj119 != null) ? ((Color)obj119) : default(Color));
			AppearanceObject pressed29 = SL58.Appearance.Pressed;
			object? obj120 = colorConverter.ConvertFromString("174, 184, 194");
			pressed29.BackColor = ((obj120 != null) ? ((Color)obj120) : default(Color));
			AppearanceObject pressed30 = SL59.Appearance.Pressed;
			object? obj121 = colorConverter.ConvertFromString("174, 184, 194");
			pressed30.BackColor = ((obj121 != null) ? ((Color)obj121) : default(Color));
			AppearanceObject pressed31 = SL60.Appearance.Pressed;
			object? obj122 = colorConverter.ConvertFromString("174, 184, 194");
			pressed31.BackColor = ((obj122 != null) ? ((Color)obj122) : default(Color));
			AppearanceObject pressed32 = SL61.Appearance.Pressed;
			object? obj123 = colorConverter.ConvertFromString("174, 184, 194");
			pressed32.BackColor = ((obj123 != null) ? ((Color)obj123) : default(Color));
			AppearanceObject pressed33 = SL62.Appearance.Pressed;
			object? obj124 = colorConverter.ConvertFromString("174, 184, 194");
			pressed33.BackColor = ((obj124 != null) ? ((Color)obj124) : default(Color));
			AppearanceObject pressed34 = SL63.Appearance.Pressed;
			object? obj125 = colorConverter.ConvertFromString("174, 184, 194");
			pressed34.BackColor = ((obj125 != null) ? ((Color)obj125) : default(Color));
			AppearanceObject pressed35 = SL64.Appearance.Pressed;
			object? obj126 = colorConverter.ConvertFromString("174, 184, 194");
			pressed35.BackColor = ((obj126 != null) ? ((Color)obj126) : default(Color));
			AppearanceObject pressed36 = SL65.Appearance.Pressed;
			object? obj127 = colorConverter.ConvertFromString("174, 184, 194");
			pressed36.BackColor = ((obj127 != null) ? ((Color)obj127) : default(Color));
			FlowLayoutPanel pnlBotam3 = PnlBotam;
			object? obj128 = colorConverter.ConvertFromString("224, 224, 224");
			((Control)pnlBotam3).BackColor = ((obj128 != null) ? ((Color)obj128) : default(Color));
			TextBox obj129 = nCurrncyRate;
			object? obj130 = colorConverter.ConvertFromString("224, 224, 224");
			((TextBoxBase)obj129).BackColor = ((obj130 != null) ? ((Color)obj130) : default(Color));
			Label obj131 = lblLiveRate;
			object? obj132 = colorConverter.ConvertFromString("224, 224, 224");
			((Control)obj131).BackColor = ((obj132 != null) ? ((Color)obj132) : default(Color));
			Label obj133 = tAmcDate;
			object? obj134 = colorConverter.ConvertFromString("224, 224, 224");
			((Control)obj133).BackColor = ((obj134 != null) ? ((Color)obj134) : default(Color));
			TextBox obj135 = tSoftDemoType;
			object? obj136 = colorConverter.ConvertFromString("224, 224, 224");
			((TextBoxBase)obj135).BackColor = ((obj136 != null) ? ((Color)obj136) : default(Color));
			ComboBox obj137 = cboTheme;
			object? obj138 = colorConverter.ConvertFromString("224, 224, 224");
			obj137.BackColor = ((obj138 != null) ? ((Color)obj138) : default(Color));
		}
		else if (cboTheme.SelectedIndex == 3)
		{
			DC_Main.MsCoTheme = 4;
			DC_Main.RsQry = "UPDATE CO_SET SET THEME = 4 WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			object? obj139 = colorConverter.ConvertFromString("Control");
			((Form)this).BackColor = ((obj139 != null) ? ((Color)obj139) : default(Color));
			ToolStrip mainTrip3 = MainTrip;
			object? obj140 = colorConverter.ConvertFromString("CadetBlue");
			mainTrip3.BackColor = ((obj140 != null) ? ((Color)obj140) : default(Color));
			ToolStripTextBox obj141 = mMainDt;
			object? obj142 = colorConverter.ConvertFromString("CadetBlue");
			((ToolStripControlHost)obj141).BackColor = ((obj142 != null) ? ((Color)obj142) : default(Color));
			((BaseControl)SideTrip).LookAndFeel.SkinName = "Liquid Sky";
			AppearanceObject normal19 = SLMain.Appearance.Normal;
			object? obj143 = colorConverter.ConvertFromString("CadetBlue");
			normal19.BackColor = ((obj143 != null) ? ((Color)obj143) : default(Color));
			AppearanceObject normal20 = SLMain2.Appearance.Normal;
			object? obj144 = colorConverter.ConvertFromString("CadetBlue");
			normal20.BackColor = ((obj144 != null) ? ((Color)obj144) : default(Color));
			AppearanceObject normal21 = SLMain3.Appearance.Normal;
			object? obj145 = colorConverter.ConvertFromString("CadetBlue");
			normal21.BackColor = ((obj145 != null) ? ((Color)obj145) : default(Color));
			AppearanceObject normal22 = SLMain4.Appearance.Normal;
			object? obj146 = colorConverter.ConvertFromString("CadetBlue");
			normal22.BackColor = ((obj146 != null) ? ((Color)obj146) : default(Color));
			AppearanceObject normal23 = SLMain5.Appearance.Normal;
			object? obj147 = colorConverter.ConvertFromString("CadetBlue");
			normal23.BackColor = ((obj147 != null) ? ((Color)obj147) : default(Color));
			AppearanceObject normal24 = SLMain6.Appearance.Normal;
			object? obj148 = colorConverter.ConvertFromString("CadetBlue");
			normal24.BackColor = ((obj148 != null) ? ((Color)obj148) : default(Color));
			AppearanceObject hovered43 = SL0.Appearance.Hovered;
			object? obj149 = colorConverter.ConvertFromString("205, 220, 220");
			hovered43.BackColor = ((obj149 != null) ? ((Color)obj149) : default(Color));
			AppearanceObject hovered44 = SL1.Appearance.Hovered;
			object? obj150 = colorConverter.ConvertFromString("205, 220, 220");
			hovered44.BackColor = ((obj150 != null) ? ((Color)obj150) : default(Color));
			AppearanceObject hovered45 = SL2.Appearance.Hovered;
			object? obj151 = colorConverter.ConvertFromString("205, 220, 220");
			hovered45.BackColor = ((obj151 != null) ? ((Color)obj151) : default(Color));
			AppearanceObject hovered46 = SL3.Appearance.Hovered;
			object? obj152 = colorConverter.ConvertFromString("205, 220, 220");
			hovered46.BackColor = ((obj152 != null) ? ((Color)obj152) : default(Color));
			AppearanceObject hovered47 = SL4.Appearance.Hovered;
			object? obj153 = colorConverter.ConvertFromString("205, 220, 220");
			hovered47.BackColor = ((obj153 != null) ? ((Color)obj153) : default(Color));
			AppearanceObject hovered48 = SL5.Appearance.Hovered;
			object? obj154 = colorConverter.ConvertFromString("205, 220, 220");
			hovered48.BackColor = ((obj154 != null) ? ((Color)obj154) : default(Color));
			AppearanceObject hovered49 = SL6.Appearance.Hovered;
			object? obj155 = colorConverter.ConvertFromString("205, 220, 220");
			hovered49.BackColor = ((obj155 != null) ? ((Color)obj155) : default(Color));
			AppearanceObject hovered50 = SL7.Appearance.Hovered;
			object? obj156 = colorConverter.ConvertFromString("205, 220, 220");
			hovered50.BackColor = ((obj156 != null) ? ((Color)obj156) : default(Color));
			AppearanceObject hovered51 = SL8.Appearance.Hovered;
			object? obj157 = colorConverter.ConvertFromString("205, 220, 220");
			hovered51.BackColor = ((obj157 != null) ? ((Color)obj157) : default(Color));
			AppearanceObject hovered52 = SL9.Appearance.Hovered;
			object? obj158 = colorConverter.ConvertFromString("205, 220, 220");
			hovered52.BackColor = ((obj158 != null) ? ((Color)obj158) : default(Color));
			AppearanceObject hovered53 = SL10.Appearance.Hovered;
			object? obj159 = colorConverter.ConvertFromString("205, 220, 220");
			hovered53.BackColor = ((obj159 != null) ? ((Color)obj159) : default(Color));
			AppearanceObject hovered54 = SL11.Appearance.Hovered;
			object? obj160 = colorConverter.ConvertFromString("205, 220, 220");
			hovered54.BackColor = ((obj160 != null) ? ((Color)obj160) : default(Color));
			AppearanceObject hovered55 = SL12.Appearance.Hovered;
			object? obj161 = colorConverter.ConvertFromString("205, 220, 220");
			hovered55.BackColor = ((obj161 != null) ? ((Color)obj161) : default(Color));
			AppearanceObject hovered56 = SL13.Appearance.Hovered;
			object? obj162 = colorConverter.ConvertFromString("205, 220, 220");
			hovered56.BackColor = ((obj162 != null) ? ((Color)obj162) : default(Color));
			AppearanceObject hovered57 = SL14.Appearance.Hovered;
			object? obj163 = colorConverter.ConvertFromString("205, 220, 220");
			hovered57.BackColor = ((obj163 != null) ? ((Color)obj163) : default(Color));
			AppearanceObject hovered58 = SL15.Appearance.Hovered;
			object? obj164 = colorConverter.ConvertFromString("205, 220, 220");
			hovered58.BackColor = ((obj164 != null) ? ((Color)obj164) : default(Color));
			AppearanceObject hovered59 = SL16.Appearance.Hovered;
			object? obj165 = colorConverter.ConvertFromString("205, 220, 220");
			hovered59.BackColor = ((obj165 != null) ? ((Color)obj165) : default(Color));
			AppearanceObject hovered60 = SL17.Appearance.Hovered;
			object? obj166 = colorConverter.ConvertFromString("205, 220, 220");
			hovered60.BackColor = ((obj166 != null) ? ((Color)obj166) : default(Color));
			AppearanceObject hovered61 = SL18.Appearance.Hovered;
			object? obj167 = colorConverter.ConvertFromString("205, 220, 220");
			hovered61.BackColor = ((obj167 != null) ? ((Color)obj167) : default(Color));
			AppearanceObject hovered62 = SL19.Appearance.Hovered;
			object? obj168 = colorConverter.ConvertFromString("205, 220, 220");
			hovered62.BackColor = ((obj168 != null) ? ((Color)obj168) : default(Color));
			AppearanceObject hovered63 = SL20.Appearance.Hovered;
			object? obj169 = colorConverter.ConvertFromString("205, 220, 220");
			hovered63.BackColor = ((obj169 != null) ? ((Color)obj169) : default(Color));
			AppearanceObject pressed37 = SL0.Appearance.Pressed;
			object? obj170 = colorConverter.ConvertFromString("205, 220, 220");
			pressed37.BackColor = ((obj170 != null) ? ((Color)obj170) : default(Color));
			AppearanceObject pressed38 = SL1.Appearance.Pressed;
			object? obj171 = colorConverter.ConvertFromString("205, 220, 220");
			pressed38.BackColor = ((obj171 != null) ? ((Color)obj171) : default(Color));
			AppearanceObject pressed39 = SL2.Appearance.Pressed;
			object? obj172 = colorConverter.ConvertFromString("205, 220, 220");
			pressed39.BackColor = ((obj172 != null) ? ((Color)obj172) : default(Color));
			AppearanceObject pressed40 = SL3.Appearance.Pressed;
			object? obj173 = colorConverter.ConvertFromString("205, 220, 220");
			pressed40.BackColor = ((obj173 != null) ? ((Color)obj173) : default(Color));
			AppearanceObject pressed41 = SL4.Appearance.Pressed;
			object? obj174 = colorConverter.ConvertFromString("205, 220, 220");
			pressed41.BackColor = ((obj174 != null) ? ((Color)obj174) : default(Color));
			AppearanceObject pressed42 = SL5.Appearance.Pressed;
			object? obj175 = colorConverter.ConvertFromString("205, 220, 220");
			pressed42.BackColor = ((obj175 != null) ? ((Color)obj175) : default(Color));
			AppearanceObject pressed43 = SL6.Appearance.Pressed;
			object? obj176 = colorConverter.ConvertFromString("205, 220, 220");
			pressed43.BackColor = ((obj176 != null) ? ((Color)obj176) : default(Color));
			AppearanceObject pressed44 = SL7.Appearance.Pressed;
			object? obj177 = colorConverter.ConvertFromString("205, 220, 220");
			pressed44.BackColor = ((obj177 != null) ? ((Color)obj177) : default(Color));
			AppearanceObject pressed45 = SL8.Appearance.Pressed;
			object? obj178 = colorConverter.ConvertFromString("205, 220, 220");
			pressed45.BackColor = ((obj178 != null) ? ((Color)obj178) : default(Color));
			AppearanceObject pressed46 = SL9.Appearance.Pressed;
			object? obj179 = colorConverter.ConvertFromString("205, 220, 220");
			pressed46.BackColor = ((obj179 != null) ? ((Color)obj179) : default(Color));
			AppearanceObject pressed47 = SL10.Appearance.Pressed;
			object? obj180 = colorConverter.ConvertFromString("205, 220, 220");
			pressed47.BackColor = ((obj180 != null) ? ((Color)obj180) : default(Color));
			AppearanceObject pressed48 = SL11.Appearance.Pressed;
			object? obj181 = colorConverter.ConvertFromString("205, 220, 220");
			pressed48.BackColor = ((obj181 != null) ? ((Color)obj181) : default(Color));
			AppearanceObject pressed49 = SL12.Appearance.Pressed;
			object? obj182 = colorConverter.ConvertFromString("205, 220, 220");
			pressed49.BackColor = ((obj182 != null) ? ((Color)obj182) : default(Color));
			AppearanceObject pressed50 = SL13.Appearance.Pressed;
			object? obj183 = colorConverter.ConvertFromString("205, 220, 220");
			pressed50.BackColor = ((obj183 != null) ? ((Color)obj183) : default(Color));
			AppearanceObject pressed51 = SL14.Appearance.Pressed;
			object? obj184 = colorConverter.ConvertFromString("205, 220, 220");
			pressed51.BackColor = ((obj184 != null) ? ((Color)obj184) : default(Color));
			AppearanceObject pressed52 = SL15.Appearance.Pressed;
			object? obj185 = colorConverter.ConvertFromString("205, 220, 220");
			pressed52.BackColor = ((obj185 != null) ? ((Color)obj185) : default(Color));
			AppearanceObject pressed53 = SL16.Appearance.Pressed;
			object? obj186 = colorConverter.ConvertFromString("205, 220, 220");
			pressed53.BackColor = ((obj186 != null) ? ((Color)obj186) : default(Color));
			AppearanceObject pressed54 = SL17.Appearance.Pressed;
			object? obj187 = colorConverter.ConvertFromString("205, 220, 220");
			pressed54.BackColor = ((obj187 != null) ? ((Color)obj187) : default(Color));
			AppearanceObject pressed55 = SL18.Appearance.Pressed;
			object? obj188 = colorConverter.ConvertFromString("205, 220, 220");
			pressed55.BackColor = ((obj188 != null) ? ((Color)obj188) : default(Color));
			AppearanceObject pressed56 = SL19.Appearance.Pressed;
			object? obj189 = colorConverter.ConvertFromString("205, 220, 220");
			pressed56.BackColor = ((obj189 != null) ? ((Color)obj189) : default(Color));
			AppearanceObject pressed57 = SL20.Appearance.Pressed;
			object? obj190 = colorConverter.ConvertFromString("205, 220, 220");
			pressed57.BackColor = ((obj190 != null) ? ((Color)obj190) : default(Color));
			AppearanceObject pressed58 = SL0.Appearance.Pressed;
			object? obj191 = colorConverter.ConvertFromString("DarkGreen");
			pressed58.ForeColor = ((obj191 != null) ? ((Color)obj191) : default(Color));
			AppearanceObject pressed59 = SL1.Appearance.Pressed;
			object? obj192 = colorConverter.ConvertFromString("DarkGreen");
			pressed59.ForeColor = ((obj192 != null) ? ((Color)obj192) : default(Color));
			AppearanceObject pressed60 = SL2.Appearance.Pressed;
			object? obj193 = colorConverter.ConvertFromString("DarkGreen");
			pressed60.ForeColor = ((obj193 != null) ? ((Color)obj193) : default(Color));
			AppearanceObject pressed61 = SL3.Appearance.Pressed;
			object? obj194 = colorConverter.ConvertFromString("DarkGreen");
			pressed61.ForeColor = ((obj194 != null) ? ((Color)obj194) : default(Color));
			AppearanceObject pressed62 = SL4.Appearance.Pressed;
			object? obj195 = colorConverter.ConvertFromString("DarkGreen");
			pressed62.ForeColor = ((obj195 != null) ? ((Color)obj195) : default(Color));
			AppearanceObject pressed63 = SL5.Appearance.Pressed;
			object? obj196 = colorConverter.ConvertFromString("DarkGreen");
			pressed63.ForeColor = ((obj196 != null) ? ((Color)obj196) : default(Color));
			AppearanceObject pressed64 = SL6.Appearance.Pressed;
			object? obj197 = colorConverter.ConvertFromString("DarkGreen");
			pressed64.ForeColor = ((obj197 != null) ? ((Color)obj197) : default(Color));
			AppearanceObject pressed65 = SL7.Appearance.Pressed;
			object? obj198 = colorConverter.ConvertFromString("DarkGreen");
			pressed65.ForeColor = ((obj198 != null) ? ((Color)obj198) : default(Color));
			AppearanceObject pressed66 = SL8.Appearance.Pressed;
			object? obj199 = colorConverter.ConvertFromString("DarkGreen");
			pressed66.ForeColor = ((obj199 != null) ? ((Color)obj199) : default(Color));
			AppearanceObject pressed67 = SL9.Appearance.Pressed;
			object? obj200 = colorConverter.ConvertFromString("DarkGreen");
			pressed67.ForeColor = ((obj200 != null) ? ((Color)obj200) : default(Color));
			AppearanceObject pressed68 = SL10.Appearance.Pressed;
			object? obj201 = colorConverter.ConvertFromString("DarkGreen");
			pressed68.ForeColor = ((obj201 != null) ? ((Color)obj201) : default(Color));
			AppearanceObject pressed69 = SL11.Appearance.Pressed;
			object? obj202 = colorConverter.ConvertFromString("DarkGreen");
			pressed69.ForeColor = ((obj202 != null) ? ((Color)obj202) : default(Color));
			AppearanceObject pressed70 = SL12.Appearance.Pressed;
			object? obj203 = colorConverter.ConvertFromString("DarkGreen");
			pressed70.ForeColor = ((obj203 != null) ? ((Color)obj203) : default(Color));
			AppearanceObject pressed71 = SL13.Appearance.Pressed;
			object? obj204 = colorConverter.ConvertFromString("DarkGreen");
			pressed71.ForeColor = ((obj204 != null) ? ((Color)obj204) : default(Color));
			AppearanceObject pressed72 = SL14.Appearance.Pressed;
			object? obj205 = colorConverter.ConvertFromString("DarkGreen");
			pressed72.ForeColor = ((obj205 != null) ? ((Color)obj205) : default(Color));
			AppearanceObject pressed73 = SL15.Appearance.Pressed;
			object? obj206 = colorConverter.ConvertFromString("DarkGreen");
			pressed73.ForeColor = ((obj206 != null) ? ((Color)obj206) : default(Color));
			AppearanceObject pressed74 = SL16.Appearance.Pressed;
			object? obj207 = colorConverter.ConvertFromString("DarkGreen");
			pressed74.ForeColor = ((obj207 != null) ? ((Color)obj207) : default(Color));
			AppearanceObject pressed75 = SL17.Appearance.Pressed;
			object? obj208 = colorConverter.ConvertFromString("DarkGreen");
			pressed75.ForeColor = ((obj208 != null) ? ((Color)obj208) : default(Color));
			AppearanceObject pressed76 = SL18.Appearance.Pressed;
			object? obj209 = colorConverter.ConvertFromString("DarkGreen");
			pressed76.ForeColor = ((obj209 != null) ? ((Color)obj209) : default(Color));
			AppearanceObject pressed77 = SL19.Appearance.Pressed;
			object? obj210 = colorConverter.ConvertFromString("DarkGreen");
			pressed77.ForeColor = ((obj210 != null) ? ((Color)obj210) : default(Color));
			AppearanceObject pressed78 = SL20.Appearance.Pressed;
			object? obj211 = colorConverter.ConvertFromString("DarkGreen");
			pressed78.ForeColor = ((obj211 != null) ? ((Color)obj211) : default(Color));
			AppearanceObject hovered64 = SL51.Appearance.Hovered;
			object? obj212 = colorConverter.ConvertFromString("205, 220, 220");
			hovered64.BackColor = ((obj212 != null) ? ((Color)obj212) : default(Color));
			AppearanceObject hovered65 = SL52.Appearance.Hovered;
			object? obj213 = colorConverter.ConvertFromString("205, 220, 220");
			hovered65.BackColor = ((obj213 != null) ? ((Color)obj213) : default(Color));
			AppearanceObject hovered66 = SL53.Appearance.Hovered;
			object? obj214 = colorConverter.ConvertFromString("205, 220, 220");
			hovered66.BackColor = ((obj214 != null) ? ((Color)obj214) : default(Color));
			AppearanceObject hovered67 = SL54.Appearance.Hovered;
			object? obj215 = colorConverter.ConvertFromString("205, 220, 220");
			hovered67.BackColor = ((obj215 != null) ? ((Color)obj215) : default(Color));
			AppearanceObject hovered68 = SL55.Appearance.Hovered;
			object? obj216 = colorConverter.ConvertFromString("205, 220, 220");
			hovered68.BackColor = ((obj216 != null) ? ((Color)obj216) : default(Color));
			AppearanceObject hovered69 = SL56.Appearance.Hovered;
			object? obj217 = colorConverter.ConvertFromString("205, 220, 220");
			hovered69.BackColor = ((obj217 != null) ? ((Color)obj217) : default(Color));
			AppearanceObject hovered70 = SL57.Appearance.Hovered;
			object? obj218 = colorConverter.ConvertFromString("205, 220, 220");
			hovered70.BackColor = ((obj218 != null) ? ((Color)obj218) : default(Color));
			AppearanceObject hovered71 = SL58.Appearance.Hovered;
			object? obj219 = colorConverter.ConvertFromString("205, 220, 220");
			hovered71.BackColor = ((obj219 != null) ? ((Color)obj219) : default(Color));
			AppearanceObject hovered72 = SL59.Appearance.Hovered;
			object? obj220 = colorConverter.ConvertFromString("205, 220, 220");
			hovered72.BackColor = ((obj220 != null) ? ((Color)obj220) : default(Color));
			AppearanceObject hovered73 = SL60.Appearance.Hovered;
			object? obj221 = colorConverter.ConvertFromString("205, 220, 220");
			hovered73.BackColor = ((obj221 != null) ? ((Color)obj221) : default(Color));
			AppearanceObject hovered74 = SL61.Appearance.Hovered;
			object? obj222 = colorConverter.ConvertFromString("174, 184, 194");
			hovered74.BackColor = ((obj222 != null) ? ((Color)obj222) : default(Color));
			AppearanceObject hovered75 = SL62.Appearance.Hovered;
			object? obj223 = colorConverter.ConvertFromString("174, 184, 194");
			hovered75.BackColor = ((obj223 != null) ? ((Color)obj223) : default(Color));
			AppearanceObject hovered76 = SL63.Appearance.Hovered;
			object? obj224 = colorConverter.ConvertFromString("174, 184, 194");
			hovered76.BackColor = ((obj224 != null) ? ((Color)obj224) : default(Color));
			AppearanceObject hovered77 = SL64.Appearance.Hovered;
			object? obj225 = colorConverter.ConvertFromString("174, 184, 194");
			hovered77.BackColor = ((obj225 != null) ? ((Color)obj225) : default(Color));
			AppearanceObject hovered78 = SL65.Appearance.Hovered;
			object? obj226 = colorConverter.ConvertFromString("174, 184, 194");
			hovered78.BackColor = ((obj226 != null) ? ((Color)obj226) : default(Color));
			AppearanceObject pressed79 = SL51.Appearance.Pressed;
			object? obj227 = colorConverter.ConvertFromString("205, 220, 220");
			pressed79.BackColor = ((obj227 != null) ? ((Color)obj227) : default(Color));
			AppearanceObject pressed80 = SL52.Appearance.Pressed;
			object? obj228 = colorConverter.ConvertFromString("205, 220, 220");
			pressed80.BackColor = ((obj228 != null) ? ((Color)obj228) : default(Color));
			AppearanceObject pressed81 = SL53.Appearance.Pressed;
			object? obj229 = colorConverter.ConvertFromString("205, 220, 220");
			pressed81.BackColor = ((obj229 != null) ? ((Color)obj229) : default(Color));
			AppearanceObject pressed82 = SL54.Appearance.Pressed;
			object? obj230 = colorConverter.ConvertFromString("205, 220, 220");
			pressed82.BackColor = ((obj230 != null) ? ((Color)obj230) : default(Color));
			AppearanceObject pressed83 = SL55.Appearance.Pressed;
			object? obj231 = colorConverter.ConvertFromString("205, 220, 220");
			pressed83.BackColor = ((obj231 != null) ? ((Color)obj231) : default(Color));
			AppearanceObject pressed84 = SL56.Appearance.Pressed;
			object? obj232 = colorConverter.ConvertFromString("205, 220, 220");
			pressed84.BackColor = ((obj232 != null) ? ((Color)obj232) : default(Color));
			AppearanceObject pressed85 = SL57.Appearance.Pressed;
			object? obj233 = colorConverter.ConvertFromString("205, 220, 220");
			pressed85.BackColor = ((obj233 != null) ? ((Color)obj233) : default(Color));
			AppearanceObject pressed86 = SL58.Appearance.Pressed;
			object? obj234 = colorConverter.ConvertFromString("205, 220, 220");
			pressed86.BackColor = ((obj234 != null) ? ((Color)obj234) : default(Color));
			AppearanceObject pressed87 = SL59.Appearance.Pressed;
			object? obj235 = colorConverter.ConvertFromString("205, 220, 220");
			pressed87.BackColor = ((obj235 != null) ? ((Color)obj235) : default(Color));
			AppearanceObject pressed88 = SL60.Appearance.Pressed;
			object? obj236 = colorConverter.ConvertFromString("205, 220, 220");
			pressed88.BackColor = ((obj236 != null) ? ((Color)obj236) : default(Color));
			AppearanceObject pressed89 = SL61.Appearance.Pressed;
			object? obj237 = colorConverter.ConvertFromString("205, 220, 220");
			pressed89.BackColor = ((obj237 != null) ? ((Color)obj237) : default(Color));
			AppearanceObject pressed90 = SL62.Appearance.Pressed;
			object? obj238 = colorConverter.ConvertFromString("205, 220, 220");
			pressed90.BackColor = ((obj238 != null) ? ((Color)obj238) : default(Color));
			AppearanceObject pressed91 = SL63.Appearance.Pressed;
			object? obj239 = colorConverter.ConvertFromString("205, 220, 220");
			pressed91.BackColor = ((obj239 != null) ? ((Color)obj239) : default(Color));
			AppearanceObject pressed92 = SL64.Appearance.Pressed;
			object? obj240 = colorConverter.ConvertFromString("205, 220, 220");
			pressed92.BackColor = ((obj240 != null) ? ((Color)obj240) : default(Color));
			AppearanceObject pressed93 = SL65.Appearance.Pressed;
			object? obj241 = colorConverter.ConvertFromString("205, 220, 220");
			pressed93.BackColor = ((obj241 != null) ? ((Color)obj241) : default(Color));
			AppearanceObject pressed94 = SL51.Appearance.Pressed;
			object? obj242 = colorConverter.ConvertFromString("DarkGreen");
			pressed94.ForeColor = ((obj242 != null) ? ((Color)obj242) : default(Color));
			AppearanceObject pressed95 = SL52.Appearance.Pressed;
			object? obj243 = colorConverter.ConvertFromString("DarkGreen");
			pressed95.ForeColor = ((obj243 != null) ? ((Color)obj243) : default(Color));
			AppearanceObject pressed96 = SL53.Appearance.Pressed;
			object? obj244 = colorConverter.ConvertFromString("DarkGreen");
			pressed96.ForeColor = ((obj244 != null) ? ((Color)obj244) : default(Color));
			AppearanceObject pressed97 = SL54.Appearance.Pressed;
			object? obj245 = colorConverter.ConvertFromString("DarkGreen");
			pressed97.ForeColor = ((obj245 != null) ? ((Color)obj245) : default(Color));
			AppearanceObject pressed98 = SL55.Appearance.Pressed;
			object? obj246 = colorConverter.ConvertFromString("DarkGreen");
			pressed98.ForeColor = ((obj246 != null) ? ((Color)obj246) : default(Color));
			AppearanceObject pressed99 = SL56.Appearance.Pressed;
			object? obj247 = colorConverter.ConvertFromString("DarkGreen");
			pressed99.ForeColor = ((obj247 != null) ? ((Color)obj247) : default(Color));
			AppearanceObject pressed100 = SL57.Appearance.Pressed;
			object? obj248 = colorConverter.ConvertFromString("DarkGreen");
			pressed100.ForeColor = ((obj248 != null) ? ((Color)obj248) : default(Color));
			AppearanceObject pressed101 = SL58.Appearance.Pressed;
			object? obj249 = colorConverter.ConvertFromString("DarkGreen");
			pressed101.ForeColor = ((obj249 != null) ? ((Color)obj249) : default(Color));
			AppearanceObject pressed102 = SL59.Appearance.Pressed;
			object? obj250 = colorConverter.ConvertFromString("DarkGreen");
			pressed102.ForeColor = ((obj250 != null) ? ((Color)obj250) : default(Color));
			AppearanceObject pressed103 = SL60.Appearance.Pressed;
			object? obj251 = colorConverter.ConvertFromString("DarkGreen");
			pressed103.ForeColor = ((obj251 != null) ? ((Color)obj251) : default(Color));
			AppearanceObject pressed104 = SL61.Appearance.Pressed;
			object? obj252 = colorConverter.ConvertFromString("DarkGreen");
			pressed104.ForeColor = ((obj252 != null) ? ((Color)obj252) : default(Color));
			AppearanceObject pressed105 = SL62.Appearance.Pressed;
			object? obj253 = colorConverter.ConvertFromString("DarkGreen");
			pressed105.ForeColor = ((obj253 != null) ? ((Color)obj253) : default(Color));
			AppearanceObject pressed106 = SL63.Appearance.Pressed;
			object? obj254 = colorConverter.ConvertFromString("DarkGreen");
			pressed106.ForeColor = ((obj254 != null) ? ((Color)obj254) : default(Color));
			AppearanceObject pressed107 = SL64.Appearance.Pressed;
			object? obj255 = colorConverter.ConvertFromString("DarkGreen");
			pressed107.ForeColor = ((obj255 != null) ? ((Color)obj255) : default(Color));
			AppearanceObject pressed108 = SL65.Appearance.Pressed;
			object? obj256 = colorConverter.ConvertFromString("DarkGreen");
			pressed108.ForeColor = ((obj256 != null) ? ((Color)obj256) : default(Color));
			AppearanceObject hovered79 = SL75.Appearance.Hovered;
			object? obj257 = colorConverter.ConvertFromString("205, 220, 220");
			hovered79.BackColor = ((obj257 != null) ? ((Color)obj257) : default(Color));
			AppearanceObject hovered80 = SL76.Appearance.Hovered;
			object? obj258 = colorConverter.ConvertFromString("205, 220, 220");
			hovered80.BackColor = ((obj258 != null) ? ((Color)obj258) : default(Color));
			AppearanceObject hovered81 = SL77.Appearance.Hovered;
			object? obj259 = colorConverter.ConvertFromString("205, 220, 220");
			hovered81.BackColor = ((obj259 != null) ? ((Color)obj259) : default(Color));
			AppearanceObject hovered82 = SL78.Appearance.Hovered;
			object? obj260 = colorConverter.ConvertFromString("205, 220, 220");
			hovered82.BackColor = ((obj260 != null) ? ((Color)obj260) : default(Color));
			AppearanceObject hovered83 = SL79.Appearance.Hovered;
			object? obj261 = colorConverter.ConvertFromString("205, 220, 220");
			hovered83.BackColor = ((obj261 != null) ? ((Color)obj261) : default(Color));
			AppearanceObject hovered84 = SL80.Appearance.Hovered;
			object? obj262 = colorConverter.ConvertFromString("205, 220, 220");
			hovered84.BackColor = ((obj262 != null) ? ((Color)obj262) : default(Color));
			AppearanceObject hovered85 = SL81.Appearance.Hovered;
			object? obj263 = colorConverter.ConvertFromString("205, 220, 220");
			hovered85.BackColor = ((obj263 != null) ? ((Color)obj263) : default(Color));
			AppearanceObject hovered86 = SL82.Appearance.Hovered;
			object? obj264 = colorConverter.ConvertFromString("205, 220, 220");
			hovered86.BackColor = ((obj264 != null) ? ((Color)obj264) : default(Color));
			AppearanceObject hovered87 = SL83.Appearance.Hovered;
			object? obj265 = colorConverter.ConvertFromString("205, 220, 220");
			hovered87.BackColor = ((obj265 != null) ? ((Color)obj265) : default(Color));
			AppearanceObject hovered88 = SL84.Appearance.Hovered;
			object? obj266 = colorConverter.ConvertFromString("205, 220, 220");
			hovered88.BackColor = ((obj266 != null) ? ((Color)obj266) : default(Color));
			AppearanceObject hovered89 = SL85.Appearance.Hovered;
			object? obj267 = colorConverter.ConvertFromString("205, 220, 220");
			hovered89.BackColor = ((obj267 != null) ? ((Color)obj267) : default(Color));
			AppearanceObject hovered90 = SL86.Appearance.Hovered;
			object? obj268 = colorConverter.ConvertFromString("205, 220, 220");
			hovered90.BackColor = ((obj268 != null) ? ((Color)obj268) : default(Color));
			AppearanceObject hovered91 = SL87.Appearance.Hovered;
			object? obj269 = colorConverter.ConvertFromString("205, 220, 220");
			hovered91.BackColor = ((obj269 != null) ? ((Color)obj269) : default(Color));
			AppearanceObject hovered92 = SL88.Appearance.Hovered;
			object? obj270 = colorConverter.ConvertFromString("205, 220, 220");
			hovered92.BackColor = ((obj270 != null) ? ((Color)obj270) : default(Color));
			AppearanceObject hovered93 = SL89.Appearance.Hovered;
			object? obj271 = colorConverter.ConvertFromString("205, 220, 220");
			hovered93.BackColor = ((obj271 != null) ? ((Color)obj271) : default(Color));
			AppearanceObject hovered94 = SL90.Appearance.Hovered;
			object? obj272 = colorConverter.ConvertFromString("205, 220, 220");
			hovered94.BackColor = ((obj272 != null) ? ((Color)obj272) : default(Color));
			AppearanceObject pressed109 = SL75.Appearance.Pressed;
			object? obj273 = colorConverter.ConvertFromString("205, 220, 220");
			pressed109.BackColor = ((obj273 != null) ? ((Color)obj273) : default(Color));
			AppearanceObject pressed110 = SL76.Appearance.Pressed;
			object? obj274 = colorConverter.ConvertFromString("205, 220, 220");
			pressed110.BackColor = ((obj274 != null) ? ((Color)obj274) : default(Color));
			AppearanceObject pressed111 = SL77.Appearance.Pressed;
			object? obj275 = colorConverter.ConvertFromString("205, 220, 220");
			pressed111.BackColor = ((obj275 != null) ? ((Color)obj275) : default(Color));
			AppearanceObject pressed112 = SL78.Appearance.Pressed;
			object? obj276 = colorConverter.ConvertFromString("205, 220, 220");
			pressed112.BackColor = ((obj276 != null) ? ((Color)obj276) : default(Color));
			AppearanceObject pressed113 = SL79.Appearance.Pressed;
			object? obj277 = colorConverter.ConvertFromString("205, 220, 220");
			pressed113.BackColor = ((obj277 != null) ? ((Color)obj277) : default(Color));
			AppearanceObject pressed114 = SL80.Appearance.Pressed;
			object? obj278 = colorConverter.ConvertFromString("205, 220, 220");
			pressed114.BackColor = ((obj278 != null) ? ((Color)obj278) : default(Color));
			AppearanceObject pressed115 = SL81.Appearance.Pressed;
			object? obj279 = colorConverter.ConvertFromString("205, 220, 220");
			pressed115.BackColor = ((obj279 != null) ? ((Color)obj279) : default(Color));
			AppearanceObject pressed116 = SL82.Appearance.Pressed;
			object? obj280 = colorConverter.ConvertFromString("205, 220, 220");
			pressed116.BackColor = ((obj280 != null) ? ((Color)obj280) : default(Color));
			AppearanceObject pressed117 = SL83.Appearance.Pressed;
			object? obj281 = colorConverter.ConvertFromString("205, 220, 220");
			pressed117.BackColor = ((obj281 != null) ? ((Color)obj281) : default(Color));
			AppearanceObject pressed118 = SL84.Appearance.Pressed;
			object? obj282 = colorConverter.ConvertFromString("205, 220, 220");
			pressed118.BackColor = ((obj282 != null) ? ((Color)obj282) : default(Color));
			AppearanceObject pressed119 = SL85.Appearance.Pressed;
			object? obj283 = colorConverter.ConvertFromString("205, 220, 220");
			pressed119.BackColor = ((obj283 != null) ? ((Color)obj283) : default(Color));
			AppearanceObject pressed120 = SL86.Appearance.Pressed;
			object? obj284 = colorConverter.ConvertFromString("205, 220, 220");
			pressed120.BackColor = ((obj284 != null) ? ((Color)obj284) : default(Color));
			AppearanceObject pressed121 = SL87.Appearance.Pressed;
			object? obj285 = colorConverter.ConvertFromString("205, 220, 220");
			pressed121.BackColor = ((obj285 != null) ? ((Color)obj285) : default(Color));
			AppearanceObject pressed122 = SL88.Appearance.Pressed;
			object? obj286 = colorConverter.ConvertFromString("205, 220, 220");
			pressed122.BackColor = ((obj286 != null) ? ((Color)obj286) : default(Color));
			AppearanceObject pressed123 = SL89.Appearance.Pressed;
			object? obj287 = colorConverter.ConvertFromString("205, 220, 220");
			pressed123.BackColor = ((obj287 != null) ? ((Color)obj287) : default(Color));
			AppearanceObject pressed124 = SL90.Appearance.Pressed;
			object? obj288 = colorConverter.ConvertFromString("205, 220, 220");
			pressed124.BackColor = ((obj288 != null) ? ((Color)obj288) : default(Color));
			AppearanceObject pressed125 = SL75.Appearance.Pressed;
			object? obj289 = colorConverter.ConvertFromString("DarkGreen");
			pressed125.ForeColor = ((obj289 != null) ? ((Color)obj289) : default(Color));
			AppearanceObject pressed126 = SL76.Appearance.Pressed;
			object? obj290 = colorConverter.ConvertFromString("DarkGreen");
			pressed126.ForeColor = ((obj290 != null) ? ((Color)obj290) : default(Color));
			AppearanceObject pressed127 = SL77.Appearance.Pressed;
			object? obj291 = colorConverter.ConvertFromString("DarkGreen");
			pressed127.ForeColor = ((obj291 != null) ? ((Color)obj291) : default(Color));
			AppearanceObject pressed128 = SL78.Appearance.Pressed;
			object? obj292 = colorConverter.ConvertFromString("DarkGreen");
			pressed128.ForeColor = ((obj292 != null) ? ((Color)obj292) : default(Color));
			AppearanceObject pressed129 = SL79.Appearance.Pressed;
			object? obj293 = colorConverter.ConvertFromString("DarkGreen");
			pressed129.ForeColor = ((obj293 != null) ? ((Color)obj293) : default(Color));
			AppearanceObject pressed130 = SL80.Appearance.Pressed;
			object? obj294 = colorConverter.ConvertFromString("DarkGreen");
			pressed130.ForeColor = ((obj294 != null) ? ((Color)obj294) : default(Color));
			AppearanceObject pressed131 = SL81.Appearance.Pressed;
			object? obj295 = colorConverter.ConvertFromString("DarkGreen");
			pressed131.ForeColor = ((obj295 != null) ? ((Color)obj295) : default(Color));
			AppearanceObject pressed132 = SL82.Appearance.Pressed;
			object? obj296 = colorConverter.ConvertFromString("DarkGreen");
			pressed132.ForeColor = ((obj296 != null) ? ((Color)obj296) : default(Color));
			AppearanceObject pressed133 = SL83.Appearance.Pressed;
			object? obj297 = colorConverter.ConvertFromString("DarkGreen");
			pressed133.ForeColor = ((obj297 != null) ? ((Color)obj297) : default(Color));
			AppearanceObject pressed134 = SL84.Appearance.Pressed;
			object? obj298 = colorConverter.ConvertFromString("DarkGreen");
			pressed134.ForeColor = ((obj298 != null) ? ((Color)obj298) : default(Color));
			AppearanceObject pressed135 = SL85.Appearance.Pressed;
			object? obj299 = colorConverter.ConvertFromString("DarkGreen");
			pressed135.ForeColor = ((obj299 != null) ? ((Color)obj299) : default(Color));
			AppearanceObject pressed136 = SL86.Appearance.Pressed;
			object? obj300 = colorConverter.ConvertFromString("DarkGreen");
			pressed136.ForeColor = ((obj300 != null) ? ((Color)obj300) : default(Color));
			AppearanceObject pressed137 = SL87.Appearance.Pressed;
			object? obj301 = colorConverter.ConvertFromString("DarkGreen");
			pressed137.ForeColor = ((obj301 != null) ? ((Color)obj301) : default(Color));
			AppearanceObject pressed138 = SL88.Appearance.Pressed;
			object? obj302 = colorConverter.ConvertFromString("DarkGreen");
			pressed138.ForeColor = ((obj302 != null) ? ((Color)obj302) : default(Color));
			AppearanceObject pressed139 = SL89.Appearance.Pressed;
			object? obj303 = colorConverter.ConvertFromString("DarkGreen");
			pressed139.ForeColor = ((obj303 != null) ? ((Color)obj303) : default(Color));
			AppearanceObject pressed140 = SL90.Appearance.Pressed;
			object? obj304 = colorConverter.ConvertFromString("DarkGreen");
			pressed140.ForeColor = ((obj304 != null) ? ((Color)obj304) : default(Color));
			FlowLayoutPanel pnlBotam4 = PnlBotam;
			object? obj305 = colorConverter.ConvertFromString("Control");
			((Control)pnlBotam4).BackColor = ((obj305 != null) ? ((Color)obj305) : default(Color));
			TextBox obj306 = nCurrncyRate;
			object? obj307 = colorConverter.ConvertFromString("Control");
			((TextBoxBase)obj306).BackColor = ((obj307 != null) ? ((Color)obj307) : default(Color));
			Label obj308 = lblLiveRate;
			object? obj309 = colorConverter.ConvertFromString("Control");
			((Control)obj308).BackColor = ((obj309 != null) ? ((Color)obj309) : default(Color));
			Label obj310 = tAmcDate;
			object? obj311 = colorConverter.ConvertFromString("Control");
			((Control)obj310).BackColor = ((obj311 != null) ? ((Color)obj311) : default(Color));
			TextBox obj312 = tSoftDemoType;
			object? obj313 = colorConverter.ConvertFromString("Control");
			((TextBoxBase)obj312).BackColor = ((obj313 != null) ? ((Color)obj313) : default(Color));
			ComboBox obj314 = cboTheme;
			object? obj315 = colorConverter.ConvertFromString("Control");
			obj314.BackColor = ((obj315 != null) ? ((Color)obj315) : default(Color));
		}
	}

	private void Country_Rate()
	{
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT * From CONV_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CON_CODE = '" + DC_Main.MsCountryCode + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count >= 0)
		{
			DC_Main.MsOzGoldRate = Conversions.ToDouble(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GOLD_OZ_RATE"], (object)""));
			DC_Main.MsOzSilverRate = Conversions.ToDouble(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SILVER_OZ_RATE"], (object)""));
			DC_Main.MsCurrency = Conversions.ToDouble(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CURRENCY_RATE"], (object)""));
			DC_Main.MsOzConvVal = 31.1035;
			DC_Main.MsOzGlConv = Conversions.ToDouble(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GOLD_CONV"], (object)""));
			DC_Main.MsOzSlConv = Conversions.ToDouble(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SILVER_CONV"], (object)""));
			((Control)chkLiveRate).ForeColor = Color.Navy;
			((TextBoxBase)nCurrncyRate).ForeColor = Color.Navy;
			nCurrncyRate.Text = "  Usd/Inr Rate : " + Strings.Format((object)DC_Main.MsCurrency, "0.00");
			((Control)lblLiveRate).ForeColor = Color.Navy;
			lblLiveRate.Text = ("  Gold : " + Strings.Format((object)(DC_Main.MsOzGoldRate * DC_Main.MsCurrency / DC_Main.MsOzConvVal * 10.0 * DC_Main.MsOzGlConv), "0") + "    Silver : " + Strings.Format((object)(DC_Main.MsOzSilverRate * DC_Main.MsCurrency / DC_Main.MsOzConvVal * 1000.0 * DC_Main.MsOzSlConv), "0") + "   RtDate : " + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["RATE_DATE"]), "dd-MM-yy hh:mm")) ?? "";
		}
		else
		{
			Interaction.MsgBox((object)"No Record Found", (MsgBoxStyle)0, (object)null);
		}
		DC_Main.Rshlp.Clear();
	}

	private void Timer1_Tick(object sender, EventArgs e)
	{
		checked
		{
			if (Lr > 2)
			{
				Lr = 0;
				if (DC_Main.LiveRateDisplay)
				{
					chkLiveRate.Checked = false;
					((Control)chkLiveRate).ForeColor = Color.Navy;
					DC_Main.LiveRateDisplay = false;
					Timer1.Enabled = true;
					Country_Rate();
				}
			}
			else
			{
				Lr++;
			}
		}
	}

	private async Task<decimal> GetUsdToInrRate()
	{
		try
		{
			HttpClient val = new HttpClient();
			try
			{
				string text = "https://api.frankfurter.app/latest?base=USD&symbols=INR";
				JObject val2 = JObject.Parse(await val.GetStringAsync(text));
				return Extensions.Value<decimal>((IEnumerable<JToken>)val2["rates"][(object)"INR"]);
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Exception ex3 = ex2;
			MessageBox.Show("Error fetching USD→INR rate: " + ex3.Message);
			decimal result = default(decimal);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private async Task<decimal> GetMetalPrice(string symbol)
	{
		try
		{
			HttpClient val = new HttpClient();
			try
			{
				string text = "https://api.gold-api.com/price/" + symbol;
				JObject val2 = JObject.Parse(await val.GetStringAsync(text));
				return Extensions.Value<decimal>((IEnumerable<JToken>)val2["price"]);
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Exception ex3 = ex2;
			MessageBox.Show("Error fetching rate: " + ex3.Message);
			decimal result = default(decimal);
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private async Task LoadGoldRate()
	{
		try
		{
			decimal num = await GetUsdToInrRate();
			decimal num2 = await GetMetalPrice("XAU");
			decimal num3 = await GetMetalPrice("XAG");
			double value = Convert.ToDouble(decimal.Multiply(num2, num)) / 31.1035 * 10.0 * 1.0884;
			double value2 = Convert.ToDouble(decimal.Multiply(num3, num)) / 31.1035 * 1000.0 * 1.095;
			lblLiveRate.Text = "Gold : " + Conversions.ToString(Math.Round(value, 0)) + " Silver : " + Conversions.ToString(Math.Round(value2, 0));
			DC_Main.RsQry = "UPDATE CONV_MAST SET GOLD_OZ_RATE = " + Conversions.ToString(num2) + ",  SILVER_OZ_RATE = " + Conversions.ToString(num3) + ",  CURRENCY_RATE = " + Conversions.ToString(num) + ",  GOLD_PR_RATE = " + Conversions.ToString(Math.Round(value, 0)) + ",  SILVER_PR_RATE = " + Conversions.ToString(Math.Round(value2, 0)) + ",  RATE_DATE = '" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy hh:mm") + "'  WHERE  CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Exception ex3 = ex2;
			MessageBox.Show("Error: " + ex3.Message);
			ProjectData.ClearProjectError();
		}
	}

	private async void chkLiveRate_Click(object sender, EventArgs e)
	{
		if (!IsInternetConnected())
		{
			Interaction.MsgBox((object)"You Don't Have internet connection...", (MsgBoxStyle)0, (object)null);
			chkLiveRate.Checked = false;
		}
		else if (chkLiveRate.Checked)
		{
			((Control)chkLiveRate).ForeColor = Color.Maroon;
			DC_Main.LiveRateDisplay = true;
			Timer1.Enabled = true;
			await LoadGoldRate();
		}
		else
		{
			((Control)chkLiveRate).ForeColor = Color.Navy;
			DC_Main.LiveRateDisplay = false;
			Timer1.Enabled = false;
			Country_Rate();
		}
	}

	public bool IsInternetConnected()
	{
		try
		{
			using WebClient webClient = new WebClient();
			using (webClient.OpenRead("http://www.google.com"))
			{
				return true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return false;
	}

	private void ShoF2Ledger_Click(object sender, EventArgs e)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.MsUserRightForm = "Ledger Report";
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)PanelImage).Visible = true;
			return;
		}
		PanalImage_Hide();
		RP_LEDR rP_LEDR = new RP_LEDR();
		((Form)rP_LEDR).MdiParent = (Form)(object)this;
		checked
		{
			DC_Main.TotOpenForm++;
			((Form)rP_LEDR).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
			((Control)rP_LEDR).Show();
			((Control)rP_LEDR).Focus();
		}
	}

	private void ShoF3Stock_Click(object sender, EventArgs e)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.MsUserRightForm = "Stock Report";
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)PanelImage).Visible = true;
			return;
		}
		PanalImage_Hide();
		RP_STOCK rP_STOCK = new RP_STOCK();
		((Form)rP_STOCK).MdiParent = (Form)(object)this;
		checked
		{
			DC_Main.TotOpenForm++;
			((Form)rP_STOCK).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
			((Control)rP_STOCK).Show();
			((Control)rP_STOCK).Focus();
		}
	}

	private void ShoF4SalesOrder_Click(object sender, EventArgs e)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.MsUserRightForm = "Sales Order";
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)PanelImage).Visible = true;
			return;
		}
		DC_Main.CurBookHelp("SALES ORDER");
		checked
		{
			if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
			{
				PanalImage_Hide();
				TR_SALE_ORD tR_SALE_ORD = new TR_SALE_ORD();
				((Form)tR_SALE_ORD).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)tR_SALE_ORD).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_SALE_ORD).Show();
				((Control)tR_SALE_ORD).Focus();
			}
		}
	}

	private void ShoF5SalesBill_Click(object sender, EventArgs e)
	{
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM396NEHM", false) == 0)
			{
				DC_Main.MsUserRightForm = "Bul Sales";
				DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
				RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
				if (RsRight.Rows.Count == 0)
				{
					DC_Main.MsUserRightForm = "";
					Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
					((Control)PanelImage).Visible = true;
					return;
				}
				DC_Main.CurBookHelp("BUL WH SALE");
				if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
				{
					PanalImage_Hide();
					TR_BUL_SALE tR_BUL_SALE = new TR_BUL_SALE();
					((Form)tR_BUL_SALE).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_BUL_SALE).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_BUL_SALE).Show();
					((Control)tR_BUL_SALE).Focus();
				}
				return;
			}
			DC_Main.MsUserRightForm = "Sales";
			DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
			RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			if (RsRight.Rows.Count == 0)
			{
				DC_Main.MsUserRightForm = "";
				Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
				((Control)PanelImage).Visible = true;
				return;
			}
			DC_Main.CurBookHelp("SALES");
			if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
			{
				PanalImage_Hide();
				if (Operators.CompareString(DC_Main.MsSalesWithHmTax, "Y", false) == 0)
				{
					TR_SALE_HM tR_SALE_HM = new TR_SALE_HM();
					((Form)tR_SALE_HM).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_SALE_HM).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_SALE_HM).Show();
					((Control)tR_SALE_HM).Focus();
				}
				else
				{
					TR_SALE tR_SALE = new TR_SALE();
					((Form)tR_SALE).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_SALE).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_SALE).Show();
					((Control)tR_SALE).Focus();
				}
			}
		}
	}

	private void Shof12TagWiseStock_Click(object sender, EventArgs e)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.MsUserRightForm = "Tag Stock";
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)PanelImage).Visible = true;
			return;
		}
		PanalImage_Hide();
		RP_TAG rP_TAG = new RP_TAG();
		((Form)rP_TAG).MdiParent = (Form)(object)this;
		checked
		{
			DC_Main.TotOpenForm++;
			((XtraForm)rP_TAG).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
			((Control)rP_TAG).Show();
			((Control)rP_TAG).Focus();
		}
	}

	private void ShoF7Purc_Click(object sender, EventArgs e)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.MsUserRightForm = "Purchase";
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)PanelImage).Visible = true;
			return;
		}
		DC_Main.CurBookHelp("PURCHASE");
		checked
		{
			if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
			{
				PanalImage_Hide();
				if (Operators.CompareString(DC_Main.MsPurcWithHmTax, "Y", false) == 0)
				{
					TR_PURC_HM tR_PURC_HM = new TR_PURC_HM();
					((Form)tR_PURC_HM).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_PURC_HM).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_PURC_HM).Show();
					((Control)tR_PURC_HM).Focus();
				}
				else
				{
					TR_PURC tR_PURC = new TR_PURC();
					((Form)tR_PURC).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)tR_PURC).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)tR_PURC).Show();
					((Control)tR_PURC).Focus();
				}
			}
		}
	}

	private void ShoF8CashRec_Click(object sender, EventArgs e)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.MsUserRightForm = "Cash Received";
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)PanelImage).Visible = true;
			return;
		}
		DC_Main.CurBookHelp("CASH REC");
		checked
		{
			if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
			{
				PanalImage_Hide();
				TR_CASH tR_CASH = new TR_CASH();
				((Form)tR_CASH).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)tR_CASH).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_CASH).Show();
				((Control)tR_CASH).Focus();
			}
		}
	}

	private void ShoF9CashPayment_Click(object sender, EventArgs e)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.MsUserRightForm = "Cash Payment";
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)PanelImage).Visible = true;
			return;
		}
		DC_Main.CurBookHelp("CASH PAY");
		checked
		{
			if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
			{
				PanalImage_Hide();
				TR_CASH tR_CASH = new TR_CASH();
				((Form)tR_CASH).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)tR_CASH).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_CASH).Show();
				((Control)tR_CASH).Focus();
			}
		}
	}

	private void ShoF6WhSales_Click(object sender, EventArgs e)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.MsUserRightForm = "Wh Sales";
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)PanelImage).Visible = true;
			return;
		}
		DC_Main.CurBookHelp("WH SALES");
		checked
		{
			if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
			{
				PanalImage_Hide();
				TR_WH_SALE tR_WH_SALE = new TR_WH_SALE();
				((Form)tR_WH_SALE).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)tR_WH_SALE).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_WH_SALE).Show();
				((Control)tR_WH_SALE).Focus();
			}
		}
	}

	private void ShoF11Rojmel_Click(object sender, EventArgs e)
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (Operators.CompareString(DC_Main.MsSoftType, "L", false) != 0)
			{
				DC_Main.MsUserRightForm = "Rojmel";
				DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
				RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
				if (RsRight.Rows.Count == 0)
				{
					DC_Main.MsUserRightForm = "";
					Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
					((Control)PanelImage).Visible = true;
					return;
				}
				PanalImage_Hide();
				RP_ROJMEL rP_ROJMEL = new RP_ROJMEL();
				((Form)rP_ROJMEL).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ROJMEL).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ROJMEL).Show();
				((Control)rP_ROJMEL).Focus();
			}
		}
	}

	private void mMainDt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			string text = Strings.Format((object)DateAndTime.Now, "yyyy");
			string text2 = Strings.Format((object)DateAndTime.Now, "dd/MM/yyyy");
			checked
			{
				int num = Strings.Len(((ToolStripControlHost)mMainDt).Text) - 1;
				int i;
				for (i = 1; i <= num && Operators.CompareString(Strings.Mid(((ToolStripControlHost)mMainDt).Text, i, 1), "", false) != 0; i++)
				{
				}
				if (i > 5)
				{
					text = Conversions.ToString(Interaction.IIf(Conversion.Val(Strings.Mid(((ToolStripControlHost)mMainDt).Text, 4, 2)) < 4.0, (object)Strings.Mid(DC_Main.MCo_year, 6, 4), (object)Strings.Mid(DC_Main.MCo_year, 1, 4)));
				}
				switch (i)
				{
				case 1:
					((ToolStripControlHost)mMainDt).Text = DateAndTime.Today.Day.ToString("00") + "/" + DateAndTime.Today.Month.ToString("00") + "/" + text;
					break;
				case 2:
					((ToolStripControlHost)mMainDt).Text = Strings.Mid(((ToolStripControlHost)mMainDt).Text, 1, 2) + "/" + Strings.Mid(text2, 4, 2) + "/" + text;
					break;
				case 3:
					((ToolStripControlHost)mMainDt).Text = Strings.Mid(((ToolStripControlHost)mMainDt).Text, 1, 2) + "/" + Strings.Mid(text2, 4, 2) + "/" + text;
					break;
				case 4:
					((ToolStripControlHost)mMainDt).Text = Strings.Mid(((ToolStripControlHost)mMainDt).Text, 1, 2) + "/" + Strings.Format((object)Conversion.Val(Strings.Mid(((ToolStripControlHost)mMainDt).Text, 4, 1)), "00") + "/" + text;
					break;
				case 5:
					((ToolStripControlHost)mMainDt).Text = Strings.Mid(((ToolStripControlHost)mMainDt).Text, 1, 2) + "/" + Strings.Mid(text2, 4, 2) + "/" + text;
					break;
				case 6:
					((ToolStripControlHost)mMainDt).Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)(Strings.Mid(((ToolStripControlHost)mMainDt).Text, 1, 2) + "/"), Interaction.IIf((Operators.CompareString(Strings.Mid(((ToolStripControlHost)mMainDt).Text, 4, 2), "  ", false) == 0) | (Operators.CompareString(Strings.Mid(((ToolStripControlHost)mMainDt).Text, 5, 1), " ", false) == 0), (object)Strings.Mid(text2, 4, 2), (object)Strings.Mid(((ToolStripControlHost)mMainDt).Text, 4, 2))), (object)"/"), (object)text));
					break;
				case 7:
					((ToolStripControlHost)mMainDt).Text = Strings.Mid(((ToolStripControlHost)mMainDt).Text, 1, 2) + "/" + Strings.Mid(((ToolStripControlHost)mMainDt).Text, 4, 2) + "/" + text;
					break;
				case 8:
					((ToolStripControlHost)mMainDt).Text = Strings.Mid(((ToolStripControlHost)mMainDt).Text, 1, 2) + "/" + Strings.Mid(((ToolStripControlHost)mMainDt).Text, 4, 2) + "/" + text;
					break;
				case 9:
					((ToolStripControlHost)mMainDt).Text = Strings.Mid(((ToolStripControlHost)mMainDt).Text, 1, 2) + "/" + Strings.Mid(((ToolStripControlHost)mMainDt).Text, 4, 2) + "/" + text;
					break;
				case 10:
					((ToolStripControlHost)mMainDt).Text = Strings.Mid(((ToolStripControlHost)mMainDt).Text, 1, 2) + "/" + Strings.Mid(((ToolStripControlHost)mMainDt).Text, 4, 2) + "/" + Strings.Mid(((ToolStripControlHost)mMainDt).Text, 7, 10);
					break;
				}
				DC_Main.MsSysDate = Conversions.ToDate(((ToolStripControlHost)mMainDt).Text);
				DC_Main.RsQry = "SELECT CO_CODE,LC_CODE,VCH_DATE,SR_NO,GR_CODE,GR_RATE,GR_TOUCH,GR_TAX_RATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					DC_Main.RtView = new DataView(DC_Main.Rshlp);
				}
				((Control)SideTrip).Focus();
			}
		}
	}

	private void mMainDt_KeyUp(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 8)
		{
			if (Strings.Len(((ToolStripControlHost)mMainDt).Text) == 2)
			{
				((ToolStripControlHost)mMainDt).Text = ((ToolStripControlHost)mMainDt).Text + "/";
			}
			else if (Strings.Len(((ToolStripControlHost)mMainDt).Text) == 5)
			{
				((ToolStripControlHost)mMainDt).Text = ((ToolStripControlHost)mMainDt).Text + "/";
			}
			mMainDt.SelectionStart = Strings.Len(((ToolStripControlHost)mMainDt).Text);
		}
	}

	private void ShoCtrlF12TagEstmate_Click(object sender, EventArgs e)
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (Operators.CompareString(DC_Main.MsSoftType, "L", false) != 0)
			{
				DC_Main.MsUserRightForm = "Tag Estmate";
				DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
				RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
				if (RsRight.Rows.Count == 0)
				{
					DC_Main.MsUserRightForm = "";
					Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
					((Control)PanelImage).Visible = true;
					return;
				}
				PanalImage_Hide();
				RP_TAG_ESTMATE rP_TAG_ESTMATE = new RP_TAG_ESTMATE();
				((Form)rP_TAG_ESTMATE).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((XtraForm)rP_TAG_ESTMATE).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_TAG_ESTMATE).Show();
				((Control)rP_TAG_ESTMATE).Focus();
			}
		}
	}

	private void BtnHome_Click(object sender, EventArgs e)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		SideFooterMenuSet();
		DC_Main.MsUserRightForm = "Reminder Rpt";
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)PanelImage).Visible = true;
			return;
		}
		PanalImage_Hide();
		RP_REMINDER rP_REMINDER = new RP_REMINDER();
		((Form)rP_REMINDER).MdiParent = (Form)(object)this;
		checked
		{
			DC_Main.TotOpenForm++;
			((Form)rP_REMINDER).Text = "Home " + Conversions.ToString(DC_Main.TotOpenForm);
			((Control)rP_REMINDER).Show();
			((Control)rP_REMINDER).Focus();
			if (Operators.CompareString(DC_Main.MsCrmProcess, "Y", false) == 0)
			{
				MainTripButton_Color();
				((ToolStripItem)btnHome).BackColor = Color.BlanchedAlmond;
				((ToolStripItem)btnHome).ForeColor = Color.DarkRed;
				((AccordionControlElementBase)SLMain2).Visible = false;
				RptAnalysis = false;
				DC_Main.MsMainBtn = "Crm";
				Side_Menu_Fill();
			}
		}
	}

	private void F1CtrlDailyRateToolStripMenuItem_Click(object sender, EventArgs e)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.MsUserRightForm = "Daily Rate";
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)PanelImage).Visible = true;
			return;
		}
		PanalImage_Hide();
		MS_RATE mS_RATE = new MS_RATE();
		((Form)mS_RATE).MdiParent = (Form)(object)this;
		checked
		{
			DC_Main.TotOpenForm++;
			((Form)mS_RATE).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
			((Control)mS_RATE).Show();
			((Control)mS_RATE).Focus();
		}
	}

	private void F11CtrlCashBankToolStripMenuItem_Click(object sender, EventArgs e)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.MsUserRightForm = "Cash Bank";
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)PanelImage).Visible = true;
			return;
		}
		PanalImage_Hide();
		RP_CASH_BANK rP_CASH_BANK = new RP_CASH_BANK();
		((Form)rP_CASH_BANK).MdiParent = (Form)(object)this;
		checked
		{
			DC_Main.TotOpenForm++;
			((Form)rP_CASH_BANK).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
			((Control)rP_CASH_BANK).Show();
			((Control)rP_CASH_BANK).Focus();
		}
	}

	private void elementCalendar_Click(object sender, EventArgs e)
	{
		FooterMenuClick = true;
		TileMenuOpen = false;
		((AccordionControlElementBase)SL51).Visible = false;
		((AccordionControlElementBase)SL52).Visible = false;
		((AccordionControlElementBase)SL53).Visible = false;
		((AccordionControlElementBase)SL54).Visible = false;
		((AccordionControlElementBase)SL55).Visible = false;
		((AccordionControlElementBase)SL56).Visible = false;
		((AccordionControlElementBase)SL57).Visible = false;
		((AccordionControlElementBase)SL58).Visible = false;
		((AccordionControlElementBase)SL59).Visible = false;
		((AccordionControlElementBase)SL60).Visible = false;
		((AccordionControlElementBase)SL61).Visible = false;
		((AccordionControlElementBase)SL62).Visible = false;
		((AccordionControlElementBase)SL63).Visible = false;
		((AccordionControlElementBase)SL64).Visible = false;
		((AccordionControlElementBase)SL65).Visible = false;
		if ((Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "B", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "S", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "P", false) == 0))
		{
			((AccordionControlElementBase)SLMain6).Visible = false;
		}
		DataView dataView = new DataView(RsMenu);
		dataView.RowFilter = "BTN_NAME = 'Analysis'";
		if (dataView.Count <= 0)
		{
			return;
		}
		checked
		{
			int num = dataView.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 65.0)
				{
					((AccordionControlElementBase)SL65).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
					((AccordionControlElementBase)SL65).Visible = true;
					((AccordionControlElementBase)SL65).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 64.0)
				{
					((AccordionControlElementBase)SL64).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
					((AccordionControlElementBase)SL64).Visible = true;
					((AccordionControlElementBase)SL64).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 63.0)
				{
					((AccordionControlElementBase)SL63).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
					((AccordionControlElementBase)SL63).Visible = true;
					((AccordionControlElementBase)SL63).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 62.0)
				{
					((AccordionControlElementBase)SL62).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
					((AccordionControlElementBase)SL62).Visible = true;
					((AccordionControlElementBase)SL62).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 61.0)
				{
					((AccordionControlElementBase)SL61).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
					((AccordionControlElementBase)SL61).Visible = true;
					((AccordionControlElementBase)SL61).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 60.0)
				{
					((AccordionControlElementBase)SL60).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
					((AccordionControlElementBase)SL60).Visible = true;
					((AccordionControlElementBase)SL60).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 59.0)
				{
					((AccordionControlElementBase)SL59).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
					((AccordionControlElementBase)SL59).Visible = true;
					((AccordionControlElementBase)SL59).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 58.0)
				{
					((AccordionControlElementBase)SL58).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
					((AccordionControlElementBase)SL58).Visible = true;
					((AccordionControlElementBase)SL58).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 57.0)
				{
					((AccordionControlElementBase)SL57).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
					((AccordionControlElementBase)SL57).Visible = true;
					((AccordionControlElementBase)SL57).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 56.0)
				{
					((AccordionControlElementBase)SL56).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
					((AccordionControlElementBase)SL56).Visible = true;
					((AccordionControlElementBase)SL56).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 55.0)
				{
					((AccordionControlElementBase)SL55).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
					((AccordionControlElementBase)SL55).Visible = true;
					((AccordionControlElementBase)SL55).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 54.0)
				{
					((AccordionControlElementBase)SL54).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
					((AccordionControlElementBase)SL54).Visible = true;
					((AccordionControlElementBase)SL54).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 53.0)
				{
					((AccordionControlElementBase)SL53).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
					((AccordionControlElementBase)SL53).Visible = true;
					((AccordionControlElementBase)SL53).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 52.0)
				{
					((AccordionControlElementBase)SL52).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
					((AccordionControlElementBase)SL52).Visible = true;
					((AccordionControlElementBase)SL52).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 51.0)
				{
					((AccordionControlElementBase)SL51).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
					((AccordionControlElementBase)SL51).Visible = true;
					((AccordionControlElementBase)SL51).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
				}
				DC_Main.M++;
			}
		}
	}

	private void elementPeople_Click(object sender, EventArgs e)
	{
		FooterMenuClick = true;
		TileMenuOpen = false;
		((AccordionControlElementBase)SL75).Visible = false;
		((AccordionControlElementBase)SL76).Visible = false;
		((AccordionControlElementBase)SL77).Visible = false;
		((AccordionControlElementBase)SL78).Visible = false;
		((AccordionControlElementBase)SL79).Visible = false;
		((AccordionControlElementBase)SL80).Visible = false;
		((AccordionControlElementBase)SL81).Visible = false;
		((AccordionControlElementBase)SL82).Visible = false;
		((AccordionControlElementBase)SL83).Visible = false;
		((AccordionControlElementBase)SL84).Visible = false;
		((AccordionControlElementBase)SL85).Visible = false;
		((AccordionControlElementBase)SL86).Visible = false;
		((AccordionControlElementBase)SL87).Visible = false;
		((AccordionControlElementBase)SL88).Visible = false;
		((AccordionControlElementBase)SL89).Visible = false;
		((AccordionControlElementBase)SL90).Visible = false;
		DataView dataView = new DataView(RsMenu);
		dataView.RowFilter = "BTN_NAME = 'More'";
		checked
		{
			if (dataView.Count > 0)
			{
				int num = dataView.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 90.0)
					{
						((AccordionControlElementBase)SL90).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL90).Visible = true;
						((AccordionControlElementBase)SL90).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 89.0)
					{
						((AccordionControlElementBase)SL89).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL89).Visible = true;
						((AccordionControlElementBase)SL89).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 88.0)
					{
						((AccordionControlElementBase)SL88).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL88).Visible = true;
						((AccordionControlElementBase)SL88).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 87.0)
					{
						((AccordionControlElementBase)SL87).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL87).Visible = true;
						((AccordionControlElementBase)SL87).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 86.0)
					{
						((AccordionControlElementBase)SL86).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL86).Visible = true;
						((AccordionControlElementBase)SL86).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 85.0)
					{
						((AccordionControlElementBase)SL85).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL85).Visible = true;
						((AccordionControlElementBase)SL85).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 84.0)
					{
						((AccordionControlElementBase)SL84).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL84).Visible = true;
						((AccordionControlElementBase)SL84).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 83.0)
					{
						((AccordionControlElementBase)SL83).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL83).Visible = true;
						((AccordionControlElementBase)SL83).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 82.0)
					{
						((AccordionControlElementBase)SL82).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL82).Visible = true;
						((AccordionControlElementBase)SL82).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 81.0)
					{
						((AccordionControlElementBase)SL81).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL81).Visible = true;
						((AccordionControlElementBase)SL81).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 80.0)
					{
						((AccordionControlElementBase)SL80).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL80).Visible = true;
						((AccordionControlElementBase)SL80).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 79.0)
					{
						((AccordionControlElementBase)SL79).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL79).Visible = true;
						((AccordionControlElementBase)SL79).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 78.0)
					{
						((AccordionControlElementBase)SL78).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL78).Visible = true;
						((AccordionControlElementBase)SL78).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 77.0)
					{
						((AccordionControlElementBase)SL77).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL77).Visible = true;
						((AccordionControlElementBase)SL77).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 76.0)
					{
						((AccordionControlElementBase)SL76).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL76).Visible = true;
						((AccordionControlElementBase)SL76).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[DC_Main.M]["SM_MAIN_CODE"])) == 75.0)
					{
						((AccordionControlElementBase)SL75).Text = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_NAME"], (object)""));
						((AccordionControlElementBase)SL75).Visible = true;
						((AccordionControlElementBase)SL75).Hint = Conversions.ToString(Operators.ConcatenateObject(dataView[DC_Main.M]["SM_MAIN_NAME"], (object)""));
					}
					DC_Main.M++;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS280NUBU", false) == 0)
			{
				((AccordionControlElementBase)SL84).Visible = true;
				((AccordionControlElementBase)SL84).Text = "Lot Report";
				((AccordionControlElementBase)SL84).Hint = "Lot Report";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM232NAHM", false) == 0)
			{
				((AccordionControlElementBase)SL81).Visible = true;
				((AccordionControlElementBase)SL81).Text = "Deisgn Move";
				((AccordionControlElementBase)SL81).Hint = "Deisgn Move";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM244NEKU", false) == 0)
			{
				((AccordionControlElementBase)SL78).Visible = true;
				((AccordionControlElementBase)SL78).Text = "Bill Wise Profit";
				((AccordionControlElementBase)SL78).Hint = "Bill Wise Profit";
			}
			if (Operators.CompareString(DC_Main.MsMfgType, "B", false) == 0)
			{
				((AccordionControlElementBase)SL75).Visible = true;
				((AccordionControlElementBase)SL75).Text = "Order Track";
				((AccordionControlElementBase)SL75).Hint = "Order Track";
			}
		}
	}

	private void SL75_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL75).Hint;
		More_Form();
	}

	private void SL76_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL76).Hint;
		More_Form();
	}

	private void SL77_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL77).Hint;
		More_Form();
	}

	private void SL78_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL78).Hint;
		More_Form();
	}

	private void SL79_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL79).Hint;
		More_Form();
	}

	private void SL80_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL80).Hint;
		More_Form();
	}

	private void SL81_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL81).Hint;
		More_Form();
	}

	private void SL82_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL82).Hint;
		More_Form();
	}

	private void SL83_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL83).Hint;
		More_Form();
	}

	private void SL84_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL84).Hint;
		More_Form();
	}

	private void SL85_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL85).Hint;
		More_Form();
	}

	private void SL86_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL86).Hint;
		More_Form();
	}

	private void SL87_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL87).Hint;
		More_Form();
	}

	private void SL88_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL88).Hint;
		More_Form();
	}

	private void SL89_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL89).Hint;
		More_Form();
	}

	private void SL90_Click(object sender, EventArgs e)
	{
		MsSideBtn = ((AccordionControlElementBase)SL90).Hint;
		More_Form();
	}

	private void F2CtrlOrderZoomToolStripMenuItem_Click(object sender, EventArgs e)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (Operators.CompareString(DC_Main.MsSoftType, "L", false) != 0 && Operators.CompareString(DC_Main.MsSoftType, "S", false) != 0)
			{
				DC_Main.MsUserRightForm = "Order Zoom";
				DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
				RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
				if (RsRight.Rows.Count == 0)
				{
					DC_Main.MsUserRightForm = "";
					Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
					((Control)PanelImage).Visible = true;
					return;
				}
				PanalImage_Hide();
				RP_ORDER rP_ORDER = new RP_ORDER();
				((Form)rP_ORDER).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)rP_ORDER).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)rP_ORDER).Show();
				((Control)rP_ORDER).Focus();
			}
		}
	}

	private void elementMail_Click(object sender, EventArgs e)
	{
		if (!((Operators.CompareString(DC_Main.MsSoftType, "P", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)))
		{
			return;
		}
		checked
		{
			if (TileMenuOpen)
			{
				if (Operators.CompareString(DC_Main.MsTileMenuShow, "W", false) == 0)
				{
					PanalImage_Hide();
					UT_WINDOW uT_WINDOW = new UT_WINDOW();
					((Form)uT_WINDOW).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)uT_WINDOW).Text = "Window " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)uT_WINDOW).Show();
					((Control)uT_WINDOW).Focus();
				}
				else
				{
					((Control)MyProject.Forms.UT_WINDOW).Show();
				}
			}
			else
			{
				TileMenuOpen = true;
			}
		}
	}

	private void chkWappId_Click(object sender, EventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Invalid comparison between Unknown and I4
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		if (!chkWappId.Checked)
		{
			return;
		}
		if ((int)((Form)MyProject.Forms.UT_WAPP_WITH_API).WindowState == 0)
		{
			DC_Main.MsUserRightForm = "Whatsapp";
			DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
			RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			if (RsRight.Rows.Count == 0)
			{
				DC_Main.MsUserRightForm = "";
				Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
				((Control)PanelImage).Visible = true;
				return;
			}
			PanalImage_Hide();
			checked
			{
				if (Operators.CompareString(DC_Main.MsWappApiActive, "Y", false) == 0)
				{
					((Form)MyProject.Forms.UT_WAPP_WITH_API).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)MyProject.Forms.UT_WAPP_WITH_API).Text = "Whatsapp " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)MyProject.Forms.UT_WAPP_WITH_API).Show();
					((Control)MyProject.Forms.UT_WAPP_WITH_API).Focus();
				}
				else
				{
					((Form)MyProject.Forms.UT_WHATSAPP).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)MyProject.Forms.UT_WAPP_WITH_API).Text = "Whatsapp " + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)MyProject.Forms.UT_WHATSAPP).Show();
					((Control)MyProject.Forms.UT_WHATSAPP).Focus();
				}
			}
		}
		else if (Operators.CompareString(DC_Main.MsWappApiActive, "Y", false) == 0)
		{
			((Control)MyProject.Forms.UT_WAPP_WITH_API).Show();
			((Control)MyProject.Forms.UT_WAPP_WITH_API).Focus();
		}
		else
		{
			((Control)MyProject.Forms.UT_WHATSAPP).Show();
			((Control)MyProject.Forms.UT_WHATSAPP).Focus();
		}
	}

	private void MDI_FORM_Activated(object sender, EventArgs e)
	{
		//IL_07a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b3: Expected O, but got Unknown
		//IL_07c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d5: Expected O, but got Unknown
		//IL_07e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f7: Expected O, but got Unknown
		//IL_080a: Unknown result type (might be due to invalid IL or missing references)
		//IL_080f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0819: Expected O, but got Unknown
		//IL_082c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0831: Unknown result type (might be due to invalid IL or missing references)
		//IL_083b: Expected O, but got Unknown
		//IL_084e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0853: Unknown result type (might be due to invalid IL or missing references)
		//IL_085d: Expected O, but got Unknown
		//IL_0870: Unknown result type (might be due to invalid IL or missing references)
		//IL_0875: Unknown result type (might be due to invalid IL or missing references)
		//IL_087f: Expected O, but got Unknown
		//IL_0892: Unknown result type (might be due to invalid IL or missing references)
		//IL_0897: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a1: Expected O, but got Unknown
		//IL_08b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c3: Expected O, but got Unknown
		//IL_08d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08db: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e5: Expected O, but got Unknown
		//IL_08f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0907: Expected O, but got Unknown
		//IL_091a: Unknown result type (might be due to invalid IL or missing references)
		//IL_091f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0929: Expected O, but got Unknown
		//IL_093c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0941: Unknown result type (might be due to invalid IL or missing references)
		//IL_094b: Expected O, but got Unknown
		//IL_09bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ce: Expected O, but got Unknown
		//IL_09eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fa: Expected O, but got Unknown
		//IL_0a17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a26: Expected O, but got Unknown
		//IL_0a43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a52: Expected O, but got Unknown
		//IL_0a6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7e: Expected O, but got Unknown
		//IL_0a9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aaa: Expected O, but got Unknown
		//IL_0ac7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad6: Expected O, but got Unknown
		//IL_0af3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b02: Expected O, but got Unknown
		//IL_0b1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2e: Expected O, but got Unknown
		//IL_0b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5a: Expected O, but got Unknown
		//IL_0b77: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b86: Expected O, but got Unknown
		//IL_0ba3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb2: Expected O, but got Unknown
		//IL_0c26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c35: Expected O, but got Unknown
		//IL_0c52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c61: Expected O, but got Unknown
		//IL_0c7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8d: Expected O, but got Unknown
		//IL_0caa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0caf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb9: Expected O, but got Unknown
		//IL_0cd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cdb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce5: Expected O, but got Unknown
		//IL_0d02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d11: Expected O, but got Unknown
		//IL_0d2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3d: Expected O, but got Unknown
		//IL_0d5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d69: Expected O, but got Unknown
		//IL_0d86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d95: Expected O, but got Unknown
		//IL_0db2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc1: Expected O, but got Unknown
		//IL_0dde: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ded: Expected O, but got Unknown
		//IL_0e0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e19: Expected O, but got Unknown
		//IL_0e36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e45: Expected O, but got Unknown
		//IL_0e62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e71: Expected O, but got Unknown
		//IL_0e8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e93: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9d: Expected O, but got Unknown
		//IL_0eba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec9: Expected O, but got Unknown
		//IL_0ee6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eeb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef5: Expected O, but got Unknown
		//IL_0f12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f21: Expected O, but got Unknown
		//IL_0f3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4d: Expected O, but got Unknown
		//IL_0f6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f79: Expected O, but got Unknown
		//IL_0f96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa5: Expected O, but got Unknown
		//IL_0fc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd1: Expected O, but got Unknown
		//IL_0fee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffd: Expected O, but got Unknown
		//IL_101a: Unknown result type (might be due to invalid IL or missing references)
		//IL_101f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1029: Expected O, but got Unknown
		//IL_1046: Unknown result type (might be due to invalid IL or missing references)
		//IL_104b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1055: Expected O, but got Unknown
		//IL_1072: Unknown result type (might be due to invalid IL or missing references)
		//IL_1077: Unknown result type (might be due to invalid IL or missing references)
		//IL_1081: Expected O, but got Unknown
		//IL_109e: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ad: Expected O, but got Unknown
		//IL_10ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_10cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d9: Expected O, but got Unknown
		//IL_10f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1105: Expected O, but got Unknown
		//IL_1122: Unknown result type (might be due to invalid IL or missing references)
		//IL_1127: Unknown result type (might be due to invalid IL or missing references)
		//IL_1131: Expected O, but got Unknown
		//IL_114e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1153: Unknown result type (might be due to invalid IL or missing references)
		//IL_115d: Expected O, but got Unknown
		//IL_117a: Unknown result type (might be due to invalid IL or missing references)
		//IL_117f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1189: Expected O, but got Unknown
		//IL_11a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b5: Expected O, but got Unknown
		//IL_11d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e1: Expected O, but got Unknown
		//IL_11fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1203: Unknown result type (might be due to invalid IL or missing references)
		//IL_120d: Expected O, but got Unknown
		//IL_122a: Unknown result type (might be due to invalid IL or missing references)
		//IL_122f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1239: Expected O, but got Unknown
		//IL_1256: Unknown result type (might be due to invalid IL or missing references)
		//IL_125b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1265: Expected O, but got Unknown
		//IL_1282: Unknown result type (might be due to invalid IL or missing references)
		//IL_1287: Unknown result type (might be due to invalid IL or missing references)
		//IL_1291: Expected O, but got Unknown
		//IL_12ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_12bd: Expected O, but got Unknown
		//IL_12da: Unknown result type (might be due to invalid IL or missing references)
		//IL_12df: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e9: Expected O, but got Unknown
		//IL_1306: Unknown result type (might be due to invalid IL or missing references)
		//IL_130b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1315: Expected O, but got Unknown
		//IL_1332: Unknown result type (might be due to invalid IL or missing references)
		//IL_1337: Unknown result type (might be due to invalid IL or missing references)
		//IL_1341: Expected O, but got Unknown
		//IL_135e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1363: Unknown result type (might be due to invalid IL or missing references)
		//IL_136d: Expected O, but got Unknown
		//IL_138a: Unknown result type (might be due to invalid IL or missing references)
		//IL_138f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1399: Expected O, but got Unknown
		//IL_13b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_13bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c5: Expected O, but got Unknown
		//IL_13e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f1: Expected O, but got Unknown
		//IL_140e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1413: Unknown result type (might be due to invalid IL or missing references)
		//IL_141d: Expected O, but got Unknown
		//IL_143a: Unknown result type (might be due to invalid IL or missing references)
		//IL_143f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1449: Expected O, but got Unknown
		//IL_1466: Unknown result type (might be due to invalid IL or missing references)
		//IL_146b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1475: Expected O, but got Unknown
		//IL_1492: Unknown result type (might be due to invalid IL or missing references)
		//IL_1497: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a1: Expected O, but got Unknown
		//IL_14be: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_14cd: Expected O, but got Unknown
		//IL_14ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f9: Expected O, but got Unknown
		//IL_1516: Unknown result type (might be due to invalid IL or missing references)
		//IL_151b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1525: Expected O, but got Unknown
		//IL_1542: Unknown result type (might be due to invalid IL or missing references)
		//IL_1547: Unknown result type (might be due to invalid IL or missing references)
		//IL_1551: Expected O, but got Unknown
		//IL_156e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1573: Unknown result type (might be due to invalid IL or missing references)
		//IL_157d: Expected O, but got Unknown
		//IL_159a: Unknown result type (might be due to invalid IL or missing references)
		//IL_159f: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a9: Expected O, but got Unknown
		//IL_15c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_15cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d5: Expected O, but got Unknown
		//IL_15f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1601: Expected O, but got Unknown
		//IL_161e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1623: Unknown result type (might be due to invalid IL or missing references)
		//IL_162d: Expected O, but got Unknown
		//IL_164a: Unknown result type (might be due to invalid IL or missing references)
		//IL_164f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1659: Expected O, but got Unknown
		//IL_1676: Unknown result type (might be due to invalid IL or missing references)
		//IL_167b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1685: Expected O, but got Unknown
		//IL_16a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b1: Expected O, but got Unknown
		//IL_16ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_16dd: Expected O, but got Unknown
		//IL_16fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1709: Expected O, but got Unknown
		//IL_1726: Unknown result type (might be due to invalid IL or missing references)
		//IL_172b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1735: Expected O, but got Unknown
		//IL_1752: Unknown result type (might be due to invalid IL or missing references)
		//IL_1757: Unknown result type (might be due to invalid IL or missing references)
		//IL_1761: Expected O, but got Unknown
		//IL_177e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1783: Unknown result type (might be due to invalid IL or missing references)
		//IL_178d: Expected O, but got Unknown
		//IL_17aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_17af: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b9: Expected O, but got Unknown
		//IL_17d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_17db: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e5: Expected O, but got Unknown
		//IL_1802: Unknown result type (might be due to invalid IL or missing references)
		//IL_1807: Unknown result type (might be due to invalid IL or missing references)
		//IL_1811: Expected O, but got Unknown
		//IL_182e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1833: Unknown result type (might be due to invalid IL or missing references)
		//IL_183d: Expected O, but got Unknown
		//IL_185a: Unknown result type (might be due to invalid IL or missing references)
		//IL_185f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1869: Expected O, but got Unknown
		//IL_1886: Unknown result type (might be due to invalid IL or missing references)
		//IL_188b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1895: Expected O, but got Unknown
		//IL_18b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_18b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c1: Expected O, but got Unknown
		//IL_18de: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ed: Expected O, but got Unknown
		//IL_190a: Unknown result type (might be due to invalid IL or missing references)
		//IL_190f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1919: Expected O, but got Unknown
		//IL_1936: Unknown result type (might be due to invalid IL or missing references)
		//IL_193b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1945: Expected O, but got Unknown
		//IL_1962: Unknown result type (might be due to invalid IL or missing references)
		//IL_1967: Unknown result type (might be due to invalid IL or missing references)
		//IL_1971: Expected O, but got Unknown
		//IL_198e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1993: Unknown result type (might be due to invalid IL or missing references)
		//IL_199d: Expected O, but got Unknown
		//IL_19ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_19bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c9: Expected O, but got Unknown
		//IL_19e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_19eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_19f5: Expected O, but got Unknown
		//IL_1a12: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a17: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a21: Expected O, but got Unknown
		//IL_1a3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a43: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a4d: Expected O, but got Unknown
		//IL_1a6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a79: Expected O, but got Unknown
		//IL_1a96: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aa5: Expected O, but got Unknown
		//IL_1ac2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad1: Expected O, but got Unknown
		//IL_1aee: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1afd: Expected O, but got Unknown
		//IL_1b1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b29: Expected O, but got Unknown
		//IL_1b46: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b55: Expected O, but got Unknown
		//IL_1b72: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b77: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b81: Expected O, but got Unknown
		//IL_1b9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bad: Expected O, but got Unknown
		//IL_1bca: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bd9: Expected O, but got Unknown
		//IL_1bf6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c05: Expected O, but got Unknown
		//IL_1c22: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c27: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c31: Expected O, but got Unknown
		//IL_1c4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c53: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c5d: Expected O, but got Unknown
		//IL_1c7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c89: Expected O, but got Unknown
		//IL_1ca6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cab: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb5: Expected O, but got Unknown
		//IL_1cd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce1: Expected O, but got Unknown
		//IL_1cfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d03: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d0d: Expected O, but got Unknown
		//IL_1d2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d39: Expected O, but got Unknown
		//IL_1d56: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d65: Expected O, but got Unknown
		//IL_1d82: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d87: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d91: Expected O, but got Unknown
		//IL_1dae: Unknown result type (might be due to invalid IL or missing references)
		//IL_1db3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dbd: Expected O, but got Unknown
		//IL_1dda: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ddf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de9: Expected O, but got Unknown
		//IL_1e06: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e15: Expected O, but got Unknown
		//IL_1e32: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e37: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e41: Expected O, but got Unknown
		//IL_1e5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e63: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e6d: Expected O, but got Unknown
		//IL_1e8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e99: Expected O, but got Unknown
		//IL_1eb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ebb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ec5: Expected O, but got Unknown
		//IL_1ee2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ee7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ef1: Expected O, but got Unknown
		//IL_1f0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f13: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f1d: Expected O, but got Unknown
		//IL_1f3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f49: Expected O, but got Unknown
		//IL_1f66: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f75: Expected O, but got Unknown
		//IL_1f92: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f97: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fa1: Expected O, but got Unknown
		//IL_1fbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fcd: Expected O, but got Unknown
		//IL_1fea: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff9: Expected O, but got Unknown
		//IL_2016: Unknown result type (might be due to invalid IL or missing references)
		//IL_201b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2025: Expected O, but got Unknown
		//IL_2042: Unknown result type (might be due to invalid IL or missing references)
		//IL_2047: Unknown result type (might be due to invalid IL or missing references)
		//IL_2051: Expected O, but got Unknown
		//IL_206e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2073: Unknown result type (might be due to invalid IL or missing references)
		//IL_207d: Expected O, but got Unknown
		//IL_209a: Unknown result type (might be due to invalid IL or missing references)
		//IL_209f: Unknown result type (might be due to invalid IL or missing references)
		//IL_20a9: Expected O, but got Unknown
		//IL_20c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_20cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d5: Expected O, but got Unknown
		//IL_20f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_20f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2101: Expected O, but got Unknown
		//IL_211e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2123: Unknown result type (might be due to invalid IL or missing references)
		//IL_212d: Expected O, but got Unknown
		//IL_214a: Unknown result type (might be due to invalid IL or missing references)
		//IL_214f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2159: Expected O, but got Unknown
		//IL_2176: Unknown result type (might be due to invalid IL or missing references)
		//IL_217b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2185: Expected O, but got Unknown
		//IL_21a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_21a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_21b1: Expected O, but got Unknown
		//IL_21ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_21dd: Expected O, but got Unknown
		//IL_21fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_21ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_2209: Expected O, but got Unknown
		//IL_2226: Unknown result type (might be due to invalid IL or missing references)
		//IL_222b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2235: Expected O, but got Unknown
		//IL_2252: Unknown result type (might be due to invalid IL or missing references)
		//IL_2257: Unknown result type (might be due to invalid IL or missing references)
		//IL_2261: Expected O, but got Unknown
		//IL_227e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2283: Unknown result type (might be due to invalid IL or missing references)
		//IL_228d: Expected O, but got Unknown
		//IL_22aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_22af: Unknown result type (might be due to invalid IL or missing references)
		//IL_22b9: Expected O, but got Unknown
		//IL_22d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_22db: Unknown result type (might be due to invalid IL or missing references)
		//IL_22e5: Expected O, but got Unknown
		//IL_2302: Unknown result type (might be due to invalid IL or missing references)
		//IL_2307: Unknown result type (might be due to invalid IL or missing references)
		//IL_2311: Expected O, but got Unknown
		//IL_232e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2333: Unknown result type (might be due to invalid IL or missing references)
		//IL_233d: Expected O, but got Unknown
		//IL_235a: Unknown result type (might be due to invalid IL or missing references)
		//IL_235f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2369: Expected O, but got Unknown
		//IL_2386: Unknown result type (might be due to invalid IL or missing references)
		//IL_238b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2395: Expected O, but got Unknown
		//IL_23b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_23b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c1: Expected O, but got Unknown
		//IL_23de: Unknown result type (might be due to invalid IL or missing references)
		//IL_23e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_23ed: Expected O, but got Unknown
		//IL_240a: Unknown result type (might be due to invalid IL or missing references)
		//IL_240f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2419: Expected O, but got Unknown
		//IL_2436: Unknown result type (might be due to invalid IL or missing references)
		//IL_243b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2445: Expected O, but got Unknown
		//IL_2462: Unknown result type (might be due to invalid IL or missing references)
		//IL_2467: Unknown result type (might be due to invalid IL or missing references)
		//IL_2471: Expected O, but got Unknown
		//IL_248e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2493: Unknown result type (might be due to invalid IL or missing references)
		//IL_249d: Expected O, but got Unknown
		//IL_24ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_24bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_24c9: Expected O, but got Unknown
		//IL_24e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_24eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_24f5: Expected O, but got Unknown
		//IL_2512: Unknown result type (might be due to invalid IL or missing references)
		//IL_2517: Unknown result type (might be due to invalid IL or missing references)
		//IL_2521: Expected O, but got Unknown
		//IL_253e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2543: Unknown result type (might be due to invalid IL or missing references)
		//IL_254d: Expected O, but got Unknown
		//IL_256a: Unknown result type (might be due to invalid IL or missing references)
		//IL_256f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2579: Expected O, but got Unknown
		//IL_2596: Unknown result type (might be due to invalid IL or missing references)
		//IL_259b: Unknown result type (might be due to invalid IL or missing references)
		//IL_25a5: Expected O, but got Unknown
		//IL_25c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_25c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_25d1: Expected O, but got Unknown
		//IL_25ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_25f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_25fd: Expected O, but got Unknown
		//IL_261a: Unknown result type (might be due to invalid IL or missing references)
		//IL_261f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2629: Expected O, but got Unknown
		//IL_2646: Unknown result type (might be due to invalid IL or missing references)
		//IL_264b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2655: Expected O, but got Unknown
		//IL_2672: Unknown result type (might be due to invalid IL or missing references)
		//IL_2677: Unknown result type (might be due to invalid IL or missing references)
		//IL_2681: Expected O, but got Unknown
		//IL_269e: Unknown result type (might be due to invalid IL or missing references)
		//IL_26a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_26ad: Expected O, but got Unknown
		//IL_26ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_26cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_26d9: Expected O, but got Unknown
		//IL_26f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_26fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2705: Expected O, but got Unknown
		//IL_2722: Unknown result type (might be due to invalid IL or missing references)
		//IL_2727: Unknown result type (might be due to invalid IL or missing references)
		//IL_2731: Expected O, but got Unknown
		//IL_274e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2753: Unknown result type (might be due to invalid IL or missing references)
		//IL_275d: Expected O, but got Unknown
		//IL_277a: Unknown result type (might be due to invalid IL or missing references)
		//IL_277f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2789: Expected O, but got Unknown
		//IL_27a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_27ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_27b5: Expected O, but got Unknown
		//IL_27d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_27d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_27e1: Expected O, but got Unknown
		//IL_27fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_2803: Unknown result type (might be due to invalid IL or missing references)
		//IL_280d: Expected O, but got Unknown
		//IL_282a: Unknown result type (might be due to invalid IL or missing references)
		//IL_282f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2839: Expected O, but got Unknown
		//IL_2856: Unknown result type (might be due to invalid IL or missing references)
		//IL_285b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2865: Expected O, but got Unknown
		//IL_2882: Unknown result type (might be due to invalid IL or missing references)
		//IL_2887: Unknown result type (might be due to invalid IL or missing references)
		//IL_2891: Expected O, but got Unknown
		//IL_28ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_28b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_28bd: Expected O, but got Unknown
		//IL_28da: Unknown result type (might be due to invalid IL or missing references)
		//IL_28df: Unknown result type (might be due to invalid IL or missing references)
		//IL_28e9: Expected O, but got Unknown
		//IL_2906: Unknown result type (might be due to invalid IL or missing references)
		//IL_290b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2915: Expected O, but got Unknown
		//IL_2932: Unknown result type (might be due to invalid IL or missing references)
		//IL_2937: Unknown result type (might be due to invalid IL or missing references)
		//IL_2941: Expected O, but got Unknown
		//IL_295e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2963: Unknown result type (might be due to invalid IL or missing references)
		//IL_296d: Expected O, but got Unknown
		//IL_298a: Unknown result type (might be due to invalid IL or missing references)
		//IL_298f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2999: Expected O, but got Unknown
		//IL_29b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_29bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_29c5: Expected O, but got Unknown
		//IL_29e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_29e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_29f1: Expected O, but got Unknown
		//IL_2a0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a13: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a1d: Expected O, but got Unknown
		//IL_2a3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a49: Expected O, but got Unknown
		//IL_2a66: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a75: Expected O, but got Unknown
		//IL_2a92: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a97: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aa1: Expected O, but got Unknown
		//IL_2abe: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ac3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2acd: Expected O, but got Unknown
		//IL_2aea: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aef: Unknown result type (might be due to invalid IL or missing references)
		//IL_2af9: Expected O, but got Unknown
		//IL_2b16: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b25: Expected O, but got Unknown
		//IL_2b42: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b47: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b51: Expected O, but got Unknown
		//IL_2b6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b73: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b7d: Expected O, but got Unknown
		//IL_2b9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ba9: Expected O, but got Unknown
		//IL_2bc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bcb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bd5: Expected O, but got Unknown
		//IL_2bf2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c01: Expected O, but got Unknown
		//IL_2c1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c23: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c2d: Expected O, but got Unknown
		//IL_2c4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c59: Expected O, but got Unknown
		//IL_2c76: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c85: Expected O, but got Unknown
		//IL_2ca2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ca7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cb1: Expected O, but got Unknown
		//IL_2cce: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cdd: Expected O, but got Unknown
		//IL_2cfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cff: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d09: Expected O, but got Unknown
		//IL_2d26: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d35: Expected O, but got Unknown
		//IL_2d52: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d57: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d61: Expected O, but got Unknown
		//IL_2d7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d83: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d8d: Expected O, but got Unknown
		//IL_2daa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2daf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2db9: Expected O, but got Unknown
		//IL_2dd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ddb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2de5: Expected O, but got Unknown
		//IL_2e02: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e07: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e11: Expected O, but got Unknown
		//IL_2e93: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e98: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e9e: Expected O, but got Unknown
		//IL_2f0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f11: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f17: Expected O, but got Unknown
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		if (DC_Main.MsYearChange)
		{
			DC_Main.MsYearChange = false;
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
				if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
				{
					((Form)this).Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)(DC_Main.MCo_code + " - " + DC_Main.MCo_Name + " - " + DC_Main.MCo_year + " - " + DC_Main.MCo_User), Interaction.IIf(Operators.CompareString(DC_Main.MCo_Type, "", false) == 0, (object)"", (object)(" - " + DC_Main.MCo_Type))), (object)" - "), (object)DC_Main.MLc_code), (object)" - "), (object)DC_Main.MLc_Name), (object)" - "), (object)DC_Main.SSRegSrNo));
				}
				else
				{
					((Form)this).Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)(DC_Main.MCo_code + " - " + DC_Main.MCo_Name + " - " + DC_Main.MCo_year + " - " + DC_Main.MCo_User), Interaction.IIf(Operators.CompareString(DC_Main.MCo_Type, "", false) == 0, (object)"", (object)(" - " + DC_Main.MCo_Type))), (object)" - "), (object)DC_Main.MLc_code), (object)" - "), (object)DC_Main.SSRegSrNo));
				}
			}
			else
			{
				((Form)this).Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)(DC_Main.MCo_code + " - " + DC_Main.MCo_Name + " - " + DC_Main.MCo_year + " - " + DC_Main.MCo_User), Interaction.IIf(Operators.CompareString(DC_Main.MCo_Type, "", false) == 0, (object)"", (object)(" - " + DC_Main.MCo_Type))), (object)" - "), (object)DC_Main.SSRegSrNo));
			}
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK252NUST", false) == 0)
		{
			((Form)this).Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)(DC_Main.MCo_code + " - " + DC_Main.MCo_Name + " - " + DC_Main.MCo_year + " - " + DC_Main.MCo_User), Interaction.IIf(Operators.CompareString(DC_Main.MCo_Type, "", false) == 0, (object)"", (object)(" - " + DC_Main.MCo_Type))), (object)" - "), (object)DC_Main.MLc_code), (object)" - "), (object)DC_Main.MLc_Name), (object)" - "), (object)DC_Main.SSRegSrNo));
		}
		if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0 && Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0)
		{
			UserRequest();
		}
		double num = (DC_Main.PcW - DC_Main.MainPcW) / DC_Main.MainPcW;
		double num2 = (DC_Main.PcH - DC_Main.MainPcH) / DC_Main.MainPcH;
		DC_Main.ScreenHight = 1.0 + num2;
		checked
		{
			DC_Main.HaderFont = (int)Math.Round(9.0 * DC_Main.ScreenHight);
			double num3 = 1.0 + num2;
			ColCon = 1.0 + num;
			if (!((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0)) || ScreenSet)
			{
				return;
			}
			ScreenSet = true;
			((ToolStripItem)btnHome).Width = (int)Math.Round((double)((ToolStripItem)btnHome).Width * ColCon);
			((ToolStripItem)BtnComp).Width = (int)Math.Round((double)((ToolStripItem)BtnComp).Width * ColCon);
			((ToolStripItem)BtnMast).Width = (int)Math.Round((double)((ToolStripItem)BtnMast).Width * ColCon);
			((ToolStripItem)BtnTran).Width = (int)Math.Round((double)((ToolStripItem)BtnTran).Width * ColCon);
			((ToolStripItem)BtnTran2).Width = (int)Math.Round((double)((ToolStripItem)BtnTran2).Width * ColCon);
			((ToolStripItem)BtnOth).Width = (int)Math.Round((double)((ToolStripItem)BtnOth).Width * ColCon);
			((ToolStripItem)BtnRpt).Width = (int)Math.Round((double)((ToolStripItem)BtnRpt).Width * ColCon);
			((ToolStripItem)BtnKrgr).Width = (int)Math.Round((double)((ToolStripItem)BtnKrgr).Width * ColCon);
			((ToolStripItem)BtnSchm).Width = (int)Math.Round((double)((ToolStripItem)BtnSchm).Width * ColCon);
			((ToolStripItem)BtnDhrn).Width = (int)Math.Round((double)((ToolStripItem)BtnDhrn).Width * ColCon);
			((ToolStripItem)BtnExit).Width = (int)Math.Round((double)((ToolStripItem)BtnExit).Width * ColCon);
			((ToolStripItem)btnHome).Height = (int)Math.Round((double)((ToolStripItem)btnHome).Height * num3);
			((ToolStripItem)BtnComp).Height = (int)Math.Round((double)((ToolStripItem)BtnComp).Width * num3);
			((ToolStripItem)BtnMast).Height = (int)Math.Round((double)((ToolStripItem)BtnMast).Height * num3);
			((ToolStripItem)BtnTran).Height = (int)Math.Round((double)((ToolStripItem)BtnTran).Height * num3);
			((ToolStripItem)BtnTran2).Height = (int)Math.Round((double)((ToolStripItem)BtnTran2).Height * num3);
			((ToolStripItem)BtnOth).Height = (int)Math.Round((double)((ToolStripItem)BtnOth).Height * num3);
			((ToolStripItem)BtnRpt).Height = (int)Math.Round((double)((ToolStripItem)BtnRpt).Height * num3);
			((ToolStripItem)BtnKrgr).Height = (int)Math.Round((double)((ToolStripItem)BtnKrgr).Height * num3);
			((ToolStripItem)BtnSchm).Height = (int)Math.Round((double)((ToolStripItem)BtnSchm).Height * num3);
			((ToolStripItem)BtnDhrn).Height = (int)Math.Round((double)((ToolStripItem)BtnDhrn).Height * num3);
			((ToolStripItem)BtnExit).Height = (int)Math.Round((double)((ToolStripItem)BtnExit).Height * num3);
			((ToolStripItem)mMainDt).Width = (int)Math.Round((double)((ToolStripItem)mMainDt).Width * (1.0 + num2));
			int num4 = (int)Math.Ceiling((double)((ToolStripItem)btnHome).Font.Size * (1.0 + num2));
			Font font = ((ToolStripItem)btnHome).Font;
			try
			{
				((ToolStripControlHost)mMainDt).Font = new Font(font.FontFamily, (float)num4, font.Style);
				((ToolStripItem)btnHome).Font = new Font(font.FontFamily, (float)num4, font.Style);
				((ToolStripItem)BtnComp).Font = new Font(font.FontFamily, (float)num4, font.Style);
				((ToolStripItem)BtnMast).Font = new Font(font.FontFamily, (float)num4, font.Style);
				((ToolStripItem)BtnTran).Font = new Font(font.FontFamily, (float)num4, font.Style);
				((ToolStripItem)BtnTran2).Font = new Font(font.FontFamily, (float)num4, font.Style);
				((ToolStripItem)BtnOth).Font = new Font(font.FontFamily, (float)num4, font.Style);
				((ToolStripItem)BtnKrgr).Font = new Font(font.FontFamily, (float)num4, font.Style);
				((ToolStripItem)BtnRpt).Font = new Font(font.FontFamily, (float)num4, font.Style);
				((ToolStripItem)BtnSchm).Font = new Font(font.FontFamily, (float)num4, font.Style);
				((ToolStripItem)BtnDhrn).Font = new Font(font.FontFamily, (float)num4, font.Style);
				((ToolStripItem)BtnMfg).Font = new Font(font.FontFamily, (float)num4, font.Style);
				((ToolStripItem)BtnExit).Font = new Font(font.FontFamily, (float)num4, font.Style);
			}
			finally
			{
				((IDisposable)font)?.Dispose();
			}
			num4 = (int)Math.Ceiling((double)SLMain.Appearance.Normal.Font.Size * (1.0 + num2));
			Font font2 = SL0.Appearance.Normal.Font;
			try
			{
				SLMain.Appearance.Normal.Font = new Font(font2.FontFamily, (float)num4, font2.Style);
				SLMain2.Appearance.Normal.Font = new Font(font2.FontFamily, (float)num4, font2.Style);
				SLMain3.Appearance.Normal.Font = new Font(font2.FontFamily, (float)num4, font2.Style);
				SLMain4.Appearance.Normal.Font = new Font(font2.FontFamily, (float)num4, font2.Style);
				SLMain5.Appearance.Normal.Font = new Font(font2.FontFamily, (float)num4, font2.Style);
				SLMain6.Appearance.Normal.Font = new Font(font2.FontFamily, (float)num4, font2.Style);
				SLMain.Appearance.Hovered.Font = new Font(font2.FontFamily, (float)num4, font2.Style);
				SLMain2.Appearance.Hovered.Font = new Font(font2.FontFamily, (float)num4, font2.Style);
				SLMain3.Appearance.Hovered.Font = new Font(font2.FontFamily, (float)num4, font2.Style);
				SLMain4.Appearance.Hovered.Font = new Font(font2.FontFamily, (float)num4, font2.Style);
				SLMain5.Appearance.Hovered.Font = new Font(font2.FontFamily, (float)num4, font2.Style);
				SLMain6.Appearance.Hovered.Font = new Font(font2.FontFamily, (float)num4, font2.Style);
			}
			finally
			{
				((IDisposable)font2)?.Dispose();
			}
			num4 = (int)Math.Ceiling((double)SL0.Appearance.Normal.Font.Size * (1.0 + num2));
			Font font3 = SL0.Appearance.Normal.Font;
			try
			{
				SL0.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL1.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL2.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL3.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL4.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL5.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL6.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL7.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL8.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL9.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL10.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL11.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL12.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL13.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL14.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL15.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL16.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL17.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL18.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL19.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL20.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL21.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL22.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL23.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL24.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL25.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL26.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL27.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL28.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL29.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL30.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL31.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL32.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL33.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL34.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL35.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL0.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL1.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL2.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL3.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL4.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL5.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL6.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL7.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL8.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL9.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL10.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL11.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL12.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL13.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL14.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL15.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL16.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL17.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL18.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL19.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL20.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL21.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL22.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL23.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL24.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL25.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL26.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL27.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL28.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL29.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL30.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL31.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL32.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL33.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL34.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL35.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL0.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL1.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL2.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL3.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL4.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL5.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL6.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL7.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL8.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL9.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL10.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL11.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL12.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL13.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL14.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL15.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL16.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL17.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL18.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL19.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL20.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL21.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL22.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL23.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL24.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL25.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL26.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL27.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL28.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL29.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL30.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL31.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL32.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL33.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL34.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL35.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL51.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL52.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL53.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL54.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL55.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL56.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL57.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL58.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL59.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL60.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL61.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL62.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL63.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL64.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL65.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL75.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL76.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL77.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL78.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL79.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL80.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL81.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL82.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL83.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL84.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL85.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL86.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL87.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL88.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL89.Appearance.Normal.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL51.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL52.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL53.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL54.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL55.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL56.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL57.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL58.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL59.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL60.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL61.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL62.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL63.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL64.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL65.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL75.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL76.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL77.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL78.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL79.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL80.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL81.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL82.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL83.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL84.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL85.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL86.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL87.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL88.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL89.Appearance.Hovered.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL51.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL52.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL53.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL54.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL55.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL56.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL57.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL58.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL59.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL60.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL61.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL62.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL63.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL64.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL65.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL75.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL76.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL77.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL78.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL79.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL80.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL81.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL82.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL83.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL84.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL85.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL86.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL87.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL88.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
				SL89.Appearance.Pressed.Font = new Font(font3.FontFamily, (float)num4, font3.Style);
			}
			finally
			{
				((IDisposable)font3)?.Dispose();
			}
			num4 = (int)Math.Ceiling((double)((Control)chkWappId).Font.Size * (1.0 + num2));
			Font font4 = ((Control)lblLiveRate).Font;
			try
			{
				foreach (object control in ((Control)PnlBotam).Controls)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(control);
					NewLateBinding.LateSet(objectValue, (Type)null, "Font", new object[1] { (object)new Font(font4.FontFamily, (float)num4, font4.Style) }, (string[])null, (Type[])null);
				}
				foreach (object control2 in ((Control)PanelImage).Controls)
				{
					object objectValue2 = RuntimeHelpers.GetObjectValue(control2);
					NewLateBinding.LateSet(objectValue2, (Type)null, "Font", new object[1] { (object)new Font(font4.FontFamily, (float)num4, font4.Style) }, (string[])null, (Type[])null);
				}
			}
			finally
			{
				((IDisposable)font4)?.Dispose();
			}
		}
	}

	private void UserRequest()
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
					DC_Main.RsQry = "SELECT COUNT(*) As UsrQry FROM USER_REQUEST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PARMATION_TYPE = 'P'";
					DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable.Rows.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(dataTable.Rows[0]["UsrQry"], (object)0, false))
						{
							((Control)LblUserRequest).ForeColor = Color.Navy;
							LblUserRequest.Text = "UReq :";
						}
						else
						{
							((Control)LblUserRequest).ForeColor = Color.Maroon;
							LblUserRequest.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UReq : ", dataTable.Rows[0]["UsrQry"]), (object)""));
						}
					}
					else
					{
						((Control)LblUserRequest).ForeColor = Color.Navy;
						LblUserRequest.Text = "UReq :";
					}
					break;
				}
				case 266:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_0140;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 266;
				continue;
			}
			break;
			IL_0140:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void LblUserRequest_Click(object sender, EventArgs e)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.MsUserRightForm = "Reminder Rpt";
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)PanelImage).Visible = true;
			return;
		}
		PanalImage_Hide();
		DC_Main.MsOpenUserRequest = true;
		RP_REMINDER rP_REMINDER = new RP_REMINDER();
		((Form)rP_REMINDER).MdiParent = (Form)(object)this;
		checked
		{
			DC_Main.TotOpenForm++;
			((Form)rP_REMINDER).Text = "Home " + Conversions.ToString(DC_Main.TotOpenForm);
			((Control)rP_REMINDER).Show();
			((Control)rP_REMINDER).Focus();
		}
	}

	private void MDI_FORM_KeyUp(object sender, KeyEventArgs e)
	{
	}

	private void ShoCtrlF8BankRec_Click(object sender, EventArgs e)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.MsUserRightForm = "Bank Received";
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)PanelImage).Visible = true;
			return;
		}
		DC_Main.CurBookHelp("BANK REC");
		checked
		{
			if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
			{
				PanalImage_Hide();
				TR_CASH tR_CASH = new TR_CASH();
				((Form)tR_CASH).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)tR_CASH).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_CASH).Show();
				((Control)tR_CASH).Focus();
			}
		}
	}

	private void ShoCtrlF9BankPay_Click(object sender, EventArgs e)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.MsUserRightForm = "Bank Payment";
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)PanelImage).Visible = true;
			return;
		}
		DC_Main.CurBookHelp("BANK PAY");
		checked
		{
			if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
			{
				PanalImage_Hide();
				TR_CASH tR_CASH = new TR_CASH();
				((Form)tR_CASH).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)tR_CASH).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_CASH).Show();
				((Control)tR_CASH).Focus();
			}
		}
	}

	private void ShoCtrlF6RateCut_Click(object sender, EventArgs e)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.MsUserRightForm = "Rate Cut";
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)PanelImage).Visible = true;
			return;
		}
		DC_Main.CurBookHelp("RATE CUT");
		checked
		{
			if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
			{
				PanalImage_Hide();
				TR_WH_SALE tR_WH_SALE = new TR_WH_SALE();
				((Form)tR_WH_SALE).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)tR_WH_SALE).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_WH_SALE).Show();
				((Control)tR_WH_SALE).Focus();
			}
		}
	}

	private void ShoCtrlF5BillRec_Click(object sender, EventArgs e)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.MsUserRightForm = "Bill Wise Rec";
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' AND FRM_VIEW = 'Y'";
		RsRight = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (RsRight.Rows.Count == 0)
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)PanelImage).Visible = true;
			return;
		}
		DC_Main.CurBookHelp("BILL REC");
		checked
		{
			if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
			{
				PanalImage_Hide();
				TR_BILL_TO tR_BILL_TO = new TR_BILL_TO();
				((Form)tR_BILL_TO).MdiParent = (Form)(object)this;
				DC_Main.TotOpenForm++;
				((Form)tR_BILL_TO).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
				((Control)tR_BILL_TO).Show();
				((Control)tR_BILL_TO).Focus();
			}
		}
	}

	private void mMainDt_Click(object sender, EventArgs e)
	{
		mMainDt.SelectAll();
		if (Operators.CompareString(Module_Schm.SchmServerIp, "", false) != 0 && CheckForInternetConnection() && !Module_Schm.bgWorker.IsBusy)
		{
			Module_Schm.SchmClickTrfr = true;
			Module_Schm.bgWorker.RunWorkerAsync();
		}
	}

	public bool CheckForInternetConnection()
	{
		bool result;
		try
		{
			using WebClient webClient = new WebClient();
			using (webClient.OpenRead("http://www.google.com"))
			{
				result = true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void chkNextAi_Click(object sender, EventArgs e)
	{
		checked
		{
			if (chkNextAi.Checked)
			{
				if (Operators.CompareString(DC_Main.MsNextAi, "Y", false) == 0)
				{
					PanalImage_Hide();
					((Form)MyProject.Forms.UT_AI_TRFR).MdiParent = (Form)(object)this;
					DC_Main.TotOpenForm++;
					((Form)MyProject.Forms.UT_WAPP_WITH_API).Text = "AiImage" + Conversions.ToString(DC_Main.TotOpenForm);
					((Control)MyProject.Forms.UT_AI_TRFR).Show();
					((Control)MyProject.Forms.UT_AI_TRFR).Focus();
					chkNextAi.Checked = false;
				}
				else
				{
					Process.Start(new ProcessStartInfo("https://www.dcnextai.com/")
					{
						UseShellExecute = true
					});
					chkNextAi.Checked = false;
				}
			}
		}
	}

	private void chkNextAi_CheckedChanged(object sender, EventArgs e)
	{
	}

	private void chkWappId_CheckedChanged(object sender, EventArgs e)
	{
	}
}
