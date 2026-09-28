using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxCrystal;
using AxMSFlexGridLib;
using Crystal;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevNet.Models;
using MSFlexGridLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class TR_MEMB_ENT : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblBook")]
	private Label _lblBook;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mVchDate")]
	private MaskedTextBox _mVchDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tVchNo")]
	private TextBox _tVchNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPrint")]
	private SimpleButton _BtnPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSave")]
	private SimpleButton _BtnSave;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnCancel")]
	private SimpleButton _BtnCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDelete")]
	private SimpleButton _BtnDelete;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExit")]
	private SimpleButton _BtnExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG")]
	private AxMSFlexGrid _MSG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ENTRY")]
	private TextBox _TEXT_ENTRY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnFirst")]
	private SimpleButton _BtnFirst;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnLast")]
	private SimpleButton _BtnLast;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnF1")]
	private SimpleButton _BtnF1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmpCode")]
	private TextBox _tEmpCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSchmCode")]
	private TextBox _tSchmCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankName")]
	private TextBox _tBankName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tChqNo")]
	private TextBox _tChqNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tVchDesc")]
	private TextBox _tVchDesc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tQrCane")]
	private TextBox _tQrCane;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPassBook")]
	private SimpleButton _BtnPassBook;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_UPI")]
	private AxMSFlexGrid _MSG_UPI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_UPI")]
	private TextBox _TEXT_UPI;

	private Module_WhatsApp whatsApp;

	private string UsUPdate;

	private string UsDelete;

	private string DataTrfr;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private DataTable VchOldData;

	private bool UpiTypeAdd;

	private int FilRowPr;

	private DataTable DtIdtlPr;

	private DataRow drPr;

	private int MsgOldRowPr;

	private bool MsgClearPr;

	private double CustOpAmt;

	private double CustClAmt;

	private string PartyAcCode;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private double OldValTot;

	private double NewValTot;

	private string CurTagNo;

	private string MsVchSrno;

	private int CurTotInstallment;

	private DataTable RsData;

	private DataTable RsDetl;

	private DataTable RsIdtl;

	private int FilRow;

	private DataTable DtIdtl;

	private DataRow dr;

	private bool Msgleft;

	private bool UpDown;

	private bool MsTxtDelete;

	private int MsgOldRow;

	private bool MsgIdtlLeft;

	private string FormBook;

	private string FormName;

	private string FormBookType;

	private string FormItmType;

	private string FormVchNo;

	private string FormMainBook;

	private string FormBookSname;

	private string FormBookInOut;

	private double ToDayGlRate;

	private string MaxVchNo;

	private string LastVchNo;

	private const int cSrNo = 0;

	private const int cMembCode = 1;

	private const int cMembName = 2;

	private const int cRecDate = 3;

	private const int cWithUpi = 4;

	private const int cRecAc = 5;

	private const int cRate = 6;

	private const int cGrWt = 7;

	private const int cAmount = 8;

	private const int cEntryMod = 9;

	private const int cChqNo = 10;

	private const int cBankName = 11;

	private const int cMobileNo = 12;

	private const int cMembAmt = 13;

	private const int cUpiName = 14;

	private const int cSrNo1 = 0;

	private const int cVchNo1 = 1;

	private const int cVchDate1 = 2;

	private const int cMbMonth1 = 3;

	private const int cMbSchmAmt1 = 4;

	private const int cUpSrNo = 0;

	private const int cUpAcCode = 1;

	private const int cUpAcName = 2;

	private const int cUpUpiType = 3;

	private const int cUpUpiId = 4;

	private const int cUpUpiAmt = 5;

	private const int cUpRowSr = 6;

	private const int cUpMembCode = 7;

	internal virtual Label lblBook
	{
		[CompilerGenerated]
		get
		{
			return _lblBook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = lblBook_DoubleClick;
			Label val = _lblBook;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_lblBook = value;
			val = _lblBook;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual MaskedTextBox mVchDate
	{
		[CompilerGenerated]
		get
		{
			return _mVchDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = mVchDate_GotFocus;
			KeyEventHandler val = new KeyEventHandler(mVchDate_KeyDown);
			MaskedTextBox val2 = _mVchDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_mVchDate = value;
			val2 = _mVchDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus += eventHandler;
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

	internal virtual TextBox tVchNo
	{
		[CompilerGenerated]
		get
		{
			return _tVchNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			EventHandler eventHandler = tVchNo_DoubleClick;
			EventHandler eventHandler2 = TVchNo_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tVchNo_KeyDown);
			TextBox val2 = _tVchNo;
			if (val2 != null)
			{
				((Control)val2).DoubleClick -= eventHandler;
				((Control)val2).TextChanged -= eventHandler2;
				((Control)val2).KeyDown -= val;
			}
			_tVchNo = value;
			val2 = _tVchNo;
			if (val2 != null)
			{
				((Control)val2).DoubleClick += eventHandler;
				((Control)val2).TextChanged += eventHandler2;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mDay")]
	private virtual TextBox _mDay;

	internal virtual TextBox mDay
	{
		get
		{
			return _mDay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_mDay = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mTime")]
	private virtual TextBox _mTime;

	internal virtual TextBox mTime
	{
		get
		{
			return _mTime;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_mTime = value;
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
			EventHandler eventHandler2 = MSG_EnterCell;
			EventHandler eventHandler3 = MSG_LeaveCell;
			EventHandler eventHandler4 = MSG_RowColChange;
			EventHandler eventHandler5 = MSG_Scroll;
			AxMSFlexGrid val = _MSG;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
				val.RowColChange -= eventHandler4;
				val.Scroll -= eventHandler5;
			}
			_MSG = value;
			val = _MSG;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
				val.RowColChange += eventHandler4;
				val.Scroll += eventHandler5;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_TOT")]
	private virtual AxMSFlexGrid _MSG_TOT;

	internal virtual AxMSFlexGrid MSG_TOT
	{
		get
		{
			return _MSG_TOT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_MSG_TOT = value;
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_ENTRY_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_ENTRY_KeyDown);
			KeyEventHandler val2 = new KeyEventHandler(TEXT_ENTRY_KeyUp);
			TextBox val3 = _TEXT_ENTRY;
			if (val3 != null)
			{
				((Control)val3).TextChanged -= eventHandler;
				((Control)val3).KeyDown -= val;
				((Control)val3).KeyUp -= val2;
			}
			_TEXT_ENTRY = value;
			val3 = _TEXT_ENTRY;
			if (val3 != null)
			{
				((Control)val3).TextChanged += eventHandler;
				((Control)val3).KeyDown += val;
				((Control)val3).KeyUp += val2;
			}
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FlowLayoutPanel1")]
	private virtual FlowLayoutPanel _FlowLayoutPanel1;

	internal virtual FlowLayoutPanel FlowLayoutPanel1
	{
		get
		{
			return _FlowLayoutPanel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_FlowLayoutPanel1 = value;
		}
	}

	internal virtual SimpleButton BtnFirst
	{
		[CompilerGenerated]
		get
		{
			return _BtnFirst;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnFirst_Click;
			SimpleButton val = _BtnFirst;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnFirst = value;
			val = _BtnFirst;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnLast
	{
		[CompilerGenerated]
		get
		{
			return _BtnLast;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnLast_Click;
			SimpleButton val = _BtnLast;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnLast = value;
			val = _BtnLast;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
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
	[AccessedThroughProperty("tHdVchNo")]
	private virtual TextBox _tHdVchNo;

	internal virtual TextBox tHdVchNo
	{
		get
		{
			return _tHdVchNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tHdVchNo = value;
		}
	}

	internal virtual TextBox tEmpCode
	{
		[CompilerGenerated]
		get
		{
			return _tEmpCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tEmpCode_KeyDown);
			TextBox val2 = _tEmpCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tEmpCode = value;
			val2 = _tEmpCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmpName")]
	private virtual TextBox _tEmpName;

	internal virtual TextBox tEmpName
	{
		get
		{
			return _tEmpName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tEmpName = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSchmName")]
	private virtual TextBox _tSchmName;

	internal virtual TextBox tSchmName
	{
		get
		{
			return _tSchmName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tSchmName = value;
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

	internal virtual TextBox tSchmCode
	{
		[CompilerGenerated]
		get
		{
			return _tSchmCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tSchmCode_KeyDown);
			EventHandler eventHandler = tSchmCode_TextChanged;
			TextBox val2 = _tSchmCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tSchmCode = value;
			val2 = _tSchmCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nMembAmt")]
	private virtual TextBox _nMembAmt;

	internal virtual TextBox nMembAmt
	{
		get
		{
			return _nMembAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nMembAmt = value;
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

	internal virtual TextBox tChqNo
	{
		[CompilerGenerated]
		get
		{
			return _tChqNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tChqNo_KeyDown);
			TextBox val2 = _tChqNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tChqNo = value;
			val2 = _tChqNo;
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

	internal virtual TextBox tVchDesc
	{
		[CompilerGenerated]
		get
		{
			return _tVchDesc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tVchDesc_KeyDown);
			EventHandler eventHandler = tVchDesc_DoubleClick;
			TextBox val2 = _tVchDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_tVchDesc = value;
			val2 = _tVchDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).DoubleClick += eventHandler;
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
	[AccessedThroughProperty("lbrMsgShow")]
	private virtual Label _lbrMsgShow;

	internal virtual Label lbrMsgShow
	{
		get
		{
			return _lbrMsgShow;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lbrMsgShow = value;
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

	internal virtual TextBox tQrCane
	{
		[CompilerGenerated]
		get
		{
			return _tQrCane;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = TQrCane_TextChanged;
			TextBox val = _tQrCane;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
			}
			_tQrCane = value;
			val = _tQrCane;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSchmType")]
	private virtual TextBox _tSchmType;

	internal virtual TextBox tSchmType
	{
		get
		{
			return _tSchmType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tSchmType = value;
		}
	}

	internal virtual SimpleButton BtnPassBook
	{
		[CompilerGenerated]
		get
		{
			return _BtnPassBook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnPassBook_Click;
			SimpleButton val = _BtnPassBook;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnPassBook = value;
			val = _BtnPassBook;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nLineSkip")]
	private virtual TextBox _nLineSkip;

	internal virtual TextBox nLineSkip
	{
		get
		{
			return _nLineSkip;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nLineSkip = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblLineSkip")]
	private virtual Label _lblLineSkip;

	internal virtual Label lblLineSkip
	{
		get
		{
			return _lblLineSkip;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblLineSkip = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkWapp")]
	private virtual CheckBox _chkWapp;

	internal virtual CheckBox chkWapp
	{
		get
		{
			return _chkWapp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkWapp = value;
		}
	}

	internal virtual AxMSFlexGrid MSG_UPI
	{
		[CompilerGenerated]
		get
		{
			return _MSG_UPI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_UPI_ClickEvent;
			EventHandler eventHandler2 = MSG_UPI_EnterCell;
			EventHandler eventHandler3 = MSG_UPI_LeaveCell;
			AxMSFlexGrid val = _MSG_UPI;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG_UPI = value;
			val = _MSG_UPI;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
			}
		}
	}

	internal virtual TextBox TEXT_UPI
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_UPI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_UPI_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_UPI_KeyDown);
			TextBox val2 = _TEXT_UPI;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_UPI = value;
			val2 = _TEXT_UPI;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nSchmAmt")]
	private virtual TextBox _nSchmAmt;

	internal virtual TextBox nSchmAmt
	{
		get
		{
			return _nSchmAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nSchmAmt = value;
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

	public TR_MEMB_ENT()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_MEMB_ENT_Load;
		((Form)this).Deactivate += TR_MEMB_ENT_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_MEMB_ENT_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_MEMB_ENT_KeyDown);
		((Form)this).Activated += TR_MEMB_ENT_Activated;
		((Form)this).Closed += TR_MEMB_ENT_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_MEMB_ENT_KeyUp);
		whatsApp = UT_WHATSAPP.whatsApp;
		DtIdtlPr = new DataTable();
		drPr = DtIdtlPr.NewRow();
		DtIdtl = new DataTable();
		dr = DtIdtl.NewRow();
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
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected O, but got Unknown
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Expected O, but got Unknown
		//IL_0474: Unknown result type (might be due to invalid IL or missing references)
		//IL_047e: Expected O, but got Unknown
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0525: Expected O, but got Unknown
		//IL_05d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05da: Expected O, but got Unknown
		//IL_065e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0668: Expected O, but got Unknown
		//IL_0700: Unknown result type (might be due to invalid IL or missing references)
		//IL_070a: Expected O, but got Unknown
		//IL_0799: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a3: Expected O, but got Unknown
		//IL_0806: Unknown result type (might be due to invalid IL or missing references)
		//IL_0810: Expected O, but got Unknown
		//IL_08b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c3: Expected O, but got Unknown
		//IL_0926: Unknown result type (might be due to invalid IL or missing references)
		//IL_0930: Expected O, but got Unknown
		//IL_09d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e3: Expected O, but got Unknown
		//IL_0b00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0a: Expected O, but got Unknown
		//IL_0c15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1f: Expected O, but got Unknown
		//IL_0c82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8c: Expected O, but got Unknown
		//IL_0e35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e98: Expected O, but got Unknown
		//IL_0efb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f05: Expected O, but got Unknown
		//IL_105b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1065: Expected O, but got Unknown
		//IL_10f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fd: Expected O, but got Unknown
		//IL_11ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b7: Expected O, but got Unknown
		//IL_1267: Unknown result type (might be due to invalid IL or missing references)
		//IL_1271: Expected O, but got Unknown
		//IL_1369: Unknown result type (might be due to invalid IL or missing references)
		//IL_1373: Expected O, but got Unknown
		//IL_1484: Unknown result type (might be due to invalid IL or missing references)
		//IL_148e: Expected O, but got Unknown
		//IL_1550: Unknown result type (might be due to invalid IL or missing references)
		//IL_155a: Expected O, but got Unknown
		//IL_1632: Unknown result type (might be due to invalid IL or missing references)
		//IL_163c: Expected O, but got Unknown
		//IL_16d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e2: Expected O, but got Unknown
		//IL_181d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1827: Expected O, but got Unknown
		//IL_188b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1895: Expected O, but got Unknown
		//IL_1935: Unknown result type (might be due to invalid IL or missing references)
		//IL_193f: Expected O, but got Unknown
		//IL_19bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c6: Expected O, but got Unknown
		//IL_1a4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a58: Expected O, but got Unknown
		//IL_1b06: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b10: Expected O, but got Unknown
		//IL_1b81: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b8b: Expected O, but got Unknown
		//IL_1c35: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c3f: Expected O, but got Unknown
		//IL_1cb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cc0: Expected O, but got Unknown
		//IL_1d48: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d52: Expected O, but got Unknown
		//IL_1e00: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e0a: Expected O, but got Unknown
		//IL_1e92: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e9c: Expected O, but got Unknown
		//IL_1f4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f54: Expected O, but got Unknown
		//IL_1fdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fe6: Expected O, but got Unknown
		//IL_20b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_20c1: Expected O, but got Unknown
		//IL_2156: Unknown result type (might be due to invalid IL or missing references)
		//IL_2160: Expected O, but got Unknown
		//IL_21de: Unknown result type (might be due to invalid IL or missing references)
		//IL_21e8: Expected O, but got Unknown
		//IL_22cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_22d7: Expected O, but got Unknown
		//IL_2340: Unknown result type (might be due to invalid IL or missing references)
		//IL_234a: Expected O, but got Unknown
		//IL_23ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_23f7: Expected O, but got Unknown
		//IL_247b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2485: Expected O, but got Unknown
		//IL_2536: Unknown result type (might be due to invalid IL or missing references)
		//IL_2540: Expected O, but got Unknown
		//IL_25ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_25f7: Expected O, but got Unknown
		//IL_26b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_26bc: Expected O, but got Unknown
		//IL_2747: Unknown result type (might be due to invalid IL or missing references)
		//IL_2751: Expected O, but got Unknown
		//IL_27fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2804: Expected O, but got Unknown
		//IL_28af: Unknown result type (might be due to invalid IL or missing references)
		//IL_28b9: Expected O, but got Unknown
		//IL_291d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2927: Expected O, but got Unknown
		//IL_2988: Unknown result type (might be due to invalid IL or missing references)
		//IL_2992: Expected O, but got Unknown
		//IL_29e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_29ea: Expected O, but got Unknown
		//IL_2a72: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a7c: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_MEMB_ENT));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		lblBook = new Label();
		mVchDate = new MaskedTextBox();
		lblBDate = new Label();
		Label2 = new Label();
		tVchNo = new TextBox();
		mDay = new TextBox();
		mTime = new TextBox();
		BtnPrint = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnExit = new SimpleButton();
		PnlBotam = new FlowLayoutPanel();
		BtnPassBook = new SimpleButton();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		nLineSkip = new TextBox();
		lblLineSkip = new Label();
		chkWapp = new CheckBox();
		BtnLast = new SimpleButton();
		BtnFirst = new SimpleButton();
		TEXT_ENTRY = new TextBox();
		DlgOpen = new OpenFileDialog();
		BtnF1 = new SimpleButton();
		Cr = new AxCrystalReport();
		tHdVchNo = new TextBox();
		tEmpCode = new TextBox();
		tEmpName = new TextBox();
		Label3 = new Label();
		tSchmName = new TextBox();
		Label15 = new Label();
		tSchmCode = new TextBox();
		nMembAmt = new TextBox();
		Label9 = new Label();
		tBankName = new TextBox();
		Label1 = new Label();
		tChqNo = new TextBox();
		Label4 = new Label();
		DGV = new DevComponents.DotNetBar.Controls.DataGridViewX();
		tVchDesc = new TextBox();
		Label5 = new Label();
		lbrMsgShow = new Label();
		Label6 = new Label();
		tQrCane = new TextBox();
		tSchmType = new TextBox();
		TEXT_UPI = new TextBox();
		MSG_UPI = new AxMSFlexGrid();
		MSG_TOT = new AxMSFlexGrid();
		MSG = new AxMSFlexGrid();
		nSchmAmt = new TextBox();
		Label7 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
		((ISupportInitialize)MSG_UPI).BeginInit();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
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
		((Control)lblBook).TabIndex = 6;
		lblBook.Text = "Memb Entry";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mVchDate).Location = new Point(297, 52);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 22);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(227, 53);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)16;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(27, 52);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(68, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tVchNo).Location = new Point(104, 52);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 22);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mDay).Location = new Point(458, 52);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 22);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mTime).Location = new Point(378, 52);
		((TextBoxBase)mTime).MaxLength = 8;
		((Control)mTime).Name = "mTime";
		((TextBoxBase)mTime).ReadOnly = true;
		((Control)mTime).Size = new Size(75, 22);
		((Control)mTime).TabIndex = 1132;
		mTime.TextAlign = (HorizontalAlignment)2;
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
		((Control)BtnPrint).TabIndex = 1;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
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
		((Control)BtnSave).TabIndex = 0;
		BtnSave.Text = "&Save";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
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
		((Control)BtnCancel).TabIndex = 2;
		BtnCancel.Text = "&Cancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
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
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPassBook);
		((Control)PnlBotam).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnLast);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnFirst);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 6;
		((BaseStyleControl)BtnPassBook).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnPassBook).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPassBook).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPassBook).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPassBook.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPassBook.ImageOptions.SvgImage");
		((Control)BtnPassBook).Location = new Point(730, 3);
		((BaseControl)BtnPassBook).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPassBook).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPassBook).Name = "BtnPassBook";
		((Control)BtnPassBook).Size = new Size(91, 37);
		((Control)BtnPassBook).TabIndex = 28;
		BtnPassBook.Text = "&PbPrint";
		((BaseButton)BtnPassBook).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)nLineSkip);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)lblLineSkip);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkWapp);
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(249, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(475, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((TextBoxBase)nLineSkip).BackColor = Color.White;
		((Control)nLineSkip).Font = new Font("Arial", 12.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nLineSkip).Location = new Point(433, 3);
		((TextBoxBase)nLineSkip).MaxLength = 15;
		((Control)nLineSkip).Name = "nLineSkip";
		((Control)nLineSkip).Size = new Size(39, 27);
		((Control)nLineSkip).TabIndex = 1167;
		nLineSkip.TextAlign = (HorizontalAlignment)2;
		((Control)lblLineSkip).BackColor = Color.Transparent;
		((Control)lblLineSkip).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblLineSkip).ForeColor = Color.Black;
		lblLineSkip.ImeMode = (ImeMode)0;
		((Control)lblLineSkip).Location = new Point(347, 0);
		((Control)lblLineSkip).Name = "lblLineSkip";
		((Control)lblLineSkip).Size = new Size(80, 31);
		((Control)lblLineSkip).TabIndex = 1168;
		lblLineSkip.Text = "Line Skip";
		lblLineSkip.TextAlign = (ContentAlignment)64;
		((ButtonBase)chkWapp).BackColor = Color.Transparent;
		((Control)chkWapp).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkWapp).ForeColor = Color.Black;
		((Control)chkWapp).Location = new Point(222, 3);
		((Control)chkWapp).Name = "chkWapp";
		((Control)chkWapp).RightToLeft = (RightToLeft)0;
		((Control)chkWapp).Size = new Size(119, 27);
		((Control)chkWapp).TabIndex = 1169;
		((ButtonBase)chkWapp).Text = "Whatsapp";
		((ButtonBase)chkWapp).UseVisualStyleBackColor = false;
		((Control)chkWapp).Visible = false;
		((BaseStyleControl)BtnLast).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnLast).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnLast).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnLast).Appearance.Options.UseForeColor = true;
		((Control)BtnLast).Location = new Point(202, 3);
		((BaseControl)BtnLast).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnLast).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnLast).Name = "BtnLast";
		((Control)BtnLast).Size = new Size(41, 37);
		((Control)BtnLast).TabIndex = 5;
		BtnLast.Text = ">";
		((BaseButton)BtnLast).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnFirst).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnFirst).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnFirst).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnFirst).Appearance.Options.UseForeColor = true;
		((Control)BtnFirst).Location = new Point(155, 3);
		((BaseControl)BtnFirst).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnFirst).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnFirst).Name = "BtnFirst";
		((Control)BtnFirst).Size = new Size(41, 37);
		((Control)BtnFirst).TabIndex = 6;
		BtnFirst.Text = "<";
		((BaseButton)BtnFirst).ToolTipAnchor = (ToolTipAnchor)1;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(471, 217);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 3;
		((Control)TEXT_ENTRY).Visible = false;
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((BaseStyleControl)BtnF1).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnF1).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnF1).Appearance.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnF1).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnF1).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnF1).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnF1).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnF1).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnF1).AppearanceHovered.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnF1).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnF1).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnF1).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnF1).AppearancePressed.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnF1).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseFont = true;
		((Control)BtnF1).Location = new Point(186, 51);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(35, 23);
		((Control)BtnF1).TabIndex = 1149;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Voucher Help";
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1203, 471);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 1155;
		((TextBoxBase)tHdVchNo).BackColor = Color.FromArgb(255, 224, 192);
		((TextBoxBase)tHdVchNo).BorderStyle = (BorderStyle)0;
		((Control)tHdVchNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((TextBoxBase)tHdVchNo).ForeColor = Color.Maroon;
		((Control)tHdVchNo).Location = new Point(8, 8);
		((TextBoxBase)tHdVchNo).MaxLength = 8;
		((Control)tHdVchNo).Name = "tHdVchNo";
		((TextBoxBase)tHdVchNo).ReadOnly = true;
		((Control)tHdVchNo).Size = new Size(56, 15);
		((Control)tHdVchNo).TabIndex = 7;
		((Control)tHdVchNo).Visible = false;
		((TextBoxBase)tEmpCode).BackColor = Color.White;
		((Control)tEmpCode).Font = new Font("Tahoma", 9f);
		((Control)tEmpCode).Location = new Point(183, 505);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(57, 22);
		((Control)tEmpCode).TabIndex = 4;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tEmpName).Location = new Point(246, 505);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(249, 22);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(101, 505);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tSchmName).BackColor = Color.PapayaWhip;
		((Control)tSchmName).Font = new Font("Tahoma", 9f);
		((Control)tSchmName).Location = new Point(185, 86);
		((TextBoxBase)tSchmName).MaxLength = 40;
		((Control)tSchmName).Name = "tSchmName";
		((Control)tSchmName).Size = new Size(356, 22);
		((Control)tSchmName).TabIndex = 1211;
		((Control)Label15).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(3, 86);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(92, 20);
		((Control)Label15).TabIndex = 1210;
		Label15.Text = "Schm Code";
		Label15.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tSchmCode).BackColor = Color.White;
		((Control)tSchmCode).Font = new Font("Tahoma", 9f);
		((Control)tSchmCode).Location = new Point(104, 86);
		((TextBoxBase)tSchmCode).MaxLength = 5;
		((Control)tSchmCode).Name = "tSchmCode";
		((Control)tSchmCode).Size = new Size(75, 22);
		((Control)tSchmCode).TabIndex = 2;
		((TextBoxBase)nMembAmt).BackColor = Color.White;
		((Control)nMembAmt).Font = new Font("Tahoma", 9f);
		((Control)nMembAmt).Location = new Point(864, 87);
		((TextBoxBase)nMembAmt).MaxLength = 10;
		((Control)nMembAmt).Name = "nMembAmt";
		((TextBoxBase)nMembAmt).ReadOnly = true;
		((Control)nMembAmt).Size = new Size(88, 22);
		((Control)nMembAmt).TabIndex = 1212;
		nMembAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(549, 89);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(77, 20);
		((Control)Label9).TabIndex = 1213;
		Label9.Text = "Schm Amt";
		Label9.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tBankName).BackColor = Color.White;
		((Control)tBankName).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tBankName).Location = new Point(183, 355);
		((TextBoxBase)tBankName).MaxLength = 50;
		((Control)tBankName).Name = "tBankName";
		((Control)tBankName).Size = new Size(312, 22);
		((Control)tBankName).TabIndex = 1215;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(101, 355);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(78, 20);
		((Control)Label1).TabIndex = 1214;
		Label1.Text = "Bank Name";
		Label1.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tChqNo).BackColor = Color.White;
		((Control)tChqNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tChqNo).Location = new Point(572, 355);
		((TextBoxBase)tChqNo).MaxLength = 50;
		((Control)tChqNo).Name = "tChqNo";
		((Control)tChqNo).Size = new Size(159, 22);
		((Control)tChqNo).TabIndex = 1217;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(505, 355);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(61, 20);
		((Control)Label4).TabIndex = 1216;
		Label4.Text = "Chq No";
		Label4.TextAlign = (ContentAlignment)16;
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV).BackgroundColor = Color.Snow;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV).ColumnHeadersHeight = 30;
		((DataGridView)DGV).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).DefaultCellStyle = val3;
		((DataGridView)DGV).EnableHeadersVisualStyles = false;
		((DataGridView)DGV).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV).Location = new Point(841, 121);
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
		((DataGridView)DGV).ReadOnly = true;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV).RowHeadersVisible = false;
		((DataGridView)DGV).RowHeadersWidth = 20;
		val5.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val5;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV).Size = new Size(325, 378);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 1218;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tVchDesc).Location = new Point(183, 534);
		((TextBoxBase)tVchDesc).MaxLength = 50;
		((Control)tVchDesc).Name = "tVchDesc";
		((Control)tVchDesc).Size = new Size(548, 22);
		((Control)tVchDesc).TabIndex = 5;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(101, 534);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(78, 20);
		((Control)Label5).TabIndex = 1219;
		Label5.Text = "Vch Desc";
		Label5.TextAlign = (ContentAlignment)16;
		((Control)lbrMsgShow).BackColor = Color.Transparent;
		((Control)lbrMsgShow).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lbrMsgShow).ForeColor = Color.Black;
		lbrMsgShow.ImeMode = (ImeMode)0;
		((Control)lbrMsgShow).Location = new Point(841, 525);
		((Control)lbrMsgShow).Name = "lbrMsgShow";
		((Control)lbrMsgShow).Size = new Size(125, 20);
		((Control)lbrMsgShow).TabIndex = 1220;
		lbrMsgShow.Text = "Whatsapp Msg";
		lbrMsgShow.TextAlign = (ContentAlignment)64;
		((Control)lbrMsgShow).Visible = false;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(555, 53);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(73, 20);
		((Control)Label6).TabIndex = 1222;
		Label6.Text = "Qr Scene";
		Label6.TextAlign = (ContentAlignment)64;
		((Control)Label6).Visible = false;
		((TextBoxBase)tQrCane).BackColor = Color.White;
		((Control)tQrCane).Font = new Font("Tahoma", 9f);
		((Control)tQrCane).Location = new Point(634, 53);
		((TextBoxBase)tQrCane).MaxLength = 8;
		((Control)tQrCane).Name = "tQrCane";
		((Control)tQrCane).Size = new Size(88, 22);
		((Control)tQrCane).TabIndex = 1221;
		((Control)tQrCane).Visible = false;
		((TextBoxBase)tSchmType).BackColor = Color.White;
		((Control)tSchmType).Font = new Font("Tahoma", 9f);
		((Control)tSchmType).Location = new Point(728, 87);
		((TextBoxBase)tSchmType).MaxLength = 10;
		((Control)tSchmType).Name = "tSchmType";
		((TextBoxBase)tSchmType).ReadOnly = true;
		((Control)tSchmType).Size = new Size(33, 22);
		((Control)tSchmType).TabIndex = 1223;
		tSchmType.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)TEXT_UPI).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_UPI).BorderStyle = (BorderStyle)0;
		((Control)TEXT_UPI).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_UPI).ForeColor = Color.White;
		((Control)TEXT_UPI).Location = new Point(395, 434);
		((Control)TEXT_UPI).Name = "TEXT_UPI";
		((Control)TEXT_UPI).Size = new Size(100, 18);
		((Control)TEXT_UPI).TabIndex = 1225;
		((Control)TEXT_UPI).Visible = false;
		((Control)MSG_UPI).Location = new Point(105, 388);
		((Control)MSG_UPI).Name = "MSG_UPI";
		((AxHost)MSG_UPI).OcxState = (State)componentResourceManager.GetObject("MSG_UPI.OcxState");
		((Control)MSG_UPI).Size = new Size(728, 111);
		((Control)MSG_UPI).TabIndex = 1224;
		((Control)MSG_TOT).Location = new Point(105, 335);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(730, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(104, 121);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(729, 213);
		((Control)MSG).TabIndex = 1135;
		((TextBoxBase)nSchmAmt).BackColor = Color.White;
		((Control)nSchmAmt).Font = new Font("Tahoma", 9f);
		((Control)nSchmAmt).Location = new Point(634, 89);
		((TextBoxBase)nSchmAmt).MaxLength = 10;
		((Control)nSchmAmt).Name = "nSchmAmt";
		((TextBoxBase)nSchmAmt).ReadOnly = true;
		((Control)nSchmAmt).Size = new Size(88, 22);
		((Control)nSchmAmt).TabIndex = 1226;
		nSchmAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(782, 89);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(90, 20);
		((Control)Label7).TabIndex = 1227;
		Label7.Text = "Memb Amt";
		Label7.TextAlign = (ContentAlignment)16;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)nMembAmt);
		((Control)this).Controls.Add((Control)(object)nSchmAmt);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)TEXT_UPI);
		((Control)this).Controls.Add((Control)(object)MSG_UPI);
		((Control)this).Controls.Add((Control)(object)tSchmType);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)tQrCane);
		((Control)this).Controls.Add((Control)(object)lbrMsgShow);
		((Control)this).Controls.Add((Control)(object)tVchDesc);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)tChqNo);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)tBankName);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)tSchmName);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)tSchmCode);
		((Control)this).Controls.Add((Control)(object)tEmpCode);
		((Control)this).Controls.Add((Control)(object)tEmpName);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)tHdVchNo);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)BtnF1);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG_TOT);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)mDay);
		((Control)this).Controls.Add((Control)(object)mTime);
		((Control)this).Controls.Add((Control)(object)mVchDate);
		((Control)this).Controls.Add((Control)(object)lblBDate);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tVchNo);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "TR_MEMB_ENT";
		((Form)this).Text = "R_PUE";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((Control)FlowLayoutPanel1).PerformLayout();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((ISupportInitialize)MSG_UPI).EndInit();
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_UPI_CLEAR()
	{
		AxMSFlexGrid mSG_UPI = MSG_UPI;
		mSG_UPI.Clear();
		mSG_UPI.Cols = 8;
		mSG_UPI.FixedRows = 1;
		mSG_UPI.Rows = 2;
		mSG_UPI.Row = 0;
		mSG_UPI[0] = 0;
		mSG_UPI[1] = 0;
		mSG_UPI.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG_UPI[0] = (int)Math.Round(450.0 * ColCon);
			mSG_UPI[0] = 3;
			mSG_UPI[0, 0] = "Sr.";
			mSG_UPI[1] = (int)Math.Round(1100.0 * ColCon);
			mSG_UPI[1] = 0;
			mSG_UPI[0, 1] = "AcCode";
			mSG_UPI[2] = (int)Math.Round(3300.0 * ColCon);
			mSG_UPI[2] = 0;
			mSG_UPI[0, 2] = "Upi Bank Name";
			mSG_UPI[3] = (int)Math.Round(1500.0 * ColCon);
			mSG_UPI[3] = 0;
			mSG_UPI[0, 3] = "UpiType";
			mSG_UPI[4] = (int)Math.Round(2500.0 * ColCon);
			mSG_UPI[4] = 0;
			mSG_UPI[0, 4] = "Upi Id";
			mSG_UPI[5] = (int)Math.Round(1400.0 * ColCon);
			mSG_UPI[5] = 7;
			mSG_UPI[0, 5] = "UpiAmt";
			mSG_UPI[6] = 0;
			mSG_UPI[0, 6] = "RowSrNo";
			mSG_UPI[7] = 0;
			mSG_UPI[0, 7] = "MemebCode";
			mSG_UPI.Row = 1;
			mSG_UPI.Col = 0;
			((Control)TEXT_UPI).Visible = false;
			mSG_UPI[0] = (int)Math.Round(325.0 * ColCon);
			mSG_UPI[1] = (int)Math.Round(300.0 * ColCon);
			mSG_UPI.ScrollBars = (ScrollBarsSettings)3;
			CommPassAddUpi();
			mSG_UPI = null;
		}
	}

	private void CommPassAddUpi()
	{
		AxMSFlexGrid mSG_UPI = MSG_UPI;
		mSG_UPI[mSG_UPI.Row, 0] = Conversions.ToString(MSG_UPI.Row);
		mSG_UPI[mSG_UPI.Row, 6] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 0]));
		mSG_UPI = null;
	}

	private void MSG_UPI_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_UPI = MSG_UPI;
		checked
		{
			if (mSG_UPI.CellWidth >= 0)
			{
				((Control)TEXT_ENTRY).Visible = false;
				((Control)TEXT_UPI).Left = (int)Math.Round((double)((Control)mSG_UPI).Left + (double)mSG_UPI.CellLeft / 15.0);
				((Control)TEXT_UPI).Top = (int)Math.Round((double)((Control)mSG_UPI).Top + (double)mSG_UPI.CellTop / 15.0);
				((Control)TEXT_UPI).Width = (int)Math.Round((double)mSG_UPI.CellWidth / 15.0);
				((Control)TEXT_UPI).Height = (int)Math.Round((double)mSG_UPI.CellHeight / 15.0);
				TEXT_UPI.Text = mSG_UPI[mSG_UPI.Row, mSG_UPI.Col];
				((Control)TEXT_UPI).Visible = true;
				((TextBoxBase)TEXT_UPI).SelectAll();
				((Control)TEXT_UPI).Focus();
				mSG_UPI = null;
			}
		}
	}

	private void MSG_UPI_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_UPI = MSG_UPI;
		checked
		{
			if (mSG_UPI[mSG_UPI.Col] == 0)
			{
				TEXT_UPI.Text = "";
				mSG_UPI[mSG_UPI.Row, mSG_UPI.Col] = "";
				DC_Main.M = 1;
				while (mSG_UPI[mSG_UPI.Col] == 0)
				{
					if (MsgIdtlLeft)
					{
						if (mSG_UPI.Col > 1)
						{
							mSG_UPI.Col -= 1;
						}
					}
					else if (mSG_UPI.Col < mSG_UPI.Cols - 1)
					{
						mSG_UPI.Col += 1;
					}
					DC_Main.M++;
					if (DC_Main.M > 10)
					{
						break;
					}
				}
			}
			if (!((mSG_UPI.Row == 0) | (mSG_UPI.CellWidth <= 0)) && MSG_UPI[MSG_UPI.Col] != 0)
			{
				((Control)TEXT_UPI).Left = (int)Math.Round((double)((Control)mSG_UPI).Left + (double)mSG_UPI.CellLeft / 15.0);
				((Control)TEXT_UPI).Top = (int)Math.Round((double)((Control)mSG_UPI).Top + (double)mSG_UPI.CellTop / 15.0);
				((Control)TEXT_UPI).Width = (int)Math.Round((double)mSG_UPI.CellWidth / 15.0);
				((Control)TEXT_UPI).Height = (int)Math.Round((double)mSG_UPI.CellHeight / 15.0);
				((Control)TEXT_UPI).Visible = true;
				((TextBoxBase)TEXT_UPI).ReadOnly = false;
				switch (MSG_UPI.Col)
				{
				case 0:
					((TextBoxBase)TEXT_UPI).MaxLength = 5;
					TEXT_UPI.Text = mSG_UPI[mSG_UPI.Row, mSG_UPI.Col];
					break;
				case 1:
					((TextBoxBase)TEXT_UPI).MaxLength = 10;
					TEXT_UPI.Text = mSG_UPI[mSG_UPI.Row, mSG_UPI.Col];
					break;
				case 3:
				case 4:
					((TextBoxBase)TEXT_UPI).MaxLength = 25;
					TEXT_UPI.Text = mSG_UPI[mSG_UPI.Row, mSG_UPI.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_UPI).MaxLength = 50;
					TEXT_UPI.Text = mSG_UPI[mSG_UPI.Row, mSG_UPI.Col];
					break;
				case 5:
					((TextBoxBase)TEXT_UPI).MaxLength = 10;
					TEXT_UPI.Text = Strings.Format((object)Conversion.Val(mSG_UPI[mSG_UPI.Row, mSG_UPI.Col]), "0.00");
					break;
				}
				mSG_UPI = null;
				((TextBoxBase)TEXT_UPI).SelectAll();
			}
		}
	}

	private void MSG_UPI_LeaveCell(object sender, EventArgs e)
	{
		if (MSG_UPI.Row != 0 && MSG_UPI[MSG_UPI.Col] != 0 && ((Control)TEXT_UPI).Visible)
		{
			AxMSFlexGrid mSG_UPI = MSG_UPI;
			switch (MSG_UPI.Col)
			{
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
				MSG_UPI[mSG_UPI.Row, mSG_UPI.Col] = TEXT_UPI.Text;
				break;
			case 5:
				MSG_UPI[mSG_UPI.Row, mSG_UPI.Col] = Strings.Format((object)Conversion.Val(TEXT_UPI.Text), "0.00");
				CommPassUpiTotAmt(MSG_UPI.Row);
				break;
			}
			mSG_UPI = null;
		}
	}

	private void CommPassUpiTotAmt(int XRow)
	{
		string text = "";
		checked
		{
			int num = MSG_UPI.Rows - 1;
			double num2 = default(double);
			for (int i = 1; i <= num; i++)
			{
				if ((Operators.CompareString(MSG_UPI[i, 1], "", false) != 0) & (Conversion.Val(MSG_UPI[i, 5]) != 0.0))
				{
					num2 += Conversion.Val(MSG_UPI[i, 5]);
					text = ((Operators.CompareString(MSG_UPI[i, 3], "", false) != 0) ? (text + MSG_UPI[i, 3] + "/" + MSG_UPI[i, 5] + "  ") : (text + MSG_UPI[i, 2] + "/" + MSG_UPI[i, 5] + "  "));
				}
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 8] = Strings.Format((object)num2, "0.00");
			}
			if (Operators.CompareString(text, "", false) != 0)
			{
				if (Strings.Len(text) > 225)
				{
					text = Strings.Mid(text, 1, 225);
				}
				MSG[MSG.Row, 14] = text;
			}
			AxMSFlexGrid mSG_UPI = MSG_UPI;
			if (Operators.CompareString(mSG_UPI[XRow, 1], "", false) != 0)
			{
				bool flag = false;
				int num3 = DtIdtlPr.Rows.Count - 1;
				for (int j = 0; j <= num3; j++)
				{
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][6])) == Conversion.Val(mSG_UPI[XRow, 6])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[j][0])) == Conversion.Val(mSG_UPI[XRow, 0])))
					{
						flag = true;
						DtIdtlPr.Rows[j][0] = mSG_UPI[XRow, 0];
						DtIdtlPr.Rows[j][1] = mSG_UPI[XRow, 1];
						DtIdtlPr.Rows[j][2] = mSG_UPI[XRow, 2];
						DtIdtlPr.Rows[j][3] = mSG_UPI[XRow, 3];
						DtIdtlPr.Rows[j][4] = mSG_UPI[XRow, 4];
						DtIdtlPr.Rows[j][5] = mSG_UPI[XRow, 5];
						DtIdtlPr.Rows[j][6] = mSG_UPI[XRow, 6];
						DtIdtlPr.Rows[j][7] = mSG_UPI[XRow, 7];
						break;
					}
				}
				if (!flag)
				{
					drPr = DtIdtlPr.NewRow();
					drPr[0] = mSG_UPI[XRow, 0];
					drPr[1] = mSG_UPI[XRow, 1];
					drPr[2] = mSG_UPI[XRow, 2];
					drPr[3] = mSG_UPI[XRow, 3];
					drPr[4] = mSG_UPI[XRow, 4];
					drPr[5] = mSG_UPI[XRow, 5];
					drPr[6] = mSG_UPI[XRow, 6];
					drPr[7] = mSG_UPI[XRow, 7];
					DtIdtlPr.Rows.Add(drPr);
				}
			}
			mSG_UPI = null;
		}
	}

	private void TEXT_UPI_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_UPI_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Invalid comparison between Unknown and I4
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Invalid comparison between Unknown and I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Invalid comparison between Unknown and I4
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Invalid comparison between Unknown and I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Invalid comparison between Unknown and I4
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Invalid comparison between Unknown and I4
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Invalid comparison between Unknown and I4
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Invalid comparison between Unknown and I4
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0907: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bb: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		AxMSFlexGrid mSG_UPI = MSG_UPI;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == 112)
		{
			if (mSG_UPI.Col == 3)
			{
				UpiTypeAdd = true;
			}
		}
		else if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					if (unchecked((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null)) == 6)
					{
						int num = DtIdtlPr.Rows.Count - 1;
						for (int i = 0; i <= num; i++)
						{
							if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][6])) == Conversion.Val(mSG_UPI[mSG_UPI.Row, 6])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][0])) == Conversion.Val(mSG_UPI[mSG_UPI.Row, 0])))
							{
								DtIdtlPr.Rows.Remove(DtIdtlPr.Rows[i]);
								break;
							}
						}
						int num2 = mSG_UPI.Cols - 1;
						DC_Main.M = 1;
						while (DC_Main.M <= num2)
						{
							mSG_UPI[mSG_UPI.Row, DC_Main.M] = "";
							DC_Main.M++;
						}
						CommPassUpiTotAmt(MSG_UPI.Row);
						TEXT_UPI.Text = "";
						Interaction.MsgBox((object)"Record is Deleted....", (MsgBoxStyle)0, (object)null);
					}
					int num3 = mSG_UPI.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num3)
					{
						mSG_UPI[mSG_UPI.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					TEXT_UPI.Text = "";
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG_UPI.Col > 1)
				{
					mSG_UPI.Col = checked(mSG_UPI.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				checked
				{
					if (mSG_UPI.Col < mSG_UPI.Cols - 1)
					{
						mSG_UPI.Col += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 38)
			{
				if (mSG_UPI.Row > 1)
				{
					mSG_UPI.Row = checked(mSG_UPI.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				checked
				{
					if (mSG_UPI.Row < mSG_UPI.Rows - 1)
					{
						mSG_UPI.Row += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG_UPI.Col)
					{
					case 1:
						if (Operators.CompareString(TEXT_UPI.Text, "", false) == 0)
						{
							CommPassUpiTotAmt(MSG_UPI.Row);
							((Control)TEXT_UPI).Visible = false;
							MSG.Col = 5;
							MSG_EnterCell(MSG, new EventArgs());
							((Control)TEXT_ENTRY).Visible = true;
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + TEXT_UPI.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '19','22','23','21','02') ORDER BY A.LC_CODE,A.AC_NAME";
							}
							else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
							{
								DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND C.AC_GR in( '19','22','23','21','02') AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(A.AC_CODE AS INT) >=200 AND A.AC_GR in( '19','22','23','21','02') ORDER BY C.AC_NAME ";
							}
							else
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_GR in( '19','22','23','21','02') ORDER BY A.AC_NAME";
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
							if (DC_Main.HelpClose)
							{
								return;
							}
							if (DC_Main.MsCreat)
							{
								MS_ACCT mS_ACCT = new MS_ACCT();
								((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
								((Control)mS_ACCT).Show();
								((Control)mS_ACCT).Focus();
								return;
							}
							if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
							{
								TEXT_UPI.Text = DC_Main.ColValue[1];
								mSG_UPI[mSG_UPI.Row, 1] = DC_Main.ColValue[1];
								mSG_UPI[mSG_UPI.Row, 2] = DC_Main.ColValue[0];
							}
							((Control)TEXT_UPI).Focus();
							return;
						}
						mSG_UPI[mSG_UPI.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CODE"], (object)""));
						mSG_UPI[mSG_UPI.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
						break;
					case 3:
					{
						DC_Main.RsQry = "SELECT UPI_TYPE As UpiTypeL  From UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND UPI_TYPE = '" + TEXT_UPI.Text + "' ORDER BY UPI_TYPE";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count != 0)
						{
							break;
						}
						int num4 = MSG_UPI.Rows - 1;
						for (int j = 1; j <= num4; j++)
						{
							if (Operators.CompareString(mSG_UPI[j, 3], TEXT_UPI.Text, false) == 0)
							{
								UpiTypeAdd = true;
							}
						}
						if (!UpiTypeAdd)
						{
							DC_Main.RsQry = "SELECT DISTINCT UPI_TYPE As UpiTypeL From UPI_DATA ORDER BY UPI_TYPE";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[2];
							DC_Main.ColWidth[0] = 350.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
							{
								TEXT_UPI.Text = DC_Main.ColValue[0];
							}
							return;
						}
						UpiTypeAdd = false;
						break;
					}
					case 4:
						if (Operators.CompareString(TEXT_UPI.Text, "", false) != 0)
						{
							DC_Main.RsQry = "SELECT UPI_ID,CO_BOOK,VCH_NO FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND UPI_ID = '" + TEXT_UPI.Text + "'";
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Tbl.Rows.Count > 0)
							{
								Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This UpiId already Exist In Book No =  ", DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)" AND VchNo = "), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)" Please Change Upi Id ..."), (MsgBoxStyle)0, (object)null);
								((TextBoxBase)TEXT_UPI).SelectAll();
								return;
							}
						}
						break;
					case 5:
						if (Conversion.Val(TEXT_UPI.Text) != 0.0)
						{
							if (mSG_UPI.Row == mSG_UPI.Rows - 1)
							{
								mSG_UPI.Rows += 1;
								mSG_UPI.Row += 1;
								CommPassAddUpi();
								mSG_UPI.Col = 1;
							}
							else
							{
								mSG_UPI.Row += 1;
								mSG_UPI.Col = 1;
								((Control)TEXT_UPI).Visible = true;
								((Control)TEXT_UPI).Focus();
							}
						}
						return;
					}
					if (mSG_UPI.Col < mSG_UPI.Cols - 1)
					{
						MSG_UPI.Col += 1;
					}
					((Control)TEXT_UPI).Visible = true;
					((Control)TEXT_UPI).Focus();
				}
			}
		}
		mSG_UPI = null;
	}

	private void TodayFineRate()
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		DataTable dataTable = default(DataTable);
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
				case 421:
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
							goto IL_0026;
						case 5:
							goto IL_008e;
						case 4:
						case 6:
						case 7:
							goto IL_00f3;
						case 8:
							goto IL_0100;
						case 9:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 10:
						case 11:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_008e:
					num2 = 5;
					DC_Main.RsQry = "SELECT TOP(1) FINE_GL_RATE,FINE_SL_RATE,VCH_DATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND SR_NO = 1  ORDER BY VCH_DATE DESC";
					goto IL_00f3;
					IL_00f3:
					num2 = 7;
					dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_0100;
					IL_0026:
					num2 = 3;
					DC_Main.RsQry = "SELECT TOP(1) GR_RATE AS FINE_GL_RATE  FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND GR_CODE = '22K'  ORDER BY VCH_DATE DESC";
					goto IL_00f3;
					IL_0100:
					num2 = 8;
					if (dataTable.Rows.Count <= 0)
					{
						goto end_IL_0001_3;
					}
					break;
					IL_000b:
					num2 = 2;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "HM427NEHP", false) == 0)
					{
						goto IL_0026;
					}
					goto IL_008e;
					end_IL_0001_2:
					break;
				}
				num2 = 9;
				ToDayGlRate = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["FINE_GL_RATE"], (object)"")) / 10.0), "0.00"));
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 421;
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

	private void DGV_CLEAR()
	{
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((DataGridView)DGV).Columns.Clear();
		((Control)DGV).Refresh();
	}

	private void DGV_FILL()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Expected O, but got Unknown
		DGV_CLEAR();
		((DataGridView)DGV).MultiSelect = false;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 9f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV).AutoGenerateColumns = false;
		((DataGridView)DGV).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV).Columns[0].Width = (int)Math.Round(35.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "VchNo");
			((DataGridView)DGV).Columns[1].Width = (int)Math.Round(55.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "VchDate");
			((DataGridView)DGV).Columns[2].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Mnth");
			((DataGridView)DGV).Columns[3].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Amt");
			((DataGridView)DGV).Columns[4].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[4].DefaultCellStyle.Format = "N2";
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			double num = 0.0;
			DC_Main.RsQry = "SELECT A.* ,B.AC_NAME FROM AD_OS AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.LD_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.MEMB_CODE = '" + TEXT_ENTRY.Text + "' AND A.SCHM_CODE = '" + tSchmCode.Text + "' AND CO_BOOK <> '076' ORDER BY A.SCHM_DATE ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.R = 0;
			if (DC_Main.Rshlp.Rows.Count <= 0)
			{
				return;
			}
			int num2 = DC_Main.Rshlp.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num2)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				((DataGridView)dGV).Rows.Add();
				((DataGridView)dGV)[0, DC_Main.R].Value = DC_Main.R + 1;
				((DataGridView)dGV)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]);
				((DataGridView)dGV)[2, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["SCHM_DATE"]), "dd/MM/yyyy");
				((DataGridView)dGV)[3, DC_Main.R].Value = DateAndTime.Month(Conversions.ToDate(DC_Main.Rshlp.Rows[DC_Main.M]["SCHM_DATE"]));
				((DataGridView)dGV)[4, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ADJ_AMT"]), "0.00");
				num = Conversions.ToDouble(Operators.AddObject((object)num, ((DataGridView)dGV)[4, DC_Main.R].Value));
				DC_Main.R++;
				dGV = null;
				DC_Main.M++;
			}
			if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(((DataGridView)DGV)[2, DC_Main.R - 1].Value, (object)"", false), (object)(MSG.Rows > 1))))
			{
				string text = Conversions.ToString(((DataGridView)DGV)[3, DC_Main.R - 1].Value);
				string text2 = Strings.Mid(Conversions.ToString(((DataGridView)DGV)[2, DC_Main.R - 1].Value), 7, 4);
				text = ((Conversions.ToDouble(text) != 12.0) ? Conversions.ToString(Conversion.Val(text) + 1.0) : Conversions.ToString(1));
				if (MSG.Row == 1)
				{
					if ((Operators.CompareString(DC_Main.SSRegSrNo, "VS176NPBU", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK163NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM489NPHM", false) == 0))
					{
						MSG[MSG.Row, 3] = Strings.Mid(mVchDate.Text, 1, 2) + "/" + Strings.Format((object)Conversion.Val(text), "00") + "/" + text2;
					}
				}
				else if (((Operators.CompareString(DC_Main.SSRegSrNo, "VS176NPBU", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK163NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM489NPHM", false) == 0)) && Operators.CompareString(MSG[MSG.Row - 1, 1], MSG[MSG.Row, 1], false) != 0)
				{
					MSG[MSG.Row, 3] = Strings.Mid(mVchDate.Text, 1, 2) + "/" + Strings.Format((object)Conversion.Val(text), "00") + "/" + Strings.Mid(mVchDate.Text, 7, 4);
				}
			}
			((DataGridView)DGV).Rows.Add();
			((DataGridView)DGV)[3, DC_Main.R].Value = "Total :";
			((DataGridView)DGV)[4, DC_Main.R].Value = Strings.Format((object)num, "0.00");
		}
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 15;
		mSG.Rows = 2;
		mSG.Row = 0;
		mSG[0] = 0;
		mSG[1] = 0;
		mSG.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG[0] = (int)Math.Round(700.0 * ColCon);
			mSG[0] = 3;
			mSG[0, 0] = "Sr";
			mSG[1] = (int)Math.Round(1000.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "Code";
			mSG[2] = (int)Math.Round(2800.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "Memb Name";
			mSG[3] = (int)Math.Round(1300.0 * ColCon);
			mSG[3] = 3;
			mSG[0, 3] = "Rec Date";
			mSG[4] = (int)Math.Round(1050.0 * ColCon);
			mSG[4] = 3;
			mSG[0, 4] = "WithUpi";
			mSG[5] = (int)Math.Round(1100.0 * ColCon);
			mSG[5] = 0;
			mSG[0, 5] = "RecAc";
			mSG[6] = (int)Math.Round(1100.0 * ColCon);
			mSG[6] = 7;
			mSG[0, 6] = "Rate";
			mSG[7] = (int)Math.Round(1200.0 * ColCon);
			mSG[7] = 7;
			mSG[0, 7] = "GrWt";
			mSG[8] = (int)Math.Round(1300.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "Amount";
			mSG[9] = 0;
			mSG[11] = 0;
			mSG[10] = 0;
			mSG[12] = 0;
			mSG[13] = 0;
			mSG[14] = 0;
			mSG.Row = 1;
			mSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			if ((Operators.CompareString(tSchmType.Text, "G", false) != 0) & (Operators.CompareString(tSchmType.Text, "S", false) != 0))
			{
				mSG[1] = (int)Math.Round(1100.0 * ColCon);
				mSG[1] = 0;
				mSG[0, 1] = "Code";
				mSG[2] = (int)Math.Round(3400.0 * ColCon);
				mSG[2] = 0;
				mSG[0, 2] = "Memb Name";
				mSG[3] = (int)Math.Round(1400.0 * ColCon);
				mSG[3] = 3;
				mSG[0, 3] = "Rec Date";
				mSG[5] = (int)Math.Round(1200.0 * ColCon);
				mSG[5] = 0;
				mSG[0, 5] = "RecAc";
				mSG[8] = (int)Math.Round(1500.0 * ColCon);
				mSG[8] = 7;
				mSG[0, 8] = "Amount";
				mSG[6] = 0;
				mSG[7] = 0;
			}
			((Control)DGV).Left = (int)Math.Round((double)((Control)MSG).Width + 115.0 * ColCon);
			MsgLastCol = 8;
			mSG[0] = (int)Math.Round(325.0 * ColCon);
			mSG[1] = (int)Math.Round(300.0 * ColCon);
			mSG.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd();
			mSG = null;
			AxMSFlexGrid mSG_TOT = MSG_TOT;
			mSG_TOT.Cols = MSG.Cols;
			int num = MSG.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				mSG_TOT[DC_Main.M] = MSG[DC_Main.M];
				mSG_TOT[DC_Main.M] = MSG[DC_Main.M];
				DC_Main.M++;
			}
			if (Operators.CompareString(DC_Main.MsGridScroll, "N", false) == 0)
			{
				MSG_TOT.ScrollBars = (ScrollBarsSettings)0;
			}
			MSG_TOT_FILL();
			mSG_TOT = null;
		}
	}

	private void MSG_TOT_FILL()
	{
		checked
		{
			if (!UpDown)
			{
				AxMSFlexGrid mSG_TOT = MSG_TOT;
				int num = MSG.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					mSG_TOT[0, DC_Main.M] = "";
					DC_Main.M++;
				}
				mSG_TOT[0, 2] = "Total :";
				int num2 = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					mSG_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 8]) + Conversion.Val(MSG[DC_Main.M, 8]))), "0.00");
					mSG_TOT[0, 7] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 7]) + Conversion.Val(MSG[DC_Main.M, 7]))), "0.000");
					DC_Main.M++;
				}
				mSG_TOT = null;
				NewValTot = Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 6]);
			}
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		}
		else
		{
			mSG[mSG.Row, 0] = Conversions.ToString(Conversion.Val(mSG[checked(mSG.Row - 1), 0]) + 1.0);
		}
		mSG[mSG.Row, 9] = "A";
		mSG[mSG.Row, 5] = "00001";
		mSG[mSG.Row, 4] = "N";
		if (Operators.CompareString(FormMainBook, "MEMB OPENING", false) == 0)
		{
			mSG[mSG.Row, 3] = Conversions.ToString(DC_Main.MOp_dt);
		}
		else
		{
			mSG[mSG.Row, 3] = mVchDate.Text;
		}
		MSG_UPI_CLEAR();
		mSG = null;
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
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				((Control)TEXT_ENTRY).Visible = true;
				((TextBoxBase)TEXT_ENTRY).SelectAll();
				((Control)TEXT_ENTRY).Focus();
				mSG = null;
			}
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
				case 1:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 5:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 4:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 6:
				case 8:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				case 7:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
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
			case 1:
			case 4:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 0:
			case 2:
			case 3:
			case 5:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 6:
			case 8:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 7:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				CommPassTotal();
				break;
			}
			mSG = null;
		}
	}

	private void CommPassTotal()
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		AxMSFlexGrid val = default(AxMSFlexGrid);
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
					goto IL_000c;
				case 432:
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
							goto IL_000c;
						case 3:
							goto IL_0015;
						case 4:
							goto IL_005e;
						case 5:
						case 6:
							goto IL_00a4;
						case 7:
							goto IL_00ed;
						case 8:
							goto IL_0112;
						case 9:
						case 10:
							goto IL_015f;
						case 11:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 12:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_00ed:
					num2 = 7;
					if (Conversion.Val(val[val.Row, 8]) == 0.0)
					{
						goto IL_0112;
					}
					goto IL_015f;
					IL_0112:
					num2 = 8;
					val[val.Row, 8] = Strings.Format((object)Math.Round(Conversions.ToDouble(val[val.Row, 7]) * Conversion.Val(val[val.Row, 6]), 0), "0.00");
					goto IL_015f;
					IL_00a4:
					num2 = 6;
					if ((Conversion.Val(val[val.Row, 6]) != 0.0) & (Conversion.Val(val[val.Row, 7]) != 0.0))
					{
						goto IL_00ed;
					}
					goto IL_015f;
					IL_015f:
					val = null;
					break;
					IL_000c:
					num2 = 2;
					val = MSG;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					if ((Conversion.Val(val[val.Row, 6]) != 0.0) & (Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_005e;
					}
					goto IL_00a4;
					IL_005e:
					num2 = 4;
					val[val.Row, 7] = Strings.Format((object)(Conversion.Val(val[val.Row, 8]) / Conversion.Val(val[val.Row, 6])), "0.000");
					goto IL_00a4;
					end_IL_0001_2:
					break;
				}
				num2 = 11;
				MSG_TOT_FILL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 432;
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

	private void TEXT_ENTRY_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_ENTRY_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Invalid comparison between Unknown and I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Invalid comparison between Unknown and I4
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Invalid comparison between Unknown and I4
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Invalid comparison between Unknown and I4
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Invalid comparison between Unknown and I4
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Invalid comparison between Unknown and I4
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Invalid comparison between Unknown and I4
		//IL_0cc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e99: Unknown result type (might be due to invalid IL or missing references)
		//IL_057d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0867: Unknown result type (might be due to invalid IL or missing references)
		//IL_0770: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = (int)Math.Round(Conversion.Val(mSG[mSG.Row, 0]));
					List<DataRow> list = new List<DataRow>();
					int num2 = DtIdtlPr.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num2)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[DC_Main.M][6])) == Conversion.Val(mSG[mSG.Row, 0]))
						{
							list.Add(DtIdtlPr.Rows[DC_Main.M]);
						}
						DC_Main.M++;
					}
					foreach (DataRow item in list)
					{
						DtIdtlPr.Rows.Remove(item);
						DtIdtlPr.AcceptChanges();
					}
					int num3 = mSG.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num3)
					{
						mSG[mSG.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					TEXT_ENTRY.Text = "";
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else if ((int)keyCode == 46)
		{
			MsTxtDelete = true;
		}
		else if ((int)keyCode == 8)
		{
			MsTxtDelete = true;
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG.Col > 1)
				{
					if (MsTxtDelete)
					{
						MsTxtDelete = false;
					}
					else
					{
						Msgleft = true;
						UpDown = true;
					}
					mSG.Col = checked(mSG.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				checked
				{
					if (mSG.Col >= MsgLastCol)
					{
						((Control)TEXT_ENTRY).Focus();
					}
					else if (mSG.Col < mSG.Cols - 1)
					{
						if (MsTxtDelete)
						{
							MsTxtDelete = false;
						}
						else
						{
							UpDown = true;
						}
						mSG.Col += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 38)
			{
				if (mSG.Row > 1)
				{
					if (MsTxtDelete)
					{
						MsTxtDelete = false;
					}
					else
					{
						UpDown = true;
					}
					MsgOldRow = 0;
					mSG.Row = checked(mSG.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				checked
				{
					if (mSG.Row < mSG.Rows - 1)
					{
						if (MsTxtDelete)
						{
							MsTxtDelete = false;
						}
						else
						{
							UpDown = true;
						}
						MsgOldRow = 0;
						mSG.Row += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG.Col)
					{
					case 1:
					{
						DC_Main.RsQry = "Select A.*,B.SCHM_TYPE From AD_MEMB AS A LEFT JOIN AD_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.SCHM_CODE = B.SCHM_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.MEMB_CODE = '" + TEXT_ENTRY.Text + "' AND A.SCHM_CODE = '" + tSchmCode.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							if (Operators.CompareString(DC_Main.SSRegSrNo, "VK052NEVK", false) == 0)
							{
								DC_Main.RsQry = "SELECT A.MEMB_CODE As MembCodeL,A.MEMB_NAME as MembNameL,A.AC_ADD1 AS AddressL,A.MEMB_AMT AS SchmAmtR  FROM AD_MEMB AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND A.SCHM_CODE = '" + tSchmCode.Text + "' AND A.EXP_DATE >= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' ORDER BY A.MEMB_CODE";
							}
							else
							{
								DC_Main.RsQry = "SELECT A.MEMB_CODE As MembCodeL,A.MEMB_NAME as MembNameL,A.AC_ADD1 AS AddressL,A.MEMB_AMT AS SchmAmtR  FROM AD_MEMB AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND A.SCHM_CODE = '" + tSchmCode.Text + "' ORDER BY A.MEMB_CODE";
							}
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[5];
							DC_Main.ColWidth[0] = 100.0;
							DC_Main.ColWidth[1] = 300.0;
							DC_Main.ColWidth[2] = 250.0;
							DC_Main.ColWidth[3] = 100.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (DC_Main.HelpClose)
							{
								return;
							}
							if (DC_Main.MsCreat)
							{
								MS_MEMB mS_MEMB = new MS_MEMB();
								((Form)mS_MEMB).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
								((Control)mS_MEMB).Show();
								((Control)mS_MEMB).Focus();
								return;
							}
							if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
							{
								TEXT_ENTRY.Text = DC_Main.ColValue[0];
								mSG[mSG.Row, 1] = DC_Main.ColValue[0];
								mSG[mSG.Row, 2] = DC_Main.ColValue[1];
							}
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						mSG[mSG.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MEMB_CODE"], (object)""));
						mSG[mSG.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MEMB_NAME"], (object)""));
						mSG[mSG.Row, 12] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_MOBILE"], (object)""));
						if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ014NPKJ", false) == 0 && !Information.IsDBNull(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["EXP_DATE"])) && DateTime.Compare(Conversions.ToDate(mVchDate.Text), Conversions.ToDate(DC_Main.Tbl.Rows[0]["EXP_DATE"])) > 0)
						{
							Interaction.MsgBox((object)"This Member Scheme Is Close Please Create New Member Code...", (MsgBoxStyle)0, (object)null);
							mSG[mSG.Row, 1] = "";
							mSG[mSG.Row, 2] = "";
							mSG[mSG.Row, 3] = "";
							return;
						}
						if (Operators.CompareString(DC_Main.SSRegSrNo, "HM244NEKU", false) == 0)
						{
							DC_Main.RsQry = "SELECT SCHM_CODE,MEMB_CODE,SUM(CASE WHEN SIGN = '+' THEN ADJ_AMT ELSE -ADJ_AMT END) As Bal FROM AD_OS AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.MEMB_CODE = '" + TEXT_ENTRY.Text + "' AND A.SCHM_CODE = '" + tSchmCode.Text + "' GROUP BY SCHM_CODE,MEMB_CODE HAVING SUM(CASE WHEN SIGN = '+' THEN ADJ_AMT ELSE -ADJ_AMT END) > 0 ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count == 0)
							{
								Interaction.MsgBox((object)"This Member Scheme Adjust Please Check....", (MsgBoxStyle)0, (object)null);
								mSG[mSG.Row, 1] = "";
								mSG[mSG.Row, 2] = "";
								mSG[mSG.Row, 3] = "";
								return;
							}
						}
						DataRow dataRow;
						object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["MEMB_AMT"]);
						double num4 = DC_Main.Fnv(ref Value);
						dataRow["MEMB_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						if (num4 != 0.0)
						{
							mSG[mSG.Row, 8] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["MEMB_AMT"]), "0.00");
							mSG[mSG.Row, 13] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["MEMB_AMT"]), "0.00");
							nMembAmt.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 13]), "0.00");
						}
						if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[0]["SCHM_TYPE"], (object)"G", false) && Conversion.Val(mSG[mSG.Row, 6]) == 0.0)
						{
							mSG[mSG.Row, 6] = Strings.Format((object)ToDayGlRate, "0.00");
						}
						Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["ITM_GWT"]);
						double num5 = DC_Main.Fnv(ref Value);
						dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
						if (num5 != 0.0)
						{
							mSG[mSG.Row, 7] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["ITM_GWT"]), "0.000");
						}
						if ((mSG.Row >= 1) & (Operators.CompareString(mSG[mSG.Row - 1, 1], mSG[mSG.Row, 1], false) != 0))
						{
							mSG[mSG.Row, 3] = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dd/MM/yyyy");
						}
						else if (mSG.Row > 1)
						{
							if (Conversions.ToDouble(Strings.Mid(mSG[mSG.Row - 1, 3], 4, 2)) == 12.0)
							{
								mSG[mSG.Row, 3] = Strings.Mid(mSG[mSG.Row - 1, 3], 1, 2) + "/" + Strings.Format((object)1, "00") + "/" + Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mSG[mSG.Row - 1, 3], 7, 4)) + 1.0), "0000");
							}
							else
							{
								mSG[mSG.Row, 3] = Strings.Mid(mSG[mSG.Row - 1, 3], 1, 2) + "/" + Strings.Format((object)(Conversions.ToDouble(Strings.Mid(mSG[mSG.Row - 1, 3], 4, 2)) + 1.0), "00") + "/" + Strings.Mid(mSG[mSG.Row - 1, 3], 7, 4);
							}
						}
						DGV_FILL();
						break;
					}
					case 4:
						if ((Operators.CompareString(TEXT_ENTRY.Text, "N", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, "Y", false) != 0))
						{
							Interaction.MsgBox((object)"Plese Enter Y or N then Try...", (MsgBoxStyle)0, (object)null);
							return;
						}
						if (Operators.CompareString(TEXT_ENTRY.Text, "Y", false) == 0)
						{
							mSG[mSG.Row, 5] = "";
							mSG[mSG.Row, 4] = TEXT_ENTRY.Text;
							((Control)TEXT_ENTRY).Visible = false;
							MSG_UPI.Row = MSG_UPI.Rows - 1;
							MSG_UPI.Col = 1;
							MSG_UPI_EnterCell(MSG_UPI, new EventArgs());
							((Control)TEXT_UPI).Focus();
							((TextBoxBase)TEXT_UPI).SelectAll();
							return;
						}
						break;
					case 5:
						if (Operators.CompareString(mSG[mSG.Row, 4], "Y", false) == 0)
						{
							break;
						}
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + TEXT_ENTRY.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.AC_NAME as AcNameL,A.AC_CODE As AcCodeL,A.AC_ADD1 AS AddressL,B.AC_GR_NAME AS AcGroupL  FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.AC_GR IN ('02','19','21','22','23')  ORDER BY A.AC_NAME";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[5];
							DC_Main.ColWidth[0] = 300.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.ColWidth[2] = 250.0;
							DC_Main.ColWidth[3] = 250.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (DC_Main.HelpClose)
							{
								return;
							}
							if (DC_Main.MsCreat)
							{
								MS_ACCT mS_ACCT = new MS_ACCT();
								((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
								((Control)mS_ACCT).Show();
								((Control)mS_ACCT).Focus();
								return;
							}
							if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
							{
								TEXT_ENTRY.Text = DC_Main.ColValue[1];
								mSG[mSG.Row, 5] = DC_Main.ColValue[1];
							}
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						mSG[mSG.Row, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CODE"], (object)""));
						if (Operators.CompareString(TEXT_ENTRY.Text, "00001", false) != 0)
						{
							MSG_LeaveCell(MSG, new EventArgs());
							((Control)TEXT_ENTRY).Visible = false;
							((Control)tBankName).Focus();
							return;
						}
						break;
					case 3:
						if (Strings.Len(TEXT_ENTRY.Text) != 10)
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						break;
					case 6:
						if (Operators.CompareString(tSchmType.Text, "G", false) == 0)
						{
							if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
							{
								((Control)TEXT_ENTRY).Focus();
							}
							else if (mSG.Row == mSG.Rows - 1)
							{
								mSG[mSG.Row, 6] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
								CommPassTotal();
								MsgClear = true;
								mSG.Rows += 1;
								mSG.Row += 1;
								MsgClear = false;
								mSG.Col = 1;
								CommPassAdd();
							}
							else
							{
								mSG.Row += 1;
								mSG.Col = 1;
								((Control)TEXT_ENTRY).Visible = true;
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						break;
					case 8:
						if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
						{
							((Control)TEXT_ENTRY).Focus();
						}
						else if (mSG.Row == mSG.Rows - 1)
						{
							mSG[mSG.Row, 8] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
							MsgClear = true;
							mSG.Rows += 1;
							mSG.Row += 1;
							MsgClear = false;
							mSG.Col = 1;
							CommPassAdd();
						}
						else
						{
							mSG.Row += 1;
							mSG.Col = 1;
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
			}
		}
		mSG = null;
	}

	private void TR_MEMB_ENT_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0b89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b98: Expected O, but got Unknown
		//IL_0bbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcc: Expected O, but got Unknown
		//IL_0c0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1a: Expected O, but got Unknown
		//IL_0c34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c43: Expected O, but got Unknown
		//IL_0cb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc6: Expected O, but got Unknown
		//IL_0ce5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf4: Expected O, but got Unknown
		//IL_0d13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d22: Expected O, but got Unknown
		//IL_0dcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd6: Expected O, but got Unknown
		//IL_0e3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4a: Expected O, but got Unknown
		//IL_0ed2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee1: Expected O, but got Unknown
		//IL_0f53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5e: Expected O, but got Unknown
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr.Connect = DC_Main.CrConnect;
		}
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
			((Control)MSG_TOT).Top = ((Control)MSG).Bottom + 1;
			((Form)this).ClientSize = new Size((int)Math.Round(DC_Main.MainPcW), (int)Math.Round(DC_Main.MainPcH));
			((Control)this).Dock = (DockStyle)5;
			ColorConverter colorConverter = new ColorConverter();
			if (DC_Main.MsCoTheme == 2)
			{
				((Form)this).BackColor = Color.Silver;
				Label obj2 = lblBook;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj2).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				TextBox obj4 = tHdVchNo;
				object? obj5 = colorConverter.ConvertFromString("MistyRose");
				((TextBoxBase)obj4).BackColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				Label obj6 = lblBook;
				object? obj7 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj6).ForeColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj8 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				object? obj9 = colorConverter.ConvertFromString("DarkGray");
				((DataGridView)dGV).BackgroundColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj10 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				AxMSFlexGrid mSG = MSG;
				object? obj11 = colorConverter.ConvertFromString("ControlLightLight");
				mSG.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				AxMSFlexGrid mSG2 = MSG;
				object? obj12 = colorConverter.ConvertFromString("DarkGray");
				mSG2.BackColorBkg = ((obj12 != null) ? ((Color)obj12) : default(Color));
				AxMSFlexGrid mSG3 = MSG;
				object? obj13 = colorConverter.ConvertFromString("255, 224, 192");
				mSG3.BackColorFixed = ((obj13 != null) ? ((Color)obj13) : default(Color));
				AxMSFlexGrid mSG_TOT = MSG_TOT;
				object? obj14 = colorConverter.ConvertFromString("Silver");
				mSG_TOT.BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				AxMSFlexGrid mSG_TOT2 = MSG_TOT;
				object? obj15 = colorConverter.ConvertFromString("Silver");
				mSG_TOT2.BackColorBkg = ((obj15 != null) ? ((Color)obj15) : default(Color));
				AxMSFlexGrid mSG_TOT3 = MSG_TOT;
				object? obj16 = colorConverter.ConvertFromString("Silver");
				mSG_TOT3.BackColorFixed = ((obj16 != null) ? ((Color)obj16) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj17 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj18 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV2 = DGV;
				object? obj19 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV2).BackgroundColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj20 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj21 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj22 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj23 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj24 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj25 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj26 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj26 != null) ? ((Color)obj26) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj27 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj28 = lblBook;
				object? obj29 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj28).ForeColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj30 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV3 = DGV;
				object? obj31 = colorConverter.ConvertFromString("238, 244, 236");
				((DataGridView)dGV3).BackgroundColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj32 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj33 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj34 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj35 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj36 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj36 != null) ? ((Color)obj36) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj37 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj37 != null) ? ((Color)obj37) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj38 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj38 != null) ? ((Color)obj38) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj39 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj39 != null) ? ((Color)obj39) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				((TextBoxBase)TEXT_UPI).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				((Control)TEXT_UPI).Font = new Font(((Control)TEXT_UPI).Font.FontFamily, (float)num3, ((Control)TEXT_UPI).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_UPI.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV).RowTemplate.Height * (1.0 + num2));
				}
				num3 = (int)Math.Ceiling((double)((Control)tSchmCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tSchmCode).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
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
					foreach (object control4 in ((Control)PnlBotam).Controls)
					{
						object objectValue2 = RuntimeHelpers.GetObjectValue(control4);
						NewLateBinding.LateSet(objectValue2, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
			}
			FormBook = DC_Main.CurBook;
			FormName = DC_Main.CurBookName;
			FormBookType = DC_Main.CurBookType;
			FormItmType = DC_Main.CurBookItm;
			FormMainBook = DC_Main.CurBookMain;
			FormBookSname = DC_Main.CurBookSname;
			FormBookInOut = DC_Main.CurBookInOut;
			DC_Main.MCo_Book = FormBook;
			if (Operators.CompareString(FormItmType, "", false) == 0)
			{
				FormItmType = "A";
			}
			if (Operators.CompareString(DC_Main.CurBookVch, "", false) != 0)
			{
				FormVchNo = DC_Main.CurBookVch;
			}
			DC_Main.CurBook = "";
			DC_Main.CurBookName = "";
			DC_Main.CurBookType = "";
			DC_Main.CurBookItm = "";
			DC_Main.CurBookMain = "";
			DC_Main.CurBookSname = "";
			DC_Main.CurBookInOut = "";
			if (Operators.CompareString(FormMainBook, "MEMB OPENING", false) == 0)
			{
			}
			if ((Operators.CompareString(DC_Main.MsWhatsAppOpen, "Y", false) == 0) | DC_Main.MsEmailOpen)
			{
				((Control)lbrMsgShow).Visible = true;
				((Control)chkWapp).Visible = true;
			}
			BtnCancel_Click(BtnCancel, new EventArgs());
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM131NEPK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM360NAPK", false) == 0))
			{
				((Control)Label6).Visible = true;
				((Control)tQrCane).Visible = true;
				CurActCtrl = (Control)(object)tQrCane;
			}
			else
			{
				CurActCtrl = (Control)(object)tVchNo;
			}
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
		DataTrfr = "N";
		mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);
		mTime.Text = DateTime.Now.ToString("HH:mm:ss");
		mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
		MsVchSrno = "";
		UsUPdate = "N";
		UsDelete = "N";
		UpiTypeAdd = false;
		chkWapp.Checked = false;
		ToDayGlRate = 0.0;
		TodayFineRate();
		OldValTot = 0.0;
		NewValTot = 0.0;
		DGV_CLEAR();
		((Control)TEXT_ENTRY).Visible = false;
		ColorConverter colorConverter = new ColorConverter();
		SimpleButton btnSave = BtnSave;
		object? obj = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnSave).ForeColor = ((obj != null) ? ((Color)obj) : default(Color));
		SimpleButton btnDelete = BtnDelete;
		object? obj2 = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnDelete).ForeColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
		MSG_CLEAR();
		MSG_UPI_CLEAR();
		if (VchOldData != null)
		{
			VchOldData.Clear();
		}
		DtIdtlPr.Clear();
		DtIdtlPr.Reset();
		FilRowPr = 0;
		checked
		{
			int num = MSG_UPI.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				DtIdtlPr.Columns.Add(MSG_UPI[0, DC_Main.M]);
				DC_Main.M++;
			}
			if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
			{
				tEmpCode.Text = DC_Main.MsUserEmpCode;
				tEmpName.Text = DC_Main.MsUserEmpName;
			}
			DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				tVchNo.Text = "00001";
			}
			else
			{
				tVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
				MaxVchNo = tVchNo.Text;
			}
			LastVchNo = tVchNo.Text;
			DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				tHdVchNo.Text = "00001";
			}
			else
			{
				tHdVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
			}
			EntryMode = "A";
			((Control)BtnSave).Enabled = true;
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM131NEPK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM360NAPK", false) == 0))
			{
				((Control)tQrCane).Focus();
			}
			else
			{
				((Control)tVchNo).Focus();
			}
		}
	}

	private void DISPLAY_DATA()
	{
		DC_Main.RsQry = "SELECT * FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
		RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (RsData.Rows.Count > 0)
			{
				if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
				{
					VchOldData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				tVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_NO"], (object)""));
				tHdVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HD_VCH_NO"], (object)""));
				tSchmCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["SCHM_CODE"], (object)""));
				DC_Main.RsQry = "SELECT * FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '" + tSchmCode.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tSchmName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SCHM_NAME"], (object)""));
				}
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					nSchmAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SCHM_AMT"]), "0.00");
				}
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tSchmType.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SCHM_TYPE"], (object)""));
				}
				tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
				DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["EMP_NAME"], (object)""));
				}
				CurPrnVch = tVchNo.Text;
				mVchDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DATE"], (object)""));
				mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
				mTime.Text = Strings.Format((object)Conversions.ToDate(RsData.Rows[0]["VCH_TIME"]), "HH:mm:ss");
				MainUser = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MAIN_USER"], (object)""));
				tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["IT_DESC"], (object)""));
				UsUPdate = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_UPDATE"], (object)""));
				UsDelete = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_DELETE"], (object)""));
				DataTrfr = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["DATA_TRFR"], (object)""));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["RE_TRFR"], (object)""), (object)"Y", false))
				{
					DataTrfr = "Y";
				}
				if (Operators.CompareString(UsUPdate, "Y", false) == 0)
				{
					((BaseStyleControl)BtnSave).ForeColor = Color.Green;
				}
				if (Operators.CompareString(UsDelete, "Y", false) == 0)
				{
					((BaseStyleControl)BtnDelete).ForeColor = Color.Green;
				}
				MSG_CLEAR();
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsData.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["MEMB_CODE"], (object)""));
					if (DC_Main.i + 1 == 1)
					{
						PartyAcCode = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["MEMB_CODE"], (object)""));
					}
					DC_Main.RsQry = "SELECT * FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SCHM_CODE = '" + tSchmCode.Text + "' AND MEMB_CODE = '" + mSG[DC_Main.i + 1, 1] + "'";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MEMB_NAME"], (object)""));
					}
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						mSG[DC_Main.i + 1, 12] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_MOBILE"], (object)""));
					}
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["MEMB_AMT"])), "0.00");
					}
					mSG[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[DC_Main.i]["MEMB_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 6] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["WITH_UPI"], (object)""));
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["REC_AC"], (object)""));
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["SCHM_DATE"], (object)""));
					mSG[DC_Main.i + 1, 11] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["BANK_NAME"], (object)""));
					mSG[DC_Main.i + 1, 10] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["CHQ_NO"], (object)""));
					mSG[DC_Main.i + 1, 14] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["UPI_NAME"], (object)""));
					mSG[DC_Main.i + 1, 9] = "E";
					mSG.Rows += 1;
					DC_Main.i++;
				}
				mSG.Rows -= 1;
				mSG = null;
				MSG_UPI_CLEAR();
				DtIdtlPr.Clear();
				DtIdtlPr.Reset();
				FilRowPr = 0;
				int num = MSG_UPI.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					DtIdtlPr.Columns.Add(MSG_UPI[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT A.* FROM UPI_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < RsIdtl.Rows.Count)
				{
					drPr = DtIdtlPr.NewRow();
					drPr[6] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
					drPr[0] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ISR_NO"]);
					drPr[1] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["UPI_AC_CODE"], (object)"");
					drPr[2] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["UPI_AC_NAME"], (object)"");
					drPr[3] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["UPI_TYPE"], (object)"");
					drPr[4] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["UPI_ID"], (object)"");
					drPr[5] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["UPI_AMT"])), "0.00");
					drPr[7] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["AC_CODE"], (object)"");
					DtIdtlPr.Rows.Add(drPr);
					DC_Main.i++;
				}
				MsgOldRowPr = 0;
				MSG_RowColChange(MSG, new EventArgs());
				DC_Main.RsQry = "SELECT A.MEMB_CODE FROM AD_OS AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.LD_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.MEMB_CODE = '" + MSG[1, 1] + "' AND A.SCHM_CODE = '" + tSchmCode.Text + "' AND CO_BOOK <> '076' ORDER BY A.SCHM_DATE ";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					CurTotInstallment = DC_Main.Tbl.Rows.Count;
				}
				MSG_TOT_FILL();
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				OldValTot = Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 6]);
				NewValTot = Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 6]);
				EntryMode = "E";
				MsVchSrno = "";
				((TextBoxBase)tVchNo).ReadOnly = true;
				((Control)mVchDate).Focus();
			}
			else
			{
				((Control)mVchDate).Focus();
				EntryMode = "A";
			}
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void TR_MEMB_ENT_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_MEMB_ENT_KeyPress(object sender, KeyPressEventArgs e)
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

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if ((Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0) & (Operators.CompareString(tEmpCode.Text, "", false) == 0))
		{
			Interaction.MsgBox((object)"Please Select Employee Code and Try......", (MsgBoxStyle)0, (object)null);
			((Control)tEmpCode).Focus();
			return;
		}
		if ((Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save This Voucher Becouse This Company Type is B......", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		((Control)BtnSave).Enabled = false;
		if ((DateTime.Compare(Conversions.ToDate(DC_Main.MCo_OpDate), Conversions.ToDate(mVchDate.Text)) > 0) | (DateTime.Compare(Conversions.ToDate(DC_Main.MCo_ClDate), Conversions.ToDate(mVchDate.Text)) < 0))
		{
			Interaction.MsgBox((object)"You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
		{
			Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (Operators.CompareString(UsUPdate, "Y", false) != 0 && ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0)))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (Operators.CompareString(tVchNo.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Insert VchNo and try", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		MSG_TOT_FILL();
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					Interaction.MsgBox((object)("Current Voucher No has been changd New Voucher No is  '" + Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000") + "'"), (MsgBoxStyle)0, (object)null);
					tVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
				}
			}
			DC_Main.RsQry = "SELECT * FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tHdVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
				}
			}
		}
		DC_Main.ExeQuteDc("DELETE FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		checked
		{
			if (Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 7]) != 0.0)
			{
				DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
				DC_Main.RsQry = "SELECT * FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.MsInsertData();
				DataRow dataRow = dataTable.NewRow();
				dataRow["CO_CODE"] = DC_Main.MCo_code;
				dataRow["LC_CODE"] = DC_Main.MLc_code;
				dataRow["CO_BOOK"] = DC_Main.MCo_Book;
				dataRow["VCH_NO"] = tHdVchNo.Text;
				dataRow["BOOK_NAME"] = FormName;
				dataTable.Rows.Add(dataRow);
				((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
				dataTable.Clear();
				DC_Main.RsQry = "SELECT * FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.MsInsertData();
				DataRow dataRow2 = RsData.NewRow();
				int num = MSG.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num)
				{
					AxMSFlexGrid mSG = MSG;
					if ((Operators.CompareString(mSG[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(mSG[DC_Main.i, 6]) + Conversion.Val(mSG[DC_Main.i, 8]) != 0.0))
					{
						dataRow2["CO_CODE"] = DC_Main.MCo_code;
						dataRow2["LC_CODE"] = DC_Main.MLc_code;
						dataRow2["CO_YEAR"] = DC_Main.MCo_year;
						dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow2["VCH_NO"] = tVchNo.Text;
						dataRow2["VCH_DATE"] = mVchDate.Text;
						dataRow2["VCH_TYPE"] = FormBookSname;
						dataRow2["INOUT_TYPE"] = FormBookInOut;
						if (Operators.CompareString(FormMainBook, "MEMB OPENING", false) == 0)
						{
							dataRow2["ENT_TYPE"] = "O";
						}
						else
						{
							dataRow2["ENT_TYPE"] = "E";
						}
						dataRow2["BOOK_NAME"] = FormMainBook;
						dataRow2["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
						if (DC_Main.i == 1)
						{
							PartyAcCode = mSG[DC_Main.i, 1];
						}
						dataRow2["SCHM_CODE"] = tSchmCode.Text;
						dataRow2["MEMB_CODE"] = mSG[DC_Main.i, 1];
						dataRow2["SCHM_DATE"] = mSG[DC_Main.i, 3];
						dataRow2["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 6]);
						dataRow2["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 7]);
						dataRow2["MEMB_AMT"] = Conversion.Val(mSG[DC_Main.i, 8]);
						dataRow2["TOT_AMT"] = 0;
						dataRow2["WITH_UPI"] = mSG[DC_Main.i, 4];
						dataRow2["REC_AC"] = mSG[DC_Main.i, 5];
						dataRow2["BANK_NAME"] = mSG[DC_Main.i, 11];
						dataRow2["CHQ_NO"] = mSG[DC_Main.i, 10];
						dataRow2["UPI_NAME"] = mSG[DC_Main.i, 14];
						dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
						dataRow2["EMP_CODE"] = tEmpCode.Text;
						dataRow2["IT_DESC"] = tVchDesc.Text;
						dataRow2["DATA_TRFR"] = "N";
						if (Operators.CompareString(DataTrfr, "Y", false) == 0)
						{
							dataRow2["RE_TRFR"] = "Y";
						}
						else
						{
							dataRow2["RE_TRFR"] = "N";
						}
						dataRow2["MAIN_USER"] = MainUser;
						dataRow2["USER_UPDATE"] = "N";
						dataRow2["USER_DELETE"] = "N";
						RsData.Rows.Add(dataRow2);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
						RsData.Clear();
					}
					mSG = null;
					DC_Main.i++;
				}
			}
			DC_Main.ExeQuteDc("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.RsQry = "SELECT * FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow3 = RsIdtl.NewRow();
			int num2 = 0;
			int num3 = DtIdtlPr.Rows.Count - 1;
			for (int i = 0; i <= num3; i++)
			{
				DataTable dtIdtlPr = DtIdtlPr;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][5])) != 0.0)
				{
					dataRow3["CO_CODE"] = DC_Main.MCo_code;
					dataRow3["LC_CODE"] = DC_Main.MLc_code;
					dataRow3["CO_YEAR"] = DC_Main.MCo_year;
					dataRow3["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow3["VCH_NO"] = tVchNo.Text;
					dataRow3["VCH_DATE"] = mVchDate.Text;
					dataRow3["SCHM_CODE"] = tSchmCode.Text;
					dataRow3["AC_CODE"] = MSG[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][6]))), 1];
					dataRow3["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][6]));
					dataRow3["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][0]));
					dataRow3["UPI_AC_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][1]);
					dataRow3["UPI_AC_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][2]);
					dataRow3["UPI_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][3]);
					dataRow3["UPI_ID"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][4]);
					dataRow3["UPI_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][5]));
					dataRow3["MAIN_USER"] = MainUser;
					RsIdtl.Rows.Add(dataRow3);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
					RsIdtl.Clear();
				}
				dtIdtlPr = null;
			}
			DC_Main.ExeQuteDc("DELETE FROM AD_OS WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			if (Operators.CompareString(FormMainBook, "MEMB OPENING", false) == 0)
			{
				Ac_Tax.SchemeOp_Os(DC_Main.MCo_Book, tVchNo.Text);
			}
			else
			{
				Ac_Tax.SchemeEnt_Os(DC_Main.MCo_Book, tVchNo.Text);
			}
			DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			if (Operators.CompareString(FormMainBook, "MEMB OPENING", false) != 0)
			{
				Ac_Ledr.Schm_Ledr(DC_Main.MCo_Book, tVchNo.Text);
			}
			DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			if (Operators.CompareString(FormMainBook, "MEMB OPENING", false) != 0)
			{
				Ac_Rojmel.Schm_RojMel(DC_Main.MCo_Book, tVchNo.Text);
			}
			Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 3);
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
				DataView dataView = new DataView(VchOldData);
				int num4 = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num4)
				{
					dataView.RowFilter = ("SR_NO = " + MSG[DC_Main.M, 0]) ?? "";
					if (dataView.Count > 0)
					{
						if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["MEMB_CODE"], (object)MSG[DC_Main.M, 1], false))
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO USER_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,VCH_DATE,EDIT_DATE,ENTRY_TIME,USER_NAME,NEW_USER,BOOK_NAME,COL_TYPE,OLD_VAL,NEW_VAL,ENTRY_CHECK)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "','" + tSchmCode.Text + "','" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy hh:mm") + "','" + MainUser + "','" + DC_Main.MCo_User + "','" + FormMainBook + "','M Code - Sr. " + MSG[DC_Main.M, 0] + "' ,'"), dataView[0]["MEMB_CODE"]), (object)"','"), (object)MSG[DC_Main.M, 1]), (object)"','N')"));
							DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						}
						if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["MEMB_AMT"], (object)Conversion.Val(MSG[DC_Main.M, 8]), false))
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO USER_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,VCH_DATE,EDIT_DATE,ENTRY_TIME,USER_NAME,NEW_USER,BOOK_NAME,COL_TYPE,OLD_VAL,NEW_VAL,ENTRY_CHECK)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "','" + tSchmCode.Text + "','" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy hh:mm") + "','" + MainUser + "','" + DC_Main.MCo_User + "','" + FormMainBook + "','M Amt - Sr. " + MSG[DC_Main.M, 0] + "','"), dataView[0]["MEMB_AMT"]), (object)"','"), (object)Conversion.Val(MSG[DC_Main.M, 8])), (object)"','N')"));
							DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						}
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataView[0]["REC_AC"])) != Conversion.Val(MSG[DC_Main.M, 5]))
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO USER_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,VCH_DATE,EDIT_DATE,ENTRY_TIME,USER_NAME,NEW_USER,BOOK_NAME,COL_TYPE,OLD_VAL,NEW_VAL,ENTRY_CHECK)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "','" + tSchmCode.Text + "','" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy hh:mm") + "','" + MainUser + "','" + DC_Main.MCo_User + "','" + FormMainBook + "','RecAc - Sr. " + MSG[DC_Main.M, 0] + "','"), dataView[0]["REC_AC"]), (object)"','"), (object)MSG[DC_Main.M, 5]), (object)"','N')"));
							DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						}
					}
					DC_Main.M++;
				}
			}
			if (Operators.CompareString(FormVchNo, "", false) != 0)
			{
				CLEAR_DATA();
				((Form)this).Close();
				return;
			}
			CurPrnVch = tVchNo.Text;
			DC_Main.MsAcBal(PartyAcCode, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
			CustOpAmt = DC_Main.MsAcAmtOpBal;
			CustClAmt = DC_Main.MsAcAmtClBal;
			DC_Main.RsQry = "SELECT A.MEMB_CODE FROM AD_OS AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.LD_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.MEMB_CODE = '" + MSG[1, 1] + "' AND A.SCHM_CODE = '" + tSchmCode.Text + "' AND CO_BOOK <> '076' ORDER BY A.SCHM_DATE ";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				CurTotInstallment = DC_Main.Tbl.Rows.Count;
			}
			CLEAR_DATA();
			BtnPrint_Click(BtnPrint, new EventArgs());
			CurPrnVch = "";
			CustOpAmt = 0.0;
			CustClAmt = 0.0;
			DC_Main.MsAcAmtOpBal = 0.0;
			DC_Main.MsAcAmtClBal = 0.0;
			DC_Main.MsAcGoldOpBal = 0.0;
			DC_Main.MsAcGoldClBal = 0.0;
			DC_Main.MsAcSilverOpBal = 0.0;
			DC_Main.MsAcSilverClBal = 0.0;
		}
	}

	private async void WappReport()
	{
		if (Operators.CompareString(((ButtonBase)MyProject.Forms.MDI_FORM.chkWappId).Text, "Whatsapp Open", false) == 0 || !((Operators.CompareString(DC_Main.MsWhatsAppOpen, "Y", false) == 0) & (Operators.CompareString(DC_Main.MsSchmWapp, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0)))
		{
			return;
		}
		DC_Main.RsQry = "Select SCHM_CODE,MEMB_CODE,MEMB_AMT,SCHM_DATE FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + CurPrnVch + "' ORDER BY SR_NO ";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.i = 0;
		checked
		{
			while (DC_Main.i < DC_Main.Tbl.Rows.Count)
			{
				string message = "";
				string text = "";
				DC_Main.RsQry = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SCHM_CODE = '"), DC_Main.Tbl.Rows[DC_Main.i]["SCHM_CODE"]), (object)"' AND MEMB_CODE = '"), DC_Main.Tbl.Rows[DC_Main.i]["MEMB_CODE"]), (object)"' AND AC_MOBILE <> ''")));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					message = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)" DEAR :", DC_Main.Rshlp.Rows[0]["MEMB_NAME"]), (object)" Your Monthly Saving Scheme Amount Rs : "), DC_Main.Tbl.Rows[DC_Main.i]["MEMB_AMT"]), (object)" Received With Month = "), (object)DateAndTime.Month(Conversions.ToDate(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["SCHM_DATE"])))), (object)"/"), (object)DateAndTime.Year(Conversions.ToDate(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["SCHM_DATE"])))), (object)" REGARD "), (object)DC_Main.MCo_Name), (object)" Have a Nice Day...")));
					text = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_MOBILE"], (object)"")));
				}
				try
				{
					if (Operators.CompareString(text, "", false) != 0)
					{
						MessageRequest val = new MessageRequest();
						val.Phone = DC_Main.MsCountryId + text;
						val.Message = message;
						val.AttachmentPath = "";
						MessageRequest request = val;
						object objectValue = RuntimeHelpers.GetObjectValue(await whatsApp.Send(request));
						lbrMsgShow.Text = Conversions.ToString(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, (Type)null, "Status", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Description", new object[0], (string[])null, (Type[])null, (bool[])null)));
						await Task.Run([SpecialName] async () =>
						{
							await Task.Delay(3000);
						});
						Application.DoEvents();
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Exception ex3 = ex2;
					MessageBox.Show(ex3.Message);
					ProjectData.ClearProjectError();
				}
				DC_Main.i++;
			}
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
		{
			Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(UsDelete, "Y", false) != 0 && Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,SR_NO,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  SUBSTRING(B.BOOK_NAME,1,20),A.MEMB_CODE,C.MEMB_NAME,0,A.MEMB_AMT,'A',0,0,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "',A.SCHM_CODE + '/' + SUBSTRING(IT_DESC,1,130)   FROM (AD_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AD_MEMB AS C ON A.CO_CODE = C.CO_CODE AND A.SCHM_CODE = C.SCHM_CODE AND A.MEMB_CODE = C.MEMB_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AD_OS WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_MEMB_ENT_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			if (OldValTot == NewValTot)
			{
				((Form)this).Close();
			}
			else if (((Control)TEXT_ENTRY).Visible)
			{
				MSG_LeaveCell(MSG, new EventArgs());
				MSG.Row = checked(MSG.Rows - 1);
				MSG.Col = 0;
				((Control)TEXT_ENTRY).Visible = false;
				MSG_TOT_FILL();
				((Control)tEmpCode).Focus();
			}
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(DC_Main.MsWhatsAppOpen, "Y", false) == 0)
		{
			WappReport();
		}
		((Form)MyProject.Forms.MS_PRINT).ShowDialog();
		if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)
		{
			lbrMsgShow.Text = "Whatsapp Msg";
			return;
		}
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SchmRecVch.RPT";
		string rptName = "SchmRecVch";
		Cr.SelectionFormula = "{AD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AD_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {AD_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AD_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {AD_DATA.VCH_NO} = '" + CurPrnVch + "'";
		Cr[(short)2] = ("TotalRecAmt = " + Strings.Format((object)CurTotInstallment, "0")) ?? "";
		if (chkWapp.Checked)
		{
			DC_Main.MsCustWappNo = "91" + MSG[1, 12];
			DC_Main.RptName = rptName;
			DC_Main.MsWappPrintType = "SchmEnt";
			DC_Main.MsWappOpAmt = Conversions.ToDouble(Strings.Format((object)CurTotInstallment, "0"));
			DC_Main.RptFormula = "{AD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AD_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {AD_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AD_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {AD_DATA.VCH_NO} = '" + CurPrnVch + "'";
			UT_REPORT uT_REPORT = new UT_REPORT();
			((Control)uT_REPORT).Show();
			((Control)uT_REPORT).Focus();
			return;
		}
		if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
		{
			if (DC_Main.MsPrintOg)
			{
				Cr[(short)1] = "InVoiceType = 'ORIGINAL FOR RECIPIENT'";
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
			if (DC_Main.MsPrintDup)
			{
				Cr[(short)1] = "InVoiceType = 'DUPLICATE FOR SUPPLIER'";
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
			if (DC_Main.MsPrintTrip)
			{
				Cr[(short)1] = "InVoiceType = 'TRIPLICATE FOR TRANSPORTER'";
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
		}
		else
		{
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
		CurTotInstallment = 0;
		DC_Main.MsPrintStatus = false;
		lbrMsgShow.Text = "Whatsapp Msg";
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CurTotInstallment = 0;
		CustOpAmt = 0.0;
		CustClAmt = 0.0;
		CLEAR_DATA();
	}

	private void TR_MEMB_ENT_Activated(object sender, EventArgs e)
	{
		DC_Main.MCo_Book = FormBook;
		DC_Main.MCo_BookType = FormBookType;
		lblBook.Text = FormName;
		if ((Operators.CompareString(FormVchNo, "", false) != 0) & (Operators.CompareString(DC_Main.CurBookVch, "", false) != 0))
		{
			DC_Main.CurBookVch = "";
			tVchNo.Text = FormVchNo;
			DISPLAY_DATA();
			Application.DoEvents();
			((Control)TEXT_ENTRY).Visible = false;
			((Control)mVchDate).Focus();
			return;
		}
		if (DC_Main.MsCreat)
		{
			DC_Main.MsCreat = false;
			TEXT_ENTRY.Text = DC_Main.MsCode;
			MSG[MSG.Row, 2] = DC_Main.MsName;
			DC_Main.MsCode = "";
			DC_Main.MsName = "";
		}
		((ContainerControl)this).ActiveControl = CurActCtrl;
		CurActCtrl.Focus();
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.SCHM_CODE As SchemeL,A.VCH_NO AS VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL ,A.MEMB_CODE As MCodeL,B.MEMB_NAME As MembAmtL,A.MAIN_USER As UserL,Sum(A.MEMB_AMT) AS VchAmountR,A.CO_BOOK As BookL FROM AD_DATA AS A LEFT JOIN AD_MEMB AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.SCHM_CODE = B.SCHM_CODE AND A.MEMB_CODE = B.MEMB_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  GROUP BY A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.SCHM_CODE,A.MEMB_CODE,B.MEMB_NAME,A.MAIN_USER ORDER BY A.VCH_NO ";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[9];
		DC_Main.ColWidth[0] = 80.0;
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[2] = 120.0;
		DC_Main.ColWidth[3] = 90.0;
		DC_Main.ColWidth[4] = 225.0;
		DC_Main.ColWidth[5] = 100.0;
		DC_Main.ColWidth[6] = 120.0;
		DC_Main.ColWidth[7] = 0.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tVchNo.Text = DC_Main.ColValue[1];
				DISPLAY_DATA();
				((Control)mVchDate).Focus();
			}
			else
			{
				((Control)tVchNo).Focus();
			}
		}
	}

	private void MSG_RowColChange(object sender, EventArgs e)
	{
		if (MSG.Row == 0 || MsgOldRow == MSG.Row)
		{
			return;
		}
		MsgOldRow = MSG.Row;
		tBankName.Text = MSG[MSG.Row, 11];
		tChqNo.Text = MSG[MSG.Row, 10];
		nMembAmt.Text = Strings.Format((object)Conversion.Val(MSG[MSG.Row, 13]), "0.00");
		MSG_UPI_CLEAR();
		int num = 1;
		checked
		{
			int num2 = DtIdtlPr.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Conversion.Val(MSG[MSG.Row, 0]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][6])))
				{
					MSG_UPI[num, 0] = Conversions.ToString(num);
					MSG_UPI[num, 1] = Conversions.ToString(DtIdtlPr.Rows[i][1]);
					MSG_UPI[num, 2] = Conversions.ToString(DtIdtlPr.Rows[i][2]);
					MSG_UPI[num, 3] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][3], (object)""));
					MSG_UPI[num, 4] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][4], (object)""));
					MSG_UPI[num, 5] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][5], (object)""));
					MSG_UPI[num, 6] = Conversions.ToString(DtIdtlPr.Rows[i][6]);
					MSG_UPI.Rows += 1;
					num++;
				}
			}
			MSG_UPI[num, 0] = Conversions.ToString(num);
			MSG_UPI[num, 6] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 0]));
		}
	}

	private void tVchNo_DoubleClick(object sender, EventArgs e)
	{
		((TextBoxBase)tVchNo).ReadOnly = false;
	}

	private void TVchNo_TextChanged(object sender, EventArgs e)
	{
	}

	private void tVchNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Invalid comparison between Unknown and I4
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			BtnF1_Click(BtnF1, new EventArgs());
		}
		if ((int)e.KeyCode == 38)
		{
			BtnLast_Click(BtnLast, new EventArgs());
		}
		if ((int)e.KeyCode == 40)
		{
			BtnFirst_Click(BtnFirst, new EventArgs());
		}
		if ((int)e.KeyCode == 13)
		{
			DISPLAY_DATA();
		}
	}

	private void mVchDate_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mVchDate).SelectionStart = 0;
		((TextBoxBase)mVchDate).SelectionLength = Strings.Len(mVchDate.Text);
	}

	private void mVchDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Invalid comparison between Unknown and I4
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		if (((int)e.KeyCode == 112) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			DC_Main.MsReqBook = DC_Main.MCo_Book;
			DC_Main.MsReqVch = tVchNo.Text;
			DC_Main.MsReqUser = DC_Main.MCo_User;
			DC_Main.MsReqAc = "";
			((Form)MyProject.Forms.UT_USER_REQUEST).ShowDialog();
		}
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mVchDate;
			DC_Main.SetDate(ref MsDate);
			mVchDate = MsDate;
			if (!DC_Main.RongDate)
			{
				TodayFineRate();
				SendKeys.Send("{tab}");
			}
		}
	}

	private void BtnFirst_Click(object sender, EventArgs e)
	{
		if (Conversion.Val(tVchNo.Text) < 2.0)
		{
			return;
		}
		string text = Strings.Format((object)(Conversion.Val(tVchNo.Text) - 1.0), "00000");
		DC_Main.i = 1;
		checked
		{
			do
			{
				DC_Main.RsQry = "SELECT VCH_NO FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count != 0 || Conversion.Val(text) == 1.0)
				{
					break;
				}
				text = Strings.Format((object)(Conversion.Val(text) - 1.0), "00000");
				DC_Main.i++;
			}
			while (DC_Main.i <= 10);
			CLEAR_DATA();
			tVchNo.Text = text;
			DISPLAY_DATA();
			((Control)tVchNo).Focus();
		}
	}

	private void BtnLast_Click(object sender, EventArgs e)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (Conversion.Val(tVchNo.Text) >= Conversion.Val(LastVchNo))
		{
			Interaction.MsgBox((object)"Last Record...", (MsgBoxStyle)0, (object)null);
			((Control)tVchNo).Focus();
			return;
		}
		string text = Strings.Format((object)(Conversions.ToDouble(tVchNo.Text) + 1.0), "00000");
		DC_Main.i = 1;
		checked
		{
			do
			{
				DC_Main.RsQry = "SELECT VCH_NO FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count != 0 || Conversion.Val(text) == Conversion.Val(LastVchNo))
				{
					break;
				}
				text = Strings.Format((object)(Conversion.Val(text) + 1.0), "00000");
				DC_Main.i++;
			}
			while (DC_Main.i <= 10);
			CLEAR_DATA();
			tVchNo.Text = text;
			DISPLAY_DATA();
			((Control)tVchNo).Focus();
		}
	}

	private void MSG_Scroll(object sender, EventArgs e)
	{
		if (MSG_TOT.LeftCol != MSG.LeftCol)
		{
			MSG_TOT.LeftCol = MSG.LeftCol;
			MSG_TOT.ScrollTrack = MSG.LeftCol != 0;
		}
	}

	private void TR_MEMB_ENT_Closed(object sender, EventArgs e)
	{
		FormVchNo = "";
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
		}
		else
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;
		}
	}

	private void tEmpCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND EMP_CODE = '" + tEmpCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT EMP_NAME As EmpNameL,EMP_CODE As EmpL FROM EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY EMP_NAME";
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
					tEmpCode.Text = DC_Main.ColValue[1];
					tEmpName.Text = DC_Main.ColValue[0];
				}
				((Control)tEmpCode).Focus();
			}
		}
		else
		{
			tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["EMP_NAME"], (object)""));
			SendKeys.Send("{tab}");
		}
	}

	private void tVchDesc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void lblBook_DoubleClick(object sender, EventArgs e)
	{
		((Control)tHdVchNo).Visible = true;
	}

	private void tSchmCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND SCHM_CODE = '" + tSchmCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT SCHM_CODE as SchmCode,SCHM_NAME As SchemeNameL,SCHM_AMT AS SchmAmtR,SCHM_TYPE As SchmTypeM FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY SCHM_CODE";
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
					tSchmCode.Text = DC_Main.ColValue[0];
					tSchmName.Text = DC_Main.ColValue[1];
					tSchmType.Text = DC_Main.ColValue[3];
				}
				((Control)tSchmCode).Focus();
			}
		}
		else
		{
			tSchmName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SCHM_NAME"], (object)""));
			nSchmAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["SCHM_AMT"]), "0.00");
			tSchmType.Text = Conversions.ToString(DC_Main.Tbl.Rows[0]["SCHM_TYPE"]);
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				MSG_CLEAR();
			}
			MSG.Col = 1;
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void TEXT_ENTRY_KeyUp(object sender, KeyEventArgs e)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Invalid comparison between Unknown and I4
		if (MSG.Col == 3 && (int)e.KeyCode != 8)
		{
			if (Strings.Len(TEXT_ENTRY.Text) == 2)
			{
				TEXT_ENTRY.Text += "/";
			}
			else if (Strings.Len(TEXT_ENTRY.Text) == 5)
			{
				TEXT_ENTRY.Text += "/";
			}
			((TextBoxBase)TEXT_ENTRY).SelectionStart = Strings.Len(TEXT_ENTRY.Text);
		}
	}

	private void tBankName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MSG[MSG.Row, 11] = tBankName.Text;
			((Control)tChqNo).Focus();
		}
	}

	private void tChqNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MSG[MSG.Row, 10] = tChqNo.Text;
			if (MSG[7] == 0)
			{
				MSG.Col = 8;
			}
			else
			{
				MSG.Col = 6;
			}
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void TQrCane_TextChanged(object sender, EventArgs e)
	{
		if (Operators.CompareString(tQrCane.Text, "", false) == 0)
		{
			return;
		}
		DC_Main.RsQry = "SELECT * FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '" + Strings.Mid(tQrCane.Text, 1, 3) + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			tSchmCode.Text = Strings.Mid(tQrCane.Text, 1, 3);
			tSchmName.Text = Conversions.ToString(DC_Main.Tbl.Rows[0]["SCHM_NAME"]);
		}
		DC_Main.RsQry = "SELECT * FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SCHM_CODE = '" + tSchmCode.Text + "' AND MEMB_CODE = '" + Strings.Mid(tQrCane.Text, 4, Strings.Len(tQrCane.Text)) + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			DC_Main.i = MSG.Rows - 1;
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				AxMSFlexGrid mSG = MSG;
				mSG[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MEMB_CODE"], (object)""));
				if (DC_Main.i == 1)
				{
					PartyAcCode = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MEMB_CODE"], (object)""));
				}
				mSG[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MEMB_NAME"], (object)""));
				mSG[DC_Main.i, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["MEMB_AMT"])), "0.00");
				mSG[DC_Main.i, 5] = "00001";
				mSG[DC_Main.i, 3] = mVchDate.Text;
				mSG[DC_Main.i, 9] = "A";
				mSG.Rows += 1;
				DC_Main.i++;
				mSG[DC_Main.i, 0] = Conversions.ToString(DC_Main.i);
				mSG[DC_Main.i, 5] = "00001";
				mSG = null;
				MSG_TOT_FILL();
				MSG.Col = 1;
				MSG.Row = 2;
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
			}
		}
	}

	private void TR_MEMB_ENT_KeyUp(object sender, KeyEventArgs e)
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

	private void BtnPassBook_Click(object sender, EventArgs e)
	{
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		DC_Main.ExeQuteDc("DELETE FROM TEMP_AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		checked
		{
			int num = (int)Math.Round(Conversion.Val(nLineSkip.Text));
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				DC_Main.RsQry = "INSERT INTO TEMP_AD_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,SCHM_DATE,  SCHM_CODE,MEMB_CODE,REC_AC,ITM_GWT,ITM_RATE,REC_AMT,BAL_AMT,CHQ_NO)   VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','000','00000',0,Null,Null,  '','','',0,0,0,0,'')";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Cr[(short)0] = "HeaderPrint = 'N'";
				DC_Main.i++;
			}
			DC_Main.i = 0;
			int num2 = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num2)
			{
				if (Operators.CompareString(tSchmCode.Text, "", false) != 0 && Operators.CompareString(MSG[DC_Main.i, 1], "", false) != 0)
				{
					string[] obj = new string[31]
					{
						"INSERT INTO TEMP_AD_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,SCHM_DATE,  SCHM_CODE,MEMB_CODE,REC_AC,ITM_GWT,ITM_RATE,REC_AMT,BAL_AMT,CHQ_NO)   VALUES('",
						DC_Main.MCo_code,
						"','",
						DC_Main.MLc_code,
						"','",
						DC_Main.MCo_year,
						"','",
						DC_Main.MCo_Book,
						"','",
						tVchNo.Text,
						"',",
						Conversions.ToString(DC_Main.i + 1),
						",'",
						Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy"),
						"','",
						Strings.Format((object)Conversions.ToDate(MSG[DC_Main.i, 3]), "MM/dd/yyyy"),
						"',  '",
						tSchmCode.Text,
						"','",
						MSG[DC_Main.i, 1],
						"','",
						MSG[DC_Main.i, 5],
						"',",
						null,
						null,
						null,
						null,
						null,
						null,
						null,
						null
					};
					object Value = MSG[DC_Main.i, 7];
					obj[23] = Conversions.ToString(DC_Main.Fnv(ref Value));
					obj[24] = ",";
					Value = MSG[DC_Main.i, 6];
					obj[25] = Conversions.ToString(DC_Main.Fnv(ref Value));
					obj[26] = ",";
					Value = MSG[DC_Main.i, 8];
					obj[27] = Conversions.ToString(DC_Main.Fnv(ref Value));
					obj[28] = ",0,'";
					obj[29] = MSG[DC_Main.i, 10];
					obj[30] = "')";
					DC_Main.RsQry = string.Concat(obj);
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.i++;
			}
			DC_Main.RsQry = "SELECT * FROM TEMP_AD_DATA";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SchmPassBook.RPT";
			Cr.SelectionFormula = "{TEMP_AD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' ";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom((short)DC_Main.MsPrintZoom);
			CurTotInstallment = 0;
		}
	}

	private void tVchDesc_DoubleClick(object sender, EventArgs e)
	{
		((Control)BtnSave).Enabled = true;
	}

	private void tSchmCode_TextChanged(object sender, EventArgs e)
	{
	}
}
