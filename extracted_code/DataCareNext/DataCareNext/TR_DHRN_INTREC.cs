using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxCrystal;
using Crystal;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class TR_DHRN_INTREC : Form
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
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcName")]
	private TextBox _tAcName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmpCode")]
	private TextBox _tEmpCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tVchDesc")]
	private TextBox _tVchDesc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBillNo")]
	private TextBox _tBillNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nDhrnAmt")]
	private TextBox _nDhrnAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nMonthlyInt")]
	private TextBox _nMonthlyInt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nDhrnMonth")]
	private TextBox _nDhrnMonth;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nIntPrc")]
	private TextBox _nIntPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nIntDays")]
	private TextBox _nIntDays;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToDate")]
	private MaskedTextBox _mToDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nIntAmt")]
	private TextBox _nIntAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tIsuNo")]
	private TextBox _tIsuNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnIssue")]
	private SimpleButton _BtnIssue;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRecAc")]
	private TextBox _tRecAc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nIntRecAmt")]
	private TextBox _nIntRecAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mIsuDate")]
	private MaskedTextBox _mIsuDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDate")]
	private MaskedTextBox _mFromDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nDhrnReceived")]
	private TextBox _nDhrnReceived;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkInt")]
	private CheckBox _chkInt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboIntMonth")]
	private ComboBox _cboIntMonth;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboLoanType")]
	private ComboBox _cboLoanType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nUnchakDhrnRec")]
	private TextBox _nUnchakDhrnRec;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nIntrestKasar")]
	private TextBox _nIntrestKasar;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nRcutAmt")]
	private TextBox _nRcutAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nFineRate")]
	private TextBox _nFineRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nPayAmt")]
	private TextBox _nPayAmt;

	private string UsUPdate;

	private string UsDelete;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private string OldAcCode;

	private string AcGstType;

	private double PurcAcFine;

	private int CurRow;

	private string CurIntTypeCalc;

	private double OldIntAmt;

	private bool EditLoad;

	private int OldIntDay;

	private double OldRCutAmt;

	private double DhrnAdjAmt;

	private string GoldDesc;

	private string IsuRec;

	private double ItGoldWt;

	private double ItSilverWt;

	private double OldIntPrc;

	private double OldMontIntPrc;

	private string CurTagImage;

	private string IsuYrCd;

	private string IsuDbCd;

	private string OldIsuNo;

	private double CustOpAmt;

	private double CustOpGold;

	private double CustOpSilver;

	private double CustClAmt;

	private double CustClGold;

	private double CustClSilver;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private double OldValTot;

	private double NewValTot;

	private string CurTagNo;

	private string MsVchSrno;

	private DataTable RsData;

	private DataTable RsDetl;

	private DataTable RsBarDetl;

	private DataTable RsBarIdtl;

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

	private string MaxVchNo;

	private string LastVchNo;

	private bool RowChang;

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
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			EventHandler eventHandler = tAcName_GotFocus;
			EventHandler eventHandler2 = tAcName_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tAcName_KeyDown);
			TextBox val2 = _tAcName;
			if (val2 != null)
			{
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).TextChanged -= eventHandler2;
				((Control)val2).KeyDown -= val;
			}
			_tAcName = value;
			val2 = _tAcName;
			if (val2 != null)
			{
				((Control)val2).GotFocus += eventHandler;
				((Control)val2).TextChanged += eventHandler2;
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
			TextBox val2 = _tVchDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tVchDesc = value;
			val2 = _tVchDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	internal virtual TextBox tBillNo
	{
		[CompilerGenerated]
		get
		{
			return _tBillNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBillNo_KeyDown);
			TextBox val2 = _tBillNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBillNo = value;
			val2 = _tBillNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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
	[AccessedThroughProperty("LClAmt")]
	private virtual Label _LClAmt;

	internal virtual Label LClAmt
	{
		get
		{
			return _LClAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LClAmt = value;
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

	internal virtual TextBox nDhrnAmt
	{
		[CompilerGenerated]
		get
		{
			return _nDhrnAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nDhrnAmt_KeyDown);
			TextBox val2 = _nDhrnAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nDhrnAmt = value;
			val2 = _nDhrnAmt;
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

	internal virtual TextBox nMonthlyInt
	{
		[CompilerGenerated]
		get
		{
			return _nMonthlyInt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nMonthlyInt_KeyDown);
			TextBox val2 = _nMonthlyInt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nMonthlyInt = value;
			val2 = _nMonthlyInt;
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

	internal virtual TextBox nDhrnMonth
	{
		[CompilerGenerated]
		get
		{
			return _nDhrnMonth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nDhrnMonth_KeyDown);
			TextBox val2 = _nDhrnMonth;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nDhrnMonth = value;
			val2 = _nDhrnMonth;
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

	internal virtual TextBox nIntPrc
	{
		[CompilerGenerated]
		get
		{
			return _nIntPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nIntPrc_KeyDown);
			TextBox val2 = _nIntPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nIntPrc = value;
			val2 = _nIntPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual MaskedTextBox mToDate
	{
		[CompilerGenerated]
		get
		{
			return _mToDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = mToDate_GotFocus;
			KeyEventHandler val = new KeyEventHandler(mToDate_KeyDown);
			MaskedTextBox val2 = _mToDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_mToDate = value;
			val2 = _mToDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus += eventHandler;
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

	internal virtual TextBox nIntAmt
	{
		[CompilerGenerated]
		get
		{
			return _nIntAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nIntAmt_KeyDown);
			TextBox val2 = _nIntAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nIntAmt = value;
			val2 = _nIntAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tIsuNo
	{
		[CompilerGenerated]
		get
		{
			return _tIsuNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tIsuNo_KeyDown);
			TextBox val2 = _tIsuNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tIsuNo = value;
			val2 = _tIsuNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tIsuYrCd")]
	private virtual TextBox _tIsuYrCd;

	internal virtual TextBox tIsuYrCd
	{
		get
		{
			return _tIsuYrCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tIsuYrCd = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tIsuDbCd")]
	private virtual TextBox _tIsuDbCd;

	internal virtual TextBox tIsuDbCd
	{
		get
		{
			return _tIsuDbCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tIsuDbCd = value;
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

	internal virtual SimpleButton BtnIssue
	{
		[CompilerGenerated]
		get
		{
			return _BtnIssue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnIssue_Click;
			SimpleButton val = _BtnIssue;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnIssue = value;
			val = _BtnIssue;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual TextBox tRecAc
	{
		[CompilerGenerated]
		get
		{
			return _tRecAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tRecAc_KeyDown);
			TextBox val2 = _tRecAc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tRecAc = value;
			val2 = _tRecAc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRecAcName")]
	private virtual TextBox _tRecAcName;

	internal virtual TextBox tRecAcName
	{
		get
		{
			return _tRecAcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tRecAcName = value;
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

	internal virtual TextBox nIntRecAmt
	{
		[CompilerGenerated]
		get
		{
			return _nIntRecAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nIntRecAmt_KeyDown);
			TextBox val2 = _nIntRecAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nIntRecAmt = value;
			val2 = _nIntRecAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual MaskedTextBox mIsuDate
	{
		[CompilerGenerated]
		get
		{
			return _mIsuDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mIsuDate_KeyDown);
			MaskedTextBox val2 = _mIsuDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mIsuDate = value;
			val2 = _mIsuDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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
	[AccessedThroughProperty("nDhrnAdjAmt")]
	private virtual TextBox _nDhrnAdjAmt;

	internal virtual TextBox nDhrnAdjAmt
	{
		get
		{
			return _nDhrnAdjAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nDhrnAdjAmt = value;
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
	[AccessedThroughProperty("nPandingDhrn")]
	private virtual TextBox _nPandingDhrn;

	internal virtual TextBox nPandingDhrn
	{
		get
		{
			return _nPandingDhrn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nPandingDhrn = value;
		}
	}

	internal virtual MaskedTextBox mFromDate
	{
		[CompilerGenerated]
		get
		{
			return _mFromDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = mFromDate_GotFocus;
			KeyEventHandler val = new KeyEventHandler(mFromDate_KeyDown);
			MaskedTextBox val2 = _mFromDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_mFromDate = value;
			val2 = _mFromDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus += eventHandler;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nIntMonth")]
	private virtual TextBox _nIntMonth;

	internal virtual TextBox nIntMonth
	{
		get
		{
			return _nIntMonth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nIntMonth = value;
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

	internal virtual TextBox nDhrnReceived
	{
		[CompilerGenerated]
		get
		{
			return _nDhrnReceived;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nDhrnReceived_KeyDown);
			TextBox val2 = _nDhrnReceived;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nDhrnReceived = value;
			val2 = _nDhrnReceived;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual CheckBox chkInt
	{
		[CompilerGenerated]
		get
		{
			return _chkInt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(chkInt_KeyDown);
			CheckBox val2 = _chkInt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_chkInt = value;
			val2 = _chkInt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nIntYear")]
	private virtual TextBox _nIntYear;

	internal virtual TextBox nIntYear
	{
		get
		{
			return _nIntYear;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nIntYear = value;
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
	[AccessedThroughProperty("nMonthIntAmt")]
	private virtual TextBox _nMonthIntAmt;

	internal virtual TextBox nMonthIntAmt
	{
		get
		{
			return _nMonthIntAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nMonthIntAmt = value;
		}
	}

	internal virtual ComboBox cboIntMonth
	{
		[CompilerGenerated]
		get
		{
			return _cboIntMonth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboIntMonth_KeyDown);
			EventHandler eventHandler = CboIntMonth_SelectedIndexChanged;
			ComboBox val2 = _cboIntMonth;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				val2.SelectedIndexChanged -= eventHandler;
			}
			_cboIntMonth = value;
			val2 = _cboIntMonth;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				val2.SelectedIndexChanged += eventHandler;
			}
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

	internal virtual ComboBox cboLoanType
	{
		[CompilerGenerated]
		get
		{
			return _cboLoanType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboLoanType_KeyDown);
			ComboBox val2 = _cboLoanType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboLoanType = value;
			val2 = _cboLoanType;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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
	[AccessedThroughProperty("nPandingDays")]
	private virtual TextBox _nPandingDays;

	internal virtual TextBox nPandingDays
	{
		get
		{
			return _nPandingDays;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nPandingDays = value;
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

	internal virtual TextBox nUnchakDhrnRec
	{
		[CompilerGenerated]
		get
		{
			return _nUnchakDhrnRec;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nUnchakDhrnRec_KeyDown);
			TextBox val2 = _nUnchakDhrnRec;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nUnchakDhrnRec = value;
			val2 = _nUnchakDhrnRec;
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

	internal virtual TextBox nIntrestKasar
	{
		[CompilerGenerated]
		get
		{
			return _nIntrestKasar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nIntrestKasar_KeyDown);
			TextBox val2 = _nIntrestKasar;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nIntrestKasar = value;
			val2 = _nIntrestKasar;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nRcutAmt
	{
		[CompilerGenerated]
		get
		{
			return _nRcutAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nRcutAmt_KeyDown);
			TextBox val2 = _nRcutAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nRcutAmt = value;
			val2 = _nRcutAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblFineRate")]
	private virtual Label _lblFineRate;

	internal virtual Label lblFineRate
	{
		get
		{
			return _lblFineRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblFineRate = value;
		}
	}

	internal virtual TextBox nFineRate
	{
		[CompilerGenerated]
		get
		{
			return _nFineRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nFineRate_KeyDown);
			EventHandler eventHandler = nFineRate_TextChanged;
			TextBox val2 = _nFineRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_nFineRate = value;
			val2 = _nFineRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblRCutAmt")]
	private virtual Label _lblRCutAmt;

	internal virtual Label lblRCutAmt
	{
		get
		{
			return _lblRCutAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblRCutAmt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblOsAmt")]
	private virtual Label _lblOsAmt;

	internal virtual Label lblOsAmt
	{
		get
		{
			return _lblOsAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblOsAmt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nOsAmt")]
	private virtual TextBox _nOsAmt;

	internal virtual TextBox nOsAmt
	{
		get
		{
			return _nOsAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nOsAmt = value;
		}
	}

	internal virtual TextBox nPayAmt
	{
		[CompilerGenerated]
		get
		{
			return _nPayAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nPayAmt_KeyDown);
			TextBox val2 = _nPayAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nPayAmt = value;
			val2 = _nPayAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblPayAmt")]
	private virtual Label _lblPayAmt;

	internal virtual Label lblPayAmt
	{
		get
		{
			return _lblPayAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblPayAmt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblMobile")]
	private virtual Label _lblMobile;

	internal virtual Label lblMobile
	{
		get
		{
			return _lblMobile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblMobile = value;
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

	public TR_DHRN_INTREC()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((Form)this).Load += TR_DHRN_INTREC_Load;
		((Form)this).Deactivate += TR_DHRN_INTREC_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_DHRN_INTREC_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_DHRN_INTREC_KeyDown);
		((Form)this).Activated += TR_DHRN_INTREC_Activated;
		((Form)this).Closed += TR_DHRN_INTREC_Closed;
		CurIntTypeCalc = "";
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
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Expected O, but got Unknown
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected O, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected O, but got Unknown
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Expected O, but got Unknown
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected O, but got Unknown
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected O, but got Unknown
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Expected O, but got Unknown
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Expected O, but got Unknown
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Expected O, but got Unknown
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected O, but got Unknown
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected O, but got Unknown
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Expected O, but got Unknown
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Expected O, but got Unknown
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Expected O, but got Unknown
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected O, but got Unknown
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected O, but got Unknown
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Expected O, but got Unknown
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Expected O, but got Unknown
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Expected O, but got Unknown
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Expected O, but got Unknown
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Expected O, but got Unknown
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Expected O, but got Unknown
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Expected O, but got Unknown
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Expected O, but got Unknown
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Expected O, but got Unknown
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Expected O, but got Unknown
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Expected O, but got Unknown
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Expected O, but got Unknown
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Expected O, but got Unknown
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Expected O, but got Unknown
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Expected O, but got Unknown
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Expected O, but got Unknown
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Expected O, but got Unknown
		//IL_0492: Unknown result type (might be due to invalid IL or missing references)
		//IL_049c: Expected O, but got Unknown
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		//IL_0510: Expected O, but got Unknown
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cd: Expected O, but got Unknown
		//IL_0650: Unknown result type (might be due to invalid IL or missing references)
		//IL_065a: Expected O, but got Unknown
		//IL_06fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0704: Expected O, but got Unknown
		//IL_07b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bf: Expected O, but got Unknown
		//IL_0849: Unknown result type (might be due to invalid IL or missing references)
		//IL_0853: Expected O, but got Unknown
		//IL_08ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f8: Expected O, but got Unknown
		//IL_0987: Unknown result type (might be due to invalid IL or missing references)
		//IL_0991: Expected O, but got Unknown
		//IL_09f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fe: Expected O, but got Unknown
		//IL_0aa7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab1: Expected O, but got Unknown
		//IL_0b14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1e: Expected O, but got Unknown
		//IL_0bc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd1: Expected O, but got Unknown
		//IL_0cee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf8: Expected O, but got Unknown
		//IL_0e03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0d: Expected O, but got Unknown
		//IL_0e70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e7a: Expected O, but got Unknown
		//IL_100c: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10cb: Expected O, but got Unknown
		//IL_11c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11cd: Expected O, but got Unknown
		//IL_1302: Unknown result type (might be due to invalid IL or missing references)
		//IL_130c: Expected O, but got Unknown
		//IL_13e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ee: Expected O, but got Unknown
		//IL_148a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1494: Expected O, but got Unknown
		//IL_15cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d9: Expected O, but got Unknown
		//IL_1624: Unknown result type (might be due to invalid IL or missing references)
		//IL_162e: Expected O, but got Unknown
		//IL_16ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b5: Expected O, but got Unknown
		//IL_1737: Unknown result type (might be due to invalid IL or missing references)
		//IL_1741: Expected O, but got Unknown
		//IL_180b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1815: Expected O, but got Unknown
		//IL_18bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c6: Expected O, but got Unknown
		//IL_1947: Unknown result type (might be due to invalid IL or missing references)
		//IL_1951: Expected O, but got Unknown
		//IL_19d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e3: Expected O, but got Unknown
		//IL_1a97: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aa1: Expected O, but got Unknown
		//IL_1b55: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b5f: Expected O, but got Unknown
		//IL_1bed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf7: Expected O, but got Unknown
		//IL_1cab: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb5: Expected O, but got Unknown
		//IL_1d44: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d4e: Expected O, but got Unknown
		//IL_1e02: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e0c: Expected O, but got Unknown
		//IL_1ec3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ecd: Expected O, but got Unknown
		//IL_1f7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f88: Expected O, but got Unknown
		//IL_2024: Unknown result type (might be due to invalid IL or missing references)
		//IL_202e: Expected O, but got Unknown
		//IL_20df: Unknown result type (might be due to invalid IL or missing references)
		//IL_20e9: Expected O, but got Unknown
		//IL_2178: Unknown result type (might be due to invalid IL or missing references)
		//IL_2182: Expected O, but got Unknown
		//IL_2240: Unknown result type (might be due to invalid IL or missing references)
		//IL_224a: Expected O, but got Unknown
		//IL_22f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_22fd: Expected O, but got Unknown
		//IL_23ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_23b8: Expected O, but got Unknown
		//IL_2454: Unknown result type (might be due to invalid IL or missing references)
		//IL_245e: Expected O, but got Unknown
		//IL_2512: Unknown result type (might be due to invalid IL or missing references)
		//IL_251c: Expected O, but got Unknown
		//IL_25cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_25d7: Expected O, but got Unknown
		//IL_2666: Unknown result type (might be due to invalid IL or missing references)
		//IL_2670: Expected O, but got Unknown
		//IL_270b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2715: Expected O, but got Unknown
		//IL_27c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_27d0: Expected O, but got Unknown
		//IL_285c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2866: Expected O, but got Unknown
		//IL_28ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_28f8: Expected O, but got Unknown
		//IL_2991: Unknown result type (might be due to invalid IL or missing references)
		//IL_299b: Expected O, but got Unknown
		//IL_2a37: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a41: Expected O, but got Unknown
		//IL_2b12: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b1c: Expected O, but got Unknown
		//IL_2bf4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bfe: Expected O, but got Unknown
		//IL_2c9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ca4: Expected O, but got Unknown
		//IL_2db9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dc3: Expected O, but got Unknown
		//IL_2e44: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e4e: Expected O, but got Unknown
		//IL_2ed6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ee0: Expected O, but got Unknown
		//IL_2f94: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f9e: Expected O, but got Unknown
		//IL_305e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3068: Expected O, but got Unknown
		//IL_30f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_3100: Expected O, but got Unknown
		//IL_3194: Unknown result type (might be due to invalid IL or missing references)
		//IL_319e: Expected O, but got Unknown
		//IL_324f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3259: Expected O, but got Unknown
		//IL_330a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3314: Expected O, but got Unknown
		//IL_33b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_33ba: Expected O, but got Unknown
		//IL_347a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3484: Expected O, but got Unknown
		//IL_3520: Unknown result type (might be due to invalid IL or missing references)
		//IL_352a: Expected O, but got Unknown
		//IL_35c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_35cf: Expected O, but got Unknown
		//IL_3683: Unknown result type (might be due to invalid IL or missing references)
		//IL_368d: Expected O, but got Unknown
		//IL_373e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3748: Expected O, but got Unknown
		//IL_37d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_37e1: Expected O, but got Unknown
		//IL_38a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_38ab: Expected O, but got Unknown
		//IL_3954: Unknown result type (might be due to invalid IL or missing references)
		//IL_395e: Expected O, but got Unknown
		//IL_3a22: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a2c: Expected O, but got Unknown
		//IL_3ac8: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ad2: Expected O, but got Unknown
		//IL_3b93: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b9d: Expected O, but got Unknown
		//IL_3c5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c65: Expected O, but got Unknown
		//IL_3d1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d24: Expected O, but got Unknown
		//IL_3d93: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d9d: Expected O, but got Unknown
		//IL_3e5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e67: Expected O, but got Unknown
		//IL_3ed3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3edd: Expected O, but got Unknown
		//IL_3f8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f98: Expected O, but got Unknown
		//IL_4049: Unknown result type (might be due to invalid IL or missing references)
		//IL_4053: Expected O, but got Unknown
		//IL_40e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_40ec: Expected O, but got Unknown
		//IL_41af: Unknown result type (might be due to invalid IL or missing references)
		//IL_41b9: Expected O, but got Unknown
		//IL_4248: Unknown result type (might be due to invalid IL or missing references)
		//IL_4252: Expected O, but got Unknown
		//IL_4312: Unknown result type (might be due to invalid IL or missing references)
		//IL_431c: Expected O, but got Unknown
		//IL_43a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_43b2: Expected O, but got Unknown
		//IL_4462: Unknown result type (might be due to invalid IL or missing references)
		//IL_446c: Expected O, but got Unknown
		//IL_452a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4534: Expected O, but got Unknown
		//IL_45e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_45ea: Expected O, but got Unknown
		//IL_46ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_46b5: Expected O, but got Unknown
		//IL_4773: Unknown result type (might be due to invalid IL or missing references)
		//IL_477d: Expected O, but got Unknown
		//IL_482a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4834: Expected O, but got Unknown
		//IL_48e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_48eb: Expected O, but got Unknown
		//IL_49ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_49b6: Expected O, but got Unknown
		//IL_4a6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a77: Expected O, but got Unknown
		//IL_4b2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b35: Expected O, but got Unknown
		//IL_4be9: Unknown result type (might be due to invalid IL or missing references)
		//IL_4bf3: Expected O, but got Unknown
		//IL_4ca7: Unknown result type (might be due to invalid IL or missing references)
		//IL_4cb1: Expected O, but got Unknown
		//IL_4d62: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d6c: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_DHRN_INTREC));
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
		FlowLayoutPanel1 = new FlowLayoutPanel();
		BtnLast = new SimpleButton();
		BtnFirst = new SimpleButton();
		DlgOpen = new OpenFileDialog();
		BtnF1 = new SimpleButton();
		Cr = new AxCrystalReport();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label1 = new Label();
		tHdVchNo = new TextBox();
		tEmpCode = new TextBox();
		tEmpName = new TextBox();
		Label3 = new Label();
		Label4 = new Label();
		tVchDesc = new TextBox();
		Label8 = new Label();
		tBillNo = new TextBox();
		LOpAmt = new Label();
		LClAmt = new Label();
		Label16 = new Label();
		nDhrnAmt = new TextBox();
		Label5 = new Label();
		nMonthlyInt = new TextBox();
		Label15 = new Label();
		nDhrnMonth = new TextBox();
		Label17 = new Label();
		nIntPrc = new TextBox();
		Label18 = new Label();
		Label19 = new Label();
		nIntDays = new TextBox();
		mToDate = new MaskedTextBox();
		Label21 = new Label();
		nIntAmt = new TextBox();
		tIsuNo = new TextBox();
		tIsuYrCd = new TextBox();
		tIsuDbCd = new TextBox();
		Label23 = new Label();
		BtnIssue = new SimpleButton();
		tRecAc = new TextBox();
		tRecAcName = new TextBox();
		Label25 = new Label();
		Label6 = new Label();
		nIntRecAmt = new TextBox();
		mIsuDate = new MaskedTextBox();
		Label7 = new Label();
		Label9 = new Label();
		nDhrnAdjAmt = new TextBox();
		Label10 = new Label();
		nPandingDhrn = new TextBox();
		mFromDate = new MaskedTextBox();
		Label11 = new Label();
		Label26 = new Label();
		nIntMonth = new TextBox();
		Label12 = new Label();
		nDhrnReceived = new TextBox();
		chkInt = new CheckBox();
		nIntYear = new TextBox();
		Label29 = new Label();
		Label14 = new Label();
		nMonthIntAmt = new TextBox();
		cboIntMonth = new ComboBox();
		Label24 = new Label();
		cboLoanType = new ComboBox();
		lblLoanType = new Label();
		Label13 = new Label();
		nPandingDays = new TextBox();
		Label20 = new Label();
		nUnchakDhrnRec = new TextBox();
		Label22 = new Label();
		nIntrestKasar = new TextBox();
		nRcutAmt = new TextBox();
		lblFineRate = new Label();
		nFineRate = new TextBox();
		lblRCutAmt = new Label();
		lblOsAmt = new Label();
		nOsAmt = new TextBox();
		nPayAmt = new TextBox();
		lblPayAmt = new Label();
		lblMobile = new Label();
		lblCity = new Label();
		lblAdd1 = new Label();
		Label27 = new Label();
		Label28 = new Label();
		Label30 = new Label();
		((Control)PnlBotam).SuspendLayout();
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
		((Control)lblBook).TabIndex = 15;
		lblBook.Text = "Dhiran Interest Received";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mVchDate).Location = new Point(543, 61);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(466, 62);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)64;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(264, 59);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(62, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchNo).Location = new Point(335, 61);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 23);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mDay).Location = new Point(714, 61);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(91, 23);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mTime).Location = new Point(625, 61);
		((TextBoxBase)mTime).MaxLength = 8;
		((Control)mTime).Name = "mTime";
		((TextBoxBase)mTime).ReadOnly = true;
		((Control)mTime).Size = new Size(83, 23);
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
		((Control)PnlBotam).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnLast);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnFirst);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 16;
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(246, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(575, 36);
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
		((Control)BtnF1).Location = new Point(418, 61);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(35, 23);
		((Control)BtnF1).TabIndex = 1149;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Voucher Help";
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1161, 409);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 1155;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(335, 91);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(77, 23);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(418, 90);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(386, 23);
		((Control)tAcName).TabIndex = 26;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(251, 88);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(75, 20);
		((Control)Label1).TabIndex = 1157;
		Label1.Text = "Party Code";
		Label1.TextAlign = (ContentAlignment)64;
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
		((Control)tEmpCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpCode).Location = new Point(336, 460);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(76, 23);
		((Control)tEmpCode).TabIndex = 14;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(418, 460);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(216, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(257, 459);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(249, 486);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(76, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(335, 489);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(402, 44);
		((Control)tVchDesc).TabIndex = 15;
		((Control)Label8).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(264, 147);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(62, 20);
		((Control)Label8).TabIndex = 1178;
		Label8.Text = "Ref No";
		Label8.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tBillNo).BackColor = Color.White;
		((Control)tBillNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBillNo).Location = new Point(335, 147);
		((TextBoxBase)tBillNo).MaxLength = 20;
		((Control)tBillNo).Name = "tBillNo";
		((TextBoxBase)tBillNo).ReadOnly = true;
		((Control)tBillNo).Size = new Size(117, 23);
		((Control)tBillNo).TabIndex = 25;
		((Control)LOpAmt).BackColor = Color.Transparent;
		((Control)LOpAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpAmt.ImeMode = (ImeMode)0;
		((Control)LOpAmt).Location = new Point(1022, 41);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(148, 20);
		((Control)LOpAmt).TabIndex = 1208;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(1022, 533);
		((Control)LClAmt).Name = "LClAmt";
		((Control)LClAmt).Size = new Size(148, 20);
		((Control)LClAmt).TabIndex = 1211;
		LClAmt.Text = "ClAmt";
		LClAmt.TextAlign = (ContentAlignment)64;
		((Control)Label16).BackColor = Color.Transparent;
		((Control)Label16).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label16).ForeColor = Color.Black;
		Label16.ImeMode = (ImeMode)0;
		((Control)Label16).Location = new Point(247, 176);
		((Control)Label16).Name = "Label16";
		((Control)Label16).Size = new Size(79, 20);
		((Control)Label16).TabIndex = 1213;
		Label16.Text = "Dhiran Amt";
		Label16.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nDhrnAmt).BackColor = Color.OldLace;
		((Control)nDhrnAmt).Font = new Font("Tahoma", 9f);
		((Control)nDhrnAmt).Location = new Point(335, 176);
		((TextBoxBase)nDhrnAmt).MaxLength = 10;
		((Control)nDhrnAmt).Name = "nDhrnAmt";
		((TextBoxBase)nDhrnAmt).ReadOnly = true;
		((Control)nDhrnAmt).Size = new Size(117, 22);
		((Control)nDhrnAmt).TabIndex = 16;
		nDhrnAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(627, 202);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(96, 20);
		((Control)Label5).TabIndex = 1215;
		Label5.Text = "Monthli Int %";
		Label5.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nMonthlyInt).BackColor = Color.White;
		((Control)nMonthlyInt).Font = new Font("Tahoma", 9f);
		((Control)nMonthlyInt).Location = new Point(729, 203);
		((TextBoxBase)nMonthlyInt).MaxLength = 10;
		((Control)nMonthlyInt).Name = "nMonthlyInt";
		((Control)nMonthlyInt).Size = new Size(76, 22);
		((Control)nMonthlyInt).TabIndex = 20;
		nMonthlyInt.TextAlign = (HorizontalAlignment)1;
		((Control)Label15).BackColor = Color.Transparent;
		((Control)Label15).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(833, 231);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(86, 20);
		((Control)Label15).TabIndex = 1221;
		Label15.Text = "Dhiran Month";
		Label15.TextAlign = (ContentAlignment)64;
		((Control)Label15).Visible = false;
		((TextBoxBase)nDhrnMonth).BackColor = Color.White;
		((Control)nDhrnMonth).Font = new Font("Tahoma", 9f);
		((Control)nDhrnMonth).Location = new Point(925, 231);
		((TextBoxBase)nDhrnMonth).MaxLength = 10;
		((Control)nDhrnMonth).Name = "nDhrnMonth";
		((TextBoxBase)nDhrnMonth).ReadOnly = true;
		((Control)nDhrnMonth).Size = new Size(76, 22);
		((Control)nDhrnMonth).TabIndex = 24;
		nDhrnMonth.TextAlign = (HorizontalAlignment)1;
		((Control)nDhrnMonth).Visible = false;
		((Control)Label17).BackColor = Color.Transparent;
		((Control)Label17).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(458, 203);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(79, 20);
		((Control)Label17).TabIndex = 1219;
		Label17.Text = "Interest %";
		Label17.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nIntPrc).BackColor = Color.White;
		((Control)nIntPrc).Font = new Font("Tahoma", 9f);
		((Control)nIntPrc).Location = new Point(543, 203);
		((TextBoxBase)nIntPrc).MaxLength = 10;
		((Control)nIntPrc).Name = "nIntPrc";
		((TextBoxBase)nIntPrc).ReadOnly = true;
		((Control)nIntPrc).Size = new Size(76, 22);
		((Control)nIntPrc).TabIndex = 19;
		nIntPrc.TextAlign = (HorizontalAlignment)1;
		((Control)Label18).BackColor = Color.Transparent;
		((Control)Label18).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label18).ForeColor = Color.Black;
		Label18.ImeMode = (ImeMode)0;
		((Control)Label18).Location = new Point(253, 261);
		((Control)Label18).Name = "Label18";
		((Control)Label18).Size = new Size(73, 20);
		((Control)Label18).TabIndex = 1227;
		Label18.Text = "To Date";
		Label18.TextAlign = (ContentAlignment)64;
		((Control)Label19).BackColor = Color.Transparent;
		((Control)Label19).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label19).ForeColor = Color.Black;
		Label19.ImeMode = (ImeMode)0;
		((Control)Label19).Location = new Point(441, 259);
		((Control)Label19).Name = "Label19";
		((Control)Label19).Size = new Size(96, 20);
		((Control)Label19).TabIndex = 1225;
		Label19.Text = "Interest Days";
		Label19.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nIntDays).BackColor = Color.White;
		((Control)nIntDays).Font = new Font("Tahoma", 9f);
		((Control)nIntDays).Location = new Point(543, 261);
		((TextBoxBase)nIntDays).MaxLength = 10;
		((Control)nIntDays).Name = "nIntDays";
		((Control)nIntDays).Size = new Size(76, 22);
		((Control)nIntDays).TabIndex = 26;
		nIntDays.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mToDate).BackColor = Color.White;
		((Control)mToDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDate).Location = new Point(335, 261);
		mToDate.Mask = "00/00/0000";
		((Control)mToDate).Name = "mToDate";
		((Control)mToDate).Size = new Size(76, 23);
		((Control)mToDate).TabIndex = 25;
		mToDate.ValidatingType = typeof(DateTime);
		((Control)Label21).BackColor = Color.Transparent;
		((Control)Label21).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label21).ForeColor = Color.Black;
		Label21.ImeMode = (ImeMode)0;
		((Control)Label21).Location = new Point(241, 290);
		((Control)Label21).Name = "Label21";
		((Control)Label21).Size = new Size(85, 20);
		((Control)Label21).TabIndex = 1232;
		Label21.Text = "Int Amount";
		Label21.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nIntAmt).BackColor = Color.White;
		((Control)nIntAmt).Font = new Font("Tahoma", 9f);
		((Control)nIntAmt).Location = new Point(335, 290);
		((TextBoxBase)nIntAmt).MaxLength = 10;
		((Control)nIntAmt).Name = "nIntAmt";
		((Control)nIntAmt).Size = new Size(117, 22);
		((Control)nIntAmt).TabIndex = 29;
		nIntAmt.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)tIsuNo).BackColor = Color.White;
		((Control)tIsuNo).Font = new Font("Tahoma", 9f);
		((Control)tIsuNo).Location = new Point(335, 119);
		((TextBoxBase)tIsuNo).MaxLength = 10;
		((Control)tIsuNo).Name = "tIsuNo";
		((Control)tIsuNo).Size = new Size(77, 22);
		((Control)tIsuNo).TabIndex = 4;
		tIsuNo.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)tIsuYrCd).BackColor = Color.White;
		((Control)tIsuYrCd).Font = new Font("Tahoma", 9f);
		((Control)tIsuYrCd).Location = new Point(625, 119);
		((TextBoxBase)tIsuYrCd).MaxLength = 10;
		((Control)tIsuYrCd).Name = "tIsuYrCd";
		((TextBoxBase)tIsuYrCd).ReadOnly = true;
		((Control)tIsuYrCd).Size = new Size(83, 22);
		((Control)tIsuYrCd).TabIndex = 1236;
		tIsuYrCd.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)tIsuDbCd).BackColor = Color.White;
		((Control)tIsuDbCd).Font = new Font("Tahoma", 9f);
		((Control)tIsuDbCd).Location = new Point(714, 119);
		((TextBoxBase)tIsuDbCd).MaxLength = 10;
		((Control)tIsuDbCd).Name = "tIsuDbCd";
		((TextBoxBase)tIsuDbCd).ReadOnly = true;
		((Control)tIsuDbCd).Size = new Size(90, 22);
		((Control)tIsuDbCd).TabIndex = 1237;
		tIsuDbCd.TextAlign = (HorizontalAlignment)1;
		((Control)Label23).BackColor = Color.Transparent;
		((Control)Label23).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label23).ForeColor = Color.Black;
		Label23.ImeMode = (ImeMode)0;
		((Control)Label23).Location = new Point(259, 119);
		((Control)Label23).Name = "Label23";
		((Control)Label23).Size = new Size(67, 20);
		((Control)Label23).TabIndex = 1238;
		Label23.Text = "Issue No";
		Label23.TextAlign = (ContentAlignment)64;
		((BaseStyleControl)BtnIssue).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnIssue).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnIssue).Appearance.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnIssue).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnIssue).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnIssue).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnIssue).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnIssue).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnIssue).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnIssue).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnIssue).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnIssue).AppearanceHovered.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnIssue).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnIssue).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnIssue).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnIssue).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnIssue).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnIssue).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnIssue).AppearancePressed.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnIssue).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnIssue).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnIssue).AppearancePressed.Options.UseFont = true;
		((Control)BtnIssue).Location = new Point(418, 119);
		((BaseControl)BtnIssue).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnIssue).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnIssue).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnIssue).Name = "BtnIssue";
		((Control)BtnIssue).Size = new Size(35, 23);
		((Control)BtnIssue).TabIndex = 1239;
		BtnIssue.Text = "F1";
		((BaseControl)BtnIssue).ToolTip = "Voucher Help";
		((TextBoxBase)tRecAc).BackColor = Color.White;
		((Control)tRecAc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tRecAc).Location = new Point(336, 431);
		((TextBoxBase)tRecAc).MaxLength = 8;
		((Control)tRecAc).Name = "tRecAc";
		((Control)tRecAc).Size = new Size(76, 23);
		((Control)tRecAc).TabIndex = 13;
		((TextBoxBase)tRecAcName).BackColor = Color.White;
		((Control)tRecAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tRecAcName).Location = new Point(418, 431);
		((TextBoxBase)tRecAcName).MaxLength = 50;
		((Control)tRecAcName).Name = "tRecAcName";
		((Control)tRecAcName).Size = new Size(320, 23);
		((Control)tRecAcName).TabIndex = 1242;
		((Control)Label25).BackColor = Color.Transparent;
		((Control)Label25).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label25).ForeColor = Color.Black;
		Label25.ImeMode = (ImeMode)0;
		((Control)Label25).Location = new Point(251, 428);
		((Control)Label25).Name = "Label25";
		((Control)Label25).Size = new Size(75, 20);
		((Control)Label25).TabIndex = 1243;
		Label25.Text = "Issue Ac";
		Label25.TextAlign = (ContentAlignment)64;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(219, 318);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(107, 20);
		((Control)Label6).TabIndex = 1248;
		Label6.Text = "Interest Rec";
		Label6.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nIntRecAmt).BackColor = Color.FromArgb(255, 224, 192);
		((Control)nIntRecAmt).Font = new Font("Tahoma", 9f);
		((Control)nIntRecAmt).Location = new Point(336, 318);
		((TextBoxBase)nIntRecAmt).MaxLength = 10;
		((Control)nIntRecAmt).Name = "nIntRecAmt";
		((Control)nIntRecAmt).Size = new Size(116, 22);
		((Control)nIntRecAmt).TabIndex = 7;
		nIntRecAmt.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)mIsuDate).BackColor = Color.White;
		((Control)mIsuDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mIsuDate).Location = new Point(543, 119);
		mIsuDate.Mask = "00/00/0000";
		((Control)mIsuDate).Name = "mIsuDate";
		mIsuDate.ReadOnly = true;
		((Control)mIsuDate).Size = new Size(76, 23);
		((Control)mIsuDate).TabIndex = 1249;
		mIsuDate.ValidatingType = typeof(DateTime);
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(466, 119);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(71, 20);
		((Control)Label7).TabIndex = 1250;
		Label7.Text = "Isu Date";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)Label9).BackColor = Color.Transparent;
		((Control)Label9).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(458, 174);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(79, 20);
		((Control)Label9).TabIndex = 1252;
		Label9.Text = "Dharan Rec";
		Label9.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nDhrnAdjAmt).BackColor = Color.OldLace;
		((Control)nDhrnAdjAmt).Font = new Font("Tahoma", 9f);
		((Control)nDhrnAdjAmt).Location = new Point(543, 176);
		((TextBoxBase)nDhrnAdjAmt).MaxLength = 10;
		((Control)nDhrnAdjAmt).Name = "nDhrnAdjAmt";
		((TextBoxBase)nDhrnAdjAmt).ReadOnly = true;
		((Control)nDhrnAdjAmt).Size = new Size(76, 22);
		((Control)nDhrnAdjAmt).TabIndex = 17;
		nDhrnAdjAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label10).BackColor = Color.Transparent;
		((Control)Label10).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(228, 204);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(98, 20);
		((Control)Label10).TabIndex = 1254;
		Label10.Text = "Panding Amt";
		Label10.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nPandingDhrn).BackColor = Color.FromArgb(255, 192, 192);
		((Control)nPandingDhrn).Font = new Font("Tahoma", 9f);
		((Control)nPandingDhrn).Location = new Point(335, 204);
		((TextBoxBase)nPandingDhrn).MaxLength = 10;
		((Control)nPandingDhrn).Name = "nPandingDhrn";
		((TextBoxBase)nPandingDhrn).ReadOnly = true;
		((Control)nPandingDhrn).Size = new Size(117, 22);
		((Control)nPandingDhrn).TabIndex = 18;
		nPandingDhrn.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)mFromDate).BackColor = Color.White;
		((Control)mFromDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDate).Location = new Point(335, 232);
		mFromDate.Mask = "00/00/0000";
		((Control)mFromDate).Name = "mFromDate";
		((Control)mFromDate).Size = new Size(76, 23);
		((Control)mFromDate).TabIndex = 22;
		mFromDate.ValidatingType = typeof(DateTime);
		((Control)Label11).BackColor = Color.Transparent;
		((Control)Label11).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(253, 233);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(73, 20);
		((Control)Label11).TabIndex = 1256;
		Label11.Text = "From Date";
		Label11.TextAlign = (ContentAlignment)64;
		((Control)Label26).BackColor = Color.Transparent;
		((Control)Label26).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label26).ForeColor = Color.Black;
		Label26.ImeMode = (ImeMode)0;
		((Control)Label26).Location = new Point(627, 260);
		((Control)Label26).Name = "Label26";
		((Control)Label26).Size = new Size(96, 20);
		((Control)Label26).TabIndex = 1260;
		Label26.Text = "Panding Month ";
		Label26.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nIntMonth).BackColor = Color.White;
		((Control)nIntMonth).Font = new Font("Tahoma", 9f);
		((Control)nIntMonth).Location = new Point(729, 261);
		((TextBoxBase)nIntMonth).MaxLength = 10;
		((Control)nIntMonth).Name = "nIntMonth";
		((Control)nIntMonth).Size = new Size(76, 22);
		((Control)nIntMonth).TabIndex = 27;
		nIntMonth.TextAlign = (HorizontalAlignment)2;
		((Control)Label12).BackColor = Color.Transparent;
		((Control)Label12).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(219, 346);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(107, 20);
		((Control)Label12).TabIndex = 1262;
		Label12.Text = "Dhiran Rec";
		Label12.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nDhrnReceived).BackColor = Color.FromArgb(255, 224, 192);
		((Control)nDhrnReceived).Font = new Font("Tahoma", 9f);
		((Control)nDhrnReceived).Location = new Point(336, 346);
		((TextBoxBase)nDhrnReceived).MaxLength = 10;
		((Control)nDhrnReceived).Name = "nDhrnReceived";
		((Control)nDhrnReceived).Size = new Size(116, 22);
		((Control)nDhrnReceived).TabIndex = 10;
		nDhrnReceived.TextAlign = (HorizontalAlignment)1;
		((ButtonBase)chkInt).BackColor = SystemColors.ButtonHighlight;
		chkInt.Checked = true;
		chkInt.CheckState = (CheckState)1;
		((Control)chkInt).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkInt).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkInt).Location = new Point(543, 150);
		((Control)chkInt).Name = "chkInt";
		((Control)chkInt).RightToLeft = (RightToLeft)0;
		((Control)chkInt).Size = new Size(164, 19);
		((Control)chkInt).TabIndex = 5;
		((ButtonBase)chkInt).Text = "With Compound Intrest";
		chkInt.TextAlign = (ContentAlignment)32;
		((ButtonBase)chkInt).UseVisualStyleBackColor = false;
		((TextBoxBase)nIntYear).BackColor = Color.White;
		((Control)nIntYear).Font = new Font("Tahoma", 9f);
		((Control)nIntYear).Location = new Point(925, 259);
		((TextBoxBase)nIntYear).MaxLength = 10;
		((Control)nIntYear).Name = "nIntYear";
		((Control)nIntYear).Size = new Size(76, 22);
		((Control)nIntYear).TabIndex = 28;
		nIntYear.TextAlign = (HorizontalAlignment)2;
		((Control)nIntYear).Visible = false;
		((Control)Label29).BackColor = Color.Transparent;
		((Control)Label29).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label29).ForeColor = Color.Black;
		Label29.ImeMode = (ImeMode)0;
		((Control)Label29).Location = new Point(827, 259);
		((Control)Label29).Name = "Label29";
		((Control)Label29).Size = new Size(89, 20);
		((Control)Label29).TabIndex = 1273;
		Label29.Text = "Panding Year";
		Label29.TextAlign = (ContentAlignment)64;
		((Control)Label29).Visible = false;
		((Control)Label14).BackColor = Color.Transparent;
		((Control)Label14).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(811, 203);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(108, 20);
		((Control)Label14).TabIndex = 1275;
		Label14.Text = "Monthli Int Amt";
		Label14.TextAlign = (ContentAlignment)64;
		((Control)Label14).Visible = false;
		((TextBoxBase)nMonthIntAmt).BackColor = Color.White;
		((Control)nMonthIntAmt).Font = new Font("Tahoma", 9f);
		((Control)nMonthIntAmt).Location = new Point(925, 203);
		((TextBoxBase)nMonthIntAmt).MaxLength = 10;
		((Control)nMonthIntAmt).Name = "nMonthIntAmt";
		((TextBoxBase)nMonthIntAmt).ReadOnly = true;
		((Control)nMonthIntAmt).Size = new Size(76, 22);
		((Control)nMonthIntAmt).TabIndex = 21;
		nMonthIntAmt.TextAlign = (HorizontalAlignment)1;
		((Control)nMonthIntAmt).Visible = false;
		cboIntMonth.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboIntMonth).Font = new Font("Tahoma", 9f);
		((ListControl)cboIntMonth).FormattingEnabled = true;
		((Control)cboIntMonth).Location = new Point(543, 233);
		((Control)cboIntMonth).Name = "cboIntMonth";
		((Control)cboIntMonth).Size = new Size(76, 22);
		((Control)cboIntMonth).TabIndex = 6;
		((Control)Label24).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label24).ForeColor = Color.Black;
		Label24.ImeMode = (ImeMode)0;
		((Control)Label24).Location = new Point(455, 233);
		((Control)Label24).Name = "Label24";
		((Control)Label24).Size = new Size(82, 20);
		((Control)Label24).TabIndex = 1277;
		Label24.Text = "Int Month";
		Label24.TextAlign = (ContentAlignment)64;
		cboLoanType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboLoanType).Font = new Font("Tahoma", 9f);
		((ListControl)cboLoanType).FormattingEnabled = true;
		((Control)cboLoanType).Location = new Point(897, 62);
		((Control)cboLoanType).Name = "cboLoanType";
		((Control)cboLoanType).Size = new Size(118, 22);
		((Control)cboLoanType).TabIndex = 2;
		((Control)lblLoanType).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblLoanType).ForeColor = Color.Black;
		lblLoanType.ImeMode = (ImeMode)0;
		((Control)lblLoanType).Location = new Point(809, 60);
		((Control)lblLoanType).Name = "lblLoanType";
		((Control)lblLoanType).Size = new Size(82, 20);
		((Control)lblLoanType).TabIndex = 1279;
		lblLoanType.Text = "Loan Type";
		lblLoanType.TextAlign = (ContentAlignment)64;
		((Control)Label13).BackColor = Color.Transparent;
		((Control)Label13).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label13).ForeColor = Color.Black;
		Label13.ImeMode = (ImeMode)0;
		((Control)Label13).Location = new Point(628, 233);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(96, 20);
		((Control)Label13).TabIndex = 1281;
		Label13.Text = "Panding Days";
		Label13.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nPandingDays).BackColor = Color.White;
		((Control)nPandingDays).Font = new Font("Tahoma", 9f);
		((Control)nPandingDays).Location = new Point(729, 232);
		((TextBoxBase)nPandingDays).MaxLength = 10;
		((Control)nPandingDays).Name = "nPandingDays";
		((Control)nPandingDays).Size = new Size(76, 22);
		((Control)nPandingDays).TabIndex = 23;
		nPandingDays.TextAlign = (HorizontalAlignment)2;
		((Control)Label20).BackColor = Color.Transparent;
		((Control)Label20).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label20).ForeColor = Color.Black;
		Label20.ImeMode = (ImeMode)0;
		((Control)Label20).Location = new Point(178, 374);
		((Control)Label20).Name = "Label20";
		((Control)Label20).Size = new Size(147, 20);
		((Control)Label20).TabIndex = 1283;
		Label20.Text = "Unchak Dhiran Rec";
		Label20.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nUnchakDhrnRec).BackColor = Color.FromArgb(255, 224, 192);
		((Control)nUnchakDhrnRec).Font = new Font("Tahoma", 9f);
		((Control)nUnchakDhrnRec).Location = new Point(336, 375);
		((TextBoxBase)nUnchakDhrnRec).MaxLength = 10;
		((Control)nUnchakDhrnRec).Name = "nUnchakDhrnRec";
		((Control)nUnchakDhrnRec).Size = new Size(116, 22);
		((Control)nUnchakDhrnRec).TabIndex = 11;
		nUnchakDhrnRec.TextAlign = (HorizontalAlignment)1;
		((Control)Label22).BackColor = Color.Transparent;
		((Control)Label22).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label22).ForeColor = Color.Black;
		Label22.ImeMode = (ImeMode)0;
		((Control)Label22).Location = new Point(216, 399);
		((Control)Label22).Name = "Label22";
		((Control)Label22).Size = new Size(109, 20);
		((Control)Label22).TabIndex = 1285;
		Label22.Text = "Intrest Kasr";
		Label22.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nIntrestKasar).BackColor = Color.FromArgb(255, 224, 192);
		((Control)nIntrestKasar).Font = new Font("Tahoma", 9f);
		((Control)nIntrestKasar).Location = new Point(336, 403);
		((TextBoxBase)nIntrestKasar).MaxLength = 10;
		((Control)nIntrestKasar).Name = "nIntrestKasar";
		((Control)nIntrestKasar).Size = new Size(116, 22);
		((Control)nIntrestKasar).TabIndex = 12;
		nIntrestKasar.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nRcutAmt).BackColor = Color.Lavender;
		((Control)nRcutAmt).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nRcutAmt).ForeColor = Color.Black;
		((Control)nRcutAmt).Location = new Point(750, 318);
		((TextBoxBase)nRcutAmt).MaxLength = 10;
		((Control)nRcutAmt).Name = "nRcutAmt";
		((Control)nRcutAmt).Size = new Size(90, 22);
		((Control)nRcutAmt).TabIndex = 1294;
		nRcutAmt.TextAlign = (HorizontalAlignment)1;
		((Control)nRcutAmt).Visible = false;
		((Control)lblFineRate).BackColor = Color.Transparent;
		((Control)lblFineRate).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblFineRate).ForeColor = Color.Black;
		lblFineRate.ImeMode = (ImeMode)0;
		((Control)lblFineRate).Location = new Point(460, 318);
		((Control)lblFineRate).Name = "lblFineRate";
		((Control)lblFineRate).Size = new Size(99, 20);
		((Control)lblFineRate).TabIndex = 1293;
		lblFineRate.Text = "Fine Rate 1 gm";
		lblFineRate.TextAlign = (ContentAlignment)64;
		((Control)lblFineRate).Visible = false;
		((TextBoxBase)nFineRate).BackColor = Color.Lavender;
		((Control)nFineRate).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nFineRate).ForeColor = Color.Black;
		((Control)nFineRate).Location = new Point(564, 318);
		((TextBoxBase)nFineRate).MaxLength = 10;
		((Control)nFineRate).Name = "nFineRate";
		((Control)nFineRate).Size = new Size(90, 22);
		((Control)nFineRate).TabIndex = 8;
		nFineRate.TextAlign = (HorizontalAlignment)1;
		((Control)nFineRate).Visible = false;
		((Control)lblRCutAmt).BackColor = Color.Transparent;
		((Control)lblRCutAmt).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblRCutAmt).ForeColor = Color.Black;
		lblRCutAmt.ImeMode = (ImeMode)0;
		((Control)lblRCutAmt).Location = new Point(660, 320);
		((Control)lblRCutAmt).Name = "lblRCutAmt";
		((Control)lblRCutAmt).Size = new Size(88, 20);
		((Control)lblRCutAmt).TabIndex = 1291;
		lblRCutAmt.Text = "Ratecut Amt";
		lblRCutAmt.TextAlign = (ContentAlignment)64;
		((Control)lblRCutAmt).Visible = false;
		((Control)lblOsAmt).BackColor = Color.Transparent;
		((Control)lblOsAmt).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblOsAmt).ForeColor = Color.Black;
		lblOsAmt.ImeMode = (ImeMode)0;
		((Control)lblOsAmt).Location = new Point(663, 348);
		((Control)lblOsAmt).Name = "lblOsAmt";
		((Control)lblOsAmt).Size = new Size(80, 20);
		((Control)lblOsAmt).TabIndex = 1297;
		lblOsAmt.Text = "Os Amount";
		lblOsAmt.TextAlign = (ContentAlignment)64;
		((Control)lblOsAmt).Visible = false;
		((TextBoxBase)nOsAmt).BackColor = Color.Lavender;
		((Control)nOsAmt).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nOsAmt).ForeColor = Color.Red;
		((Control)nOsAmt).Location = new Point(750, 346);
		((TextBoxBase)nOsAmt).MaxLength = 10;
		((Control)nOsAmt).Name = "nOsAmt";
		((Control)nOsAmt).Size = new Size(90, 22);
		((Control)nOsAmt).TabIndex = 1296;
		nOsAmt.TextAlign = (HorizontalAlignment)1;
		((Control)nOsAmt).Visible = false;
		((TextBoxBase)nPayAmt).BackColor = Color.Lavender;
		((Control)nPayAmt).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nPayAmt).ForeColor = Color.Blue;
		((Control)nPayAmt).Location = new Point(564, 348);
		((TextBoxBase)nPayAmt).MaxLength = 10;
		((Control)nPayAmt).Name = "nPayAmt";
		((Control)nPayAmt).Size = new Size(90, 22);
		((Control)nPayAmt).TabIndex = 9;
		nPayAmt.TextAlign = (HorizontalAlignment)1;
		((Control)nPayAmt).Visible = false;
		((Control)lblPayAmt).BackColor = Color.Transparent;
		((Control)lblPayAmt).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblPayAmt).ForeColor = Color.Black;
		lblPayAmt.ImeMode = (ImeMode)0;
		((Control)lblPayAmt).Location = new Point(470, 350);
		((Control)lblPayAmt).Name = "lblPayAmt";
		((Control)lblPayAmt).Size = new Size(88, 20);
		((Control)lblPayAmt).TabIndex = 1298;
		lblPayAmt.Text = "Pay Amt";
		lblPayAmt.TextAlign = (ContentAlignment)64;
		((Control)lblPayAmt).Visible = false;
		((Control)lblMobile).BackColor = Color.Transparent;
		((Control)lblMobile).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lblMobile).ForeColor = Color.Maroon;
		lblMobile.ImeMode = (ImeMode)0;
		((Control)lblMobile).Location = new Point(876, 145);
		((Control)lblMobile).Name = "lblMobile";
		((Control)lblMobile).Size = new Size(286, 20);
		((Control)lblMobile).TabIndex = 1304;
		lblMobile.Text = ":";
		lblMobile.TextAlign = (ContentAlignment)16;
		((Control)lblCity).BackColor = Color.Transparent;
		((Control)lblCity).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lblCity).ForeColor = Color.Maroon;
		lblCity.ImeMode = (ImeMode)0;
		((Control)lblCity).Location = new Point(876, 116);
		((Control)lblCity).Name = "lblCity";
		((Control)lblCity).Size = new Size(286, 20);
		((Control)lblCity).TabIndex = 1303;
		lblCity.Text = ":";
		lblCity.TextAlign = (ContentAlignment)16;
		((Control)lblAdd1).BackColor = Color.Transparent;
		((Control)lblAdd1).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lblAdd1).ForeColor = Color.Maroon;
		lblAdd1.ImeMode = (ImeMode)0;
		((Control)lblAdd1).Location = new Point(876, 90);
		((Control)lblAdd1).Name = "lblAdd1";
		((Control)lblAdd1).Size = new Size(286, 20);
		((Control)lblAdd1).TabIndex = 1302;
		lblAdd1.Text = ":";
		lblAdd1.TextAlign = (ContentAlignment)16;
		((Control)Label27).BackColor = Color.Transparent;
		((Control)Label27).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label27).ForeColor = Color.Maroon;
		Label27.ImeMode = (ImeMode)0;
		((Control)Label27).Location = new Point(797, 146);
		((Control)Label27).Name = "Label27";
		((Control)Label27).Size = new Size(73, 20);
		((Control)Label27).TabIndex = 1301;
		Label27.Text = "Mobile No  :";
		Label27.TextAlign = (ContentAlignment)64;
		((Control)Label28).BackColor = Color.Transparent;
		((Control)Label28).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label28).ForeColor = Color.Maroon;
		Label28.ImeMode = (ImeMode)0;
		((Control)Label28).Location = new Point(811, 117);
		((Control)Label28).Name = "Label28";
		((Control)Label28).Size = new Size(59, 20);
		((Control)Label28).TabIndex = 1300;
		Label28.Text = "City  :";
		Label28.TextAlign = (ContentAlignment)64;
		((Control)Label30).BackColor = Color.Transparent;
		((Control)Label30).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label30).ForeColor = Color.Maroon;
		Label30.ImeMode = (ImeMode)0;
		((Control)Label30).Location = new Point(811, 90);
		((Control)Label30).Name = "Label30";
		((Control)Label30).Size = new Size(59, 20);
		((Control)Label30).TabIndex = 1299;
		Label30.Text = "Add 1  :";
		Label30.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)lblMobile);
		((Control)this).Controls.Add((Control)(object)lblCity);
		((Control)this).Controls.Add((Control)(object)lblAdd1);
		((Control)this).Controls.Add((Control)(object)Label27);
		((Control)this).Controls.Add((Control)(object)Label28);
		((Control)this).Controls.Add((Control)(object)Label30);
		((Control)this).Controls.Add((Control)(object)nPayAmt);
		((Control)this).Controls.Add((Control)(object)lblPayAmt);
		((Control)this).Controls.Add((Control)(object)lblOsAmt);
		((Control)this).Controls.Add((Control)(object)nOsAmt);
		((Control)this).Controls.Add((Control)(object)nRcutAmt);
		((Control)this).Controls.Add((Control)(object)lblFineRate);
		((Control)this).Controls.Add((Control)(object)nFineRate);
		((Control)this).Controls.Add((Control)(object)lblRCutAmt);
		((Control)this).Controls.Add((Control)(object)Label22);
		((Control)this).Controls.Add((Control)(object)nIntrestKasar);
		((Control)this).Controls.Add((Control)(object)Label20);
		((Control)this).Controls.Add((Control)(object)nUnchakDhrnRec);
		((Control)this).Controls.Add((Control)(object)Label13);
		((Control)this).Controls.Add((Control)(object)nPandingDays);
		((Control)this).Controls.Add((Control)(object)cboLoanType);
		((Control)this).Controls.Add((Control)(object)lblLoanType);
		((Control)this).Controls.Add((Control)(object)cboIntMonth);
		((Control)this).Controls.Add((Control)(object)Label24);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)nMonthIntAmt);
		((Control)this).Controls.Add((Control)(object)Label29);
		((Control)this).Controls.Add((Control)(object)nIntYear);
		((Control)this).Controls.Add((Control)(object)chkInt);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)nDhrnReceived);
		((Control)this).Controls.Add((Control)(object)Label26);
		((Control)this).Controls.Add((Control)(object)nIntMonth);
		((Control)this).Controls.Add((Control)(object)mFromDate);
		((Control)this).Controls.Add((Control)(object)Label11);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)nPandingDhrn);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)nDhrnAdjAmt);
		((Control)this).Controls.Add((Control)(object)mIsuDate);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)nIntRecAmt);
		((Control)this).Controls.Add((Control)(object)tRecAc);
		((Control)this).Controls.Add((Control)(object)tRecAcName);
		((Control)this).Controls.Add((Control)(object)Label25);
		((Control)this).Controls.Add((Control)(object)BtnIssue);
		((Control)this).Controls.Add((Control)(object)Label23);
		((Control)this).Controls.Add((Control)(object)tIsuDbCd);
		((Control)this).Controls.Add((Control)(object)tIsuYrCd);
		((Control)this).Controls.Add((Control)(object)tIsuNo);
		((Control)this).Controls.Add((Control)(object)Label21);
		((Control)this).Controls.Add((Control)(object)nIntAmt);
		((Control)this).Controls.Add((Control)(object)mToDate);
		((Control)this).Controls.Add((Control)(object)Label18);
		((Control)this).Controls.Add((Control)(object)Label19);
		((Control)this).Controls.Add((Control)(object)nIntDays);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)nDhrnMonth);
		((Control)this).Controls.Add((Control)(object)Label17);
		((Control)this).Controls.Add((Control)(object)nIntPrc);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)nMonthlyInt);
		((Control)this).Controls.Add((Control)(object)Label16);
		((Control)this).Controls.Add((Control)(object)nDhrnAmt);
		((Control)this).Controls.Add((Control)(object)LClAmt);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tBillNo);
		((Control)this).Controls.Add((Control)(object)tVchDesc);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)tEmpCode);
		((Control)this).Controls.Add((Control)(object)tEmpName);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)tHdVchNo);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)BtnF1);
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
		((Control)this).Name = "TR_DHRN_INTREC";
		((Form)this).Text = "Dhiran Interest Received";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void TR_DHRN_INTREC_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0793: Unknown result type (might be due to invalid IL or missing references)
		//IL_079a: Expected O, but got Unknown
		//IL_087b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0880: Unknown result type (might be due to invalid IL or missing references)
		//IL_088a: Expected O, but got Unknown
		//IL_0912: Unknown result type (might be due to invalid IL or missing references)
		//IL_0917: Unknown result type (might be due to invalid IL or missing references)
		//IL_0921: Expected O, but got Unknown
		//IL_09ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c5: Expected O, but got Unknown
		//IL_0a4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5e: Expected O, but got Unknown
		//IL_0a83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a88: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a92: Expected O, but got Unknown
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
				((ButtonBase)chkInt).BackColor = Color.Silver;
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj9 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				CheckBox obj10 = chkInt;
				object? obj11 = colorConverter.ConvertFromString("200, 205, 210");
				((ButtonBase)obj10).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj12 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj13 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj14 = lblBook;
				object? obj15 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj14).ForeColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj16 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj17 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				CheckBox obj18 = chkInt;
				object? obj19 = colorConverter.ConvertFromString("205, 220, 220");
				((ButtonBase)obj18).BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tVchNo).Font.Size * (1.0 + num2));
				Font font = ((Control)tVchNo).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is CheckBox) && ((Operators.CompareString(val3.Name, "lblBook", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_IDTL", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ORD", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_UPI", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY_2", false) != 0)))
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
			if (Operators.CompareString(FormMainBook, "LOAN INT ENTRY", false) == 0)
			{
				Label16.Text = "Lon Amount";
				Label9.Text = "Old Rec Lon";
				Label12.Text = "Lon Rec";
				CurIntTypeCalc = DC_Main.MsLoanIntType;
			}
			else if (Operators.CompareString(FormMainBook, "OS LETTER", false) == 0)
			{
				CurIntTypeCalc = DC_Main.MsDhrnIntType;
				((Control)lblLoanType).Visible = false;
				((Control)cboLoanType).Visible = false;
			}
			else
			{
				CurIntTypeCalc = DC_Main.MsDhrnIntType;
				lblLoanType.Text = "Dhrn Type";
			}
			cboIntMonth.Items.Add((object)"0");
			cboIntMonth.Items.Add((object)"1");
			cboIntMonth.Items.Add((object)"2");
			cboIntMonth.Items.Add((object)"3");
			cboIntMonth.Items.Add((object)"4");
			cboIntMonth.Items.Add((object)"5");
			cboIntMonth.Items.Add((object)"6");
			cboIntMonth.Items.Add((object)"7");
			cboIntMonth.Items.Add((object)"8");
			cboIntMonth.Items.Add((object)"9");
			cboIntMonth.Items.Add((object)"10");
			cboIntMonth.Items.Add((object)"11");
			cboIntMonth.Items.Add((object)"12");
			cboIntMonth.Items.Add((object)"13");
			cboIntMonth.Items.Add((object)"14");
			cboIntMonth.Items.Add((object)"15");
			cboIntMonth.Items.Add((object)"16");
			cboIntMonth.Items.Add((object)"17");
			cboIntMonth.Items.Add((object)"18");
			cboIntMonth.Items.Add((object)"19");
			cboIntMonth.Items.Add((object)"20");
			cboIntMonth.Items.Add((object)"21");
			cboIntMonth.Items.Add((object)"22");
			cboIntMonth.Items.Add((object)"23");
			cboIntMonth.Items.Add((object)"24");
			cboIntMonth.Items.Add((object)"25");
			cboIntMonth.Items.Add((object)"26");
			cboIntMonth.Items.Add((object)"27");
			cboIntMonth.Items.Add((object)"28");
			cboIntMonth.Items.Add((object)"29");
			cboIntMonth.Items.Add((object)"30");
			cboIntMonth.Items.Add((object)"31");
			cboIntMonth.Items.Add((object)"32");
			cboIntMonth.Items.Add((object)"33");
			cboIntMonth.Items.Add((object)"34");
			cboIntMonth.Items.Add((object)"35");
			cboIntMonth.Items.Add((object)"36");
			cboIntMonth.SelectedIndex = 0;
			cboLoanType.Items.Add((object)"Amount");
			cboLoanType.Items.Add((object)"Gold");
			cboLoanType.Items.Add((object)"Silver");
			cboLoanType.SelectedIndex = 0;
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
		OldAcCode = "";
		OldIsuNo = "";
		((TextBoxBase)tVchNo).ReadOnly = true;
		UsUPdate = "N";
		UsDelete = "N";
		lblAdd1.Text = ":";
		lblCity.Text = ":";
		lblMobile.Text = ":";
		if (Operators.CompareString(FormMainBook, "LOAN INT ENTRY", false) == 0)
		{
			chkInt.Checked = false;
		}
		else if (Operators.CompareString(DC_Main.MsDhrnCompound, "N", false) == 0)
		{
			chkInt.Checked = false;
		}
		else
		{
			chkInt.Checked = true;
		}
		LOpAmt.Text = ": Amt";
		((Control)LOpAmt).ForeColor = Color.Black;
		LClAmt.Text = ": Amt";
		((Control)LClAmt).ForeColor = Color.Black;
		ColorConverter colorConverter = new ColorConverter();
		SimpleButton btnSave = BtnSave;
		object? obj = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnSave).ForeColor = ((obj != null) ? ((Color)obj) : default(Color));
		SimpleButton btnDelete = BtnDelete;
		object? obj2 = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnDelete).ForeColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
		((Control)lblFineRate).Visible = false;
		((Control)lblRCutAmt).Visible = false;
		((Control)lblPayAmt).Visible = false;
		((Control)lblOsAmt).Visible = false;
		((Control)nFineRate).Visible = false;
		((Control)nRcutAmt).Visible = false;
		((Control)nPayAmt).Visible = false;
		((Control)nOsAmt).Visible = false;
		OldValTot = 0.0;
		NewValTot = 0.0;
		OldIntAmt = 0.0;
		OldIntDay = 0;
		OldRCutAmt = 0.0;
		cboIntMonth.SelectedIndex = 0;
		AcGstType = "L";
		tRecAc.Text = "00001";
		cboLoanType.SelectedIndex = 0;
		EditLoad = false;
		if (Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0)
		{
			tEmpCode.Text = "";
		}
		else
		{
			tEmpCode.Text = "001";
		}
		if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
		{
			tEmpCode.Text = DC_Main.MsUserEmpCode;
			tEmpName.Text = DC_Main.MsUserEmpName;
		}
		DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		DC_Main.RsQry = "SELECT * FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
		RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (RsData.Rows.Count > 0)
		{
			EditLoad = true;
			tVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_NO"], (object)""));
			CurPrnVch = tVchNo.Text;
			tHdVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HD_VCH_NO"], (object)""));
			mVchDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DATE"], (object)""));
			mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
			mTime.Text = Strings.Format((object)Conversions.ToDate(RsData.Rows[0]["VCH_TIME"]), "HH:mm:ss");
			mToDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TO_DATE"], (object)""));
			tBillNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["DHRN_BILL"], (object)""));
			tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_CODE"], (object)""));
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_NAME"], (object)""));
			OldAcCode = tAcCode.Text;
			tRecAc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["LEDR_ACCD"], (object)""));
			DC_Main.RsQry = "SELECT * FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tRecAc.Text + "'";
			DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.RsAc.Rows.Count > 0)
			{
				tRecAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				lblAdd1.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_ADD1"], (object)""));
				lblCity.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_CITY"], (object)""));
				lblMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_MOBILE"], (object)""));
			}
			DC_Main.RsAc.Clear();
			DC_Main.RsAc.Columns.Clear();
			mIsuDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["DHRN_DATE"], (object)""));
			if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["LOAN_TYPE"], (object)""), (object)"G", false))
			{
				cboLoanType.SelectedIndex = 1;
			}
			else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["LOAN_TYPE"], (object)""), (object)"S", false))
			{
				cboLoanType.SelectedIndex = 2;
			}
			else
			{
				cboLoanType.SelectedIndex = 0;
			}
			if (cboLoanType.SelectedIndex != 0)
			{
				nDhrnAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DHRN_AMT"]), "0.000");
				nDhrnAdjAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DHRN_ADJ_AMT"]), "0.000");
				nPandingDhrn.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DHRN_OS_AMT"]), "0.000");
				nDhrnReceived.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DHRN_REC_AMT"]), "0.000");
				nUnchakDhrnRec.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["UNCHAK_DHRN_REC"]), "0.000");
				nIntAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["INT_AMT"]), "0.000");
				OldIntAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["INT_AMT"]), "0.000"));
				nIntRecAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["INT_REC_AMT"]), "0.000");
				nMonthIntAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["MONTH_INT_AMT"]), "0.000");
			}
			else
			{
				nDhrnAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DHRN_AMT"]), "0.00");
				nDhrnAdjAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DHRN_ADJ_AMT"]), "0.00");
				nPandingDhrn.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DHRN_OS_AMT"]), "0.00");
				nDhrnReceived.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DHRN_REC_AMT"]), "0.00");
				nUnchakDhrnRec.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["UNCHAK_DHRN_REC"]), "0.00");
				nIntAmt.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["INT_AMT"])), "0.00");
				OldIntAmt = Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["INT_AMT"])), "0.00"));
				nIntRecAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["INT_REC_AMT"]), "0.00");
				nMonthIntAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["MONTH_INT_AMT"]), "0.00");
			}
			nDhrnMonth.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DHRN_MONTH"]), "00");
			mFromDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["FROM_DATE"], (object)""));
			mToDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TO_DATE"], (object)""));
			cboIntMonth.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["INT_MONTH"]), "0");
			nIntDays.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["INT_DAY"]), "0");
			OldIntDay = Conversions.ToInteger(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["INT_DAY"]), "0"));
			nIntPrc.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["INT_PRC"]), "0.00");
			nIntrestKasar.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["KASAR_AMT"]), "0.00");
			if (Conversion.Val(nIntPrc.Text) != 0.0)
			{
				nMonthlyInt.Text = Strings.Format((object)(Conversion.Val(nIntPrc.Text) / 12.0), "0.00");
			}
			tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
			DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
			DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.RsAc.Rows.Count > 0)
			{
				tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["EMP_NAME"], (object)""));
			}
			tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DESC"], (object)""));
			tIsuNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_NO"], (object)""));
			tIsuYrCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_YRCD"], (object)""));
			tIsuDbCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_DBCD"], (object)""));
			MainUser = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MAIN_USER"], (object)""));
			UsUPdate = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_UPDATE"], (object)""));
			UsDelete = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_DELETE"], (object)""));
			nFineRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RCUT_RATE"]), "0.00");
			nRcutAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RCUT_AMT"]), "0.00");
			nPayAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RCUT_PAY_AMT"]), "0.00");
			nOsAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RCUT_OS_AMT"]), "0.00");
			if (Operators.CompareString(UsUPdate, "Y", false) == 0)
			{
				((BaseStyleControl)BtnSave).ForeColor = Color.Green;
			}
			if (Operators.CompareString(UsDelete, "Y", false) == 0)
			{
				((BaseStyleControl)BtnDelete).ForeColor = Color.Green;
			}
			DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
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
			if (DC_Main.MsAcAmtClBal > 0.0)
			{
				LClAmt.Text = Strings.Format((object)DC_Main.MsAcAmtClBal, "0.00") + " : Cr Amt";
				((Control)LClAmt).ForeColor = Color.Blue;
			}
			else if (DC_Main.MsAcAmtClBal < 0.0)
			{
				LClAmt.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcAmtClBal), "0.00") + " : Dr Amt";
				((Control)LClAmt).ForeColor = Color.Red;
			}
			else
			{
				LClAmt.Text = ": Amt";
			}
			CustOpAmt = DC_Main.MsAcAmtOpBal;
			CustClAmt = DC_Main.MsAcAmtClBal;
			DC_Main.MsAcAmtOpBal = 0.0;
			DC_Main.MsAcAmtClBal = 0.0;
			EditLoad = false;
			if (((Operators.CompareString(FormMainBook, "LOAN INT ENTRY", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK236NEVK", false) == 0)) && cboLoanType.SelectedIndex != 0)
			{
				((Control)lblFineRate).Visible = true;
				((Control)lblRCutAmt).Visible = true;
				((Control)lblPayAmt).Visible = true;
				((Control)lblOsAmt).Visible = true;
				((Control)nFineRate).Visible = true;
				((Control)nRcutAmt).Visible = true;
				((Control)nPayAmt).Visible = true;
				((Control)nOsAmt).Visible = true;
			}
			OldValTot = Conversion.Val(nIntAmt.Text) + Conversion.Val(nDhrnReceived.Text);
			NewValTot = Conversion.Val(nIntAmt.Text) + Conversion.Val(nDhrnReceived.Text);
			EntryMode = "E";
			MsVchSrno = "";
			((TextBoxBase)tVchNo).ReadOnly = true;
			((Control)mVchDate).Focus();
		}
		else
		{
			((Control)mVchDate).Focus();
			EntryMode = "A";
			EditLoad = false;
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void TR_DHRN_INTREC_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_DHRN_INTREC_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if ((Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save This Voucher Becouse This Company Type is B......", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		((Control)BtnSave).Enabled = false;
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
		if (Operators.CompareString(tAcCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Insert Party and try", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			((Control)tAcCode).Focus();
			return;
		}
		if (Operators.CompareString(tVchNo.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Insert VchNo and try", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		DC_Main.ExeQuteDc("DELETE FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.ExeQuteDc("DELETE FROM DHRN_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		if (Conversion.Val(nIntAmt.Text) + Conversion.Val(nIntRecAmt.Text) + Conversion.Val(nDhrnReceived.Text) + Conversion.Val(nUnchakDhrnRec.Text) != 0.0)
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
			DC_Main.RsQry = "SELECT * FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow2 = RsData.NewRow();
			dataRow2["CO_CODE"] = DC_Main.MCo_code;
			dataRow2["LC_CODE"] = DC_Main.MLc_code;
			dataRow2["CO_YEAR"] = DC_Main.MCo_year;
			dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
			dataRow2["VCH_NO"] = tVchNo.Text;
			dataRow2["VCH_DATE"] = mVchDate.Text;
			dataRow2["DHRN_BILL"] = tBillNo.Text;
			dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
			dataRow2["AC_CODE"] = tAcCode.Text;
			dataRow2["AC_NAME"] = tAcName.Text;
			dataRow2["FROM_DATE"] = mFromDate.Text;
			dataRow2["TO_DATE"] = mToDate.Text;
			dataRow2["VCH_TYPE"] = FormBookSname;
			dataRow2["INOUT_TYPE"] = FormBookInOut;
			if (Operators.CompareString(FormMainBook, "LOAN INT ENTRY", false) == 0)
			{
				dataRow2["ENTRY_TYPE"] = "L";
			}
			else
			{
				dataRow2["ENTRY_TYPE"] = "D";
			}
			dataRow2["BOOK_NAME"] = FormMainBook;
			dataRow2["DHRN_LIC_NO"] = "";
			dataRow2["PACKET_NO"] = "";
			dataRow2["DHRN_DATE"] = mIsuDate.Text;
			dataRow2["DHRN_AMT"] = Conversion.Val(nDhrnAmt.Text);
			dataRow2["DHRN_ADJ_AMT"] = Conversion.Val(nDhrnAdjAmt.Text);
			dataRow2["DHRN_OS_AMT"] = Conversion.Val(nPandingDhrn.Text);
			dataRow2["DHRN_REC_AMT"] = Conversion.Val(nDhrnReceived.Text);
			dataRow2["UNCHAK_DHRN_REC"] = Conversion.Val(nUnchakDhrnRec.Text);
			dataRow2["DHRN_MONTH"] = Conversion.Val(nDhrnMonth.Text);
			dataRow2["MONTH_INT_AMT"] = Conversion.Val(nMonthIntAmt.Text);
			dataRow2["KASAR_AMT"] = 0;
			dataRow2["LOAN_TYPE"] = Strings.Mid(cboLoanType.Text, 1, 1);
			dataRow2["INT_DAY"] = Conversion.Val(nIntDays.Text);
			dataRow2["INT_PRC"] = Conversion.Val(nIntPrc.Text);
			dataRow2["INT_AMT"] = Conversion.Val(nIntAmt.Text);
			dataRow2["INT_REC_AMT"] = Conversion.Val(nIntRecAmt.Text);
			dataRow2["KASAR_AMT"] = Conversion.Val(nIntrestKasar.Text);
			dataRow2["INT_MONTH"] = Conversion.Val(cboIntMonth.Text);
			dataRow2["LEDR_ACCD"] = tRecAc.Text;
			dataRow2["EMP_CODE"] = tEmpCode.Text;
			dataRow2["GOLD_AMT"] = 0;
			dataRow2["GOLD_WT"] = 0;
			dataRow2["ISU_NO"] = tIsuNo.Text;
			dataRow2["ISU_LC"] = DC_Main.MLc_code;
			dataRow2["ISU_YRCD"] = tIsuYrCd.Text;
			dataRow2["ISU_DBCD"] = tIsuDbCd.Text;
			dataRow2["VCH_DESC"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(tVchDesc.Text, "Text Hear", false) == 0, (object)"", (object)tVchDesc.Text));
			dataRow2["PAN_ADJ_AMT"] = 0;
			dataRow2["ADJ_INT"] = 0;
			dataRow2["ADJ_DHRN"] = 0;
			dataRow2["RCUT_RATE"] = Conversion.Val(nFineRate.Text);
			dataRow2["RCUT_AMT"] = Conversion.Val(nRcutAmt.Text);
			dataRow2["RCUT_PAY_AMT"] = Conversion.Val(nPayAmt.Text);
			dataRow2["RCUT_OS_AMT"] = Conversion.Val(nOsAmt.Text);
			dataRow2["EMP_CODE"] = tEmpCode.Text;
			dataRow2["MAIN_USER"] = MainUser;
			dataRow2["VCH_DESC"] = tVchDesc.Text;
			dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
			dataRow2["DATA_TRFR"] = "N";
			dataRow2["USER_UPDATE"] = "N";
			dataRow2["USER_DELETE"] = "N";
			RsData.Rows.Add(dataRow2);
			((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
			RsData.Clear();
		}
		if (Operators.CompareString(FormMainBook, "LOAN INT ENTRY", false) == 0)
		{
			DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Ledr.Loan_IntRec_Ledr(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Rojmel.Loan_IntRec_RojMel(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Tax.Loan_IntIsu_Data(DC_Main.MCo_Book, tVchNo.Text, DC_Main.MCo_year);
			DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Stock.Loan_Int_Stk(DC_Main.MCo_Book, tVchNo.Text);
		}
		else if (Operators.CompareString(FormMainBook, "OS LETTER", false) != 0)
		{
			DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Ledr.DhrnIntRec_Ledr(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Rojmel.DhrnIntRec_RojMel(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Tax.DhrnIntRec_Data(DC_Main.MCo_Book, tVchNo.Text, DC_Main.MCo_year);
			DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Stock.Dhrn_Int_Stk(DC_Main.MCo_Book, tVchNo.Text);
		}
		Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
		if (Operators.CompareString(FormVchNo, "", false) != 0)
		{
			CLEAR_DATA();
			((Form)this).Close();
			return;
		}
		CurPrnVch = tVchNo.Text;
		DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
		CustOpAmt = DC_Main.MsAcAmtOpBal;
		CustClAmt = DC_Main.MsAcAmtClBal;
		CustOpGold = DC_Main.MsAcGoldOpBal;
		CustClGold = DC_Main.MsAcGoldClBal;
		CustOpSilver = DC_Main.MsAcSilverOpBal;
		CustClSilver = DC_Main.MsAcSilverClBal;
		CLEAR_DATA();
		BtnPrint_Click(BtnPrint, new EventArgs());
		CurPrnVch = "";
		CustOpAmt = 0.0;
		CustClAmt = 0.0;
		CustOpGold = 0.0;
		CustClGold = 0.0;
		CustOpSilver = 0.0;
		CustClSilver = 0.0;
		DC_Main.MsAcAmtOpBal = 0.0;
		DC_Main.MsAcAmtClBal = 0.0;
		DC_Main.MsAcGoldOpBal = 0.0;
		DC_Main.MsAcGoldClBal = 0.0;
		DC_Main.MsAcSilverOpBal = 0.0;
		DC_Main.MsAcSilverClBal = 0.0;
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
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
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,1,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,AC_CODE,AC_NAME,0,INT_REC_AMT,'A',0,0,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "',SUBSTRING(VCH_DESC,1,149) FROM DHRN_REC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_DHRN_INTREC_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && OldValTot == NewValTot)
		{
			((Form)this).Close();
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
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
		if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)
		{
			return;
		}
		if (Operators.CompareString(FormMainBook, "OS LETTER", false) == 0)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\DhrnOsLetter.RPT";
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\DhrnIntRec.RPT";
		}
		Cr.SelectionFormula = "{DHRN_REC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DHRN_REC_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {DHRN_REC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {DHRN_REC_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {DHRN_REC_DATA.VCH_NO} = '" + CurPrnVch + "'";
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
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CustOpAmt = 0.0;
		CustClAmt = 0.0;
		CustOpGold = 0.0;
		CustClGold = 0.0;
		CustOpSilver = 0.0;
		CustClSilver = 0.0;
		CLEAR_DATA();
	}

	private void TR_DHRN_INTREC_Activated(object sender, EventArgs e)
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
			((Control)mVchDate).Focus();
			return;
		}
		if (DC_Main.MsCreat)
		{
			DC_Main.MsCreat = false;
			tAcCode.Text = DC_Main.MsCode;
			tAcName.Text = DC_Main.MsName;
			DC_Main.MsCode = "";
			DC_Main.MsName = "";
		}
		((ContainerControl)this).ActiveControl = CurActCtrl;
		CurActCtrl.Focus();
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL,A.AC_NAME As VchNameL,A.MAIN_USER As UserL FROM DHRN_REC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[6];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 250.0;
		DC_Main.ColWidth[4] = 125.0;
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
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		if (((int)e.KeyCode == 112) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			DC_Main.MsReqBook = DC_Main.MCo_Book;
			DC_Main.MsReqVch = tVchNo.Text;
			DC_Main.MsReqUser = DC_Main.MCo_User;
			DC_Main.MsReqAc = tAcCode.Text;
			((Form)MyProject.Forms.UT_USER_REQUEST).ShowDialog();
		}
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		MaskedTextBox MsDate = mVchDate;
		DC_Main.SetDate(ref MsDate);
		mVchDate = MsDate;
		if (!DC_Main.RongDate)
		{
			if (Operators.CompareString(EntryMode, "E", false) != 0)
			{
				mToDate.Text = mVchDate.Text;
			}
			SendKeys.Send("{TAB}");
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
				DC_Main.RsQry = "SELECT VCH_NO FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void TR_DHRN_INTREC_Closed(object sender, EventArgs e)
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

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(FormMainBook, "LOAN INT ENTRY", false) == 0, (object)"AND A.AC_GR IN('01','03','04')", (object)"AND A.AC_GR = '15'")), (object)" ORDER BY A.AC_NAME"));
			}
			else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(FormMainBook, "LOAN INT ENTRY", false) == 0, (object)"AND A.AC_GR IN('01','03','04')", (object)"AND A.AC_GR = '15'")), (object)" AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME "));
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(FormMainBook, "LOAN INT ENTRY", false) == 0, (object)"AND A.AC_GR IN('01','03','04')", (object)"AND A.AC_GR = '15'")), (object)" ORDER BY A.AC_NAME"));
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
				if (Operators.CompareString(FormMainBook, "LOAN INT ENTRY", false) == 0)
				{
					DC_Main.MsGrCode = "04";
				}
				else
				{
					DC_Main.MsGrCode = "15";
				}
				MS_ACCT mS_ACCT = new MS_ACCT();
				((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)mS_ACCT).Show();
				((Control)mS_ACCT).Focus();
			}
			else
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tAcCode.Text = DC_Main.ColValue[1];
					tAcName.Text = DC_Main.ColValue[0];
				}
				((Control)tAcCode).Focus();
			}
			return;
		}
		if (Operators.CompareString(tAcCode.Text, OldAcCode, false) != 0)
		{
			OldAcCode = tAcCode.Text;
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			AcGstType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GST_TYPE"], (object)""));
			lblAdd1.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_ADD1"], (object)""));
			lblCity.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CITY"], (object)""));
			lblMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_MOBILE"], (object)""));
			DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
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
			DC_Main.MsAcAmtClBal = 0.0;
		}
		SendKeys.Send("{tab}");
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
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
		if (((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)) && (int)e.KeyCode == 112)
		{
			DC_Main.RsQry = "SELECT VCH_DESC As VchDescL FROM DHRN_REC_DATA WHERE VCH_DESC <> '' AND LEN(VCH_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND VCH_DESC <> '' GROUP BY VCH_DESC   ORDER BY VCH_DESC";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[3];
			DC_Main.ColWidth[0] = 700.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				tVchDesc.Text = DC_Main.ColValue[0];
				((TextBoxBase)tVchDesc).SelectionStart = Strings.Len(tVchDesc.Text);
			}
		}
	}

	private void lblBook_DoubleClick(object sender, EventArgs e)
	{
		((Control)tHdVchNo).Visible = true;
	}

	private void BILL_TOTAL()
	{
		checked
		{
			if (Operators.CompareString(CurIntTypeCalc, "M", false) != 0)
			{
				if (((Operators.CompareString(mToDate.Text, DC_Main.MMask, false) != 0) | (Operators.CompareString(mFromDate.Text, DC_Main.MMask, false) != 0)) && ((Operators.CompareString(mToDate.Text, "", false) != 0) | (Operators.CompareString(mFromDate.Text, "", false) != 0)))
				{
					if (Operators.CompareString(DC_Main.MsIntDayCalc, "2", false) == 0)
					{
						nIntDays.Text = Conversions.ToString(Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mToDate.Text), Conversions.ToDate(mFromDate.Text), (FirstDayOfWeek)1, (FirstWeekOfYear)1)) + 1);
					}
					else
					{
						nIntDays.Text = Conversions.ToString(Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mToDate.Text), Conversions.ToDate(mFromDate.Text), (FirstDayOfWeek)1, (FirstWeekOfYear)1)));
					}
				}
			}
			else if ((Conversion.Val(cboIntMonth.Text) != 0.0) & (Operators.CompareString(mToDate.Text, DC_Main.MMask, false) != 0))
			{
				mToDate.Text = mFromDate.Text;
				int num = (int)Math.Round(Conversion.Val(cboIntMonth.Text));
				for (int i = 1; i <= num; i++)
				{
					double num2 = Conversion.Val((object)DateAndTime.Month(Conversions.ToDate(mToDate.Text)));
					if (num2 == 1.0 || num2 == 3.0 || num2 == 5.0 || num2 == 7.0 || num2 == 8.0 || num2 == 10.0 || num2 == 12.0)
					{
						mToDate.Text = Conversions.ToString(Conversions.ToDate(mToDate.Text).AddDays(31.0));
					}
					else if (num2 == 2.0)
					{
						mToDate.Text = Conversions.ToString(Conversions.ToDate(mToDate.Text).AddDays(28.0));
					}
					else if (num2 == 4.0 || num2 == 6.0 || num2 == 9.0 || num2 == 11.0)
					{
						mToDate.Text = Conversions.ToString(Conversions.ToDate(mToDate.Text).AddDays(30.0));
					}
				}
				nIntDays.Text = Conversions.ToString(Conversion.Val(cboIntMonth.Text) * 30.0);
			}
			else if ((Operators.CompareString(mToDate.Text, DC_Main.MMask, false) != 0) | (Operators.CompareString(mFromDate.Text, DC_Main.MMask, false) != 0))
			{
				mToDate.Text = mFromDate.Text;
				nIntDays.Text = "";
				nIntAmt.Text = "";
			}
			if (((Conversion.Val(nIntDays.Text) != 0.0) & (Operators.CompareString(CurIntTypeCalc, "M", false) == 0)) && cboIntMonth.SelectedIndex != 0)
			{
				double num3 = Conversion.Val(nIntDays.Text) - Math.Round(Conversion.Val(nIntDays.Text) / 30.0) * 30.0;
				nIntDays.Text = Conversions.ToString(Conversion.Val(nIntDays.Text) - num3);
			}
			if ((double)OldIntDay != Conversion.Val(nIntDays.Text))
			{
				OldIntDay = (int)Math.Round(Conversion.Val(nIntDays.Text));
				if (chkInt.Checked)
				{
					if ((Operators.CompareString(mFromDate.Text, "", false) != 0) & (Operators.CompareString(mFromDate.Text, DC_Main.MMask, false) != 0))
					{
						int num4 = (int)Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mVchDate.Text), Conversions.ToDate(mFromDate.Text), (FirstDayOfWeek)1, (FirstWeekOfYear)1));
						nIntYear.Text = Strings.Format((object)((double)num4 / 365.0), "0.00");
					}
					if (Conversion.Val(nIntYear.Text) > 1.0)
					{
						if (((Conversion.Val(nPandingDhrn.Text) != 0.0) & (Conversion.Val(nIntDays.Text) != 0.0)) && Operators.CompareString(EntryMode, "E", false) != 0)
						{
							nIntYear.Text = Strings.Mid(nIntYear.Text, 1, 1);
							double num5 = Conversion.Val(nPandingDhrn.Text);
							int num6 = (int)Math.Round(Conversion.Val(nIntYear.Text));
							DC_Main.M = 1;
							double num8 = default(double);
							double num9 = default(double);
							while (DC_Main.M <= num6)
							{
								double num7 = Conversions.ToDouble(Strings.Format((object)Math.Round(num5 * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * 360.0), "0.00"));
								num8 += num7;
								num5 += num7;
								num9 += 360.0;
								DC_Main.M++;
							}
							if (Conversion.Val(nIntDays.Text) >= num9)
							{
								if (cboLoanType.SelectedIndex != 0)
								{
									nIntAmt.Text = Strings.Format((object)Math.Round(num5 * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * (Conversion.Val(nIntDays.Text) - num9) + num8, 3), "0.000");
								}
								else
								{
									nIntAmt.Text = Strings.Format((object)Math.Round(num5 * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * (Conversion.Val(nIntDays.Text) - num9) + num8), "0.00");
								}
							}
							else
							{
								double num10 = 0.0;
								if (cboLoanType.SelectedIndex != 0)
								{
									double num11 = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(nPandingDhrn.Text) * Math.Pow(1.0 + Conversion.Val(nIntPrc.Text) / 100.0, Conversion.Val(nIntYear.Text)) - Conversion.Val(nPandingDhrn.Text)), "0.000"));
									if (num11 != 0.0)
									{
										nIntAmt.Text = Strings.Format((object)(num11 / (Conversion.Val(nIntYear.Text) * 12.0) * Conversion.Val(cboIntMonth.Text)), "0.000");
									}
									else
									{
										nIntAmt.Text = Conversions.ToString(0);
									}
								}
								else
								{
									double num11 = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(nPandingDhrn.Text) * Math.Pow(1.0 + Conversion.Val(nIntPrc.Text) / 100.0, Conversion.Val(nIntYear.Text)) - Conversion.Val(nPandingDhrn.Text)), "0.00"));
									if (num11 != 0.0)
									{
										nIntAmt.Text = Strings.Format((object)(num11 / (Conversion.Val(nIntYear.Text) * 12.0) * Conversion.Val(cboIntMonth.Text)), "0.00");
									}
									else
									{
										nIntAmt.Text = Conversions.ToString(0);
									}
								}
							}
							if (Operators.CompareString(EntryMode, "A", false) == 0 && OldIntAmt != Conversion.Val(nIntAmt.Text))
							{
								OldIntAmt = Conversion.Val(nIntAmt.Text);
								if (cboLoanType.SelectedIndex != 0)
								{
									nIntRecAmt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.000");
								}
								else
								{
									nIntRecAmt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.00");
								}
							}
						}
					}
					else if (((Conversion.Val(nPandingDhrn.Text) != 0.0) & (Conversion.Val(nIntDays.Text) != 0.0)) && Operators.CompareString(EntryMode, "E", false) != 0)
					{
						if (cboLoanType.SelectedIndex != 0)
						{
							if (Conversion.Val(nMonthIntAmt.Text) != 0.0)
							{
								nIntAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nMonthIntAmt.Text) * Conversion.Val(cboIntMonth.Text), 3), "0.000");
								if (OldIntAmt != Conversion.Val(nIntAmt.Text))
								{
									OldIntAmt = Conversion.Val(nIntAmt.Text);
									nIntRecAmt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.00");
								}
							}
							else
							{
								nIntAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nPandingDhrn.Text) * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * Conversion.Val(nIntDays.Text), 3), "0.000");
								if (OldIntAmt != Conversion.Val(nIntAmt.Text))
								{
									OldIntAmt = Conversion.Val(nIntAmt.Text);
									nIntRecAmt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.000");
								}
							}
						}
						else if (Conversion.Val(nMonthIntAmt.Text) != 0.0)
						{
							nIntAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nMonthIntAmt.Text) * Conversion.Val(cboIntMonth.Text), 0), "0.00");
							if (OldIntAmt != Conversion.Val(nIntAmt.Text))
							{
								OldIntAmt = Conversion.Val(nIntAmt.Text);
								nIntRecAmt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.00");
							}
						}
						else
						{
							nIntAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nPandingDhrn.Text) * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * Conversion.Val(nIntDays.Text)), "0.00");
							if (OldIntAmt != Conversion.Val(nIntAmt.Text))
							{
								OldIntAmt = Conversion.Val(nIntAmt.Text);
								nIntRecAmt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.00");
							}
						}
					}
				}
				else if ((Conversion.Val(nPandingDhrn.Text) != 0.0) & (Conversion.Val((object)Conversion.Val(cboIntMonth.Text)) != 0.0))
				{
					if (cboLoanType.SelectedIndex != 0)
					{
						if (Conversion.Val(nMonthIntAmt.Text) != 0.0)
						{
							nIntAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nMonthIntAmt.Text) * Conversion.Val(cboIntMonth.Text), 3), "0.000");
						}
						else
						{
							nIntAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nPandingDhrn.Text) * Conversion.Val(nIntPrc.Text) / 100.0 * (30.0 * Conversion.Val(cboIntMonth.Text)) / DC_Main.MsIntYearDays, 3), "0.000");
						}
						if (OldIntAmt != Conversion.Val(nIntAmt.Text))
						{
							OldIntAmt = Conversion.Val(nIntAmt.Text);
							nIntRecAmt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.000");
						}
					}
					else
					{
						if (Conversion.Val(nMonthIntAmt.Text) != 0.0)
						{
							nIntAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nMonthIntAmt.Text) * Conversion.Val(cboIntMonth.Text), 0), "0.00");
						}
						else
						{
							nIntAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nPandingDhrn.Text) * Conversion.Val(nIntPrc.Text) / 100.0 * (30.0 * Conversion.Val(cboIntMonth.Text)) / DC_Main.MsIntYearDays, 0), "0.00");
						}
						if (OldIntAmt != Conversion.Val(nIntAmt.Text))
						{
							OldIntAmt = Conversion.Val(nIntAmt.Text);
							nIntRecAmt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.00");
						}
					}
				}
				else if (Conversion.Val(nIntDays.Text) != 0.0)
				{
					if (cboLoanType.SelectedIndex != 0)
					{
						nIntAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nPandingDhrn.Text) * Conversion.Val(nIntPrc.Text) / 100.0 * Conversion.Val(nIntDays.Text) / DC_Main.MsIntYearDays, 3), "0.000");
						if (OldIntAmt != Conversion.Val(nIntAmt.Text))
						{
							OldIntAmt = Conversion.Val(nIntAmt.Text);
							nIntRecAmt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.000");
						}
					}
					else
					{
						nIntAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nPandingDhrn.Text) * Conversion.Val(nIntPrc.Text) / 100.0 * Conversion.Val(nIntDays.Text) / DC_Main.MsIntYearDays, 0), "0.00");
						if (OldIntAmt != Conversion.Val(nIntAmt.Text))
						{
							OldIntAmt = Conversion.Val(nIntAmt.Text);
							nIntRecAmt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.00");
						}
					}
				}
			}
			if (Conversion.Val(nIntDays.Text) == 0.0 && Operators.CompareString(EntryMode, "E", false) != 0)
			{
				nIntAmt.Text = "";
			}
			if (((Control)nFineRate).Visible)
			{
				nRcutAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nIntAmt.Text) * Conversion.Val(nFineRate.Text), 0), "0.00");
				nOsAmt.Text = Strings.Format((object)(Conversion.Val(nRcutAmt.Text) - Conversion.Val(nPayAmt.Text)), "0.00");
			}
			if (CustOpAmt > 0.0)
			{
				CustClAmt = CustOpAmt + Conversion.Val(nDhrnReceived.Text) + Conversion.Val(nUnchakDhrnRec.Text);
			}
			else if (CustOpAmt < 0.0)
			{
				CustClAmt = Conversion.Val(nDhrnReceived.Text) + Conversion.Val(nUnchakDhrnRec.Text) - Math.Abs(CustOpAmt);
			}
			else
			{
				CustClAmt = Conversion.Val(nDhrnReceived.Text) + Conversion.Val(nUnchakDhrnRec.Text);
			}
			if (CustClAmt > 0.0)
			{
				LClAmt.Text = Strings.Format((object)CustClAmt, "0.00") + " : Cr Amt";
				((Control)LClAmt).ForeColor = Color.Blue;
			}
			else if (CustClAmt < 0.0)
			{
				LClAmt.Text = Strings.Format((object)Math.Abs(CustClAmt), "0.00") + " : Dr Amt";
				((Control)LClAmt).ForeColor = Color.Red;
			}
			else
			{
				LClAmt.Text = ": Amt";
			}
		}
	}

	private void tBillNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tBankName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tAcName_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)tAcName).SelectionStart = 0;
		((TextBoxBase)tAcName).SelectionLength = Strings.Len(tAcName.Text);
		if (Operators.CompareString(tAcCode.Text, "00050", false) == 0)
		{
			((TextBoxBase)tAcName).ReadOnly = false;
		}
		else
		{
			((TextBoxBase)tAcName).ReadOnly = true;
		}
	}

	private void tAcName_TextChanged(object sender, EventArgs e)
	{
	}

	private void tAcName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tAdd1_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tAdd2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tAdd3_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tCity_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void nDhrnAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (cboLoanType.SelectedIndex != 0)
			{
				nDhrnAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nDhrnAmt.Text)), "0.000");
			}
			else
			{
				nDhrnAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nDhrnAmt.Text)), "0.00");
			}
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nMonthlyInt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nMonthlyInt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nMonthlyInt.Text)), "0.00");
			if (OldMontIntPrc != Conversion.Val(nMonthlyInt.Text))
			{
				OldMontIntPrc = Conversion.Val(nMonthlyInt.Text);
				nIntPrc.Text = Strings.Format((object)(Conversion.Val(nMonthlyInt.Text) * 12.0), "0.00");
			}
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nIntPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nIntPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nIntPrc.Text)), "0.00");
			if ((Conversion.Val(nMonthlyInt.Text) == 0.0) | (OldIntPrc != Conversion.Val(nIntPrc.Text)))
			{
				OldIntPrc = Conversion.Val(nIntPrc.Text);
				nMonthlyInt.Text = Strings.Format((object)(Conversion.Val(nIntPrc.Text) / 12.0), "0.00");
				OldMontIntPrc = Conversion.Val(nMonthlyInt.Text);
			}
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nDhrnMonth_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nDhrnMonth.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nDhrnMonth.Text)), "0");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nIntAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		nIntAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nIntAmt.Text)), "0.00");
		nIntRecAmt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.000");
		if ((double)OldIntDay != Conversion.Val(nIntDays.Text))
		{
			DC_Main.RsQry = "SELECT B.ISU_NO AS IsuNoL,A.DHRN_BILL AS RefNoL,A.VCH_DATE AS IsuDateM,C.AC_NAME,A.DHRN_AMT AS DhiranAmtR,A.INT_PRC AS InterestR,B.ISU_YRCD AS YearM, B.ISU_DBCD As BookM,sum(B.INT_REC_AMT - B.INT_AMT)As IntBalance FROM (DHRN_REC_DATA AS A LEFT JOIN DHRN_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_YEAR = B.ISU_YRCD AND A.CO_BOOK = B.ISU_DBCD AND A.VCH_NO = B.ISU_NO) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE ='" + tAcCode.Text + "' and B.ISU_NO = '" + tIsuNo.Text + "' AND B.ISU_DBCD = '" + tIsuDbCd.Text + "' AND B.ISU_YRCD  = '" + tIsuYrCd.Text + "' GROUP BY A.VCH_DATE,B.ISU_NO,A.DHRN_AMT,A.INT_PRC,C.AC_NAME,B.ISU_DBCD,B.ISU_YRCD,A.DHRN_BILL HAVING SUM(B.INT_REC_AMT - B.INT_AMT) >0 ORDER BY A.VCH_DATE,B.ISU_NO";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count > 0)
			{
				if (cboLoanType.SelectedIndex != 0)
				{
					if (Conversion.Val(nIntAmt.Text) >= Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IntBalance"]), "0.000")))
					{
						nIntRecAmt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.000");
					}
					else
					{
						nIntRecAmt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.000");
						nDhrnReceived.Text = Strings.Format((object)Conversion.Val(nPandingDhrn.Text), "0.000");
					}
				}
				else if (Conversion.Val(nIntAmt.Text) >= Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IntBalance"]), "0.00")))
				{
					nIntRecAmt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.00");
				}
				else
				{
					nIntRecAmt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.00");
					nDhrnReceived.Text = Strings.Format((object)Conversion.Val(nPandingDhrn.Text), "0.00");
				}
			}
			else if (cboLoanType.SelectedIndex != 0)
			{
				nIntRecAmt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.000");
			}
			else
			{
				nIntRecAmt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.00");
			}
		}
		BILL_TOTAL();
		((Control)nIntRecAmt).Focus();
	}

	private void tPacketNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tRecAc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tRecAc.Text + "'";
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
					tRecAc.Text = DC_Main.ColValue[1];
					tRecAcName.Text = DC_Main.ColValue[0];
				}
				((Control)tRecAc).Focus();
			}
		}
		else
		{
			tRecAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			SendKeys.Send("{TAB}");
		}
	}

	private void BtnIssue_Click(object sender, EventArgs e)
	{
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT B.ISU_NO AS IsuNoL,A.DHRN_BILL AS RefNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS IsuDateM,C.AC_NAME,A.DHRN_AMT AS DhiranAmtR,A.INT_PRC AS InterestR,B.ISU_YRCD AS YearM, B.ISU_DBCD As BookM,sum(B.DHRN_REC_AMT)As DhrnRecR,SUM(B.UNCHAK_DHRN_REC) AS UnchakRecR,A.GOLD_DESC AS ItemName FROM (DHRN_ISU_DATA AS A LEFT JOIN DHRN_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.ISU_YRCD AND A.CO_BOOK = B.ISU_DBCD AND A.VCH_NO = B.ISU_NO) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE ='" + tAcCode.Text + "' AND A.LOAN_TYPE = '" + Strings.Mid(cboLoanType.Text, 1, 1) + "' GROUP BY A.VCH_DATE,B.ISU_NO,A.DHRN_AMT,A.INT_PRC,C.AC_NAME,B.ISU_DBCD,B.ISU_YRCD,A.DHRN_BILL,A.GOLD_DESC HAVING (SUM(B.DHRN_REC_AMT)+SUM(B.UNCHAK_DHRN_REC)) < A.DHRN_AMT  ORDER BY A.VCH_DATE,B.ISU_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[12];
		DC_Main.ColWidth[0] = 90.0;
		DC_Main.ColWidth[1] = 90.0;
		DC_Main.ColWidth[2] = 120.0;
		DC_Main.ColWidth[3] = 300.0;
		DC_Main.ColWidth[4] = 100.0;
		DC_Main.ColWidth[5] = 80.0;
		DC_Main.ColWidth[6] = 0.0;
		DC_Main.ColWidth[7] = 0.0;
		DC_Main.ColWidth[8] = 110.0;
		DC_Main.ColWidth[9] = 110.0;
		DC_Main.ColWidth[10] = 250.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				tIsuNo.Text = DC_Main.ColValue[0];
				tIsuYrCd.Text = DC_Main.ColValue[6];
				tIsuDbCd.Text = DC_Main.ColValue[7];
				nDhrnAdjAmt.Text = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.00");
				((Control)tIsuNo).Focus();
			}
			else
			{
				((Control)tIsuNo).Focus();
			}
		}
	}

	private void tIsuNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if ((Operators.CompareString(tIsuNo.Text, "", false) == 0) | (Operators.CompareString(OldIsuNo, tIsuNo.Text, false) != 0))
		{
			DC_Main.RsQry = "Select A.* from DHRN_ISU_DATA AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + tIsuYrCd.Text + "' AND A.CO_BOOK ='" + tIsuDbCd.Text + "'  AND A.VCH_NO = '" + tIsuNo.Text + "' AND A.AC_CODE ='" + tAcCode.Text + "'  ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				BtnIssue_Click(BtnIssue, new EventArgs());
				((Control)tIsuNo).Focus();
				return;
			}
			mIsuDate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VCH_DATE"]), "dd/MM/yyyy");
			OldIsuNo = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_NO"], (object)""));
			tBillNo.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DHRN_BILL"], (object)""));
			if (cboLoanType.SelectedIndex != 0)
			{
				if (Operators.ConditionalCompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["MONTH_INT_AMT"], (object)0, false))
				{
					((Control)Label14).Visible = true;
					((Control)nMonthIntAmt).Visible = true;
				}
				nDhrnAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["DHRN_AMT"]), "0.000");
				nMonthIntAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["MONTH_INT_AMT"]), "0.000");
				nPandingDhrn.Text = Strings.Format((object)(Conversion.Val(nDhrnAmt.Text) - Conversion.Val(nDhrnAdjAmt.Text)), "0.000");
			}
			else
			{
				nDhrnAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["DHRN_AMT"]), "0.00");
				nMonthIntAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["MONTH_INT_AMT"]), "0.00");
				nPandingDhrn.Text = Strings.Format((object)(Conversion.Val(nDhrnAmt.Text) - Conversion.Val(nDhrnAdjAmt.Text)), "0.00");
			}
			nDhrnMonth.Text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["DHRN_MONTH"]), "00");
			nIntPrc.Text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["INT_PRC"]), "0.00");
			if (Conversion.Val(nIntPrc.Text) != 0.0)
			{
				nMonthlyInt.Text = Strings.Format((object)(Conversion.Val(nIntPrc.Text) / 12.0), "0.00");
			}
			if (Operators.CompareString(EntryMode, "E", false) != 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND ISU_YRCD = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' AND ISU_DBCD = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND ISU_NO = '"), (object)tIsuNo.Text), (object)"'  AND AC_CODE = '"), DC_Main.Rshlp.Rows[0]["AC_CODE"]), (object)"'  ORDER BY TO_DATE DESC"));
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					mFromDate.Text = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["TO_DATE"], (object)""));
				}
				else
				{
					mFromDate.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_DATE"], (object)""));
				}
				DC_Main.Rshlp.Clear();
				DC_Main.Rshlp.Columns.Clear();
				dataTable.Clear();
				dataTable.Columns.Clear();
				if (DateTime.Compare(Conversions.ToDate(mVchDate.Text), Conversions.ToDate(Strings.Format((object)Conversions.ToDate(mFromDate.Text), "dd/MM/yyyy"))) < 0)
				{
					mToDate.Text = mFromDate.Text;
				}
			}
			if ((Operators.CompareString(EntryMode, "A", false) == 0) & (Operators.CompareString(CurIntTypeCalc, "M", false) != 0))
			{
				mToDate.Text = Conversions.ToString(DC_Main.MsSysDate);
			}
			if ((Operators.CompareString(mFromDate.Text, "", false) != 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
			{
				if (DateTime.Compare(Conversions.ToDate(mVchDate.Text), Conversions.ToDate(Strings.Format((object)Conversions.ToDate(mFromDate.Text), "dd/MM/yyyy"))) < 0)
				{
					nIntMonth.Text = Conversions.ToString(0);
				}
				else if (Operators.CompareString(DC_Main.MsIntDayCalc, "2", false) == 0)
				{
					nPandingDays.Text = Conversions.ToString(checked(Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mVchDate.Text), Conversions.ToDate(mFromDate.Text), (FirstDayOfWeek)1, (FirstWeekOfYear)1)) + 1));
					nIntMonth.Text = Conversions.ToString(Math.Round(Conversion.Val(nPandingDays.Text) / 30.0 - 0.51) + 1.0);
				}
				else
				{
					nPandingDays.Text = Conversions.ToString(Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mVchDate.Text), Conversions.ToDate(mFromDate.Text), (FirstDayOfWeek)1, (FirstWeekOfYear)1)));
					nIntMonth.Text = Conversions.ToString(Math.Round(Conversion.Val(nPandingDays.Text) / 30.0 - 0.51) + 1.0);
				}
			}
			BILL_TOTAL();
			((Control)cboIntMonth).Focus();
		}
		else
		{
			((Control)cboIntMonth).Focus();
		}
	}

	private void nIntRecAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (cboLoanType.SelectedIndex != 0)
			{
				nIntRecAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nIntRecAmt.Text)), "0.000");
			}
			else
			{
				nIntRecAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nIntRecAmt.Text)), "0.00");
			}
			BILL_TOTAL();
			SendKeys.Send("{tab}");
		}
	}

	private void nIntDays_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nIntDays.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nIntDays.Text)), "0");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void mIsuDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mIsuDate;
			DC_Main.SetDate(ref MsDate);
			mIsuDate = MsDate;
			if (!DC_Main.RongDate)
			{
				SendKeys.Send("{TAB}");
			}
		}
	}

	private void mFromDate_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mFromDate).SelectionStart = 0;
		((TextBoxBase)mFromDate).SelectionLength = Strings.Len(mFromDate.Text);
	}

	private void mFromDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mToDate;
			DC_Main.SetDate(ref MsDate);
			mToDate = MsDate;
			if (!DC_Main.RongDate)
			{
				BILL_TOTAL();
				SendKeys.Send("{TAB}");
			}
		}
	}

	private void mToDate_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mToDate).SelectionStart = 0;
		((TextBoxBase)mToDate).SelectionLength = Strings.Len(mToDate.Text);
	}

	private void mToDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mToDate;
			DC_Main.SetDate(ref MsDate);
			mToDate = MsDate;
			if (!DC_Main.RongDate)
			{
				BILL_TOTAL();
				SendKeys.Send("{TAB}");
			}
		}
	}

	private void nDhrnReceived_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (cboLoanType.SelectedIndex != 0)
			{
				nDhrnReceived.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nDhrnReceived.Text)), "0.000");
			}
			else
			{
				nDhrnReceived.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nDhrnReceived.Text)), "0.00");
			}
			BILL_TOTAL();
			SendKeys.Send("{tab}");
		}
	}

	private void cboIntMonth_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		mToDate.Text = mFromDate.Text;
		checked
		{
			if (Conversion.Val(cboIntMonth.Text) != 0.0)
			{
				int num = (int)Math.Round(Conversion.Val(cboIntMonth.Text));
				for (int i = 1; i <= num; i++)
				{
					double num2 = Conversion.Val(Strings.Mid(mToDate.Text, 4, 2));
					if (num2 == 1.0 || num2 == 3.0 || num2 == 5.0 || num2 == 7.0 || num2 == 8.0 || num2 == 10.0 || num2 == 12.0)
					{
						mToDate.Text = Conversions.ToString(Conversions.ToDate(mToDate.Text).AddDays(31.0));
					}
					else if (num2 == 2.0)
					{
						if (Operators.CompareString(Strings.Mid(mToDate.Text, 1, 2), "01", false) == 0)
						{
							mToDate.Text = Conversions.ToString(Conversions.ToDate(mToDate.Text).AddDays(28.0));
							if (Operators.CompareString(Strings.Mid(mToDate.Text, 1, 2), "29", false) == 0)
							{
								mToDate.Text = Conversions.ToString(Conversions.ToDate(mToDate.Text).AddDays(1.0));
							}
						}
						else
						{
							mToDate.Text = Conversions.ToString(Conversions.ToDate(mToDate.Text).AddDays(28.0));
						}
					}
					else if (num2 == 4.0 || num2 == 6.0 || num2 == 9.0 || num2 == 11.0)
					{
						mToDate.Text = Conversions.ToString(Conversions.ToDate(mToDate.Text).AddDays(30.0));
					}
				}
			}
			else
			{
				if (Operators.CompareString(EntryMode, "A", false) == 0)
				{
					mToDate.Text = mVchDate.Text;
				}
				if (((Operators.CompareString(mToDate.Text, DC_Main.MMask, false) != 0) | (Operators.CompareString(mFromDate.Text, DC_Main.MMask, false) != 0)) && ((Operators.CompareString(mToDate.Text, "", false) != 0) | (Operators.CompareString(mFromDate.Text, "", false) != 0)))
				{
					if (Operators.CompareString(DC_Main.MsIntDayCalc, "2", false) == 0)
					{
						nIntDays.Text = Conversions.ToString(Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mToDate.Text), Conversions.ToDate(mFromDate.Text), (FirstDayOfWeek)1, (FirstWeekOfYear)1)) + 1);
					}
					else
					{
						nIntDays.Text = Conversions.ToString(Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mToDate.Text), Conversions.ToDate(mFromDate.Text), (FirstDayOfWeek)1, (FirstWeekOfYear)1)));
					}
				}
			}
			BILL_TOTAL();
			((Control)nIntRecAmt).Focus();
		}
	}

	private void chkInt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			BILL_TOTAL();
			((Control)cboIntMonth).Focus();
		}
	}

	private void cboLoanType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13 && (int)e.KeyCode == 13)
		{
			if (((Operators.CompareString(FormMainBook, "LOAN INT ENTRY", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK236NEVK", false) == 0)) && cboLoanType.SelectedIndex != 0)
			{
				((Control)lblFineRate).Visible = true;
				((Control)lblRCutAmt).Visible = true;
				((Control)lblPayAmt).Visible = true;
				((Control)lblOsAmt).Visible = true;
				((Control)nFineRate).Visible = true;
				((Control)nRcutAmt).Visible = true;
				((Control)nPayAmt).Visible = true;
				((Control)nOsAmt).Visible = true;
			}
			SendKeys.Send("{tab}");
		}
	}

	private void nUnchakDhrnRec_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (cboLoanType.SelectedIndex != 0)
			{
				nUnchakDhrnRec.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nUnchakDhrnRec.Text)), "0.000");
			}
			else
			{
				nUnchakDhrnRec.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nUnchakDhrnRec.Text)), "0.00");
			}
			BILL_TOTAL();
			SendKeys.Send("{tab}");
		}
	}

	private void nIntrestKasar_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nIntrestKasar.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nIntrestKasar.Text)), "0.00");
			SendKeys.Send("{tab}");
		}
	}

	private void CboIntMonth_SelectedIndexChanged(object sender, EventArgs e)
	{
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		int num5 = default(int);
		int num6 = default(int);
		double num7 = default(double);
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
						if (EditLoad)
						{
							goto end_IL_0001;
						}
						goto IL_0013;
					case 1334:
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
							case 3:
								goto IL_0013;
							case 4:
								goto IL_0037;
							case 5:
								goto IL_0040;
							case 6:
								goto IL_0059;
							case 7:
								goto IL_0082;
							case 8:
								goto IL_00a5;
							case 10:
								goto IL_00c0;
							case 11:
								goto IL_0127;
							case 13:
								goto IL_0162;
							case 14:
								goto IL_017b;
							case 15:
								goto IL_01a7;
							case 16:
								goto IL_01dd;
							case 17:
								goto IL_0206;
							case 20:
								goto IL_0242;
							case 23:
								goto IL_027b;
							case 24:
								goto IL_02bb;
							case 9:
							case 12:
							case 18:
							case 19:
							case 21:
							case 22:
							case 25:
								goto IL_02f2;
							case 27:
								goto IL_030b;
							case 28:
								goto IL_0328;
							case 29:
							case 30:
								goto IL_0344;
							case 31:
								goto IL_0383;
							case 32:
								goto IL_03c2;
							case 33:
								goto IL_03de;
							case 35:
								goto IL_0426;
							case 26:
							case 34:
							case 36:
							case 37:
							case 38:
							case 39:
							case 40:
								goto end_IL_0001_3;
							default:
								goto end_IL_0001_2;
							case 2:
							case 41:
							case 42:
								goto end_IL_0001;
							}
							goto default;
						}
						IL_03de:
						num2 = 33;
						nIntDays.Text = Conversions.ToString(Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mToDate.Text), Conversions.ToDate(mFromDate.Text), (FirstDayOfWeek)1, (FirstWeekOfYear)1)) + 1);
						break;
						IL_0426:
						num2 = 35;
						nIntDays.Text = Conversions.ToString(Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mToDate.Text), Conversions.ToDate(mFromDate.Text), (FirstDayOfWeek)1, (FirstWeekOfYear)1)));
						break;
						IL_03c2:
						num2 = 32;
						if (Operators.CompareString(DC_Main.MsIntDayCalc, "2", false) == 0)
						{
							goto IL_03de;
						}
						goto IL_0426;
						IL_02bb:
						num2 = 24;
						mToDate.Text = Conversions.ToString(Conversions.ToDate(mToDate.Text).AddDays(30.0));
						goto IL_02f2;
						IL_0013:
						num2 = 3;
						if (Operators.CompareString(tAcCode.Text, "", false) == 0)
						{
							goto end_IL_0001;
						}
						goto IL_0037;
						IL_0037:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_0040;
						IL_0040:
						num2 = 5;
						mToDate.Text = mFromDate.Text;
						goto IL_0059;
						IL_0059:
						num2 = 6;
						if (Conversion.Val(cboIntMonth.Text) != 0.0)
						{
							goto IL_0082;
						}
						goto IL_030b;
						IL_0082:
						num2 = 7;
						num5 = (int)Math.Round(Conversion.Val(cboIntMonth.Text));
						num6 = 1;
						goto IL_02fb;
						IL_02fb:
						if (num6 > num5)
						{
							break;
						}
						goto IL_00a5;
						IL_00a5:
						num2 = 8;
						num7 = Conversion.Val(Strings.Mid(mToDate.Text, 4, 2));
						goto IL_00c0;
						IL_00c0:
						num2 = 10;
						if (num7 == 1.0 || num7 == 3.0 || num7 == 5.0 || num7 == 7.0 || num7 == 8.0 || num7 == 10.0 || num7 == 12.0)
						{
							goto IL_0127;
						}
						goto IL_0162;
						IL_0127:
						num2 = 11;
						mToDate.Text = Conversions.ToString(Conversions.ToDate(mToDate.Text).AddDays(31.0));
						goto IL_02f2;
						IL_02f2:
						num2 = 25;
						num6++;
						goto IL_02fb;
						IL_030b:
						num2 = 27;
						if (Operators.CompareString(EntryMode, "A", false) == 0)
						{
							goto IL_0328;
						}
						goto IL_0344;
						IL_0328:
						num2 = 28;
						mToDate.Text = mVchDate.Text;
						goto IL_0344;
						IL_0344:
						num2 = 30;
						if (!((Operators.CompareString(mToDate.Text, DC_Main.MMask, false) != 0) | (Operators.CompareString(mFromDate.Text, DC_Main.MMask, false) != 0)))
						{
							break;
						}
						goto IL_0383;
						IL_0383:
						num2 = 31;
						if (!((Operators.CompareString(mToDate.Text, "", false) != 0) | (Operators.CompareString(mFromDate.Text, "", false) != 0)))
						{
							break;
						}
						goto IL_03c2;
						IL_0162:
						num2 = 13;
						if (num7 == 2.0)
						{
							goto IL_017b;
						}
						goto IL_027b;
						IL_017b:
						num2 = 14;
						if (Operators.CompareString(Strings.Mid(mToDate.Text, 1, 2), "01", false) == 0)
						{
							goto IL_01a7;
						}
						goto IL_0242;
						IL_01a7:
						num2 = 15;
						mToDate.Text = Conversions.ToString(Conversions.ToDate(mToDate.Text).AddDays(28.0));
						goto IL_01dd;
						IL_01dd:
						num2 = 16;
						if (Operators.CompareString(Strings.Mid(mToDate.Text, 1, 2), "29", false) == 0)
						{
							goto IL_0206;
						}
						goto IL_02f2;
						IL_0206:
						num2 = 17;
						mToDate.Text = Conversions.ToString(Conversions.ToDate(mToDate.Text).AddDays(1.0));
						goto IL_02f2;
						IL_0242:
						num2 = 20;
						mToDate.Text = Conversions.ToString(Conversions.ToDate(mToDate.Text).AddDays(28.0));
						goto IL_02f2;
						IL_027b:
						num2 = 23;
						if (num7 == 4.0 || num7 == 6.0 || num7 == 9.0 || num7 == 11.0)
						{
							goto IL_02bb;
						}
						goto IL_02f2;
						end_IL_0001_3:
						break;
					}
					num2 = 40;
					BILL_TOTAL();
					break;
				}
				end_IL_0001_2:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1334;
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

	private void nPayAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nPayAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nPayAmt.Text)), "0.00");
			nOsAmt.Text = Strings.Format((object)(Conversion.Val(nRcutAmt.Text) - Conversion.Val(nPayAmt.Text)), "0.00");
			((Control)tRecAc).Focus();
		}
	}

	private void nFineRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nFineRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nFineRate.Text)), "0.00");
			nRcutAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nIntAmt.Text) * Conversion.Val(nFineRate.Text), 0), "0.00");
			if (Conversion.Val(nPayAmt.Text) == 0.0)
			{
				nPayAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nIntAmt.Text) * Conversion.Val(nFineRate.Text), 0), "0.00");
			}
			OldRCutAmt = Conversion.Val(nPayAmt.Text);
			((Control)nPayAmt).Focus();
		}
	}

	private void nRcutAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nRcutAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nRcutAmt.Text)), "0.00");
			double num = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(nRcutAmt.Text) / Conversion.Val(nFineRate.Text)), "0.000"));
			if (num > Conversion.Val(nIntAmt.Text))
			{
				nDhrnReceived.Text = Strings.Format((object)Math.Round(num - Conversion.Val(nIntAmt.Text), 2), "0.000");
			}
			if (Conversion.Val(nRcutAmt.Text) > OldRCutAmt)
			{
				nPayAmt.Text = Strings.Format((object)Conversion.Val(nRcutAmt.Text), "0.00");
			}
			((Control)nPayAmt).Focus();
		}
	}

	private void nFineRate_TextChanged(object sender, EventArgs e)
	{
	}
}
