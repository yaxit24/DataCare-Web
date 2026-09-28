using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxCrystal;
using AxMSFlexGridLib;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using MSFlexGridLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class MS_DESIGN_BOOK : Form
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
	[AccessedThroughProperty("PicImage")]
	private PictureBox _PicImage;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_IDTL")]
	private AxMSFlexGrid _MSG_IDTL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_IDTL")]
	private TextBox _TEXT_IDTL;

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
	[AccessedThroughProperty("FlowLayoutPanel1")]
	private FlowLayoutPanel _FlowLayoutPanel1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicZoom")]
	private PictureBox _PicZoom;

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
	[AccessedThroughProperty("btnExel")]
	private SimpleButton _btnExel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPrCode")]
	private TextBox _tPrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnExelImport")]
	private SimpleButton _btnExelImport;

	private string UsUPdate;

	private string UsDelete;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private bool WeightPortOpen;

	private bool StkSaleVchDel;

	private string CurTagNo;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private double OldValTot;

	private double NewValTot;

	private string MsVchSrno;

	private string OldTagItm;

	private string TmpEntryMode;

	private DataTable RsDetl;

	private DataTable RsIdtl;

	private DataTable RsImg;

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

	private const int cSrNo = 0;

	private const int cPageNo = 1;

	private const int cDesign = 2;

	private const int cStyle = 3;

	private const int cGrCode = 4;

	private const int cSize = 5;

	private const int cDieNo = 6;

	private const int cPcs = 7;

	private const int cGrWt = 8;

	private const int cOthWt = 9;

	private const int cNetWt = 10;

	private const int cGhtPrc = 11;

	private const int cGhtWt = 12;

	private const int cTouch = 13;

	private const int cWestPrc = 14;

	private const int cFine = 15;

	private const int cLbrPrc = 16;

	private const int cLbrType = 17;

	private const int cLbrRate = 18;

	private const int cLbrAmt = 19;

	private const int cOthAmt = 20;

	private const int cItRate = 21;

	private const int cItAmt = 22;

	private const int cTagCost = 23;

	private const int cPrCost = 24;

	private const int cMargin = 25;

	private const int cMrp = 26;

	private const int cImageTake = 27;

	private const int cKrName = 28;

	private const int cOldSrNo = 29;

	private const int cRateType = 30;

	private const int cItType = 31;

	private const int cItName = 32;

	private const int cEntryMod = 33;

	private const int cOldGrWt = 34;

	private const int cOldNtWt = 35;

	private const int cOldGhatPrc = 36;

	private const int cOldGhatWt = 37;

	private const int cOldTouch = 38;

	private const int cOldWestPrc = 39;

	private const int cOldKrNetWt = 40;

	private const int cOldKrTouch = 41;

	private const int cOldKrWest = 42;

	private const int cOldMargin = 43;

	private const int cVchDate = 44;

	private const int cRowValue = 45;

	private const int cRowText = 46;

	private const int c1SrNo = 0;

	private const int c1ItCode = 1;

	private const int c1ItName = 2;

	private const int c1DmCode = 3;

	private const int c1DmName = 4;

	private const int c1DmColor = 5;

	private const int c1DmSize = 6;

	private const int c1DmOrigin = 7;

	private const int c1DmRemark = 8;

	private const int c1DmSfNo = 9;

	private const int c1Pcs = 10;

	private const int c1PcsWt = 11;

	private const int c1KrWt = 12;

	private const int c1KrPrc = 13;

	private const int c1GrWt = 14;

	private const int c1ConPrc = 15;

	private const int c1RateType = 16;

	private const int c1ItRate = 17;

	private const int c1ItmAmt = 18;

	private const int c1LbrRate = 19;

	private const int c1LbrAmt = 20;

	private const int c1NetAmt = 21;

	private const int c1ConWt = 22;

	private const int c1KrConWt = 23;

	private const int c1ItType = 24;

	private const int c1RowSr = 25;

	private const int c1oldKrWt = 26;

	private const int c1oldGrWt = 27;

	private const int c1RowValue = 28;

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
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tVchNo_KeyDown);
			EventHandler eventHandler = tVchNo_TextChanged;
			TextBox val2 = _tVchNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tVchNo = value;
			val2 = _tVchNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
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

	internal virtual AxMSFlexGrid MSG_IDTL
	{
		[CompilerGenerated]
		get
		{
			return _MSG_IDTL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_IDTL_ClickEvent;
			EventHandler eventHandler2 = MSG_IDTL_EnterCell;
			EventHandler eventHandler3 = MSG_IDTL_LeaveCell;
			AxMSFlexGrid val = _MSG_IDTL;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG_IDTL = value;
			val = _MSG_IDTL;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
			}
		}
	}

	internal virtual TextBox TEXT_IDTL
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_IDTL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_IDTL_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_IDTL_KeyDown);
			TextBox val2 = _TEXT_IDTL;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_IDTL = value;
			val2 = _TEXT_IDTL;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
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

	internal virtual FlowLayoutPanel FlowLayoutPanel1
	{
		[CompilerGenerated]
		get
		{
			return _FlowLayoutPanel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = FlowLayoutPanel1_DoubleClick;
			FlowLayoutPanel val = _FlowLayoutPanel1;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_FlowLayoutPanel1 = value;
			val = _FlowLayoutPanel1;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnFirst")]
	private virtual SimpleButton _BtnFirst;

	internal virtual SimpleButton BtnFirst
	{
		get
		{
			return _BtnFirst;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnFirst = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnLast")]
	private virtual SimpleButton _BtnLast;

	internal virtual SimpleButton BtnLast
	{
		get
		{
			return _BtnLast;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnLast = value;
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
	[AccessedThroughProperty("Timer1")]
	private virtual Timer _Timer1;

	internal virtual Timer Timer1
	{
		get
		{
			return _Timer1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Timer1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SerialPort1")]
	private virtual SerialPort _SerialPort1;

	internal virtual SerialPort SerialPort1
	{
		get
		{
			return _SerialPort1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_SerialPort1 = value;
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

	internal virtual SimpleButton btnExel
	{
		[CompilerGenerated]
		get
		{
			return _btnExel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnExel_Click;
			SimpleButton val = _btnExel;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnExel = value;
			val = _btnExel;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
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
			EventHandler eventHandler = tPrCode_TextChanged;
			TextBox val2 = _tPrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tPrCode = value;
			val2 = _tPrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = DGV_DoubleClick;
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(DGV_CellContentClick);
			DataGridViewX val2 = _DGV;
			if (val2 != null)
			{
				((Control)val2).DoubleClick -= eventHandler;
				((DataGridView)val2).CellContentClick -= val;
			}
			_DGV = value;
			val2 = _DGV;
			if (val2 != null)
			{
				((Control)val2).DoubleClick += eventHandler;
				((DataGridView)val2).CellContentClick += val;
			}
		}
	}

	internal virtual SimpleButton btnExelImport
	{
		[CompilerGenerated]
		get
		{
			return _btnExelImport;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnExelImport_Click;
			SimpleButton val = _btnExelImport;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnExelImport = value;
			val = _btnExelImport;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
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
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
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
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected O, but got Unknown
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
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Expected O, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Expected O, but got Unknown
		//IL_04c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ce: Expected O, but got Unknown
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_053b: Expected O, but got Unknown
		//IL_05e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ee: Expected O, but got Unknown
		//IL_0651: Unknown result type (might be due to invalid IL or missing references)
		//IL_065b: Expected O, but got Unknown
		//IL_0704: Unknown result type (might be due to invalid IL or missing references)
		//IL_070e: Expected O, but got Unknown
		//IL_082b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0835: Expected O, but got Unknown
		//IL_0940: Unknown result type (might be due to invalid IL or missing references)
		//IL_094a: Expected O, but got Unknown
		//IL_09ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b7: Expected O, but got Unknown
		//IL_0b60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc4: Expected O, but got Unknown
		//IL_0d54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5e: Expected O, but got Unknown
		//IL_0e73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e7d: Expected O, but got Unknown
		//IL_0f73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f7d: Expected O, but got Unknown
		//IL_108c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1096: Expected O, but got Unknown
		//IL_1134: Unknown result type (might be due to invalid IL or missing references)
		//IL_113e: Expected O, but got Unknown
		//IL_11e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f0: Expected O, but got Unknown
		//IL_12f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_12fe: Expected O, but got Unknown
		//IL_1362: Unknown result type (might be due to invalid IL or missing references)
		//IL_136c: Expected O, but got Unknown
		//IL_13c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_13cb: Expected O, but got Unknown
		//IL_147c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1486: Expected O, but got Unknown
		//IL_1537: Unknown result type (might be due to invalid IL or missing references)
		//IL_1541: Expected O, but got Unknown
		//IL_16a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b3: Expected O, but got Unknown
		//IL_178b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1795: Expected O, but got Unknown
		//IL_1831: Unknown result type (might be due to invalid IL or missing references)
		//IL_183b: Expected O, but got Unknown
		//IL_1976: Unknown result type (might be due to invalid IL or missing references)
		//IL_1980: Expected O, but got Unknown
		//IL_19c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d2: Expected O, but got Unknown
		//IL_1a4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a57: Expected O, but got Unknown
		//IL_1adf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae9: Expected O, but got Unknown
		//IL_1c2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c36: Expected O, but got Unknown
		//IL_1cdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce9: Expected O, but got Unknown
		//IL_1d67: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d71: Expected O, but got Unknown
		//IL_1df5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dff: Expected O, but got Unknown
		//IL_1eca: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed4: Expected O, but got Unknown
		//IL_1f69: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f73: Expected O, but got Unknown
		//IL_1ff1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ffb: Expected O, but got Unknown
		//IL_20e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_20ea: Expected O, but got Unknown
		//IL_2153: Unknown result type (might be due to invalid IL or missing references)
		//IL_215d: Expected O, but got Unknown
		components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_DESIGN_BOOK));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		lblBook = new Label();
		Label2 = new Label();
		tVchNo = new TextBox();
		BtnPrint = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnExit = new SimpleButton();
		PnlBotam = new FlowLayoutPanel();
		btnExel = new SimpleButton();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		btnExelImport = new SimpleButton();
		BtnLast = new SimpleButton();
		BtnFirst = new SimpleButton();
		TEXT_ENTRY = new TextBox();
		TEXT_IDTL = new TextBox();
		MSG_IDTL = new AxMSFlexGrid();
		PicImage = new PictureBox();
		MSG_TOT = new AxMSFlexGrid();
		MSG = new AxMSFlexGrid();
		BtnImgC = new SimpleButton();
		BtnImgS = new SimpleButton();
		BtnImgD = new SimpleButton();
		DlgOpen = new OpenFileDialog();
		PicZoom = new PictureBox();
		BtnF1 = new SimpleButton();
		Cr = new AxCrystalReport();
		tEmpCode = new TextBox();
		tEmpName = new TextBox();
		Label5 = new Label();
		Timer1 = new Timer(components);
		SerialPort1 = new SerialPort(components);
		PictureBox1 = new PictureBox();
		tHdVchNo = new TextBox();
		tPrCode = new TextBox();
		tPrName = new TextBox();
		Label3 = new Label();
		DGV = new DataGridViewX();
		((Control)PnlBotam).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((ISupportInitialize)MSG_IDTL).BeginInit();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)PictureBox1).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
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
		((Control)lblBook).TabIndex = 17;
		lblBook.Text = "Design Book";
		lblBook.TextAlign = (ContentAlignment)32;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImageAlign = (ContentAlignment)64;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(12, 44);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(68, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchNo).Location = new Point(86, 43);
		((TextBoxBase)tVchNo).MaxLength = 20;
		((Control)tVchNo).Name = "tVchNo";
		((Control)tVchNo).Size = new Size(139, 23);
		((Control)tVchNo).TabIndex = 0;
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
		((Control)PnlBotam).Controls.Add((Control)(object)btnExel);
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
		((BaseStyleControl)btnExel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnExel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnExel).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnExel).Appearance.Options.UseForeColor = true;
		btnExel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)btnExel.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		((Control)btnExel).Location = new Point(730, 3);
		((BaseControl)btnExel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnExel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnExel).Name = "btnExel";
		((Control)btnExel).Size = new Size(91, 37);
		((Control)btnExel).TabIndex = 30;
		btnExel.Text = "&Exel";
		((BaseButton)btnExel).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)btnExelImport);
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(152, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(572, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((BaseStyleControl)btnExelImport).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnExelImport).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnExelImport).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnExelImport).Appearance.Options.UseForeColor = true;
		btnExelImport.ImageOptions.Location = (ImageLocation)1;
		((Control)btnExelImport).Location = new Point(458, 3);
		((BaseControl)btnExelImport).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnExelImport).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnExelImport).Name = "btnExelImport";
		((Control)btnExelImport).Size = new Size(111, 30);
		((Control)btnExelImport).TabIndex = 31;
		btnExelImport.Text = "&Exel Import";
		((BaseButton)btnExelImport).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)btnExelImport).Visible = false;
		((BaseStyleControl)BtnLast).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnLast).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnLast).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnLast).Appearance.Options.UseForeColor = true;
		((Control)BtnLast).Location = new Point(105, 3);
		((BaseControl)BtnLast).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnLast).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnLast).Name = "BtnLast";
		((Control)BtnLast).Size = new Size(41, 37);
		((Control)BtnLast).TabIndex = 29;
		BtnLast.Text = ">";
		((BaseButton)BtnLast).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnFirst).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnFirst).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnFirst).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnFirst).Appearance.Options.UseForeColor = true;
		((Control)BtnFirst).Location = new Point(58, 3);
		((BaseControl)BtnFirst).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnFirst).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnFirst).Name = "BtnFirst";
		((Control)BtnFirst).Size = new Size(41, 37);
		((Control)BtnFirst).TabIndex = 28;
		BtnFirst.Text = "<";
		((BaseButton)BtnFirst).ToolTipAnchor = (ToolTipAnchor)1;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(539, 226);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 5;
		((Control)TEXT_ENTRY).Visible = false;
		((TextBoxBase)TEXT_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_IDTL).ForeColor = Color.White;
		((Control)TEXT_IDTL).Location = new Point(499, 427);
		((Control)TEXT_IDTL).Name = "TEXT_IDTL";
		((Control)TEXT_IDTL).Size = new Size(100, 18);
		((Control)TEXT_IDTL).TabIndex = 13;
		((Control)TEXT_IDTL).Visible = false;
		((Control)MSG_IDTL).Location = new Point(12, 390);
		((Control)MSG_IDTL).Name = "MSG_IDTL";
		((AxHost)MSG_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_IDTL.OcxState");
		((Control)MSG_IDTL).Size = new Size(926, 131);
		((Control)MSG_IDTL).TabIndex = 1140;
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(944, 391);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(178, 162);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1138;
		PicImage.TabStop = false;
		((Control)MSG_TOT).Location = new Point(13, 371);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1162, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(12, 173);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1158, 194);
		((Control)MSG).TabIndex = 1135;
		BtnImgC.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgC.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgC.ImageOptions.SvgImage");
		((Control)BtnImgC).Location = new Point(1130, 390);
		((BaseControl)BtnImgC).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgC).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgC).Name = "BtnImgC";
		((Control)BtnImgC).Size = new Size(40, 34);
		((Control)BtnImgC).TabIndex = 18;
		((BaseControl)BtnImgC).ToolTip = "Image Capture";
		BtnImgS.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgS.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgS.ImageOptions.SvgImage");
		((Control)BtnImgS).Location = new Point(1130, 456);
		((BaseControl)BtnImgS).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgS).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgS).Name = "BtnImgS";
		((Control)BtnImgS).Size = new Size(40, 34);
		((Control)BtnImgS).TabIndex = 19;
		((BaseControl)BtnImgS).ToolTip = "Image Select";
		BtnImgD.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgD.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgD.ImageOptions.SvgImage");
		((Control)BtnImgD).Location = new Point(1130, 519);
		((BaseControl)BtnImgD).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgD).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgD).Name = "BtnImgD";
		((Control)BtnImgD).Size = new Size(40, 34);
		((Control)BtnImgD).TabIndex = 20;
		((BaseControl)BtnImgD).ToolTip = "Image Delete";
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((Control)PicZoom).BackColor = Color.Transparent;
		PicZoom.ImeMode = (ImeMode)0;
		((Control)PicZoom).Location = new Point(1215, 456);
		((Control)PicZoom).Name = "PicZoom";
		((Control)PicZoom).Size = new Size(12, 32);
		PicZoom.SizeMode = (PictureBoxSizeMode)4;
		PicZoom.TabIndex = 1147;
		PicZoom.TabStop = false;
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
		((Control)BtnF1).Location = new Point(231, 44);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(35, 23);
		((Control)BtnF1).TabIndex = 1149;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Voucher Help";
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1215, 226);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 1155;
		((TextBoxBase)tEmpCode).BackColor = Color.White;
		((Control)tEmpCode).Font = new Font("Tahoma", 9f);
		((Control)tEmpCode).Location = new Point(89, 533);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(57, 22);
		((Control)tEmpCode).TabIndex = 14;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tEmpName).Location = new Point(152, 533);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(216, 22);
		((Control)tEmpName).TabIndex = 1167;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(14, 535);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(69, 20);
		((Control)Label5).TabIndex = 1166;
		Label5.Text = "Employee";
		Label5.TextAlign = (ContentAlignment)16;
		((Control)PictureBox1).Location = new Point(1215, 269);
		((Control)PictureBox1).Name = "PictureBox1";
		((Control)PictureBox1).Size = new Size(56, 48);
		PictureBox1.SizeMode = (PictureBoxSizeMode)3;
		PictureBox1.TabIndex = 1228;
		PictureBox1.TabStop = false;
		((Control)PictureBox1).Visible = false;
		((TextBoxBase)tHdVchNo).BackColor = Color.FromArgb(255, 224, 192);
		((TextBoxBase)tHdVchNo).BorderStyle = (BorderStyle)0;
		((Control)tHdVchNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((TextBoxBase)tHdVchNo).ForeColor = Color.Maroon;
		((Control)tHdVchNo).Location = new Point(24, 9);
		((TextBoxBase)tHdVchNo).MaxLength = 8;
		((Control)tHdVchNo).Name = "tHdVchNo";
		((TextBoxBase)tHdVchNo).ReadOnly = true;
		((Control)tHdVchNo).Size = new Size(56, 15);
		((Control)tHdVchNo).TabIndex = 1229;
		((Control)tHdVchNo).Visible = false;
		((TextBoxBase)tPrCode).BackColor = Color.White;
		((Control)tPrCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tPrCode).Location = new Point(86, 87);
		((TextBoxBase)tPrCode).MaxLength = 8;
		((Control)tPrCode).Name = "tPrCode";
		((Control)tPrCode).Size = new Size(76, 23);
		((Control)tPrCode).TabIndex = 1242;
		((TextBoxBase)tPrName).BackColor = Color.White;
		((Control)tPrName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tPrName).Location = new Point(168, 87);
		((TextBoxBase)tPrName).MaxLength = 8;
		((Control)tPrName).Name = "tPrName";
		((Control)tPrName).Size = new Size(260, 23);
		((Control)tPrName).TabIndex = 1244;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(14, 86);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(66, 20);
		((Control)Label3).TabIndex = 1243;
		Label3.Text = "Pr Code";
		Label3.TextAlign = (ContentAlignment)64;
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
		((Control)DGV).Location = new Point(526, 43);
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
		((DataGridView)DGV).RowHeadersWidth = 20;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val5;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		((DataGridView)DGV).ScrollBars = (ScrollBars)2;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV).Size = new Size(644, 120);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 1245;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)tPrCode);
		((Control)this).Controls.Add((Control)(object)tPrName);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)tHdVchNo);
		((Control)this).Controls.Add((Control)(object)PictureBox1);
		((Control)this).Controls.Add((Control)(object)tEmpCode);
		((Control)this).Controls.Add((Control)(object)tEmpName);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)BtnF1);
		((Control)this).Controls.Add((Control)(object)PicZoom);
		((Control)this).Controls.Add((Control)(object)BtnImgD);
		((Control)this).Controls.Add((Control)(object)BtnImgS);
		((Control)this).Controls.Add((Control)(object)BtnImgC);
		((Control)this).Controls.Add((Control)(object)TEXT_IDTL);
		((Control)this).Controls.Add((Control)(object)MSG_IDTL);
		((Control)this).Controls.Add((Control)(object)PicImage);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG_TOT);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tVchNo);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_DESIGN_BOOK";
		((Form)this).Text = "r";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((ISupportInitialize)MSG_IDTL).EndInit();
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)PictureBox1).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public MS_DESIGN_BOOK()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		((Form)this).Load += MS_DESIGN_BOOK_Load;
		((Form)this).Deactivate += MS_DESIGN_BOOK_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_DESIGN_BOOK_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(MS_DESIGN_BOOK_KeyDown);
		((Form)this).Activated += MS_DESIGN_BOOK_Activated;
		((Form)this).Closed += MS_DESIGN_BOOK_Closed;
		((Control)this).KeyUp += new KeyEventHandler(MS_DESIGN_BOOK_KeyUp);
		WeightPortOpen = false;
		StkSaleVchDel = false;
		DtIdtl = new DataTable();
		dr = DtIdtl.NewRow();
		InitializeComponent();
	}

	private void MSG_IDTL_CLEAR()
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		mSG_IDTL.Clear();
		mSG_IDTL.Cols = 29;
		mSG_IDTL.FixedRows = 1;
		mSG_IDTL.Rows = 2;
		mSG_IDTL.Row = 0;
		mSG_IDTL[0] = 0;
		mSG_IDTL[1] = 0;
		mSG_IDTL.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG_IDTL[0] = (int)Math.Round(500.0 * ColCon);
			mSG_IDTL[0] = 3;
			mSG_IDTL[0, 0] = "Sr";
			mSG_IDTL[1] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[1] = 0;
			mSG_IDTL[0, 1] = "ItCode";
			mSG_IDTL[2] = (int)Math.Round(2000.0 * ColCon);
			mSG_IDTL[2] = 0;
			mSG_IDTL[0, 2] = "ItName";
			mSG_IDTL[3] = (int)Math.Round(875.0 * ColCon);
			mSG_IDTL[3] = 0;
			mSG_IDTL[0, 3] = "DmCode";
			mSG_IDTL[4] = (int)Math.Round(1700.0 * ColCon);
			mSG_IDTL[4] = 0;
			mSG_IDTL[0, 4] = "DmName";
			mSG_IDTL[5] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[5] = 0;
			mSG_IDTL[0, 5] = "DmColor";
			mSG_IDTL[6] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[6] = 3;
			mSG_IDTL[0, 6] = "DmSize";
			mSG_IDTL[7] = (int)Math.Round(1500.0 * ColCon);
			mSG_IDTL[7] = 0;
			mSG_IDTL[0, 7] = "DmOrigin";
			mSG_IDTL[8] = (int)Math.Round(1500.0 * ColCon);
			mSG_IDTL[8] = 0;
			mSG_IDTL[0, 8] = "DmRemark";
			mSG_IDTL[9] = (int)Math.Round(1500.0 * ColCon);
			mSG_IDTL[9] = 0;
			mSG_IDTL[0, 9] = "DmSfNo";
			mSG_IDTL[10] = (int)Math.Round(750.0 * ColCon);
			mSG_IDTL[10] = 7;
			mSG_IDTL[0, 10] = "Pcs";
			mSG_IDTL[11] = (int)Math.Round(750.0 * ColCon);
			mSG_IDTL[11] = 7;
			mSG_IDTL[0, 11] = "PcsWt";
			mSG_IDTL[12] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[12] = 7;
			mSG_IDTL[0, 12] = "KrWt";
			mSG_IDTL[13] = (int)Math.Round(800.0 * ColCon);
			mSG_IDTL[13] = 7;
			mSG_IDTL[0, 13] = "KrLs%";
			mSG_IDTL[14] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[14] = 7;
			mSG_IDTL[0, 14] = "Weight";
			mSG_IDTL[15] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[15] = 7;
			mSG_IDTL[0, 15] = "Con%";
			mSG_IDTL[16] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[16] = 3;
			mSG_IDTL[0, 16] = "P/W";
			mSG_IDTL[17] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[17] = 7;
			mSG_IDTL[0, 17] = "Rate";
			mSG_IDTL[18] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[18] = 7;
			mSG_IDTL[0, 18] = "ItAmt";
			mSG_IDTL[19] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[19] = 7;
			mSG_IDTL[0, 19] = "LbrRate";
			mSG_IDTL[20] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[20] = 7;
			mSG_IDTL[0, 20] = "LbrAmt";
			mSG_IDTL[21] = (int)Math.Round(1050.0 * ColCon);
			mSG_IDTL[21] = 7;
			mSG_IDTL[0, 21] = "NetAmt";
			mSG_IDTL[22] = 0;
			mSG_IDTL[0, 22] = "ConWt";
			mSG_IDTL[23] = 0;
			mSG_IDTL[0, 23] = "KrConWt";
			mSG_IDTL[24] = 0;
			mSG_IDTL[0, 24] = "ItType";
			mSG_IDTL[25] = 0;
			mSG_IDTL[0, 25] = "RowSrNo";
			mSG_IDTL[26] = 0;
			mSG_IDTL[0, 26] = "OldKrWt";
			mSG_IDTL[27] = 0;
			mSG_IDTL[0, 27] = "OldGrWt";
			mSG_IDTL[28] = 0;
			mSG_IDTL[0, 28] = "1RowVal";
			mSG_IDTL.Row = 1;
			mSG_IDTL.Col = 0;
			((Control)TEXT_IDTL).Visible = false;
			DataView dataView = new DataView(DC_Main.RsClIdtl);
			if (dataView.Count > 0)
			{
				int num = mSG_IDTL.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					dataView.RowFilter = "BOOK_NAME = 'TAG_IDTL' AND COL_NAME = '" + mSG_IDTL[0, DC_Main.M] + "'";
					if (dataView.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(dataView[0]["YES_NO"], (object)"N", false))
						{
							mSG_IDTL[DC_Main.M] = 0;
						}
						mSG_IDTL[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);
					}
					DC_Main.M++;
				}
			}
			mSG_IDTL[0] = (int)Math.Round(325.0 * ColCon);
			mSG_IDTL[1] = (int)Math.Round(300.0 * ColCon);
			mSG_IDTL.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd_Idtl();
			mSG_IDTL = null;
		}
	}

	private void CommPassAdd_Idtl()
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		mSG_IDTL[mSG_IDTL.Row, 0] = Conversions.ToString(mSG_IDTL.Row);
		mSG_IDTL[mSG_IDTL.Row, 25] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 29]));
		checked
		{
			if (mSG_IDTL.Row > 1)
			{
				DataView dataView = new DataView(DC_Main.RsClIdtl);
				if (dataView.Count > 0)
				{
					int num = mSG_IDTL.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
					{
						dataView.RowFilter = "BOOK_NAME = 'TAG_IDTL' AND COL_NEW_NAME = '" + mSG_IDTL[0, DC_Main.M] + "'";
						if (dataView.Count > 0 && Operators.ConditionalCompareObjectEqual(dataView[0]["COL_RPT"], (object)"Y", false))
						{
							mSG_IDTL[mSG_IDTL.Row, DC_Main.M] = mSG_IDTL[mSG_IDTL.Row - 1, DC_Main.M];
						}
						DC_Main.M++;
					}
				}
			}
			mSG_IDTL = null;
		}
	}

	private void TEXT_IDTL_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_IDTL_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Invalid comparison between Unknown and I4
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Invalid comparison between Unknown and I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Invalid comparison between Unknown and I4
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Invalid comparison between Unknown and I4
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Invalid comparison between Unknown and I4
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Invalid comparison between Unknown and I4
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Invalid comparison between Unknown and I4
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0935: Unknown result type (might be due to invalid IL or missing references)
		MsgIdtlLeft = false;
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = DtIdtl.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						string text = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][25])));
						string text2 = Conversions.ToString(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 25]));
						string text3 = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])));
						string text4 = Conversions.ToString(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 0]));
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][25])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 25])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 0])))
						{
							DtIdtl.Rows.Remove(DtIdtl.Rows[i]);
							break;
						}
					}
					int num2 = mSG_IDTL.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num2)
					{
						mSG_IDTL[mSG_IDTL.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					CommPassTotal_Idtl(1);
					TEXT_IDTL.Text = "";
					Interaction.MsgBox((object)"Record is Deleted....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG_IDTL.Col > 1)
				{
					MsgIdtlLeft = true;
					mSG_IDTL.Col = checked(mSG_IDTL.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				if (mSG_IDTL.Col < 21)
				{
					mSG_IDTL.Col = checked(mSG_IDTL.Col + 1);
				}
				return;
			}
			if ((int)keyCode == 38)
			{
				if (mSG_IDTL.Row > 1)
				{
					mSG_IDTL.Row = checked(mSG_IDTL.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				checked
				{
					if (mSG_IDTL.Row < mSG_IDTL.Rows - 1)
					{
						mSG_IDTL.Row += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG_IDTL.Col)
					{
					case 1:
						if (Operators.CompareString(TEXT_IDTL.Text, "", false) == 0)
						{
							((Control)TEXT_IDTL).Visible = false;
							MSG.Col += 1;
							MSG_EnterCell(MSG, new EventArgs());
							((Control)TEXT_ENTRY).Visible = true;
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_IDTL.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.IT_NAME";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[7];
							DC_Main.ColWidth[0] = 300.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.ColWidth[2] = 250.0;
							DC_Main.ColWidth[3] = 0.0;
							DC_Main.ColWidth[4] = 0.0;
							DC_Main.ColWidth[5] = 0.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_IDTL.Text = DC_Main.ColValue[1];
									mSG_IDTL[mSG_IDTL.Row, 1] = DC_Main.ColValue[1];
									mSG_IDTL[mSG_IDTL.Row, 2] = DC_Main.ColValue[0];
									mSG_IDTL[mSG_IDTL.Row, 24] = DC_Main.ColValue[4];
								}
								((Control)TEXT_IDTL).Focus();
							}
							return;
						}
						mSG_IDTL[mSG_IDTL.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_IDTL[mSG_IDTL.Row, 24] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 15]) == 0.0)
						{
							mSG_IDTL[mSG_IDTL.Row, 15] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CON_PRC"], (object)"")), "0.000");
						}
						if (Operators.CompareString(EntryMode, "A", false) != 0)
						{
							break;
						}
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""), (object)"F", false))
						{
							if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 21]) == 0.0)
							{
								mSG_IDTL[mSG_IDTL.Row, 21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
							}
						}
						else if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 17]) == 0.0)
						{
							mSG_IDTL[mSG_IDTL.Row, 17] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
						}
						if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""), (object)"", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""), (object)"F", false))) && Operators.CompareString(mSG_IDTL[mSG_IDTL.Row, 16], "", false) == 0)
						{
							mSG_IDTL[mSG_IDTL.Row, 16] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""));
						}
						break;
					case 3:
					{
						if (Operators.CompareString(TEXT_IDTL.Text, "", false) == 0 || mSG_IDTL[3] == 0)
						{
							break;
						}
						DC_Main.RsQry = "Select * From DM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND DM_CODE = '" + TEXT_IDTL.Text + "'";
						DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (dataTable.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.DM_NAME As ItemNameL,A.DM_CODE as ItCodeL,B.GR_NAME As GroupL FROM DM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.DM_NAME";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[4];
							DC_Main.ColWidth[0] = 300.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.ColWidth[2] = 250.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_IDTL.Text = DC_Main.ColValue[1];
									mSG_IDTL[mSG_IDTL.Row, 3] = DC_Main.ColValue[1];
									mSG_IDTL[mSG_IDTL.Row, 4] = DC_Main.ColValue[0];
								}
								((Control)TEXT_IDTL).Focus();
							}
							return;
						}
						mSG_IDTL[mSG_IDTL.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["DM_CODE"], (object)""));
						mSG_IDTL[mSG_IDTL.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["DM_NAME"], (object)""));
						if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 17]) == 0.0)
						{
							mSG_IDTL[mSG_IDTL.Row, 17] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["SL_RATE"], (object)"")), "0.00");
						}
						break;
					}
					case 11:
						if ((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) != 0.0) & (Conversion.Val(TEXT_IDTL.Text) != 0.0))
						{
							mSG_IDTL[mSG_IDTL.Row, 12] = Strings.Format((object)(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) * Conversion.Val(TEXT_IDTL.Text)), "0.000");
						}
						break;
					case 14:
						if ((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) == 0.0) & (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 14]) == 0.0))
						{
							if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 21]) == 0.0)
							{
								mSG_IDTL[mSG_IDTL.Row, 21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
							}
							mSG_IDTL[mSG_IDTL.Row, 17] = "";
						}
						break;
					case 21:
						if (mSG_IDTL.Row == mSG_IDTL.Rows - 1)
						{
							mSG_IDTL[mSG_IDTL.Row, 21] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
							CommPassTotal_Idtl(mSG_IDTL.Row);
							MsgClearIdtl = true;
							mSG_IDTL.Rows += 1;
							mSG_IDTL.Row += 1;
							MsgClearIdtl = false;
							mSG_IDTL.Col = 1;
							CommPassAdd_Idtl();
						}
						else
						{
							mSG_IDTL[mSG_IDTL.Row, 21] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
							CommPassTotal_Idtl(mSG_IDTL.Row);
							((Control)TEXT_IDTL).Visible = false;
							mSG_IDTL.Row += 1;
							mSG_IDTL.Col = 1;
							((Control)TEXT_IDTL).Visible = true;
							((Control)TEXT_IDTL).Focus();
						}
						return;
					}
					if (mSG_IDTL.Col < mSG_IDTL.Cols - 1)
					{
						mSG_IDTL.Col += 1;
					}
					((Control)TEXT_IDTL).Visible = true;
					((Control)TEXT_IDTL).Focus();
				}
			}
		}
		mSG_IDTL = null;
	}

	private void MSG_IDTL_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		checked
		{
			if (mSG_IDTL.CellWidth >= 0)
			{
				((Control)TEXT_IDTL).Left = (int)Math.Round((double)((Control)mSG_IDTL).Left + (double)mSG_IDTL.CellLeft / 15.0);
				((Control)TEXT_IDTL).Top = (int)Math.Round((double)((Control)mSG_IDTL).Top + (double)mSG_IDTL.CellTop / 15.0);
				((Control)TEXT_IDTL).Width = (int)Math.Round((double)mSG_IDTL.CellWidth / 15.0);
				((Control)TEXT_IDTL).Height = (int)Math.Round((double)mSG_IDTL.CellHeight / 15.0);
				TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
				((Control)TEXT_IDTL).Visible = true;
				((Control)TEXT_ENTRY).Visible = false;
				((TextBoxBase)TEXT_IDTL).SelectAll();
				((Control)TEXT_IDTL).Focus();
				mSG_IDTL = null;
			}
		}
	}

	private void MSG_IDTL_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		checked
		{
			if (mSG_IDTL[mSG_IDTL.Col] == 0)
			{
				TEXT_IDTL.Text = "";
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = "";
				DC_Main.M = 1;
				while (mSG_IDTL[mSG_IDTL.Col] == 0)
				{
					if (MsgIdtlLeft)
					{
						if (mSG_IDTL.Col > 1)
						{
							mSG_IDTL.Col -= 1;
						}
					}
					else if (mSG_IDTL.Col < mSG_IDTL.Cols - 1)
					{
						mSG_IDTL.Col += 1;
					}
					DC_Main.M++;
					if (DC_Main.M > 10)
					{
						break;
					}
				}
			}
			if (!((mSG_IDTL.Row == 0) | (mSG_IDTL.CellWidth <= 0)) && mSG_IDTL[mSG_IDTL.Col] != 0)
			{
				((Control)TEXT_IDTL).Left = (int)Math.Round((double)((Control)mSG_IDTL).Left + (double)mSG_IDTL.CellLeft / 15.0);
				((Control)TEXT_IDTL).Top = (int)Math.Round((double)((Control)mSG_IDTL).Top + (double)mSG_IDTL.CellTop / 15.0);
				((Control)TEXT_IDTL).Width = (int)Math.Round((double)mSG_IDTL.CellWidth / 15.0);
				((Control)TEXT_IDTL).Height = (int)Math.Round((double)mSG_IDTL.CellHeight / 15.0);
				((Control)TEXT_IDTL).Visible = true;
				((TextBoxBase)TEXT_IDTL).ReadOnly = false;
				switch (MSG_IDTL.Col)
				{
				case 0:
				case 1:
					((TextBoxBase)TEXT_IDTL).MaxLength = 5;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_IDTL).MaxLength = 8;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 2:
				case 4:
					((TextBoxBase)TEXT_IDTL).MaxLength = 50;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 5:
					((TextBoxBase)TEXT_IDTL).MaxLength = 15;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 6:
				case 7:
				case 8:
				case 9:
					((TextBoxBase)TEXT_IDTL).MaxLength = 20;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 16:
					((TextBoxBase)TEXT_IDTL).MaxLength = 1;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 10:
					((TextBoxBase)TEXT_IDTL).MaxLength = 6;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0");
					break;
				case 15:
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.000");
					break;
				case 13:
				case 17:
				case 18:
				case 19:
				case 20:
				case 21:
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.00");
					break;
				case 11:
				case 12:
				case 14:
				case 22:
				case 23:
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.000");
					break;
				}
				mSG_IDTL = null;
				((TextBoxBase)TEXT_IDTL).SelectAll();
			}
		}
	}

	private void MSG_IDTL_LeaveCell(object sender, EventArgs e)
	{
		if (!MsgClearIdtl && MSG_IDTL.Row != 0 && MSG_IDTL[MSG_IDTL.Col] != 0 && ((Control)TEXT_IDTL).Visible)
		{
			AxMSFlexGrid mSG_IDTL = MSG_IDTL;
			switch (MSG_IDTL.Col)
			{
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 16:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = TEXT_IDTL.Text;
				break;
			case 10:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 15:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.000");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 13:
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 11:
			case 12:
			case 14:
			case 22:
			case 23:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.000");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			}
			mSG_IDTL = null;
		}
	}

	private void CommPassTotal_Idtl(int CRow)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		if ((Conversion.Val(mSG_IDTL[CRow, 10]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 11]) != 0.0))
		{
			mSG_IDTL[CRow, 12] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 10]) * Conversion.Val(mSG_IDTL[CRow, 11])), "0.000");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 13]) != 0.0)
		{
			mSG_IDTL[CRow, 14] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 12]) * Conversion.Val(mSG_IDTL[CRow, 13]) / 100.0), "0.000");
			mSG_IDTL[CRow, 27] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 14]), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 12]) != Conversion.Val(mSG_IDTL[CRow, 26])) & (Conversion.Val(mSG_IDTL[CRow, 14]) == 0.0))
		{
			mSG_IDTL[CRow, 26] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 12]), "0.000");
			mSG_IDTL[CRow, 14] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 12]), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 14]) != Conversion.Val(mSG_IDTL[CRow, 27])) & (Conversion.Val(mSG_IDTL[CRow, 12]) == 0.0))
		{
			mSG_IDTL[CRow, 27] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 14]), "0.000");
			mSG_IDTL[CRow, 12] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 14]), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 15]) != 0.0))
		{
			mSG_IDTL[CRow, 22] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 15])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 22] = Conversions.ToString(0);
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 15]) != 0.0))
		{
			mSG_IDTL[CRow, 23] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 12]) * Conversion.Val(mSG_IDTL[CRow, 15])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 23] = Conversions.ToString(0);
		}
		if (Operators.CompareString(mSG_IDTL[CRow, 16], "", false) == 0)
		{
			if ((Conversion.Val(mSG_IDTL[CRow, 14]) == 0.0) & (Conversion.Val(mSG_IDTL[CRow, 10]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 17]) != 0.0))
			{
				mSG_IDTL[CRow, 18] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 17]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.00");
			}
			else if ((Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 17]) != 0.0))
			{
				mSG_IDTL[CRow, 18] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 17]) * Conversion.Val(mSG_IDTL[CRow, 14])), "0.00");
			}
		}
		else if (((0 - ((Operators.CompareString(mSG_IDTL[CRow, 16], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_IDTL[CRow, 17])))) != 0)
		{
			mSG_IDTL[CRow, 18] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 17]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.00");
		}
		else if (Conversion.Val(mSG_IDTL[CRow, 17]) != 0.0)
		{
			mSG_IDTL[CRow, 18] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 17]) * Conversion.Val(mSG_IDTL[CRow, 14])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 19]) != 0.0)
		{
			mSG_IDTL[CRow, 20] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 19]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 18]) + Conversion.Val(mSG_IDTL[CRow, 20]) != 0.0)
		{
			mSG_IDTL[CRow, 21] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 18]) + Conversion.Val(mSG_IDTL[CRow, 20])), "0.00");
		}
		checked
		{
			int num5 = MSG_IDTL.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num5)
			{
				num3 += Conversion.Val(mSG_IDTL[DC_Main.M, 22]);
				num4 += Conversion.Val(mSG_IDTL[DC_Main.M, 23]);
				num += Conversion.Val(mSG_IDTL[DC_Main.M, 21]);
				DC_Main.M++;
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 9] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 10] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 8]) - Conversion.Val(MSG[MSG.Row, 9])), "0.000");
			}
			if (num != 0.0)
			{
				MSG[MSG.Row, 20] = Strings.Format((object)num, "0.00");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 10] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 8]) - num3), "0.000");
			}
			if (Operators.CompareString(mSG_IDTL[CRow, 1], "", false) != 0)
			{
				bool flag = false;
				int num6 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num6; i++)
				{
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][25])) == Conversion.Val(mSG_IDTL[CRow, 25])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[CRow, 0])))
					{
						flag = true;
						DtIdtl.Rows[i][0] = mSG_IDTL[CRow, 0];
						DtIdtl.Rows[i][1] = mSG_IDTL[CRow, 1];
						DtIdtl.Rows[i][2] = mSG_IDTL[CRow, 2];
						DtIdtl.Rows[i][3] = mSG_IDTL[CRow, 3];
						DtIdtl.Rows[i][4] = mSG_IDTL[CRow, 4];
						DtIdtl.Rows[i][5] = mSG_IDTL[CRow, 5];
						DtIdtl.Rows[i][6] = mSG_IDTL[CRow, 6];
						DtIdtl.Rows[i][7] = mSG_IDTL[CRow, 7];
						DtIdtl.Rows[i][8] = mSG_IDTL[CRow, 8];
						DtIdtl.Rows[i][9] = mSG_IDTL[CRow, 9];
						DtIdtl.Rows[i][10] = mSG_IDTL[CRow, 10];
						DtIdtl.Rows[i][11] = mSG_IDTL[CRow, 11];
						DtIdtl.Rows[i][14] = mSG_IDTL[CRow, 14];
						DtIdtl.Rows[i][12] = mSG_IDTL[CRow, 12];
						DtIdtl.Rows[i][13] = mSG_IDTL[CRow, 13];
						DtIdtl.Rows[i][15] = mSG_IDTL[CRow, 15];
						DtIdtl.Rows[i][16] = mSG_IDTL[CRow, 16];
						DtIdtl.Rows[i][17] = mSG_IDTL[CRow, 17];
						DtIdtl.Rows[i][18] = mSG_IDTL[CRow, 18];
						DtIdtl.Rows[i][19] = mSG_IDTL[CRow, 19];
						DtIdtl.Rows[i][20] = mSG_IDTL[CRow, 20];
						DtIdtl.Rows[i][21] = mSG_IDTL[CRow, 21];
						DtIdtl.Rows[i][22] = mSG_IDTL[CRow, 22];
						DtIdtl.Rows[i][23] = mSG_IDTL[CRow, 23];
						DtIdtl.Rows[i][24] = mSG_IDTL[CRow, 24];
						DtIdtl.Rows[i][25] = mSG_IDTL[CRow, 25];
						DtIdtl.Rows[i][26] = mSG_IDTL[CRow, 26];
						DtIdtl.Rows[i][27] = mSG_IDTL[CRow, 27];
						DtIdtl.Rows[i][28] = mSG_IDTL[CRow, 28];
						break;
					}
				}
				if (!flag)
				{
					dr = DtIdtl.NewRow();
					dr[0] = mSG_IDTL[CRow, 0];
					dr[1] = mSG_IDTL[CRow, 1];
					dr[2] = mSG_IDTL[CRow, 2];
					dr[3] = mSG_IDTL[CRow, 3];
					dr[4] = mSG_IDTL[CRow, 4];
					dr[5] = mSG_IDTL[CRow, 5];
					dr[6] = mSG_IDTL[CRow, 6];
					dr[7] = mSG_IDTL[CRow, 7];
					dr[8] = mSG_IDTL[CRow, 8];
					dr[9] = mSG_IDTL[CRow, 9];
					dr[10] = mSG_IDTL[CRow, 10];
					dr[11] = mSG_IDTL[CRow, 11];
					dr[14] = mSG_IDTL[CRow, 14];
					dr[12] = mSG_IDTL[CRow, 12];
					dr[13] = mSG_IDTL[CRow, 13];
					dr[15] = mSG_IDTL[CRow, 15];
					dr[16] = mSG_IDTL[CRow, 16];
					dr[17] = mSG_IDTL[CRow, 17];
					dr[18] = mSG_IDTL[CRow, 18];
					dr[19] = mSG_IDTL[CRow, 19];
					dr[20] = mSG_IDTL[CRow, 20];
					dr[21] = mSG_IDTL[CRow, 21];
					dr[22] = mSG_IDTL[CRow, 22];
					dr[23] = mSG_IDTL[CRow, 23];
					dr[24] = mSG_IDTL[CRow, 24];
					dr[25] = mSG_IDTL[CRow, 25];
					dr[26] = mSG_IDTL[CRow, 26];
					dr[27] = mSG_IDTL[CRow, 27];
					dr[28] = mSG_IDTL[CRow, 28];
					DtIdtl.Rows.Add(dr);
				}
			}
			mSG_IDTL = null;
		}
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 47;
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
			mSG[1] = (int)Math.Round(900.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "Page No";
			mSG[2] = (int)Math.Round(1300.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "Design";
			if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
			{
				mSG[3] = (int)Math.Round(1200.0 * ColCon);
				mSG[3] = 0;
				mSG[0, 3] = "Style";
			}
			else
			{
				mSG[3] = 0;
			}
			mSG[5] = (int)Math.Round(800.0 * ColCon);
			mSG[5] = 0;
			mSG[0, 5] = "Size";
			mSG[4] = (int)Math.Round(900.0 * ColCon);
			mSG[4] = 0;
			mSG[0, 4] = "GrCode";
			mSG[6] = (int)Math.Round(1700.0 * ColCon);
			mSG[6] = 0;
			mSG[0, 6] = "DieNo";
			mSG[7] = (int)Math.Round(700.0 * ColCon);
			mSG[7] = 7;
			mSG[0, 7] = "Pcs";
			mSG[8] = (int)Math.Round(1000.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "GrWt";
			mSG[9] = (int)Math.Round(900.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "LsWt";
			mSG[10] = (int)Math.Round(1000.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "NetWt";
			mSG[11] = 0;
			mSG[11] = 7;
			mSG[0, 11] = "Ght%";
			mSG[12] = 0;
			mSG[12] = 7;
			mSG[0, 12] = "GhtWt";
			mSG[13] = (int)Math.Round(850.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "Touch";
			mSG[14] = (int)Math.Round(850.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "West%";
			mSG[15] = (int)Math.Round(1000.0 * ColCon);
			mSG[15] = 7;
			mSG[0, 15] = "Fine";
			mSG[16] = (int)Math.Round(800.0 * ColCon);
			mSG[16] = 7;
			mSG[0, 16] = "Lbr%";
			mSG[17] = (int)Math.Round(800.0 * ColCon);
			mSG[17] = 3;
			mSG[0, 17] = "LType";
			mSG[18] = (int)Math.Round(900.0 * ColCon);
			mSG[18] = 7;
			mSG[0, 18] = "LbrRate";
			mSG[19] = (int)Math.Round(950.0 * ColCon);
			mSG[19] = 7;
			mSG[0, 19] = "LbrAmt";
			mSG[20] = (int)Math.Round(1000.0 * ColCon);
			mSG[20] = 7;
			mSG[0, 20] = "OthAmt";
			mSG[24] = (int)Math.Round(1000.0 * ColCon);
			mSG[24] = 7;
			mSG[0, 24] = "PrCost";
			mSG[21] = (int)Math.Round(1000.0 * ColCon);
			mSG[21] = 7;
			mSG[0, 21] = "ItRate";
			mSG[22] = (int)Math.Round(1100.0 * ColCon);
			mSG[22] = 7;
			mSG[0, 22] = "ItAmt";
			mSG[23] = (int)Math.Round(1100.0 * ColCon);
			mSG[23] = 7;
			mSG[0, 23] = "TagCost";
			mSG[25] = (int)Math.Round(800.0 * ColCon);
			mSG[25] = 7;
			mSG[0, 25] = "Margin";
			mSG[26] = (int)Math.Round(1000.0 * ColCon);
			mSG[26] = 7;
			mSG[0, 26] = "Mrp";
			mSG[27] = (int)Math.Round(750.0 * ColCon);
			mSG[27] = 3;
			mSG[0, 27] = "Image";
			mSG[28] = (int)Math.Round(800.0 * ColCon);
			mSG[28] = 7;
			mSG[0, 28] = "KrCod";
			mSG[29] = 0;
			mSG[30] = 0;
			mSG[31] = 0;
			mSG[32] = 0;
			mSG[33] = 0;
			mSG[34] = 0;
			mSG[35] = 0;
			mSG[36] = 0;
			mSG[37] = 0;
			mSG[38] = 0;
			mSG[39] = 0;
			mSG[40] = 0;
			mSG[41] = 0;
			mSG[42] = 0;
			mSG[43] = 0;
			mSG[44] = 0;
			mSG[45] = 0;
			mSG[46] = 0;
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
					dataView.RowFilter = "BOOK_NAME = 'DESIGN DETL' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
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
			MsgLastCol = 28;
			DC_Main.M = 29;
			while (DC_Main.M <= 24)
			{
				if (mSG[DC_Main.M] > 0)
				{
					mSG[24] = (int)Math.Round(1100.0 * ColCon);
					MsgLastCol = 24;
					break;
				}
				DC_Main.M++;
			}
			mSG[0] = (int)Math.Round(325.0 * ColCon);
			mSG[1] = (int)Math.Round(300.0 * ColCon);
			mSG.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd();
			mSG = null;
			AxMSFlexGrid mSG_TOT = MSG_TOT;
			mSG_TOT.Cols = MSG.Cols;
			int num2 = MSG.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num2)
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
					mSG_TOT[0, 7] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 7]) + Conversion.Val(MSG[DC_Main.M, 7]))), "0");
					mSG_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 8]) + Conversion.Val(MSG[DC_Main.M, 8]))), "0.000");
					mSG_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 9]) + Conversion.Val(MSG[DC_Main.M, 9]))), "0.000");
					mSG_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 10]) + Conversion.Val(MSG[DC_Main.M, 10]))), "0.000");
					mSG_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 12]) + Conversion.Val(MSG[DC_Main.M, 12]))), "0.000");
					mSG_TOT[0, 15] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 15]) + Conversion.Val(MSG[DC_Main.M, 15]))), "0.000");
					mSG_TOT[0, 22] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 22]) + Conversion.Val(MSG[DC_Main.M, 22]))), "0.00");
					mSG_TOT[0, 19] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 19]) + Conversion.Val(MSG[DC_Main.M, 19]))), "0.00");
					mSG_TOT[0, 20] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 20]) + Conversion.Val(MSG[DC_Main.M, 20]))), "0.00");
					mSG_TOT[0, 23] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 23]) + Conversion.Val(MSG[DC_Main.M, 23]))), "0.00");
					mSG_TOT[0, 26] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 26]) + Conversion.Val(MSG[DC_Main.M, 26]))), "0.000");
					mSG_TOT[0, 24] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 24]) + Conversion.Val(MSG[DC_Main.M, 24]))), "0.00");
					DC_Main.M++;
				}
				mSG_TOT = null;
				NewValTot = Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 20]) + Conversion.Val(MSG_TOT[0, 19]) + Conversion.Val(MSG_TOT[0, 26]);
			}
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG[mSG.Row, 7] = Conversions.ToString(1);
		mSG[mSG.Row, 17] = DC_Main.MsLbrType;
		mSG[mSG.Row, 44] = Conversions.ToString(DC_Main.MsSysDate);
		checked
		{
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				mSG[mSG.Row, 29] = Conversions.ToString(MSG.Row);
			}
			else
			{
				mSG[mSG.Row, 29] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 29]) + 1.0);
			}
			mSG[mSG.Row, 33] = "A";
			mSG[mSG.Row, 27] = "N";
			MSG_IDTL_CLEAR();
			if (mSG.Row > 1)
			{
				DataView dataView = new DataView(DC_Main.RsClDetl);
				if (dataView.Count > 0)
				{
					int num = mSG.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
					{
						dataView.RowFilter = "BOOK_NAME = 'DESIGN DETL' AND COL_NEW_NAME = '" + mSG[0, DC_Main.M] + "'";
						if (dataView.Count > 0 && Operators.ConditionalCompareObjectEqual(dataView[0]["COL_RPT"], (object)"Y", false))
						{
							TEXT_ENTRY.Text = mSG[mSG.Row - 1, DC_Main.M];
							mSG[mSG.Row, DC_Main.M] = mSG[mSG.Row - 1, DC_Main.M];
						}
						DC_Main.M++;
					}
				}
			}
			mSG = null;
		}
	}

	private void MSG_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
		UpDown = false;
		MsgOldRow = 0;
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
				case 4:
				case 28:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 3:
				case 6:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 2:
				case 5:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 1:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 17:
				case 27:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 7:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
					break;
				case 11:
				case 13:
				case 14:
				case 16:
				case 25:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				case 18:
				case 19:
				case 20:
				case 21:
				case 22:
				case 23:
				case 26:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				case 8:
				case 9:
				case 10:
				case 12:
				case 15:
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
			case 4:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 0:
			case 1:
			case 2:
			case 3:
			case 5:
			case 6:
			case 17:
			case 27:
			case 28:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 7:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
				break;
			case 11:
			case 13:
			case 14:
			case 16:
			case 25:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
			case 23:
			case 24:
			case 26:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 9:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				CommPassTotal_Idtl(1);
				CommPassTotal();
				break;
			case 8:
			case 10:
			case 12:
			case 15:
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
				case 3986:
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
							goto IL_0047;
						case 5:
							goto IL_0079;
						case 6:
						case 7:
							goto IL_00c1;
						case 8:
							goto IL_010b;
						case 9:
						case 10:
							goto IL_0153;
						case 11:
							goto IL_018a;
						case 12:
							goto IL_01be;
						case 13:
							goto IL_021e;
						case 15:
							goto IL_029c;
						case 14:
						case 16:
						case 17:
						case 18:
							goto IL_02d3;
						case 19:
							goto IL_031f;
						case 20:
						case 21:
							goto IL_0373;
						case 22:
							goto IL_03aa;
						case 23:
							goto IL_03de;
						case 24:
							goto IL_043e;
						case 25:
						case 26:
						case 27:
							goto IL_04bc;
						case 28:
							goto IL_04f3;
						case 29:
							goto IL_0527;
						case 30:
							goto IL_0587;
						case 31:
						case 32:
						case 33:
							goto IL_0605;
						case 34:
							goto IL_0640;
						case 35:
						case 36:
							goto IL_068a;
						case 37:
							goto IL_06e7;
						case 38:
						case 39:
							goto IL_0763;
						case 40:
							goto IL_07b3;
						case 42:
							goto IL_07fc;
						case 44:
							goto IL_084f;
						case 46:
							goto IL_08ad;
						case 48:
							goto IL_0908;
						case 41:
						case 43:
						case 45:
						case 47:
						case 49:
						case 50:
						case 51:
							goto IL_095b;
						case 52:
							goto IL_0989;
						case 54:
							goto IL_09d2;
						case 56:
							goto IL_0a25;
						case 58:
							goto IL_0a8d;
						case 60:
							goto IL_0afc;
						case 53:
						case 55:
						case 57:
						case 59:
						case 61:
						case 62:
						case 63:
							goto IL_0b4e;
						case 64:
							goto IL_0b81;
						case 65:
							goto IL_0bdd;
						case 66:
						case 67:
							goto IL_0c3b;
						case 68:
							goto IL_0c94;
						case 69:
							goto IL_0cc8;
						case 70:
						case 71:
							goto IL_0d2b;
						case 72:
							goto IL_0d64;
						case 73:
							goto IL_0d9b;
						case 74:
							goto IL_0dcf;
						case 75:
						case 76:
						case 77:
							goto IL_0e35;
						case 78:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 79:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_0d9b:
					num2 = 73;
					val[val.Row, 43] = Strings.Format((object)Conversion.Val(val[val.Row, 25]), "0.00");
					goto IL_0dcf;
					IL_0dcf:
					num2 = 74;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 24]) * (1.0 + Conversion.Val(val[val.Row, 25]) / 100.0)), "0.00");
					goto IL_0e35;
					IL_0d64:
					num2 = 72;
					if (Conversion.Val(val[val.Row, 25]) != Conversion.Val(val[val.Row, 43]))
					{
						goto IL_0d9b;
					}
					goto IL_0e35;
					IL_0e35:
					val = null;
					break;
					IL_000c:
					num2 = 2;
					val = MSG;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					if (Conversion.Val(val[val.Row, 8]) != Conversion.Val(val[val.Row, 34]))
					{
						goto IL_0047;
					}
					goto IL_00c1;
					IL_0047:
					num2 = 4;
					val[val.Row, 34] = Strings.Format((object)Conversion.Val(val[val.Row, 8]), "0.000");
					goto IL_0079;
					IL_0079:
					num2 = 5;
					val[val.Row, 10] = Strings.Format((object)(Conversion.Val(val[val.Row, 8]) - Conversion.Val(val[val.Row, 9])), "0.000");
					goto IL_00c1;
					IL_00c1:
					num2 = 7;
					if ((Conversion.Val(val[val.Row, 9]) != 0.0) & (Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_010b;
					}
					goto IL_0153;
					IL_010b:
					num2 = 8;
					val[val.Row, 10] = Strings.Format((object)(Conversion.Val(val[val.Row, 8]) - Conversion.Val(val[val.Row, 9])), "0.000");
					goto IL_0153;
					IL_0153:
					num2 = 10;
					if (Conversion.Val(val[val.Row, 10]) != Conversion.Val(val[val.Row, 35]))
					{
						goto IL_018a;
					}
					goto IL_02d3;
					IL_018a:
					num2 = 11;
					val[val.Row, 35] = Strings.Format((object)Conversion.Val(val[val.Row, 10]), "0.000");
					goto IL_01be;
					IL_01be:
					num2 = 12;
					if ((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 14]) != 0.0) & (Conversion.Val(val[val.Row, 10]) != 0.0))
					{
						goto IL_021e;
					}
					goto IL_029c;
					IL_021e:
					num2 = 13;
					val[val.Row, 15] = Strings.Format((object)((Conversion.Val(val[val.Row, 10]) + Conversion.Val(val[val.Row, 12])) * (Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 14])) / 100.0), "0.000");
					goto IL_02d3;
					IL_029c:
					num2 = 15;
					val[val.Row, 15] = Strings.Format((object)Conversion.Val(val[val.Row, 10]), "0.000");
					goto IL_02d3;
					IL_02d3:
					num2 = 18;
					if ((Conversion.Val(val[val.Row, 11]) != 0.0) & (Conversion.Val(val[val.Row, 10]) != 0.0))
					{
						goto IL_031f;
					}
					goto IL_0373;
					IL_031f:
					num2 = 19;
					val[val.Row, 12] = Strings.Format((object)(Conversion.Val(val[val.Row, 10]) * Conversion.Val(val[val.Row, 11]) / 100.0), "0.000");
					goto IL_0373;
					IL_0373:
					num2 = 21;
					if (Conversion.Val(val[val.Row, 13]) != Conversion.Val(val[val.Row, 38]))
					{
						goto IL_03aa;
					}
					goto IL_04bc;
					IL_03aa:
					num2 = 22;
					val[val.Row, 38] = Strings.Format((object)Conversion.Val(val[val.Row, 13]), "0.00");
					goto IL_03de;
					IL_03de:
					num2 = 23;
					if ((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 14]) != 0.0) & (Conversion.Val(val[val.Row, 10]) != 0.0))
					{
						goto IL_043e;
					}
					goto IL_04bc;
					IL_043e:
					num2 = 24;
					val[val.Row, 15] = Strings.Format((object)((Conversion.Val(val[val.Row, 10]) + Conversion.Val(val[val.Row, 12])) * (Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 14])) / 100.0), "0.000");
					goto IL_04bc;
					IL_04bc:
					num2 = 27;
					if (Conversion.Val(val[val.Row, 14]) != Conversion.Val(val[val.Row, 39]))
					{
						goto IL_04f3;
					}
					goto IL_0605;
					IL_04f3:
					num2 = 28;
					val[val.Row, 39] = Strings.Format((object)Conversion.Val(val[val.Row, 14]), "0.00");
					goto IL_0527;
					IL_0527:
					num2 = 29;
					if ((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 14]) != 0.0) & (Conversion.Val(val[val.Row, 10]) != 0.0))
					{
						goto IL_0587;
					}
					goto IL_0605;
					IL_0587:
					num2 = 30;
					val[val.Row, 15] = Strings.Format((object)((Conversion.Val(val[val.Row, 10]) + Conversion.Val(val[val.Row, 12])) * (Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 14])) / 100.0), "0.000");
					goto IL_0605;
					IL_0605:
					num2 = 33;
					if (Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 14]) == 0.0)
					{
						goto IL_0640;
					}
					goto IL_068a;
					IL_0640:
					num2 = 34;
					val[val.Row, 15] = Strings.Format((object)(Conversion.Val(val[val.Row, 10]) + Conversion.Val(val[val.Row, 12])), "0.000");
					goto IL_068a;
					IL_068a:
					num2 = 36;
					if ((Conversion.Val(val[val.Row, 15]) == 0.0) & (Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 14]) != 0.0))
					{
						goto IL_06e7;
					}
					goto IL_0763;
					IL_06e7:
					num2 = 37;
					val[val.Row, 15] = Strings.Format((object)((Conversion.Val(val[val.Row, 10]) + Conversion.Val(val[val.Row, 12])) * (Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 14])) / 100.0), "0.000");
					goto IL_0763;
					IL_0763:
					num2 = 39;
					if ((Conversion.Val(val[val.Row, 21]) != 0.0) & (Conversion.Val(val[val.Row, 15]) != 0.0))
					{
						goto IL_07b3;
					}
					goto IL_095b;
					IL_07b3:
					num2 = 40;
					switch (val[val.Row, 30])
					{
					case "P":
						break;
					case "1":
						goto IL_084f;
					case "K":
						goto IL_08ad;
					default:
						goto IL_0908;
					}
					goto IL_07fc;
					IL_0908:
					num2 = 48;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 15]) * Conversion.Val(val[val.Row, 21]), 0), "0.00");
					goto IL_095b;
					IL_08ad:
					num2 = 46;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 15]) * (Conversion.Val(val[val.Row, 21]) / 1000.0), 0), "0.00");
					goto IL_095b;
					IL_084f:
					num2 = 44;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 15]) * (Conversion.Val(val[val.Row, 21]) / 10.0), 0), "0.00");
					goto IL_095b;
					IL_07fc:
					num2 = 42;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 7]) * Conversion.Val(val[val.Row, 21]), 0), "0.00");
					goto IL_095b;
					IL_095b:
					num2 = 51;
					if (Conversion.Val(val[val.Row, 18]) != 0.0)
					{
						goto IL_0989;
					}
					goto IL_0b4e;
					IL_0989:
					num2 = 52;
					switch (val[val.Row, 17])
					{
					case "P":
						break;
					case "N":
						goto IL_0a25;
					case "K":
						goto IL_0a8d;
					default:
						goto IL_0afc;
					}
					goto IL_09d2;
					IL_0afc:
					num2 = 60;
					val[val.Row, 19] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 8]) * Conversion.Val(val[val.Row, 18]), 0), "0.00");
					goto IL_0b4e;
					IL_0a8d:
					num2 = 58;
					val[val.Row, 19] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 10]) + Conversion.Val(val[val.Row, 12])) * (Conversion.Val(val[val.Row, 18]) / 1000.0), 0), "0.00");
					goto IL_0b4e;
					IL_0a25:
					num2 = 56;
					val[val.Row, 19] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 10]) + Conversion.Val(val[val.Row, 12])) * Conversion.Val(val[val.Row, 18]), 0), "0.00");
					goto IL_0b4e;
					IL_09d2:
					num2 = 54;
					val[val.Row, 19] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 7]) * Conversion.Val(val[val.Row, 18]), 0), "0.00");
					goto IL_0b4e;
					IL_0b4e:
					num2 = 63;
					if ((Operators.CompareString(DC_Main.SSRegSrNo, "AK004NEAK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "AK019NEAK", false) == 0))
					{
						goto IL_0b81;
					}
					goto IL_0c3b;
					IL_0b81:
					num2 = 64;
					val[val.Row, 23] = Strings.Format((object)(Conversion.Val(val[val.Row, 22]) + Conversion.Val(val[val.Row, 19]) + Conversion.Val(val[val.Row, 20])), "0.0");
					goto IL_0bdd;
					IL_0bdd:
					num2 = 65;
					val[val.Row, 24] = Strings.Format((object)(Conversion.Val(val[val.Row, 22]) + Conversion.Val(val[val.Row, 19]) + Conversion.Val(val[val.Row, 20])), "0.0");
					goto IL_0c3b;
					IL_0c3b:
					num2 = 67;
					if ((Conversion.Val(val[val.Row, 23]) != 0.0) & (Conversion.Val(val[val.Row, 25]) != Conversion.Val(val[val.Row, 43])))
					{
						goto IL_0c94;
					}
					goto IL_0d2b;
					IL_0c94:
					num2 = 68;
					val[val.Row, 43] = Strings.Format((object)Conversion.Val(val[val.Row, 25]), "0.00");
					goto IL_0cc8;
					IL_0cc8:
					num2 = 69;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) * (1.0 + Conversion.Val(val[val.Row, 25]) / 100.0)), "0.00");
					goto IL_0d2b;
					IL_0d2b:
					num2 = 71;
					if ((val[23] == 0) & (Conversion.Val(val[val.Row, 24]) != 0.0))
					{
						goto IL_0d64;
					}
					goto IL_0e35;
					end_IL_0001_2:
					break;
				}
				num2 = 78;
				MSG_TOT_FILL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 3986;
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

	private void WeightScal()
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
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
					if (Operators.CompareString(DC_Main.MsWeightPort, "0", false) != 0)
					{
						SerialPort1.BaudRate = 2400;
						SerialPort1.DataBits = 7;
						SerialPort1.Parity = (Parity)0;
						SerialPort1.StopBits = (StopBits)1;
						SerialPort1.PortName = DC_Main.MsWeightPort;
						SerialPort1.Open();
						Timer1.Start();
						WeightPortOpen = true;
					}
					goto end_IL_0001;
				case 182:
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
				try0001_dispatch = 182;
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

	private void TEXT_ENTRY_TextChanged(object sender, EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void TEXT_ENTRY_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Invalid comparison between Unknown and I4
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Invalid comparison between Unknown and I4
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Invalid comparison between Unknown and I4
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Invalid comparison between Unknown and I4
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Invalid comparison between Unknown and I4
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Invalid comparison between Unknown and I4
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Invalid comparison between Unknown and I4
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Invalid comparison between Unknown and I4
		//IL_045c: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Invalid comparison between Unknown and I4
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		//IL_050e: Invalid comparison between Unknown and I4
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_0840: Unknown result type (might be due to invalid IL or missing references)
		//IL_065a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1f: Unknown result type (might be due to invalid IL or missing references)
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
				List<DataRow> list = new List<DataRow>();
				checked
				{
					int num = DtIdtl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[DC_Main.M][25])) == Conversion.Val(mSG[mSG.Row, 29]))
						{
							list.Add(DtIdtl.Rows[DC_Main.M]);
						}
						DC_Main.M++;
					}
					foreach (DataRow item in list)
					{
						DtIdtl.Rows.Remove(item);
						DtIdtl.AcceptChanges();
					}
					int num2 = mSG.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num2)
					{
						mSG[mSG.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					TEXT_ENTRY.Text = "";
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else if ((int)keyCode == 112)
		{
			if (mSG.Col == 28)
			{
				DC_Main.RsQry = "SELECT AC_NAME As KarigarL,AC_SHORT as CodeL  FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_SHORT <> '' ORDER BY AC_NAME";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[3];
				DC_Main.ColWidth[0] = 400.0;
				DC_Main.ColWidth[1] = 100.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
					{
						TEXT_ENTRY.Text = DC_Main.ColValue[1];
						mSG[mSG.Row, 28] = DC_Main.ColValue[1];
					}
					((Control)TEXT_ENTRY).Focus();
				}
				return;
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
				if (Operators.CompareString(mSG[mSG.Row, mSG.Col], TEXT_ENTRY.Text, false) != 0)
				{
					MsTxtDelete = true;
				}
				if (mSG.Row > 1)
				{
					MsgOldRow = 0;
					if (MsTxtDelete)
					{
						MsTxtDelete = false;
					}
					else
					{
						UpDown = true;
						CommPassTotal();
					}
					mSG.Row = checked(mSG.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				if (Operators.CompareString(mSG[mSG.Row, mSG.Col], TEXT_ENTRY.Text, false) != 0)
				{
					MsTxtDelete = true;
				}
				checked
				{
					if (mSG.Row >= mSG.Rows - 1)
					{
						return;
					}
					MsgOldRow = 0;
					if (MsTxtDelete)
					{
						MsTxtDelete = false;
					}
					else
					{
						if (mSG.Col != 28)
						{
							UpDown = true;
						}
						CommPassTotal();
					}
					mSG.Row += 1;
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG.Col)
					{
					case 4:
						if (Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
						{
							break;
						}
						DC_Main.RsQry = "Select * From GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND GR_CODE = '" + TEXT_ENTRY.Text + "' ";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.GR_NAME As GroupNameL,A.GR_CODE as GrCodeL, A.GR_TYPE As ItTypeL FROM GROUP_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.GR_NAME";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[4];
							DC_Main.ColWidth[0] = 300.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.ColWidth[2] = 100.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[1];
									mSG[mSG.Row, 4] = DC_Main.ColValue[1];
									mSG[mSG.Row, 32] = DC_Main.ColValue[0];
									mSG[mSG.Row, 31] = DC_Main.ColValue[2];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 32] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["GR_NAME"], (object)""));
						mSG[mSG.Row, 31] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["GR_TYPE"], (object)""));
						break;
					case 3:
						if (Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
						{
							break;
						}
						DC_Main.RsQry = "SELECT MODEL_NAME  From MODEL_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND MODEL_NAME = '" + TEXT_ENTRY.Text + "' ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT DISTINCT MODEL_NAME as StyleL From MODEL_MAST ORDER BY MODEL_NAME";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[2];
							DC_Main.ColWidth[0] = 350.0;
							DC_Main.HelpSelect = 1;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (DC_Main.HelpClose)
							{
								return;
							}
							if (DC_Main.MsCreat)
							{
								MS_STYLE mS_STYLE = new MS_STYLE();
								DC_Main.MsUserRightForm = "Style";
								((Form)mS_STYLE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
								((Control)mS_STYLE).Show();
								((Control)mS_STYLE).Focus();
								return;
							}
							if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
							{
								TEXT_ENTRY.Text = DC_Main.ColValue[0];
								return;
							}
						}
						break;
					case 8:
						if ((Conversion.Val(TEXT_ENTRY.Text) == 0.0) & (Operators.CompareString(MSG[MSG.Row, 30], "P", false) != 0))
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						mSG[mSG.Row, 8] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
						CommPassTotal();
						((Control)TEXT_ENTRY).Visible = false;
						if (Operators.CompareString(FormMainBook, "JDTR TAG", false) == 0)
						{
							MSG_IDTL.Row = 1;
						}
						else
						{
							MSG_IDTL.Row = MSG_IDTL.Rows - 1;
						}
						MSG_IDTL.Col = 1;
						MSG_IDTL_EnterCell(MSG_IDTL, new EventArgs());
						((Control)TEXT_IDTL).Focus();
						((TextBoxBase)TEXT_IDTL).SelectAll();
						return;
					case 27:
						if (Operators.CompareString(TEXT_ENTRY.Text, "Y", false) == 0)
						{
							DC_Main.MsImageNo = DC_Main.MCo_code + "_" + tVchNo.Text + "_" + tPrCode.Text + "_" + MSG[MSG.Row, 2];
							DC_Main.MsImageType = "TagImage";
							DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
							if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) == 0)
							{
								UT_WEB_CAM uT_WEB_CAM = new UT_WEB_CAM();
								((Form)uT_WEB_CAM).MdiParent = ((Form)this).MdiParent;
								((Control)uT_WEB_CAM).Show();
								((Control)uT_WEB_CAM).Focus();
								return;
							}
						}
						break;
					case 28:
						if (Operators.CompareString(DC_Main.SSRegSrNo, "VK133NEVK", false) == 0)
						{
							DC_Main.RsQry = "SELECT AC_SHORT FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_SHORT = '" + TEXT_ENTRY.Text + "' AND AC_SHORT <> ''";
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Tbl.Rows.Count == 0)
							{
								DC_Main.RsQry = "SELECT AC_NAME As KarigarL,AC_SHORT as CodeL  FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_SHORT <> '' ORDER BY AC_NAME";
								DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.ColWidth = new double[3];
								DC_Main.ColWidth[0] = 400.0;
								DC_Main.ColWidth[1] = 100.0;
								DC_Main.HelpSelect = 1;
								((Form)MyProject.Forms.MS_HELP).ShowDialog();
								if (!DC_Main.HelpClose)
								{
									if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
									{
										TEXT_ENTRY.Text = DC_Main.ColValue[1];
										mSG[mSG.Row, 28] = DC_Main.ColValue[1];
									}
									((Control)TEXT_ENTRY).Focus();
								}
								return;
							}
						}
						if (mSG.Row == mSG.Rows - 1)
						{
							mSG[mSG.Row, 28] = TEXT_ENTRY.Text;
							MsgClear = true;
							mSG.Rows += 1;
							mSG.Row += 1;
							mSG.Col = 1;
							MsgClear = false;
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

	private void MS_DESIGN_BOOK_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0c43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c52: Expected O, but got Unknown
		//IL_0c77: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c86: Expected O, but got Unknown
		//IL_0cc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd4: Expected O, but got Unknown
		//IL_0cee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cfd: Expected O, but got Unknown
		//IL_0d17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d26: Expected O, but got Unknown
		//IL_0d67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d76: Expected O, but got Unknown
		//IL_0d95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da4: Expected O, but got Unknown
		//IL_0dc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd2: Expected O, but got Unknown
		//IL_0e58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e5f: Expected O, but got Unknown
		//IL_0ef0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eff: Expected O, but got Unknown
		//IL_0f87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f96: Expected O, but got Unknown
		//IL_1008: Unknown result type (might be due to invalid IL or missing references)
		//IL_100d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1013: Expected O, but got Unknown
		//IL_109b: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10aa: Expected O, but got Unknown
		//IL_10cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_10de: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		DC_Main.MsUserRightForm = "";
		if (dataTable.Rows.Count > 0)
		{
			UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));
			UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));
			UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr.Connect = DC_Main.CrConnect;
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
			((Control)MSG_IDTL).Top = ((Control)MSG_TOT).Top + 25;
			((Control)PicImage).Height = ((Control)MSG_IDTL).Height;
			((Control)PicImage).Top = ((Control)MSG_IDTL).Top;
			((Control)BtnImgC).Top = ((Control)PicImage).Top;
			((Control)BtnImgS).Top = ((Control)PicImage).Top + 48;
			((Control)BtnImgD).Top = ((Control)PicImage).Top + 96;
			((Form)this).ClientSize = new Size((int)Math.Round(DC_Main.MainPcW), (int)Math.Round(DC_Main.MainPcH));
			((Control)this).Dock = (DockStyle)5;
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
				AxMSFlexGrid mSG = MSG;
				object? obj7 = colorConverter.ConvertFromString("ControlLightLight");
				mSG.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				AxMSFlexGrid mSG2 = MSG;
				object? obj8 = colorConverter.ConvertFromString("DarkGray");
				mSG2.BackColorBkg = ((obj8 != null) ? ((Color)obj8) : default(Color));
				AxMSFlexGrid mSG3 = MSG;
				object? obj9 = colorConverter.ConvertFromString("255, 224, 192");
				mSG3.BackColorFixed = ((obj9 != null) ? ((Color)obj9) : default(Color));
				AxMSFlexGrid mSG_TOT = MSG_TOT;
				object? obj10 = colorConverter.ConvertFromString("Silver");
				mSG_TOT.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				AxMSFlexGrid mSG_TOT2 = MSG_TOT;
				object? obj11 = colorConverter.ConvertFromString("Silver");
				mSG_TOT2.BackColorBkg = ((obj11 != null) ? ((Color)obj11) : default(Color));
				AxMSFlexGrid mSG_TOT3 = MSG_TOT;
				object? obj12 = colorConverter.ConvertFromString("Silver");
				mSG_TOT3.BackColorFixed = ((obj12 != null) ? ((Color)obj12) : default(Color));
				AxMSFlexGrid mSG_IDTL = MSG_IDTL;
				object? obj13 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				AxMSFlexGrid mSG_IDTL2 = MSG_IDTL;
				object? obj14 = colorConverter.ConvertFromString("DarkGray");
				mSG_IDTL2.BackColorBkg = ((obj14 != null) ? ((Color)obj14) : default(Color));
				AxMSFlexGrid mSG_IDTL3 = MSG_IDTL;
				object? obj15 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_IDTL3.BackColorFixed = ((obj15 != null) ? ((Color)obj15) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj16 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj17 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj18 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj19 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj20 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj21 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj22 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj23 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG_IDTL4 = MSG_IDTL;
				object? obj24 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL4.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG_IDTL5 = MSG_IDTL;
				object? obj25 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_IDTL5.BackColorBkg = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG_IDTL6 = MSG_IDTL;
				object? obj26 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_IDTL6.BackColorFixed = ((obj26 != null) ? ((Color)obj26) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj27 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj28 = lblBook;
				object? obj29 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj28).ForeColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj30 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj31 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj32 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj33 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj34 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj35 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj36 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj36 != null) ? ((Color)obj36) : default(Color));
				AxMSFlexGrid mSG_IDTL7 = MSG_IDTL;
				object? obj37 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL7.BackColor = ((obj37 != null) ? ((Color)obj37) : default(Color));
				AxMSFlexGrid mSG_IDTL8 = MSG_IDTL;
				object? obj38 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_IDTL8.BackColorBkg = ((obj38 != null) ? ((Color)obj38) : default(Color));
				AxMSFlexGrid mSG_IDTL9 = MSG_IDTL;
				object? obj39 = colorConverter.ConvertFromString("Cornsilk");
				mSG_IDTL9.BackColorFixed = ((obj39 != null) ? ((Color)obj39) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj40 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj40 != null) ? ((Color)obj40) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				((TextBoxBase)TEXT_IDTL).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				((Control)TEXT_IDTL).Font = new Font(((Control)TEXT_IDTL).Font.FontFamily, (float)num3, ((Control)TEXT_IDTL).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_IDTL.Font = new Font("Segoe UI Semibold", (float)num3, MSG_IDTL.Font.Style);
				num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font.Style);
				((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
				((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
				((DataGridView)DGV).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV).ColumnHeadersHeight * (1.0 + num2));
				((DataGridView)DGV).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV).RowTemplate.Height * (1.0 + num2));
				Font font = ((Control)tVchNo).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton) && ((Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_IDTL", false) != 0) & (Operators.CompareString(val3.Name, "lblBook", false) != 0)))
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
			BtnCancel_Click(BtnCancel, new EventArgs());
			DGV_FILL();
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
		MsVchSrno = "";
		StkSaleVchDel = false;
		UsUPdate = "N";
		UsDelete = "N";
		((DataGridView)DGV).DataSource = null;
		ColorConverter colorConverter = new ColorConverter();
		SimpleButton btnSave = BtnSave;
		object? obj = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnSave).ForeColor = ((obj != null) ? ((Color)obj) : default(Color));
		SimpleButton btnDelete = BtnDelete;
		object? obj2 = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnDelete).ForeColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
		OldValTot = 0.0;
		NewValTot = 0.0;
		OldTagItm = "";
		PicImage.Image = null;
		DC_Main.MsImagePath = "";
		((Control)TEXT_ENTRY).Visible = false;
		((Control)TEXT_IDTL).Visible = false;
		((TextBoxBase)tVchNo).ReadOnly = false;
		((TextBoxBase)tPrCode).ReadOnly = false;
		MSG_CLEAR();
		MSG_IDTL_CLEAR();
		DGV_FILL();
		DtIdtl.Clear();
		DtIdtl.Reset();
		FilRow = 0;
		checked
		{
			int num = MSG_IDTL.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
				DC_Main.M++;
			}
			TmpEntryMode = "A";
			EntryMode = "A";
			((Control)tVchNo).Focus();
		}
	}

	private void DISPLAY_DATA()
	{
		TEXT_ENTRY.Text = "";
		((Control)TEXT_ENTRY).Visible = false;
		DC_Main.RsQry = "SELECT A.* FROM DESIGN_DETL AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND  A.PR_CODE = '" + tPrCode.Text + "' AND A.BOOK_NAME = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				MSG_CLEAR();
				MSG_IDTL_CLEAR();
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 29] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["OLD_SRNO"]);
					mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PAGE_NO"], (object)""));
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_STYLE"], (object)""));
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["GR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DIE_NO"], (object)""));
					mSG[DC_Main.i + 1, 7] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 17] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_COST"])), "0.00");
					mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 28] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 30] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 31] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 45] = Strings.Format((object)(Conversion.Val(mSG[DC_Main.i + 1, 7]) + Conversion.Val(mSG[DC_Main.i + 1, 8]) + Conversion.Val(mSG[DC_Main.i + 1, 15]) + Conversion.Val(mSG[DC_Main.i + 1, 19]) + Conversion.Val(mSG[DC_Main.i + 1, 20]) + Conversion.Val(mSG[DC_Main.i + 1, 26]) + Conversion.Val(mSG[DC_Main.i + 1, 16])), "0.000");
					string text = "";
					text = mSG[DC_Main.i + 1, 1] + mSG[DC_Main.i + 1, 2] + mSG[DC_Main.i + 1, 5] + mSG[DC_Main.i + 1, 3];
					mSG[DC_Main.i + 1, 46] = text;
					mSG[DC_Main.i + 1, 33] = "E";
					mSG.Rows += 1;
					DC_Main.i++;
				}
				mSG.Rows -= 1;
				mSG = null;
				MSG_TOT_FILL();
				DtIdtl.Clear();
				DtIdtl.Reset();
				FilRow = 0;
				int num = MSG_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM DESIGN_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND  A.PR_CODE = '" + tPrCode.Text + "' AND A.BOOK_NAME = '" + tVchNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
				{
					dr = DtIdtl.NewRow();
					dr[25] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["SR_NO"]);
					dr[0] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ISR_NO"]);
					dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
					dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
					dr[10] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
					dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS_WT"])), "0.000");
					dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					dr[27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
					dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_LESS_PRC"])), "0.00");
					dr[26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
					dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
					dr[16] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					dr[21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					dr[22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					dr[24] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					dr[28] = Strings.Format(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(dr[10], dr[14]), dr[12]), dr[13]), dr[21]), "0.000");
					DtIdtl.Rows.Add(dr);
					DC_Main.i++;
				}
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				OldValTot = Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 20]) + Conversion.Val(MSG_TOT[0, 19]) + Conversion.Val(MSG_TOT[0, 26]);
				NewValTot = Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 20]) + Conversion.Val(MSG_TOT[0, 19]) + Conversion.Val(MSG_TOT[0, 26]);
				OldTagItm = "";
				EntryMode = "E";
				TmpEntryMode = "E";
				MsVchSrno = "";
				((TextBoxBase)tVchNo).ReadOnly = true;
				MSG.Row = MSG.Rows - 1;
				MSG.Col = 1;
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
			}
			else
			{
				MSG.Row = MSG.Rows - 1;
				MSG.Col = 1;
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
			}
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (Operators.CompareString(DC_Main.MsTagVchAutoSave, "Y", false) == 0)
			{
				int num = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					if ((DC_Main.M == 1) & (Conversion.Val(MSG[DC_Main.M, 8]) + Conversion.Val(MSG[DC_Main.M, 26]) == 0.0))
					{
						((Form)this).Close();
						return;
					}
					if (Operators.CompareString(MSG[DC_Main.M, 33], "A", false) == 0)
					{
						Interaction.MsgBox((object)"Please Save Voucher Befoure Exit...", (MsgBoxStyle)0, (object)null);
						((Control)BtnSave).Enabled = true;
						((Control)BtnSave).Focus();
						return;
					}
					DC_Main.M++;
				}
			}
			((Form)this).Close();
		}
	}

	private void MS_DESIGN_BOOK_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_DESIGN_BOOK_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f92: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(UsUPdate, "Y", false) != 0 && ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0)))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(tVchNo.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Error Found : Please Enter Book Detail First...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			return;
		}
		DC_Main.MsTagVchSrnoUpdate = false;
		checked
		{
			int num = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				AxMSFlexGrid mSG = MSG;
				string text = "";
				text = mSG[DC_Main.i, 1] + mSG[DC_Main.i, 2] + mSG[DC_Main.i, 5] + mSG[DC_Main.i, 3];
				if ((Operators.CompareString(Strings.Format((object)Conversion.Val(mSG[DC_Main.i, 45]), "0.000"), Strings.Format((object)(Conversion.Val(mSG[DC_Main.i, 7]) + Conversion.Val(mSG[DC_Main.i, 8]) + Conversion.Val(mSG[DC_Main.i, 15]) + Conversion.Val(mSG[DC_Main.i, 19]) + Conversion.Val(mSG[DC_Main.i, 20]) + Conversion.Val(mSG[DC_Main.i, 26]) + Conversion.Val(mSG[DC_Main.i, 16])), "0.000"), false) != 0) | (Operators.CompareString(mSG[DC_Main.i, 46], text, false) != 0))
				{
					DC_Main.RsQry = "DELETE FROM DESIGN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  PR_CODE = '" + tPrCode.Text + "' AND BOOK_NAME = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG[DC_Main.i, 0])) + " ";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.RsQry = "SELECT * FROM DESIGN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + tPrCode.Text + "' AND BOOK_NAME = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG[DC_Main.i, 0])) + " ";
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow = RsDetl.NewRow();
					if ((Operators.CompareString(tPrCode.Text, "", false) != 0) & (Operators.CompareString(mSG[DC_Main.i, 2], "", false) != 0) & (Conversion.Val(mSG[DC_Main.i, 26]) + Conversion.Val(mSG[DC_Main.i, 8]) != 0.0))
					{
						dataRow["CO_CODE"] = DC_Main.MCo_code;
						dataRow["BOOK_NAME"] = tVchNo.Text;
						dataRow["PR_CODE"] = tPrCode.Text;
						if (Operators.CompareString(mSG[DC_Main.i, 44], "", false) == 0)
						{
							dataRow["VCH_DATE"] = DC_Main.MsSysDate;
						}
						else
						{
							dataRow["VCH_DATE"] = mSG[DC_Main.i, 44];
						}
						dataRow["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
						dataRow["OLD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 29]);
						dataRow["PAGE_NO"] = mSG[DC_Main.i, 1];
						dataRow["DESIGN_NO"] = mSG[DC_Main.i, 2];
						dataRow["ITM_STYLE"] = mSG[DC_Main.i, 3];
						dataRow["GR_CODE"] = mSG[DC_Main.i, 4];
						dataRow["ITM_SIZE"] = mSG[DC_Main.i, 5];
						dataRow["DIE_NO"] = mSG[DC_Main.i, 6];
						dataRow["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 7]);
						dataRow["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 8]);
						dataRow["ITM_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 9]);
						dataRow["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 10]);
						dataRow["ITM_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 13]);
						dataRow["ITM_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 14]);
						dataRow["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 15]);
						dataRow["LBR_PRC"] = Conversion.Val(mSG[DC_Main.i, 16]);
						dataRow["LBR_TYPE"] = mSG[DC_Main.i, 17];
						dataRow["LBR_RATE"] = Conversion.Val(mSG[DC_Main.i, 18]);
						dataRow["LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 19]);
						dataRow["OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 20]);
						dataRow["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 21]);
						dataRow["ITM_AMT"] = Conversion.Val(mSG[DC_Main.i, 22]);
						dataRow["ITM_MRP"] = Conversion.Val(mSG[DC_Main.i, 26]);
						dataRow["KR_NAME"] = mSG[DC_Main.i, 28];
						dataRow["RATE_TYPE"] = mSG[DC_Main.i, 30];
						dataRow["IT_TYPE"] = mSG[DC_Main.i, 31];
						dataRow["DESIGN_IMG_ID"] = DC_Main.MCo_code + "_" + tVchNo.Text + "_" + tPrCode.Text + "_" + MSG[DC_Main.i, 2];
						dataRow["MAIN_USER"] = MainUser;
						RsDetl.Rows.Add(dataRow);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						RsDetl.Clear();
					}
				}
				mSG = null;
				DC_Main.i++;
			}
			int num2 = 0;
			int num3 = DtIdtl.Rows.Count - 1;
			for (int i = 0; i <= num3; i++)
			{
				DataTable dtIdtl = DtIdtl;
				if (Operators.CompareString(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][28])), "0.000"), Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][14])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][13])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][21]))), "0.000"), false) != 0)
				{
					int num4 = MSG.Rows - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num4)
					{
						if (Conversion.Val(MSG[DC_Main.M, 29]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][25])))
						{
							num2 = DC_Main.M;
							break;
						}
						DC_Main.M++;
					}
					DC_Main.RsQry = ("DELETE FROM DESIGN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  PR_CODE = '" + tPrCode.Text + "' AND BOOK_NAME = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(num2) + " AND ISR_NO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])))) ?? "";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.RsQry = ("Select * FROM DESIGN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  PR_CODE = '" + tPrCode.Text + "' AND BOOK_NAME = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(num2) + " AND ISR_NO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])))) ?? "";
					RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow2 = RsIdtl.NewRow();
					dataRow2["CO_CODE"] = DC_Main.MCo_code;
					dataRow2["PR_CODE"] = tPrCode.Text;
					dataRow2["BOOK_NAME"] = tVchNo.Text;
					dataRow2["SR_NO"] = Conversion.Val(MSG[num2, 29]);
					dataRow2["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0]));
					dataRow2["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][1]);
					dataRow2["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10]));
					dataRow2["IT_PCS_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][11]));
					dataRow2["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][14]));
					dataRow2["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12]));
					dataRow2["KR_LESS_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][13]));
					dataRow2["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15]));
					dataRow2["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16]);
					dataRow2["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][17]));
					dataRow2["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][18]));
					dataRow2["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19]));
					dataRow2["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]));
					dataRow2["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][21]));
					dataRow2["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][22]));
					dataRow2["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][24]);
					dataRow2["MAIN_USER"] = MainUser;
					RsIdtl.Rows.Add(dataRow2);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
					RsIdtl.Clear();
				}
				dtIdtl = null;
			}
			if (Operators.CompareString(FormVchNo, "", false) != 0)
			{
				CLEAR_DATA();
				((Form)this).Close();
				return;
			}
			Interaction.MsgBox((object)"Data Are Save....", (MsgBoxStyle)0, (object)null);
			CurPrnVch = tVchNo.Text;
			CLEAR_DATA();
			CurPrnVch = "";
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Invalid comparison between Unknown and I4
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UsDelete, "Y", false) != 0 && Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) != 0 && !StkSaleVchDel)
		{
			DC_Main.RsQry = "SELECT * FROM  MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO IN (SELECT TAG_NO FROM DESIGN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "') AND ITM_SIGN = '-'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				Interaction.MsgBox((object)"You Cant Delete This Voucher Because  Tag Use in Sales Transection....", (MsgBoxStyle)0, (object)null);
				return;
			}
		}
		if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.ExeQuteDc("DELETE FROM DESIGN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + tPrCode.Text + "' AND BOOK_NAME = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DESIGN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + tPrCode.Text + "' AND BOOK_NAME = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void MS_DESIGN_BOOK_KeyDown(object sender, KeyEventArgs e)
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

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (Operators.CompareString(DC_Main.MsTagVchAutoSave, "Y", false) == 0 && MSG.Row != 1)
			{
				int num = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					if ((Operators.CompareString(MSG[DC_Main.M, 33], "A", false) == 0) & (Conversion.Val(MSG[DC_Main.M, 26]) + Conversion.Val(MSG[DC_Main.M, 8]) != 0.0))
					{
						Interaction.MsgBox((object)"Please Save Voucher Befoure Exit...", (MsgBoxStyle)0, (object)null);
						((Control)BtnSave).Enabled = true;
						((Control)BtnSave).Focus();
						return;
					}
					DC_Main.M++;
				}
			}
			CLEAR_DATA();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void MS_DESIGN_BOOK_Activated(object sender, EventArgs e)
	{
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
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
			((Control)tPrCode).Focus();
			return;
		}
		if ((Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath ?? "", (FileAttribute)0), "", false) != 0) & (Operators.CompareString(DC_Main.MsImagePath, "", false) != 0))
		{
			Image val = Image.FromFile(DC_Main.MsImagePath);
			PicImage.Image = (Image)new Bitmap(val);
			val.Dispose();
			Mobile_image_Save(MSG.Row);
		}
		else
		{
			PicImage.Image = null;
		}
		((ContainerControl)this).ActiveControl = CurActCtrl;
		CurActCtrl.Focus();
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT BOOK_NAME As DesignBookL,PR_CODE As PrCodeL,COUNT (*) As TotDesignM FROM DESIGN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY BOOK_NAME,PR_CODE  ORDER BY BOOK_NAME,PR_CODE";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[4];
		DC_Main.ColWidth[0] = 250.0;
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[2] = 130.0;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				CLEAR_DATA();
				tVchNo.Text = DC_Main.ColValue[0];
				DGV_FILL();
				((Control)tPrCode).Focus();
			}
			else
			{
				((Control)tVchNo).Focus();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void MSG_RowColChange(object sender, EventArgs e)
	{
		//IL_0a28: Unknown result type (might be due to invalid IL or missing references)
		//IL_097d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0987: Expected O, but got Unknown
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
					{
						if (MSG.Row == 0 || !((MsgOldRow != MSG.Row) & !MsgClear))
						{
							goto end_IL_0001;
						}
						MsgOldRow = MSG.Row;
						MSG_IDTL_CLEAR();
						double num3 = 0.0;
						double num4 = 0.0;
						double num5 = 0.0;
						int num6 = 1;
						int num7 = DtIdtl.Rows.Count - 1;
						for (int i = 0; i <= num7; i++)
						{
							if (Conversion.Val(MSG[MSG.Row, 29]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][25])))
							{
								MSG_IDTL[num6, 0] = Conversions.ToString(num6);
								MSG_IDTL[num6, 1] = Conversions.ToString(DtIdtl.Rows[i][1]);
								MSG_IDTL[num6, 2] = Conversions.ToString(DtIdtl.Rows[i][2]);
								MSG_IDTL[num6, 3] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][3], (object)""));
								MSG_IDTL[num6, 4] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][4], (object)""));
								MSG_IDTL[num6, 5] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][5], (object)""));
								MSG_IDTL[num6, 6] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][6], (object)""));
								MSG_IDTL[num6, 7] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][7], (object)""));
								MSG_IDTL[num6, 8] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][8], (object)""));
								MSG_IDTL[num6, 9] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][9], (object)""));
								MSG_IDTL[num6, 10] = Conversions.ToString(DtIdtl.Rows[i][10]);
								MSG_IDTL[num6, 11] = Conversions.ToString(0);
								MSG_IDTL[num6, 14] = Conversions.ToString(DtIdtl.Rows[i][14]);
								MSG_IDTL[num6, 12] = Conversions.ToString(DtIdtl.Rows[i][12]);
								MSG_IDTL[num6, 13] = Conversions.ToString(DtIdtl.Rows[i][13]);
								MSG_IDTL[num6, 15] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][15], (object)""));
								MSG_IDTL[num6, 16] = Conversions.ToString(DtIdtl.Rows[i][16]);
								MSG_IDTL[num6, 17] = Conversions.ToString(DtIdtl.Rows[i][17]);
								MSG_IDTL[num6, 18] = Conversions.ToString(DtIdtl.Rows[i][18]);
								MSG_IDTL[num6, 19] = Conversions.ToString(DtIdtl.Rows[i][19]);
								MSG_IDTL[num6, 20] = Conversions.ToString(DtIdtl.Rows[i][20]);
								MSG_IDTL[num6, 21] = Conversions.ToString(DtIdtl.Rows[i][21]);
								MSG_IDTL[num6, 22] = Conversions.ToString(DtIdtl.Rows[i][22]);
								MSG_IDTL[num6, 23] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][23], (object)""));
								MSG_IDTL[num6, 24] = Conversions.ToString(DtIdtl.Rows[i][24]);
								MSG_IDTL[num6, 25] = Conversions.ToString(DtIdtl.Rows[i][25]);
								MSG_IDTL[num6, 26] = Conversions.ToString(DtIdtl.Rows[i][26]);
								MSG_IDTL[num6, 27] = Conversions.ToString(DtIdtl.Rows[i][27]);
								MSG_IDTL[num6, 28] = Conversions.ToString(DtIdtl.Rows[i][28]);
								num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][21]));
								num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][22]));
								num5 += Conversion.Val(Operators.ConcatenateObject(DtIdtl.Rows[i][23], (object)""));
								MSG_IDTL.Rows += 1;
								num6++;
							}
						}
						if (num4 != 0.0)
						{
							MSG[MSG.Row, 9] = Strings.Format((object)num4, "0.000");
							MSG[MSG.Row, 10] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 8]) - Conversion.Val(MSG[MSG.Row, 9])), "0.000");
						}
						if (num3 != 0.0)
						{
							MSG[MSG.Row, 20] = Strings.Format((object)num3, "0.00");
						}
						CommPassTotal();
						ProjectData.ClearProjectError();
						num2 = 2;
						DC_Main.MsImageNo = DC_Main.MCo_code + "_" + tVchNo.Text + "_" + tPrCode.Text + "_" + MSG[MSG.Row, 2];
						DC_Main.MsImageType = "TagImage";
						DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
						DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + DC_Main.MsImageNo + "'";
						RsImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
						if (RsImg.Rows.Count > 0)
						{
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
							{
								PicImage.Image = null;
								goto end_IL_0001;
							}
							object obj = Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)"");
							byte[] bA = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj));
							object objectValue = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA));
							PicImage.Image = (Image)objectValue;
						}
						else if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
						{
							PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
						}
						else
						{
							PicImage.Image = null;
						}
						MSG_IDTL[num6, 0] = Conversions.ToString(num6);
						MSG_IDTL[num6, 25] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 29]));
						goto end_IL_0001;
					}
					case 2608:
						num = -1;
						switch (num2)
						{
						case 2:
							Interaction.MsgBox((object)"Please Check NextImage Data ...", (MsgBoxStyle)0, (object)null);
							goto end_IL_0001;
						}
						break;
					}
				}
			}
			catch (object obj2) when (obj2 is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj2);
				try0001_dispatch = 2608;
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

	private void tVchNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			BtnF1_Click(BtnF1, new EventArgs());
		}
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tVchNo.Text, "", false) != 0)
		{
			DC_Main.RsQry = "SELECT BOOK_NAME FROM DESIGN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND BOOK_NAME = '" + tVchNo.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				if ((int)Interaction.MsgBox((object)"Add New Design Book ? ", (MsgBoxStyle)292, (object)"Message") == 6)
				{
					((Control)tPrCode).Focus();
				}
				else
				{
					BtnF1_Click(BtnF1, new EventArgs());
				}
			}
			else
			{
				DGV_FILL();
				((Control)tPrCode).Focus();
			}
		}
		else
		{
			((Control)tVchNo).Focus();
		}
	}

	private void DGV_FILL()
	{
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Expected O, but got Unknown
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected O, but got Unknown
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.BOOK_NAME,A.PR_CODE,B.PR_NAME,COUNT(*) As Design FROM DESIGN_DETL AS A LEFT JOIN PRODUCT_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.PR_CODE = B.PR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tVchNo.Text, "", false) == 0, (object)"", (object)("AND A.BOOK_NAME = '" + tVchNo.Text + "'"))), (object)" GROUP BY A.BOOK_NAME,A.PR_CODE,B.PR_NAME ORDER BY A.BOOK_NAME,A.PR_CODE "));
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(DC_Main.Tbl);
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
				((DataGridView)DGV).ColumnCount = 4;
				((DataGridView)DGV).Columns[0].Width = (int)Math.Round(125.0 * ColCon);
				((DataGridView)DGV).Columns[0].DataPropertyName = "BOOK_NAME";
				((DataGridView)DGV).Columns[0].HeaderText = "Book";
				((DataGridView)DGV).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV).Columns[1].DataPropertyName = "PR_CODE";
				((DataGridView)DGV).Columns[1].HeaderText = "Code";
				((DataGridView)DGV).Columns[2].Width = (int)Math.Round(225.0 * ColCon);
				((DataGridView)DGV).Columns[2].DataPropertyName = "PR_NAME";
				((DataGridView)DGV).Columns[2].HeaderText = "Product";
				((DataGridView)DGV).Columns[3].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV).Columns[3].DataPropertyName = "Design";
				((DataGridView)DGV).Columns[3].HeaderText = "Design";
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				((DataGridView)DGV).DataSource = dataView;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgC_Click(object sender, EventArgs e)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
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
				case 154:
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
				try0001_dispatch = 154;
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
	private void BtnImgS_Click(object sender, EventArgs e)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Invalid comparison between Unknown and I4
		//IL_060f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected O, but got Unknown
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Expected O, but got Unknown
		//IL_0564: Unknown result type (might be due to invalid IL or missing references)
		//IL_056b: Expected O, but got Unknown
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
					((FileDialog)DlgOpen).Filter = "JPEG (*.jpg)|*.jpg";
					((FileDialog)DlgOpen).Title = "Open Image File";
					if ((int)((CommonDialog)DlgOpen).ShowDialog() != 1)
					{
						goto end_IL_0001;
					}
					DC_Main.MsImageNo = DC_Main.MCo_code + "_" + tVchNo.Text + "_" + tPrCode.Text + "_" + MSG[MSG.Row, 2];
					DC_Main.MsImageType = "TagImage";
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						if (PicImage.Image != null)
						{
							PicImage.Image.Dispose();
							PicImage.Image = null;
						}
						FileSystem.Kill(DC_Main.MsImagePath);
					}
					PicImage.Image = Image.FromFile(((FileDialog)DlgOpen).FileName);
					if (Operators.CompareString(FileSystem.Dir(Application.StartupPath + "\\temp.jpg", (FileAttribute)0), "", false) != 0)
					{
						FileSystem.Kill(Application.StartupPath + "\\temp.jpg");
					}
					float num3 = float.Parse(Conversions.ToString(1));
					Bitmap val = new Bitmap(PicImage.Image);
					int width = ((Image)val).Width;
					num3 = ((width > 5000) ? float.Parse(Conversions.ToString(0.5)) : ((width > 4500) ? float.Parse(Conversions.ToString(0.6)) : ((width > 4000) ? float.Parse(Conversions.ToString(0.7)) : ((width > 3500) ? float.Parse(Conversions.ToString(0.8)) : ((width > 3000) ? float.Parse(Conversions.ToString(0.75)) : ((width > 2500) ? float.Parse(Conversions.ToString(0.8)) : ((width <= 2000) ? float.Parse(Conversions.ToString(1)) : float.Parse(Conversions.ToString(0.9)))))))));
					checked
					{
						Bitmap val2 = new Bitmap((int)Math.Round((float)((Image)val).Width * num3), (int)Math.Round((float)((Image)val).Height * num3));
						Graphics val3 = Graphics.FromImage((Image)(object)val2);
						val3.SmoothingMode = (SmoothingMode)2;
						val3.InterpolationMode = (InterpolationMode)7;
						val3.PixelOffsetMode = (PixelOffsetMode)2;
						val3.DrawImage((Image)(object)val, 0, 0, ((Image)val2).Width + 1, ((Image)val2).Height + 1);
						PicImage.Image = (Image)(object)val2;
						PicImage.Image.Save(Application.StartupPath + "\\temp.jpg");
						long num4 = FileSystem.FileLen(Application.StartupPath + "\\temp.jpg");
						string text;
						if (num4 < 1000)
						{
							text = " Bytes";
						}
						else if (num4 > 1000000)
						{
							num4 = (long)Conversion.Int((double)num4 / 1000000.0);
							text = " Mb";
						}
						else
						{
							num4 = (long)Conversion.Int((double)num4 / 1000.0);
							text = " Kb";
						}
						string text2 = Conversions.ToString(num4) + text;
						int num5 = 100;
						if (Operators.CompareString(text, " Kb", false) != 0)
						{
							double num6 = Conversion.Val((object)num4);
							num5 = ((num6 > 30.0) ? 20 : ((num6 > 25.0) ? 30 : ((num6 > 20.0) ? 35 : ((num6 > 15.0) ? 40 : ((num6 > 10.0) ? 50 : ((num6 > 7.0) ? 55 : ((num6 > 5.0) ? 70 : ((num6 > 3.0) ? 75 : ((num6 > 2.0) ? 80 : ((!(num6 > 1.0)) ? 90 : 85))))))))));
						}
						Bitmap val4 = (Bitmap)Image.FromFile(Application.StartupPath + "\\temp.jpg");
						Ac_Image.SaveJPGWithCompressionSetting(PicImage.Image, DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg", num5);
						((Image)val4).Dispose();
						PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
						Mobile_image_Save(MSG.Row);
						goto end_IL_0001;
					}
				}
				case 1559:
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
				try0001_dispatch = 1559;
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
	private void BtnImgD_Click(object sender, EventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
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
					if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Image now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
					{
						DC_Main.MsImageNo = DC_Main.MCo_code + "_" + tVchNo.Text + "_" + tPrCode.Text + "_" + MSG[MSG.Row, 2];
						DC_Main.RsQry = "DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + DC_Main.MCo_code + "_" + tVchNo.Text + "_" + tPrCode.Text + "_" + MSG[MSG.Row, 2] + "' ";
						DC_Main.ExeQuteImg(DC_Main.RsQry);
						DC_Main.MsImageType = "TagImage";
						DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
						if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
						{
							PicImage.Image.Dispose();
							PicImage.Image = null;
							FileSystem.Kill(DC_Main.MsImagePath);
						}
					}
					goto end_IL_0001;
				case 495:
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
				try0001_dispatch = 495;
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

	private void MSG_Scroll(object sender, EventArgs e)
	{
		if (MSG_TOT.LeftCol != MSG.LeftCol)
		{
			MSG_TOT.LeftCol = MSG.LeftCol;
			MSG_TOT.ScrollTrack = MSG.LeftCol != 0;
		}
	}

	private void MS_DESIGN_BOOK_Closed(object sender, EventArgs e)
	{
		FormVchNo = "";
		DC_Main.MsImagePath = "";
		DC_Main.MsTagVchSrnoUpdate = false;
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void Mobile_image_Save(int ImgRow)
	{
		AxMSFlexGrid mSG = MSG;
		DC_Main.MsImageNo = DC_Main.MCo_code + "_" + tVchNo.Text + "_" + tPrCode.Text + "_" + MSG[MSG.Row, 2];
		DC_Main.MsImageType = "TagImage";
		DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
		if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
		{
			PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
			MemoryStream memoryStream = new MemoryStream();
			PicImage.Image.Save((Stream)memoryStream, PicImage.Image.RawFormat);
			byte[] buffer = memoryStream.GetBuffer();
			string value = Convert.ToBase64String(buffer);
			DC_Main.RsQry = "DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + DC_Main.MCo_code + "_" + tVchNo.Text + "_" + tPrCode.Text + "_" + MSG[MSG.Row, 2] + "' ";
			DC_Main.ExeQuteImg(DC_Main.RsQry);
			DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + DC_Main.MCo_code + "_" + tVchNo.Text + "_" + tPrCode.Text + "_" + MSG[MSG.Row, 2] + "' ";
			RsImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow = RsImg.NewRow();
			dataRow["CO_CODE"] = DC_Main.MCo_code;
			dataRow["LC_CODE"] = DC_Main.MLc_code;
			dataRow["TAG_NO"] = DC_Main.MCo_code + "_" + tVchNo.Text + "_" + tPrCode.Text + "_" + MSG[MSG.Row, 2];
			dataRow["IMAGE_TYPE"] = "D";
			dataRow["MOB_IMAGE"] = value;
			RsImg.Rows.Add(dataRow);
			((DbDataAdapter)(object)DC_Main.Da).Update(RsImg);
			RsImg.Clear();
		}
		mSG = null;
	}

	private void lblBook_DoubleClick(object sender, EventArgs e)
	{
		((Control)tHdVchNo).Visible = true;
	}

	~MS_DESIGN_BOOK()
	{
		((Component)this).Finalize();
	}

	private void MS_DESIGN_BOOK_KeyUp(object sender, KeyEventArgs e)
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
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Invalid comparison between Unknown and I4
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Invalid comparison between Unknown and I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Invalid comparison between Unknown and I4
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Invalid comparison between Unknown and I4
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Invalid comparison between Unknown and I4
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_ENTRY", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_ENTRY).SelectionStart = 0;
			((TextBoxBase)TEXT_ENTRY).SelectionLength = Strings.Len(TEXT_ENTRY.Text);
		}
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_IDTL", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_IDTL).SelectionStart = 0;
			((TextBoxBase)TEXT_IDTL).SelectionLength = Strings.Len(TEXT_IDTL.Text);
		}
	}

	private void BtnExel_Click(object sender, EventArgs e)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		((Control)this).Cursor = Cursors.WaitCursor;
		object objectValue = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("Excel.Application", ""));
		object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, (Type)null, "Workbooks", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Add", new object[0], (string[])null, (Type[])null, (bool[])null));
		object objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, (Type)null, "Sheets", new object[1] { 1 }, (string[])null, (Type[])null, (bool[])null));
		objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, (Type)null, "Sheets", new object[1] { "sheet1" }, (string[])null, (Type[])null, (bool[])null));
		NewLateBinding.LateSet(objectValue3, (Type)null, "Cells", new object[3] { 1, 1, "Sheet 1 content" }, (string[])null, (Type[])null);
		int num = 0;
		checked
		{
			do
			{
				NewLateBinding.LateSet(objectValue3, (Type)null, "Cells", new object[3]
				{
					1,
					num + 1,
					MSG[0, num]
				}, (string[])null, (Type[])null);
				num++;
			}
			while (num <= 28);
			int num2 = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num2)
			{
				int num3 = 0;
				do
				{
					NewLateBinding.LateSet(objectValue3, (Type)null, "Cells", new object[3]
					{
						DC_Main.i + 1,
						num3 + 1,
						MSG[DC_Main.i, num3]
					}, (string[])null, (Type[])null);
					num3++;
				}
				while (num3 <= 28);
				DC_Main.i++;
			}
			ColorConverter colorConverter = new ColorConverter();
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS124NEVS", false) == 0)
			{
				string text = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\TagEntry.xlsx";
				object obj = objectValue3;
				object[] obj2 = new object[1] { text };
				object[] array = obj2;
				bool[] obj3 = new bool[1] { true };
				bool[] array2 = obj3;
				NewLateBinding.LateCall(obj, (Type)null, "SaveAs", obj2, (string[])null, (Type[])null, obj3, true);
				if (array2[0])
				{
					text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
				}
				NewLateBinding.LateCall(NewLateBinding.LateGet(objectValue, (Type)null, "Workbooks", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Close", new object[0], (string[])null, (Type[])null, (bool[])null, true);
				NewLateBinding.LateCall(objectValue, (Type)null, "Quit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
				((Control)this).Cursor = Cursors.Default;
			}
			else
			{
				NewLateBinding.LateSet(objectValue, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
				NewLateBinding.LateCall(objectValue, (Type)null, "Quit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
				objectValue3 = null;
				objectValue2 = null;
				objectValue = null;
				GC.Collect();
				((Control)this).Cursor = Cursors.Default;
			}
		}
	}

	private void tPrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND PR_CODE = '" + tPrCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT PR_NAME As PrNameL,PR_CODE as PrCodeL FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY PR_NAME";
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
			DISPLAY_DATA();
		}
	}

	private void NewTagNo(int Y)
	{
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		MSG_CLEAR();
		MSG_IDTL_CLEAR();
		tPrCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[1].Value);
		tPrName.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[2].Value);
		tVchNo.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
		DISPLAY_DATA();
		DGV_FILL();
		((TextBoxBase)tVchNo).ReadOnly = true;
		((TextBoxBase)tPrCode).ReadOnly = true;
		((Control)tVchNo).Focus();
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

	private void BtnExelImport_Click(object sender, EventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Invalid comparison between Unknown and I4
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Invalid comparison between Unknown and I4
		//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(tPrCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Product First And try..", (MsgBoxStyle)0, (object)null);
			((Control)tPrCode).Focus();
			return;
		}
		if (Operators.CompareString(tVchNo.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Book Name First And try..", (MsgBoxStyle)0, (object)null);
			((Control)tPrCode).Focus();
			return;
		}
		int num = checked(MSG.Rows - 1);
		string text = "001";
		int num2 = 1;
		if ((int)Interaction.MsgBox((object)"Are You Sure To Import Data In Next Software ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
		{
			return;
		}
		((FileDialog)DlgOpen).Filter = "Excel files |*.xls;*.xlsx";
		((FileDialog)DlgOpen).Title = "Open File";
		if ((int)((CommonDialog)DlgOpen).ShowDialog() != 1)
		{
			return;
		}
		DC_Main.Tbl = ImportExceltoDatatable(((FileDialog)DlgOpen).FileName);
		checked
		{
			int num3 = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.i = 0;
			while (DC_Main.i <= num3)
			{
				num2++;
				if (num2 == 4)
				{
					string text2 = Conversions.ToString(NewLateBinding.LateGet((object)null, typeof(Strings), "UCase", new object[1] { Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][2], (object)"") }, (string[])null, (Type[])null, (bool[])null));
					if (Operators.CompareString(text2, "", false) == 0)
					{
						text2 = Conversions.ToString(NewLateBinding.LateGet((object)null, typeof(Strings), "UCase", new object[1] { Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][3], (object)"") }, (string[])null, (Type[])null, (bool[])null));
					}
					if (Operators.CompareString(text2, "", false) == 0)
					{
						text2 = Conversions.ToString(NewLateBinding.LateGet((object)null, typeof(Strings), "UCase", new object[1] { Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][4], (object)"") }, (string[])null, (Type[])null, (bool[])null));
					}
					if (Operators.CompareString(text2, "", false) == 0)
					{
						text2 = Conversions.ToString(NewLateBinding.LateGet((object)null, typeof(Strings), "UCase", new object[1] { Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][5], (object)"") }, (string[])null, (Type[])null, (bool[])null));
					}
					if (Operators.CompareString(text2, "", false) == 0)
					{
						text2 = Conversions.ToString(NewLateBinding.LateGet((object)null, typeof(Strings), "UCase", new object[1] { Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][6], (object)"") }, (string[])null, (Type[])null, (bool[])null));
					}
					if (Operators.CompareString(text2, "", false) == 0)
					{
						text2 = Conversions.ToString(NewLateBinding.LateGet((object)null, typeof(Strings), "UCase", new object[1] { Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i][7], (object)"") }, (string[])null, (Type[])null, (bool[])null));
					}
					if (Operators.CompareString(text2, "G.W.", false) != 0)
					{
						text = Strings.Format((object)Math.Round((double)num / 50.0 + 1.0), "00");
						DC_Main.RsQry = "INSERT INTO DESIGN_DETL(CO_CODE,BOOK_NAME,PR_CODE,SR_NO,OLD_SRNO,PAGE_NO,VCH_DATE,GR_CODE,  DESIGN_NO,ITM_SIZE,DIE_NO,ITM_PCS,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,ITM_RATE,ITM_AMT,  LBR_TYPE,LBR_PRC,LBR_RATE,LBR_AMT,OTH_AMT,TAG_COST,ITM_MRP,GHT_PRC,ITM_GHT,NET_AMT,RATE_TYPE,IT_TYPE,KR_NAME,MAIN_USER)  VALUES  ('" + DC_Main.MCo_code + "','" + tVchNo.Text + "','" + tPrCode.Text + "'," + Conversions.ToString(num) + "," + Conversions.ToString(num) + ",'" + text + "','" + Conversions.ToString(DC_Main.MsSysDate) + "','',  '" + text2 + "','','',0,0,0,0,0,0,0,0,0,  '',0,0,0,0,0,0,0,0,0,'','','','" + DC_Main.MCo_User + "')";
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						MSG[num, 2] = text2;
						num2 = 0;
						AxMSFlexGrid mSG;
						(mSG = MSG).Rows = mSG.Rows + 1;
						num++;
					}
				}
				Application.DoEvents();
				DC_Main.i++;
			}
			Interaction.MsgBox((object)"Data is Import Ok....", (MsgBoxStyle)0, (object)null);
			Application.Exit();
		}
	}

	private void FlowLayoutPanel1_DoubleClick(object sender, EventArgs e)
	{
		((Control)btnExelImport).Visible = true;
	}

	private void tVchNo_TextChanged(object sender, EventArgs e)
	{
	}

	private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void tPrCode_TextChanged(object sender, EventArgs e)
	{
	}
}
