using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext.My;

[StandardModule]
[HideModuleName]
[GeneratedCode("MyTemplate", "11.0.0.0")]
internal sealed class MyProject
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
	internal sealed class MyForms
	{
		[ThreadStatic]
		private static Hashtable m_FormBeingCreated;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public BtmSchm m_BtmSchm;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MDI_FORM m_MDI_FORM;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_AC_GROUP m_MS_AC_GROUP;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_ACCT m_MS_ACCT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_ADD_MAST m_MS_ADD_MAST;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_AUTO_ITEM m_MS_AUTO_ITEM;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_BOOK m_MS_BOOK;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_BOOKLIST m_MS_BOOKLIST;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_COMPANY m_MS_COMPANY;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_DESIGN_BOOK m_MS_DESIGN_BOOK;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_DM m_MS_DM;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_EMP m_MS_EMP;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_GOLD_MAST m_MS_GOLD_MAST;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_GROUP m_MS_GROUP;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_HELP m_MS_HELP;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_ITEM m_MS_ITEM;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_LBR_TYPE m_MS_LBR_TYPE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_LOCT m_MS_LOCT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_LOGIN m_MS_LOGIN;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_MEMB m_MS_MEMB;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_MFG_MAST m_MS_MFG_MAST;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_OPNCOMP m_MS_OPNCOMP;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_POINT m_MS_POINT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_PRINT m_MS_PRINT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_PRODUCT m_MS_PRODUCT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_RATE m_MS_RATE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_STK_LIMIT m_MS_STK_LIMIT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_STYLE m_MS_STYLE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_TASTING m_MS_TASTING;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_TAX m_MS_TAX;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_TRADE m_MS_TRADE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_UPDATE m_MS_UPDATE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_USER m_MS_USER;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_WINDOW_SET m_MS_WINDOW_SET;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MS_YEAR m_MS_YEAR;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public OlockerService m_OlockerService;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_ADDRESS m_RP_ADDRESS;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_ALL m_RP_ALL;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_BAL_ZOOM m_RP_BAL_ZOOM;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_BALANCE m_RP_BALANCE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_BILL_PROFIT m_RP_BILL_PROFIT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_CASH_BANK m_RP_CASH_BANK;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_CONSI_APR m_RP_CONSI_APR;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_CUST m_RP_CUST;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_CUST_CRM m_RP_CUST_CRM;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_DAY_WORK m_RP_DAY_WORK;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_DHRN_LOAN m_RP_DHRN_LOAN;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_DHRN_OS m_RP_DHRN_OS;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_EMP m_RP_EMP;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_GRAPH m_RP_GRAPH;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_GST m_RP_GST;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_HUID m_RP_HUID;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_INOUT m_RP_INOUT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_JDTR_ZOOM m_RP_JDTR_ZOOM;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_LC_INOUT m_RP_LC_INOUT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_LC_SALE m_RP_LC_SALE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_LEDR m_RP_LEDR;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_MFG m_RP_MFG;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_MFG_LEDR m_RP_MFG_LEDR;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_MFG_ZOOM m_RP_MFG_ZOOM;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_MOVEMENT m_RP_MOVEMENT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_ORD_TRACK m_RP_ORD_TRACK;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_ORDER m_RP_ORDER;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_OS m_RP_OS;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_OTH_DETL m_RP_OTH_DETL;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_PHY_STOCK m_RP_PHY_STOCK;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_REMINDER m_RP_REMINDER;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_ROJMEL m_RP_ROJMEL;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_SLPR_ZOOM m_RP_SLPR_ZOOM;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_STK_LEVEL m_RP_STK_LEVEL;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_STK_MOVE m_RP_STK_MOVE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_STOCK m_RP_STOCK;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_STOCK_FINE m_RP_STOCK_FINE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_STOCK_VALUE m_RP_STOCK_VALUE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_TAG m_RP_TAG;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_TAG_ESTMATE m_RP_TAG_ESTMATE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_TAG_IMAGE m_RP_TAG_IMAGE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_TAX m_RP_TAX;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_TOUR_ZOOM m_RP_TOUR_ZOOM;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_TRADING m_RP_TRADING;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public RP_USER m_RP_USER;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_AC_OPBL m_TR_AC_OPBL;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_APR_ISU m_TR_APR_ISU;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_BILL_TO m_TR_BILL_TO;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_BUL_BOOKING m_TR_BUL_BOOKING;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_BUL_SALE m_TR_BUL_SALE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_CARD_REC m_TR_CARD_REC;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_CASH m_TR_CASH;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_CONTRA m_TR_CONTRA;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_DHRN_INTREC m_TR_DHRN_INTREC;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_DHRN_ISU m_TR_DHRN_ISU;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_DHRN_REC m_TR_DHRN_REC;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_EMP_JV m_TR_EMP_JV;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_FINE_SL_PR m_TR_FINE_SL_PR;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_FN_INOUT m_TR_FN_INOUT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_GOLD_BOOK m_TR_GOLD_BOOK;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_INOUT m_TR_INOUT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_ITM_LOT m_TR_ITM_LOT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_ITM_OPBL m_TR_ITM_OPBL;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_JDT_REC m_TR_JDT_REC;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_KR_ISU m_TR_KR_ISU;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_LEDR_ADJ m_TR_LEDR_ADJ;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_LOCT_AMT m_TR_LOCT_AMT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_MEMB_ADJ m_TR_MEMB_ADJ;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_MEMB_ENT m_TR_MEMB_ENT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_MFG_GHAT_REC m_TR_MFG_GHAT_REC;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_MFG_ISU_REC m_TR_MFG_ISU_REC;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_MFG_ITEM m_TR_MFG_ITEM;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_MFG_KR_ISU_REC m_TR_MFG_KR_ISU_REC;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_MFG_ORD_ISU m_TR_MFG_ORD_ISU;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_MFG_ORD_REC m_TR_MFG_ORD_REC;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_MFG_WITH_LOT m_TR_MFG_WITH_LOT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_MLT_PRO m_TR_MLT_PRO;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_OTH_COMM m_TR_OTH_COMM;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_OTH_PURC m_TR_OTH_PURC;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_PHYSTK m_TR_PHYSTK;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_PR_SL_HEDG m_TR_PR_SL_HEDG;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_PR_SL_UAE m_TR_PR_SL_UAE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_PURC m_TR_PURC;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_PURC_HM m_TR_PURC_HM;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_REP_REC m_TR_REP_REC;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_SALE m_TR_SALE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_SALE_HM m_TR_SALE_HM;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_SALE_LBR m_TR_SALE_LBR;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_SALE_ORD m_TR_SALE_ORD;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_SALE_RTN m_TR_SALE_RTN;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_SALE_RTN_UAE m_TR_SALE_RTN_UAE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_SL_EBILL m_TR_SL_EBILL;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_SL_ORD_ADJ m_TR_SL_ORD_ADJ;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_SL_PR_ITEM m_TR_SL_PR_ITEM;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_TAG_CAN m_TR_TAG_CAN;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_TAG_OPBL m_TR_TAG_OPBL;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_TAG_SPLIT m_TR_TAG_SPLIT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_TAG_WT_DIFF m_TR_TAG_WT_DIFF;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_TOUR m_TR_TOUR;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_TOUR_ORD m_TR_TOUR_ORD;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_TOUR_SALE m_TR_TOUR_SALE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_UPI_REC m_TR_UPI_REC;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_VP m_TR_VP;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_VP_ADJ m_TR_VP_ADJ;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_WH_SALE m_TR_WH_SALE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public TR_WH_SALE_RTN m_TR_WH_SALE_RTN;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_AI_TRFR m_UT_AI_TRFR;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_BANK m_UT_BANK;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_BKP m_UT_BKP;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_CUST_ENTRY m_UT_CUST_ENTRY;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_E_INVOICE m_UT_E_INVOICE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_EXPORT m_UT_EXPORT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_HDD m_UT_HDD;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_IMPORT m_UT_IMPORT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_PWD_UPDATE m_UT_PWD_UPDATE;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_REMINDER m_UT_REMINDER;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_REPORT m_UT_REPORT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_SET_ADMIN m_UT_SET_ADMIN;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_SETTING m_UT_SETTING;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_SETTING_MAIN m_UT_SETTING_MAIN;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_SMS m_UT_SMS;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_TAG_PRINT m_UT_TAG_PRINT;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_USER_REQUEST m_UT_USER_REQUEST;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_VCH_RE_NUMBR m_UT_VCH_RE_NUMBR;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_WAPP_WITH_API m_UT_WAPP_WITH_API;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_WEB_CAM m_UT_WEB_CAM;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_WHATSAPP m_UT_WHATSAPP;

		[EditorBrowsable(EditorBrowsableState.Never)]
		public UT_WINDOW m_UT_WINDOW;

		public BtmSchm BtmSchm
		{
			[DebuggerHidden]
			get
			{
				m_BtmSchm = Create__Instance__(m_BtmSchm);
				return m_BtmSchm;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_BtmSchm)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_BtmSchm);
				}
			}
		}

		public MDI_FORM MDI_FORM
		{
			[DebuggerHidden]
			get
			{
				m_MDI_FORM = Create__Instance__(m_MDI_FORM);
				return m_MDI_FORM;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MDI_FORM)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MDI_FORM);
				}
			}
		}

		public MS_AC_GROUP MS_AC_GROUP
		{
			[DebuggerHidden]
			get
			{
				m_MS_AC_GROUP = Create__Instance__(m_MS_AC_GROUP);
				return m_MS_AC_GROUP;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_AC_GROUP)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_AC_GROUP);
				}
			}
		}

		public MS_ACCT MS_ACCT
		{
			[DebuggerHidden]
			get
			{
				m_MS_ACCT = Create__Instance__(m_MS_ACCT);
				return m_MS_ACCT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_ACCT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_ACCT);
				}
			}
		}

		public MS_ADD_MAST MS_ADD_MAST
		{
			[DebuggerHidden]
			get
			{
				m_MS_ADD_MAST = Create__Instance__(m_MS_ADD_MAST);
				return m_MS_ADD_MAST;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_ADD_MAST)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_ADD_MAST);
				}
			}
		}

		public MS_AUTO_ITEM MS_AUTO_ITEM
		{
			[DebuggerHidden]
			get
			{
				m_MS_AUTO_ITEM = Create__Instance__(m_MS_AUTO_ITEM);
				return m_MS_AUTO_ITEM;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_AUTO_ITEM)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_AUTO_ITEM);
				}
			}
		}

		public MS_BOOK MS_BOOK
		{
			[DebuggerHidden]
			get
			{
				m_MS_BOOK = Create__Instance__(m_MS_BOOK);
				return m_MS_BOOK;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_BOOK)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_BOOK);
				}
			}
		}

		public MS_BOOKLIST MS_BOOKLIST
		{
			[DebuggerHidden]
			get
			{
				m_MS_BOOKLIST = Create__Instance__(m_MS_BOOKLIST);
				return m_MS_BOOKLIST;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_BOOKLIST)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_BOOKLIST);
				}
			}
		}

		public MS_COMPANY MS_COMPANY
		{
			[DebuggerHidden]
			get
			{
				m_MS_COMPANY = Create__Instance__(m_MS_COMPANY);
				return m_MS_COMPANY;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_COMPANY)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_COMPANY);
				}
			}
		}

		public MS_DESIGN_BOOK MS_DESIGN_BOOK
		{
			[DebuggerHidden]
			get
			{
				m_MS_DESIGN_BOOK = Create__Instance__(m_MS_DESIGN_BOOK);
				return m_MS_DESIGN_BOOK;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_DESIGN_BOOK)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_DESIGN_BOOK);
				}
			}
		}

		public MS_DM MS_DM
		{
			[DebuggerHidden]
			get
			{
				m_MS_DM = Create__Instance__(m_MS_DM);
				return m_MS_DM;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_DM)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_DM);
				}
			}
		}

		public MS_EMP MS_EMP
		{
			[DebuggerHidden]
			get
			{
				m_MS_EMP = Create__Instance__(m_MS_EMP);
				return m_MS_EMP;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_EMP)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_EMP);
				}
			}
		}

		public MS_GOLD_MAST MS_GOLD_MAST
		{
			[DebuggerHidden]
			get
			{
				m_MS_GOLD_MAST = Create__Instance__(m_MS_GOLD_MAST);
				return m_MS_GOLD_MAST;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_GOLD_MAST)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_GOLD_MAST);
				}
			}
		}

		public MS_GROUP MS_GROUP
		{
			[DebuggerHidden]
			get
			{
				m_MS_GROUP = Create__Instance__(m_MS_GROUP);
				return m_MS_GROUP;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_GROUP)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_GROUP);
				}
			}
		}

		public MS_HELP MS_HELP
		{
			[DebuggerHidden]
			get
			{
				m_MS_HELP = Create__Instance__(m_MS_HELP);
				return m_MS_HELP;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_HELP)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_HELP);
				}
			}
		}

		public MS_ITEM MS_ITEM
		{
			[DebuggerHidden]
			get
			{
				m_MS_ITEM = Create__Instance__(m_MS_ITEM);
				return m_MS_ITEM;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_ITEM)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_ITEM);
				}
			}
		}

		public MS_LBR_TYPE MS_LBR_TYPE
		{
			[DebuggerHidden]
			get
			{
				m_MS_LBR_TYPE = Create__Instance__(m_MS_LBR_TYPE);
				return m_MS_LBR_TYPE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_LBR_TYPE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_LBR_TYPE);
				}
			}
		}

		public MS_LOCT MS_LOCT
		{
			[DebuggerHidden]
			get
			{
				m_MS_LOCT = Create__Instance__(m_MS_LOCT);
				return m_MS_LOCT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_LOCT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_LOCT);
				}
			}
		}

		public MS_LOGIN MS_LOGIN
		{
			[DebuggerHidden]
			get
			{
				m_MS_LOGIN = Create__Instance__(m_MS_LOGIN);
				return m_MS_LOGIN;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_LOGIN)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_LOGIN);
				}
			}
		}

		public MS_MEMB MS_MEMB
		{
			[DebuggerHidden]
			get
			{
				m_MS_MEMB = Create__Instance__(m_MS_MEMB);
				return m_MS_MEMB;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_MEMB)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_MEMB);
				}
			}
		}

		public MS_MFG_MAST MS_MFG_MAST
		{
			[DebuggerHidden]
			get
			{
				m_MS_MFG_MAST = Create__Instance__(m_MS_MFG_MAST);
				return m_MS_MFG_MAST;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_MFG_MAST)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_MFG_MAST);
				}
			}
		}

		public MS_OPNCOMP MS_OPNCOMP
		{
			[DebuggerHidden]
			get
			{
				m_MS_OPNCOMP = Create__Instance__(m_MS_OPNCOMP);
				return m_MS_OPNCOMP;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_OPNCOMP)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_OPNCOMP);
				}
			}
		}

		public MS_POINT MS_POINT
		{
			[DebuggerHidden]
			get
			{
				m_MS_POINT = Create__Instance__(m_MS_POINT);
				return m_MS_POINT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_POINT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_POINT);
				}
			}
		}

		public MS_PRINT MS_PRINT
		{
			[DebuggerHidden]
			get
			{
				m_MS_PRINT = Create__Instance__(m_MS_PRINT);
				return m_MS_PRINT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_PRINT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_PRINT);
				}
			}
		}

		public MS_PRODUCT MS_PRODUCT
		{
			[DebuggerHidden]
			get
			{
				m_MS_PRODUCT = Create__Instance__(m_MS_PRODUCT);
				return m_MS_PRODUCT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_PRODUCT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_PRODUCT);
				}
			}
		}

		public MS_RATE MS_RATE
		{
			[DebuggerHidden]
			get
			{
				m_MS_RATE = Create__Instance__(m_MS_RATE);
				return m_MS_RATE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_RATE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_RATE);
				}
			}
		}

		public MS_STK_LIMIT MS_STK_LIMIT
		{
			[DebuggerHidden]
			get
			{
				m_MS_STK_LIMIT = Create__Instance__(m_MS_STK_LIMIT);
				return m_MS_STK_LIMIT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_STK_LIMIT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_STK_LIMIT);
				}
			}
		}

		public MS_STYLE MS_STYLE
		{
			[DebuggerHidden]
			get
			{
				m_MS_STYLE = Create__Instance__(m_MS_STYLE);
				return m_MS_STYLE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_STYLE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_STYLE);
				}
			}
		}

		public MS_TASTING MS_TASTING
		{
			[DebuggerHidden]
			get
			{
				m_MS_TASTING = Create__Instance__(m_MS_TASTING);
				return m_MS_TASTING;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_TASTING)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_TASTING);
				}
			}
		}

		public MS_TAX MS_TAX
		{
			[DebuggerHidden]
			get
			{
				m_MS_TAX = Create__Instance__(m_MS_TAX);
				return m_MS_TAX;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_TAX)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_TAX);
				}
			}
		}

		public MS_TRADE MS_TRADE
		{
			[DebuggerHidden]
			get
			{
				m_MS_TRADE = Create__Instance__(m_MS_TRADE);
				return m_MS_TRADE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_TRADE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_TRADE);
				}
			}
		}

		public MS_UPDATE MS_UPDATE
		{
			[DebuggerHidden]
			get
			{
				m_MS_UPDATE = Create__Instance__(m_MS_UPDATE);
				return m_MS_UPDATE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_UPDATE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_UPDATE);
				}
			}
		}

		public MS_USER MS_USER
		{
			[DebuggerHidden]
			get
			{
				m_MS_USER = Create__Instance__(m_MS_USER);
				return m_MS_USER;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_USER)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_USER);
				}
			}
		}

		public MS_WINDOW_SET MS_WINDOW_SET
		{
			[DebuggerHidden]
			get
			{
				m_MS_WINDOW_SET = Create__Instance__(m_MS_WINDOW_SET);
				return m_MS_WINDOW_SET;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_WINDOW_SET)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_WINDOW_SET);
				}
			}
		}

		public MS_YEAR MS_YEAR
		{
			[DebuggerHidden]
			get
			{
				m_MS_YEAR = Create__Instance__(m_MS_YEAR);
				return m_MS_YEAR;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_MS_YEAR)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_MS_YEAR);
				}
			}
		}

		public OlockerService OlockerService
		{
			[DebuggerHidden]
			get
			{
				m_OlockerService = Create__Instance__(m_OlockerService);
				return m_OlockerService;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_OlockerService)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_OlockerService);
				}
			}
		}

		public RP_ADDRESS RP_ADDRESS
		{
			[DebuggerHidden]
			get
			{
				m_RP_ADDRESS = Create__Instance__(m_RP_ADDRESS);
				return m_RP_ADDRESS;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_ADDRESS)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_ADDRESS);
				}
			}
		}

		public RP_ALL RP_ALL
		{
			[DebuggerHidden]
			get
			{
				m_RP_ALL = Create__Instance__(m_RP_ALL);
				return m_RP_ALL;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_ALL)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_ALL);
				}
			}
		}

		public RP_BAL_ZOOM RP_BAL_ZOOM
		{
			[DebuggerHidden]
			get
			{
				m_RP_BAL_ZOOM = Create__Instance__(m_RP_BAL_ZOOM);
				return m_RP_BAL_ZOOM;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_BAL_ZOOM)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_BAL_ZOOM);
				}
			}
		}

		public RP_BALANCE RP_BALANCE
		{
			[DebuggerHidden]
			get
			{
				m_RP_BALANCE = Create__Instance__(m_RP_BALANCE);
				return m_RP_BALANCE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_BALANCE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_BALANCE);
				}
			}
		}

		public RP_BILL_PROFIT RP_BILL_PROFIT
		{
			[DebuggerHidden]
			get
			{
				m_RP_BILL_PROFIT = Create__Instance__(m_RP_BILL_PROFIT);
				return m_RP_BILL_PROFIT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_BILL_PROFIT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_BILL_PROFIT);
				}
			}
		}

		public RP_CASH_BANK RP_CASH_BANK
		{
			[DebuggerHidden]
			get
			{
				m_RP_CASH_BANK = Create__Instance__(m_RP_CASH_BANK);
				return m_RP_CASH_BANK;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_CASH_BANK)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_CASH_BANK);
				}
			}
		}

		public RP_CONSI_APR RP_CONSI_APR
		{
			[DebuggerHidden]
			get
			{
				m_RP_CONSI_APR = Create__Instance__(m_RP_CONSI_APR);
				return m_RP_CONSI_APR;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_CONSI_APR)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_CONSI_APR);
				}
			}
		}

		public RP_CUST RP_CUST
		{
			[DebuggerHidden]
			get
			{
				m_RP_CUST = Create__Instance__<RP_CUST>(m_RP_CUST);
				return m_RP_CUST;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_CUST)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__<RP_CUST>(ref m_RP_CUST);
				}
			}
		}

		public RP_CUST_CRM RP_CUST_CRM
		{
			[DebuggerHidden]
			get
			{
				m_RP_CUST_CRM = Create__Instance__(m_RP_CUST_CRM);
				return m_RP_CUST_CRM;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_CUST_CRM)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_CUST_CRM);
				}
			}
		}

		public RP_DAY_WORK RP_DAY_WORK
		{
			[DebuggerHidden]
			get
			{
				m_RP_DAY_WORK = Create__Instance__(m_RP_DAY_WORK);
				return m_RP_DAY_WORK;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_DAY_WORK)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_DAY_WORK);
				}
			}
		}

		public RP_DHRN_LOAN RP_DHRN_LOAN
		{
			[DebuggerHidden]
			get
			{
				m_RP_DHRN_LOAN = Create__Instance__(m_RP_DHRN_LOAN);
				return m_RP_DHRN_LOAN;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_DHRN_LOAN)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_DHRN_LOAN);
				}
			}
		}

		public RP_DHRN_OS RP_DHRN_OS
		{
			[DebuggerHidden]
			get
			{
				m_RP_DHRN_OS = Create__Instance__(m_RP_DHRN_OS);
				return m_RP_DHRN_OS;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_DHRN_OS)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_DHRN_OS);
				}
			}
		}

		public RP_EMP RP_EMP
		{
			[DebuggerHidden]
			get
			{
				m_RP_EMP = Create__Instance__(m_RP_EMP);
				return m_RP_EMP;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_EMP)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_EMP);
				}
			}
		}

		public RP_GRAPH RP_GRAPH
		{
			[DebuggerHidden]
			get
			{
				m_RP_GRAPH = Create__Instance__(m_RP_GRAPH);
				return m_RP_GRAPH;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_GRAPH)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_GRAPH);
				}
			}
		}

		public RP_GST RP_GST
		{
			[DebuggerHidden]
			get
			{
				m_RP_GST = Create__Instance__(m_RP_GST);
				return m_RP_GST;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_GST)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_GST);
				}
			}
		}

		public RP_HUID RP_HUID
		{
			[DebuggerHidden]
			get
			{
				m_RP_HUID = Create__Instance__<RP_HUID>(m_RP_HUID);
				return m_RP_HUID;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_HUID)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__<RP_HUID>(ref m_RP_HUID);
				}
			}
		}

		public RP_INOUT RP_INOUT
		{
			[DebuggerHidden]
			get
			{
				m_RP_INOUT = Create__Instance__(m_RP_INOUT);
				return m_RP_INOUT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_INOUT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_INOUT);
				}
			}
		}

		public RP_JDTR_ZOOM RP_JDTR_ZOOM
		{
			[DebuggerHidden]
			get
			{
				m_RP_JDTR_ZOOM = Create__Instance__(m_RP_JDTR_ZOOM);
				return m_RP_JDTR_ZOOM;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_JDTR_ZOOM)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_JDTR_ZOOM);
				}
			}
		}

		public RP_LC_INOUT RP_LC_INOUT
		{
			[DebuggerHidden]
			get
			{
				m_RP_LC_INOUT = Create__Instance__(m_RP_LC_INOUT);
				return m_RP_LC_INOUT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_LC_INOUT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_LC_INOUT);
				}
			}
		}

		public RP_LC_SALE RP_LC_SALE
		{
			[DebuggerHidden]
			get
			{
				m_RP_LC_SALE = Create__Instance__(m_RP_LC_SALE);
				return m_RP_LC_SALE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_LC_SALE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_LC_SALE);
				}
			}
		}

		public RP_LEDR RP_LEDR
		{
			[DebuggerHidden]
			get
			{
				m_RP_LEDR = Create__Instance__(m_RP_LEDR);
				return m_RP_LEDR;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_LEDR)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_LEDR);
				}
			}
		}

		public RP_MFG RP_MFG
		{
			[DebuggerHidden]
			get
			{
				m_RP_MFG = Create__Instance__(m_RP_MFG);
				return m_RP_MFG;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_MFG)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_MFG);
				}
			}
		}

		public RP_MFG_LEDR RP_MFG_LEDR
		{
			[DebuggerHidden]
			get
			{
				m_RP_MFG_LEDR = Create__Instance__(m_RP_MFG_LEDR);
				return m_RP_MFG_LEDR;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_MFG_LEDR)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_MFG_LEDR);
				}
			}
		}

		public RP_MFG_ZOOM RP_MFG_ZOOM
		{
			[DebuggerHidden]
			get
			{
				m_RP_MFG_ZOOM = Create__Instance__(m_RP_MFG_ZOOM);
				return m_RP_MFG_ZOOM;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_MFG_ZOOM)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_MFG_ZOOM);
				}
			}
		}

		public RP_MOVEMENT RP_MOVEMENT
		{
			[DebuggerHidden]
			get
			{
				m_RP_MOVEMENT = Create__Instance__(m_RP_MOVEMENT);
				return m_RP_MOVEMENT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_MOVEMENT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_MOVEMENT);
				}
			}
		}

		public RP_ORD_TRACK RP_ORD_TRACK
		{
			[DebuggerHidden]
			get
			{
				m_RP_ORD_TRACK = Create__Instance__(m_RP_ORD_TRACK);
				return m_RP_ORD_TRACK;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_ORD_TRACK)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_ORD_TRACK);
				}
			}
		}

		public RP_ORDER RP_ORDER
		{
			[DebuggerHidden]
			get
			{
				m_RP_ORDER = Create__Instance__(m_RP_ORDER);
				return m_RP_ORDER;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_ORDER)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_ORDER);
				}
			}
		}

		public RP_OS RP_OS
		{
			[DebuggerHidden]
			get
			{
				m_RP_OS = Create__Instance__(m_RP_OS);
				return m_RP_OS;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_OS)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_OS);
				}
			}
		}

		public RP_OTH_DETL RP_OTH_DETL
		{
			[DebuggerHidden]
			get
			{
				m_RP_OTH_DETL = Create__Instance__(m_RP_OTH_DETL);
				return m_RP_OTH_DETL;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_OTH_DETL)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_OTH_DETL);
				}
			}
		}

		public RP_PHY_STOCK RP_PHY_STOCK
		{
			[DebuggerHidden]
			get
			{
				m_RP_PHY_STOCK = Create__Instance__(m_RP_PHY_STOCK);
				return m_RP_PHY_STOCK;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_PHY_STOCK)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_PHY_STOCK);
				}
			}
		}

		public RP_REMINDER RP_REMINDER
		{
			[DebuggerHidden]
			get
			{
				m_RP_REMINDER = Create__Instance__(m_RP_REMINDER);
				return m_RP_REMINDER;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_REMINDER)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_REMINDER);
				}
			}
		}

		public RP_ROJMEL RP_ROJMEL
		{
			[DebuggerHidden]
			get
			{
				m_RP_ROJMEL = Create__Instance__(m_RP_ROJMEL);
				return m_RP_ROJMEL;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_ROJMEL)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_ROJMEL);
				}
			}
		}

		public RP_SLPR_ZOOM RP_SLPR_ZOOM
		{
			[DebuggerHidden]
			get
			{
				m_RP_SLPR_ZOOM = Create__Instance__(m_RP_SLPR_ZOOM);
				return m_RP_SLPR_ZOOM;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_SLPR_ZOOM)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_SLPR_ZOOM);
				}
			}
		}

		public RP_STK_LEVEL RP_STK_LEVEL
		{
			[DebuggerHidden]
			get
			{
				m_RP_STK_LEVEL = Create__Instance__(m_RP_STK_LEVEL);
				return m_RP_STK_LEVEL;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_STK_LEVEL)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_STK_LEVEL);
				}
			}
		}

		public RP_STK_MOVE RP_STK_MOVE
		{
			[DebuggerHidden]
			get
			{
				m_RP_STK_MOVE = Create__Instance__(m_RP_STK_MOVE);
				return m_RP_STK_MOVE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_STK_MOVE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_STK_MOVE);
				}
			}
		}

		public RP_STOCK RP_STOCK
		{
			[DebuggerHidden]
			get
			{
				m_RP_STOCK = Create__Instance__(m_RP_STOCK);
				return m_RP_STOCK;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_STOCK)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_STOCK);
				}
			}
		}

		public RP_STOCK_FINE RP_STOCK_FINE
		{
			[DebuggerHidden]
			get
			{
				m_RP_STOCK_FINE = Create__Instance__(m_RP_STOCK_FINE);
				return m_RP_STOCK_FINE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_STOCK_FINE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_STOCK_FINE);
				}
			}
		}

		public RP_STOCK_VALUE RP_STOCK_VALUE
		{
			[DebuggerHidden]
			get
			{
				m_RP_STOCK_VALUE = Create__Instance__(m_RP_STOCK_VALUE);
				return m_RP_STOCK_VALUE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_STOCK_VALUE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_STOCK_VALUE);
				}
			}
		}

		public RP_TAG RP_TAG
		{
			[DebuggerHidden]
			get
			{
				m_RP_TAG = Create__Instance__<RP_TAG>(m_RP_TAG);
				return m_RP_TAG;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_TAG)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__<RP_TAG>(ref m_RP_TAG);
				}
			}
		}

		public RP_TAG_ESTMATE RP_TAG_ESTMATE
		{
			[DebuggerHidden]
			get
			{
				m_RP_TAG_ESTMATE = Create__Instance__<RP_TAG_ESTMATE>(m_RP_TAG_ESTMATE);
				return m_RP_TAG_ESTMATE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_TAG_ESTMATE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__<RP_TAG_ESTMATE>(ref m_RP_TAG_ESTMATE);
				}
			}
		}

		public RP_TAG_IMAGE RP_TAG_IMAGE
		{
			[DebuggerHidden]
			get
			{
				m_RP_TAG_IMAGE = Create__Instance__<RP_TAG_IMAGE>(m_RP_TAG_IMAGE);
				return m_RP_TAG_IMAGE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_TAG_IMAGE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__<RP_TAG_IMAGE>(ref m_RP_TAG_IMAGE);
				}
			}
		}

		public RP_TAX RP_TAX
		{
			[DebuggerHidden]
			get
			{
				m_RP_TAX = Create__Instance__(m_RP_TAX);
				return m_RP_TAX;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_TAX)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_TAX);
				}
			}
		}

		public RP_TOUR_ZOOM RP_TOUR_ZOOM
		{
			[DebuggerHidden]
			get
			{
				m_RP_TOUR_ZOOM = Create__Instance__(m_RP_TOUR_ZOOM);
				return m_RP_TOUR_ZOOM;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_TOUR_ZOOM)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_TOUR_ZOOM);
				}
			}
		}

		public RP_TRADING RP_TRADING
		{
			[DebuggerHidden]
			get
			{
				m_RP_TRADING = Create__Instance__(m_RP_TRADING);
				return m_RP_TRADING;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_TRADING)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_TRADING);
				}
			}
		}

		public RP_USER RP_USER
		{
			[DebuggerHidden]
			get
			{
				m_RP_USER = Create__Instance__(m_RP_USER);
				return m_RP_USER;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_RP_USER)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_RP_USER);
				}
			}
		}

		public TR_AC_OPBL TR_AC_OPBL
		{
			[DebuggerHidden]
			get
			{
				m_TR_AC_OPBL = Create__Instance__(m_TR_AC_OPBL);
				return m_TR_AC_OPBL;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_AC_OPBL)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_AC_OPBL);
				}
			}
		}

		public TR_APR_ISU TR_APR_ISU
		{
			[DebuggerHidden]
			get
			{
				m_TR_APR_ISU = Create__Instance__(m_TR_APR_ISU);
				return m_TR_APR_ISU;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_APR_ISU)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_APR_ISU);
				}
			}
		}

		public TR_BILL_TO TR_BILL_TO
		{
			[DebuggerHidden]
			get
			{
				m_TR_BILL_TO = Create__Instance__(m_TR_BILL_TO);
				return m_TR_BILL_TO;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_BILL_TO)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_BILL_TO);
				}
			}
		}

		public TR_BUL_BOOKING TR_BUL_BOOKING
		{
			[DebuggerHidden]
			get
			{
				m_TR_BUL_BOOKING = Create__Instance__(m_TR_BUL_BOOKING);
				return m_TR_BUL_BOOKING;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_BUL_BOOKING)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_BUL_BOOKING);
				}
			}
		}

		public TR_BUL_SALE TR_BUL_SALE
		{
			[DebuggerHidden]
			get
			{
				m_TR_BUL_SALE = Create__Instance__(m_TR_BUL_SALE);
				return m_TR_BUL_SALE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_BUL_SALE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_BUL_SALE);
				}
			}
		}

		public TR_CARD_REC TR_CARD_REC
		{
			[DebuggerHidden]
			get
			{
				m_TR_CARD_REC = Create__Instance__(m_TR_CARD_REC);
				return m_TR_CARD_REC;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_CARD_REC)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_CARD_REC);
				}
			}
		}

		public TR_CASH TR_CASH
		{
			[DebuggerHidden]
			get
			{
				m_TR_CASH = Create__Instance__(m_TR_CASH);
				return m_TR_CASH;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_CASH)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_CASH);
				}
			}
		}

		public TR_CONTRA TR_CONTRA
		{
			[DebuggerHidden]
			get
			{
				m_TR_CONTRA = Create__Instance__(m_TR_CONTRA);
				return m_TR_CONTRA;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_CONTRA)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_CONTRA);
				}
			}
		}

		public TR_DHRN_INTREC TR_DHRN_INTREC
		{
			[DebuggerHidden]
			get
			{
				m_TR_DHRN_INTREC = Create__Instance__(m_TR_DHRN_INTREC);
				return m_TR_DHRN_INTREC;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_DHRN_INTREC)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_DHRN_INTREC);
				}
			}
		}

		public TR_DHRN_ISU TR_DHRN_ISU
		{
			[DebuggerHidden]
			get
			{
				m_TR_DHRN_ISU = Create__Instance__(m_TR_DHRN_ISU);
				return m_TR_DHRN_ISU;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_DHRN_ISU)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_DHRN_ISU);
				}
			}
		}

		public TR_DHRN_REC TR_DHRN_REC
		{
			[DebuggerHidden]
			get
			{
				m_TR_DHRN_REC = Create__Instance__(m_TR_DHRN_REC);
				return m_TR_DHRN_REC;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_DHRN_REC)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_DHRN_REC);
				}
			}
		}

		public TR_EMP_JV TR_EMP_JV
		{
			[DebuggerHidden]
			get
			{
				m_TR_EMP_JV = Create__Instance__(m_TR_EMP_JV);
				return m_TR_EMP_JV;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_EMP_JV)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_EMP_JV);
				}
			}
		}

		public TR_FINE_SL_PR TR_FINE_SL_PR
		{
			[DebuggerHidden]
			get
			{
				m_TR_FINE_SL_PR = Create__Instance__(m_TR_FINE_SL_PR);
				return m_TR_FINE_SL_PR;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_FINE_SL_PR)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_FINE_SL_PR);
				}
			}
		}

		public TR_FN_INOUT TR_FN_INOUT
		{
			[DebuggerHidden]
			get
			{
				m_TR_FN_INOUT = Create__Instance__(m_TR_FN_INOUT);
				return m_TR_FN_INOUT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_FN_INOUT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_FN_INOUT);
				}
			}
		}

		public TR_GOLD_BOOK TR_GOLD_BOOK
		{
			[DebuggerHidden]
			get
			{
				m_TR_GOLD_BOOK = Create__Instance__(m_TR_GOLD_BOOK);
				return m_TR_GOLD_BOOK;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_GOLD_BOOK)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_GOLD_BOOK);
				}
			}
		}

		public TR_INOUT TR_INOUT
		{
			[DebuggerHidden]
			get
			{
				m_TR_INOUT = Create__Instance__(m_TR_INOUT);
				return m_TR_INOUT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_INOUT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_INOUT);
				}
			}
		}

		public TR_ITM_LOT TR_ITM_LOT
		{
			[DebuggerHidden]
			get
			{
				m_TR_ITM_LOT = Create__Instance__(m_TR_ITM_LOT);
				return m_TR_ITM_LOT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_ITM_LOT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_ITM_LOT);
				}
			}
		}

		public TR_ITM_OPBL TR_ITM_OPBL
		{
			[DebuggerHidden]
			get
			{
				m_TR_ITM_OPBL = Create__Instance__(m_TR_ITM_OPBL);
				return m_TR_ITM_OPBL;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_ITM_OPBL)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_ITM_OPBL);
				}
			}
		}

		public TR_JDT_REC TR_JDT_REC
		{
			[DebuggerHidden]
			get
			{
				m_TR_JDT_REC = Create__Instance__(m_TR_JDT_REC);
				return m_TR_JDT_REC;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_JDT_REC)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_JDT_REC);
				}
			}
		}

		public TR_KR_ISU TR_KR_ISU
		{
			[DebuggerHidden]
			get
			{
				m_TR_KR_ISU = Create__Instance__(m_TR_KR_ISU);
				return m_TR_KR_ISU;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_KR_ISU)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_KR_ISU);
				}
			}
		}

		public TR_LEDR_ADJ TR_LEDR_ADJ
		{
			[DebuggerHidden]
			get
			{
				m_TR_LEDR_ADJ = Create__Instance__(m_TR_LEDR_ADJ);
				return m_TR_LEDR_ADJ;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_LEDR_ADJ)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_LEDR_ADJ);
				}
			}
		}

		public TR_LOCT_AMT TR_LOCT_AMT
		{
			[DebuggerHidden]
			get
			{
				m_TR_LOCT_AMT = Create__Instance__(m_TR_LOCT_AMT);
				return m_TR_LOCT_AMT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_LOCT_AMT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_LOCT_AMT);
				}
			}
		}

		public TR_MEMB_ADJ TR_MEMB_ADJ
		{
			[DebuggerHidden]
			get
			{
				m_TR_MEMB_ADJ = Create__Instance__(m_TR_MEMB_ADJ);
				return m_TR_MEMB_ADJ;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_MEMB_ADJ)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_MEMB_ADJ);
				}
			}
		}

		public TR_MEMB_ENT TR_MEMB_ENT
		{
			[DebuggerHidden]
			get
			{
				m_TR_MEMB_ENT = Create__Instance__(m_TR_MEMB_ENT);
				return m_TR_MEMB_ENT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_MEMB_ENT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_MEMB_ENT);
				}
			}
		}

		public TR_MFG_GHAT_REC TR_MFG_GHAT_REC
		{
			[DebuggerHidden]
			get
			{
				m_TR_MFG_GHAT_REC = Create__Instance__(m_TR_MFG_GHAT_REC);
				return m_TR_MFG_GHAT_REC;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_MFG_GHAT_REC)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_MFG_GHAT_REC);
				}
			}
		}

		public TR_MFG_ISU_REC TR_MFG_ISU_REC
		{
			[DebuggerHidden]
			get
			{
				m_TR_MFG_ISU_REC = Create__Instance__(m_TR_MFG_ISU_REC);
				return m_TR_MFG_ISU_REC;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_MFG_ISU_REC)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_MFG_ISU_REC);
				}
			}
		}

		public TR_MFG_ITEM TR_MFG_ITEM
		{
			[DebuggerHidden]
			get
			{
				m_TR_MFG_ITEM = Create__Instance__(m_TR_MFG_ITEM);
				return m_TR_MFG_ITEM;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_MFG_ITEM)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_MFG_ITEM);
				}
			}
		}

		public TR_MFG_KR_ISU_REC TR_MFG_KR_ISU_REC
		{
			[DebuggerHidden]
			get
			{
				m_TR_MFG_KR_ISU_REC = Create__Instance__(m_TR_MFG_KR_ISU_REC);
				return m_TR_MFG_KR_ISU_REC;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_MFG_KR_ISU_REC)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_MFG_KR_ISU_REC);
				}
			}
		}

		public TR_MFG_ORD_ISU TR_MFG_ORD_ISU
		{
			[DebuggerHidden]
			get
			{
				m_TR_MFG_ORD_ISU = Create__Instance__(m_TR_MFG_ORD_ISU);
				return m_TR_MFG_ORD_ISU;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_MFG_ORD_ISU)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_MFG_ORD_ISU);
				}
			}
		}

		public TR_MFG_ORD_REC TR_MFG_ORD_REC
		{
			[DebuggerHidden]
			get
			{
				m_TR_MFG_ORD_REC = Create__Instance__(m_TR_MFG_ORD_REC);
				return m_TR_MFG_ORD_REC;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_MFG_ORD_REC)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_MFG_ORD_REC);
				}
			}
		}

		public TR_MFG_WITH_LOT TR_MFG_WITH_LOT
		{
			[DebuggerHidden]
			get
			{
				m_TR_MFG_WITH_LOT = Create__Instance__(m_TR_MFG_WITH_LOT);
				return m_TR_MFG_WITH_LOT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_MFG_WITH_LOT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_MFG_WITH_LOT);
				}
			}
		}

		public TR_MLT_PRO TR_MLT_PRO
		{
			[DebuggerHidden]
			get
			{
				m_TR_MLT_PRO = Create__Instance__(m_TR_MLT_PRO);
				return m_TR_MLT_PRO;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_MLT_PRO)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_MLT_PRO);
				}
			}
		}

		public TR_OTH_COMM TR_OTH_COMM
		{
			[DebuggerHidden]
			get
			{
				m_TR_OTH_COMM = Create__Instance__(m_TR_OTH_COMM);
				return m_TR_OTH_COMM;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_OTH_COMM)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_OTH_COMM);
				}
			}
		}

		public TR_OTH_PURC TR_OTH_PURC
		{
			[DebuggerHidden]
			get
			{
				m_TR_OTH_PURC = Create__Instance__(m_TR_OTH_PURC);
				return m_TR_OTH_PURC;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_OTH_PURC)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_OTH_PURC);
				}
			}
		}

		public TR_PHYSTK TR_PHYSTK
		{
			[DebuggerHidden]
			get
			{
				m_TR_PHYSTK = Create__Instance__(m_TR_PHYSTK);
				return m_TR_PHYSTK;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_PHYSTK)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_PHYSTK);
				}
			}
		}

		public TR_PR_SL_HEDG TR_PR_SL_HEDG
		{
			[DebuggerHidden]
			get
			{
				m_TR_PR_SL_HEDG = Create__Instance__(m_TR_PR_SL_HEDG);
				return m_TR_PR_SL_HEDG;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_PR_SL_HEDG)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_PR_SL_HEDG);
				}
			}
		}

		public TR_PR_SL_UAE TR_PR_SL_UAE
		{
			[DebuggerHidden]
			get
			{
				m_TR_PR_SL_UAE = Create__Instance__(m_TR_PR_SL_UAE);
				return m_TR_PR_SL_UAE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_PR_SL_UAE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_PR_SL_UAE);
				}
			}
		}

		public TR_PURC TR_PURC
		{
			[DebuggerHidden]
			get
			{
				m_TR_PURC = Create__Instance__(m_TR_PURC);
				return m_TR_PURC;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_PURC)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_PURC);
				}
			}
		}

		public TR_PURC_HM TR_PURC_HM
		{
			[DebuggerHidden]
			get
			{
				m_TR_PURC_HM = Create__Instance__(m_TR_PURC_HM);
				return m_TR_PURC_HM;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_PURC_HM)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_PURC_HM);
				}
			}
		}

		public TR_REP_REC TR_REP_REC
		{
			[DebuggerHidden]
			get
			{
				m_TR_REP_REC = Create__Instance__(m_TR_REP_REC);
				return m_TR_REP_REC;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_REP_REC)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_REP_REC);
				}
			}
		}

		public TR_SALE TR_SALE
		{
			[DebuggerHidden]
			get
			{
				m_TR_SALE = Create__Instance__(m_TR_SALE);
				return m_TR_SALE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_SALE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_SALE);
				}
			}
		}

		public TR_SALE_HM TR_SALE_HM
		{
			[DebuggerHidden]
			get
			{
				m_TR_SALE_HM = Create__Instance__(m_TR_SALE_HM);
				return m_TR_SALE_HM;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_SALE_HM)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_SALE_HM);
				}
			}
		}

		public TR_SALE_LBR TR_SALE_LBR
		{
			[DebuggerHidden]
			get
			{
				m_TR_SALE_LBR = Create__Instance__(m_TR_SALE_LBR);
				return m_TR_SALE_LBR;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_SALE_LBR)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_SALE_LBR);
				}
			}
		}

		public TR_SALE_ORD TR_SALE_ORD
		{
			[DebuggerHidden]
			get
			{
				m_TR_SALE_ORD = Create__Instance__(m_TR_SALE_ORD);
				return m_TR_SALE_ORD;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_SALE_ORD)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_SALE_ORD);
				}
			}
		}

		public TR_SALE_RTN TR_SALE_RTN
		{
			[DebuggerHidden]
			get
			{
				m_TR_SALE_RTN = Create__Instance__(m_TR_SALE_RTN);
				return m_TR_SALE_RTN;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_SALE_RTN)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_SALE_RTN);
				}
			}
		}

		public TR_SALE_RTN_UAE TR_SALE_RTN_UAE
		{
			[DebuggerHidden]
			get
			{
				m_TR_SALE_RTN_UAE = Create__Instance__(m_TR_SALE_RTN_UAE);
				return m_TR_SALE_RTN_UAE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_SALE_RTN_UAE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_SALE_RTN_UAE);
				}
			}
		}

		public TR_SL_EBILL TR_SL_EBILL
		{
			[DebuggerHidden]
			get
			{
				m_TR_SL_EBILL = Create__Instance__(m_TR_SL_EBILL);
				return m_TR_SL_EBILL;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_SL_EBILL)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_SL_EBILL);
				}
			}
		}

		public TR_SL_ORD_ADJ TR_SL_ORD_ADJ
		{
			[DebuggerHidden]
			get
			{
				m_TR_SL_ORD_ADJ = Create__Instance__(m_TR_SL_ORD_ADJ);
				return m_TR_SL_ORD_ADJ;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_SL_ORD_ADJ)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_SL_ORD_ADJ);
				}
			}
		}

		public TR_SL_PR_ITEM TR_SL_PR_ITEM
		{
			[DebuggerHidden]
			get
			{
				m_TR_SL_PR_ITEM = Create__Instance__(m_TR_SL_PR_ITEM);
				return m_TR_SL_PR_ITEM;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_SL_PR_ITEM)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_SL_PR_ITEM);
				}
			}
		}

		public TR_TAG_CAN TR_TAG_CAN
		{
			[DebuggerHidden]
			get
			{
				m_TR_TAG_CAN = Create__Instance__(m_TR_TAG_CAN);
				return m_TR_TAG_CAN;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_TAG_CAN)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_TAG_CAN);
				}
			}
		}

		public TR_TAG_OPBL TR_TAG_OPBL
		{
			[DebuggerHidden]
			get
			{
				m_TR_TAG_OPBL = Create__Instance__(m_TR_TAG_OPBL);
				return m_TR_TAG_OPBL;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_TAG_OPBL)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_TAG_OPBL);
				}
			}
		}

		public TR_TAG_SPLIT TR_TAG_SPLIT
		{
			[DebuggerHidden]
			get
			{
				m_TR_TAG_SPLIT = Create__Instance__(m_TR_TAG_SPLIT);
				return m_TR_TAG_SPLIT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_TAG_SPLIT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_TAG_SPLIT);
				}
			}
		}

		public TR_TAG_WT_DIFF TR_TAG_WT_DIFF
		{
			[DebuggerHidden]
			get
			{
				m_TR_TAG_WT_DIFF = Create__Instance__(m_TR_TAG_WT_DIFF);
				return m_TR_TAG_WT_DIFF;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_TAG_WT_DIFF)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_TAG_WT_DIFF);
				}
			}
		}

		public TR_TOUR TR_TOUR
		{
			[DebuggerHidden]
			get
			{
				m_TR_TOUR = Create__Instance__(m_TR_TOUR);
				return m_TR_TOUR;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_TOUR)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_TOUR);
				}
			}
		}

		public TR_TOUR_ORD TR_TOUR_ORD
		{
			[DebuggerHidden]
			get
			{
				m_TR_TOUR_ORD = Create__Instance__(m_TR_TOUR_ORD);
				return m_TR_TOUR_ORD;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_TOUR_ORD)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_TOUR_ORD);
				}
			}
		}

		public TR_TOUR_SALE TR_TOUR_SALE
		{
			[DebuggerHidden]
			get
			{
				m_TR_TOUR_SALE = Create__Instance__(m_TR_TOUR_SALE);
				return m_TR_TOUR_SALE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_TOUR_SALE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_TOUR_SALE);
				}
			}
		}

		public TR_UPI_REC TR_UPI_REC
		{
			[DebuggerHidden]
			get
			{
				m_TR_UPI_REC = Create__Instance__(m_TR_UPI_REC);
				return m_TR_UPI_REC;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_UPI_REC)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_UPI_REC);
				}
			}
		}

		public TR_VP TR_VP
		{
			[DebuggerHidden]
			get
			{
				m_TR_VP = Create__Instance__(m_TR_VP);
				return m_TR_VP;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_VP)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_VP);
				}
			}
		}

		public TR_VP_ADJ TR_VP_ADJ
		{
			[DebuggerHidden]
			get
			{
				m_TR_VP_ADJ = Create__Instance__(m_TR_VP_ADJ);
				return m_TR_VP_ADJ;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_VP_ADJ)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_VP_ADJ);
				}
			}
		}

		public TR_WH_SALE TR_WH_SALE
		{
			[DebuggerHidden]
			get
			{
				m_TR_WH_SALE = Create__Instance__(m_TR_WH_SALE);
				return m_TR_WH_SALE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_WH_SALE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_WH_SALE);
				}
			}
		}

		public TR_WH_SALE_RTN TR_WH_SALE_RTN
		{
			[DebuggerHidden]
			get
			{
				m_TR_WH_SALE_RTN = Create__Instance__(m_TR_WH_SALE_RTN);
				return m_TR_WH_SALE_RTN;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_TR_WH_SALE_RTN)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_TR_WH_SALE_RTN);
				}
			}
		}

		public UT_AI_TRFR UT_AI_TRFR
		{
			[DebuggerHidden]
			get
			{
				m_UT_AI_TRFR = Create__Instance__(m_UT_AI_TRFR);
				return m_UT_AI_TRFR;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_AI_TRFR)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_AI_TRFR);
				}
			}
		}

		public UT_BANK UT_BANK
		{
			[DebuggerHidden]
			get
			{
				m_UT_BANK = Create__Instance__(m_UT_BANK);
				return m_UT_BANK;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_BANK)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_BANK);
				}
			}
		}

		public UT_BKP UT_BKP
		{
			[DebuggerHidden]
			get
			{
				m_UT_BKP = Create__Instance__(m_UT_BKP);
				return m_UT_BKP;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_BKP)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_BKP);
				}
			}
		}

		public UT_CUST_ENTRY UT_CUST_ENTRY
		{
			[DebuggerHidden]
			get
			{
				m_UT_CUST_ENTRY = Create__Instance__(m_UT_CUST_ENTRY);
				return m_UT_CUST_ENTRY;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_CUST_ENTRY)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_CUST_ENTRY);
				}
			}
		}

		public UT_E_INVOICE UT_E_INVOICE
		{
			[DebuggerHidden]
			get
			{
				m_UT_E_INVOICE = Create__Instance__(m_UT_E_INVOICE);
				return m_UT_E_INVOICE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_E_INVOICE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_E_INVOICE);
				}
			}
		}

		public UT_EXPORT UT_EXPORT
		{
			[DebuggerHidden]
			get
			{
				m_UT_EXPORT = Create__Instance__(m_UT_EXPORT);
				return m_UT_EXPORT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_EXPORT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_EXPORT);
				}
			}
		}

		public UT_HDD UT_HDD
		{
			[DebuggerHidden]
			get
			{
				m_UT_HDD = Create__Instance__(m_UT_HDD);
				return m_UT_HDD;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_HDD)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_HDD);
				}
			}
		}

		public UT_IMPORT UT_IMPORT
		{
			[DebuggerHidden]
			get
			{
				m_UT_IMPORT = Create__Instance__(m_UT_IMPORT);
				return m_UT_IMPORT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_IMPORT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_IMPORT);
				}
			}
		}

		public UT_PWD_UPDATE UT_PWD_UPDATE
		{
			[DebuggerHidden]
			get
			{
				m_UT_PWD_UPDATE = Create__Instance__(m_UT_PWD_UPDATE);
				return m_UT_PWD_UPDATE;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_PWD_UPDATE)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_PWD_UPDATE);
				}
			}
		}

		public UT_REMINDER UT_REMINDER
		{
			[DebuggerHidden]
			get
			{
				m_UT_REMINDER = Create__Instance__(m_UT_REMINDER);
				return m_UT_REMINDER;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_REMINDER)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_REMINDER);
				}
			}
		}

		public UT_REPORT UT_REPORT
		{
			[DebuggerHidden]
			get
			{
				m_UT_REPORT = Create__Instance__(m_UT_REPORT);
				return m_UT_REPORT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_REPORT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_REPORT);
				}
			}
		}

		public UT_SET_ADMIN UT_SET_ADMIN
		{
			[DebuggerHidden]
			get
			{
				m_UT_SET_ADMIN = Create__Instance__(m_UT_SET_ADMIN);
				return m_UT_SET_ADMIN;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_SET_ADMIN)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_SET_ADMIN);
				}
			}
		}

		public UT_SETTING UT_SETTING
		{
			[DebuggerHidden]
			get
			{
				m_UT_SETTING = Create__Instance__(m_UT_SETTING);
				return m_UT_SETTING;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_SETTING)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_SETTING);
				}
			}
		}

		public UT_SETTING_MAIN UT_SETTING_MAIN
		{
			[DebuggerHidden]
			get
			{
				m_UT_SETTING_MAIN = Create__Instance__(m_UT_SETTING_MAIN);
				return m_UT_SETTING_MAIN;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_SETTING_MAIN)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_SETTING_MAIN);
				}
			}
		}

		public UT_SMS UT_SMS
		{
			[DebuggerHidden]
			get
			{
				m_UT_SMS = Create__Instance__(m_UT_SMS);
				return m_UT_SMS;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_SMS)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_SMS);
				}
			}
		}

		public UT_TAG_PRINT UT_TAG_PRINT
		{
			[DebuggerHidden]
			get
			{
				m_UT_TAG_PRINT = Create__Instance__(m_UT_TAG_PRINT);
				return m_UT_TAG_PRINT;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_TAG_PRINT)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_TAG_PRINT);
				}
			}
		}

		public UT_USER_REQUEST UT_USER_REQUEST
		{
			[DebuggerHidden]
			get
			{
				m_UT_USER_REQUEST = Create__Instance__(m_UT_USER_REQUEST);
				return m_UT_USER_REQUEST;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_USER_REQUEST)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_USER_REQUEST);
				}
			}
		}

		public UT_VCH_RE_NUMBR UT_VCH_RE_NUMBR
		{
			[DebuggerHidden]
			get
			{
				m_UT_VCH_RE_NUMBR = Create__Instance__(m_UT_VCH_RE_NUMBR);
				return m_UT_VCH_RE_NUMBR;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_VCH_RE_NUMBR)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_VCH_RE_NUMBR);
				}
			}
		}

		public UT_WAPP_WITH_API UT_WAPP_WITH_API
		{
			[DebuggerHidden]
			get
			{
				m_UT_WAPP_WITH_API = Create__Instance__(m_UT_WAPP_WITH_API);
				return m_UT_WAPP_WITH_API;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_WAPP_WITH_API)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_WAPP_WITH_API);
				}
			}
		}

		public UT_WEB_CAM UT_WEB_CAM
		{
			[DebuggerHidden]
			get
			{
				m_UT_WEB_CAM = Create__Instance__(m_UT_WEB_CAM);
				return m_UT_WEB_CAM;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_WEB_CAM)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_WEB_CAM);
				}
			}
		}

		public UT_WHATSAPP UT_WHATSAPP
		{
			[DebuggerHidden]
			get
			{
				m_UT_WHATSAPP = Create__Instance__(m_UT_WHATSAPP);
				return m_UT_WHATSAPP;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_WHATSAPP)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_WHATSAPP);
				}
			}
		}

		public UT_WINDOW UT_WINDOW
		{
			[DebuggerHidden]
			get
			{
				m_UT_WINDOW = Create__Instance__(m_UT_WINDOW);
				return m_UT_WINDOW;
			}
			[DebuggerHidden]
			set
			{
				if (value != m_UT_WINDOW)
				{
					if (value != null)
					{
						throw new ArgumentException("Property can only be set to Nothing");
					}
					Dispose__Instance__(ref m_UT_WINDOW);
				}
			}
		}

		[DebuggerHidden]
		private static T Create__Instance__<T>(T Instance) where T : Form, new()
		{
			if (Instance == null || ((Control)Instance).IsDisposed)
			{
				if (m_FormBeingCreated != null)
				{
					if (m_FormBeingCreated.ContainsKey(typeof(T)))
					{
						throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate", new string[0]));
					}
				}
				else
				{
					m_FormBeingCreated = new Hashtable();
				}
				m_FormBeingCreated.Add(typeof(T), null);
				try
				{
					return new T();
				}
				catch (TargetInvocationException ex) when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					ProjectData.SetProjectError((Exception)ex);
					return ex.InnerException != null;
				}).Invoke())
				{
					string resourceString = Utils.GetResourceString("WinForms_SeeInnerException", new string[1] { ex.InnerException.Message });
					throw new InvalidOperationException(resourceString, ex.InnerException);
				}
				finally
				{
					m_FormBeingCreated.Remove(typeof(T));
				}
			}
			return Instance;
		}

		[DebuggerHidden]
		private void Dispose__Instance__<T>(ref T instance) where T : Form
		{
			((Component)instance/*cast due to constrained. prefix*/).Dispose();
			instance = default(T);
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public MyForms()
		{
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object o)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(o));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal new Type GetType()
		{
			return typeof(MyForms);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
	internal sealed class MyWebServices
	{
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override bool Equals(object o)
		{
			return base.Equals(RuntimeHelpers.GetObjectValue(o));
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		internal new Type GetType()
		{
			return typeof(MyWebServices);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerHidden]
		public override string ToString()
		{
			return base.ToString();
		}

		[DebuggerHidden]
		private static T Create__Instance__<T>(T instance) where T : new()
		{
			if (instance == null)
			{
				return new T();
			}
			return instance;
		}

		[DebuggerHidden]
		private void Dispose__Instance__<T>(ref T instance)
		{
			instance = default(T);
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public MyWebServices()
		{
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	[ComVisible(false)]
	internal sealed class ThreadSafeObjectProvider<T> where T : new()
	{
		[CompilerGenerated]
		[ThreadStatic]
		private static T m_ThreadStaticValue;

		internal T GetInstance
		{
			[DebuggerHidden]
			get
			{
				if (m_ThreadStaticValue == null)
				{
					m_ThreadStaticValue = new T();
				}
				return m_ThreadStaticValue;
			}
		}

		[DebuggerHidden]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ThreadSafeObjectProvider()
		{
		}
	}

	private static readonly ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new ThreadSafeObjectProvider<MyComputer>();

	private static readonly ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new ThreadSafeObjectProvider<MyApplication>();

	private static readonly ThreadSafeObjectProvider<User> m_UserObjectProvider = new ThreadSafeObjectProvider<User>();

	private static ThreadSafeObjectProvider<MyForms> m_MyFormsObjectProvider = new ThreadSafeObjectProvider<MyForms>();

	private static readonly ThreadSafeObjectProvider<MyWebServices> m_MyWebServicesObjectProvider = new ThreadSafeObjectProvider<MyWebServices>();

	[HelpKeyword("My.Computer")]
	internal static MyComputer Computer
	{
		[DebuggerHidden]
		get
		{
			return m_ComputerObjectProvider.GetInstance;
		}
	}

	[HelpKeyword("My.Application")]
	internal static MyApplication Application
	{
		[DebuggerHidden]
		get
		{
			return m_AppObjectProvider.GetInstance;
		}
	}

	[HelpKeyword("My.User")]
	internal static User User
	{
		[DebuggerHidden]
		get
		{
			return m_UserObjectProvider.GetInstance;
		}
	}

	[HelpKeyword("My.Forms")]
	internal static MyForms Forms
	{
		[DebuggerHidden]
		get
		{
			return m_MyFormsObjectProvider.GetInstance;
		}
	}

	[HelpKeyword("My.WebServices")]
	internal static MyWebServices WebServices
	{
		[DebuggerHidden]
		get
		{
			return m_MyWebServicesObjectProvider.GetInstance;
		}
	}
}
