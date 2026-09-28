using System;
using System.Collections;
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
public class TR_LOCT_AMT : Form
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
	[AccessedThroughProperty("btnChqPrint")]
	private SimpleButton _btnChqPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItDesc")]
	private TextBox _tItDesc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tFrmLc")]
	private TextBox _tFrmLc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tToLcCode")]
	private TextBox _tToLcCode;

	private Module_WhatsApp whatsApp;

	private string UsUPdate;

	private string UsDelete;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private int CurRow;

	private double CustOpAmt;

	private double CustClAmt;

	private string PartyAcCode;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private double OldValTot;

	private double NewValTot;

	private string MsVchSrno;

	private DataTable RsData;

	private DataTable RsDetl;

	private DataTable RsIdtl;

	private int FilRow;

	private DataTable DtIdtl;

	private DataRow dr;

	private bool Msgleft;

	private bool UpDown;

	private bool MsTxtDelete;

	private string FormBook;

	private string FormName;

	private string FormBookType;

	private string FormItmType;

	private string FormVchNo;

	private string FormMainBook;

	private string FormBookSname;

	private string FormBookInOut;

	private string MaxVchNo;

	private string LastVchNo;

	private const int cSrNo = 0;

	private const int cAcCode = 1;

	private const int cAcName = 2;

	private const int cChqNo = 3;

	private const int cRecAmt = 4;

	private const int cEntryMod = 5;

	private const int cItDesc = 6;

	private const int cOldSrNo = 7;

	private const int cMobileNo = 8;

	private const int cKasarAmt = 9;

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
			EventHandler eventHandler4 = MSG_Scroll;
			EventHandler eventHandler5 = MSG_RowColChange;
			AxMSFlexGrid val = _MSG;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
				val.Scroll -= eventHandler4;
				val.RowColChange -= eventHandler5;
			}
			_MSG = value;
			val = _MSG;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
				val.Scroll += eventHandler4;
				val.RowColChange += eventHandler5;
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
			EventHandler eventHandler = TEXT_ENTRY_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_ENTRY_KeyDown);
			TextBox val2 = _TEXT_ENTRY;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_ENTRY = value;
			val2 = _TEXT_ENTRY;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
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
	[AccessedThroughProperty("LOpAmt")]
	private virtual Label _LOpAmt;

	internal virtual Label LOpAmt
	{
		get
		{
			return _LOpAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LOpAmt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LBookAmt")]
	private virtual Label _LBookAmt;

	internal virtual Label LBookAmt
	{
		get
		{
			return _LBookAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LBookAmt = value;
		}
	}

	internal virtual SimpleButton btnChqPrint
	{
		[CompilerGenerated]
		get
		{
			return _btnChqPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnChqPrint_Click;
			SimpleButton val = _btnChqPrint;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnChqPrint = value;
			val = _btnChqPrint;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual TextBox tItDesc
	{
		[CompilerGenerated]
		get
		{
			return _tItDesc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tItDesc_KeyDown);
			EventHandler eventHandler = tItDesc_GotFocus;
			EventHandler eventHandler2 = tItDesc_DoubleClick;
			TextBox val2 = _tItDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).DoubleClick -= eventHandler2;
			}
			_tItDesc = value;
			val2 = _tItDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
				((Control)val2).DoubleClick += eventHandler2;
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
	[AccessedThroughProperty("tFrombook")]
	private virtual TextBox _tFrombook;

	internal virtual TextBox tFrombook
	{
		get
		{
			return _tFrombook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tFrombook = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tToBook")]
	private virtual TextBox _tToBook;

	internal virtual TextBox tToBook
	{
		get
		{
			return _tToBook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tToBook = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tFromVchNo")]
	private virtual TextBox _tFromVchNo;

	internal virtual TextBox tFromVchNo
	{
		get
		{
			return _tFromVchNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tFromVchNo = value;
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
	[AccessedThroughProperty("tToVchNo")]
	private virtual TextBox _tToVchNo;

	internal virtual TextBox tToVchNo
	{
		get
		{
			return _tToVchNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tToVchNo = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tFromLcName")]
	private virtual TextBox _tFromLcName;

	internal virtual TextBox tFromLcName
	{
		get
		{
			return _tFromLcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tFromLcName = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lFromLc")]
	private virtual Label _lFromLc;

	internal virtual Label lFromLc
	{
		get
		{
			return _lFromLc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lFromLc = value;
		}
	}

	internal virtual TextBox tFrmLc
	{
		[CompilerGenerated]
		get
		{
			return _tFrmLc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tFrmLc_KeyDown);
			TextBox val2 = _tFrmLc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tFrmLc = value;
			val2 = _tFrmLc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tToLcCode
	{
		[CompilerGenerated]
		get
		{
			return _tToLcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tToLcCode_KeyDown);
			TextBox val2 = _tToLcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tToLcCode = value;
			val2 = _tToLcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tToLcName")]
	private virtual TextBox _tToLcName;

	internal virtual TextBox tToLcName
	{
		get
		{
			return _tToLcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tToLcName = value;
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

	public TR_LOCT_AMT()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_LOCT_AMT_Load;
		((Form)this).Deactivate += TR_LOCT_AMT_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_LOCT_AMT_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_LOCT_AMT_KeyDown);
		((Form)this).Activated += TR_LOCT_AMT_Activated;
		((Form)this).Closed += TR_LOCT_AMT_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_LOCT_AMT_KeyUp);
		whatsApp = UT_WHATSAPP.whatsApp;
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
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Expected O, but got Unknown
		//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Expected O, but got Unknown
		//IL_0489: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Expected O, but got Unknown
		//IL_053e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0548: Expected O, but got Unknown
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d6: Expected O, but got Unknown
		//IL_066e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0678: Expected O, but got Unknown
		//IL_0707: Unknown result type (might be due to invalid IL or missing references)
		//IL_0711: Expected O, but got Unknown
		//IL_0774: Unknown result type (might be due to invalid IL or missing references)
		//IL_077e: Expected O, but got Unknown
		//IL_0827: Unknown result type (might be due to invalid IL or missing references)
		//IL_0831: Expected O, but got Unknown
		//IL_0894: Unknown result type (might be due to invalid IL or missing references)
		//IL_089e: Expected O, but got Unknown
		//IL_0947: Unknown result type (might be due to invalid IL or missing references)
		//IL_0951: Expected O, but got Unknown
		//IL_0a6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a78: Expected O, but got Unknown
		//IL_0b83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8d: Expected O, but got Unknown
		//IL_0bf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfa: Expected O, but got Unknown
		//IL_0da3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e06: Expected O, but got Unknown
		//IL_0e69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e73: Expected O, but got Unknown
		//IL_0f85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8f: Expected O, but got Unknown
		//IL_1087: Unknown result type (might be due to invalid IL or missing references)
		//IL_1091: Expected O, but got Unknown
		//IL_11a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ac: Expected O, but got Unknown
		//IL_1253: Unknown result type (might be due to invalid IL or missing references)
		//IL_125d: Expected O, but got Unknown
		//IL_12be: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c8: Expected O, but got Unknown
		//IL_134a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1354: Expected O, but got Unknown
		//IL_142c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1436: Expected O, but got Unknown
		//IL_14d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_14dc: Expected O, but got Unknown
		//IL_1617: Unknown result type (might be due to invalid IL or missing references)
		//IL_1621: Expected O, but got Unknown
		//IL_1685: Unknown result type (might be due to invalid IL or missing references)
		//IL_168f: Expected O, but got Unknown
		//IL_1733: Unknown result type (might be due to invalid IL or missing references)
		//IL_173d: Expected O, but got Unknown
		//IL_17ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c4: Expected O, but got Unknown
		//IL_184c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1856: Expected O, but got Unknown
		//IL_1907: Unknown result type (might be due to invalid IL or missing references)
		//IL_1911: Expected O, but got Unknown
		//IL_19c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d2: Expected O, but got Unknown
		//IL_1a83: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a8d: Expected O, but got Unknown
		//IL_1b2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b38: Expected O, but got Unknown
		//IL_1be9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf3: Expected O, but got Unknown
		//IL_1cb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cbe: Expected O, but got Unknown
		//IL_1d59: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d63: Expected O, but got Unknown
		//IL_1dfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e08: Expected O, but got Unknown
		//IL_1e8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e99: Expected O, but got Unknown
		//IL_1f43: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f4d: Expected O, but got Unknown
		//IL_200b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2015: Expected O, but got Unknown
		//IL_20b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_20ba: Expected O, but got Unknown
		//IL_214b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2155: Expected O, but got Unknown
		//IL_2213: Unknown result type (might be due to invalid IL or missing references)
		//IL_221d: Expected O, but got Unknown
		//IL_22a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_22b1: Expected O, but got Unknown
		//IL_233b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2345: Expected O, but got Unknown
		//IL_23d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_23e0: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_LOCT_AMT));
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
		btnChqPrint = new SimpleButton();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		BtnLast = new SimpleButton();
		BtnFirst = new SimpleButton();
		TEXT_ENTRY = new TextBox();
		MSG_TOT = new AxMSFlexGrid();
		MSG = new AxMSFlexGrid();
		DlgOpen = new OpenFileDialog();
		BtnF1 = new SimpleButton();
		Cr = new AxCrystalReport();
		tHdVchNo = new TextBox();
		tEmpCode = new TextBox();
		tEmpName = new TextBox();
		Label3 = new Label();
		LOpAmt = new Label();
		LBookAmt = new Label();
		tItDesc = new TextBox();
		Label4 = new Label();
		lbrMsgShow = new Label();
		tFrombook = new TextBox();
		tToBook = new TextBox();
		tFromVchNo = new TextBox();
		Label6 = new Label();
		Label5 = new Label();
		tToVchNo = new TextBox();
		tFromLcName = new TextBox();
		lFromLc = new Label();
		tFrmLc = new TextBox();
		tToLcCode = new TextBox();
		tToLcName = new TextBox();
		Label1 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
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
		lblBook.Text = "Location Amount";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mVchDate).Location = new Point(110, 80);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 22);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(30, 80);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)16;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(32, 48);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(63, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tVchNo).Location = new Point(110, 47);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 22);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mDay).Location = new Point(192, 47);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 22);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mTime).Location = new Point(192, 80);
		((TextBoxBase)mTime).MaxLength = 8;
		((Control)mTime).Name = "mTime";
		((TextBoxBase)mTime).ReadOnly = true;
		((Control)mTime).Size = new Size(83, 22);
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
		((Control)PnlBotam).Controls.Add((Control)(object)btnChqPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnLast);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnFirst);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 7;
		((BaseStyleControl)btnChqPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnChqPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnChqPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnChqPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnChqPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnChqPrint.ImageOptions.SvgImage");
		((Control)btnChqPrint).Location = new Point(730, 3);
		((BaseControl)btnChqPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnChqPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnChqPrint).Name = "btnChqPrint";
		((Control)btnChqPrint).Size = new Size(91, 37);
		((Control)btnChqPrint).TabIndex = 28;
		btnChqPrint.Text = "C&hq";
		((BaseButton)btnChqPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)btnChqPrint).Visible = false;
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(246, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(478, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((BaseStyleControl)BtnLast).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnLast).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnLast).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnLast).Appearance.Options.UseForeColor = true;
		((Control)BtnLast).Location = new Point(199, 3);
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
		((Control)BtnFirst).Location = new Point(152, 3);
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
		((Control)TEXT_ENTRY).Location = new Point(545, 196);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 4;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)MSG_TOT).Location = new Point(110, 383);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(954, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(110, 116);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1000, 264);
		((Control)MSG).TabIndex = 1135;
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
		((Control)BtnF1).Location = new Point(279, 46);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(35, 23);
		((Control)BtnF1).TabIndex = 1149;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Voucher Help";
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1176, 402);
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
		((Control)tHdVchNo).TabIndex = 1159;
		((Control)tHdVchNo).Visible = false;
		((TextBoxBase)tEmpCode).BackColor = Color.White;
		((Control)tEmpCode).Font = new Font("Tahoma", 9f);
		((Control)tEmpCode).Location = new Point(191, 486);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(57, 22);
		((Control)tEmpCode).TabIndex = 6;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tEmpName).Location = new Point(254, 486);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(236, 22);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(94, 485);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(83, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)LOpAmt).BackColor = Color.Transparent;
		((Control)LOpAmt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpAmt.ImeMode = (ImeMode)0;
		((Control)LOpAmt).Location = new Point(930, 406);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(180, 20);
		((Control)LOpAmt).TabIndex = 1207;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)LBookAmt).BackColor = Color.Transparent;
		((Control)LBookAmt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LBookAmt).ForeColor = Color.Black;
		LBookAmt.ImeMode = (ImeMode)0;
		((Control)LBookAmt).Location = new Point(933, 47);
		((Control)LBookAmt).Name = "LBookAmt";
		((Control)LBookAmt).Size = new Size(177, 20);
		((Control)LBookAmt).TabIndex = 1208;
		LBookAmt.Text = "Balance";
		LBookAmt.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tItDesc).BackColor = Color.White;
		((Control)tItDesc).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tItDesc).Location = new Point(191, 407);
		((TextBoxBase)tItDesc).MaxLength = 240;
		tItDesc.Multiline = true;
		((Control)tItDesc).Name = "tItDesc";
		tItDesc.ScrollBars = (ScrollBars)2;
		((Control)tItDesc).Size = new Size(535, 71);
		((Control)tItDesc).TabIndex = 5;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(98, 406);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(83, 20);
		((Control)Label4).TabIndex = 1212;
		Label4.Text = "It Desc";
		Label4.TextAlign = (ContentAlignment)64;
		((Control)lbrMsgShow).BackColor = Color.Transparent;
		((Control)lbrMsgShow).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lbrMsgShow).ForeColor = Color.Black;
		lbrMsgShow.ImeMode = (ImeMode)0;
		((Control)lbrMsgShow).Location = new Point(985, 438);
		((Control)lbrMsgShow).Name = "lbrMsgShow";
		((Control)lbrMsgShow).Size = new Size(125, 20);
		((Control)lbrMsgShow).TabIndex = 1215;
		lbrMsgShow.Text = "Whatsapp Msg";
		lbrMsgShow.TextAlign = (ContentAlignment)64;
		((Control)lbrMsgShow).Visible = false;
		((TextBoxBase)tFrombook).BackColor = Color.White;
		((Control)tFrombook).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tFrombook).Location = new Point(844, 47);
		((TextBoxBase)tFrombook).MaxLength = 3;
		((Control)tFrombook).Name = "tFrombook";
		((TextBoxBase)tFrombook).ReadOnly = true;
		((Control)tFrombook).Size = new Size(60, 23);
		((Control)tFrombook).TabIndex = 1227;
		((Control)tFrombook).Visible = false;
		((TextBoxBase)tToBook).BackColor = Color.White;
		((Control)tToBook).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tToBook).Location = new Point(844, 80);
		((TextBoxBase)tToBook).MaxLength = 3;
		((Control)tToBook).Name = "tToBook";
		((TextBoxBase)tToBook).ReadOnly = true;
		((Control)tToBook).Size = new Size(60, 23);
		((Control)tToBook).TabIndex = 1226;
		((Control)tToBook).Visible = false;
		((TextBoxBase)tFromVchNo).BackColor = Color.White;
		((Control)tFromVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tFromVchNo).Location = new Point(762, 47);
		((TextBoxBase)tFromVchNo).MaxLength = 8;
		((Control)tFromVchNo).Name = "tFromVchNo";
		((TextBoxBase)tFromVchNo).ReadOnly = true;
		((Control)tFromVchNo).Size = new Size(76, 23);
		((Control)tFromVchNo).TabIndex = 1225;
		((Control)tFromVchNo).Visible = false;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(664, 48);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(92, 20);
		((Control)Label6).TabIndex = 1224;
		Label6.Text = "From VchNo";
		Label6.TextAlign = (ContentAlignment)64;
		((Control)Label6).Visible = false;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(673, 81);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(80, 20);
		((Control)Label5).TabIndex = 1223;
		Label5.Text = "TrFrVchNo";
		Label5.TextAlign = (ContentAlignment)64;
		((Control)Label5).Visible = false;
		((TextBoxBase)tToVchNo).BackColor = Color.White;
		((Control)tToVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tToVchNo).Location = new Point(762, 80);
		((TextBoxBase)tToVchNo).MaxLength = 8;
		((Control)tToVchNo).Name = "tToVchNo";
		((TextBoxBase)tToVchNo).ReadOnly = true;
		((Control)tToVchNo).Size = new Size(76, 23);
		((Control)tToVchNo).TabIndex = 1222;
		((Control)tToVchNo).Visible = false;
		((TextBoxBase)tFromLcName).BackColor = Color.White;
		((Control)tFromLcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tFromLcName).Location = new Point(445, 47);
		((TextBoxBase)tFromLcName).MaxLength = 8;
		((Control)tFromLcName).Name = "tFromLcName";
		((Control)tFromLcName).Size = new Size(210, 23);
		((Control)tFromLcName).TabIndex = 1221;
		((Control)tFromLcName).Visible = false;
		((Control)lFromLc).BackColor = Color.Transparent;
		((Control)lFromLc).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lFromLc).ForeColor = Color.Black;
		lFromLc.ImeMode = (ImeMode)0;
		((Control)lFromLc).Location = new Point(322, 48);
		((Control)lFromLc).Name = "lFromLc";
		((Control)lFromLc).Size = new Size(61, 20);
		((Control)lFromLc).TabIndex = 1220;
		lFromLc.Text = "From Lc";
		lFromLc.TextAlign = (ContentAlignment)16;
		((Control)lFromLc).Visible = false;
		((TextBoxBase)tFrmLc).BackColor = Color.White;
		((Control)tFrmLc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tFrmLc).Location = new Point(389, 47);
		((TextBoxBase)tFrmLc).MaxLength = 2;
		((Control)tFrmLc).Name = "tFrmLc";
		((Control)tFrmLc).Size = new Size(50, 23);
		((Control)tFrmLc).TabIndex = 2;
		((Control)tFrmLc).Visible = false;
		((TextBoxBase)tToLcCode).BackColor = Color.White;
		((Control)tToLcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tToLcCode).Location = new Point(389, 80);
		((TextBoxBase)tToLcCode).MaxLength = 2;
		((Control)tToLcCode).Name = "tToLcCode";
		((Control)tToLcCode).Size = new Size(50, 23);
		((Control)tToLcCode).TabIndex = 3;
		((Control)tToLcCode).Visible = false;
		((TextBoxBase)tToLcName).BackColor = Color.White;
		((Control)tToLcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tToLcName).Location = new Point(445, 80);
		((TextBoxBase)tToLcName).MaxLength = 8;
		((Control)tToLcName).Name = "tToLcName";
		((Control)tToLcName).Size = new Size(210, 23);
		((Control)tToLcName).TabIndex = 1219;
		((Control)tToLcName).Visible = false;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(321, 81);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(58, 20);
		((Control)Label1).TabIndex = 1218;
		Label1.Text = "Trfr Lc";
		Label1.TextAlign = (ContentAlignment)16;
		((Control)Label1).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)tFrombook);
		((Control)this).Controls.Add((Control)(object)tToBook);
		((Control)this).Controls.Add((Control)(object)tFromVchNo);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tToVchNo);
		((Control)this).Controls.Add((Control)(object)tFromLcName);
		((Control)this).Controls.Add((Control)(object)lFromLc);
		((Control)this).Controls.Add((Control)(object)tFrmLc);
		((Control)this).Controls.Add((Control)(object)tToLcCode);
		((Control)this).Controls.Add((Control)(object)tToLcName);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)lbrMsgShow);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)tItDesc);
		((Control)this).Controls.Add((Control)(object)LBookAmt);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
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
		((Control)this).Name = "TR_LOCT_AMT";
		((Form)this).Text = "Location Amount";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 10;
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
			mSG[1] = (int)Math.Round(1500.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "AcCode";
			mSG[2] = (int)Math.Round(4500.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "Ac Name";
			mSG[3] = (int)Math.Round(1500.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "Chq No";
			mSG[6] = (int)Math.Round(4500.0 * ColCon);
			mSG[6] = 0;
			mSG[0, 6] = "Remark";
			mSG[9] = 0;
			mSG[9] = 7;
			mSG[0, 9] = "Kasar";
			mSG[4] = (int)Math.Round(1600.0 * ColCon);
			mSG[4] = 7;
			mSG[0, 4] = "Amount";
			mSG[5] = 0;
			mSG[7] = 0;
			mSG[8] = 0;
			mSG.Row = 1;
			mSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			MsgLastCol = 9;
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
					mSG_TOT[0, 4] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 4]) + Conversion.Val(MSG[DC_Main.M, 4]))), "0.00");
					mSG_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 9]) + Conversion.Val(MSG[DC_Main.M, 9]))), "0.000");
					DC_Main.M++;
				}
				mSG_TOT = null;
				NewValTot = Conversion.Val(MSG_TOT[0, 4]) + Conversion.Val(MSG_TOT[0, 9]);
			}
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG[mSG.Row, 5] = "A";
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
				case 6:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 240;
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
				case 4:
				case 9:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
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
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 0:
			case 2:
			case 3:
			case 6:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 4:
			case 9:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
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
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				AxMSFlexGrid mSG;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000c;
				case 71:
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
							goto IL_0016;
						case 4:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 5:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_000c:
					num2 = 2;
					mSG = MSG;
					goto IL_0016;
					IL_0016:
					mSG = null;
					break;
					end_IL_0001_2:
					break;
				}
				num2 = 4;
				MSG_TOT_FILL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 71;
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
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Invalid comparison between Unknown and I4
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Invalid comparison between Unknown and I4
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Invalid comparison between Unknown and I4
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Invalid comparison between Unknown and I4
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Invalid comparison between Unknown and I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Invalid comparison between Unknown and I4
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Invalid comparison between Unknown and I4
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Invalid comparison between Unknown and I4
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = mSG.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
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
					mSG.Row = checked(mSG.Row - 1);
				}
				CurRow = 0;
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
						mSG.Row += 1;
					}
					CurRow = 0;
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
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + TEXT_ENTRY.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE NOT IN (SELECT AC_CODE FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "') ORDER BY A.LC_CODE,A.AC_NAME";
							}
							else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
							{
								DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE NOT IN (SELECT AC_CODE FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "') AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME ";
							}
							else
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE NOT IN (SELECT AC_CODE FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "') ORDER BY A.AC_NAME";
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
								TEXT_ENTRY.Text = DC_Main.ColValue[1];
								mSG[mSG.Row, 1] = DC_Main.ColValue[1];
								mSG[mSG.Row, 2] = DC_Main.ColValue[0];
							}
							((Control)TEXT_ENTRY).Focus();
						}
						else
						{
							mSG[mSG.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CODE"], (object)""));
							mSG[mSG.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
							mSG[mSG.Row, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_MOBILE"], (object)""));
							DC_Main.MsAcBal(mSG[mSG.Row, 1], Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
							if (DC_Main.MsAcAmtOpBal > 0.0)
							{
								LOpAmt.Text = Strings.Format((object)DC_Main.MsAcAmtOpBal, "0.00") + " : Cr Amt";
								((Control)LOpAmt).ForeColor = Color.Blue;
							}
							else if (DC_Main.MsAcAmtOpBal < 0.0)
							{
								LOpAmt.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcAmtOpBal), "0.00") + " : Dr Amt";
								((Control)LOpAmt).ForeColor = Color.Red;
							}
							else
							{
								LOpAmt.Text = ": Amt";
							}
							CustOpAmt = DC_Main.MsAcAmtOpBal;
							DC_Main.MsAcAmtOpBal = 0.0;
							DC_Main.MsAcGoldOpBal = 0.0;
							DC_Main.MsAcSilverOpBal = 0.0;
							DC_Main.MsAcAmtClBal = 0.0;
							DC_Main.MsAcGoldClBal = 0.0;
							DC_Main.MsAcSilverClBal = 0.0;
							((Control)TEXT_ENTRY).Visible = false;
							((Control)tItDesc).Focus();
						}
						return;
					case 4:
					case 6:
						if (mSG.Row == mSG.Rows - 1)
						{
							if (Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
							{
								((Control)TEXT_ENTRY).Focus();
								return;
							}
							mSG[mSG.Row, 4] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
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

	private void TR_LOCT_AMT_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0a65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a74: Expected O, but got Unknown
		//IL_0ab3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac2: Expected O, but got Unknown
		//IL_0adc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aeb: Expected O, but got Unknown
		//IL_0b13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1a: Expected O, but got Unknown
		//IL_0ba0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baf: Expected O, but got Unknown
		//IL_0c5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6d: Expected O, but got Unknown
		//IL_0d06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d11: Expected O, but got Unknown
		//IL_0d9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0daa: Expected O, but got Unknown
		//IL_0dcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dde: Expected O, but got Unknown
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
				AxMSFlexGrid mSG = MSG;
				object? obj9 = colorConverter.ConvertFromString("ControlLightLight");
				mSG.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				AxMSFlexGrid mSG2 = MSG;
				object? obj10 = colorConverter.ConvertFromString("DarkGray");
				mSG2.BackColorBkg = ((obj10 != null) ? ((Color)obj10) : default(Color));
				AxMSFlexGrid mSG3 = MSG;
				object? obj11 = colorConverter.ConvertFromString("255, 224, 192");
				mSG3.BackColorFixed = ((obj11 != null) ? ((Color)obj11) : default(Color));
				AxMSFlexGrid mSG_TOT = MSG_TOT;
				object? obj12 = colorConverter.ConvertFromString("Silver");
				mSG_TOT.BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				AxMSFlexGrid mSG_TOT2 = MSG_TOT;
				object? obj13 = colorConverter.ConvertFromString("Silver");
				mSG_TOT2.BackColorBkg = ((obj13 != null) ? ((Color)obj13) : default(Color));
				AxMSFlexGrid mSG_TOT3 = MSG_TOT;
				object? obj14 = colorConverter.ConvertFromString("Silver");
				mSG_TOT3.BackColorFixed = ((obj14 != null) ? ((Color)obj14) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj15 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj16 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj17 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj18 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj19 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj20 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj21 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj22 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj22 != null) ? ((Color)obj22) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj23 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj24 = lblBook;
				object? obj25 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj24).ForeColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj26 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj27 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj28 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj29 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj29 != null) ? ((Color)obj29) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj30 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj31 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj32 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj33 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				Font font = ((Control)tVchNo).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is CheckBox) && ((Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "lblBook", false) != 0)))
						{
							val3.Font = new Font(font.FontFamily, (float)num3, font.Style);
						}
					}
				}
				finally
				{
					((IDisposable)font)?.Dispose();
				}
				((Control)FlowLayoutPanel1).Width = (int)Math.Round(569.0 * (1.0 + num));
				num3 = (int)Math.Ceiling((double)((Control)lblBook).Font.Size * (1.0 + num2));
				((Control)lblBook).Font = new Font(((Control)lblBook).Font.FontFamily, (float)num3, ((Control)lblBook).Font.Style);
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnSave).Font.Size * (1.0 + num2));
				Font font2 = ((BaseStyleControl)BtnSave).Font;
				try
				{
					foreach (object control4 in ((Control)PnlBotam).Controls)
					{
						object objectValue2 = RuntimeHelpers.GetObjectValue(control4);
						if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue2, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"chkWapp", false))
						{
							NewLateBinding.LateSet(objectValue2, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
						}
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnFirst).Font.Size * (1.0 + num2));
				((BaseStyleControl)BtnFirst).Font = new Font(((BaseStyleControl)BtnFirst).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnFirst).Font.Style);
				((BaseStyleControl)BtnLast).Font = new Font(((BaseStyleControl)BtnLast).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnLast).Font.Style);
				if (DC_Main.ScreenHight > 1.0)
				{
					MSG_TOT.ScrollBars = (ScrollBarsSettings)0;
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
			if (Operators.CompareString(FormMainBook, "AMT OUT", false) == 0)
			{
				((Control)Label1).Visible = true;
				((Control)tToLcCode).Visible = true;
				((Control)tToLcName).Visible = true;
				((Control)Label5).Visible = true;
				((Control)tToVchNo).Visible = true;
				((TextBoxBase)tToVchNo).ReadOnly = true;
				((Control)tToBook).Visible = true;
				((TextBoxBase)tToBook).ReadOnly = true;
			}
			if (Operators.CompareString(FormMainBook, "AMT IN", false) == 0)
			{
				((Control)lFromLc).Visible = true;
				((Control)tFrmLc).Visible = true;
				((TextBoxBase)tFrmLc).ReadOnly = true;
				((Control)tFromLcName).Visible = true;
				((TextBoxBase)tFromLcName).ReadOnly = true;
				((Control)Label6).Visible = true;
				((Control)tFromVchNo).Visible = true;
				((TextBoxBase)tFromVchNo).ReadOnly = true;
				((Control)tFrombook).Visible = true;
				((TextBoxBase)tFrombook).ReadOnly = true;
			}
			DC_Main.CurBook = "";
			DC_Main.CurBookName = "";
			DC_Main.CurBookType = "";
			DC_Main.CurBookItm = "";
			DC_Main.CurBookMain = "";
			DC_Main.CurBookSname = "";
			DC_Main.CurBookInOut = "";
			if ((Operators.CompareString(DC_Main.MsWhatsAppOpen, "Y", false) == 0) | DC_Main.MsEmailOpen)
			{
				((Control)lbrMsgShow).Visible = true;
			}
			BtnCancel_Click(BtnCancel, new EventArgs());
			CurActCtrl = (Control)(object)tVchNo;
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
		mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);
		mTime.Text = DateTime.Now.ToString("HH:mm:ss");
		mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
		MsVchSrno = "";
		OldValTot = 0.0;
		NewValTot = 0.0;
		CurRow = 0;
		UsUPdate = "N";
		UsDelete = "N";
		ColorConverter colorConverter = new ColorConverter();
		SimpleButton btnSave = BtnSave;
		object? obj = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnSave).ForeColor = ((obj != null) ? ((Color)obj) : default(Color));
		SimpleButton btnDelete = BtnDelete;
		object? obj2 = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnDelete).ForeColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
		((Control)TEXT_ENTRY).Visible = false;
		LOpAmt.Text = ": Amt";
		((Control)LOpAmt).ForeColor = Color.Black;
		LBookAmt.Text = ": Amt";
		((Control)LBookAmt).ForeColor = Color.Black;
		((TextBoxBase)tToLcCode).ReadOnly = false;
		MSG_CLEAR();
		if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
		{
			tEmpCode.Text = DC_Main.MsUserEmpCode;
			tEmpName.Text = DC_Main.MsUserEmpName;
		}
		DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From LOCT_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		((Control)tVchNo).Focus();
	}

	private void DISPLAY_DATA()
	{
		MSG_CLEAR();
		DC_Main.RsQry = "SELECT * FROM LOCT_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
		RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (RsData.Rows.Count > 0)
			{
				((TextBoxBase)tToLcCode).ReadOnly = true;
				tVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_NO"], (object)""));
				tHdVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HD_VCH_NO"], (object)""));
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
				tToLcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TO_LC_CODE"], (object)""));
				tToBook.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TO_CO_BOOK"], (object)""));
				tToVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TO_VCH_NO"], (object)""));
				tFrmLc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["FROM_LC_CODE"], (object)""));
				tFrombook.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["FROM_CO_BOOK"], (object)""));
				tFromVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["FROM_VCH_NO"], (object)""));
				DC_Main.RsQry = "SELECT LC_NAME FROM LOCT_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tToLcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LC_NAME"], (object)""));
				}
				DC_Main.RsQry = "SELECT LC_NAME FROM LOCT_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND LC_CODE = '" + tFrmLc.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tFromLcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LC_NAME"], (object)""));
				}
				UsUPdate = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_UPDATE"], (object)""));
				UsDelete = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_DELETE"], (object)""));
				if (Operators.CompareString(UsUPdate, "Y", false) == 0)
				{
					((BaseStyleControl)BtnSave).ForeColor = Color.Green;
				}
				if (Operators.CompareString(UsDelete, "Y", false) == 0)
				{
					((BaseStyleControl)BtnDelete).ForeColor = Color.Green;
				}
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsData.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["AC_CODE"], (object)""));
					if (DC_Main.i + 1 == 1)
					{
						PartyAcCode = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["AC_CODE"], (object)""));
						DC_Main.MsAcBal(PartyAcCode, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
						if (DC_Main.MsAcAmtOpBal > 0.0)
						{
							LOpAmt.Text = Strings.Format((object)DC_Main.MsAcAmtOpBal, "0.00") + " : Cr Amt";
							((Control)LOpAmt).ForeColor = Color.Blue;
						}
						else if (DC_Main.MsAcAmtOpBal < 0.0)
						{
							LOpAmt.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcAmtOpBal), "0.00") + " : Dr Amt";
							((Control)LOpAmt).ForeColor = Color.Red;
						}
						else
						{
							LOpAmt.Text = ": Amt";
						}
						CustOpAmt = DC_Main.MsAcAmtOpBal;
						CustClAmt = DC_Main.MsAcAmtClBal;
						DC_Main.MsAcAmtOpBal = 0.0;
						DC_Main.MsAcGoldOpBal = 0.0;
						DC_Main.MsAcSilverOpBal = 0.0;
						DC_Main.MsAcAmtClBal = 0.0;
						DC_Main.MsAcGoldClBal = 0.0;
						DC_Main.MsAcSilverClBal = 0.0;
					}
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["AC_NAME"], (object)""));
					mSG[DC_Main.i + 1, 4] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[DC_Main.i]["REC_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["IT_DESC"], (object)""));
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["CHQ_NO"], (object)""));
					mSG[DC_Main.i + 1, 5] = "E";
					mSG.Rows += 1;
					DC_Main.i++;
				}
				mSG.Rows -= 1;
				mSG = null;
				MSG_TOT_FILL();
				CurRow = 0;
				tItDesc.Text = MSG[1, 6];
				OldValTot = Conversion.Val(MSG_TOT[0, 4]) + Conversion.Val(MSG_TOT[0, 9]);
				NewValTot = Conversion.Val(MSG_TOT[0, 4]) + Conversion.Val(MSG_TOT[0, 9]);
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

	private void TR_LOCT_AMT_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_LOCT_AMT_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_19f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_0512: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
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
						if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
						{
							Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
							goto end_IL_0001;
						}
						if ((Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0) & (Operators.CompareString(tEmpCode.Text, "", false) == 0))
						{
							Interaction.MsgBox((object)"Please Select Employee Code and Try......", (MsgBoxStyle)0, (object)null);
							((Control)tEmpCode).Focus();
							goto end_IL_0001;
						}
						if ((Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
						{
							Interaction.MsgBox((object)"You Cant Save This Voucher Becouse This Company Type is B......", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						((Control)BtnSave).Enabled = false;
						if ((DateTime.Compare(Conversions.ToDate(DC_Main.MCo_OpDate), Conversions.ToDate(mVchDate.Text)) > 0) | (DateTime.Compare(Conversions.ToDate(DC_Main.MCo_ClDate), Conversions.ToDate(mVchDate.Text)) < 0))
						{
							Interaction.MsgBox((object)"You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
						{
							Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						if (Operators.CompareString(UsUPdate, "Y", false) != 0 && ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0)))
						{
							Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						if (Operators.CompareString(tVchNo.Text, "", false) == 0)
						{
							Interaction.MsgBox((object)"Please Insert VchNo and try", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						MSG_TOT_FILL();
						ProjectData.ClearProjectError();
						num2 = 2;
						tToBook.Text = "159";
						if (Operators.CompareString(EntryMode, "A", false) == 0)
						{
							DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From LOCT_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + tToBook.Text + "' HAVING MAX(VCH_NO) > 0";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count > 0)
							{
								tToVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
							}
							else
							{
								tToVchNo.Text = "00001";
							}
						}
						if (Operators.CompareString(EntryMode, "A", false) == 0)
						{
							DC_Main.RsQry = "SELECT * FROM LOCT_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count > 0)
							{
								DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From LOCT_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
						if (Operators.CompareString(FormMainBook, "AMT OUT", false) == 0)
						{
							DC_Main.ExeQuteDc("DELETE FROM LOCT_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
							if (Conversion.Val(MSG_TOT[0, 4]) + Conversion.Val(MSG_TOT[0, 9]) != 0.0)
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
								DC_Main.RsQry = "SELECT * FROM LOCT_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
								RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.MsInsertData();
								DataRow dataRow2 = RsData.NewRow();
								int num3 = MSG.Rows - 1;
								DC_Main.i = 1;
								while (DC_Main.i <= num3)
								{
									AxMSFlexGrid mSG = MSG;
									if ((Operators.CompareString(mSG[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(mSG[DC_Main.i, 9]) + Conversion.Val(mSG[DC_Main.i, 4]) != 0.0))
									{
										dataRow2["CO_CODE"] = DC_Main.MCo_code;
										dataRow2["LC_CODE"] = DC_Main.MLc_code;
										dataRow2["CO_YEAR"] = DC_Main.MCo_year;
										dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
										dataRow2["VCH_NO"] = tVchNo.Text;
										dataRow2["VCH_DATE"] = mVchDate.Text;
										dataRow2["VCH_TYPE"] = FormBookSname;
										dataRow2["INOUT_TYPE"] = FormBookInOut;
										dataRow2["ENTRY_TYPE"] = "B";
										dataRow2["BOOK_NAME"] = FormMainBook;
										dataRow2["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
										if (DC_Main.i == 1)
										{
											PartyAcCode = mSG[DC_Main.i, 1];
										}
										dataRow2["AC_CODE"] = mSG[DC_Main.i, 1];
										dataRow2["AC_NAME"] = mSG[DC_Main.i, 2];
										dataRow2["REC_AMT"] = Conversion.Val(mSG[DC_Main.i, 4]);
										dataRow2["IT_DESC"] = mSG[DC_Main.i, 6];
										dataRow2["CHQ_NO"] = mSG[DC_Main.i, 3];
										dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
										dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
										dataRow2["EMP_CODE"] = tEmpCode.Text;
										dataRow2["TO_LC_CODE"] = tToLcCode.Text;
										dataRow2["TO_CO_BOOK"] = tToBook.Text;
										dataRow2["TO_VCH_NO"] = tToVchNo.Text;
										dataRow2["FROM_LC_CODE"] = DC_Main.MLc_code;
										dataRow2["FROM_CO_BOOK"] = DC_Main.MCo_Book;
										dataRow2["FROM_VCH_NO"] = tVchNo.Text;
										dataRow2["AMT_TRFR"] = "N";
										dataRow2["DATA_TRFR"] = "N";
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
							DC_Main.ExeQuteDc("DELETE FROM LOCT_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
							if (Conversion.Val(MSG_TOT[0, 4]) + Conversion.Val(MSG_TOT[0, 9]) != 0.0)
							{
								DC_Main.RsQry = "SELECT * FROM LOCT_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'";
								RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.MsInsertData();
								DataRow dataRow3 = RsData.NewRow();
								int num4 = MSG.Rows - 1;
								DC_Main.i = 1;
								while (DC_Main.i <= num4)
								{
									AxMSFlexGrid mSG2 = MSG;
									if ((Operators.CompareString(mSG2[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(mSG2[DC_Main.i, 9]) + Conversion.Val(mSG2[DC_Main.i, 4]) != 0.0))
									{
										dataRow3["CO_CODE"] = DC_Main.MCo_code;
										dataRow3["LC_CODE"] = tToLcCode.Text;
										dataRow3["CO_YEAR"] = DC_Main.MCo_year;
										dataRow3["CO_BOOK"] = tToBook.Text;
										dataRow3["VCH_NO"] = tToVchNo.Text;
										dataRow3["VCH_DATE"] = mVchDate.Text;
										dataRow3["VCH_TYPE"] = FormBookSname;
										dataRow3["INOUT_TYPE"] = FormBookInOut;
										dataRow3["ENTRY_TYPE"] = "B";
										dataRow3["BOOK_NAME"] = FormMainBook;
										dataRow3["SR_NO"] = Conversion.Val(mSG2[DC_Main.i, 0]);
										dataRow3["AC_CODE"] = mSG2[DC_Main.i, 1];
										dataRow3["AC_NAME"] = mSG2[DC_Main.i, 2];
										dataRow3["REC_AMT"] = Conversion.Val(mSG2[DC_Main.i, 4]);
										dataRow3["IT_DESC"] = mSG2[DC_Main.i, 6];
										dataRow3["CHQ_NO"] = mSG2[DC_Main.i, 3];
										dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
										dataRow3["HD_VCH_NO"] = tToVchNo.Text;
										dataRow3["EMP_CODE"] = "";
										dataRow3["FROM_LC_CODE"] = DC_Main.MLc_code;
										dataRow3["FROM_CO_BOOK"] = DC_Main.MCo_Book;
										dataRow3["FROM_VCH_NO"] = tVchNo.Text;
										dataRow3["TO_LC_CODE"] = tToLcCode.Text;
										dataRow3["TO_CO_BOOK"] = tToBook.Text;
										dataRow3["TO_VCH_NO"] = tToVchNo.Text;
										dataRow3["VCH_TYPE"] = "AMTIN";
										dataRow3["INOUT_TYPE"] = "I";
										dataRow3["ENTRY_TYPE"] = "B";
										dataRow3["BOOK_NAME"] = "AMT IN";
										dataRow3["AMT_TRFR"] = "N";
										dataRow3["DATA_TRFR"] = "N";
										dataRow3["MAIN_USER"] = MainUser;
										dataRow3["USER_UPDATE"] = "N";
										dataRow3["USER_DELETE"] = "N";
										RsData.Rows.Add(dataRow3);
										((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
										RsData.Clear();
									}
									mSG2 = null;
									DC_Main.i++;
								}
							}
						}
						if (Operators.CompareString(FormMainBook, "AMT IN", false) == 0 && ((Operators.CompareString(MSG[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(MSG[DC_Main.i, 9]) + Conversion.Val(MSG[DC_Main.i, 4]) != 0.0)))
						{
							DC_Main.ExeQuteDc("DELETE FROM LOCT_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
							DC_Main.RsQry = "SELECT * FROM LOCT_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
							RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.MsInsertData();
							DataRow dataRow4 = RsData.NewRow();
							int num5 = MSG.Rows - 1;
							DC_Main.i = 1;
							while (DC_Main.i <= num5)
							{
								AxMSFlexGrid mSG3 = MSG;
								if ((Operators.CompareString(mSG3[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(mSG3[DC_Main.i, 9]) + Conversion.Val(mSG3[DC_Main.i, 4]) != 0.0))
								{
									dataRow4["CO_CODE"] = DC_Main.MCo_code;
									dataRow4["LC_CODE"] = DC_Main.MLc_code;
									dataRow4["CO_YEAR"] = DC_Main.MCo_year;
									dataRow4["CO_BOOK"] = DC_Main.MCo_Book;
									dataRow4["VCH_NO"] = tVchNo.Text;
									dataRow4["VCH_DATE"] = mVchDate.Text;
									dataRow4["VCH_TYPE"] = FormBookSname;
									dataRow4["INOUT_TYPE"] = FormBookInOut;
									dataRow4["ENTRY_TYPE"] = "B";
									dataRow4["BOOK_NAME"] = FormMainBook;
									dataRow4["SR_NO"] = Conversion.Val(mSG3[DC_Main.i, 0]);
									if (DC_Main.i == 1)
									{
										PartyAcCode = mSG3[DC_Main.i, 1];
									}
									dataRow4["AC_CODE"] = mSG3[DC_Main.i, 1];
									dataRow4["AC_NAME"] = mSG3[DC_Main.i, 2];
									dataRow4["REC_AMT"] = Conversion.Val(mSG3[DC_Main.i, 4]);
									dataRow4["IT_DESC"] = mSG3[DC_Main.i, 6];
									dataRow4["CHQ_NO"] = mSG3[DC_Main.i, 3];
									dataRow4["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
									dataRow4["HD_VCH_NO"] = tHdVchNo.Text;
									dataRow4["EMP_CODE"] = tEmpCode.Text;
									dataRow4["TO_LC_CODE"] = tToLcCode.Text;
									dataRow4["TO_CO_BOOK"] = tToBook.Text;
									dataRow4["TO_VCH_NO"] = tToVchNo.Text;
									dataRow4["FROM_LC_CODE"] = tFrmLc.Text;
									dataRow4["FROM_CO_BOOK"] = tFrombook.Text;
									dataRow4["FROM_VCH_NO"] = tFromVchNo.Text;
									dataRow4["AMT_TRFR"] = "Y";
									dataRow4["DATA_TRFR"] = "N";
									dataRow4["MAIN_USER"] = MainUser;
									dataRow4["USER_UPDATE"] = "N";
									dataRow4["USER_DELETE"] = "N";
									RsData.Rows.Add(dataRow4);
									((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
									RsData.Clear();
								}
								mSG3 = null;
								DC_Main.i++;
							}
						}
						DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						Ac_Ledr.Loct_Amt_Ledr(DC_Main.MCo_Book, tVchNo.Text);
						DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						Ac_Rojmel.Loct_Amt_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
						Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
						if (Operators.CompareString(FormVchNo, "", false) != 0)
						{
							CLEAR_DATA();
							((Form)this).Close();
							goto end_IL_0001;
						}
						CurPrnVch = tVchNo.Text;
						DC_Main.MsAcBal(PartyAcCode, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
						CustOpAmt = DC_Main.MsAcAmtOpBal;
						CustClAmt = DC_Main.MsAcAmtClBal;
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
						goto end_IL_0001;
					case 6653:
						num = -1;
						switch (num2)
						{
						case 2:
							((Control)BtnSave).Enabled = true;
							EntryMode = "E";
							Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
							goto end_IL_0001;
						}
						break;
					}
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 6653;
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

	private async void WappReport()
	{
		if (Operators.CompareString(((ButtonBase)MyProject.Forms.MDI_FORM.chkWappId).Text, "Whatsapp Open", false) == 0 || !((Operators.CompareString(DC_Main.MsWhatsAppOpen, "Y", false) == 0) & (Operators.CompareString(DC_Main.MsCustSms, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0)))
		{
			return;
		}
		DC_Main.RsQry = "Select A.AC_NAME,A.REC_AMT,B.AC_MOBILE,A.CHQ_NO FROM LOCT_AMT AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + CurPrnVch + "' AND B.AC_MOBILE <> '' ORDER BY A.SR_NO ";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.i = 0;
		checked
		{
			while (DC_Main.i < DC_Main.Tbl.Rows.Count)
			{
				string message = "";
				string text = Conversions.ToString(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE"]));
				if (Operators.CompareString(FormMainBook, "CASH REC", false) == 0)
				{
					message = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)" DEAR :", DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]), (object)" PAYMENT RECEIVED WITH AMOUNT : "), DC_Main.Tbl.Rows[DC_Main.i]["REC_AMT"]), (object)"  REGARD "), (object)DC_Main.MCo_Name), (object)" Have a Nice Day...")));
				}
				if (Operators.CompareString(FormMainBook, "CASH PAY", false) == 0)
				{
					message = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)" DEAR :", DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]), (object)" AMOUNT PAID WITH RS : "), DC_Main.Tbl.Rows[DC_Main.i]["REC_AMT"]), (object)"  REGARD "), (object)DC_Main.MCo_Name), (object)" Have a Nice Day...")));
				}
				if (Operators.CompareString(FormMainBook, "BANK REC", false) == 0)
				{
					message = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)" DEAR :", DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]), (object)" PAYMENT RECEIVED WITH CHEQUE NO : "), DC_Main.Tbl.Rows[DC_Main.i]["CHQ_NO"]), (object)" AMOUNT : "), DC_Main.Tbl.Rows[DC_Main.i]["REC_AMT"]), (object)"  REGARD "), (object)DC_Main.MCo_Name), (object)" Have a Nice Day...")));
				}
				if (Operators.CompareString(FormMainBook, "BANK PAY", false) == 0)
				{
					message = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)" DEAR :", DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]), (object)" AMOUNT PAID WITH CHEQUE NO : "), DC_Main.Tbl.Rows[DC_Main.i]["CHQ_NO"]), (object)" AMOUNT : "), DC_Main.Tbl.Rows[DC_Main.i]["REC_AMT"]), (object)"  REGARD "), (object)DC_Main.MCo_Name), (object)" Have a Nice Day...")));
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
						lbrMsgShow.Text = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject((object)(Conversions.ToString(DC_Main.i + 1) + " - "), NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, (Type)null, "Status", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Description", new object[0], (string[])null, (Type[])null, (bool[])null))));
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
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Invalid comparison between Unknown and I4
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cb: Unknown result type (might be due to invalid IL or missing references)
		if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
		{
			Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(UsDelete, "Y", false) != 0 && Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(FormMainBook, "AMT OUT", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM LOCT_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "' AND AMT_TRFR = 'Y'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				Interaction.MsgBox((object)"You Cant Delete This Voucher Because Outword Branch Received This Voucher Please Detlet First Out Word Branch Vch First...", (MsgBoxStyle)0, (object)null);
				return;
			}
		}
		if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,SR_NO,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,AC_CODE,AC_NAME,CASE WHEN INOUT_TYPE = 'O' THEN REC_AMT ELSE 0 END,CASE WHEN INOUT_TYPE = 'I' THEN REC_AMT ELSE 0 END,'A',0,0,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "',SUBSTRING(IT_DESC,1,149) FROM LOCT_AMT AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			if (Operators.CompareString(FormMainBook, "AMT OUT", false) == 0)
			{
				DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
				DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM LOCT_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM LOCT_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
			}
			else
			{
				DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
				DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM LOCT_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			}
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_LOCT_AMT_KeyDown(object sender, KeyEventArgs e)
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
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\LoctAmtVch.RPT";
		Cr.SelectionFormula = "{LOCT_AMT.CO_CODE} = '" + DC_Main.MCo_code + "' AND {LOCT_AMT.LC_CODE} = '" + DC_Main.MLc_code + "' AND {LOCT_AMT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {LOCT_AMT.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {LOCT_AMT.VCH_NO} = '" + CurPrnVch + "'";
		Cr[(short)2] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";
		Cr[(short)3] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";
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
		DC_Main.MsPrintStatus = false;
		lbrMsgShow.Text = "Whatsapp Msg";
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CustOpAmt = 0.0;
		CustClAmt = 0.0;
		CLEAR_DATA();
	}

	private void TR_LOCT_AMT_Activated(object sender, EventArgs e)
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
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL,B.AC_ADD1 As AddressL,A.IT_DESC As VchDescL,A.MAIN_USER As UserL,A.REC_AMT As RecAmtR,AMT_TRFR As TrfrM FROM LOCT_AMT AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' ORDER BY A.VCH_NO,A.SR_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[9];
		DC_Main.ColWidth[0] = 80.0;
		DC_Main.ColWidth[1] = 110.0;
		DC_Main.ColWidth[2] = 250.0;
		DC_Main.ColWidth[3] = 200.0;
		DC_Main.ColWidth[4] = 225.0;
		DC_Main.ColWidth[5] = 100.0;
		DC_Main.ColWidth[6] = 100.0;
		DC_Main.ColWidth[7] = 80.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				CLEAR_DATA();
				tVchNo.Text = DC_Main.ColValue[0];
				DISPLAY_DATA();
				((Control)mVchDate).Focus();
			}
			else
			{
				((Control)tVchNo).Focus();
			}
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
				DC_Main.RsQry = "SELECT VCH_NO FROM LOCT_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM LOCT_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void TR_LOCT_AMT_Closed(object sender, EventArgs e)
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

	private void lblBook_DoubleClick(object sender, EventArgs e)
	{
		((Control)tHdVchNo).Visible = true;
	}

	private void btnChqPrint_Click(object sender, EventArgs e)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		((Form)MyProject.Forms.MS_PRINT).ShowDialog();
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) != 0)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\ChqPrint" + DC_Main.MCo_Book + ".RPT";
			Cr.SelectionFormula = "{LOCT_AMT.CO_CODE} = '" + DC_Main.MCo_code + "' AND {LOCT_AMT.LC_CODE} = '" + DC_Main.MLc_code + "' AND {LOCT_AMT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {LOCT_AMT.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {LOCT_AMT.VCH_NO} = '" + CurPrnVch + "'";
			if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
			{
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
			else
			{
				Cr.Destination = (DestinationConstants)0;
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
			}
			DC_Main.MsPrintStatus = false;
		}
	}

	private void MSG_RowColChange(object sender, EventArgs e)
	{
		if (CurRow != MSG.Row)
		{
			tItDesc.Text = MSG[MSG.Row, 6];
			CurRow = MSG.Row;
		}
	}

	private void tItDesc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Invalid comparison between Unknown and I4
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			MSG[MSG.Row, 6] = tItDesc.Text;
			MSG.Col = 4;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
		if (((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)) && (int)e.KeyCode == 112)
		{
			DC_Main.RsQry = "SELECT IT_DESC As VchDescL FROM LOCT_AMT WHERE IT_DESC <> '' AND LEN(IT_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND IT_DESC <> '' GROUP BY IT_DESC   ORDER BY IT_DESC";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[3];
			DC_Main.ColWidth[0] = 700.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				tItDesc.Text = DC_Main.ColValue[0];
				((TextBoxBase)tItDesc).SelectionStart = Strings.Len(tItDesc.Text);
			}
		}
	}

	private void tItDesc_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)tItDesc).SelectionStart = 0;
		((TextBoxBase)tItDesc).SelectionLength = Strings.Len(tItDesc.Text);
	}

	private void TR_LOCT_AMT_KeyUp(object sender, KeyEventArgs e)
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

	private void tToLcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From LOCT_MAST WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count <= 0)
		{
			DC_Main.RsQry = "Select LC_CODE As CodeL,LC_NAME As NameL,LC_ADD1 As AddressL,LC_CITY As CityL FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE <> '" + DC_Main.MLc_code + "' ORDER BY LC_CODE";
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
				tToLcCode.Text = DC_Main.ColValue[0];
				tToLcName.Text = DC_Main.ColValue[1];
				((TextBoxBase)tToLcCode).SelectAll();
				((Control)tToLcCode).Focus();
			}
		}
		else
		{
			tToLcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LC_NAME"], (object)""));
			MSG.Col = 1;
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void tFrmLc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MSG.Col = 1;
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void tItDesc_DoubleClick(object sender, EventArgs e)
	{
		((Control)BtnSave).Enabled = true;
	}
}
