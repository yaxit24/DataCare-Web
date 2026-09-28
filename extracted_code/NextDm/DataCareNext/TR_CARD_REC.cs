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
public class TR_CARD_REC : Form
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
	[AccessedThroughProperty("nBankComPrc")]
	private TextBox _nBankComPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nSchPrc")]
	private TextBox _nSchPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCardCommPrc")]
	private TextBox _nCardCommPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCardComAmt")]
	private TextBox _nCardComAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCardAc")]
	private TextBox _tCardAc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nBankCom1")]
	private TextBox _nBankCom1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCardAmt")]
	private TextBox _nCardAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nBankCom2")]
	private TextBox _nBankCom2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCashPaid")]
	private TextBox _nCashPaid;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private string CurPrnVch;

	private string OldAcCode;

	private string AcGstType;

	private double OldCardComPrc;

	private double OldBankComPrc;

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

	private string MsVchSrno;

	private DataTable RsData;

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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = tVchNo_DoubleClick;
			KeyEventHandler val = new KeyEventHandler(tVchNo_KeyDown);
			TextBox val2 = _tVchNo;
			if (val2 != null)
			{
				((Control)val2).DoubleClick -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tVchNo = value;
			val2 = _tVchNo;
			if (val2 != null)
			{
				((Control)val2).DoubleClick += eventHandler;
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
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAcName_KeyDown);
			TextBox val2 = _tAcName;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAcName = value;
			val2 = _tAcName;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nBillAmt")]
	private virtual TextBox _nBillAmt;

	internal virtual TextBox nBillAmt
	{
		get
		{
			return _nBillAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nBillAmt = value;
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

	internal virtual TextBox nBankComPrc
	{
		[CompilerGenerated]
		get
		{
			return _nBankComPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nBankComPrc_KeyDown);
			EventHandler eventHandler = NBankComPrc_TextChanged;
			TextBox val2 = _nBankComPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_nBankComPrc = value;
			val2 = _nBankComPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
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

	internal virtual TextBox nSchPrc
	{
		[CompilerGenerated]
		get
		{
			return _nSchPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nSchPrc_KeyDown);
			TextBox val2 = _nSchPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nSchPrc = value;
			val2 = _nSchPrc;
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

	internal virtual TextBox nCardCommPrc
	{
		[CompilerGenerated]
		get
		{
			return _nCardCommPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nCardCommPrc_KeyDown);
			TextBox val2 = _nCardCommPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nCardCommPrc = value;
			val2 = _nCardCommPrc;
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
	[AccessedThroughProperty("mToDate")]
	private virtual MaskedTextBox _mToDate;

	internal virtual MaskedTextBox mToDate
	{
		get
		{
			return _mToDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_mToDate = value;
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

	internal virtual TextBox nCardComAmt
	{
		[CompilerGenerated]
		get
		{
			return _nCardComAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nCardComAmt_KeyDown);
			TextBox val2 = _nCardComAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nCardComAmt = value;
			val2 = _nCardComAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBillNo")]
	private virtual TextBox _tBillNo;

	internal virtual TextBox tBillNo
	{
		get
		{
			return _tBillNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tBillNo = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBillYrCd")]
	private virtual TextBox _tBillYrCd;

	internal virtual TextBox tBillYrCd
	{
		get
		{
			return _tBillYrCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tBillYrCd = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBillDbCd")]
	private virtual TextBox _tBillDbCd;

	internal virtual TextBox tBillDbCd
	{
		get
		{
			return _tBillDbCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tBillDbCd = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnIssue")]
	private virtual SimpleButton _BtnIssue;

	internal virtual SimpleButton BtnIssue
	{
		get
		{
			return _BtnIssue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnIssue = value;
		}
	}

	internal virtual TextBox tCardAc
	{
		[CompilerGenerated]
		get
		{
			return _tCardAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tRecAc_KeyDown);
			TextBox val2 = _tCardAc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tCardAc = value;
			val2 = _tCardAc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCardBankName")]
	private virtual TextBox _tCardBankName;

	internal virtual TextBox tCardBankName
	{
		get
		{
			return _tCardBankName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tCardBankName = value;
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

	internal virtual TextBox nBankCom1
	{
		[CompilerGenerated]
		get
		{
			return _nBankCom1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nBankCom1_KeyDown);
			TextBox val2 = _nBankCom1;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nBankCom1 = value;
			val2 = _nBankCom1;
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
	[AccessedThroughProperty("nBillAdjAmt")]
	private virtual TextBox _nBillAdjAmt;

	internal virtual TextBox nBillAdjAmt
	{
		get
		{
			return _nBillAdjAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nBillAdjAmt = value;
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

	internal virtual TextBox nCardAmt
	{
		[CompilerGenerated]
		get
		{
			return _nCardAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nCardAmt_KeyDown);
			TextBox val2 = _nCardAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nCardAmt = value;
			val2 = _nCardAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDate")]
	private virtual MaskedTextBox _mFromDate;

	internal virtual MaskedTextBox mFromDate
	{
		get
		{
			return _mFromDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_mFromDate = value;
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

	internal virtual TextBox nBankCom2
	{
		[CompilerGenerated]
		get
		{
			return _nBankCom2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nBankCom2_KeyDown);
			TextBox val2 = _nBankCom2;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nBankCom2 = value;
			val2 = _nBankCom2;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nBankNetAmt")]
	private virtual TextBox _nBankNetAmt;

	internal virtual TextBox nBankNetAmt
	{
		get
		{
			return _nBankNetAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nBankNetAmt = value;
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
	[AccessedThroughProperty("nBillOs")]
	private virtual TextBox _nBillOs;

	internal virtual TextBox nBillOs
	{
		get
		{
			return _nBillOs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nBillOs = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nBankComAmt")]
	private virtual TextBox _nBankComAmt;

	internal virtual TextBox nBankComAmt
	{
		get
		{
			return _nBankComAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nBankComAmt = value;
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

	internal virtual TextBox nCashPaid
	{
		[CompilerGenerated]
		get
		{
			return _nCashPaid;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nUnchakDhrnRec_KeyDown);
			TextBox val2 = _nCashPaid;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nCashPaid = value;
			val2 = _nCashPaid;
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
	[AccessedThroughProperty("nCardNetAmt")]
	private virtual TextBox _nCardNetAmt;

	internal virtual TextBox nCardNetAmt
	{
		get
		{
			return _nCardNetAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nCardNetAmt = value;
		}
	}

	public TR_CARD_REC()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((Form)this).Load += TR_CARD_REC_Load;
		((Form)this).Deactivate += TR_CARD_REC_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_CARD_REC_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_CARD_REC_KeyDown);
		((Form)this).Activated += TR_CARD_REC_Activated;
		((Form)this).Closed += TR_CARD_REC_Closed;
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
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Expected O, but got Unknown
		//IL_044f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Expected O, but got Unknown
		//IL_04dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e6: Expected O, but got Unknown
		//IL_0586: Unknown result type (might be due to invalid IL or missing references)
		//IL_0590: Expected O, but got Unknown
		//IL_0641: Unknown result type (might be due to invalid IL or missing references)
		//IL_064b: Expected O, but got Unknown
		//IL_06d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06df: Expected O, but got Unknown
		//IL_077a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0784: Expected O, but got Unknown
		//IL_0813: Unknown result type (might be due to invalid IL or missing references)
		//IL_081d: Expected O, but got Unknown
		//IL_0880: Unknown result type (might be due to invalid IL or missing references)
		//IL_088a: Expected O, but got Unknown
		//IL_0933: Unknown result type (might be due to invalid IL or missing references)
		//IL_093d: Expected O, but got Unknown
		//IL_09a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09aa: Expected O, but got Unknown
		//IL_0a53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5d: Expected O, but got Unknown
		//IL_0b7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b84: Expected O, but got Unknown
		//IL_0c8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c99: Expected O, but got Unknown
		//IL_0cfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d06: Expected O, but got Unknown
		//IL_0e98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f57: Expected O, but got Unknown
		//IL_104f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1059: Expected O, but got Unknown
		//IL_118e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1198: Expected O, but got Unknown
		//IL_1270: Unknown result type (might be due to invalid IL or missing references)
		//IL_127a: Expected O, but got Unknown
		//IL_1316: Unknown result type (might be due to invalid IL or missing references)
		//IL_1320: Expected O, but got Unknown
		//IL_145b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1465: Expected O, but got Unknown
		//IL_14b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ba: Expected O, but got Unknown
		//IL_1537: Unknown result type (might be due to invalid IL or missing references)
		//IL_1541: Expected O, but got Unknown
		//IL_15c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_15cd: Expected O, but got Unknown
		//IL_1697: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a1: Expected O, but got Unknown
		//IL_1748: Unknown result type (might be due to invalid IL or missing references)
		//IL_1752: Expected O, but got Unknown
		//IL_17d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_17dd: Expected O, but got Unknown
		//IL_1865: Unknown result type (might be due to invalid IL or missing references)
		//IL_186f: Expected O, but got Unknown
		//IL_1923: Unknown result type (might be due to invalid IL or missing references)
		//IL_192d: Expected O, but got Unknown
		//IL_19e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_19eb: Expected O, but got Unknown
		//IL_1a8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a94: Expected O, but got Unknown
		//IL_1b55: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b5f: Expected O, but got Unknown
		//IL_1c23: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c2d: Expected O, but got Unknown
		//IL_1cde: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce8: Expected O, but got Unknown
		//IL_1d76: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d80: Expected O, but got Unknown
		//IL_1e31: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e3b: Expected O, but got Unknown
		//IL_1eca: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed4: Expected O, but got Unknown
		//IL_1f85: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f8f: Expected O, but got Unknown
		//IL_201e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2028: Expected O, but got Unknown
		//IL_20d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_20e3: Expected O, but got Unknown
		//IL_2172: Unknown result type (might be due to invalid IL or missing references)
		//IL_217c: Expected O, but got Unknown
		//IL_222d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2237: Expected O, but got Unknown
		//IL_22c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_22cd: Expected O, but got Unknown
		//IL_2365: Unknown result type (might be due to invalid IL or missing references)
		//IL_236f: Expected O, but got Unknown
		//IL_23fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2404: Expected O, but got Unknown
		//IL_2492: Unknown result type (might be due to invalid IL or missing references)
		//IL_249c: Expected O, but got Unknown
		//IL_2570: Unknown result type (might be due to invalid IL or missing references)
		//IL_257a: Expected O, but got Unknown
		//IL_2652: Unknown result type (might be due to invalid IL or missing references)
		//IL_265c: Expected O, but got Unknown
		//IL_26f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2702: Expected O, but got Unknown
		//IL_281a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2824: Expected O, but got Unknown
		//IL_28a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_28af: Expected O, but got Unknown
		//IL_2937: Unknown result type (might be due to invalid IL or missing references)
		//IL_2941: Expected O, but got Unknown
		//IL_29f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_29ff: Expected O, but got Unknown
		//IL_2ab0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aba: Expected O, but got Unknown
		//IL_2b41: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b4b: Expected O, but got Unknown
		//IL_2bff: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c09: Expected O, but got Unknown
		//IL_2cc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cd1: Expected O, but got Unknown
		//IL_2d79: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d83: Expected O, but got Unknown
		//IL_2e34: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e3e: Expected O, but got Unknown
		//IL_2ecd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ed7: Expected O, but got Unknown
		//IL_2f88: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f92: Expected O, but got Unknown
		//IL_302a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3034: Expected O, but got Unknown
		//IL_30c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_30cd: Expected O, but got Unknown
		//IL_318b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3195: Expected O, but got Unknown
		//IL_323a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3244: Expected O, but got Unknown
		//IL_32d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_32dd: Expected O, but got Unknown
		//IL_338e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3398: Expected O, but got Unknown
		//IL_3413: Unknown result type (might be due to invalid IL or missing references)
		//IL_341d: Expected O, but got Unknown
		//IL_34d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_34db: Expected O, but got Unknown
		//IL_358c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3596: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_CARD_REC));
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
		LOpAmt = new Label();
		LClAmt = new Label();
		Label16 = new Label();
		nBillAmt = new TextBox();
		Label5 = new Label();
		nBankComPrc = new TextBox();
		Label15 = new Label();
		nSchPrc = new TextBox();
		Label17 = new Label();
		nCardCommPrc = new TextBox();
		Label21 = new Label();
		nCardComAmt = new TextBox();
		tBillNo = new TextBox();
		tBillYrCd = new TextBox();
		tBillDbCd = new TextBox();
		Label23 = new Label();
		BtnIssue = new SimpleButton();
		tCardAc = new TextBox();
		tCardBankName = new TextBox();
		Label25 = new Label();
		Label6 = new Label();
		nBankCom1 = new TextBox();
		Label7 = new Label();
		Label9 = new Label();
		nBillAdjAmt = new TextBox();
		Label10 = new Label();
		nCardAmt = new TextBox();
		Label12 = new Label();
		nBankCom2 = new TextBox();
		nBankNetAmt = new TextBox();
		Label14 = new Label();
		nBillOs = new TextBox();
		nBankComAmt = new TextBox();
		Label20 = new Label();
		nCashPaid = new TextBox();
		Label22 = new Label();
		Label8 = new Label();
		nCardNetAmt = new TextBox();
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
		((Control)lblBook).TabIndex = 21;
		lblBook.Text = "Cared Received";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mVchDate).Location = new Point(543, 92);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(466, 93);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)64;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(264, 90);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(62, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchNo).Location = new Point(335, 92);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 23);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mDay).Location = new Point(714, 92);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(91, 23);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mTime).Location = new Point(625, 92);
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
		((Control)PnlBotam).TabIndex = 20;
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
		((Control)BtnF1).Location = new Point(418, 92);
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
		((Control)tAcCode).Location = new Point(335, 121);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 2;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(418, 121);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(386, 23);
		((Control)tAcName).TabIndex = 26;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(251, 119);
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
		((Control)tEmpCode).Location = new Point(335, 430);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(76, 23);
		((Control)tEmpCode).TabIndex = 18;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(418, 430);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(208, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(257, 438);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(250, 466);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(76, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(335, 459);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(402, 53);
		((Control)tVchDesc).TabIndex = 19;
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
		((Control)LOpAmt).Visible = false;
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
		((Control)LClAmt).Visible = false;
		((Control)Label16).BackColor = Color.Transparent;
		((Control)Label16).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label16).ForeColor = Color.Black;
		Label16.ImeMode = (ImeMode)0;
		((Control)Label16).Location = new Point(247, 182);
		((Control)Label16).Name = "Label16";
		((Control)Label16).Size = new Size(79, 20);
		((Control)Label16).TabIndex = 1213;
		Label16.Text = "Bill Amt";
		Label16.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nBillAmt).BackColor = Color.OldLace;
		((Control)nBillAmt).Font = new Font("Tahoma", 9f);
		((Control)nBillAmt).Location = new Point(335, 178);
		((TextBoxBase)nBillAmt).MaxLength = 10;
		((Control)nBillAmt).Name = "nBillAmt";
		((TextBoxBase)nBillAmt).ReadOnly = true;
		((Control)nBillAmt).Size = new Size(76, 22);
		((Control)nBillAmt).TabIndex = 6;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(222, 321);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(107, 20);
		((Control)Label5).TabIndex = 1215;
		Label5.Text = "Bank Comm %";
		Label5.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nBankComPrc).BackColor = Color.White;
		((Control)nBankComPrc).Font = new Font("Tahoma", 9f);
		((Control)nBankComPrc).Location = new Point(335, 318);
		((TextBoxBase)nBankComPrc).MaxLength = 10;
		((Control)nBankComPrc).Name = "nBankComPrc";
		((Control)nBankComPrc).Size = new Size(76, 22);
		((Control)nBankComPrc).TabIndex = 14;
		nBankComPrc.TextAlign = (HorizontalAlignment)1;
		((Control)Label15).BackColor = Color.Transparent;
		((Control)Label15).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(213, 349);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(115, 20);
		((Control)Label15).TabIndex = 1221;
		Label15.Text = "Sch Charg%";
		Label15.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nSchPrc).BackColor = Color.White;
		((Control)nSchPrc).Font = new Font("Tahoma", 9f);
		((Control)nSchPrc).Location = new Point(335, 346);
		((TextBoxBase)nSchPrc).MaxLength = 10;
		((Control)nSchPrc).Name = "nSchPrc";
		((Control)nSchPrc).Size = new Size(76, 22);
		((Control)nSchPrc).TabIndex = 15;
		nSchPrc.TextAlign = (HorizontalAlignment)1;
		((Control)Label17).BackColor = Color.Transparent;
		((Control)Label17).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(444, 208);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(93, 20);
		((Control)Label17).TabIndex = 1219;
		Label17.Text = "Card Comm %";
		Label17.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nCardCommPrc).BackColor = Color.White;
		((Control)nCardCommPrc).Font = new Font("Tahoma", 9f);
		((Control)nCardCommPrc).Location = new Point(543, 208);
		((TextBoxBase)nCardCommPrc).MaxLength = 10;
		((Control)nCardCommPrc).Name = "nCardCommPrc";
		((Control)nCardCommPrc).Size = new Size(83, 22);
		((Control)nCardCommPrc).TabIndex = 10;
		nCardCommPrc.TextAlign = (HorizontalAlignment)1;
		((Control)Label21).BackColor = Color.Transparent;
		((Control)Label21).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label21).ForeColor = Color.Black;
		Label21.ImeMode = (ImeMode)0;
		((Control)Label21).Location = new Point(222, 238);
		((Control)Label21).Name = "Label21";
		((Control)Label21).Size = new Size(105, 20);
		((Control)Label21).TabIndex = 1232;
		Label21.Text = "Card Comm Amt";
		Label21.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nCardComAmt).BackColor = Color.White;
		((Control)nCardComAmt).Font = new Font("Tahoma", 9f);
		((Control)nCardComAmt).Location = new Point(335, 234);
		((TextBoxBase)nCardComAmt).MaxLength = 10;
		((Control)nCardComAmt).Name = "nCardComAmt";
		((Control)nCardComAmt).Size = new Size(76, 22);
		((Control)nCardComAmt).TabIndex = 11;
		nCardComAmt.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)tBillNo).BackColor = Color.White;
		((Control)tBillNo).Font = new Font("Tahoma", 9f);
		((Control)tBillNo).Location = new Point(335, 150);
		((TextBoxBase)tBillNo).MaxLength = 10;
		((Control)tBillNo).Name = "tBillNo";
		((TextBoxBase)tBillNo).ReadOnly = true;
		((Control)tBillNo).Size = new Size(76, 22);
		((Control)tBillNo).TabIndex = 3;
		tBillNo.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)tBillYrCd).BackColor = Color.White;
		((Control)tBillYrCd).Font = new Font("Tahoma", 9f);
		((Control)tBillYrCd).Location = new Point(543, 150);
		((TextBoxBase)tBillYrCd).MaxLength = 10;
		((Control)tBillYrCd).Name = "tBillYrCd";
		((TextBoxBase)tBillYrCd).ReadOnly = true;
		((Control)tBillYrCd).Size = new Size(83, 22);
		((Control)tBillYrCd).TabIndex = 4;
		((TextBoxBase)tBillDbCd).BackColor = Color.White;
		((Control)tBillDbCd).Font = new Font("Tahoma", 9f);
		((Control)tBillDbCd).Location = new Point(714, 150);
		((TextBoxBase)tBillDbCd).MaxLength = 10;
		((Control)tBillDbCd).Name = "tBillDbCd";
		((TextBoxBase)tBillDbCd).ReadOnly = true;
		((Control)tBillDbCd).Size = new Size(90, 22);
		((Control)tBillDbCd).TabIndex = 5;
		((Control)Label23).BackColor = Color.Transparent;
		((Control)Label23).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label23).ForeColor = Color.Black;
		Label23.ImeMode = (ImeMode)0;
		((Control)Label23).Location = new Point(259, 150);
		((Control)Label23).Name = "Label23";
		((Control)Label23).Size = new Size(67, 20);
		((Control)Label23).TabIndex = 1238;
		Label23.Text = "Bill No";
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
		((Control)BtnIssue).Location = new Point(418, 150);
		((BaseControl)BtnIssue).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnIssue).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnIssue).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnIssue).Name = "BtnIssue";
		((Control)BtnIssue).Size = new Size(35, 23);
		((Control)BtnIssue).TabIndex = 1239;
		BtnIssue.Text = "F1";
		((BaseControl)BtnIssue).ToolTip = "Voucher Help";
		((TextBoxBase)tCardAc).BackColor = Color.White;
		((Control)tCardAc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tCardAc).Location = new Point(335, 289);
		((TextBoxBase)tCardAc).MaxLength = 8;
		((Control)tCardAc).Name = "tCardAc";
		((Control)tCardAc).Size = new Size(76, 23);
		((Control)tCardAc).TabIndex = 13;
		((TextBoxBase)tCardBankName).BackColor = Color.White;
		((Control)tCardBankName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tCardBankName).Location = new Point(418, 290);
		((TextBoxBase)tCardBankName).MaxLength = 50;
		((Control)tCardBankName).Name = "tCardBankName";
		((Control)tCardBankName).Size = new Size(387, 23);
		((Control)tCardBankName).TabIndex = 1242;
		((Control)Label25).BackColor = Color.Transparent;
		((Control)Label25).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label25).ForeColor = Color.Black;
		Label25.ImeMode = (ImeMode)0;
		((Control)Label25).Location = new Point(231, 292);
		((Control)Label25).Name = "Label25";
		((Control)Label25).Size = new Size(95, 20);
		((Control)Label25).TabIndex = 1243;
		Label25.Text = "Card Bank Ac";
		Label25.TextAlign = (ContentAlignment)64;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(207, 377);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(119, 20);
		((Control)Label6).TabIndex = 1248;
		Label6.Text = "Bank Comm Amt";
		Label6.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nBankCom1).BackColor = Color.OldLace;
		((Control)nBankCom1).Font = new Font("Tahoma", 9f);
		((Control)nBankCom1).Location = new Point(418, 319);
		((TextBoxBase)nBankCom1).MaxLength = 10;
		((Control)nBankCom1).Name = "nBankCom1";
		((TextBoxBase)nBankCom1).ReadOnly = true;
		((Control)nBankCom1).Size = new Size(96, 22);
		((Control)nBankCom1).TabIndex = 6;
		nBankCom1.TextAlign = (HorizontalAlignment)1;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(466, 150);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(71, 20);
		((Control)Label7).TabIndex = 1250;
		Label7.Text = "Bill Year";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)Label9).BackColor = Color.Transparent;
		((Control)Label9).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(458, 180);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(79, 20);
		((Control)Label9).TabIndex = 1252;
		Label9.Text = "Bill Adj";
		Label9.TextAlign = (ContentAlignment)64;
		((Control)Label9).Visible = false;
		((TextBoxBase)nBillAdjAmt).BackColor = Color.OldLace;
		((Control)nBillAdjAmt).Font = new Font("Tahoma", 9f);
		((Control)nBillAdjAmt).Location = new Point(543, 179);
		((TextBoxBase)nBillAdjAmt).MaxLength = 10;
		((Control)nBillAdjAmt).Name = "nBillAdjAmt";
		((TextBoxBase)nBillAdjAmt).ReadOnly = true;
		((Control)nBillAdjAmt).Size = new Size(83, 22);
		((Control)nBillAdjAmt).TabIndex = 7;
		nBillAdjAmt.TextAlign = (HorizontalAlignment)1;
		((Control)nBillAdjAmt).Visible = false;
		((Control)Label10).BackColor = Color.Transparent;
		((Control)Label10).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(228, 210);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(98, 20);
		((Control)Label10).TabIndex = 1254;
		Label10.Text = "Card Amt";
		Label10.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nCardAmt).BackColor = Color.White;
		((Control)nCardAmt).Font = new Font("Tahoma", 9f);
		((Control)nCardAmt).Location = new Point(335, 206);
		((TextBoxBase)nCardAmt).MaxLength = 10;
		((Control)nCardAmt).Name = "nCardAmt";
		((Control)nCardAmt).Size = new Size(76, 22);
		((Control)nCardAmt).TabIndex = 9;
		nCardAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label12).BackColor = Color.Transparent;
		((Control)Label12).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(219, 405);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(107, 20);
		((Control)Label12).TabIndex = 1262;
		Label12.Text = "Bank Net Amt";
		Label12.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nBankCom2).BackColor = Color.OldLace;
		((Control)nBankCom2).Font = new Font("Tahoma", 9f);
		((Control)nBankCom2).Location = new Point(418, 346);
		((TextBoxBase)nBankCom2).MaxLength = 10;
		((Control)nBankCom2).Name = "nBankCom2";
		((TextBoxBase)nBankCom2).ReadOnly = true;
		((Control)nBankCom2).Size = new Size(96, 22);
		((Control)nBankCom2).TabIndex = 7;
		nBankCom2.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nBankNetAmt).BackColor = Color.MistyRose;
		((Control)nBankNetAmt).Font = new Font("Tahoma", 9f);
		((Control)nBankNetAmt).Location = new Point(335, 402);
		((TextBoxBase)nBankNetAmt).MaxLength = 10;
		((Control)nBankNetAmt).Name = "nBankNetAmt";
		((Control)nBankNetAmt).Size = new Size(76, 22);
		((Control)nBankNetAmt).TabIndex = 17;
		nBankNetAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label14).BackColor = Color.Transparent;
		((Control)Label14).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(632, 180);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(76, 20);
		((Control)Label14).TabIndex = 1275;
		Label14.Text = "Bill Os";
		Label14.TextAlign = (ContentAlignment)64;
		((Control)Label14).Visible = false;
		((TextBoxBase)nBillOs).BackColor = Color.OldLace;
		((Control)nBillOs).Font = new Font("Tahoma", 9f);
		((Control)nBillOs).Location = new Point(714, 179);
		((TextBoxBase)nBillOs).MaxLength = 10;
		((Control)nBillOs).Name = "nBillOs";
		((TextBoxBase)nBillOs).ReadOnly = true;
		((Control)nBillOs).Size = new Size(90, 22);
		((Control)nBillOs).TabIndex = 8;
		nBillOs.TextAlign = (HorizontalAlignment)1;
		((Control)nBillOs).Visible = false;
		((TextBoxBase)nBankComAmt).BackColor = Color.White;
		((Control)nBankComAmt).Font = new Font("Tahoma", 9f);
		((Control)nBankComAmt).Location = new Point(335, 374);
		((TextBoxBase)nBankComAmt).MaxLength = 10;
		((Control)nBankComAmt).Name = "nBankComAmt";
		((Control)nBankComAmt).Size = new Size(76, 22);
		((Control)nBankComAmt).TabIndex = 16;
		nBankComAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label20).BackColor = Color.Transparent;
		((Control)Label20).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label20).ForeColor = Color.Black;
		Label20.ImeMode = (ImeMode)0;
		((Control)Label20).Location = new Point(418, 263);
		((Control)Label20).Name = "Label20";
		((Control)Label20).Size = new Size(119, 20);
		((Control)Label20).TabIndex = 1283;
		Label20.Text = "Cash Paid Amt";
		Label20.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nCashPaid).BackColor = Color.White;
		((Control)nCashPaid).Font = new Font("Tahoma", 9f);
		((Control)nCashPaid).Location = new Point(543, 262);
		((TextBoxBase)nCashPaid).MaxLength = 10;
		((Control)nCashPaid).Name = "nCashPaid";
		((Control)nCashPaid).Size = new Size(83, 22);
		((Control)nCashPaid).TabIndex = 12;
		nCashPaid.TextAlign = (HorizontalAlignment)1;
		((Control)Label22).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label22).ForeColor = Color.Black;
		Label22.ImeMode = (ImeMode)0;
		((Control)Label22).Location = new Point(637, 150);
		((Control)Label22).Name = "Label22";
		((Control)Label22).Size = new Size(71, 20);
		((Control)Label22).TabIndex = 1284;
		Label22.Text = "Bill Book";
		Label22.TextAlign = (ContentAlignment)64;
		((Control)Label8).BackColor = Color.Transparent;
		((Control)Label8).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(222, 263);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(105, 20);
		((Control)Label8).TabIndex = 1286;
		Label8.Text = "Card Net Amt";
		Label8.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nCardNetAmt).BackColor = Color.MistyRose;
		((Control)nCardNetAmt).Font = new Font("Tahoma", 9f);
		((Control)nCardNetAmt).Location = new Point(335, 261);
		((TextBoxBase)nCardNetAmt).MaxLength = 10;
		((Control)nCardNetAmt).Name = "nCardNetAmt";
		((Control)nCardNetAmt).Size = new Size(76, 22);
		((Control)nCardNetAmt).TabIndex = 1285;
		nCardNetAmt.TextAlign = (HorizontalAlignment)1;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)nCardNetAmt);
		((Control)this).Controls.Add((Control)(object)Label22);
		((Control)this).Controls.Add((Control)(object)Label20);
		((Control)this).Controls.Add((Control)(object)nCashPaid);
		((Control)this).Controls.Add((Control)(object)nBankComAmt);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)nBillOs);
		((Control)this).Controls.Add((Control)(object)nBankNetAmt);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)nBankCom2);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)nCardAmt);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)nBillAdjAmt);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)nBankCom1);
		((Control)this).Controls.Add((Control)(object)tCardAc);
		((Control)this).Controls.Add((Control)(object)tCardBankName);
		((Control)this).Controls.Add((Control)(object)Label25);
		((Control)this).Controls.Add((Control)(object)BtnIssue);
		((Control)this).Controls.Add((Control)(object)Label23);
		((Control)this).Controls.Add((Control)(object)tBillDbCd);
		((Control)this).Controls.Add((Control)(object)tBillYrCd);
		((Control)this).Controls.Add((Control)(object)tBillNo);
		((Control)this).Controls.Add((Control)(object)Label21);
		((Control)this).Controls.Add((Control)(object)nCardComAmt);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)nSchPrc);
		((Control)this).Controls.Add((Control)(object)Label17);
		((Control)this).Controls.Add((Control)(object)nCardCommPrc);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)nBankComPrc);
		((Control)this).Controls.Add((Control)(object)Label16);
		((Control)this).Controls.Add((Control)(object)nBillAmt);
		((Control)this).Controls.Add((Control)(object)LClAmt);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
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
		((Control)this).Name = "TR_CARD_REC";
		((Form)this).Text = "Cared Received";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void TR_CARD_REC_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_072a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0731: Expected O, but got Unknown
		//IL_07b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c6: Expected O, but got Unknown
		//IL_0875: Unknown result type (might be due to invalid IL or missing references)
		//IL_087a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0884: Expected O, but got Unknown
		//IL_091d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0922: Unknown result type (might be due to invalid IL or missing references)
		//IL_0928: Expected O, but got Unknown
		//IL_09b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c1: Expected O, but got Unknown
		//IL_09e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f5: Expected O, but got Unknown
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
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj9 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj10 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj11 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj12 = lblBook;
				object? obj13 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj12).ForeColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj14 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj15 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
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
			BtnCancel_Click(BtnCancel, new EventArgs());
			if (DC_Main.MsCardSlAdj)
			{
				tBillNo.Text = DC_Main.MsSlBill;
				tAcCode.Text = DC_Main.MsSlAcCode;
				tBillYrCd.Text = DC_Main.MsSlYrCd;
				tBillDbCd.Text = DC_Main.MsSlDbCd;
				nBillAmt.Text = Strings.Format((object)DC_Main.MsSlAmt, "0.00");
				((TextBoxBase)nCashPaid).ReadOnly = true;
			}
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
		((TextBoxBase)tVchNo).ReadOnly = true;
		LOpAmt.Text = ": Amt";
		((Control)LOpAmt).ForeColor = Color.Black;
		LClAmt.Text = ": Amt";
		((Control)LClAmt).ForeColor = Color.Black;
		OldValTot = 0.0;
		NewValTot = 0.0;
		OldCardComPrc = 0.0;
		OldBankComPrc = 0.0;
		AcGstType = "L";
		if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
		{
			tEmpCode.Text = DC_Main.MsUserEmpCode;
			tEmpName.Text = DC_Main.MsUserEmpName;
		}
		DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From CARD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		DC_Main.RsQry = "SELECT * FROM CARD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
		RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (RsData.Rows.Count > 0)
		{
			tVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_NO"], (object)""));
			CurPrnVch = tVchNo.Text;
			tHdVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HD_VCH_NO"], (object)""));
			mVchDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DATE"], (object)""));
			mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
			mTime.Text = Strings.Format((object)Conversions.ToDate(RsData.Rows[0]["VCH_TIME"]), "HH:mm:ss");
			tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_CODE"], (object)""));
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_NAME"], (object)""));
			OldAcCode = tAcCode.Text;
			tBillNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BILL_NO"], (object)""));
			tBillYrCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BILL_YRCD"], (object)""));
			tBillDbCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BILL_DBCD"], (object)""));
			nBillAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["BILL_AMT"]), "0.00");
			nBillAdjAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["BILL_ADJ_AMT"]), "0.00");
			nBillOs.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["BILL_OS_AMT"]), "0.00");
			nCardAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_AMT"]), "0.00");
			nCardCommPrc.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_COM_PRC"]), "0.00");
			nCardComAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_COM_AMT"]), "0.00");
			nCardNetAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_REC_AMT"]), "0.00");
			nCashPaid.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CASH_PAID"]), "0.00");
			tCardAc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_ACCD"], (object)""));
			DC_Main.RsQry = "SELECT * FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tCardAc.Text + "'";
			DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.RsAc.Rows.Count > 0)
			{
				tCardBankName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
			}
			DC_Main.RsAc.Clear();
			DC_Main.RsAc.Columns.Clear();
			nBankComPrc.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["BANK_COM_PRC"]), "0.00");
			nSchPrc.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["BANK_SCH_PRC"]), "0.00");
			nBankCom1.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["BANK_COMM_1"]), "0.00");
			nBankCom2.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["BANK_COMM_2"]), "0.00");
			nBankComAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["BANK_COM_AMT"]), "0.00");
			nBankNetAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["BANK_NET_AMT"]), "0.00");
			tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
			DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
			DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.RsAc.Rows.Count > 0)
			{
				tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["EMP_NAME"], (object)""));
			}
			tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["IT_DESC"], (object)""));
			MainUser = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MAIN_USER"], (object)""));
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
			OldValTot = Conversion.Val(nCardComAmt.Text) + Conversion.Val(nBankCom2.Text);
			NewValTot = Conversion.Val(nCardComAmt.Text) + Conversion.Val(nBankCom2.Text);
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

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void TR_CARD_REC_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_CARD_REC_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
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
		if ((DateTime.Compare(Conversions.ToDate(DC_Main.MCo_OpDate), Conversions.ToDate(mVchDate.Text)) > 0) | (DateTime.Compare(Conversions.ToDate(DC_Main.MCo_ClDate), Conversions.ToDate(mVchDate.Text)) < 0))
		{
			Interaction.MsgBox((object)"You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ014NPKJ", false) != 0 && DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
		{
			Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
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
			DC_Main.RsQry = "SELECT * FROM CARD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From CARD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		DC_Main.ExeQuteDc("DELETE FROM CARD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.ExeQuteDc("DELETE FROM DHRN_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		if (Conversion.Val(nCardAmt.Text) != 0.0)
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
			DC_Main.RsQry = "SELECT * FROM CARD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow2 = RsData.NewRow();
			dataRow2["CO_CODE"] = DC_Main.MCo_code;
			dataRow2["LC_CODE"] = DC_Main.MLc_code;
			dataRow2["CO_YEAR"] = DC_Main.MCo_year;
			dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
			dataRow2["VCH_NO"] = tVchNo.Text;
			dataRow2["VCH_DATE"] = mVchDate.Text;
			dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
			dataRow2["AC_CODE"] = tAcCode.Text;
			dataRow2["AC_NAME"] = tAcName.Text;
			dataRow2["VCH_TYPE"] = FormBookSname;
			dataRow2["INOUT_TYPE"] = FormBookInOut;
			dataRow2["ENTRY_TYPE"] = "I";
			dataRow2["BOOK_NAME"] = FormMainBook;
			dataRow2["BILL_NO"] = tBillNo.Text;
			dataRow2["BILL_LC_CODE"] = DC_Main.MLc_code;
			dataRow2["BILL_YRCD"] = tBillYrCd.Text;
			dataRow2["BILL_DBCD"] = tBillDbCd.Text;
			dataRow2["BILL_AMT"] = Conversion.Val(nBillAmt.Text);
			dataRow2["BILL_ADJ_AMT"] = Conversion.Val(nBillAdjAmt.Text);
			dataRow2["BILL_OS_AMT"] = Conversion.Val(nBillOs.Text);
			dataRow2["CARD_AMT"] = Conversion.Val(nCardAmt.Text);
			dataRow2["CARD_COM_PRC"] = Conversion.Val(nCardCommPrc.Text);
			dataRow2["CARD_COM_AMT"] = Conversion.Val(nCardComAmt.Text);
			dataRow2["CARD_REC_AMT"] = Conversion.Val(nCardNetAmt.Text);
			dataRow2["CASH_PAID"] = Conversion.Val(nCashPaid.Text);
			dataRow2["BANK_ACCD"] = tCardAc.Text;
			dataRow2["BANK_NAME"] = tCardBankName.Text;
			dataRow2["BANK_COM_PRC"] = Conversion.Val(nBankComPrc.Text);
			dataRow2["BANK_SCH_PRC"] = Conversion.Val(nSchPrc.Text);
			dataRow2["BANK_COMM_1"] = Conversion.Val(nBankCom1.Text);
			dataRow2["BANK_COMM_2"] = Conversion.Val(nBankCom2.Text);
			dataRow2["BANK_COM_AMT"] = Conversion.Val(nBankComAmt.Text);
			dataRow2["BANK_NET_AMT"] = Conversion.Val(nBankNetAmt.Text);
			dataRow2["EMP_CODE"] = tEmpCode.Text;
			dataRow2["IT_DESC"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(tVchDesc.Text, "Text Hear", false) == 0, (object)"", (object)tVchDesc.Text));
			dataRow2["MAIN_USER"] = MainUser;
			dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
			dataRow2["DATA_TRFR"] = "N";
			RsData.Rows.Add(dataRow2);
			((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
			RsData.Clear();
		}
		DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		Ac_Ledr.Card_Adj_Ledr(DC_Main.MCo_Book, tVchNo.Text);
		DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		Ac_Rojmel.Card_Adj_RojMel(DC_Main.MCo_Book, tVchNo.Text);
		if (DC_Main.MsCardSlAdj)
		{
			DC_Main.MsCardAdj = Conversion.Val(nCardNetAmt.Text);
			DC_Main.MsCardAdjComm = Conversion.Val(nCardComAmt.Text);
			DC_Main.MsCardBank = tCardAc.Text;
			DC_Main.MsCardBankName = tCardBankName.Text;
			CLEAR_DATA();
			((Form)this).Close();
			return;
		}
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
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Invalid comparison between Unknown and I4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
		if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
		{
			Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,1,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,AC_CODE,AC_NAME,0,CARD_AMT,'A',0,0,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "',SUBSTRING(IT_DESC,1,149) FROM CARD_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM CARD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_CARD_REC_KeyDown(object sender, KeyEventArgs e)
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
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
		}
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

	private void TR_CARD_REC_Activated(object sender, EventArgs e)
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
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL,A.MAIN_USER As UserL,A.CARD_AMT As CardAmtR,A.CARD_COM_AMT As CardComR FROM CARD_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[7];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 100.0;
		DC_Main.ColWidth[4] = 100.0;
		DC_Main.ColWidth[5] = 100.0;
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
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mVchDate;
			DC_Main.SetDate(ref MsDate);
			mVchDate = MsDate;
			if (!DC_Main.RongDate)
			{
				SendKeys.Send("{TAB}");
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
				DC_Main.RsQry = "SELECT VCH_NO FROM CARD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM CARD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void TR_CARD_REC_Closed(object sender, EventArgs e)
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
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
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
			if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				tAcCode.Text = DC_Main.ColValue[1];
				tAcName.Text = DC_Main.ColValue[0];
			}
			((Control)tAcCode).Focus();
			return;
		}
		if (Operators.CompareString(tAcCode.Text, OldAcCode, false) != 0)
		{
			OldAcCode = tAcCode.Text;
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			AcGstType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GST_TYPE"], (object)""));
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
		((Control)nCardAmt).Focus();
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
			DC_Main.RsQry = "SELECT IT_DESC As VchDescL FROM CARD_DATA WHERE IT_DESC <> '' AND LEN(IT_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND IT_DESC <> '' GROUP BY IT_DESC   ORDER BY IT_DESC";
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
		if (Conversion.Val(nCashPaid.Text) != 0.0)
		{
			if ((Conversion.Val(nCardAmt.Text) != 0.0) & (Conversion.Val(nCardCommPrc.Text) != OldCardComPrc))
			{
				nCardComAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nCardAmt.Text) * Conversion.Val(nCardCommPrc.Text) / 100.0), "0.00");
				nCardNetAmt.Text = Strings.Format((object)(Conversion.Val(nCardAmt.Text) + Conversion.Val(nCardComAmt.Text)), "0.00");
			}
			else
			{
				nCardNetAmt.Text = Strings.Format((object)(Conversion.Val(nCardAmt.Text) + Conversion.Val(nCardComAmt.Text)), "0.00");
			}
			if ((Conversion.Val(nCardNetAmt.Text) != 0.0) & (Conversion.Val(nBankComPrc.Text) != OldBankComPrc))
			{
				nBankCom1.Text = Strings.Format((object)Math.Round(Conversion.Val(nCardAmt.Text) * Conversion.Val(nBankComPrc.Text) / 100.0, 2), "0.00");
				if ((Conversion.Val(nBankCom1.Text) != 0.0) & (Conversion.Val(nSchPrc.Text) != 0.0))
				{
					nBankCom2.Text = Strings.Format((object)Math.Round(Conversion.Val(nBankCom1.Text) * Conversion.Val(nSchPrc.Text) / 100.0, 2), "0.00");
				}
				nBankComAmt.Text = Strings.Format((object)(Conversion.Val(nBankCom1.Text) + Conversion.Val(nBankCom2.Text)), "0.00");
				nBankNetAmt.Text = Strings.Format((object)(Conversion.Val(nCardNetAmt.Text) - Conversion.Val(nBankComAmt.Text)), "0.00");
			}
			else
			{
				nBankNetAmt.Text = Strings.Format((object)(Conversion.Val(nCardNetAmt.Text) - Conversion.Val(nBankComAmt.Text)), "0.00");
			}
		}
		else
		{
			if ((Conversion.Val(nCardAmt.Text) != 0.0) & (Conversion.Val(nCardCommPrc.Text) != OldCardComPrc))
			{
				nCardComAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nCardAmt.Text) * Conversion.Val(nCardCommPrc.Text) / 100.0), "0.00");
				nCardNetAmt.Text = Strings.Format((object)(Conversion.Val(nCardAmt.Text) + Conversion.Val(nCardComAmt.Text)), "0.00");
			}
			else
			{
				nCardNetAmt.Text = Strings.Format((object)(Conversion.Val(nCardAmt.Text) + Conversion.Val(nCardComAmt.Text)), "0.00");
			}
			if ((Conversion.Val(nCardNetAmt.Text) != 0.0) & (Conversion.Val(nBankComPrc.Text) != OldBankComPrc))
			{
				nBankCom1.Text = Strings.Format((object)Math.Round(Conversion.Val(nCardNetAmt.Text) * Conversion.Val(nBankComPrc.Text) / 100.0, 2), "0.00");
				if ((Conversion.Val(nBankCom1.Text) != 0.0) & (Conversion.Val(nSchPrc.Text) != 0.0))
				{
					nBankCom2.Text = Strings.Format((object)Math.Round(Conversion.Val(nBankCom1.Text) * Conversion.Val(nSchPrc.Text) / 100.0, 2), "0.00");
				}
				nBankComAmt.Text = Strings.Format((object)(Conversion.Val(nBankCom1.Text) + Conversion.Val(nBankCom2.Text)), "0.00");
				nBankNetAmt.Text = Strings.Format((object)(Conversion.Val(nCardNetAmt.Text) - Conversion.Val(nBankComAmt.Text)), "0.00");
			}
			else
			{
				nBankComAmt.Text = Strings.Format((object)(Conversion.Val(nBankCom1.Text) + Conversion.Val(nBankCom2.Text)), "0.00");
				nBankNetAmt.Text = Strings.Format((object)(Conversion.Val(nCardNetAmt.Text) - Conversion.Val(nBankComAmt.Text)), "0.00");
			}
		}
		if (CustOpAmt > 0.0)
		{
			CustClAmt = CustOpAmt + Conversion.Val(nBankCom2.Text) + Conversion.Val(nCashPaid.Text);
		}
		else if (CustOpAmt < 0.0)
		{
			CustClAmt = Conversion.Val(nBankCom2.Text) + Conversion.Val(nCashPaid.Text) - Math.Abs(CustOpAmt);
		}
		else
		{
			CustClAmt = Conversion.Val(nBankCom2.Text) + Conversion.Val(nCashPaid.Text);
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

	private void tAcName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void nBankComPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nBankComPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nBankComPrc.Text)), "0.00");
			BILL_TOTAL();
			if (Conversion.Val(nBankComPrc.Text) == 0.0)
			{
				((Control)nBankCom1).Focus();
				((TextBoxBase)nBankCom1).ReadOnly = false;
			}
			else
			{
				SendKeys.Send("{TAB}");
			}
		}
	}

	private void nCardCommPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nCardCommPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nCardCommPrc.Text)), "0.00");
			BILL_TOTAL();
			((Control)tCardAc).Focus();
		}
	}

	private void nSchPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nSchPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nSchPrc.Text)), "0.00");
			BILL_TOTAL();
			if (Conversion.Val(nBankComPrc.Text) == 0.0)
			{
				((Control)nBankCom2).Focus();
				((TextBoxBase)nBankCom2).ReadOnly = false;
			}
			else
			{
				((Control)tEmpCode).Focus();
			}
		}
	}

	private void nCardComAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nCardComAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nCardComAmt.Text)), "0.00");
			BILL_TOTAL();
			((Control)nBankCom1).Focus();
		}
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
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tCardAc.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR IN ('02','22','23','19','03') ORDER BY A.LC_CODE,A.AC_NAME";
			}
			else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND C.AC_GR IN ('02','22','23','19','03') AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.AC_GR IN ('02','22','23','19','03') AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME ";
			}
			else
			{
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_GR IN ('02','22','23','19','03') ORDER BY A.AC_NAME";
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
					tCardAc.Text = DC_Main.ColValue[1];
					tCardBankName.Text = DC_Main.ColValue[0];
				}
				((Control)tCardAc).Focus();
			}
		}
		else
		{
			tCardBankName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			SendKeys.Send("{TAB}");
		}
	}

	private void nBankCom1_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nBankCom1.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nBankCom1.Text)), "0.00");
			BILL_TOTAL();
			((Control)nSchPrc).Focus();
		}
	}

	private void nBankCom2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nBankCom2.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nBankCom2.Text)), "0.00");
			BILL_TOTAL();
			((Control)tEmpCode).Focus();
		}
	}

	private void nUnchakDhrnRec_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nCashPaid.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nCashPaid.Text)), "0.00");
			BILL_TOTAL();
			SendKeys.Send("{tab}");
		}
	}

	private void nCardAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nCardAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nCardAmt.Text)), "0.00");
			BILL_TOTAL();
			SendKeys.Send("{tab}");
		}
	}

	private void NBankComPrc_TextChanged(object sender, EventArgs e)
	{
	}
}
