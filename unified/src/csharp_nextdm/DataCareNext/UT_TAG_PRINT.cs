using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
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
using MSFlexGridLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using QRCoder;
using TagitSDK;

namespace DataCareNext;

[DesignerGenerated]
public class UT_TAG_PRINT : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblBook")]
	private Label _lblBook;

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
	[AccessedThroughProperty("BtnF1")]
	private SimpleButton _BtnF1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBookCode")]
	private TextBox _tBookCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTagSet")]
	private SimpleButton _btnTagSet;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPrCode")]
	private TextBox _tPrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tGrCode")]
	private TextBox _tGrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkHmIdUpdate")]
	private CheckBox _chkHmIdUpdate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnRfid")]
	private SimpleButton _btnRfid;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private bool HmidUpdate;

	private TagitDevices tagitObject;

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

	private DataTable RsIdtl;

	private int FilRow;

	private DataTable DtIdtl;

	private DataRow dr;

	private bool Msgleft;

	private bool UpDown;

	private bool MsTxtDelete;

	private int MsgOldRow;

	private bool MsgIdtlLeft;

	private const int cSrNo = 0;

	private const int cBox = 1;

	private const int cTagNo = 2;

	private const int cItCode = 3;

	private const int cCounter = 4;

	private const int cDesign = 5;

	private const int cSize = 6;

	private const int cBagWt = 7;

	private const int cPcs = 8;

	private const int cGrWt = 9;

	private const int cHmId = 10;

	private const int cHmWt = 11;

	private const int cHmId2 = 12;

	private const int cHmWt2 = 13;

	private const int cHmId3 = 14;

	private const int cHmWt3 = 15;

	private const int cHmId4 = 16;

	private const int cHmWt4 = 17;

	private const int cOthWt = 18;

	private const int cNetWt = 19;

	private const int cGhtPrc = 20;

	private const int cGhtWt = 21;

	private const int cTouch = 22;

	private const int cWestPrc = 23;

	private const int cFine = 24;

	private const int cLbrCode = 25;

	private const int cLbrType = 26;

	private const int cLbrRate = 27;

	private const int cLbrAmt = 28;

	private const int cOthAmt = 29;

	private const int cMrp = 30;

	private const int cKrName = 31;

	private const int cLbrPrc = 32;

	private const int cKrOthWt = 33;

	private const int cKrNetWt = 34;

	private const int cKrGhatPrc = 35;

	private const int cKrGhatWt = 36;

	private const int cKrTouch = 37;

	private const int cKrWestPrc = 38;

	private const int cKrFine = 39;

	private const int cKrLRate = 40;

	private const int cKrLAmt = 41;

	private const int cKrOthAmt = 42;

	private const int cPrCost = 43;

	private const int cVchSrno = 44;

	private const int cItRate = 45;

	private const int cItAmt = 46;

	private const int cTagCost = 47;

	private const int cMargin = 48;

	private const int cImageTake = 49;

	private const int cTagSrNo = 50;

	private const int cOldSrNo = 51;

	private const int cRateType = 52;

	private const int cItType = 53;

	private const int cTagType = 54;

	private const int cPrCode = 55;

	private const int cItName = 56;

	private const int cEntryMod = 57;

	private const int cOldTagType = 58;

	private const int cOldPrCode = 59;

	private const int cOldGrWt = 60;

	private const int cOldNtWt = 61;

	private const int cOldGhatPrc = 62;

	private const int cOldGhatWt = 63;

	private const int cOldTouch = 64;

	private const int cOldWestPrc = 65;

	private const int cOldKrNetWt = 66;

	private const int cOldKrTouch = 67;

	private const int cOldKrWest = 68;

	private const int cSlType = 69;

	private const int CStkDt = 70;

	private const int cItmStyle = 71;

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
			EventHandler eventHandler = TVchNo_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tVchNo_KeyDown);
			TextBox val2 = _tVchNo;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tVchNo = value;
			val2 = _tVchNo;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
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
			EventHandler eventHandler5 = MSG_Enter;
			AxMSFlexGrid val = _MSG;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
				val.RowColChange -= eventHandler4;
				((Control)val).Enter -= eventHandler5;
			}
			_MSG = value;
			val = _MSG;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
				val.RowColChange += eventHandler4;
				((Control)val).Enter += eventHandler5;
			}
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
	[AccessedThroughProperty("lblItem")]
	private virtual Label _lblItem;

	internal virtual Label lblItem
	{
		get
		{
			return _lblItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblItem = value;
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

	internal virtual TextBox tBookCode
	{
		[CompilerGenerated]
		get
		{
			return _tBookCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBookCode_KeyDown);
			TextBox val2 = _tBookCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBookCode = value;
			val2 = _tBookCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBookName")]
	private virtual TextBox _tBookName;

	internal virtual TextBox tBookName
	{
		get
		{
			return _tBookName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tBookName = value;
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

	internal virtual SimpleButton btnTagSet
	{
		[CompilerGenerated]
		get
		{
			return _btnTagSet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTagSet_Click;
			SimpleButton val = _btnTagSet;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTagSet = value;
			val = _btnTagSet;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboPrintfile")]
	private virtual ComboBox _cboPrintfile;

	internal virtual ComboBox cboPrintfile
	{
		get
		{
			return _cboPrintfile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboPrintfile = value;
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
	[AccessedThroughProperty("nLableSkip")]
	private virtual TextBox _nLableSkip;

	internal virtual TextBox nLableSkip
	{
		get
		{
			return _nLableSkip;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nLableSkip = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tGrName")]
	private virtual TextBox _tGrName;

	internal virtual TextBox tGrName
	{
		get
		{
			return _tGrName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tGrName = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPrName")]
	private virtual TextBox _tPrName;

	internal virtual TextBox tPrName
	{
		get
		{
			return _tPrName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tPrName = value;
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

	internal virtual TextBox tPrCode
	{
		[CompilerGenerated]
		get
		{
			return _tPrCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPrCode_KeyDown);
			TextBox val2 = _tPrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPrCode = value;
			val2 = _tPrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tGrCode
	{
		[CompilerGenerated]
		get
		{
			return _tGrCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tGrCode_KeyDown);
			TextBox val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tGrCode = value;
			val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboItemTyp")]
	private virtual ComboBox _cboItemTyp;

	internal virtual ComboBox cboItemTyp
	{
		get
		{
			return _cboItemTyp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboItemTyp = value;
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
	[AccessedThroughProperty("PictureBox1")]
	private virtual PictureBox _PictureBox1;

	internal virtual PictureBox PictureBox1
	{
		get
		{
			return _PictureBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PictureBox1 = value;
		}
	}

	internal virtual CheckBox chkHmIdUpdate
	{
		[CompilerGenerated]
		get
		{
			return _chkHmIdUpdate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkHmIdUpdate_CheckedChanged;
			CheckBox val = _chkHmIdUpdate;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkHmIdUpdate = value;
			val = _chkHmIdUpdate;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnRfid
	{
		[CompilerGenerated]
		get
		{
			return _btnRfid;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnRfid_Click;
			SimpleButton val = _btnRfid;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnRfid = value;
			val = _btnRfid;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboPrintType")]
	private virtual ComboBox _cboPrintType;

	internal virtual ComboBox cboPrintType
	{
		get
		{
			return _cboPrintType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboPrintType = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblPrintType")]
	private virtual Label _lblPrintType;

	internal virtual Label lblPrintType
	{
		get
		{
			return _lblPrintType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblPrintType = value;
		}
	}

	public UT_TAG_PRINT()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		((Form)this).Load += TR_TAG_CAN_Load;
		((Form)this).Deactivate += TR_TAG_CAN_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_TAG_CAN_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_TAG_CAN_KeyDown);
		((Form)this).Activated += TR_TAG_CAN_Activated;
		((Control)this).KeyUp += new KeyEventHandler(TR_TAG_CAN_KeyUp);
		((Form)this).Closed += TR_TAG_CAN_Closed;
		tagitObject = new TagitDevices();
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
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Expected O, but got Unknown
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Expected O, but got Unknown
		//IL_0546: Unknown result type (might be due to invalid IL or missing references)
		//IL_0550: Expected O, but got Unknown
		//IL_05b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bd: Expected O, but got Unknown
		//IL_0666: Unknown result type (might be due to invalid IL or missing references)
		//IL_0670: Expected O, but got Unknown
		//IL_078d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0797: Expected O, but got Unknown
		//IL_08a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ac: Expected O, but got Unknown
		//IL_090f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0919: Expected O, but got Unknown
		//IL_0aab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b04: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0e: Expected O, but got Unknown
		//IL_0c52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5c: Expected O, but got Unknown
		//IL_0cd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce3: Expected O, but got Unknown
		//IL_0dc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd2: Expected O, but got Unknown
		//IL_0eaa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb4: Expected O, but got Unknown
		//IL_0f50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5a: Expected O, but got Unknown
		//IL_1095: Unknown result type (might be due to invalid IL or missing references)
		//IL_109f: Expected O, but got Unknown
		//IL_10ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f4: Expected O, but got Unknown
		//IL_116e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1178: Expected O, but got Unknown
		//IL_11fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1206: Expected O, but got Unknown
		//IL_12cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d7: Expected O, but got Unknown
		//IL_139e: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a8: Expected O, but got Unknown
		//IL_147d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1487: Expected O, but got Unknown
		//IL_1523: Unknown result type (might be due to invalid IL or missing references)
		//IL_152d: Expected O, but got Unknown
		//IL_166f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1679: Expected O, but got Unknown
		//IL_16f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_16fd: Expected O, but got Unknown
		//IL_17ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b8: Expected O, but got Unknown
		//IL_186c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1876: Expected O, but got Unknown
		//IL_18f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_18fe: Expected O, but got Unknown
		//IL_1980: Unknown result type (might be due to invalid IL or missing references)
		//IL_198a: Expected O, but got Unknown
		//IL_19fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a05: Expected O, but got Unknown
		//IL_1aa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aac: Expected O, but got Unknown
		//IL_1b5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b64: Expected O, but got Unknown
		//IL_1be2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bec: Expected O, but got Unknown
		//IL_1c79: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c83: Expected O, but got Unknown
		//IL_1cf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cfa: Expected O, but got Unknown
		//IL_1e34: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e3e: Expected O, but got Unknown
		//IL_1e8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e99: Expected O, but got Unknown
		//IL_1f79: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f83: Expected O, but got Unknown
		//IL_2009: Unknown result type (might be due to invalid IL or missing references)
		//IL_2013: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UT_TAG_PRINT));
		lblBook = new Label();
		Label2 = new Label();
		tVchNo = new TextBox();
		BtnPrint = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnExit = new SimpleButton();
		PnlBotam = new FlowLayoutPanel();
		btnRfid = new SimpleButton();
		TEXT_ENTRY = new TextBox();
		lblItem = new Label();
		DlgOpen = new OpenFileDialog();
		BtnF1 = new SimpleButton();
		Cr = new AxCrystalReport();
		tBookCode = new TextBox();
		tBookName = new TextBox();
		Label1 = new Label();
		tHdVchNo = new TextBox();
		btnTagSet = new SimpleButton();
		cboPrintfile = new ComboBox();
		Label6 = new Label();
		Label3 = new Label();
		nLableSkip = new TextBox();
		tGrName = new TextBox();
		tPrName = new TextBox();
		Label4 = new Label();
		Label5 = new Label();
		tPrCode = new TextBox();
		tGrCode = new TextBox();
		cboItemTyp = new ComboBox();
		Label7 = new Label();
		PictureBox1 = new PictureBox();
		MSG = new AxMSFlexGrid();
		chkHmIdUpdate = new CheckBox();
		cboPrintType = new ComboBox();
		lblPrintType = new Label();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)PictureBox1).BeginInit();
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
		lblBook.Text = "Tag Print";
		lblBook.TextAlign = (ContentAlignment)32;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(28, 78);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(68, 18);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchNo).Location = new Point(102, 78);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((Control)tVchNo).Size = new Size(76, 23);
		((Control)tVchNo).TabIndex = 1;
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
		((Control)PnlBotam).Controls.Add((Control)(object)btnRfid);
		((Control)PnlBotam).Controls.Add((Control)(object)cboPrintType);
		((Control)PnlBotam).Controls.Add((Control)(object)lblPrintType);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 4;
		((BaseStyleControl)btnRfid).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnRfid).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnRfid).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnRfid).Appearance.Options.UseForeColor = true;
		btnRfid.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)btnRfid.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		((Control)btnRfid).Location = new Point(730, 3);
		((BaseControl)btnRfid).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnRfid).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnRfid).Name = "btnRfid";
		((Control)btnRfid).Size = new Size(91, 37);
		((Control)btnRfid).TabIndex = 32;
		btnRfid.Text = "&Rfid";
		((BaseButton)btnRfid).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)btnRfid).Visible = false;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(525, 210);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 2;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)lblItem).Font = new Font("Franklin Gothic Book", 9.75f);
		((Control)lblItem).ForeColor = Color.Black;
		lblItem.ImeMode = (ImeMode)0;
		((Control)lblItem).Location = new Point(12, 538);
		((Control)lblItem).Name = "lblItem";
		((Control)lblItem).Size = new Size(221, 20);
		((Control)lblItem).TabIndex = 1139;
		lblItem.Text = "Item Name";
		lblItem.TextAlign = (ContentAlignment)16;
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
		((Control)BtnF1).Location = new Point(184, 78);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(35, 23);
		((Control)BtnF1).TabIndex = 1149;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Voucher Help";
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1181, 147);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 1155;
		((TextBoxBase)tBookCode).BackColor = Color.White;
		((Control)tBookCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookCode).Location = new Point(102, 44);
		((TextBoxBase)tBookCode).MaxLength = 8;
		((Control)tBookCode).Name = "tBookCode";
		((Control)tBookCode).Size = new Size(76, 23);
		((Control)tBookCode).TabIndex = 0;
		((TextBoxBase)tBookName).BackColor = Color.White;
		((Control)tBookName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookName).Location = new Point(184, 44);
		((TextBoxBase)tBookName).MaxLength = 8;
		((Control)tBookName).Name = "tBookName";
		((Control)tBookName).Size = new Size(224, 23);
		((Control)tBookName).TabIndex = 1158;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(36, 44);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(60, 20);
		((Control)Label1).TabIndex = 1157;
		Label1.Text = "Book";
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
		((BaseStyleControl)btnTagSet).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnTagSet).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnTagSet).Appearance.Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnTagSet).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnTagSet).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnTagSet).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnTagSet).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnTagSet).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnTagSet).Appearance.Options.UseForeColor = true;
		((BaseButton)btnTagSet).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnTagSet).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnTagSet).AppearanceHovered.Font = new Font("Arial", 9f);
		((BaseButton)btnTagSet).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnTagSet).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnTagSet).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnTagSet).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnTagSet).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnTagSet).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnTagSet).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnTagSet).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnTagSet).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnTagSet).AppearancePressed.Options.UseFont = true;
		((Control)btnTagSet).Location = new Point(1126, 78);
		((BaseControl)btnTagSet).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnTagSet).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnTagSet).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTagSet).Name = "btnTagSet";
		((Control)btnTagSet).Size = new Size(44, 24);
		((Control)btnTagSet).TabIndex = 1162;
		btnTagSet.Text = "Set";
		((BaseControl)btnTagSet).ToolTip = "Party Help";
		cboPrintfile.AutoCompleteMode = (AutoCompleteMode)2;
		cboPrintfile.AutoCompleteSource = (AutoCompleteSource)256;
		cboPrintfile.BackColor = Color.FromArgb(250, 220, 230);
		((Control)cboPrintfile).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboPrintfile).FormattingEnabled = true;
		((Control)cboPrintfile).Location = new Point(1007, 79);
		cboPrintfile.MaxLength = 5;
		((Control)cboPrintfile).Name = "cboPrintfile";
		((Control)cboPrintfile).Size = new Size(113, 24);
		((Control)cboPrintfile).TabIndex = 1160;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(895, 80);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(106, 20);
		((Control)Label6).TabIndex = 1161;
		Label6.Text = "Print file Name";
		Label6.TextAlign = (ContentAlignment)16;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(1042, 538);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(80, 20);
		((Control)Label3).TabIndex = 1164;
		Label3.Text = "Lable Skip";
		Label3.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nLableSkip).BackColor = Color.White;
		((Control)nLableSkip).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nLableSkip).Location = new Point(1131, 537);
		((TextBoxBase)nLableSkip).MaxLength = 15;
		((Control)nLableSkip).Name = "nLableSkip";
		((Control)nLableSkip).Size = new Size(39, 22);
		((Control)nLableSkip).TabIndex = 3;
		((TextBoxBase)tGrName).BackColor = Color.PapayaWhip;
		((Control)tGrName).Font = new Font("Tahoma", 9f);
		((Control)tGrName).Location = new Point(552, 42);
		((TextBoxBase)tGrName).MaxLength = 50;
		((Control)tGrName).Name = "tGrName";
		((Control)tGrName).Size = new Size(240, 22);
		((Control)tGrName).TabIndex = 1170;
		((TextBoxBase)tPrName).BackColor = Color.PapayaWhip;
		((Control)tPrName).Font = new Font("Tahoma", 9f);
		((Control)tPrName).Location = new Point(552, 77);
		((TextBoxBase)tPrName).MaxLength = 50;
		((Control)tPrName).Name = "tPrName";
		((Control)tPrName).Size = new Size(240, 22);
		((Control)tPrName).TabIndex = 1169;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(413, 44);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(66, 20);
		((Control)Label4).TabIndex = 1168;
		Label4.Text = "Gr Code";
		Label4.TextAlign = (ContentAlignment)64;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(413, 79);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(66, 20);
		((Control)Label5).TabIndex = 1167;
		Label5.Text = "Pr Code";
		Label5.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tPrCode).BackColor = Color.White;
		((Control)tPrCode).Font = new Font("Tahoma", 9f);
		((Control)tPrCode).Location = new Point(483, 77);
		((TextBoxBase)tPrCode).MaxLength = 2;
		((Control)tPrCode).Name = "tPrCode";
		((Control)tPrCode).Size = new Size(66, 22);
		((Control)tPrCode).TabIndex = 1165;
		((TextBoxBase)tGrCode).BackColor = Color.White;
		((Control)tGrCode).Font = new Font("Tahoma", 9f);
		((Control)tGrCode).Location = new Point(483, 42);
		((TextBoxBase)tGrCode).MaxLength = 3;
		((Control)tGrCode).Name = "tGrCode";
		((Control)tGrCode).Size = new Size(66, 22);
		((Control)tGrCode).TabIndex = 1166;
		cboItemTyp.BackColor = Color.FromArgb(250, 220, 230);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(309, 77);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(99, 22);
		((Control)cboItemTyp).TabIndex = 1171;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(228, 77);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(73, 20);
		((Control)Label7).TabIndex = 1172;
		Label7.Text = "Item Type";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)PictureBox1).Location = new Point(812, 48);
		((Control)PictureBox1).Name = "PictureBox1";
		((Control)PictureBox1).Size = new Size(56, 48);
		PictureBox1.SizeMode = (PictureBoxSizeMode)3;
		PictureBox1.TabIndex = 1174;
		PictureBox1.TabStop = false;
		((Control)PictureBox1).Visible = false;
		((Control)MSG).Location = new Point(12, 110);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1158, 421);
		((Control)MSG).TabIndex = 1135;
		((ButtonBase)chkHmIdUpdate).BackColor = Color.Transparent;
		((Control)chkHmIdUpdate).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkHmIdUpdate).ForeColor = Color.Black;
		((Control)chkHmIdUpdate).Location = new Point(899, 48);
		((Control)chkHmIdUpdate).Name = "chkHmIdUpdate";
		((Control)chkHmIdUpdate).RightToLeft = (RightToLeft)0;
		((Control)chkHmIdUpdate).Size = new Size(135, 19);
		((Control)chkHmIdUpdate).TabIndex = 1175;
		((ButtonBase)chkHmIdUpdate).Text = "Hm Id Update";
		((ButtonBase)chkHmIdUpdate).UseVisualStyleBackColor = false;
		cboPrintType.AutoCompleteMode = (AutoCompleteMode)2;
		cboPrintType.AutoCompleteSource = (AutoCompleteSource)256;
		cboPrintType.BackColor = Color.FromArgb(250, 220, 230);
		((Control)cboPrintType).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboPrintType).FormattingEnabled = true;
		((Control)cboPrintType).Location = new Point(624, 3);
		cboPrintType.MaxLength = 5;
		((Control)cboPrintType).Name = "cboPrintType";
		((Control)cboPrintType).Size = new Size(100, 24);
		((Control)cboPrintType).TabIndex = 1244;
		((Control)cboPrintType).Visible = false;
		((Control)lblPrintType).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblPrintType).ForeColor = Color.Black;
		lblPrintType.ImageAlign = (ContentAlignment)64;
		lblPrintType.ImeMode = (ImeMode)0;
		((Control)lblPrintType).Location = new Point(520, 0);
		((Control)lblPrintType).Name = "lblPrintType";
		((Control)lblPrintType).Size = new Size(98, 30);
		((Control)lblPrintType).TabIndex = 1245;
		lblPrintType.Text = "Print Type";
		lblPrintType.TextAlign = (ContentAlignment)64;
		((Control)lblPrintType).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)chkHmIdUpdate);
		((Control)this).Controls.Add((Control)(object)PictureBox1);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)tGrName);
		((Control)this).Controls.Add((Control)(object)tPrName);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tPrCode);
		((Control)this).Controls.Add((Control)(object)tGrCode);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)nLableSkip);
		((Control)this).Controls.Add((Control)(object)btnTagSet);
		((Control)this).Controls.Add((Control)(object)cboPrintfile);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)tHdVchNo);
		((Control)this).Controls.Add((Control)(object)tBookCode);
		((Control)this).Controls.Add((Control)(object)tBookName);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)BtnF1);
		((Control)this).Controls.Add((Control)(object)lblItem);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tVchNo);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "UT_TAG_PRINT";
		((Form)this).Text = "Tag Print";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)PictureBox1).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 72;
		mSG.Rows = 2;
		mSG.Row = 0;
		mSG[0] = 0;
		mSG[1] = 0;
		mSG.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG[0] = (int)Math.Round(500.0 * ColCon);
			mSG[0] = 3;
			mSG[0, 0] = "Sr";
			mSG[1] = (int)Math.Round(1000.0 * ColCon);
			mSG[1] = 3;
			mSG[0, 1] = "Y/N";
			mSG[3] = (int)Math.Round(1000.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "ItCode";
			mSG[2] = (int)Math.Round(1200.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "TagNo";
			mSG[4] = (int)Math.Round(900.0 * ColCon);
			mSG[4] = 0;
			mSG[0, 4] = "Counter";
			mSG[5] = (int)Math.Round(1300.0 * ColCon);
			mSG[5] = 0;
			mSG[0, 5] = "Design";
			mSG[6] = (int)Math.Round(800.0 * ColCon);
			mSG[6] = 0;
			mSG[0, 6] = "Size";
			mSG[7] = (int)Math.Round(0.0 * ColCon);
			mSG[7] = 7;
			mSG[0, 7] = "BagWt";
			mSG[8] = (int)Math.Round(700.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "Pcs";
			mSG[9] = (int)Math.Round(1000.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "GrWt";
			mSG[25] = (int)Math.Round(800.0 * ColCon);
			mSG[25] = 0;
			mSG[0, 25] = "LCode";
			if (chkHmIdUpdate.Checked)
			{
				HmidUpdate = false;
				mSG[10] = (int)Math.Round(1000.0 * ColCon);
				mSG[10] = 3;
				mSG[0, 10] = "HmId";
				mSG[12] = (int)Math.Round(1000.0 * ColCon);
				mSG[12] = 3;
				mSG[0, 12] = "HmId2";
				mSG[14] = (int)Math.Round(1000.0 * ColCon);
				mSG[14] = 3;
				mSG[0, 14] = "HmId3";
				mSG[16] = (int)Math.Round(1000.0 * ColCon);
				mSG[16] = 3;
				mSG[0, 16] = "HmId4";
				mSG[11] = (int)Math.Round(950.0 * ColCon);
				mSG[11] = 7;
				mSG[0, 11] = "HmWt";
				mSG[13] = (int)Math.Round(950.0 * ColCon);
				mSG[13] = 7;
				mSG[0, 13] = "HmWt2";
				mSG[15] = (int)Math.Round(950.0 * ColCon);
				mSG[15] = 7;
				mSG[0, 15] = "HmWt3";
				mSG[17] = (int)Math.Round(950.0 * ColCon);
				mSG[17] = 7;
				mSG[0, 17] = "HmWt4";
				mSG[32] = (int)Math.Round(950.0 * ColCon);
				mSG[32] = 7;
				mSG[0, 32] = "Lbr%";
				mSG[27] = (int)Math.Round(950.0 * ColCon);
				mSG[27] = 7;
				mSG[0, 27] = "LRate";
				mSG[30] = (int)Math.Round(1100.0 * ColCon);
				mSG[30] = 7;
				mSG[0, 30] = "Mrp";
				mSG[25] = 0;
				mSG[19] = 0;
				mSG[21] = 0;
				mSG[22] = 0;
				mSG[23] = 0;
				mSG[24] = 0;
				mSG[28] = 0;
				mSG[29] = 0;
				mSG[31] = (int)Math.Round(900.0 * ColCon);
				mSG[31] = 7;
				mSG[0, 31] = "KrCode";
			}
			else
			{
				mSG[10] = 0;
				mSG[12] = 0;
				mSG[14] = 0;
				mSG[16] = 0;
				mSG[11] = 0;
				mSG[13] = 0;
				mSG[15] = 0;
				mSG[17] = 0;
				mSG[32] = (int)Math.Round(0.0 * ColCon);
				mSG[32] = 7;
				mSG[0, 32] = "Lbr%";
				mSG[19] = (int)Math.Round(1000.0 * ColCon);
				mSG[19] = 7;
				mSG[0, 19] = "NetWt";
				mSG[21] = (int)Math.Round(850.0 * ColCon);
				mSG[21] = 7;
				mSG[0, 21] = "GhtWt";
				mSG[22] = (int)Math.Round(850.0 * ColCon);
				mSG[22] = 7;
				mSG[0, 22] = "Touch";
				mSG[23] = (int)Math.Round(850.0 * ColCon);
				mSG[23] = 7;
				mSG[0, 23] = "West%";
				mSG[24] = (int)Math.Round(1000.0 * ColCon);
				mSG[24] = 7;
				mSG[0, 24] = "Fine";
				mSG[27] = (int)Math.Round(900.0 * ColCon);
				mSG[27] = 7;
				mSG[0, 27] = "LbrRate";
				mSG[28] = (int)Math.Round(950.0 * ColCon);
				mSG[28] = 7;
				mSG[0, 28] = "LbrAmt";
				mSG[29] = (int)Math.Round(1000.0 * ColCon);
				mSG[29] = 7;
				mSG[0, 29] = "OthAmt";
				mSG[30] = (int)Math.Round(900.0 * ColCon);
				mSG[30] = 7;
				mSG[0, 30] = "Mrp";
				mSG[31] = (int)Math.Round(900.0 * ColCon);
				mSG[31] = 7;
				mSG[0, 31] = "KrCode";
			}
			mSG[18] = (int)Math.Round(0.0 * ColCon);
			mSG[18] = 7;
			mSG[0, 18] = "LsWt";
			mSG[33] = (int)Math.Round(0.0 * ColCon);
			mSG[33] = 7;
			mSG[0, 33] = "KrOthWt";
			mSG[34] = (int)Math.Round(0.0 * ColCon);
			mSG[34] = 7;
			mSG[0, 34] = "KrNwt";
			mSG[35] = (int)Math.Round(0.0 * ColCon);
			mSG[35] = 7;
			mSG[0, 35] = "KrGht%";
			mSG[36] = (int)Math.Round(0.0 * ColCon);
			mSG[36] = 7;
			mSG[0, 36] = "KrGht";
			mSG[37] = (int)Math.Round(0.0 * ColCon);
			mSG[37] = 7;
			mSG[0, 37] = "KrTouch";
			mSG[38] = (int)Math.Round(0.0 * ColCon);
			mSG[38] = 7;
			mSG[0, 38] = "KrWst%";
			mSG[39] = (int)Math.Round(0.0 * ColCon);
			mSG[39] = 7;
			mSG[0, 39] = "KrFine";
			mSG[20] = (int)Math.Round(0.0 * ColCon);
			mSG[20] = 7;
			mSG[0, 20] = "Ght%";
			mSG[26] = (int)Math.Round(0.0 * ColCon);
			mSG[26] = 3;
			mSG[0, 26] = "LType";
			mSG[40] = (int)Math.Round(0.0 * ColCon);
			mSG[40] = 7;
			mSG[0, 40] = "KrLRate";
			mSG[41] = (int)Math.Round(0.0 * ColCon);
			mSG[41] = 7;
			mSG[0, 41] = "KrLAmt";
			mSG[42] = (int)Math.Round(0.0 * ColCon);
			mSG[42] = 7;
			mSG[0, 42] = "KrOthAmt";
			mSG[43] = (int)Math.Round(0.0 * ColCon);
			mSG[43] = 7;
			mSG[0, 43] = "PrCost";
			mSG[45] = (int)Math.Round(0.0 * ColCon);
			mSG[45] = 7;
			mSG[0, 45] = "ItRate";
			mSG[46] = (int)Math.Round(0.0 * ColCon);
			mSG[46] = 7;
			mSG[0, 46] = "ItAmt";
			mSG[47] = (int)Math.Round(0.0 * ColCon);
			mSG[47] = 7;
			mSG[0, 47] = "TagCost";
			mSG[48] = (int)Math.Round(0.0 * ColCon);
			mSG[48] = 7;
			mSG[0, 48] = "Margin";
			mSG[49] = (int)Math.Round(0.0 * ColCon);
			mSG[49] = 3;
			mSG[0, 49] = "Image";
			mSG[50] = 0;
			mSG[51] = 0;
			mSG[52] = 0;
			mSG[53] = 0;
			mSG[54] = 0;
			mSG[55] = 0;
			mSG[44] = 0;
			mSG[56] = 0;
			mSG[57] = 0;
			mSG[58] = 0;
			mSG[59] = 0;
			mSG[60] = 0;
			mSG[61] = 0;
			mSG[62] = 0;
			mSG[63] = 0;
			mSG[64] = 0;
			mSG[65] = 0;
			mSG[66] = 0;
			mSG[67] = 0;
			mSG[68] = 0;
			mSG[69] = 0;
			mSG[70] = 0;
			mSG[71] = 0;
			mSG.Row = 1;
			mSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			DataView dataView = new DataView(DC_Main.RsClDetl);
			if (dataView.Count > 0)
			{
				int num = mSG.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					dataView.RowFilter = " BOOK_NAME = 'TAG_DETL' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
					if (dataView.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(dataView[0]["YES_NO"], (object)"N", false))
						{
							mSG[DC_Main.M] = 0;
						}
						mSG[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);
					}
					DC_Main.M++;
				}
			}
			MsgLastCol = 31;
			DC_Main.M = 32;
			do
			{
				if (mSG[DC_Main.M] > 0)
				{
					mSG[43] = (int)Math.Round(1100.0 * ColCon);
					MsgLastCol = 43;
					break;
				}
				DC_Main.M++;
			}
			while (DC_Main.M <= 43);
			mSG[0] = (int)Math.Round(325.0 * ColCon);
			mSG[1] = (int)Math.Round(300.0 * ColCon);
			mSG.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd();
			mSG = null;
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG[mSG.Row, 8] = Conversions.ToString(1);
		mSG[mSG.Row, 1] = "Y";
		mSG[mSG.Row, 26] = DC_Main.MsLbrType;
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			mSG[mSG.Row, 51] = Conversions.ToString(MSG.Row);
		}
		else
		{
			mSG[mSG.Row, 51] = Conversions.ToString(Conversion.Val(mSG[checked(mSG.Rows - 2), 51]) + 1.0);
		}
		mSG[mSG.Row, 57] = "A";
		mSG[mSG.Row, 49] = "N";
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
				case 3:
				case 31:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 4:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 10:
				case 12:
				case 14:
				case 16:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 5:
				case 6:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 1:
				case 26:
				case 49:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 8:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
					break;
				case 20:
				case 22:
				case 23:
				case 32:
				case 37:
				case 38:
				case 48:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				case 27:
				case 28:
				case 29:
				case 30:
				case 40:
				case 41:
				case 42:
				case 43:
				case 45:
				case 46:
				case 47:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				case 7:
				case 9:
				case 11:
				case 13:
				case 15:
				case 17:
				case 18:
				case 19:
				case 21:
				case 24:
				case 33:
				case 34:
				case 35:
				case 36:
				case 39:
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
			case 3:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 0:
			case 1:
			case 2:
			case 4:
			case 5:
			case 6:
			case 10:
			case 12:
			case 14:
			case 16:
			case 26:
			case 31:
			case 49:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 8:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
				break;
			case 20:
			case 22:
			case 23:
			case 32:
			case 37:
			case 38:
			case 48:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 27:
			case 28:
			case 29:
			case 30:
			case 40:
			case 41:
			case 42:
			case 43:
			case 45:
			case 46:
			case 47:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 18:
			case 33:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				CommPassTotal();
				break;
			case 7:
			case 9:
			case 11:
			case 13:
			case 15:
			case 17:
			case 19:
			case 21:
			case 24:
			case 34:
			case 35:
			case 36:
			case 39:
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
				case 4363:
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
							goto IL_004b;
						case 5:
							goto IL_007e;
						case 6:
							goto IL_00c5;
						case 7:
						case 8:
							goto IL_010e;
						case 9:
							goto IL_0159;
						case 10:
						case 11:
							goto IL_01a3;
						case 12:
							goto IL_01da;
						case 13:
							goto IL_020e;
						case 14:
							goto IL_026e;
						case 16:
							goto IL_02ec;
						case 15:
						case 17:
						case 18:
						case 19:
							goto IL_0323;
						case 20:
							goto IL_035a;
						case 21:
							goto IL_038e;
						case 22:
							goto IL_03ee;
						case 23:
						case 24:
						case 25:
							goto IL_046c;
						case 26:
							goto IL_04a3;
						case 27:
							goto IL_04d7;
						case 28:
							goto IL_0537;
						case 29:
						case 30:
						case 31:
							goto IL_05b5;
						case 32:
							goto IL_05f0;
						case 33:
						case 34:
							goto IL_063a;
						case 35:
							goto IL_0686;
						case 36:
						case 37:
							goto IL_06d0;
						case 38:
							goto IL_0707;
						case 39:
							goto IL_073b;
						case 40:
							goto IL_079b;
						case 42:
							goto IL_0819;
						case 41:
						case 43:
						case 44:
						case 45:
							goto IL_0850;
						case 46:
							goto IL_0887;
						case 47:
							goto IL_08bb;
						case 48:
							goto IL_091b;
						case 49:
						case 50:
						case 51:
							goto IL_0999;
						case 52:
							goto IL_09d0;
						case 53:
							goto IL_0a04;
						case 54:
							goto IL_0a64;
						case 55:
						case 56:
						case 57:
							goto IL_0ae2;
						case 58:
							goto IL_0b1d;
						case 59:
						case 60:
							goto IL_0b67;
						case 61:
							goto IL_0bb7;
						case 63:
							goto IL_0c00;
						case 65:
							goto IL_0c53;
						case 67:
							goto IL_0cb1;
						case 69:
							goto IL_0d0c;
						case 62:
						case 64:
						case 66:
						case 68:
						case 70:
						case 71:
						case 72:
							goto IL_0d5f;
						case 73:
							goto IL_0d8d;
						case 75:
							goto IL_0dd6;
						case 77:
							goto IL_0e29;
						case 79:
							goto IL_0e91;
						case 81:
							goto IL_0f00;
						case 74:
						case 76:
						case 78:
						case 80:
						case 82:
						case 83:
						case 84:
							goto IL_0f53;
						case 85:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 86:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_0e29:
					num2 = 77;
					val[val.Row, 28] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 19]) + Conversion.Val(val[val.Row, 21])) * Conversion.Val(val[val.Row, 27]), 0), "0.00");
					goto IL_0f53;
					IL_0dd6:
					num2 = 75;
					val[val.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 8]) * Conversion.Val(val[val.Row, 27]), 0), "0.00");
					goto IL_0f53;
					IL_0e91:
					num2 = 79;
					val[val.Row, 28] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 19]) + Conversion.Val(val[val.Row, 21])) * (Conversion.Val(val[val.Row, 27]) / 1000.0), 0), "0.00");
					goto IL_0f53;
					IL_0f53:
					num2 = 84;
					val[val.Row, 43] = Strings.Format((object)(Conversion.Val(val[val.Row, 41]) + Conversion.Val(val[val.Row, 42])), "0.0");
					break;
					IL_000c:
					num2 = 2;
					val = MSG;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					if (Conversion.Val(val[val.Row, 9]) != Conversion.Val(val[val.Row, 60]))
					{
						goto IL_004b;
					}
					goto IL_010e;
					IL_004b:
					num2 = 4;
					val[val.Row, 60] = Strings.Format((object)Conversion.Val(val[val.Row, 9]), "0.000");
					goto IL_007e;
					IL_007e:
					num2 = 5;
					val[val.Row, 19] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) - Conversion.Val(val[val.Row, 18])), "0.000");
					goto IL_00c5;
					IL_00c5:
					num2 = 6;
					val[val.Row, 34] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) - Conversion.Val(val[val.Row, 33])), "0.000");
					goto IL_010e;
					IL_010e:
					num2 = 8;
					if ((Conversion.Val(val[val.Row, 18]) != 0.0) & (Conversion.Val(val[val.Row, 9]) != 0.0))
					{
						goto IL_0159;
					}
					goto IL_01a3;
					IL_0159:
					num2 = 9;
					val[val.Row, 19] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) - Conversion.Val(val[val.Row, 18])), "0.000");
					goto IL_01a3;
					IL_01a3:
					num2 = 11;
					if (Conversion.Val(val[val.Row, 19]) != Conversion.Val(val[val.Row, 61]))
					{
						goto IL_01da;
					}
					goto IL_0323;
					IL_01da:
					num2 = 12;
					val[val.Row, 61] = Strings.Format((object)Conversion.Val(val[val.Row, 19]), "0.000");
					goto IL_020e;
					IL_020e:
					num2 = 13;
					if ((Conversion.Val(val[val.Row, 22]) + Conversion.Val(val[val.Row, 23]) != 0.0) & (Conversion.Val(val[val.Row, 19]) != 0.0))
					{
						goto IL_026e;
					}
					goto IL_02ec;
					IL_026e:
					num2 = 14;
					val[val.Row, 24] = Strings.Format((object)((Conversion.Val(val[val.Row, 19]) + Conversion.Val(val[val.Row, 21])) * (Conversion.Val(val[val.Row, 22]) + Conversion.Val(val[val.Row, 23])) / 100.0), "0.000");
					goto IL_0323;
					IL_02ec:
					num2 = 16;
					val[val.Row, 24] = Strings.Format((object)Conversion.Val(val[val.Row, 19]), "0.000");
					goto IL_0323;
					IL_0323:
					num2 = 19;
					if (Conversion.Val(val[val.Row, 22]) != Conversion.Val(val[val.Row, 64]))
					{
						goto IL_035a;
					}
					goto IL_046c;
					IL_035a:
					num2 = 20;
					val[val.Row, 64] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_038e;
					IL_038e:
					num2 = 21;
					if ((Conversion.Val(val[val.Row, 22]) + Conversion.Val(val[val.Row, 23]) != 0.0) & (Conversion.Val(val[val.Row, 19]) != 0.0))
					{
						goto IL_03ee;
					}
					goto IL_046c;
					IL_03ee:
					num2 = 22;
					val[val.Row, 24] = Strings.Format((object)((Conversion.Val(val[val.Row, 19]) + Conversion.Val(val[val.Row, 21])) * (Conversion.Val(val[val.Row, 22]) + Conversion.Val(val[val.Row, 23])) / 100.0), "0.000");
					goto IL_046c;
					IL_046c:
					num2 = 25;
					if (Conversion.Val(val[val.Row, 23]) != Conversion.Val(val[val.Row, 65]))
					{
						goto IL_04a3;
					}
					goto IL_05b5;
					IL_04a3:
					num2 = 26;
					val[val.Row, 65] = Strings.Format((object)Conversion.Val(val[val.Row, 23]), "0.00");
					goto IL_04d7;
					IL_04d7:
					num2 = 27;
					if ((Conversion.Val(val[val.Row, 22]) + Conversion.Val(val[val.Row, 23]) != 0.0) & (Conversion.Val(val[val.Row, 19]) != 0.0))
					{
						goto IL_0537;
					}
					goto IL_05b5;
					IL_0537:
					num2 = 28;
					val[val.Row, 24] = Strings.Format((object)((Conversion.Val(val[val.Row, 19]) + Conversion.Val(val[val.Row, 21])) * (Conversion.Val(val[val.Row, 22]) + Conversion.Val(val[val.Row, 23])) / 100.0), "0.000");
					goto IL_05b5;
					IL_05b5:
					num2 = 31;
					if (Conversion.Val(val[val.Row, 22]) + Conversion.Val(val[val.Row, 23]) == 0.0)
					{
						goto IL_05f0;
					}
					goto IL_063a;
					IL_05f0:
					num2 = 32;
					val[val.Row, 24] = Strings.Format((object)(Conversion.Val(val[val.Row, 19]) + Conversion.Val(val[val.Row, 21])), "0.000");
					goto IL_063a;
					IL_063a:
					num2 = 34;
					if ((Conversion.Val(val[val.Row, 33]) != 0.0) & (Conversion.Val(val[val.Row, 9]) != 0.0))
					{
						goto IL_0686;
					}
					goto IL_06d0;
					IL_0686:
					num2 = 35;
					val[val.Row, 34] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) - Conversion.Val(val[val.Row, 33])), "0.000");
					goto IL_06d0;
					IL_06d0:
					num2 = 37;
					if (Conversion.Val(val[val.Row, 34]) != Conversion.Val(val[val.Row, 66]))
					{
						goto IL_0707;
					}
					goto IL_0850;
					IL_0707:
					num2 = 38;
					val[val.Row, 66] = Strings.Format((object)Conversion.Val(val[val.Row, 34]), "0.000");
					goto IL_073b;
					IL_073b:
					num2 = 39;
					if ((Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 38]) != 0.0) & (Conversion.Val(val[val.Row, 34]) != 0.0))
					{
						goto IL_079b;
					}
					goto IL_0819;
					IL_079b:
					num2 = 40;
					val[val.Row, 39] = Strings.Format((object)((Conversion.Val(val[val.Row, 34]) + Conversion.Val(val[val.Row, 36])) * (Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 38])) / 100.0), "0.000");
					goto IL_0850;
					IL_0819:
					num2 = 42;
					val[val.Row, 39] = Strings.Format((object)Conversion.Val(val[val.Row, 34]), "0.000");
					goto IL_0850;
					IL_0850:
					num2 = 45;
					if (Conversion.Val(val[val.Row, 37]) != Conversion.Val(val[val.Row, 67]))
					{
						goto IL_0887;
					}
					goto IL_0999;
					IL_0887:
					num2 = 46;
					val[val.Row, 67] = Strings.Format((object)Conversion.Val(val[val.Row, 37]), "0.00");
					goto IL_08bb;
					IL_08bb:
					num2 = 47;
					if ((Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 38]) != 0.0) & (Conversion.Val(val[val.Row, 34]) != 0.0))
					{
						goto IL_091b;
					}
					goto IL_0999;
					IL_091b:
					num2 = 48;
					val[val.Row, 39] = Strings.Format((object)((Conversion.Val(val[val.Row, 34]) + Conversion.Val(val[val.Row, 36])) * (Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 38])) / 100.0), "0.000");
					goto IL_0999;
					IL_0999:
					num2 = 51;
					if (Conversion.Val(val[val.Row, 38]) != Conversion.Val(val[val.Row, 68]))
					{
						goto IL_09d0;
					}
					goto IL_0ae2;
					IL_09d0:
					num2 = 52;
					val[val.Row, 68] = Strings.Format((object)Conversion.Val(val[val.Row, 38]), "0.00");
					goto IL_0a04;
					IL_0a04:
					num2 = 53;
					if ((Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 38]) != 0.0) & (Conversion.Val(val[val.Row, 34]) != 0.0))
					{
						goto IL_0a64;
					}
					goto IL_0ae2;
					IL_0a64:
					num2 = 54;
					val[val.Row, 39] = Strings.Format((object)((Conversion.Val(val[val.Row, 34]) + Conversion.Val(val[val.Row, 36])) * (Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 38])) / 100.0), "0.000");
					goto IL_0ae2;
					IL_0ae2:
					num2 = 57;
					if (Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 38]) == 0.0)
					{
						goto IL_0b1d;
					}
					goto IL_0b67;
					IL_0b1d:
					num2 = 58;
					val[val.Row, 39] = Strings.Format((object)(Conversion.Val(val[val.Row, 34]) + Conversion.Val(val[val.Row, 36])), "0.000");
					goto IL_0b67;
					IL_0b67:
					num2 = 60;
					if ((Conversion.Val(val[val.Row, 45]) != 0.0) & (Conversion.Val(val[val.Row, 24]) != 0.0))
					{
						goto IL_0bb7;
					}
					goto IL_0d5f;
					IL_0bb7:
					num2 = 61;
					switch (val[val.Row, 52])
					{
					case "P":
						break;
					case "1":
						goto IL_0c53;
					case "K":
						goto IL_0cb1;
					default:
						goto IL_0d0c;
					}
					goto IL_0c00;
					IL_0d0c:
					num2 = 69;
					val[val.Row, 46] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 24]) * Conversion.Val(val[val.Row, 45]), 0), "0.00");
					goto IL_0d5f;
					IL_0cb1:
					num2 = 67;
					val[val.Row, 46] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 24]) * (Conversion.Val(val[val.Row, 45]) / 1000.0), 0), "0.00");
					goto IL_0d5f;
					IL_0c53:
					num2 = 65;
					val[val.Row, 46] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 24]) * (Conversion.Val(val[val.Row, 45]) / 10.0), 0), "0.00");
					goto IL_0d5f;
					IL_0c00:
					num2 = 63;
					val[val.Row, 46] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 8]) * Conversion.Val(val[val.Row, 45]), 0), "0.00");
					goto IL_0d5f;
					IL_0d5f:
					num2 = 72;
					if (Conversion.Val(val[val.Row, 27]) != 0.0)
					{
						goto IL_0d8d;
					}
					goto IL_0f53;
					IL_0d8d:
					num2 = 73;
					switch (val[val.Row, 26])
					{
					case "P":
						break;
					case "N":
						goto IL_0e29;
					case "K":
						goto IL_0e91;
					default:
						goto IL_0f00;
					}
					goto IL_0dd6;
					IL_0f00:
					num2 = 81;
					val[val.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 9]) * Conversion.Val(val[val.Row, 27]), 0), "0.00");
					goto IL_0f53;
					end_IL_0001_2:
					break;
				}
				val = null;
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 4363;
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
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Invalid comparison between Unknown and I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Invalid comparison between Unknown and I4
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Invalid comparison between Unknown and I4
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Invalid comparison between Unknown and I4
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Invalid comparison between Unknown and I4
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Invalid comparison between Unknown and I4
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Invalid comparison between Unknown and I4
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Invalid comparison between Unknown and I4
		//IL_0617: Unknown result type (might be due to invalid IL or missing references)
		//IL_0839: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e89: Unknown result type (might be due to invalid IL or missing references)
		//IL_223b: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		AxMSFlexGrid val = default(AxMSFlexGrid);
		Keys keyCode = default(Keys);
		int num5 = default(int);
		int num6 = default(int);
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
						UpDown = false;
						goto IL_000b;
					case 11098:
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
								goto IL_000b;
							case 3:
								goto IL_0014;
							case 4:
								goto IL_001e;
							case 5:
								goto IL_0028;
							case 7:
								goto IL_0032;
							case 8:
								goto IL_004e;
							case 9:
								goto IL_0066;
							case 10:
								goto IL_007b;
							case 11:
								goto IL_0095;
							case 12:
								goto IL_00ad;
							case 13:
								goto IL_00c1;
							case 16:
								goto IL_00d8;
							case 17:
								goto IL_00e7;
							case 19:
								goto IL_00f6;
							case 20:
								goto IL_0104;
							case 22:
								goto IL_0113;
							case 23:
								goto IL_0122;
							case 24:
								goto IL_0134;
							case 25:
								goto IL_0143;
							case 27:
								goto IL_0151;
							case 28:
								goto IL_015b;
							case 26:
							case 29:
							case 30:
								goto IL_0166;
							case 34:
								goto IL_0184;
							case 35:
								goto IL_0196;
							case 36:
								goto IL_01b0;
							case 38:
								goto IL_01c4;
							case 39:
								goto IL_01dd;
							case 40:
								goto IL_01ec;
							case 42:
								goto IL_01fa;
							case 41:
							case 43:
							case 44:
								goto IL_0205;
							case 48:
								goto IL_0223;
							case 49:
								goto IL_0232;
							case 50:
								goto IL_0244;
							case 51:
								goto IL_0253;
							case 53:
								goto IL_0261;
							case 52:
							case 54:
							case 55:
								goto IL_026c;
							case 56:
								goto IL_0276;
							case 60:
								goto IL_0294;
							case 61:
								goto IL_02a3;
							case 62:
								goto IL_02bc;
							case 63:
								goto IL_02cb;
							case 65:
								goto IL_02d9;
							case 64:
							case 66:
							case 67:
								goto IL_02e4;
							case 68:
								goto IL_02ee;
							case 72:
								goto IL_030c;
							case 73:
								goto IL_031f;
							case 75:
								goto IL_036f;
							case 76:
								goto IL_03b6;
							case 77:
								goto IL_046e;
							case 78:
								goto IL_0480;
							case 79:
								goto IL_049e;
							case 80:
								goto IL_04ba;
							case 82:
								goto IL_04f9;
							case 81:
							case 83:
							case 84:
								goto IL_0535;
							case 85:
								goto IL_0547;
							case 86:
								goto IL_0556;
							case 87:
								goto IL_0569;
							case 88:
								goto IL_057c;
							case 89:
								goto IL_058f;
							case 90:
								goto IL_05a2;
							case 91:
								goto IL_05b5;
							case 92:
								goto IL_05c8;
							case 93:
								goto IL_05db;
							case 94:
								goto IL_05ee;
							case 95:
								goto IL_0601;
							case 96:
								goto IL_060a;
							case 97:
								goto IL_061d;
							case 99:
								goto IL_0630;
							case 100:
								goto IL_0651;
							case 101:
								goto IL_066d;
							case 103:
								goto IL_0687;
							case 102:
							case 104:
							case 105:
								goto IL_069e;
							case 106:
								goto IL_06b7;
							case 107:
								goto IL_06cf;
							case 108:
								goto IL_06eb;
							case 110:
								goto IL_0707;
							case 109:
							case 111:
							case 112:
								goto IL_0720;
							case 113:
								goto IL_0743;
							case 114:
								goto IL_0766;
							case 115:
								goto IL_077f;
							case 118:
								goto IL_0797;
							case 119:
								goto IL_07ae;
							case 120:
								goto IL_07c4;
							case 124:
								goto IL_07e0;
							case 125:
								goto IL_07f5;
							case 126:
								goto IL_082f;
							case 128:
							case 129:
								goto IL_0846;
							case 130:
								goto IL_0861;
							case 131:
								goto IL_089f;
							case 132:
								goto IL_08c0;
							case 133:
								goto IL_0936;
							case 134:
								goto IL_094b;
							case 135:
								goto IL_095d;
							case 136:
								goto IL_0973;
							case 137:
								goto IL_0989;
							case 138:
								goto IL_099f;
							case 139:
								goto IL_09b5;
							case 140:
								goto IL_09cb;
							case 141:
								goto IL_09e1;
							case 142:
								goto IL_09f7;
							case 143:
								goto IL_0a0d;
							case 144:
								goto IL_0a23;
							case 145:
								goto IL_0a2f;
							case 146:
								goto IL_0a45;
							case 148:
								goto IL_0a5b;
							case 149:
								goto IL_0a7f;
							case 150:
								goto IL_0a98;
							case 151:
								goto IL_0ab4;
							case 152:
								goto IL_0acf;
							case 153:
								goto IL_0aea;
							case 154:
								goto IL_0b10;
							case 155:
								goto IL_0b36;
							case 156:
								goto IL_0b52;
							case 157:
							case 158:
							case 159:
								goto IL_0b68;
							case 160:
								goto IL_0bfb;
							case 161:
								goto IL_0c10;
							case 162:
								goto IL_0c21;
							case 163:
								goto IL_0c42;
							case 164:
								goto IL_0c7e;
							case 165:
								goto IL_0cbb;
							case 166:
								goto IL_0cf7;
							case 167:
								goto IL_0d33;
							case 168:
								goto IL_0d6f;
							case 169:
								goto IL_0dab;
							case 170:
								goto IL_0de8;
							case 171:
								goto IL_0e25;
							case 172:
								goto IL_0e62;
							case 173:
								goto IL_0e9f;
							case 174:
								goto IL_0edc;
							case 175:
								goto IL_0f23;
							case 176:
								goto IL_0f6a;
							case 177:
								goto IL_0fb1;
							case 178:
								goto IL_0ff8;
							case 179:
								goto IL_103e;
							case 180:
								goto IL_1070;
							case 181:
								goto IL_10b7;
							case 182:
								goto IL_10fe;
							case 183:
								goto IL_1145;
							case 184:
								goto IL_118c;
							case 185:
								goto IL_11d3;
							case 186:
								goto IL_121a;
							case 187:
								goto IL_1261;
							case 188:
								goto IL_12a8;
							case 189:
								goto IL_12ef;
							case 190:
								goto IL_1336;
							case 191:
								goto IL_137d;
							case 192:
								goto IL_13c4;
							case 193:
								goto IL_140b;
							case 194:
								goto IL_1452;
							case 195:
								goto IL_1499;
							case 196:
								goto IL_14d6;
							case 197:
								goto IL_151d;
							case 198:
								goto IL_1564;
							case 199:
								goto IL_15ab;
							case 200:
								goto IL_15f2;
							case 201:
								goto IL_1639;
							case 202:
								goto IL_1680;
							case 203:
								goto IL_16c7;
							case 204:
								goto IL_170e;
							case 205:
								goto IL_1755;
							case 206:
								goto IL_179c;
							case 207:
								goto IL_17e3;
							case 208:
								goto IL_182a;
							case 209:
								goto IL_1871;
							case 210:
								goto IL_18b8;
							case 211:
								goto IL_18ff;
							case 212:
								goto IL_1946;
							case 213:
								goto IL_1983;
							case 214:
								goto IL_19ca;
							case 215:
								goto IL_1a07;
							case 216:
								goto IL_1a44;
							case 217:
								goto IL_1a81;
							case 218:
								goto IL_1abe;
							case 219:
								goto IL_1afb;
							case 220:
								goto IL_1b38;
							case 221:
								goto IL_1b75;
							case 222:
								goto IL_1bb2;
							case 223:
								goto IL_1bef;
							case 224:
								goto IL_1c2c;
							case 117:
							case 122:
							case 123:
							case 225:
							case 226:
							case 227:
								goto IL_1c6a;
							case 228:
								goto IL_1c89;
							case 229:
								goto IL_1ca3;
							case 230:
								goto IL_1cb0;
							case 231:
								goto IL_1cc5;
							case 232:
								goto IL_1cda;
							case 233:
								goto IL_1ce7;
							case 234:
								goto IL_1cf5;
							case 237:
								goto IL_1d0b;
							case 243:
								goto IL_1d2a;
							case 244:
								goto IL_1d6e;
							case 245:
								goto IL_1d83;
							case 246:
								goto IL_1da4;
							case 247:
								goto IL_1dc3;
							case 248:
								goto IL_1dd8;
							case 249:
								goto IL_1de9;
							case 250:
								goto IL_1dff;
							case 251:
								goto IL_1e15;
							case 252:
								goto IL_1e2b;
							case 253:
								goto IL_1e41;
							case 254:
								goto IL_1e57;
							case 255:
								goto IL_1e6d;
							case 256:
								goto IL_1e79;
							case 257:
								goto IL_1e8f;
							case 259:
								goto IL_1ea5;
							case 260:
								goto IL_1ec9;
							case 261:
								goto IL_1ee2;
							case 262:
								goto IL_1efd;
							case 263:
								goto IL_1f19;
							case 264:
								goto IL_1f35;
							case 265:
								goto IL_1f51;
							case 266:
							case 267:
								goto IL_1f6f;
							case 270:
								goto IL_1f8d;
							case 271:
								goto IL_1fcb;
							case 272:
								goto IL_2009;
							case 273:
								goto IL_2047;
							case 274:
								goto IL_2085;
							case 275:
								goto IL_20c3;
							case 278:
								goto IL_2105;
							case 279:
								goto IL_2159;
							case 280:
								goto IL_216e;
							case 281:
								goto IL_218f;
							case 282:
								goto IL_21cd;
							case 283:
								goto IL_21e2;
							case 284:
								goto IL_21f3;
							case 285:
								goto IL_2209;
							case 286:
								goto IL_221f;
							case 287:
								goto IL_222b;
							case 288:
								goto IL_2241;
							case 290:
								goto IL_2257;
							case 291:
								goto IL_2278;
							case 292:
								goto IL_2291;
							case 293:
							case 294:
								goto IL_22ae;
							case 297:
								goto IL_22c9;
							case 300:
								goto IL_230d;
							case 301:
								goto IL_2334;
							case 305:
								goto IL_2353;
							case 306:
								goto IL_236d;
							case 307:
								goto IL_238c;
							case 308:
								goto IL_23ac;
							case 309:
								goto IL_23b9;
							case 310:
								goto IL_23ce;
							case 311:
								goto IL_23e3;
							case 312:
								goto IL_23f0;
							case 313:
								goto IL_23fe;
							case 316:
								goto IL_2414;
							case 315:
							case 317:
							case 318:
								goto IL_242a;
							case 319:
								goto IL_2438;
							case 320:
								goto IL_244b;
							case 324:
								goto IL_246a;
							case 325:
								goto IL_2489;
							case 326:
								goto IL_24bd;
							case 327:
								goto IL_24ca;
							case 328:
								goto IL_24df;
							case 329:
								goto IL_24f4;
							case 330:
								goto IL_2501;
							case 331:
								goto IL_250f;
							case 334:
								goto IL_2525;
							case 333:
							case 335:
							case 336:
								goto IL_253b;
							case 337:
								goto IL_2549;
							case 338:
								goto IL_255c;
							case 74:
							case 236:
							case 239:
							case 240:
							case 241:
							case 242:
							case 269:
							case 276:
							case 277:
							case 296:
							case 298:
							case 299:
							case 303:
							case 304:
							case 322:
							case 323:
							case 340:
							case 341:
								goto IL_2573;
							case 342:
								goto IL_258f;
							case 343:
							case 344:
								goto IL_25b0;
							case 345:
								goto IL_25c3;
							case 6:
							case 14:
							case 15:
							case 18:
							case 21:
							case 33:
							case 47:
							case 59:
							case 71:
							case 346:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 31:
							case 32:
							case 37:
							case 45:
							case 46:
							case 57:
							case 58:
							case 69:
							case 70:
							case 98:
							case 116:
							case 121:
							case 127:
							case 147:
							case 235:
							case 238:
							case 258:
							case 268:
							case 289:
							case 295:
							case 302:
							case 314:
							case 321:
							case 332:
							case 339:
							case 347:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0846:
						num2 = 129;
						DC_Main.X++;
						goto IL_0858;
						IL_2573:
						num2 = 341;
						if (val.Col < val.Cols - 1)
						{
							goto IL_258f;
						}
						goto IL_25b0;
						IL_082f:
						num2 = 126;
						Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001_3;
						IL_258f:
						num2 = 342;
						MSG.Col += 1;
						goto IL_25b0;
						IL_000b:
						num2 = 2;
						Msgleft = false;
						goto IL_0014;
						IL_0014:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_001e;
						IL_001e:
						num2 = 4;
						val = MSG;
						goto IL_0028;
						IL_0028:
						num2 = 5;
						keyCode = e.KeyCode;
						goto IL_0032;
						IL_0032:
						num2 = 7;
						if (unchecked((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0)))))
						{
							goto IL_004e;
						}
						goto IL_00d8;
						IL_004e:
						num2 = 8;
						if (unchecked((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null)) != 6)
						{
							break;
						}
						goto IL_0066;
						IL_0066:
						num2 = 9;
						num5 = val.Cols - 1;
						DC_Main.M = 1;
						goto IL_00a4;
						IL_00a4:
						if (DC_Main.M <= num5)
						{
							goto IL_007b;
						}
						goto IL_00ad;
						IL_00ad:
						num2 = 12;
						TEXT_ENTRY.Text = "";
						goto IL_00c1;
						IL_00c1:
						num2 = 13;
						Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
						break;
						IL_007b:
						num2 = 10;
						val[val.Row, DC_Main.M] = "";
						goto IL_0095;
						IL_0095:
						num2 = 11;
						DC_Main.M++;
						goto IL_00a4;
						IL_00d8:
						num2 = 16;
						if (unchecked((int)keyCode) == 46)
						{
							goto IL_00e7;
						}
						goto IL_00f6;
						IL_00e7:
						num2 = 17;
						MsTxtDelete = true;
						break;
						IL_00f6:
						num2 = 19;
						if (unchecked((int)keyCode) == 8)
						{
							goto IL_0104;
						}
						goto IL_0113;
						IL_0104:
						num2 = 20;
						MsTxtDelete = true;
						break;
						IL_0113:
						num2 = 22;
						if (unchecked((int)keyCode) == 37)
						{
							goto IL_0122;
						}
						goto IL_0184;
						IL_0122:
						num2 = 23;
						if (val.Col <= 1)
						{
							goto end_IL_0001_3;
						}
						goto IL_0134;
						IL_0134:
						num2 = 24;
						if (MsTxtDelete)
						{
							goto IL_0143;
						}
						goto IL_0151;
						IL_0143:
						num2 = 25;
						MsTxtDelete = false;
						goto IL_0166;
						IL_0151:
						num2 = 27;
						Msgleft = true;
						goto IL_015b;
						IL_015b:
						num2 = 28;
						UpDown = true;
						goto IL_0166;
						IL_0166:
						num2 = 30;
						val.Col -= 1;
						goto end_IL_0001_3;
						IL_0184:
						num2 = 34;
						if (unchecked((int)keyCode) == 39)
						{
							goto IL_0196;
						}
						goto IL_0223;
						IL_0196:
						num2 = 35;
						if (val.Col >= MsgLastCol)
						{
							goto IL_01b0;
						}
						goto IL_01c4;
						IL_01b0:
						num2 = 36;
						((Control)TEXT_ENTRY).Focus();
						goto end_IL_0001_3;
						IL_01c4:
						num2 = 38;
						if (val.Col >= val.Cols - 1)
						{
							goto end_IL_0001_3;
						}
						goto IL_01dd;
						IL_01dd:
						num2 = 39;
						if (MsTxtDelete)
						{
							goto IL_01ec;
						}
						goto IL_01fa;
						IL_01ec:
						num2 = 40;
						MsTxtDelete = false;
						goto IL_0205;
						IL_01fa:
						num2 = 42;
						UpDown = true;
						goto IL_0205;
						IL_0205:
						num2 = 44;
						val.Col += 1;
						goto end_IL_0001_3;
						IL_0223:
						num2 = 48;
						if (unchecked((int)keyCode) == 38)
						{
							goto IL_0232;
						}
						goto IL_0294;
						IL_0232:
						num2 = 49;
						if (val.Row <= 1)
						{
							goto end_IL_0001_3;
						}
						goto IL_0244;
						IL_0244:
						num2 = 50;
						if (MsTxtDelete)
						{
							goto IL_0253;
						}
						goto IL_0261;
						IL_0253:
						num2 = 51;
						MsTxtDelete = false;
						goto IL_026c;
						IL_0261:
						num2 = 53;
						UpDown = true;
						goto IL_026c;
						IL_026c:
						num2 = 55;
						MsgOldRow = 0;
						goto IL_0276;
						IL_0276:
						num2 = 56;
						val.Row -= 1;
						goto end_IL_0001_3;
						IL_0294:
						num2 = 60;
						if (unchecked((int)keyCode) == 40)
						{
							goto IL_02a3;
						}
						goto IL_030c;
						IL_02a3:
						num2 = 61;
						if (val.Row >= val.Rows - 1)
						{
							goto end_IL_0001_3;
						}
						goto IL_02bc;
						IL_02bc:
						num2 = 62;
						if (MsTxtDelete)
						{
							goto IL_02cb;
						}
						goto IL_02d9;
						IL_02cb:
						num2 = 63;
						MsTxtDelete = false;
						goto IL_02e4;
						IL_02d9:
						num2 = 65;
						UpDown = true;
						goto IL_02e4;
						IL_02e4:
						num2 = 67;
						MsgOldRow = 0;
						goto IL_02ee;
						IL_02ee:
						num2 = 68;
						val.Row += 1;
						goto end_IL_0001_3;
						IL_030c:
						num2 = 72;
						if (unchecked((int)keyCode) != 13)
						{
							break;
						}
						goto IL_031f;
						IL_031f:
						num2 = 73;
						switch (val.Col)
						{
						case 2:
							break;
						case 3:
							goto IL_1d2a;
						case 4:
							goto IL_2105;
						case 9:
							goto IL_230d;
						case 31:
							goto IL_2353;
						case 32:
							goto IL_246a;
						default:
							goto IL_2573;
						}
						goto IL_036f;
						IL_246a:
						num2 = 324;
						if (val.Row == val.Rows - 1)
						{
							goto IL_2489;
						}
						goto IL_2525;
						IL_2489:
						num2 = 325;
						val[val.Row, 32] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
						goto IL_24bd;
						IL_24bd:
						num2 = 326;
						MsgClear = true;
						goto IL_24ca;
						IL_24ca:
						num2 = 327;
						val.Rows += 1;
						goto IL_24df;
						IL_24df:
						num2 = 328;
						val.Row += 1;
						goto IL_24f4;
						IL_24f4:
						num2 = 329;
						MsgClear = false;
						goto IL_2501;
						IL_2501:
						num2 = 330;
						val.Col = 2;
						goto IL_250f;
						IL_250f:
						num2 = 331;
						CommPassAdd();
						goto end_IL_0001_3;
						IL_2525:
						num2 = 334;
						val.Row += 1;
						goto IL_253b;
						IL_253b:
						num2 = 336;
						val.Col = 1;
						goto IL_2549;
						IL_2549:
						num2 = 337;
						((Control)TEXT_ENTRY).Visible = true;
						goto IL_255c;
						IL_255c:
						num2 = 338;
						((Control)TEXT_ENTRY).Focus();
						goto end_IL_0001_3;
						IL_2353:
						num2 = 305;
						if (val[32] == 0)
						{
							goto IL_236d;
						}
						goto IL_2573;
						IL_236d:
						num2 = 306;
						if (val.Row == val.Rows - 1)
						{
							goto IL_238c;
						}
						goto IL_2414;
						IL_238c:
						num2 = 307;
						val[val.Row, 31] = TEXT_ENTRY.Text;
						goto IL_23ac;
						IL_23ac:
						num2 = 308;
						MsgClear = true;
						goto IL_23b9;
						IL_23b9:
						num2 = 309;
						val.Rows += 1;
						goto IL_23ce;
						IL_23ce:
						num2 = 310;
						val.Row += 1;
						goto IL_23e3;
						IL_23e3:
						num2 = 311;
						MsgClear = false;
						goto IL_23f0;
						IL_23f0:
						num2 = 312;
						val.Col = 2;
						goto IL_23fe;
						IL_23fe:
						num2 = 313;
						CommPassAdd();
						goto end_IL_0001_3;
						IL_2414:
						num2 = 316;
						val.Row += 1;
						goto IL_242a;
						IL_242a:
						num2 = 318;
						val.Col = 1;
						goto IL_2438;
						IL_2438:
						num2 = 319;
						((Control)TEXT_ENTRY).Visible = true;
						goto IL_244b;
						IL_244b:
						num2 = 320;
						((Control)TEXT_ENTRY).Focus();
						goto end_IL_0001_3;
						IL_230d:
						num2 = 300;
						if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
						{
							goto IL_2334;
						}
						goto IL_2573;
						IL_2334:
						num2 = 301;
						((Control)TEXT_ENTRY).Focus();
						goto end_IL_0001_3;
						IL_2105:
						num2 = 278;
						DC_Main.RsQry = "Select * From TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' and LC_CODE = '" + DC_Main.MLc_code + "'  AND TABLE_CODE = '" + TEXT_ENTRY.Text + "'";
						goto IL_2159;
						IL_2159:
						num2 = 279;
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_216e;
						IL_216e:
						num2 = 280;
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							goto IL_218f;
						}
						goto IL_22c9;
						IL_218f:
						num2 = 281;
						DC_Main.RsQry = "SELECT TABLE_NAME As CounterL,TABLE_CODE as CodeL  FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY TABLE_NAME";
						goto IL_21cd;
						IL_21cd:
						num2 = 282;
						DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_21e2;
						IL_21e2:
						num2 = 283;
						DC_Main.ColWidth = new double[3];
						goto IL_21f3;
						IL_21f3:
						num2 = 284;
						DC_Main.ColWidth[0] = 400.0;
						goto IL_2209;
						IL_2209:
						num2 = 285;
						DC_Main.ColWidth[1] = 100.0;
						goto IL_221f;
						IL_221f:
						num2 = 286;
						DC_Main.HelpSelect = 1;
						goto IL_222b;
						IL_222b:
						num2 = 287;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						goto IL_2241;
						IL_2241:
						num2 = 288;
						if (DC_Main.HelpClose)
						{
							goto end_IL_0001_3;
						}
						goto IL_2257;
						IL_2257:
						num2 = 290;
						if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
						{
							goto IL_2278;
						}
						goto IL_22ae;
						IL_2278:
						num2 = 291;
						TEXT_ENTRY.Text = DC_Main.ColValue[1];
						goto IL_2291;
						IL_2291:
						num2 = 292;
						val[val.Row, 4] = DC_Main.ColValue[1];
						goto IL_22ae;
						IL_22ae:
						num2 = 294;
						((Control)TEXT_ENTRY).Focus();
						goto end_IL_0001_3;
						IL_22c9:
						num2 = 297;
						val[val.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_CODE"], (object)""));
						goto IL_2573;
						IL_1d2a:
						num2 = 243;
						DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_ENTRY.Text + "'";
						goto IL_1d6e;
						IL_1d6e:
						num2 = 244;
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_1d83;
						IL_1d83:
						num2 = 245;
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							goto IL_1da4;
						}
						goto IL_1f8d;
						IL_1da4:
						num2 = 246;
						DC_Main.RsQry = "SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.IT_NAME";
						goto IL_1dc3;
						IL_1dc3:
						num2 = 247;
						DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_1dd8;
						IL_1dd8:
						num2 = 248;
						DC_Main.ColWidth = new double[7];
						goto IL_1de9;
						IL_1de9:
						num2 = 249;
						DC_Main.ColWidth[0] = 300.0;
						goto IL_1dff;
						IL_1dff:
						num2 = 250;
						DC_Main.ColWidth[1] = 100.0;
						goto IL_1e15;
						IL_1e15:
						num2 = 251;
						DC_Main.ColWidth[2] = 250.0;
						goto IL_1e2b;
						IL_1e2b:
						num2 = 252;
						DC_Main.ColWidth[3] = 0.0;
						goto IL_1e41;
						IL_1e41:
						num2 = 253;
						DC_Main.ColWidth[4] = 0.0;
						goto IL_1e57;
						IL_1e57:
						num2 = 254;
						DC_Main.ColWidth[5] = 0.0;
						goto IL_1e6d;
						IL_1e6d:
						num2 = 255;
						DC_Main.HelpSelect = 1;
						goto IL_1e79;
						IL_1e79:
						num2 = 256;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						goto IL_1e8f;
						IL_1e8f:
						num2 = 257;
						if (DC_Main.HelpClose)
						{
							goto end_IL_0001_3;
						}
						goto IL_1ea5;
						IL_1ea5:
						num2 = 259;
						if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
						{
							goto IL_1ec9;
						}
						goto IL_1f6f;
						IL_1ec9:
						num2 = 260;
						TEXT_ENTRY.Text = DC_Main.ColValue[1];
						goto IL_1ee2;
						IL_1ee2:
						num2 = 261;
						val[val.Row, 3] = DC_Main.ColValue[1];
						goto IL_1efd;
						IL_1efd:
						num2 = 262;
						val[val.Row, 56] = DC_Main.ColValue[0];
						goto IL_1f19;
						IL_1f19:
						num2 = 263;
						val[val.Row, 55] = DC_Main.ColValue[3];
						goto IL_1f35;
						IL_1f35:
						num2 = 264;
						val[val.Row, 53] = DC_Main.ColValue[4];
						goto IL_1f51;
						IL_1f51:
						num2 = 265;
						val[val.Row, 54] = DC_Main.ColValue[4];
						goto IL_1f6f;
						IL_1f6f:
						num2 = 267;
						((Control)TEXT_ENTRY).Focus();
						goto end_IL_0001_3;
						IL_1f8d:
						num2 = 270;
						val[val.Row, 56] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						goto IL_1fcb;
						IL_1fcb:
						num2 = 271;
						val[val.Row, 55] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						goto IL_2009;
						IL_2009:
						num2 = 272;
						val[val.Row, 53] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						goto IL_2047;
						IL_2047:
						num2 = 273;
						val[val.Row, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
						goto IL_2085;
						IL_2085:
						num2 = 274;
						val[val.Row, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						goto IL_20c3;
						IL_20c3:
						num2 = 275;
						lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)" : It Name"));
						goto IL_2573;
						IL_036f:
						num2 = 75;
						if ((Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0) | (Operators.CompareString(TEXT_ENTRY.Text, val[val.Row, 2], false) != 0))
						{
							goto IL_03b6;
						}
						goto IL_2573;
						IL_03b6:
						num2 = 76;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO,A.VCH_SRNO,B.VCH_TIME FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + TEXT_ENTRY.Text + "'"), Interaction.IIf(Conversion.Val(val[val.Row, 44]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(val[val.Row, 44]))) ?? ""))), (object)" GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_TIME HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_TIME DESC"));
						goto IL_046e;
						IL_25c3:
						num2 = 345;
						((Control)TEXT_ENTRY).Focus();
						break;
						IL_25b0:
						num2 = 344;
						((Control)TEXT_ENTRY).Visible = true;
						goto IL_25c3;
						IL_046e:
						num2 = 77;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0480;
						IL_0480:
						num2 = 78;
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							goto IL_049e;
						}
						goto IL_07e0;
						IL_049e:
						num2 = 79;
						if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
						{
							goto IL_04ba;
						}
						goto IL_04f9;
						IL_04ba:
						num2 = 80;
						DC_Main.RsQry = "Select C.DESIGN_NO AS DesignL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,A.TAG_NO AS TagNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_TIME DESC";
						goto IL_0535;
						IL_04f9:
						num2 = 82;
						DC_Main.RsQry = "Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_TIME DESC";
						goto IL_0535;
						IL_0535:
						num2 = 84;
						DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0547;
						IL_0547:
						num2 = 85;
						DC_Main.ColWidth = new double[10];
						goto IL_0556;
						IL_0556:
						num2 = 86;
						DC_Main.ColWidth[0] = 120.0;
						goto IL_0569;
						IL_0569:
						num2 = 87;
						DC_Main.ColWidth[1] = 300.0;
						goto IL_057c;
						IL_057c:
						num2 = 88;
						DC_Main.ColWidth[2] = 100.0;
						goto IL_058f;
						IL_058f:
						num2 = 89;
						DC_Main.ColWidth[3] = 120.0;
						goto IL_05a2;
						IL_05a2:
						num2 = 90;
						DC_Main.ColWidth[4] = 100.0;
						goto IL_05b5;
						IL_05b5:
						num2 = 91;
						DC_Main.ColWidth[5] = 100.0;
						goto IL_05c8;
						IL_05c8:
						num2 = 92;
						DC_Main.ColWidth[6] = 110.0;
						goto IL_05db;
						IL_05db:
						num2 = 93;
						DC_Main.ColWidth[7] = 0.0;
						goto IL_05ee;
						IL_05ee:
						num2 = 94;
						DC_Main.ColWidth[8] = 0.0;
						goto IL_0601;
						IL_0601:
						num2 = 95;
						DC_Main.HelpSelect = 1;
						goto IL_060a;
						IL_060a:
						num2 = 96;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						goto IL_061d;
						IL_061d:
						num2 = 97;
						if (DC_Main.HelpClose)
						{
							goto end_IL_0001_3;
						}
						goto IL_0630;
						IL_0630:
						num2 = 99;
						if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
						{
							goto IL_0651;
						}
						goto IL_0797;
						IL_0651:
						num2 = 100;
						if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
						{
							goto IL_066d;
						}
						goto IL_0687;
						IL_066d:
						num2 = 101;
						TEXT_ENTRY.Text = DC_Main.ColValue[3];
						goto IL_069e;
						IL_0687:
						num2 = 103;
						TEXT_ENTRY.Text = DC_Main.ColValue[0];
						goto IL_069e;
						IL_069e:
						num2 = 105;
						val[val.Row, 56] = DC_Main.ColValue[1];
						goto IL_06b7;
						IL_06b7:
						num2 = 106;
						val[val.Row, 3] = DC_Main.ColValue[2];
						goto IL_06cf;
						IL_06cf:
						num2 = 107;
						if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
						{
							goto IL_06eb;
						}
						goto IL_0707;
						IL_06eb:
						num2 = 108;
						val[val.Row, 5] = DC_Main.ColValue[0];
						goto IL_0720;
						IL_0707:
						num2 = 110;
						val[val.Row, 5] = DC_Main.ColValue[3];
						goto IL_0720;
						IL_0720:
						num2 = 112;
						val[val.Row, 9] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
						goto IL_0743;
						IL_0743:
						num2 = 113;
						val[val.Row, 19] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
						goto IL_0766;
						IL_0766:
						num2 = 114;
						val[val.Row, 44] = DC_Main.ColValue[7];
						goto IL_077f;
						IL_077f:
						num2 = 115;
						((Control)TEXT_ENTRY).Focus();
						goto end_IL_0001_3;
						IL_0797:
						num2 = 118;
						val[val.Row, 44] = "";
						goto IL_07ae;
						IL_07ae:
						num2 = 119;
						val[val.Row, 2] = "";
						goto IL_07c4;
						IL_07c4:
						num2 = 120;
						((Control)TEXT_ENTRY).Focus();
						goto end_IL_0001_3;
						IL_07e0:
						num2 = 124;
						num6 = val.Rows - 1;
						DC_Main.X = 1;
						goto IL_0858;
						IL_0858:
						if (DC_Main.X <= num6)
						{
							goto IL_07f5;
						}
						goto IL_0861;
						IL_0861:
						num2 = 130;
						val[val.Row, 44] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
						goto IL_089f;
						IL_089f:
						num2 = 131;
						if (DC_Main.Rshlp.Rows.Count > 1)
						{
							goto IL_08c0;
						}
						goto IL_0b68;
						IL_08c0:
						num2 = 132;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_DATE From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_DATE HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_DATE DESC"));
						goto IL_0936;
						IL_0936:
						num2 = 133;
						DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_094b;
						IL_094b:
						num2 = 134;
						DC_Main.ColWidth = new double[10];
						goto IL_095d;
						IL_095d:
						num2 = 135;
						DC_Main.ColWidth[0] = 120.0;
						goto IL_0973;
						IL_0973:
						num2 = 136;
						DC_Main.ColWidth[1] = 300.0;
						goto IL_0989;
						IL_0989:
						num2 = 137;
						DC_Main.ColWidth[2] = 100.0;
						goto IL_099f;
						IL_099f:
						num2 = 138;
						DC_Main.ColWidth[3] = 120.0;
						goto IL_09b5;
						IL_09b5:
						num2 = 139;
						DC_Main.ColWidth[4] = 100.0;
						goto IL_09cb;
						IL_09cb:
						num2 = 140;
						DC_Main.ColWidth[5] = 100.0;
						goto IL_09e1;
						IL_09e1:
						num2 = 141;
						DC_Main.ColWidth[6] = 110.0;
						goto IL_09f7;
						IL_09f7:
						num2 = 142;
						DC_Main.ColWidth[7] = 0.0;
						goto IL_0a0d;
						IL_0a0d:
						num2 = 143;
						DC_Main.ColWidth[8] = 0.0;
						goto IL_0a23;
						IL_0a23:
						num2 = 144;
						DC_Main.HelpSelect = 1;
						goto IL_0a2f;
						IL_0a2f:
						num2 = 145;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						goto IL_0a45;
						IL_0a45:
						num2 = 146;
						if (DC_Main.HelpClose)
						{
							goto end_IL_0001_3;
						}
						goto IL_0a5b;
						IL_0a5b:
						num2 = 148;
						if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
						{
							goto IL_0a7f;
						}
						goto IL_0b68;
						IL_0a7f:
						num2 = 149;
						TEXT_ENTRY.Text = DC_Main.ColValue[0];
						goto IL_0a98;
						IL_0a98:
						num2 = 150;
						val[val.Row, 56] = DC_Main.ColValue[1];
						goto IL_0ab4;
						IL_0ab4:
						num2 = 151;
						val[val.Row, 3] = DC_Main.ColValue[0];
						goto IL_0acf;
						IL_0acf:
						num2 = 152;
						val[val.Row, 5] = DC_Main.ColValue[3];
						goto IL_0aea;
						IL_0aea:
						num2 = 153;
						val[val.Row, 9] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
						goto IL_0b10;
						IL_0b10:
						num2 = 154;
						val[val.Row, 19] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
						goto IL_0b36;
						IL_0b36:
						num2 = 155;
						val[val.Row, 44] = DC_Main.ColValue[7];
						goto IL_0b52;
						IL_0b52:
						num2 = 156;
						((Control)TEXT_ENTRY).Focus();
						goto IL_0b68;
						IL_0b68:
						num2 = 159;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' AND A.VCH_SRNO = '"), (object)val[val.Row, 44]), (object)"' ORDER BY A.VCH_TIME DESC "));
						goto IL_0bfb;
						IL_0bfb:
						num2 = 160;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0c10;
						IL_0c10:
						num2 = 161;
						DC_Main.i = val.Row;
						goto IL_0c21;
						IL_0c21:
						num2 = 162;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							goto IL_0c42;
						}
						goto IL_1c6a;
						IL_0c42:
						num2 = 163;
						val[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
						goto IL_0c7e;
						IL_0c7e:
						num2 = 164;
						val[DC_Main.i, 56] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
						goto IL_0cbb;
						IL_0cbb:
						num2 = 165;
						val[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
						goto IL_0cf7;
						IL_0cf7:
						num2 = 166;
						val[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
						goto IL_0d33;
						IL_0d33:
						num2 = 167;
						val[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
						goto IL_0d6f;
						IL_0d6f:
						num2 = 168;
						val[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
						goto IL_0dab;
						IL_0dab:
						num2 = 169;
						val[DC_Main.i, 25] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_CODE"], (object)""));
						goto IL_0de8;
						IL_0de8:
						num2 = 170;
						val[DC_Main.i, 10] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
						goto IL_0e25;
						IL_0e25:
						num2 = 171;
						val[DC_Main.i, 12] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID2"], (object)""));
						goto IL_0e62;
						IL_0e62:
						num2 = 172;
						val[DC_Main.i, 14] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID3"], (object)""));
						goto IL_0e9f;
						IL_0e9f:
						num2 = 173;
						val[DC_Main.i, 16] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID4"], (object)""));
						goto IL_0edc;
						IL_0edc:
						num2 = 174;
						val[DC_Main.i, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID_WT"])), "0.000");
						goto IL_0f23;
						IL_0f23:
						num2 = 175;
						val[DC_Main.i, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID2_WT"])), "0.000");
						goto IL_0f6a;
						IL_0f6a:
						num2 = 176;
						val[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID3_WT"])), "0.000");
						goto IL_0fb1;
						IL_0fb1:
						num2 = 177;
						val[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID4_WT"])), "0.000");
						goto IL_0ff8;
						IL_0ff8:
						num2 = 178;
						val[DC_Main.i, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BAG_WT"])), "0.000");
						goto IL_103e;
						IL_103e:
						num2 = 179;
						val[DC_Main.i, 8] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
						goto IL_1070;
						IL_1070:
						num2 = 180;
						val[DC_Main.i, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
						goto IL_10b7;
						IL_10b7:
						num2 = 181;
						val[DC_Main.i, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
						goto IL_10fe;
						IL_10fe:
						num2 = 182;
						val[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
						goto IL_1145;
						IL_1145:
						num2 = 183;
						val[DC_Main.i, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
						goto IL_118c;
						IL_118c:
						num2 = 184;
						val[DC_Main.i, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
						goto IL_11d3;
						IL_11d3:
						num2 = 185;
						val[DC_Main.i, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
						goto IL_121a;
						IL_121a:
						num2 = 186;
						val[DC_Main.i, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
						goto IL_1261;
						IL_1261:
						num2 = 187;
						val[DC_Main.i, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
						goto IL_12a8;
						IL_12a8:
						num2 = 188;
						val[DC_Main.i, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
						goto IL_12ef;
						IL_12ef:
						num2 = 189;
						val[DC_Main.i, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
						goto IL_1336;
						IL_1336:
						num2 = 190;
						val[DC_Main.i, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
						goto IL_137d;
						IL_137d:
						num2 = 191;
						val[DC_Main.i, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
						goto IL_13c4;
						IL_13c4:
						num2 = 192;
						val[DC_Main.i, 65] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
						goto IL_140b;
						IL_140b:
						num2 = 193;
						val[DC_Main.i, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
						goto IL_1452;
						IL_1452:
						num2 = 194;
						val[DC_Main.i, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
						goto IL_1499;
						IL_1499:
						num2 = 195;
						val[DC_Main.i, 26] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
						goto IL_14d6;
						IL_14d6:
						num2 = 196;
						val[DC_Main.i, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
						goto IL_151d;
						IL_151d:
						num2 = 197;
						val[DC_Main.i, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
						goto IL_1564;
						IL_1564:
						num2 = 198;
						val[DC_Main.i, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
						goto IL_15ab;
						IL_15ab:
						num2 = 199;
						val[DC_Main.i, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_NET_WT"])), "0.00");
						goto IL_15f2;
						IL_15f2:
						num2 = 200;
						val[DC_Main.i, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_TOUCH"])), "0.00");
						goto IL_1639;
						IL_1639:
						num2 = 201;
						val[DC_Main.i, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_WEST_PRC"])), "0.00");
						goto IL_1680;
						IL_1680:
						num2 = 202;
						val[DC_Main.i, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_FINE"])), "0.000");
						goto IL_16c7;
						IL_16c7:
						num2 = 203;
						val[DC_Main.i, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_LBR_RATE"])), "0.00");
						goto IL_170e;
						IL_170e:
						num2 = 204;
						val[DC_Main.i, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_LBR_AMT"])), "0.00");
						goto IL_1755;
						IL_1755:
						num2 = 205;
						val[DC_Main.i, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_OTH_AMT"])), "0.00");
						goto IL_179c;
						IL_179c:
						num2 = 206;
						val[DC_Main.i, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_COST"])), "0.00");
						goto IL_17e3;
						IL_17e3:
						num2 = 207;
						val[DC_Main.i, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
						goto IL_182a;
						IL_182a:
						num2 = 208;
						val[DC_Main.i, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_AMT"])), "0.00");
						goto IL_1871;
						IL_1871:
						num2 = 209;
						val[DC_Main.i, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAG_COST"])), "0.00");
						goto IL_18b8;
						IL_18b8:
						num2 = 210;
						val[DC_Main.i, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MARGIN"])), "0.00");
						goto IL_18ff;
						IL_18ff:
						num2 = 211;
						val[DC_Main.i, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
						goto IL_1946;
						IL_1946:
						num2 = 212;
						val[DC_Main.i, 31] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
						goto IL_1983;
						IL_1983:
						num2 = 213;
						val[DC_Main.i, 50] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAG_SRNO"])), "0");
						goto IL_19ca;
						IL_19ca:
						num2 = 214;
						val[DC_Main.i, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
						goto IL_1a07;
						IL_1a07:
						num2 = 215;
						val[DC_Main.i, 53] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
						goto IL_1a44;
						IL_1a44:
						num2 = 216;
						val[DC_Main.i, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
						goto IL_1a81;
						IL_1a81:
						num2 = 217;
						val[DC_Main.i, 55] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
						goto IL_1abe;
						IL_1abe:
						num2 = 218;
						val[DC_Main.i, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
						goto IL_1afb;
						IL_1afb:
						num2 = 219;
						val[DC_Main.i, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
						goto IL_1b38;
						IL_1b38:
						num2 = 220;
						val[DC_Main.i, 44] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
						goto IL_1b75;
						IL_1b75:
						num2 = 221;
						val[DC_Main.i, 69] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_TYPE"], (object)""));
						goto IL_1bb2;
						IL_1bb2:
						num2 = 222;
						val[DC_Main.i, 70] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["STK_DATE"], (object)""));
						goto IL_1bef;
						IL_1bef:
						num2 = 223;
						val[DC_Main.i, 71] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_STYLE"], (object)""));
						goto IL_1c2c;
						IL_1c2c:
						num2 = 224;
						lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)" : It Name"));
						goto IL_1c6a;
						IL_1c6a:
						num2 = 227;
						if (val.Row == val.Rows - 1)
						{
							goto IL_1c89;
						}
						goto IL_2573;
						IL_1c89:
						num2 = 228;
						if (!chkHmIdUpdate.Checked)
						{
							goto IL_1ca3;
						}
						goto IL_1d0b;
						IL_1ca3:
						num2 = 229;
						MsgClear = true;
						goto IL_1cb0;
						IL_1cb0:
						num2 = 230;
						val.Rows += 1;
						goto IL_1cc5;
						IL_1cc5:
						num2 = 231;
						val.Row += 1;
						goto IL_1cda;
						IL_1cda:
						num2 = 232;
						MsgClear = false;
						goto IL_1ce7;
						IL_1ce7:
						num2 = 233;
						val.Col = 2;
						goto IL_1cf5;
						IL_1cf5:
						num2 = 234;
						CommPassAdd();
						goto end_IL_0001_3;
						IL_1d0b:
						num2 = 237;
						val.Col = 10;
						goto end_IL_0001_3;
						IL_07f5:
						num2 = 125;
						if ((Operators.CompareString(val[DC_Main.X, 2], TEXT_ENTRY.Text, false) == 0) & (val.Row != DC_Main.X))
						{
							goto IL_082f;
						}
						goto IL_0846;
						end_IL_0001_2:
						break;
					}
					val = null;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 11098;
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

	private void TR_TAG_CAN_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_097a: Unknown result type (might be due to invalid IL or missing references)
		//IL_097f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0989: Expected O, but got Unknown
		//IL_09c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d7: Expected O, but got Unknown
		//IL_09ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a06: Expected O, but got Unknown
		//IL_0aa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab1: Expected O, but got Unknown
		//IL_0b39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b48: Expected O, but got Unknown
		//IL_0bba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc5: Expected O, but got Unknown
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
				AxMSFlexGrid mSG = MSG;
				object? obj9 = colorConverter.ConvertFromString("ControlLightLight");
				mSG.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				AxMSFlexGrid mSG2 = MSG;
				object? obj10 = colorConverter.ConvertFromString("DarkGray");
				mSG2.BackColorBkg = ((obj10 != null) ? ((Color)obj10) : default(Color));
				AxMSFlexGrid mSG3 = MSG;
				object? obj11 = colorConverter.ConvertFromString("255, 224, 192");
				mSG3.BackColorFixed = ((obj11 != null) ? ((Color)obj11) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj12 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj13 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj14 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj15 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj15 != null) ? ((Color)obj15) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj16 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)btnTagSet).Appearance;
				object? obj17 = colorConverter.ConvertFromString("233, 235, 240");
				appearance2.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				ComboBox obj18 = cboPrintfile;
				object? obj19 = colorConverter.ConvertFromString("233, 235, 240");
				obj18.BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj20 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj21 = lblBook;
				object? obj22 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj21).ForeColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj23 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj24 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj25 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj26 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AppearanceObject appearance3 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj27 = colorConverter.ConvertFromString("238, 244, 236");
				appearance3.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AppearanceObject appearance4 = ((BaseStyleControl)btnTagSet).Appearance;
				object? obj28 = colorConverter.ConvertFromString("Cornsilk");
				appearance4.BackColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				ComboBox obj29 = cboPrintfile;
				object? obj30 = colorConverter.ConvertFromString("Cornsilk");
				obj29.BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				Font font = ((Control)tVchNo).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is CheckBox || val3 is SimpleButton) && ((Operators.CompareString(val3.Name, "lblBook", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_IDTL", false) != 0)))
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
			BtnCancel_Click(BtnCancel, new EventArgs());
			if (Operators.CompareString(DC_Main.MsQrCodeGen, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT * FROM PRINT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_TYPE = 'QR' ORDER BY PRINT_FILE";
			}
			else
			{
				DC_Main.RsQry = "SELECT * FROM PRINT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_TYPE = 'TAG' ORDER BY PRINT_FILE";
			}
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			string text = "";
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboPrintfile.Items.Add((object)"");
				int num4 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
				{
					cboPrintfile.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["PRINT_SET_A"], (object)""), (object)"Y", false))
					{
						text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
					}
					DC_Main.X++;
				}
				cboPrintfile.SelectedIndex = 0;
			}
			else
			{
				cboPrintfile.Items.Add((object)"");
			}
			cboPrintfile.Text = text;
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM340NEKU", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM285NEKU", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM407NEKU", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK191NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK052NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM328NEKU", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM427NEHP", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM606NEKU", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK113NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK250NEPH", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK253NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK106NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "AK011NEAK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM287NEKU", false) == 0))
			{
				((Control)btnRfid).Visible = true;
				((Control)lblPrintType).Visible = true;
				((Control)cboPrintType).Visible = true;
			}
			cboItemTyp.Items.Add((object)"Gold");
			cboItemTyp.Items.Add((object)"Silver");
			cboItemTyp.Items.Add((object)"Diamond");
			cboItemTyp.Items.Add((object)"Real Stone");
			cboItemTyp.Items.Add((object)"Emitation");
			cboItemTyp.Items.Add((object)"Other");
			cboItemTyp.Items.Add((object)"Platinum");
			if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
			{
				cboItemTyp.SelectedIndex = 0;
			}
			else
			{
				cboItemTyp.SelectedIndex = 1;
			}
			cboPrintType.Items.Add((object)"Gold");
			cboPrintType.Items.Add((object)"Silver");
			cboPrintType.Items.Add((object)"Diamond");
			cboPrintType.Items.Add((object)"Platinum");
			cboPrintType.Items.Add((object)"Emitation");
			cboPrintType.Items.Add((object)"RealStone");
			cboPrintType.Items.Add((object)"Other");
			if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
			{
				cboPrintType.SelectedIndex = 0;
			}
			else
			{
				cboPrintType.SelectedIndex = 1;
			}
			CurActCtrl = (Control)(object)tBookCode;
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
		lblItem.Text = "";
		MsVchSrno = "";
		((Control)BtnSave).Enabled = false;
		chkHmIdUpdate.Checked = false;
		OldValTot = 0.0;
		NewValTot = 0.0;
		((Control)TEXT_ENTRY).Visible = false;
		MSG_CLEAR();
		EntryMode = "A";
		((Control)BtnSave).Enabled = true;
		((Control)tVchNo).Focus();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void TR_TAG_CAN_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_TAG_CAN_KeyPress(object sender, KeyPressEventArgs e)
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
		if (!chkHmIdUpdate.Checked)
		{
			return;
		}
		checked
		{
			int num = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				if ((Operators.CompareString(MSG[DC_Main.i, 2], "", false) != 0) & ((Operators.CompareString(MSG[DC_Main.i, 10], "", false) != 0) | (Conversion.Val(MSG[DC_Main.i, 32]) + Conversion.Val(MSG[DC_Main.i, 30]) != 0.0)))
				{
					DC_Main.RsQry = ("UPDATE BAR_DETL SET HM_ID = '" + MSG[DC_Main.i, 10] + "',HM_ID_WT = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 11])) + ",  HM_ID2 = '" + MSG[DC_Main.i, 12] + "',HM_ID2_WT = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 13])) + ",  HM_ID3 = '" + MSG[DC_Main.i, 14] + "',HM_ID3_WT = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 15])) + ",  HM_ID4 = '" + MSG[DC_Main.i, 16] + "',HM_ID4_WT = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 17])) + ",  LBR_PRC = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 32])) + ",  ITM_MRP = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 30])) + ",  LBR_RATE = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 27])) + "  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO = '" + MSG[DC_Main.i, 2] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 44]))) ?? "";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.i++;
			}
			HmidUpdate = true;
			BtnPrint_Click(MSG, new EventArgs());
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
	}

	private void TR_TAG_CAN_KeyDown(object sender, KeyEventArgs e)
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
				((Control)BtnPrint).Focus();
			}
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected O, but got Unknown
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (chkHmIdUpdate.Checked & !HmidUpdate)
		{
			Interaction.MsgBox((object)"Please First Update Hmid Data and Then print", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
			return;
		}
		DC_Main.ExeQuteDc("DELETE FROM TAG_PRINT_DATA");
		DC_Main.ExeQuteDc("DELETE FROM IMAGE_DATA");
		checked
		{
			int num = (int)Math.Round(Conversion.Val(nLableSkip.Text));
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				DC_Main.RsQry = "INSERT INTO TAG_PRINT_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,IT_CODE,VCH_SRNO)   VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','" + tBookCode.Text + "','00000'," + Conversions.ToString(DC_Main.i) + ",'00',0)";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.i++;
			}
			int num2 = MSG.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num2)
			{
				if ((Operators.CompareString(MSG[DC_Main.M, 2], "", false) != 0) & (Operators.CompareString(MSG[DC_Main.M, 1], "Y", false) == 0))
				{
					DC_Main.RsQry = ("INSERT INTO TAG_PRINT_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,  AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,VCH_SRNO,RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,ITM_COLOR,LBR_CODE,ITM_STYLE)  SELECT '" + DC_Main.MCo_code + "',LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,  AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,VCH_SRNO,RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,ITM_COLOR,LBR_CODE,ITM_STYLE  FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + MSG[DC_Main.M, 2] + "' and VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.M, 44]))) ?? "";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					if (Operators.CompareString(DC_Main.MsQrCodeGen, "Y", false) == 0)
					{
						QRCodeGenerator val = new QRCodeGenerator();
						QRCodeData val2 = val.CreateQrCode(MSG[DC_Main.M, 2], (ECCLevel)2, false, false, (EciMode)0, -1);
						QRCode val3 = new QRCode(val2);
						PictureBox1.Image = (Image)(object)val3.GetGraphic(3);
						MemoryStream memoryStream = new MemoryStream();
						PictureBox1.Image.Save((Stream)memoryStream, ImageFormat.Jpeg);
						byte[] value = memoryStream.ToArray();
						DC_Main.RsQry = "SELECT * FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + MSG[DC_Main.M, 2] + "' AND VCH_SRNO = " + MSG[DC_Main.M, 44] + " ";
						DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.MsInsertData();
						DataRow dataRow = dataTable.NewRow();
						dataRow["CO_CODE"] = DC_Main.MCo_code;
						dataRow["LC_CODE"] = DC_Main.MLc_code;
						dataRow["SR_NO"] = DC_Main.M;
						dataRow["TAG_NO"] = MSG[DC_Main.M, 2];
						dataRow["VCH_SRNO"] = Conversion.Val(MSG[DC_Main.M, 44]);
						dataRow["TAG_IMAGE"] = value;
						dataTable.Rows.Add(dataRow);
						((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
						dataTable.Clear();
					}
				}
				DC_Main.M++;
			}
			DC_Main.RsQry = "SELECT * FROM TAG_PRINT_DATA";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			((Form)MyProject.Forms.MS_PRINT).ShowDialog();
			if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)
			{
				return;
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsCustMail = "";
				DC_Main.MsCustWappNo = "";
				string text = cboPrintfile.Text;
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptName = text;
				DC_Main.RptFormula = "{TAG_PRINT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "'";
				UT_REPORT uT_REPORT = new UT_REPORT();
				((Control)uT_REPORT).Show();
				((Control)uT_REPORT).Focus();
				return;
			}
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + cboPrintfile.Text + ".RPT";
			Cr.SelectionFormula = "{TAG_PRINT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' ";
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
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
			DC_Main.MsPrintStatus = false;
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void TR_TAG_CAN_Activated(object sender, EventArgs e)
	{
		((ContainerControl)this).ActiveControl = CurActCtrl;
		CurActCtrl.Focus();
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL FROM BAR_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + tBookCode.Text + "' GROUP BY A.VCH_NO,A.VCH_DATE,B.AC_NAME ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[4];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				CLEAR_DATA();
				tVchNo.Text = DC_Main.ColValue[0];
				((Control)tVchNo).Focus();
			}
			else
			{
				((Control)tVchNo).Focus();
			}
		}
	}

	private void MSG_RowColChange(object sender, EventArgs e)
	{
		if (MSG.Row != 0 && ((MsgOldRow != MSG.Row) & !MsgClear))
		{
			MsgOldRow = MSG.Row;
			lblItem.Text = MSG[MSG.Row, 56] + " : It Name";
		}
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
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 112)
		{
			BtnF1_Click(BtnF1, new EventArgs());
		}
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tVchNo.Text, "", false) == 0)
		{
			MSG.Col = 2;
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
			return;
		}
		DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + tBookCode.Text + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
		RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (RsDetl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL FROM BAR_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + tBookCode.Text + "' GROUP BY A.VCH_NO,A.VCH_DATE,B.AC_NAME ORDER BY A.VCH_NO";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[4];
			DC_Main.ColWidth[0] = 100.0;
			DC_Main.ColWidth[1] = 120.0;
			DC_Main.ColWidth[2] = 300.0;
			DC_Main.HelpSelect = 0;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tVchNo.Text = DC_Main.ColValue[0];
				((Control)tVchNo).Focus();
			}
			return;
		}
		checked
		{
			DC_Main.i = MSG.Rows - 2;
			DC_Main.M = 0;
			((Control)TEXT_ENTRY).Visible = false;
			AxMSFlexGrid mSG = MSG;
			while (DC_Main.M < RsDetl.Rows.Count)
			{
				mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
				mSG[DC_Main.i + 1, 1] = "Y";
				mSG[DC_Main.i + 1, 51] = Conversions.ToString(RsDetl.Rows[DC_Main.M]["OLD_SRNO"]);
				mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.M]["IT_CODE"], (object)""));
				mSG[DC_Main.i + 1, 56] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.M]["IT_NAME"], (object)""));
				mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.M]["TAG_NO"], (object)""));
				mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.M]["TBL_CODE"], (object)""));
				mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.M]["DESIGN_NO"], (object)""));
				mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.M]["ITM_SIZE"], (object)""));
				mSG[DC_Main.i + 1, 25] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.M]["LBR_CODE"], (object)""));
				mSG[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["BAG_WT"])), "0.000");
				mSG[DC_Main.i + 1, 8] = Conversions.ToString(RsDetl.Rows[DC_Main.M]["ITM_PCS"]);
				mSG[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["ITM_GWT"])), "0.000");
				mSG[DC_Main.i + 1, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["ITM_GWT"])), "0.000");
				mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["ITM_OTH_WT"])), "0.000");
				mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["ITM_NWT"])), "0.000");
				mSG[DC_Main.i + 1, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["ITM_NWT"])), "0.000");
				mSG[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["ITM_GHT_WT"])), "0.000");
				mSG[DC_Main.i + 1, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["ITM_GHT_WT"])), "0.000");
				mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["ITM_TOUCH"])), "0.00");
				mSG[DC_Main.i + 1, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["ITM_TOUCH"])), "0.00");
				mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["ITM_WEST_PRC"])), "0.00");
				mSG[DC_Main.i + 1, 65] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["ITM_WEST_PRC"])), "0.00");
				mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["ITM_FINE"])), "0.000");
				mSG[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["KR_NET_WT"])), "0.000");
				mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["KR_TOUCH"])), "0.00");
				mSG[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["KR_WEST_PRC"])), "0.00");
				mSG[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["KR_FINE"])), "0.000");
				mSG[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["LBR_PRC"])), "0.00");
				mSG[DC_Main.i + 1, 26] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.M]["LBR_TYPE"], (object)""));
				mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["LBR_RATE"])), "0.00");
				mSG[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["LBR_AMT"])), "0.00");
				mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["OTH_AMT"])), "0.00");
				mSG[DC_Main.i + 1, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["ITM_RATE"])), "0.00");
				mSG[DC_Main.i + 1, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["ITM_AMT"])), "0.00");
				mSG[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.M]["ITM_MRP"])), "0.00");
				mSG[DC_Main.i + 1, 31] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.M]["KR_NAME"], (object)""));
				mSG[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.M]["RATE_TYPE"], (object)""));
				mSG[DC_Main.i + 1, 53] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.M]["IT_TYPE"], (object)""));
				mSG[DC_Main.i + 1, 55] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.M]["PR_CODE"], (object)""));
				mSG[DC_Main.i + 1, 44] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.M]["VCH_SRNO"], (object)""));
				mSG[DC_Main.i + 1, 69] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.M]["SL_TYPE"], (object)""));
				mSG[DC_Main.i + 1, 59] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.M]["PR_CODE"], (object)""));
				mSG[DC_Main.i + 1, 70] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.M]["STK_DATE"], (object)""));
				mSG[DC_Main.i + 1, 57] = "E";
				mSG.Rows += 1;
				DC_Main.i++;
				DC_Main.M++;
			}
			mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
			tVchNo.Text = "";
			((Control)tVchNo).Focus();
			mSG = null;
		}
	}

	private void TR_TAG_CAN_KeyUp(object sender, KeyEventArgs e)
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

	private void MSG_Enter(object sender, EventArgs e)
	{
	}

	private void TR_TAG_CAN_Closed(object sender, EventArgs e)
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

	private void tBookCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + tBookCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT B.BOOK_NAME As BookNameL,A.CO_BOOK As BookL FROM BAR_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY B.BOOK_NAME,A.CO_BOOK ORDER BY B.BOOK_NAME";
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
						tBookCode.Text = DC_Main.ColValue[1];
						tBookName.Text = DC_Main.ColValue[0];
					}
					((Control)tBookCode).Focus();
				}
			}
			else
			{
				tBookName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["BOOK_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
		else
		{
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

	private void tGrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND GR_CODE = '" + tGrCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.GR_NAME As GrNameL,A.GR_CODE as GrCodeL,A.GR_TYPE as TypeL,A.TRAD_TYPE As TradTypeL FROM GROUP_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" GROUP BY A.GR_NAME,A.GR_CODE,A.GR_TYPE,A.TRAD_TYPE ORDER BY A.GR_NAME"));
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[5];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[2] = 100.0;
			DC_Main.ColWidth[3] = 100.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					tGrCode.Text = DC_Main.ColValue[1];
					tGrName.Text = DC_Main.ColValue[0];
				}
				((TextBoxBase)tGrCode).SelectAll();
			}
		}
		else
		{
			tGrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GR_NAME"], (object)""));
			((Control)tPrCode).Focus();
		}
	}

	private void tPrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND PR_CODE = '" + tPrCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.PR_NAME As PrNameL,A.PR_CODE as PrCodeL FROM PRODUCT_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.PR_CODE = B.PR_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" GROUP BY A.PR_NAME,A.PR_CODE ORDER BY PR_NAME"));
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[3];
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					tPrCode.Text = DC_Main.ColValue[1];
					tPrName.Text = DC_Main.ColValue[0];
				}
				((TextBoxBase)tPrCode).SelectAll();
			}
		}
		else
		{
			tPrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_NAME"], (object)""));
			MSG_VCH_FILL();
		}
	}

	private void MSG_VCH_FILL()
	{
		MSG_CLEAR();
		DC_Main.RsQry = "SELECT C.VCH_TYPE As VchTyp,C.VCH_NO VchNo,C.STK_DATE As StkDate,A.TAG_NO As TagNo,A.IT_CODE As ItCode,B.IT_NAME,C.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_SIZE As Size,C.ITM_PCS as Pcs,C.ITM_GWT As Grwt,C.ITM_NWT AS NetWt,C.LBR_AMT LbrAmt,C.OTH_AMT OthAmt,  C.ITM_MRP As Mrp,C.KR_NAME As KrName,C.CO_BOOK As Book,C.BOOK_NAME As BookName,C.AC_CODE As AcCode,C.VCH_SRNO As TagId,C.BAG_WT,  C.ITM_GHT_WT,C.ITM_TOUCH,C.ITM_WEST_PRC,C.ITM_FINE,C.LBR_PRC,C.LBR_TYPE,C.LBR_RATE,C.LBR_CODE  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.TAG_NO <> '' AND C.STK_DATE <= '" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "'";
		if (Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
		}
		if (Operators.CompareString(tGrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
		}
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		DC_Main.RsQry += " GROUP BY C.VCH_TYPE,C.VCH_NO,C.STK_DATE,A.TAG_NO,A.IT_CODE,B.IT_NAME,C.TBL_CODE,C.DESIGN_NO,C.ITM_SIZE,C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,C.LBR_AMT,C.OTH_AMT,  C.ITM_MRP,C.KR_NAME,C.CO_BOOK,C.BOOK_NAME,C.AC_CODE,C.VCH_SRNO,C.BAG_WT,  C.ITM_GHT_WT,C.ITM_TOUCH,C.ITM_WEST_PRC,C.ITM_FINE,C.LBR_PRC,C.LBR_TYPE,C.LBR_RATE,C.LBR_CODE ";
		DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.IT_CODE,A.TAG_NO";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.i = 0;
		DC_Main.M = 0;
		AxMSFlexGrid mSG = MSG;
		checked
		{
			while (DC_Main.M < dataTable.Rows.Count)
			{
				mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
				mSG[DC_Main.i + 1, 1] = "Y";
				mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.M]["ItCode"], (object)""));
				mSG[DC_Main.i + 1, 56] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.M]["IT_NAME"], (object)""));
				mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.M]["TagNo"], (object)""));
				mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.M]["Counter"], (object)""));
				mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.M]["Design"], (object)""));
				mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.M]["Size"], (object)""));
				mSG[DC_Main.i + 1, 25] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.M]["LBR_CODE"], (object)""));
				mSG[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["BAG_WT"])), "0.000");
				mSG[DC_Main.i + 1, 8] = Conversions.ToString(dataTable.Rows[DC_Main.M]["Pcs"]);
				mSG[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["Grwt"])), "0.000");
				mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["NetWt"])), "0.000");
				mSG[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["ITM_GHT_WT"])), "0.000");
				mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["ITM_TOUCH"])), "0.00");
				mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["ITM_WEST_PRC"])), "0.00");
				mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["ITM_FINE"])), "0.000");
				mSG[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["LBR_PRC"])), "0.00");
				mSG[DC_Main.i + 1, 26] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.M]["LBR_TYPE"], (object)""));
				mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["LBR_RATE"])), "0.00");
				mSG[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["LbrAmt"])), "0.00");
				mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["OthAmt"])), "0.00");
				mSG[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["Mrp"])), "0.00");
				mSG[DC_Main.i + 1, 31] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.M]["KrName"], (object)""));
				mSG[DC_Main.i + 1, 44] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.M]["TagId"], (object)""));
				mSG.Rows += 1;
				DC_Main.i++;
				DC_Main.M++;
			}
			mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
			((Control)tPrCode).Focus();
			mSG = null;
		}
	}

	private void BtnTagSet_Click(object sender, EventArgs e)
	{
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.MsQrCodeGen, "Y", false) == 0)
		{
			DC_Main.RsQry = "UPDATE PRINT_MAST SET PRINT_SET_A = 'N' WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_TYPE = 'QR' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE PRINT_MAST SET PRINT_SET_A = 'Y' WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_FILE = '" + cboPrintfile.Text + "' AND PRINT_TYPE = 'QR'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.RsQry = "UPDATE PRINT_MAST SET PRINT_SET_A = 'N' WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_TYPE = 'TAG' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE PRINT_MAST SET PRINT_SET_A = 'Y' WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_FILE = '" + cboPrintfile.Text + "' AND PRINT_TYPE = 'TAG'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		Interaction.MsgBox((object)"Tag Print Report Default Set", (MsgBoxStyle)0, (object)null);
	}

	private void chkHmIdUpdate_CheckedChanged(object sender, EventArgs e)
	{
		((Control)BtnSave).Enabled = true;
		MSG_CLEAR();
		MSG.Col = 2;
		MSG.Row = 1;
		MSG[1, 1] = "Y";
		MSG_EnterCell(MSG, new EventArgs());
		((Control)TEXT_ENTRY).Focus();
	}

	private void MordenJwTag()
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		string text4 = "Gold";
		checked
		{
			int num = MSG.Rows - 1;
			string text22 = default(string);
			for (int i = 1; i <= num; i++)
			{
				if (!((Operators.CompareString(MSG[i, 2], "", false) != 0) & (Operators.CompareString(MSG[i, 1], "Y", false) == 0)))
				{
					continue;
				}
				DC_Main.RsQry = "SELECT GR_CODE,IT_TYPE FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + MSG[i, 3] + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				text2 = "";
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					text2 = Conversions.ToString(DC_Main.Tbl.Rows[0]["GR_CODE"]);
				}
				if (cboPrintType.SelectedIndex == 0)
				{
					text4 = "Gold";
				}
				else if (cboPrintType.SelectedIndex == 1)
				{
					text4 = "Silver";
				}
				else if (cboPrintType.SelectedIndex == 2)
				{
					text4 = "Diamond";
				}
				else if (cboPrintType.SelectedIndex == 3)
				{
					text4 = "Platinum";
				}
				else if (cboPrintType.SelectedIndex == 4)
				{
					text4 = "Emitation";
				}
				else if (cboPrintType.SelectedIndex == 5)
				{
					text4 = "RealStone";
				}
				else if (cboPrintType.SelectedIndex == 6)
				{
					text4 = "Other";
				}
				int num2 = 0;
				if (cboPrintType.SelectedIndex == 2)
				{
					DC_Main.RsQry = ("SELECT IT_CODE,DM_ORIGIN,DM_COLOR,IT_GWT,IT_PCS,DM_SFNO,DM_REMARK FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO = '" + MSG[i, 2] + "' AND VCH_SRNO = " + MSG[i, 44]) ?? "";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					text3 = "";
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						if (Operators.CompareString(DC_Main.SSRegSrNo, "VK191NEVK", false) == 0)
						{
							int num3 = DC_Main.Tbl.Rows.Count - 1;
							DC_Main.M = 0;
							while (DC_Main.M <= num3)
							{
								text3 = Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_REMARK"]), (object)"")));
								DC_Main.M++;
							}
							num2 = DC_Main.M;
							int m = num2;
							DC_Main.M = m;
							while (DC_Main.M <= 9)
							{
								text3 += ",";
								DC_Main.M++;
							}
						}
						else if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM427NEHP", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM606NEKU", false) == 0))
						{
							int num4 = DC_Main.Tbl.Rows.Count - 1;
							DC_Main.M = 0;
							while (DC_Main.M <= num4)
							{
								text3 = Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)" / "), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)" / "), DC_Main.Tbl.Rows[DC_Main.M]["IT_GWT"]), (object)"")));
								DC_Main.M++;
							}
							num2 = DC_Main.M;
							int m2 = num2;
							DC_Main.M = m2;
							while (DC_Main.M <= 9)
							{
								text3 += ",";
								DC_Main.M++;
							}
						}
						else
						{
							if (DC_Main.Tbl.Rows.Count > 2)
							{
								DC_Main.M = 0;
								do
								{
									text3 = ((!((Operators.CompareString(DC_Main.SSRegSrNo, "HM407NEKU", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM328NEKU", false) == 0))) ? Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)""), DC_Main.Tbl.Rows[DC_Main.M]["DM_ORIGIN"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_COLOR"]), (object)","), DC_Main.Tbl.Rows[DC_Main.M]["DM_SFNO"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_REMARK"]), (object)","), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)"/"), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["IT_GWT"], (object)"")), "0.00")), (object)""))) : Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)""), DC_Main.Tbl.Rows[DC_Main.M]["DM_ORIGIN"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_COLOR"]), (object)","), DC_Main.Tbl.Rows[DC_Main.M]["DM_SFNO"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_REMARK"]), (object)","), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)"/"), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["IT_GWT"], (object)"")), "0.00")), (object)""))));
									num2 += 3;
									DC_Main.M++;
								}
								while (DC_Main.M <= 1);
							}
							else
							{
								int num5 = DC_Main.Tbl.Rows.Count - 1;
								DC_Main.M = 0;
								while (DC_Main.M <= num5)
								{
									text3 = ((Operators.CompareString(DC_Main.SSRegSrNo, "HM407NEKU", false) != 0) ? Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_ORIGIN"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_COLOR"]), (object)","), DC_Main.Tbl.Rows[DC_Main.M]["DM_SFNO"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_REMARK"]), (object)","), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)"/"), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["IT_GWT"], (object)"")), "0.00")), (object)""))) : Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_ORIGIN"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_COLOR"]), (object)","), DC_Main.Tbl.Rows[DC_Main.M]["DM_SFNO"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_REMARK"]), (object)","), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)"/"), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["IT_GWT"], (object)"")), "0.00")))));
									num2 += 3;
									DC_Main.M++;
								}
							}
							if (num2 > DC_Main.M)
							{
								int m3 = num2;
								DC_Main.M = m3;
								while (DC_Main.M <= 9)
								{
									text3 += ",";
									DC_Main.M++;
								}
							}
						}
						text3 += ",";
						if (Operators.CompareString(text3, "", false) != 0)
						{
							text3 = Strings.Mid(text3, 1, Strings.Len(text3) - 1);
						}
					}
					else
					{
						text3 = ",,,,,,,,,,";
					}
				}
				else
				{
					DC_Main.RsQry = ("SELECT IT_CODE,IT_PCS,IT_GWT,IT_NET_AMT,DM_COLOR,DM_SFNO FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO = '" + MSG[i, 2] + "' AND VCH_SRNO = " + MSG[i, 44]) ?? "";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					text3 = "";
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						int num6 = DC_Main.Tbl.Rows.Count - 1;
						DC_Main.M = 0;
						while (DC_Main.M <= num6)
						{
							text3 = ((Operators.CompareString(DC_Main.SSRegSrNo, "HM407NEKU", false) != 0) ? ((Operators.CompareString(DC_Main.SSRegSrNo, "HM606NEKU", false) != 0) ? Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)"/"), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["IT_GWT"], (object)"")), "0.00")), (object)"/"), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["IT_NET_AMT"])), "0")), (object)""))) : Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_COLOR"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_SFNO"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)"/"), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["IT_GWT"], (object)""))), (object)"")))) : Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)"/"), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["IT_GWT"], (object)"")), "0.00")), (object)"/"), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["IT_NET_AMT"])), "0")), (object)""))));
							DC_Main.M++;
						}
						num2 = DC_Main.M;
						int m4 = num2;
						DC_Main.M = m4;
						while (DC_Main.M <= 10)
						{
							text3 += ",";
							DC_Main.M++;
						}
						if (Operators.CompareString(text3, "", false) != 0)
						{
							text3 = Strings.Mid(text3, 1, Strings.Len(text3) - 1);
						}
					}
					else
					{
						text3 = ",,,,,,,,,,";
					}
				}
				string text5 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 8]) == 0.0, (object)"", (object)MSG[i, 8]));
				string text6 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 9]) == 0.0, (object)"", (object)MSG[i, 9]));
				string text7 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 18]) == 0.0, (object)"", (object)MSG[i, 18]));
				string text8 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 19]) == 0.0, (object)"", (object)MSG[i, 19]));
				string text9 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 20]) == 0.0, (object)"", (object)MSG[i, 20]));
				string text10 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 21]) == 0.0, (object)"", (object)MSG[i, 21]));
				string text11 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 22]) == 0.0, (object)"", (object)MSG[i, 22]));
				string text12 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 23]) == 0.0, (object)"", (object)MSG[i, 23]));
				string text13 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 24]) == 0.0, (object)"", (object)MSG[i, 24]));
				string text14 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 32]) == 0.0, (object)"", (object)MSG[i, 32]));
				string text15 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 27]) == 0.0, (object)"", (object)MSG[i, 27]));
				string text16 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 28]) == 0.0, (object)"", (object)MSG[i, 28]));
				string text17 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 29]) == 0.0, (object)"", (object)MSG[i, 29]));
				string text18 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 30]) == 0.0, (object)"", (object)Strings.Format((object)Conversion.Val(MSG[i, 30]), "0")));
				string text19 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 43]) == 0.0, (object)"", (object)Strings.Format((object)Conversion.Val(MSG[i, 43]), "0")));
				if (Operators.CompareString(DC_Main.SSRegSrNo, "HM285NEKU", false) == 0)
				{
					text11 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 37]) != 0.0, (object)Strings.Format((object)Conversion.Val(MSG[i, 37]), "0.00"), (object)""));
					text12 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 38]) != 0.0, (object)Strings.Format((object)Conversion.Val(MSG[i, 38]), "0.00"), (object)""));
					text13 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 39]) != 0.0, (object)Strings.Format((object)Conversion.Val(MSG[i, 39]), "0.00"), (object)""));
				}
				if (Operators.CompareString(DC_Main.SSRegSrNo, "HM407NEKU", false) == 0)
				{
					text6 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 9]) != 0.0, (object)Strings.Format((object)Conversion.Val(MSG[i, 9]), "0.00"), (object)""));
					text7 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 18]) != 0.0, (object)Strings.Format((object)Conversion.Val(MSG[i, 18]), "0.00"), (object)""));
					text8 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 19]) != 0.0, (object)Strings.Format((object)Conversion.Val(MSG[i, 19]), "0.00"), (object)""));
					text13 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 24]) != 0.0, (object)Strings.Format((object)Conversion.Val(MSG[i, 24]), "0.00"), (object)""));
				}
				if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
				{
					string text20 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 37]) != 0.0, (object)Strings.Format((object)Conversion.Val(MSG[i, 37]), "0.00"), (object)""));
					string text21 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 38] ?? "") != 0.0, (object)Strings.Format((object)Conversion.Val(MSG[i, 38]), "0.00"), (object)""));
					DC_Main.RsQry = "SELECT ADD_TOUCH FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND GR_CODE = '" + text2 + "'";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					text22 = Conversions.ToString(0);
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						double num7 = Conversion.Val(text20) + Conversion.Val(text21);
						object Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["ADD_TOUCH"], (object)"");
						text22 = Conversions.ToString(Math.Round(num7 + DC_Main.Fnv(ref Value), 0));
					}
				}
				text = text + MSG[i, 2] + ",";
				text = text + text2 + ",";
				text = text + MSG[i, 3] + ",";
				text = text + MSG[i, 56] + ",";
				text = text + MSG[i, 5] + ",";
				text = text + MSG[i, 6] + ",";
				if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK191NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM427NEHP", false) == 0))
				{
					if (Operators.CompareString(MSG[i, 69], "G", false) == 0)
					{
						text = text + text6 + ",";
						text += ",";
						text += ",";
					}
					else
					{
						text = text + text6 + ",";
						text = text + text7 + ",";
						text = text + text8 + ",";
					}
				}
				else
				{
					text = text + text6 + ",";
					text = text + text7 + ",";
					text = text + text8 + ",";
				}
				text = text + text9 + ",";
				text = text + text10 + ",";
				text = text + text11 + ",";
				text = text + text12 + ",";
				text = text + text13 + ",";
				text = (((Operators.CompareString(DC_Main.SSRegSrNo, "VK191NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM427NEHP", false) == 0)) ? (text + MSG[i, 69] + ",") : ((Operators.CompareString(DC_Main.SSRegSrNo, "AK011NEAK", false) != 0) ? (text + MSG[i, 25] + ",") : (text + text5 + ",")));
				text = text + text14 + ",";
				text = text + text15 + ",";
				text = text + text16 + ",";
				text = text + text17 + ",";
				text = text + text18 + ",";
				text = text + text19 + ",";
				text = text + MSG[i, 10] + ",";
				text = text + MSG[i, 12] + ",";
				if (Operators.CompareString(DC_Main.SSRegSrNo, "HM427NEHP", false) == 0)
				{
					text = text + MSG[i, 4] + ",";
					text = text + Strings.Mid(MSG[i, 70], 7, 4) + Strings.Mid(MSG[i, 70], 4, 2) + Strings.Mid(MSG[i, 70], 1, 2) + ",";
				}
				else
				{
					text = text + MSG[i, 14] + ",";
					text = ((Operators.CompareString(DC_Main.SSRegSrNo, "HM606NEKU", false) == 0) ? (text + MSG[i, 4] + ",") : ((Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) != 0) ? (text + MSG[i, 16] + ",") : (text + "00" + Strings.Mid(MSG[i, 70], 4, 2) + Strings.Mid(MSG[i, 70], 1, 2) + Strings.Mid(MSG[i, 70], 9, 2) + "09" + text22 + "9" + MSG[i, 31] + ",")));
				}
				text += MSG[i, 31] ?? "";
				text = text + text3 + ",";
				text = text + text4 + ";";
			}
			text = text ?? "";
			string text23 = "C:\\Tagit";
			if (!Directory.Exists(text23))
			{
				Directory.CreateDirectory(text23);
			}
			string text24 = "GoldTag1";
			File.WriteAllText(text23 + "\\" + text24 + ".txt", text);
			string text25 = "";
			switch (DC_Main.SSRegSrNo)
			{
			case "HM340NEKU":
				text25 = "Rushab";
				break;
			case "VK142NEVK":
				text25 = "Radhika";
				break;
			case "HM285NEKU":
				text25 = "Madina";
				break;
			case "HM407NEKU":
				text25 = "Modern";
				break;
			case "VK191NEVK":
				text25 = "Devi Pavitra";
				break;
			case "VK052NEVK":
				text25 = "HANUMAN JEWELLERS";
				break;
			case "HM328NEKU":
				text25 = "Swapnil";
				break;
			case "HM427NEHP":
				text25 = "Devi Pavitra Hyd";
				break;
			case "HM606NEKU":
				text25 = "SRI ANDHRA";
				break;
			case "VK113NEVK":
				text25 = "VAIJNATH";
				break;
			case "VK250NEPH":
				text25 = "PANCHRATNA";
				break;
			case "VK253NEVK":
				text25 = "KAJRIJEW";
				break;
			case "VK106NEVK":
				text25 = "MAHALAXMIJEW";
				break;
			case "VK289NEPH":
				text25 = "MUKUTASRI";
				break;
			case "AK011NEAK":
				text25 = "MAYURA";
				break;
			case "HM287NEKU":
				text25 = "ABHUSHAN";
				break;
			}
			string text26 = text;
			bool flag = tagitObject.PrintTags(text26, text25);
		}
	}

	private void BtnRfid_Click(object sender, EventArgs e)
	{
		switch (DC_Main.SSRegSrNo)
		{
		case "HM407NEKU":
		case "HM285NEKU":
		case "HM340NEKU":
		case "VK191NEVK":
		case "VK142NEVK":
		case "VK052NEVK":
		case "HM328NEKU":
		case "HM427NEHP":
		case "HM606NEKU":
		case "VK113NEVK":
		case "VK250NEPH":
		case "VK253NEVK":
		case "VK106NEVK":
		case "VK289NEPH":
		case "AK011NEAK":
		case "HM287NEKU":
			MordenJwTag();
			return;
		}
		string text = "\"";
		string text2 = "";
		string text3 = "";
		string text4 = "Gold";
		checked
		{
			int num = MSG.Rows - 1;
			for (int i = 1; i <= num; i++)
			{
				if (!((Operators.CompareString(MSG[i, 2], "", false) != 0) & (Operators.CompareString(MSG[i, 1], "Y", false) == 0)))
				{
					continue;
				}
				DC_Main.RsQry = "SELECT GR_CODE,IT_TYPE FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + MSG[i, 3] + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				text2 = "";
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					text2 = Conversions.ToString(DC_Main.Tbl.Rows[0]["GR_CODE"]);
				}
				if (cboPrintType.SelectedIndex == 0)
				{
					text4 = "Gold";
				}
				else if (cboPrintType.SelectedIndex == 1)
				{
					text4 = "Silver";
				}
				else if (cboPrintType.SelectedIndex == 2)
				{
					text4 = "Diamond";
				}
				else if (cboPrintType.SelectedIndex == 3)
				{
					text4 = "Platinum";
				}
				else if (cboPrintType.SelectedIndex == 4)
				{
					text4 = "Emitation";
				}
				else if (cboPrintType.SelectedIndex == 5)
				{
					text4 = "RealStone";
				}
				else if (cboPrintType.SelectedIndex == 6)
				{
					text4 = "Other";
				}
				DC_Main.RsQry = ("SELECT IT_CODE,IT_PCS,IT_CON_WT,IT_NET_AMT FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO = '" + MSG[i, 2] + "' AND VCH_SRNO = " + MSG[i, 44]) ?? "";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				text3 = "";
				int num2 = 0;
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					if (DC_Main.Tbl.Rows.Count > 5)
					{
						DC_Main.M = 0;
						do
						{
							text3 = Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["IT_CON_WT"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["IT_NET_AMT"]), (object)"")));
							DC_Main.M++;
						}
						while (DC_Main.M <= 4);
					}
					else
					{
						int num3 = DC_Main.Tbl.Rows.Count - 1;
						DC_Main.M = 0;
						while (DC_Main.M <= num3)
						{
							text3 = Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["IT_CON_WT"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["IT_NET_AMT"]), (object)"")));
							DC_Main.M++;
						}
					}
					num2 = DC_Main.M;
					int m = num2;
					DC_Main.M = m;
					while (DC_Main.M <= 6)
					{
						text3 += ",";
						DC_Main.M++;
					}
					if (Operators.CompareString(text3, "", false) != 0)
					{
						text3 = Strings.Mid(text3, 1, Strings.Len(text3) - 1);
					}
				}
				else
				{
					text3 = ",,,,,,";
				}
				if ((Operators.CompareString(text4, "Gold", false) == 0) | (Operators.CompareString(text4, "Diamond", false) == 0) | (Operators.CompareString(text4, "Platinum", false) == 0))
				{
					if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)
					{
						text = text + text2 + ",";
						text = text + MSG[i, 2] + ",";
						text = ((Operators.CompareString(MSG[i, 6], "", false) == 0) ? (text + MSG[i, 6] + ",") : (text + "S :" + MSG[i, 6] + ","));
						text = text + MSG[i, 10] + ",";
						text = text + MSG[i, 12] + ",";
						text = text + MSG[i, 14] + ",";
						text = text + MSG[i, 16] + ",";
						text = text + "G :" + MSG[i, 9] + ",";
						text = text + "L :" + MSG[i, 18] + ",";
						text = text + "N :" + MSG[i, 19] + ",";
						text = text + "W :" + MSG[i, 23] + ",";
						text = text + "Lrt :" + MSG[i, 27] + ",";
						text = text + "OAmt :" + MSG[i, 29] + ",";
						text = string.Concat(text, "Kr :" + MSG[i, 31]);
						text = text + text3 + ",";
						text = text + text4 + ";";
						continue;
					}
					text = text + text2 + ",";
					text = text + MSG[i, 2] + ",";
					text = ((Operators.CompareString(MSG[i, 6], "", false) == 0) ? (text + MSG[i, 6] + ",") : (text + "S :" + MSG[i, 6] + ","));
					text = text + MSG[i, 10] + ",";
					text = text + MSG[i, 12] + ",";
					text = text + MSG[i, 14] + ",";
					text = text + MSG[i, 16] + ",";
					text = text + "G :" + MSG[i, 9] + ",";
					text = text + "L :" + MSG[i, 18] + ",";
					text = text + "N :" + MSG[i, 19] + ",";
					if (Operators.CompareString(MSG[i, 25], "", false) != 0)
					{
						text += ",";
						text = text + "Cod :" + MSG[i, 25] + ",";
						text += ",";
					}
					else if (Conversion.Val(MSG[i, 30]) != 0.0)
					{
						text += ",";
						text += ",";
						text = text + "Mrp :" + MSG[i, 30] + ",";
					}
					else
					{
						text += ",";
						text = text + "Lrt :" + MSG[i, 27] + ",";
						text = text + "OAmt :" + MSG[i, 29] + ",";
					}
					text = string.Concat(text, "Kr :" + MSG[i, 31]);
					text = text + text3 + ",";
					text = text + text4 + ";";
				}
				else if (Operators.CompareString(text4, "Silver", false) == 0)
				{
					text3 = ",,,,,,";
					text = text + text2 + ",";
					text = text + MSG[i, 2] + ",";
					text = ((Operators.CompareString(MSG[i, 6], "", false) == 0) ? (text + MSG[i, 6] + ",") : (text + "S :" + MSG[i, 6] + ","));
					text += ",";
					text += ",";
					text += ",";
					text += ",";
					text = text + "G :" + MSG[i, 9] + ",";
					text = text + "L :" + MSG[i, 18] + ",";
					text = text + "N :" + MSG[i, 19] + ",";
					text += ",";
					if (Operators.CompareString(MSG[i, 25], "", false) == 0)
					{
						text = ((Operators.CompareString(MSG[i, 27], "", false) != 0) ? (text + "Lrt :" + MSG[i, 27] + ",") : (text + "LAmt :" + MSG[i, 28] + ","));
						text = ((Conversion.Val(MSG[i, 30]) != 0.0) ? (text + "Mrp :" + MSG[i, 30] + ",") : (text + ","));
					}
					else
					{
						text = text + "Cod :" + MSG[i, 25] + ",";
						text += ",";
					}
					text = string.Concat(text, "Kr :" + MSG[i, 31]);
					text = text + text3 + ",";
					text = text + text4 + ";";
				}
				else
				{
					text3 = ",,,,,,";
					text = text + text2 + ",";
					text = text + MSG[i, 2] + ",";
					text = ((Operators.CompareString(MSG[i, 6], "", false) == 0) ? (text + MSG[i, 6] + ",") : (text + "S :" + MSG[i, 6] + ","));
					text += ",";
					text += ",";
					text += ",";
					text += ",";
					text = text + "G :" + MSG[i, 9] + ",";
					text = text + "L :" + MSG[i, 18] + ",";
					text = text + "N :" + MSG[i, 19] + ",";
					text += ",";
					if (Operators.CompareString(MSG[i, 25], "", false) == 0)
					{
						text = ((Operators.CompareString(MSG[i, 27], "", false) != 0) ? (text + "Lrt :" + MSG[i, 27] + ",") : (text + "LAmt :" + MSG[i, 28] + ","));
						text = ((Conversion.Val(MSG[i, 30]) != 0.0) ? (text + "Mrp :" + MSG[i, 30] + ",") : (text + ","));
					}
					else
					{
						text = text + "Cod :" + MSG[i, 25] + ",";
						text += ",";
					}
					text = string.Concat(text, "Kr :" + MSG[i, 31]);
					text = text + text3 + ",";
					text = text + text4 + ";";
				}
			}
			text += "\"";
			string text5 = "C:\\Tagit";
			if (!Directory.Exists(text5))
			{
				Directory.CreateDirectory(text5);
			}
			string text6 = "GoldTag1";
			File.WriteAllText(text5 + "\\" + text6 + ".txt", text);
			string text7 = "DataCare";
			switch (DC_Main.SSRegSrNo)
			{
			case "HM340NEKU":
				text7 = "Rushab";
				break;
			case "VK142NEVK":
				text7 = "Radhika";
				break;
			case "HM285NEKU":
				text7 = "Madina";
				break;
			case "HM407NEKU":
				text7 = "Modern";
				break;
			}
			string text8 = text;
			bool flag = tagitObject.PrintTags(text8, text7);
		}
	}
}
