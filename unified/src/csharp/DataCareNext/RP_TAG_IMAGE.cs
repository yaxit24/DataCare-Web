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
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxCrystal;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevNet.Models;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class RP_TAG_IMAGE : XtraForm
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExit")]
	private SimpleButton _BtnExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDelete")]
	private SimpleButton _BtnDelete;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnCancel")]
	private SimpleButton _BtnCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSave")]
	private SimpleButton _BtnSave;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnStock")]
	private QButton _BtnStock;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnOut")]
	private QButton _BtnOut;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnIn")]
	private QButton _BtnIn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboItemTyp")]
	private ComboBox _cboItemTyp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicImage")]
	private PictureBox _PicImage;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnImgCapture")]
	private QButton _BtnImgCapture;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnImgSelect")]
	private QButton _BtnImgSelect;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnImgDel")]
	private QButton _BtnImgDel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicZoom")]
	private PictureBox _PicZoom;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItCode")]
	private TextBox _tItCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tGrCode")]
	private TextBox _tGrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_PR")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV_PR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_DETL")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV_DETL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnWapp")]
	private SimpleButton _btnWapp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMobileNo")]
	private TextBox _tMobileNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnAc")]
	private SimpleButton _BtnAc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nToWt")]
	private TextBox _nToWt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nFromWt")]
	private TextBox _nFromWt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nToRow")]
	private TextBox _nToRow;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nFromRow")]
	private TextBox _nFromRow;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBookCode")]
	private TextBox _tBookCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkItSelect")]
	private CheckBox _chkItSelect;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAll")]
	private QButton _btnAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnItCancel")]
	private QButton _btnItCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOk")]
	private QButton _btnOk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tVchNo")]
	private TextBox _tVchNo;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsStkSum;

	private Module_WhatsApp whatsApp;

	private string ScelectMo;

	private int ImageFillStart;

	private int ImageFillEnd;

	private double ColCon;

	private string PrCode;

	private string CurMainBook;

	private DataTable RsRowImg;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string[] AryPrCode;

	private double ScanVchSrNo;

	private string SelectIt;

	private const int cBox = 0;

	private const int cSrNo = 1;

	private const int cTagNo = 2;

	private const int cItemName = 3;

	private const int cDesign = 4;

	private const int cPcs = 5;

	private const int cGrWt = 6;

	private const int cNetWt = 7;

	private const int cImage = 8;

	private const int cBookType = 9;

	private const int cVchNo = 10;

	private const int cSize = 11;

	private const int cTouch = 12;

	private const int cWest = 13;

	private const int cFine = 14;

	private const int cLbrPrc = 15;

	private const int cLbrAmt = 16;

	private const int cOthAmt = 17;

	private const int cMrp = 18;

	private const int cVchDate = 19;

	private const int cBookCode = 20;

	private const int cBookName = 21;

	private const int cVchSrNo = 22;

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
	[AccessedThroughProperty("tSerchAll")]
	private virtual SearchControl _tSerchAll;

	internal virtual SearchControl tSerchAll
	{
		get
		{
			return _tSerchAll;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tSerchAll = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDt")]
	private virtual DateEdit _mFromDt;

	internal virtual DateEdit mFromDt
	{
		get
		{
			return _mFromDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_mFromDt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToDt")]
	private virtual DateEdit _mToDt;

	internal virtual DateEdit mToDt
	{
		get
		{
			return _mToDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_mToDt = value;
		}
	}

	internal virtual QButton BtnStock
	{
		[CompilerGenerated]
		get
		{
			return _BtnStock;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnStock_Click;
			QButton val = _BtnStock;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnStock = value;
			val = _BtnStock;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnOut
	{
		[CompilerGenerated]
		get
		{
			return _BtnOut;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOut_Click;
			QButton val = _BtnOut;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnOut = value;
			val = _BtnOut;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnIn
	{
		[CompilerGenerated]
		get
		{
			return _BtnIn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnIn_Click;
			QButton val = _BtnIn;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnIn = value;
			val = _BtnIn;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual ComboBox cboItemTyp
	{
		[CompilerGenerated]
		get
		{
			return _cboItemTyp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboItemTyp_KeyDown);
			EventHandler eventHandler = cboItemTyp_SelectedIndexChanged;
			ComboBox val2 = _cboItemTyp;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				val2.SelectedIndexChanged -= eventHandler;
			}
			_cboItemTyp = value;
			val2 = _cboItemTyp;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				val2.SelectedIndexChanged += eventHandler;
			}
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
	[AccessedThroughProperty("BtnSumm")]
	private virtual SimpleButton _BtnSumm;

	internal virtual SimpleButton BtnSumm
	{
		get
		{
			return _BtnSumm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnSumm = value;
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

	internal virtual QButton BtnImgCapture
	{
		[CompilerGenerated]
		get
		{
			return _BtnImgCapture;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnImgCapture_Click;
			QButton val = _BtnImgCapture;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnImgCapture = value;
			val = _BtnImgCapture;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnImgSelect
	{
		[CompilerGenerated]
		get
		{
			return _BtnImgSelect;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnImgSelect_Click;
			QButton val = _BtnImgSelect;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnImgSelect = value;
			val = _BtnImgSelect;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnImgDel
	{
		[CompilerGenerated]
		get
		{
			return _BtnImgDel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnImgDel_Click;
			QButton val = _BtnImgDel;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnImgDel = value;
			val = _BtnImgDel;
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

	internal virtual TextBox tItCode
	{
		[CompilerGenerated]
		get
		{
			return _tItCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tItCode_KeyDown);
			TextBox val2 = _tItCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tItCode = value;
			val2 = _tItCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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
	[AccessedThroughProperty("Image1")]
	private virtual ImageCollection _Image1;

	internal virtual ImageCollection Image1
	{
		get
		{
			return _Image1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Image1 = value;
		}
	}

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV_PR
	{
		[CompilerGenerated]
		get
		{
			return _DGV_PR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = DGV_PR_DoubleClick;
			DevComponents.DotNetBar.Controls.DataGridViewX val = _DGV_PR;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_DGV_PR = value;
			val = _DGV_PR;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV_DETL
	{
		[CompilerGenerated]
		get
		{
			return _DGV_DETL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(DGV_DETL_CellContentClick);
			EventHandler eventHandler = DGV_DETL_DoubleClick;
			DevComponents.DotNetBar.Controls.DataGridViewX val2 = _DGV_DETL;
			if (val2 != null)
			{
				((DataGridView)val2).CellContentClick -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_DGV_DETL = value;
			val2 = _DGV_DETL;
			if (val2 != null)
			{
				((DataGridView)val2).CellContentClick += val;
				((Control)val2).DoubleClick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicSmall")]
	private virtual PictureBox _PicSmall;

	internal virtual PictureBox PicSmall
	{
		get
		{
			return _PicSmall;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PicSmall = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nTotAmt")]
	private virtual TextBox _nTotAmt;

	internal virtual TextBox nTotAmt
	{
		get
		{
			return _nTotAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nTotAmt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nLbrPrc")]
	private virtual TextBox _nLbrPrc;

	internal virtual TextBox nLbrPrc
	{
		get
		{
			return _nLbrPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nLbrPrc = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ProgressBar1")]
	private virtual ProgressBar _ProgressBar1;

	internal virtual ProgressBar ProgressBar1
	{
		get
		{
			return _ProgressBar1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_ProgressBar1 = value;
		}
	}

	internal virtual SimpleButton btnWapp
	{
		[CompilerGenerated]
		get
		{
			return _btnWapp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnWapp_Click;
			SimpleButton val = _btnWapp;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnWapp = value;
			val = _btnWapp;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual TextBox tMobileNo
	{
		[CompilerGenerated]
		get
		{
			return _tMobileNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tMobileNo_KeyDown);
			TextBox val2 = _tMobileNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tMobileNo = value;
			val2 = _tMobileNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual SimpleButton BtnAc
	{
		[CompilerGenerated]
		get
		{
			return _BtnAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAc_Click;
			SimpleButton val = _BtnAc;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnAc = value;
			val = _BtnAc;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual TextBox nToWt
	{
		[CompilerGenerated]
		get
		{
			return _nToWt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nToWt_KeyDown);
			EventHandler eventHandler = nToWt_GotFocus;
			TextBox val2 = _nToWt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_nToWt = value;
			val2 = _nToWt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
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

	internal virtual TextBox nFromWt
	{
		[CompilerGenerated]
		get
		{
			return _nFromWt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nFromWt_KeyDown);
			EventHandler eventHandler = nFromWt_GotFocus;
			TextBox val2 = _nFromWt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_nFromWt = value;
			val2 = _nFromWt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("numDelay")]
	private virtual NumericUpDown _numDelay;

	internal virtual NumericUpDown numDelay
	{
		get
		{
			return _numDelay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_numDelay = value;
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

	internal virtual TextBox nToRow
	{
		[CompilerGenerated]
		get
		{
			return _nToRow;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nToRow_KeyDown);
			EventHandler eventHandler = nToRow_GotFocus;
			TextBox val2 = _nToRow;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_nToRow = value;
			val2 = _nToRow;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
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

	internal virtual TextBox nFromRow
	{
		[CompilerGenerated]
		get
		{
			return _nFromRow;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nFromRow_KeyDown);
			EventHandler eventHandler = nFromRow_GotFocus;
			TextBox val2 = _nFromRow;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_nFromRow = value;
			val2 = _nFromRow;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
			}
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
			EventHandler eventHandler = tBookCode_TextChanged;
			TextBox val2 = _tBookCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tBookCode = value;
			val2 = _tBookCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	internal virtual CheckBox chkItSelect
	{
		[CompilerGenerated]
		get
		{
			return _chkItSelect;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkItSelect_Click;
			CheckBox val = _chkItSelect;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_chkItSelect = value;
			val = _chkItSelect;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlIt")]
	private virtual Panel _PnlIt;

	internal virtual Panel PnlIt
	{
		get
		{
			return _PnlIt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlIt = value;
		}
	}

	internal virtual QButton btnAll
	{
		[CompilerGenerated]
		get
		{
			return _btnAll;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAll_Click;
			QButton val = _btnAll;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAll = value;
			val = _btnAll;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnItCancel
	{
		[CompilerGenerated]
		get
		{
			return _btnItCancel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnItCancel_Click;
			QButton val = _btnItCancel;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnItCancel = value;
			val = _btnItCancel;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnOk
	{
		[CompilerGenerated]
		get
		{
			return _btnOk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOk_Click;
			QButton val = _btnOk;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOk = value;
			val = _btnOk;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_ITM")]
	private virtual DevComponents.DotNetBar.Controls.DataGridViewX _DGV_ITM;

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV_ITM
	{
		get
		{
			return _DGV_ITM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DGV_ITM = value;
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
			EventHandler eventHandler = tVchNo_TextChanged;
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

	public int newindex { get; set; }

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
			((XtraForm)this).Dispose(disposing);
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
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Expected O, but got Unknown
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Expected O, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected O, but got Unknown
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected O, but got Unknown
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Expected O, but got Unknown
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected O, but got Unknown
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected O, but got Unknown
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Expected O, but got Unknown
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Expected O, but got Unknown
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected O, but got Unknown
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected O, but got Unknown
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Expected O, but got Unknown
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Expected O, but got Unknown
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Expected O, but got Unknown
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Expected O, but got Unknown
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Expected O, but got Unknown
		//IL_0588: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05eb: Expected O, but got Unknown
		//IL_064e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0658: Expected O, but got Unknown
		//IL_0701: Unknown result type (might be due to invalid IL or missing references)
		//IL_070b: Expected O, but got Unknown
		//IL_0816: Unknown result type (might be due to invalid IL or missing references)
		//IL_0820: Expected O, but got Unknown
		//IL_093d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0947: Expected O, but got Unknown
		//IL_09aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b4: Expected O, but got Unknown
		//IL_0a5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a67: Expected O, but got Unknown
		//IL_0aca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad4: Expected O, but got Unknown
		//IL_0b7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b87: Expected O, but got Unknown
		//IL_0bea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf4: Expected O, but got Unknown
		//IL_0c9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca8: Expected O, but got Unknown
		//IL_0dc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dca: Expected O, but got Unknown
		//IL_0e57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e61: Expected O, but got Unknown
		//IL_0f11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1b: Expected O, but got Unknown
		//IL_0fa8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb2: Expected O, but got Unknown
		//IL_1088: Unknown result type (might be due to invalid IL or missing references)
		//IL_1092: Expected O, but got Unknown
		//IL_1100: Unknown result type (might be due to invalid IL or missing references)
		//IL_110a: Expected O, but got Unknown
		//IL_11f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1203: Expected O, but got Unknown
		//IL_128b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1291: Expected O, but got Unknown
		//IL_1293: Unknown result type (might be due to invalid IL or missing references)
		//IL_1299: Expected O, but got Unknown
		//IL_1342: Unknown result type (might be due to invalid IL or missing references)
		//IL_134c: Expected O, but got Unknown
		//IL_139f: Unknown result type (might be due to invalid IL or missing references)
		//IL_13a5: Expected O, but got Unknown
		//IL_13ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d0: Expected O, but got Unknown
		//IL_1463: Unknown result type (might be due to invalid IL or missing references)
		//IL_146d: Expected O, but got Unknown
		//IL_14c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c6: Expected O, but got Unknown
		//IL_14eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f1: Expected O, but got Unknown
		//IL_176c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1790: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1801: Unknown result type (might be due to invalid IL or missing references)
		//IL_180b: Expected O, but got Unknown
		//IL_182e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b19: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b66: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b70: Expected O, but got Unknown
		//IL_1b93: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e36: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ecb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed5: Expected O, but got Unknown
		//IL_1ef5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f75: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f7f: Expected O, but got Unknown
		//IL_1fe8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff2: Expected O, but got Unknown
		//IL_24f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_2514: Unknown result type (might be due to invalid IL or missing references)
		//IL_2538: Unknown result type (might be due to invalid IL or missing references)
		//IL_255c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2585: Unknown result type (might be due to invalid IL or missing references)
		//IL_258f: Expected O, but got Unknown
		//IL_25b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2816: Unknown result type (might be due to invalid IL or missing references)
		//IL_283a: Unknown result type (might be due to invalid IL or missing references)
		//IL_285e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2882: Unknown result type (might be due to invalid IL or missing references)
		//IL_28ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_28b5: Expected O, but got Unknown
		//IL_28db: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b63: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b87: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bab: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bde: Expected O, but got Unknown
		//IL_2c04: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c98: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ca2: Expected O, but got Unknown
		//IL_2d37: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d41: Expected O, but got Unknown
		//IL_2dbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dc9: Expected O, but got Unknown
		//IL_2e9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ea8: Expected O, but got Unknown
		//IL_2f11: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f1b: Expected O, but got Unknown
		//IL_2fbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fc7: Expected O, but got Unknown
		//IL_30b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_30c1: Expected O, but got Unknown
		//IL_314c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3156: Expected O, but got Unknown
		//IL_3214: Unknown result type (might be due to invalid IL or missing references)
		//IL_321e: Expected O, but got Unknown
		//IL_32ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_32c4: Expected O, but got Unknown
		//IL_334a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3354: Expected O, but got Unknown
		//IL_343b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3445: Expected O, but got Unknown
		//IL_34ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_34b8: Expected O, but got Unknown
		//IL_357d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3587: Expected O, but got Unknown
		//IL_3623: Unknown result type (might be due to invalid IL or missing references)
		//IL_362d: Expected O, but got Unknown
		//IL_36b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_36bd: Expected O, but got Unknown
		//IL_37a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_37b1: Expected O, but got Unknown
		//IL_381a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3824: Expected O, but got Unknown
		//IL_3b06: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b72: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ba5: Expected O, but got Unknown
		//IL_3bc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ea3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ec7: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eeb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f14: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f1e: Expected O, but got Unknown
		//IL_3f44: Unknown result type (might be due to invalid IL or missing references)
		//IL_41fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_421f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4243: Unknown result type (might be due to invalid IL or missing references)
		//IL_4267: Unknown result type (might be due to invalid IL or missing references)
		//IL_4290: Unknown result type (might be due to invalid IL or missing references)
		//IL_429a: Expected O, but got Unknown
		//IL_42c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_447a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4484: Expected O, but got Unknown
		//IL_4532: Unknown result type (might be due to invalid IL or missing references)
		//IL_453c: Expected O, but got Unknown
		//IL_45b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_45bc: Expected O, but got Unknown
		//IL_466a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4674: Expected O, but got Unknown
		//IL_46ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_46f4: Expected O, but got Unknown
		//IL_4792: Unknown result type (might be due to invalid IL or missing references)
		//IL_479c: Expected O, but got Unknown
		//IL_487c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4886: Expected O, but got Unknown
		//IL_4937: Unknown result type (might be due to invalid IL or missing references)
		//IL_4941: Expected O, but got Unknown
		//IL_49dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_49e6: Expected O, but got Unknown
		//IL_4abb: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ac5: Expected O, but got Unknown
		//IL_4b5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b68: Expected O, but got Unknown
		//IL_4c7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c87: Expected O, but got Unknown
		//IL_4cfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d07: Expected O, but got Unknown
		//IL_4db8: Unknown result type (might be due to invalid IL or missing references)
		//IL_4dc2: Expected O, but got Unknown
		//IL_4e38: Unknown result type (might be due to invalid IL or missing references)
		//IL_4e42: Expected O, but got Unknown
		//IL_4edf: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ee9: Expected O, but got Unknown
		//IL_4f86: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f90: Expected O, but got Unknown
		//IL_502e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5038: Expected O, but got Unknown
		//IL_50d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_50dd: Expected O, but got Unknown
		//IL_5158: Unknown result type (might be due to invalid IL or missing references)
		//IL_5162: Expected O, but got Unknown
		components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_TAG_IMAGE));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		DataGridViewCellStyle val7 = new DataGridViewCellStyle();
		DataGridViewCellStyle val8 = new DataGridViewCellStyle();
		DataGridViewCellStyle val9 = new DataGridViewCellStyle();
		DataGridViewCellStyle val10 = new DataGridViewCellStyle();
		DataGridViewCellStyle val11 = new DataGridViewCellStyle();
		DataGridViewCellStyle val12 = new DataGridViewCellStyle();
		DataGridViewCellStyle val13 = new DataGridViewCellStyle();
		DataGridViewCellStyle val14 = new DataGridViewCellStyle();
		DataGridViewCellStyle val15 = new DataGridViewCellStyle();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		BtnSumm = new SimpleButton();
		btnWapp = new SimpleButton();
		nToRow = new TextBox();
		Label4 = new Label();
		nFromRow = new TextBox();
		Label5 = new Label();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		tSerchAll = new SearchControl();
		mFromDt = new DateEdit();
		mToDt = new DateEdit();
		BtnStock = new QButton();
		BtnOut = new QButton();
		BtnIn = new QButton();
		cboItemTyp = new ComboBox();
		Label3 = new Label();
		Panel1 = new Panel();
		PnlIt = new Panel();
		btnAll = new QButton();
		btnItCancel = new QButton();
		btnOk = new QButton();
		DGV_ITM = new DevComponents.DotNetBar.Controls.DataGridViewX();
		numDelay = new NumericUpDown();
		ProgressBar1 = new ProgressBar();
		nTotAmt = new TextBox();
		nLbrPrc = new TextBox();
		DGV_DETL = new DevComponents.DotNetBar.Controls.DataGridViewX();
		DGV_PR = new DevComponents.DotNetBar.Controls.DataGridViewX();
		BtnImgCapture = new QButton();
		BtnImgSelect = new QButton();
		BtnImgDel = new QButton();
		PicImage = new PictureBox();
		DlgOpen = new OpenFileDialog();
		PicZoom = new PictureBox();
		Label9 = new Label();
		tItCode = new TextBox();
		Label10 = new Label();
		tGrCode = new TextBox();
		Label1 = new Label();
		Image1 = new ImageCollection(components);
		PicSmall = new PictureBox();
		Label2 = new Label();
		tMobileNo = new TextBox();
		BtnAc = new SimpleButton();
		nToWt = new TextBox();
		Label11 = new Label();
		nFromWt = new TextBox();
		Label8 = new Label();
		Label6 = new Label();
		tBookCode = new TextBox();
		chkItSelect = new CheckBox();
		tVchNo = new TextBox();
		Label12 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)tSerchAll.Properties).BeginInit();
		((ISupportInitialize)mFromDt.Properties.CalendarTimeProperties).BeginInit();
		((ISupportInitialize)mFromDt.Properties).BeginInit();
		((ISupportInitialize)mToDt.Properties.CalendarTimeProperties).BeginInit();
		((ISupportInitialize)mToDt.Properties).BeginInit();
		((Control)Panel1).SuspendLayout();
		((Control)PnlIt).SuspendLayout();
		((ISupportInitialize)DGV_ITM).BeginInit();
		((ISupportInitialize)numDelay).BeginInit();
		((ISupportInitialize)DGV_DETL).BeginInit();
		((ISupportInitialize)DGV_PR).BeginInit();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)Image1).BeginInit();
		((ISupportInitialize)PicSmall).BeginInit();
		((XtraForm)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSumm);
		((Control)PnlBotam).Controls.Add((Control)(object)btnWapp);
		((Control)PnlBotam).Controls.Add((Control)(object)nToRow);
		((Control)PnlBotam).Controls.Add((Control)(object)Label4);
		((Control)PnlBotam).Controls.Add((Control)(object)nFromRow);
		((Control)PnlBotam).Controls.Add((Control)(object)Label5);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 5;
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
		((Control)BtnExit).TabIndex = 7;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
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
		((Control)BtnDelete).TabIndex = 6;
		BtnDelete.Text = "&Delete";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
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
		((Control)BtnCancel).TabIndex = 5;
		BtnCancel.Text = "&Cancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
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
		((Control)BtnSave).TabIndex = 4;
		BtnSave.Text = "&Excel";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
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
		((Control)BtnPrint).TabIndex = 3;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnSumm).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnSumm).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSumm).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSumm).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSumm.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSumm.ImageOptions.SvgImage");
		((Control)BtnSumm).Location = new Point(730, 3);
		((BaseControl)BtnSumm).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSumm).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSumm).Name = "BtnSumm";
		((Control)BtnSumm).Size = new Size(91, 37);
		((Control)BtnSumm).TabIndex = 11;
		BtnSumm.Text = "&Summ";
		((BaseButton)BtnSumm).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btnWapp).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnWapp).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnWapp).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnWapp).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnWapp.ImageOptions).Image = (Image)(object)Resources.ArrowRight;
		((Control)btnWapp).Location = new Point(633, 3);
		((BaseControl)btnWapp).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnWapp).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnWapp).Name = "btnWapp";
		((Control)btnWapp).Size = new Size(91, 37);
		((Control)btnWapp).TabIndex = 12;
		btnWapp.Text = "&Wp Send";
		((BaseButton)btnWapp).ToolTipAnchor = (ToolTipAnchor)1;
		((TextBoxBase)nToRow).BackColor = Color.White;
		((Control)nToRow).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nToRow).Location = new Point(581, 3);
		((TextBoxBase)nToRow).MaxLength = 5;
		((Control)nToRow).Name = "nToRow";
		((Control)nToRow).Size = new Size(46, 22);
		((Control)nToRow).TabIndex = 1227;
		nToRow.TextAlign = (HorizontalAlignment)2;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(511, 0);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(64, 20);
		((Control)Label4).TabIndex = 1228;
		Label4.Text = "To/ Row";
		Label4.TextAlign = (ContentAlignment)16;
		((TextBoxBase)nFromRow).BackColor = Color.White;
		((Control)nFromRow).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nFromRow).Location = new Point(459, 3);
		((TextBoxBase)nFromRow).MaxLength = 5;
		((Control)nFromRow).Name = "nFromRow";
		((Control)nFromRow).Size = new Size(46, 22);
		((Control)nFromRow).TabIndex = 1225;
		nFromRow.TextAlign = (HorizontalAlignment)2;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(395, 0);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(58, 20);
		((Control)Label5).TabIndex = 1226;
		Label5.Text = "F/ Row";
		Label5.TextAlign = (ContentAlignment)16;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1251, 315);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 10;
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
		lblBook.Text = "Tag Image Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((Control)tSerchAll).Location = new Point(650, 47);
		((Control)tSerchAll).Name = "tSerchAll";
		((RepositoryItem)tSerchAll.Properties).Appearance.BackColor = Color.White;
		((RepositoryItem)tSerchAll.Properties).Appearance.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((RepositoryItem)tSerchAll.Properties).Appearance.ForeColor = Color.Navy;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseBackColor = true;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseFont = true;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseForeColor = true;
		((EditorButtonCollection)tSerchAll.Properties.Buttons).AddRange((EditorButton[])(object)new EditorButton[2]
		{
			(EditorButton)new ClearButton(),
			(EditorButton)new SearchButton()
		});
		((RepositoryItemTextEdit)tSerchAll.Properties).NullValuePrompt = "Tag Search";
		((Control)tSerchAll).Size = new Size(120, 22);
		((Control)tSerchAll).TabIndex = 8;
		mFromDt.EditValue = null;
		((Control)mFromDt).Location = new Point(18, 42);
		((Control)mFromDt).Name = "mFromDt";
		((RepositoryItem)mFromDt.Properties).Appearance.BackColor = Color.LemonChiffon;
		((RepositoryItem)mFromDt.Properties).Appearance.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((RepositoryItem)mFromDt.Properties).Appearance.Options.UseBackColor = true;
		((RepositoryItem)mFromDt.Properties).Appearance.Options.UseFont = true;
		((RepositoryItemButtonEdit)mFromDt.Properties).Buttons.AddRange((EditorButton[])(object)new EditorButton[1]
		{
			new EditorButton((ButtonPredefines)(-5))
		});
		((RepositoryItemButtonEdit)mFromDt.Properties.CalendarTimeProperties).Buttons.AddRange((EditorButton[])(object)new EditorButton[1]
		{
			new EditorButton((ButtonPredefines)(-5))
		});
		((Control)mFromDt).Size = new Size(101, 22);
		((Control)mFromDt).TabIndex = 0;
		mToDt.EditValue = null;
		((Control)mToDt).Location = new Point(125, 42);
		((Control)mToDt).Name = "mToDt";
		((RepositoryItem)mToDt.Properties).Appearance.BackColor = Color.LemonChiffon;
		((RepositoryItem)mToDt.Properties).Appearance.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((RepositoryItem)mToDt.Properties).Appearance.Options.UseBackColor = true;
		((RepositoryItem)mToDt.Properties).Appearance.Options.UseFont = true;
		((RepositoryItemButtonEdit)mToDt.Properties).Buttons.AddRange((EditorButton[])(object)new EditorButton[1]
		{
			new EditorButton((ButtonPredefines)(-5))
		});
		((RepositoryItemButtonEdit)mToDt.Properties.CalendarTimeProperties).Buttons.AddRange((EditorButton[])(object)new EditorButton[1]
		{
			new EditorButton((ButtonPredefines)(-5))
		});
		((Control)mToDt).Size = new Size(101, 22);
		((Control)mToDt).TabIndex = 1;
		((QControl)BtnStock).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnStock).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnStock).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnStock).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnStock).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnStock).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnStock).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnStock).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnStock).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)BtnStock).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnStock).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnStock).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnStock).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnStock).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)BtnStock).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnStock).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnStock.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnStock.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnStock.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnStock.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnStock.Image = null;
		((QControl)BtnStock).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnStock).Location = new Point(287, 75);
		((Control)BtnStock).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnStock).Name = "BtnStock";
		((Control)BtnStock).Size = new Size(115, 37);
		((Control)BtnStock).TabIndex = 9;
		BtnStock.Text = "&Stock Tag";
		((QControl)BtnOut).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnOut).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnOut).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnOut).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnOut).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnOut).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnOut).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnOut).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnOut).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)BtnOut).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnOut).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnOut).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnOut).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnOut).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)BtnOut).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnOut).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnOut.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnOut.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnOut.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnOut.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnOut.Image = null;
		((QControl)BtnOut).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnOut).Location = new Point(154, 75);
		((Control)BtnOut).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnOut).Name = "BtnOut";
		((Control)BtnOut).Size = new Size(115, 37);
		((Control)BtnOut).TabIndex = 10;
		BtnOut.Text = "&Out Tag";
		((QControl)BtnIn).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnIn).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnIn).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnIn).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnIn).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnIn).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnIn).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnIn).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnIn).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)BtnIn).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnIn).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnIn).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnIn).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnIn).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)BtnIn).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnIn).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnIn.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnIn.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnIn.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnIn.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnIn.Image = null;
		((QControl)BtnIn).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnIn).Location = new Point(22, 75);
		((Control)BtnIn).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnIn).Name = "BtnIn";
		((Control)BtnIn).Size = new Size(115, 37);
		((Control)BtnIn).TabIndex = 11;
		BtnIn.Text = "&In Tag";
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(305, 43);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(98, 22);
		((Control)cboItemTyp).TabIndex = 2;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(226, 43);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(74, 20);
		((Control)Label3).TabIndex = 124;
		Label3.Text = "Item Type";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Panel1).BackColor = Color.SeaShell;
		Panel1.BorderStyle = (BorderStyle)1;
		((Control)Panel1).Controls.Add((Control)(object)PnlIt);
		((Control)Panel1).Controls.Add((Control)(object)numDelay);
		((Control)Panel1).Controls.Add((Control)(object)ProgressBar1);
		((Control)Panel1).Controls.Add((Control)(object)nTotAmt);
		((Control)Panel1).Controls.Add((Control)(object)nLbrPrc);
		((Control)Panel1).Controls.Add((Control)(object)DGV_DETL);
		((Control)Panel1).Controls.Add((Control)(object)DGV_PR);
		((Control)Panel1).Controls.Add((Control)(object)BtnImgCapture);
		((Control)Panel1).Controls.Add((Control)(object)BtnImgSelect);
		((Control)Panel1).Controls.Add((Control)(object)Cr);
		((Control)Panel1).Controls.Add((Control)(object)BtnImgDel);
		((Control)Panel1).Controls.Add((Control)(object)PicImage);
		((Control)Panel1).Location = new Point(-10, 108);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(1319, 458);
		((Control)Panel1).TabIndex = 129;
		((Control)PnlIt).BackColor = Color.LavenderBlush;
		PnlIt.BorderStyle = (BorderStyle)1;
		((Control)PnlIt).Controls.Add((Control)(object)btnAll);
		((Control)PnlIt).Controls.Add((Control)(object)btnItCancel);
		((Control)PnlIt).Controls.Add((Control)(object)btnOk);
		((Control)PnlIt).Controls.Add((Control)(object)DGV_ITM);
		((Control)PnlIt).Location = new Point(428, 148);
		((Control)PnlIt).Name = "PnlIt";
		((Control)PnlIt).Size = new Size(456, 299);
		((Control)PnlIt).TabIndex = 1210;
		((Control)PnlIt).Visible = false;
		((QControl)btnAll).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnAll).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAll).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnAll).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnAll).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnAll).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAll).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAll).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnAll).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnAll).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnAll).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAll).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnAll).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnAll).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnAll.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAll.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAll.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAll.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAll.Image = null;
		((QControl)btnAll).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnAll).Location = new Point(53, 249);
		((Control)btnAll).Margin = new Padding(3, 6, 3, 6);
		((Control)btnAll).Name = "btnAll";
		((Control)btnAll).Size = new Size(100, 38);
		((Control)btnAll).TabIndex = 1159;
		btnAll.Text = "All";
		((QControl)btnItCancel).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnItCancel).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnItCancel).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnItCancel).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnItCancel).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnItCancel).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnItCancel).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnItCancel).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnItCancel).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnItCancel).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnItCancel).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnItCancel).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnItCancel).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnItCancel).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnItCancel.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Image = null;
		((QControl)btnItCancel).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnItCancel).Location = new Point(317, 249);
		((Control)btnItCancel).Margin = new Padding(3, 6, 3, 6);
		((Control)btnItCancel).Name = "btnItCancel";
		((Control)btnItCancel).Size = new Size(100, 38);
		((Control)btnItCancel).TabIndex = 1158;
		btnItCancel.Text = "Cancel";
		((QControl)btnOk).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOk).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOk).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOk).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOk).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOk).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOk).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOk).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOk).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnOk).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOk).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOk.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Image = null;
		((QControl)btnOk).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnOk).Location = new Point(184, 249);
		((Control)btnOk).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOk).Name = "btnOk";
		((Control)btnOk).Size = new Size(100, 38);
		((Control)btnOk).TabIndex = 1157;
		btnOk.Text = "Ok";
		((DataGridView)DGV_ITM).AllowUserToAddRows = false;
		((DataGridView)DGV_ITM).AllowUserToDeleteRows = false;
		((DataGridView)DGV_ITM).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_ITM).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV_ITM).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_ITM).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_ITM).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV_ITM).ColumnHeadersHeight = 30;
		((DataGridView)DGV_ITM).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(30, 57, 91);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ITM).DefaultCellStyle = val3;
		((DataGridView)DGV_ITM).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_ITM).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_ITM).Location = new Point(11, 11);
		((Control)DGV_ITM).Name = "DGV_ITM";
		DGV_ITM.PaintEnhancedSelection = false;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_ITM).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV_ITM).RowHeadersVisible = false;
		((DataGridView)DGV_ITM).RowHeadersWidth = 20;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_ITM).RowsDefaultCellStyle = val5;
		DGV_ITM.ScrollBarAppearance = (eScrollBarAppearance)0;
		((DataGridView)DGV_ITM).ScrollBars = (ScrollBars)2;
		DGV_ITM.SelectAllSignVisible = false;
		((DataGridView)DGV_ITM).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_ITM).Size = new Size(433, 229);
		((DataGridView)DGV_ITM).StandardTab = true;
		((Control)DGV_ITM).TabIndex = 1156;
		((Control)numDelay).Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)numDelay).Location = new Point(1137, 12);
		((Control)numDelay).Name = "numDelay";
		((Control)numDelay).Size = new Size(39, 22);
		((Control)numDelay).TabIndex = 1211;
		numDelay.Value = new decimal(new int[4] { 3, 0, 0, 0 });
		((Control)ProgressBar1).Location = new Point(21, 427);
		((Control)ProgressBar1).Name = "ProgressBar1";
		((Control)ProgressBar1).Size = new Size(863, 20);
		((Control)ProgressBar1).TabIndex = 1210;
		((TextBoxBase)nTotAmt).BackColor = Color.FromArgb(255, 224, 192);
		((Control)nTotAmt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nTotAmt).Location = new Point(1251, 408);
		((TextBoxBase)nTotAmt).MaxLength = 15;
		((Control)nTotAmt).Name = "nTotAmt";
		((Control)nTotAmt).Size = new Size(44, 23);
		((Control)nTotAmt).TabIndex = 1158;
		nTotAmt.TextAlign = (HorizontalAlignment)1;
		((Control)nTotAmt).Visible = false;
		((Control)nLbrPrc).Font = new Font("Tahoma", 9f);
		((Control)nLbrPrc).Location = new Point(1251, 380);
		((TextBoxBase)nLbrPrc).MaxLength = 15;
		((Control)nLbrPrc).Name = "nLbrPrc";
		((Control)nLbrPrc).Size = new Size(46, 22);
		((Control)nLbrPrc).TabIndex = 1157;
		nLbrPrc.TextAlign = (HorizontalAlignment)1;
		((Control)nLbrPrc).Visible = false;
		((DataGridView)DGV_DETL).AllowUserToAddRows = false;
		((DataGridView)DGV_DETL).AllowUserToDeleteRows = false;
		((DataGridView)DGV_DETL).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DGV_DETL).BackgroundColor = Color.Snow;
		((DataGridView)DGV_DETL).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_DETL).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV_DETL).ColumnHeadersHeight = 30;
		((DataGridView)DGV_DETL).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(30, 57, 91);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).DefaultCellStyle = val8;
		((DataGridView)DGV_DETL).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_DETL).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_DETL).Location = new Point(21, 12);
		((Control)DGV_DETL).Name = "DGV_DETL";
		DGV_DETL.PaintEnhancedSelection = false;
		((DataGridView)DGV_DETL).ReadOnly = true;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_DETL).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DGV_DETL).RowHeadersVisible = false;
		((DataGridView)DGV_DETL).RowHeadersWidth = 20;
		val10.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_DETL).RowsDefaultCellStyle = val10;
		DGV_DETL.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_DETL.SelectAllSignVisible = false;
		((DataGridView)DGV_DETL).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_DETL).Size = new Size(863, 410);
		((DataGridView)DGV_DETL).StandardTab = true;
		((Control)DGV_DETL).TabIndex = 1156;
		((DataGridView)DGV_PR).AllowUserToAddRows = false;
		((DataGridView)DGV_PR).AllowUserToDeleteRows = false;
		((DataGridView)DGV_PR).AllowUserToResizeRows = false;
		val11.BackColor = Color.PapayaWhip;
		val11.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val11.ForeColor = Color.FromArgb(64, 64, 64);
		val11.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val11.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_PR).AlternatingRowsDefaultCellStyle = val11;
		((DataGridView)DGV_PR).BackgroundColor = Color.Snow;
		((DataGridView)DGV_PR).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_PR).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val12.Alignment = (DataGridViewContentAlignment)16;
		val12.BackColor = SystemColors.Control;
		val12.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val12.ForeColor = Color.FromArgb(64, 64, 64);
		val12.SelectionBackColor = SystemColors.ScrollBar;
		val12.SelectionForeColor = Color.White;
		val12.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_PR).ColumnHeadersDefaultCellStyle = val12;
		((DataGridView)DGV_PR).ColumnHeadersHeight = 30;
		((DataGridView)DGV_PR).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val13.Alignment = (DataGridViewContentAlignment)16;
		val13.BackColor = SystemColors.Window;
		val13.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val13.ForeColor = Color.FromArgb(30, 57, 91);
		val13.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val13.SelectionForeColor = Color.Maroon;
		val13.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_PR).DefaultCellStyle = val13;
		((DataGridView)DGV_PR).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_PR).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_PR).Location = new Point(895, 12);
		((Control)DGV_PR).Name = "DGV_PR";
		DGV_PR.PaintEnhancedSelection = false;
		((DataGridView)DGV_PR).ReadOnly = true;
		val14.Alignment = (DataGridViewContentAlignment)16;
		val14.BackColor = Color.MintCream;
		val14.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val14.ForeColor = SystemColors.WindowText;
		val14.SelectionBackColor = SystemColors.Highlight;
		val14.SelectionForeColor = SystemColors.HighlightText;
		val14.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_PR).RowHeadersDefaultCellStyle = val14;
		((DataGridView)DGV_PR).RowHeadersVisible = false;
		((DataGridView)DGV_PR).RowHeadersWidth = 20;
		val15.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val15.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_PR).RowsDefaultCellStyle = val15;
		DGV_PR.ScrollBarAppearance = (eScrollBarAppearance)0;
		((DataGridView)DGV_PR).ScrollBars = (ScrollBars)2;
		DGV_PR.SelectAllSignVisible = false;
		((DataGridView)DGV_PR).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_PR).Size = new Size(234, 230);
		((DataGridView)DGV_PR).StandardTab = true;
		((Control)DGV_PR).TabIndex = 1155;
		((QControl)BtnImgCapture).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnImgCapture).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnImgCapture).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnImgCapture).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnImgCapture).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnImgCapture).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnImgCapture).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnImgCapture).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnImgCapture).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)BtnImgCapture).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnImgCapture).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnImgCapture).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnImgCapture).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnImgCapture).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)BtnImgCapture).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnImgCapture).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnImgCapture.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnImgCapture.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnImgCapture.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnImgCapture.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnImgCapture.Image = null;
		((QControl)BtnImgCapture).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnImgCapture).Location = new Point(1137, 125);
		((Control)BtnImgCapture).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnImgCapture).Name = "BtnImgCapture";
		((Control)BtnImgCapture).Size = new Size(48, 31);
		((Control)BtnImgCapture).TabIndex = 1154;
		BtnImgCapture.Text = "C";
		((QControl)BtnImgCapture).ToolTipText = "Image Capture";
		((QControl)BtnImgSelect).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnImgSelect).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnImgSelect).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnImgSelect).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnImgSelect).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnImgSelect).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnImgSelect).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnImgSelect).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnImgSelect).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)BtnImgSelect).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnImgSelect).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnImgSelect).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnImgSelect).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnImgSelect).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)BtnImgSelect).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnImgSelect).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnImgSelect.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnImgSelect.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnImgSelect.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnImgSelect.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnImgSelect.Image = null;
		((QControl)BtnImgSelect).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnImgSelect).Location = new Point(1137, 168);
		((Control)BtnImgSelect).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnImgSelect).Name = "BtnImgSelect";
		((Control)BtnImgSelect).Size = new Size(48, 31);
		((Control)BtnImgSelect).TabIndex = 1153;
		BtnImgSelect.Text = "S";
		((QControl)BtnImgSelect).ToolTipText = "Image Select";
		((QControl)BtnImgDel).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnImgDel).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnImgDel).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnImgDel).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnImgDel).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnImgDel).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnImgDel).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnImgDel).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnImgDel).ColorScheme.ButtonHotText.SetColor("LunaOlive", Color.MediumBlue, false);
		((QControl)BtnImgDel).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnImgDel).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnImgDel).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnImgDel).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnImgDel).ColorScheme.ButtonText.SetColor("LunaOlive", Color.Maroon, false);
		((QColorSchemeBase)((QControl)BtnImgDel).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnImgDel).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnImgDel.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnImgDel.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnImgDel.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnImgDel.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnImgDel.Image = null;
		((QControl)BtnImgDel).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnImgDel).Location = new Point(1137, 211);
		((Control)BtnImgDel).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnImgDel).Name = "BtnImgDel";
		((Control)BtnImgDel).Size = new Size(48, 31);
		((Control)BtnImgDel).TabIndex = 1152;
		BtnImgDel.Text = "D";
		((QControl)BtnImgDel).ToolTipText = "Image Delete";
		((Control)PicImage).BackColor = Color.LavenderBlush;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.Image = (Image)(object)Resources.longset;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(895, 251);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(290, 196);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1139;
		PicImage.TabStop = false;
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((Control)PicZoom).BackColor = Color.Transparent;
		PicZoom.ImeMode = (ImeMode)0;
		((Control)PicZoom).Location = new Point(1143, 50);
		((Control)PicZoom).Name = "PicZoom";
		((Control)PicZoom).Size = new Size(12, 32);
		PicZoom.SizeMode = (PictureBoxSizeMode)4;
		PicZoom.TabIndex = 1156;
		PicZoom.TabStop = false;
		((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(978, 76);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(60, 20);
		((Control)Label9).TabIndex = 1158;
		Label9.Text = "It Code";
		Label9.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tItCode).BackColor = Color.White;
		((Control)tItCode).Font = new Font("Tahoma", 9f);
		((Control)tItCode).Location = new Point(1044, 74);
		((TextBoxBase)tItCode).MaxLength = 5;
		((Control)tItCode).Name = "tItCode";
		((TextBoxBase)tItCode).ReadOnly = true;
		((Control)tItCode).Size = new Size(76, 22);
		((Control)tItCode).TabIndex = 7;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(974, 41);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(64, 20);
		((Control)Label10).TabIndex = 1161;
		Label10.Text = "Gr Code";
		Label10.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tGrCode).BackColor = Color.White;
		((Control)tGrCode).Font = new Font("Tahoma", 9f);
		((Control)tGrCode).Location = new Point(1044, 41);
		((TextBoxBase)tGrCode).MaxLength = 3;
		((Control)tGrCode).Name = "tGrCode";
		((TextBoxBase)tGrCode).ReadOnly = true;
		((Control)tGrCode).Size = new Size(76, 22);
		((Control)tGrCode).TabIndex = 6;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(570, 49);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(74, 20);
		((Control)Label1).TabIndex = 1163;
		Label1.Text = "Tag Filter";
		Label1.TextAlign = (ContentAlignment)64;
		Image1.ImageStream = (ImageCollectionStreamer)componentResourceManager.GetObject("Image1.ImageStream");
		Image1.Images.SetKeyName(0, "Green_Arrow_Up.jpg");
		Image1.Images.SetKeyName(1, "manphoto.jpg");
		((Control)PicSmall).BackColor = Color.LavenderBlush;
		PicSmall.BorderStyle = (BorderStyle)1;
		PicSmall.ImeMode = (ImeMode)0;
		((Control)PicSmall).Location = new Point(1215, 45);
		((Control)PicSmall).Name = "PicSmall";
		((Control)PicSmall).Size = new Size(53, 33);
		PicSmall.SizeMode = (PictureBoxSizeMode)4;
		PicSmall.TabIndex = 1164;
		PicSmall.TabStop = false;
		((Control)PicSmall).Visible = false;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(555, 78);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(89, 20);
		((Control)Label2).TabIndex = 1166;
		Label2.Text = "Mobile No";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tMobileNo).BackColor = Color.White;
		((Control)tMobileNo).Font = new Font("Tahoma", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tMobileNo).Location = new Point(650, 76);
		((TextBoxBase)tMobileNo).MaxLength = 10;
		((Control)tMobileNo).Name = "tMobileNo";
		((Control)tMobileNo).Size = new Size(120, 26);
		((Control)tMobileNo).TabIndex = 3;
		((BaseStyleControl)BtnAc).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnAc).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnAc).Appearance.Font = new Font("Arial", 9f);
		((BaseStyleControl)BtnAc).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnAc).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnAc).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnAc).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnAc).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnAc).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnAc).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnAc).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnAc).AppearanceHovered.Font = new Font("Arial", 9f);
		((BaseButton)BtnAc).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnAc).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnAc).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnAc).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnAc).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnAc).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnAc).AppearancePressed.Font = new Font("Arial", 9f);
		((BaseButton)BtnAc).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnAc).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnAc).AppearancePressed.Options.UseFont = true;
		((Control)BtnAc).Location = new Point(776, 75);
		((BaseControl)BtnAc).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnAc).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnAc).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnAc).Name = "BtnAc";
		((Control)BtnAc).Size = new Size(34, 26);
		((Control)BtnAc).TabIndex = 1167;
		BtnAc.Text = "A";
		((BaseControl)BtnAc).ToolTip = "Party Help";
		((TextBoxBase)nToWt).BackColor = Color.White;
		((Control)nToWt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nToWt).Location = new Point(881, 74);
		((TextBoxBase)nToWt).MaxLength = 6;
		((Control)nToWt).Name = "nToWt";
		((Control)nToWt).Size = new Size(81, 23);
		((Control)nToWt).TabIndex = 5;
		nToWt.TextAlign = (HorizontalAlignment)1;
		((Control)Label11).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(814, 77);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(61, 20);
		((Control)Label11).TabIndex = 1171;
		Label11.Text = "To Wt";
		Label11.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nFromWt).BackColor = Color.White;
		((Control)nFromWt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nFromWt).Location = new Point(881, 44);
		((TextBoxBase)nFromWt).MaxLength = 6;
		((Control)nFromWt).Name = "nFromWt";
		((Control)nFromWt).Size = new Size(81, 23);
		((Control)nFromWt).TabIndex = 4;
		nFromWt.TextAlign = (HorizontalAlignment)1;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(791, 44);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(84, 20);
		((Control)Label8).TabIndex = 1170;
		Label8.Text = "From Wt";
		Label8.TextAlign = (ContentAlignment)64;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(405, 45);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(73, 20);
		((Control)Label6).TabIndex = 1186;
		Label6.Text = "Book No";
		Label6.TextAlign = (ContentAlignment)64;
		((Control)tBookCode).Font = new Font("Tahoma", 9f);
		((Control)tBookCode).Location = new Point(483, 45);
		((TextBoxBase)tBookCode).MaxLength = 15;
		((Control)tBookCode).Name = "tBookCode";
		((Control)tBookCode).Size = new Size(71, 22);
		((Control)tBookCode).TabIndex = 1185;
		tBookCode.TextAlign = (HorizontalAlignment)2;
		((ButtonBase)chkItSelect).BackColor = Color.FromArgb(255, 224, 192);
		((Control)chkItSelect).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkItSelect).ForeColor = Color.Black;
		((Control)chkItSelect).Location = new Point(1023, 6);
		((Control)chkItSelect).Name = "chkItSelect";
		((Control)chkItSelect).RightToLeft = (RightToLeft)0;
		((Control)chkItSelect).Size = new Size(96, 19);
		((Control)chkItSelect).TabIndex = 1209;
		((ButtonBase)chkItSelect).Text = "Item Select";
		((ButtonBase)chkItSelect).UseVisualStyleBackColor = false;
		((Control)tVchNo).Font = new Font("Tahoma", 9f);
		((Control)tVchNo).Location = new Point(484, 78);
		((TextBoxBase)tVchNo).MaxLength = 15;
		((Control)tVchNo).Name = "tVchNo";
		((Control)tVchNo).Size = new Size(71, 22);
		((Control)tVchNo).TabIndex = 1212;
		tVchNo.TextAlign = (HorizontalAlignment)2;
		((Control)Label12).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(408, 79);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(70, 20);
		((Control)Label12).TabIndex = 1213;
		Label12.Text = "Vch No";
		Label12.TextAlign = (ContentAlignment)64;
		((XtraForm)this).Appearance.BackColor = SystemColors.ButtonHighlight;
		((XtraForm)this).Appearance.Options.UseBackColor = true;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)tVchNo);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)chkItSelect);
		((Control)this).Controls.Add((Control)(object)tBookCode);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)nToWt);
		((Control)this).Controls.Add((Control)(object)Label11);
		((Control)this).Controls.Add((Control)(object)nFromWt);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)BtnAc);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tMobileNo);
		((Control)this).Controls.Add((Control)(object)PicSmall);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)tGrCode);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)tItCode);
		((Control)this).Controls.Add((Control)(object)PicZoom);
		((Control)this).Controls.Add((Control)(object)Panel1);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)BtnIn);
		((Control)this).Controls.Add((Control)(object)BtnOut);
		((Control)this).Controls.Add((Control)(object)BtnStock);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)tSerchAll);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_TAG_IMAGE";
		((XtraForm)this).Text = "Tag Image Report";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)PnlBotam).PerformLayout();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)tSerchAll.Properties).EndInit();
		((ISupportInitialize)mFromDt.Properties.CalendarTimeProperties).EndInit();
		((ISupportInitialize)mFromDt.Properties).EndInit();
		((ISupportInitialize)mToDt.Properties.CalendarTimeProperties).EndInit();
		((ISupportInitialize)mToDt.Properties).EndInit();
		((Control)Panel1).ResumeLayout(false);
		((Control)Panel1).PerformLayout();
		((Control)PnlIt).ResumeLayout(false);
		((ISupportInitialize)DGV_ITM).EndInit();
		((ISupportInitialize)numDelay).EndInit();
		((ISupportInitialize)DGV_DETL).EndInit();
		((ISupportInitialize)DGV_PR).EndInit();
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)Image1).EndInit();
		((ISupportInitialize)PicSmall).EndInit();
		((XtraForm)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public RP_TAG_IMAGE()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		((Form)this).Load += RP_TAG_IMAGE_Load;
		((Form)this).Deactivate += RP_TAG_IMAGE_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_TAG_IMAGE_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_TAG_IMAGE_KeyDown);
		((Form)this).Activated += RP_TAG_IMAGE_Activated;
		((Form)this).Closed += RP_TAG_IMAGE_Closed;
		whatsApp = UT_WHATSAPP.whatsApp;
		InitializeComponent();
	}

	private void Tag_Summ(string RptType)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) == 0 && Operators.CompareString(RptType, "Stock", false) == 0 && ((Operators.CompareString(tItCode.Text, "", false) == 0) & (Operators.CompareString(PrCode, "", false) == 0)))
		{
			Interaction.MsgBox((object)"Please Select Item Code or Product Name and Try", (MsgBoxStyle)0, (object)null);
		}
		switch (RptType)
		{
		case "In":
			DC_Main.RsQry = "SELECT A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,A.TAG_NO As TagNo,B.IT_NAME As ItName,A.ITM_SIZE As Size,A.ITM_PCS as Pcs,A.ITM_GWT As Grwt,A.ITM_NWT AS NetWt,'' AS ItImage,  A.ITM_TOUCH As ItTouch,A.ITM_WEST_PRC As ItWest,A.ITM_FINE As ItFine,A.LBR_PRC As LbrPrc,A.LBR_AMT LbrAmt,A.OTH_AMT OthAmt,A.ITM_MRP As Mrp,  A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.VCH_SRNO As TagId,A.DESIGN_NO As Design  from BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.TAG_NO <> '' AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "'  ";
			if (Conversion.Val(nFromWt.Text) != 0.0)
			{
				DC_Main.RsQry += "AND A.ITM_NWT >=  " + Conversions.ToString(Conversion.Val(nFromWt.Text));
			}
			if (Conversion.Val(nToWt.Text) != 0.0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.ITM_NWT <=  '" + Conversions.ToString(Conversion.Val(nToWt.Text)) + "'";
			}
			if (Operators.CompareString(PrCode, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + PrCode + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
			}
			if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + ((TextEdit)tSerchAll).Text + "'";
			}
			if (Operators.CompareString(SelectIt, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE IN (" + SelectIt + ")";
			}
			if (Operators.CompareString(tBookCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.CO_BOOK =  '" + tBookCode.Text + "'";
			}
			if (Operators.CompareString(tVchNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.VCH_NO =  '" + tVchNo.Text + "'";
			}
			if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
			{
				DC_Main.RsQry += "ORDER BY SUBSTRING(A.DESIGN_NO,1,2),LEN(A.DESIGN_NO),A.DESIGN_NO";
			}
			else
			{
				DC_Main.RsQry += "ORDER BY A.TAG_NO";
			}
			break;
		case "Out":
			if (Operators.CompareString(CurMainBook, "SALES ORDER", false) == 0)
			{
				DC_Main.RsQry = "SELECT C.VCH_TYPE As VchTyp,C.VCH_NO VchNo,C.VCH_DATE As VchDate,C.TAG_NO As TagNo,B.IT_NAME As ItName,A.ITM_SIZE As Size,A.ITM_PCS as Pcs,A.ITM_GWT As Grwt,A.ITM_NWT AS NetWt,'' AS ItImage,  A.ITM_TOUCH As ItTouch,A.ITM_WEST_PRC As ItWest,A.ITM_FINE As ItFine,A.LBR_PRC As LbrPrc,A.LBR_AMT LbrAmt,A.OTH_AMT OthAmt,A.ITM_MRP As Mrp,  A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.VCH_SRNO As TagId,C.DESIGN_NO As Design  from (SL_ORD_DETL AS C LEFT JOIN BAR_DETL AS A ON C.CO_CODE = A.CO_CODE AND C.TAG_NO = A.TAG_NO AND C.VCH_SRNO = A.VCH_SRNO) LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE C.CO_CODE = '" + DC_Main.MCo_code + "'  AND C.LC_CODE = '" + DC_Main.MLc_code + "' AND C.CO_YEAR = '" + DC_Main.MCo_year + "' AND C.TAG_NO <> 'N' AND C.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "' AND C.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "' AND C.TAG_NO <> '' ";
			}
			else
			{
				DC_Main.RsQry = "SELECT A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,A.TAG_NO As TagNo,B.IT_NAME As ItName,A.ITM_SIZE As Size,A.ITM_PCS as Pcs,A.ITM_GWT As Grwt,A.ITM_NWT AS NetWt,'' AS ItImage,  A.ITM_TOUCH As ItTouch,A.ITM_WEST_PRC As ItWest,A.ITM_FINE As ItFine,A.LBR_PRC As LbrPrc,A.LBR_AMT LbrAmt,A.OTH_AMT OthAmt,A.ITM_MRP As Mrp,  A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.VCH_SRNO As TagId,C.DESIGN_NO As Design  from (MAIN_STOCK AS C LEFT JOIN BAR_DETL AS A ON C.CO_CODE = A.CO_CODE AND C.TAG_NO = A.TAG_NO AND C.VCH_SRNO = A.VCH_SRNO) LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE C.CO_CODE = '" + DC_Main.MCo_code + "'  AND C.LC_CODE = '" + DC_Main.MLc_code + "' AND C.CO_YEAR = '" + DC_Main.MCo_year + "' AND C.TAG_NO <> 'N' AND C.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "' AND C.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "' AND C.ITM_SIGN = '-' ";
			}
			if (Conversion.Val(nFromWt.Text) != 0.0)
			{
				DC_Main.RsQry += "AND A.ITM_NWT >=  " + Conversions.ToString(Conversion.Val(nFromWt.Text));
			}
			if (Conversion.Val(nToWt.Text) != 0.0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.ITM_NWT <=  '" + Conversions.ToString(Conversion.Val(nToWt.Text)) + "'";
			}
			if (Operators.CompareString(PrCode, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + PrCode + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + ((TextEdit)tSerchAll).Text + "'";
			}
			if (Operators.CompareString(tBookCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.CO_BOOK =  '" + tBookCode.Text + "'";
			}
			if (Operators.CompareString(SelectIt, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE IN (" + SelectIt + ")";
			}
			if (Operators.CompareString(tVchNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.VCH_NO =  '" + tVchNo.Text + "'";
			}
			if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
			{
				DC_Main.RsQry += "ORDER BY SUBSTRING(A.DESIGN_NO,1,2),LEN(A.DESIGN_NO),A.DESIGN_NO";
			}
			else
			{
				DC_Main.RsQry += "ORDER BY A.TAG_NO";
			}
			break;
		case "Stock":
			DC_Main.RsQry = "SELECT A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,A.TAG_NO As TagNo,B.IT_NAME As ItName,A.ITM_SIZE As Size,A.ITM_PCS as Pcs,A.ITM_GWT As Grwt,A.ITM_NWT AS NetWt,'' AS ItImage,  A.ITM_TOUCH As ItTouch,A.ITM_WEST_PRC As ItWest,A.ITM_FINE As ItFine,A.LBR_PRC As LbrPrc,A.LBR_AMT LbrAmt,A.OTH_AMT OthAmt,A.ITM_MRP As Mrp,  A.CO_BOOK As Book,A.BOOK_NAME As BookName,C.VCH_SRNO As TagId,A.DESIGN_NO Design  from (MAIN_STOCK AS C INNER JOIN BAR_DETL AS A ON C.CO_CODE = A.CO_CODE  And C.TAG_NO = A.TAG_NO And C.VCH_SRNO = A.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE WHERE C.CO_CODE = '" + DC_Main.MCo_code + "'  AND C.LC_CODE = '" + DC_Main.MLc_code + "' AND C.CO_YEAR = '" + DC_Main.MCo_year + "' AND C.TAG_NO <> 'N' AND C.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "'";
			if (Conversion.Val(nFromWt.Text) != 0.0)
			{
				DC_Main.RsQry += "AND A.ITM_NWT >=  " + Conversions.ToString(Conversion.Val(nFromWt.Text));
			}
			if (Conversion.Val(nToWt.Text) != 0.0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.ITM_NWT <=  '" + Conversions.ToString(Conversion.Val(nToWt.Text)) + "'";
			}
			if (Operators.CompareString(PrCode, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + PrCode + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE =  '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
			}
			if (Operators.CompareString(RptType, "Mrp", false) == 0)
			{
				DC_Main.RsQry += "AND C.ITM_MRP <> 0";
			}
			if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + ((TextEdit)tSerchAll).Text + "'";
			}
			if (Operators.CompareString(tBookCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND C.CO_BOOK =  '" + tBookCode.Text + "'";
			}
			if (Operators.CompareString(SelectIt, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_CODE IN (" + SelectIt + ")";
			}
			if (Operators.CompareString(tVchNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.VCH_NO =  '" + tVchNo.Text + "'";
			}
			DC_Main.RsQry += " GROUP BY A.VCH_TYPE,A.VCH_NO,A.VCH_DATE,A.TAG_NO,B.IT_NAME,A.ITM_SIZE,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,  A.ITM_TOUCH,A.ITM_WEST_PRC,A.ITM_FINE,A.LBR_PRC,A.LBR_AMT,A.OTH_AMT,A.ITM_MRP,  A.CO_BOOK,A.BOOK_NAME,C.VCH_SRNO,A.DESIGN_NO ";
			DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0 ";
			if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
			{
				DC_Main.RsQry += "ORDER BY SUBSTRING(C.DESIGN_NO,1,2), LEN(C.DESIGN_NO),C.DESIGN_NO";
			}
			else
			{
				DC_Main.RsQry += "ORDER BY A.TAG_NO";
			}
			break;
		}
		RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_FILL();
	}

	private void DGV_FILL()
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_0a0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a17: Expected O, but got Unknown
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).Columns.Clear();
		((DataGridView)DGV_DETL).Rows.Clear();
		((Control)DGV_DETL).Refresh();
		((DataGridView)DGV_DETL).MultiSelect = false;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV_DETL).AutoGenerateColumns = false;
		DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
		((DataGridViewColumn)val).Name = "Select";
		checked
		{
			((DataGridViewColumn)val).Width = (int)Math.Round(65.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add((DataGridViewColumn)(object)val);
			DataGridViewImageColumn val2 = new DataGridViewImageColumn();
			((DataGridView)DGV_DETL).Columns.Add("", "Sr");
			((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "TagNo");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "ItName");
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(145.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Design");
			((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Pcs");
			((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns.Add("", "GrWt");
			((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "NetWt");
			((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add((DataGridViewColumn)(object)val2);
			((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(140.0 * ColCon);
			((DataGridViewColumn)val2).HeaderText = "Tag Image          .";
			val2.ImageLayout = (DataGridViewImageCellLayout)3;
			((DataGridView)DGV_DETL).Columns.Add("", "Book");
			((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "VchNo");
			((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Size");
			((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Touch");
			((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "West");
			((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Fine");
			((DataGridView)DGV_DETL).Columns[14].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Lbr%");
			((DataGridView)DGV_DETL).Columns[15].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "LAmt");
			((DataGridView)DGV_DETL).Columns[16].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "OthAmt");
			((DataGridView)DGV_DETL).Columns[17].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Mrp");
			((DataGridView)DGV_DETL).Columns[18].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "VchDate");
			((DataGridView)DGV_DETL).Columns[19].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "BookCode");
			((DataGridView)DGV_DETL).Columns[20].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "BookName");
			((DataGridView)DGV_DETL).Columns[21].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "TagId");
			((DataGridView)DGV_DETL).Columns[22].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			DC_Main.R = 0;
			int num = RsStkSum.Rows.Count - 1;
			DC_Main.X = 0;
			while (DC_Main.X <= num)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL = DGV_DETL;
				((DataGridView)dGV_DETL).Rows.Add();
				((DataGridView)dGV_DETL)[1, DC_Main.R].Value = DC_Main.R + 1;
				((DataGridView)dGV_DETL)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["TagNo"]);
				((DataGridView)dGV_DETL)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["Design"]);
				((DataGridView)dGV_DETL)[22, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["TagId"]);
				((DataGridView)dGV_DETL)[3, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["ItName"]);
				((DataGridView)dGV_DETL)[11, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["Size"]);
				((DataGridView)dGV_DETL)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["Pcs"]);
				((DataGridView)dGV_DETL)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["Grwt"]);
				((DataGridView)dGV_DETL)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["NetWt"]);
				((DataGridView)dGV_DETL)[9, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["VchTyp"]);
				((DataGridView)dGV_DETL)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["VchNo"]);
				((DataGridView)dGV_DETL)[12, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["ItTouch"]);
				((DataGridView)dGV_DETL)[13, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["ItWest"]);
				((DataGridView)dGV_DETL)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["ItFine"]);
				((DataGridView)dGV_DETL)[15, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["LbrPrc"]);
				((DataGridView)dGV_DETL)[16, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["LbrAmt"]);
				((DataGridView)dGV_DETL)[17, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["OthAmt"]);
				((DataGridView)dGV_DETL)[18, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["Mrp"]);
				((DataGridView)dGV_DETL)[19, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["VchDate"]), "dd/MM/yyyy");
				((DataGridView)dGV_DETL)[20, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["Book"]);
				((DataGridView)dGV_DETL)[21, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.X]["BookName"]);
				DC_Main.R++;
				dGV_DETL = null;
				DC_Main.X++;
			}
			ImageFillStart = 0;
			ImageFillEnd = 75;
			Image_Fill();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void Image_Fill()
	{
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		((Control)DGV_PR).Enabled = false;
		checked
		{
			if (ImageFillEnd >= ((DataGridView)DGV_DETL).Rows.Count - 1)
			{
				ImageFillEnd = ((DataGridView)DGV_DETL).Rows.Count - 1;
			}
			int imageFillStart = ImageFillStart;
			int imageFillEnd = ImageFillEnd;
			DC_Main.R = imageFillStart;
			while (DC_Main.R <= imageFillEnd)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL = DGV_DETL;
				PicImage.Image = null;
				DC_Main.MsImageNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(((DataGridView)dGV_DETL)[2, DC_Main.R].Value, (object)"_"), ((DataGridView)dGV_DETL)[22, DC_Main.R].Value));
				DC_Main.MsImageType = "TagImage";
				DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
				Application.DoEvents();
				if (Operators.CompareString(DC_Main.MsHttpPath, "", false) != 0)
				{
					try
					{
						string address = ((Operators.CompareString(DC_Main.MsAppSchem, "Y", false) != 0) ? (DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg") : (DC_Main.MsHttpPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg"));
						((DataGridView)dGV_DETL)[8, DC_Main.R].Value = (object)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
						((DataGridView)dGV_DETL).Rows[DC_Main.R].Height = 75;
						((DataGridView)dGV_DETL).Rows[DC_Main.R].Cells[2].Selected = true;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '"), ((DataGridView)dGV_DETL)[2, DC_Main.R].Value), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[22, DC_Main.R].Value))), (object)""));
						DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
						if (dataTable.Rows.Count > 0)
						{
							((DataGridView)DGV_DETL).Rows[DC_Main.R].Height = 75;
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
							{
								PicImage.Image = null;
								((DataGridView)dGV_DETL).Rows[DC_Main.R].Cells[2].Selected = true;
							}
							else
							{
								object obj = Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)"");
								byte[] bA = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj));
								object objectValue = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA));
								((DataGridView)dGV_DETL)[8, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(objectValue);
								((DataGridView)dGV_DETL).Rows[DC_Main.R].Cells[2].Selected = true;
							}
						}
						else if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
						{
							((DataGridView)dGV_DETL).Rows[DC_Main.R].Height = 75;
							Image value;
							using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
							{
								value = Image.FromStream(stream);
							}
							((DataGridView)dGV_DETL)[8, DC_Main.R].Value = value;
							((DataGridView)dGV_DETL).Rows[DC_Main.R].Cells[2].Selected = true;
						}
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '"), ((DataGridView)dGV_DETL)[2, DC_Main.R].Value), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[22, DC_Main.R].Value))), (object)""));
					DataTable dataTable2 = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
					if (dataTable2.Rows.Count > 0)
					{
						((DataGridView)DGV_DETL).Rows[DC_Main.R].Height = 75;
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable2.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
						{
							PicImage.Image = null;
							((DataGridView)dGV_DETL).Rows[DC_Main.R].Cells[2].Selected = true;
						}
						else
						{
							object obj2 = Operators.ConcatenateObject(dataTable2.Rows[0]["MOB_IMAGE"], (object)"");
							byte[] bA2 = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj2));
							object objectValue2 = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA2));
							((DataGridView)dGV_DETL)[8, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(objectValue2);
							((DataGridView)dGV_DETL).Rows[DC_Main.R].Cells[2].Selected = true;
						}
					}
					else if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						((DataGridView)dGV_DETL).Rows[DC_Main.R].Height = 75;
						Image value2;
						using (Stream stream2 = File.OpenRead(DC_Main.MsImagePath))
						{
							value2 = Image.FromStream(stream2);
						}
						((DataGridView)dGV_DETL)[8, DC_Main.R].Value = value2;
						((DataGridView)dGV_DETL).Rows[DC_Main.R].Cells[2].Selected = true;
					}
				}
				dGV_DETL = null;
				DC_Main.R++;
			}
			((Control)DGV_PR).Enabled = true;
		}
	}

	private DataTable FillDataTable()
	{
		DataColumn dataColumn = new DataColumn();
		dataColumn.ColumnName = "Display Image";
		dataColumn.DataType = Type.GetType("System.String");
		RsStkSum.Columns.Add(dataColumn);
		checked
		{
			int num = RsStkSum.Rows.Count - 1;
			DC_Main.i = 0;
			while (DC_Main.i <= num)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '"), RsStkSum.Rows[DC_Main.i]["TagNo"]), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.i]["TagId"]))), (object)""));
				RsRowImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
				if (RsRowImg.Rows.Count > 0)
				{
					DataRow dataRow = RsStkSum.AsEnumerable().ElementAtOrDefault(DC_Main.i);
					dataRow["MOB_IMAGE"] = Operators.ConcatenateObject(RsRowImg.Rows[0]["MOB_IMAGE"], (object)"");
					dataRow["Display Image"] = "photo\\img" + DC_Main.i + ".jpg";
				}
				DC_Main.i++;
			}
			return RsStkSum;
		}
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		object obj = default(object);
		int num5 = default(int);
		object obj2 = default(object);
		object obj3 = default(object);
		object obj4 = default(object);
		int num6 = default(int);
		int num7 = default(int);
		int num8 = default(int);
		object obj5 = default(object);
		int num9 = default(int);
		Image val = default(Image);
		string text = default(string);
		object objectValue = default(object);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					object obj6;
					object[] obj7;
					object[] array;
					bool[] obj8;
					bool[] array2;
					object obj9;
					switch (try0001_dispatch)
					{
					default:
						num2 = 1;
						if (Operators.CompareString(UserPrint, "Y", false) != 0)
						{
							goto IL_001e;
						}
						goto IL_0034;
					case 2247:
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
								goto IL_001e;
							case 4:
							case 5:
								goto IL_0034;
							case 6:
								goto IL_004b;
							case 7:
								goto IL_007d;
							case 8:
								goto IL_00a5;
							case 9:
								goto IL_00ae;
							case 10:
								goto IL_00e1;
							case 11:
								goto IL_00f8;
							case 12:
								goto IL_0140;
							case 13:
								goto IL_014f;
							case 14:
								goto IL_016c;
							case 15:
								goto IL_0187;
							case 17:
								goto IL_01dd;
							case 19:
								goto IL_024a;
							case 21:
								goto IL_02b7;
							case 23:
								goto IL_0324;
							case 24:
								goto IL_036b;
							case 25:
								goto IL_038c;
							case 26:
								goto IL_0396;
							case 27:
								goto IL_03a1;
							case 28:
								goto IL_03b2;
							case 29:
								goto IL_03c4;
							case 30:
								goto IL_0437;
							case 31:
								goto IL_0470;
							case 32:
								goto IL_0477;
							case 33:
								goto IL_04d8;
							case 34:
								goto IL_0545;
							case 35:
								goto IL_0568;
							case 36:
								goto IL_058c;
							case 39:
								goto IL_0594;
							case 40:
								goto IL_05b7;
							case 16:
							case 18:
							case 20:
							case 22:
							case 37:
							case 38:
							case 41:
							case 42:
							case 43:
								goto IL_060f;
							case 44:
								goto IL_0621;
							case 45:
								goto IL_063c;
							case 46:
								goto IL_0676;
							case 47:
								goto IL_06ad;
							case 48:
								goto IL_06d1;
							case 49:
								goto IL_06f6;
							case 50:
								goto IL_0726;
							case 51:
								goto IL_0729;
							case 52:
								goto IL_0758;
							case 53:
								goto IL_0779;
							case 54:
								goto IL_0789;
							case 55:
								goto IL_0799;
							case 56:
								goto IL_07a8;
							case 57:
								goto IL_07ae;
							case 58:
								goto IL_07b4;
							case 59:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 60:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_02b7:
						num2 = 21;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[num5, DC_Main.i].Value)), "0")
						}, (string[])null, (Type[])null);
						goto IL_060f;
						IL_024a:
						num2 = 19;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[num5, DC_Main.i].Value)), "0.00")
						}, (string[])null, (Type[])null);
						goto IL_060f;
						IL_058c:
						obj2 = null;
						goto IL_060f;
						IL_01dd:
						num2 = 17;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[num5, DC_Main.i].Value)), "0.000")
						}, (string[])null, (Type[])null);
						goto IL_060f;
						IL_001e:
						num2 = 2;
						Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001_3;
						IL_0034:
						num2 = 5;
						obj3 = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("Excel.Application", ""));
						goto IL_004b;
						IL_004b:
						num2 = 6;
						obj4 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj3, (Type)null, "Workbooks", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Add", new object[0], (string[])null, (Type[])null, (bool[])null));
						goto IL_007d;
						IL_007d:
						num2 = 7;
						obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj4, (Type)null, "Sheets", new object[1] { 1 }, (string[])null, (Type[])null, (bool[])null));
						goto IL_00a5;
						IL_00a5:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_00ae;
						IL_00ae:
						num2 = 9;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3] { 1, 1, "Sheet 1 content" }, (string[])null, (Type[])null);
						goto IL_00e1;
						IL_00e1:
						num2 = 10;
						num6 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num7 = 0;
						goto IL_0149;
						IL_0149:
						if (num7 <= num6)
						{
							goto IL_00f8;
						}
						goto IL_014f;
						IL_014f:
						num2 = 13;
						num8 = ((DataGridView)DGV_DETL).RowCount - 1;
						DC_Main.i = 0;
						goto IL_0630;
						IL_0630:
						if (DC_Main.i <= num8)
						{
							goto IL_016c;
						}
						goto IL_063c;
						IL_063c:
						num2 = 45;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "RowHeight", new object[1] { 60 }, (string[])null, (Type[])null, false, true);
						goto IL_0676;
						IL_0676:
						num2 = 46;
						obj5 = NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null);
						goto IL_06ad;
						IL_06ad:
						num2 = 47;
						NewLateBinding.LateSetComplex(obj5, (Type)null, "Bold", new object[1] { true }, (string[])null, (Type[])null, false, true);
						goto IL_06d1;
						IL_06d1:
						num2 = 48;
						NewLateBinding.LateSetComplex(obj5, (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_06f6;
						IL_06f6:
						num2 = 49;
						NewLateBinding.LateSetComplex(obj5, (Type)null, "Color", new object[1] { Information.RGB(0, 0, 128) }, (string[])null, (Type[])null, false, true);
						goto IL_0726;
						IL_0726:
						obj5 = null;
						goto IL_0729;
						IL_0729:
						num2 = 51;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0758;
						IL_0758:
						num2 = 52;
						NewLateBinding.LateSet(obj3, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_0779;
						IL_0779:
						num2 = 53;
						Marshal.ReleaseComObject(RuntimeHelpers.GetObjectValue(obj));
						goto IL_0789;
						IL_0789:
						num2 = 54;
						Marshal.ReleaseComObject(RuntimeHelpers.GetObjectValue(obj4));
						goto IL_0799;
						IL_0799:
						num2 = 55;
						Marshal.ReleaseComObject(RuntimeHelpers.GetObjectValue(obj3));
						goto IL_07a8;
						IL_07a8:
						num2 = 56;
						obj = null;
						goto IL_07ae;
						IL_07ae:
						num2 = 57;
						obj4 = null;
						goto IL_07b4;
						IL_07b4:
						num2 = 58;
						obj3 = null;
						break;
						IL_016c:
						num2 = 14;
						num9 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num5 = 0;
						goto IL_0618;
						IL_0618:
						if (num5 <= num9)
						{
							goto IL_0187;
						}
						goto IL_0621;
						IL_0621:
						num2 = 44;
						DC_Main.i++;
						goto IL_0630;
						IL_0187:
						num2 = 15;
						switch (num5)
						{
						case 6:
						case 7:
						case 14:
							break;
						case 15:
						case 16:
						case 17:
						case 18:
							goto IL_024a;
						case 22:
							goto IL_02b7;
						case 8:
							goto IL_0324;
						default:
							goto IL_0594;
						}
						goto IL_01dd;
						IL_0594:
						num2 = 39;
						if (((DataGridView)DGV_DETL)[num5, DC_Main.i].Value != null)
						{
							goto IL_05b7;
						}
						goto IL_060f;
						IL_05b7:
						num2 = 40;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							((DataGridView)DGV_DETL)[num5, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_060f;
						IL_0324:
						num2 = 23;
						if (((DataGridView)DGV_DETL)[num5, DC_Main.i].Value != null && ((DataGridView)DGV_DETL)[num5, DC_Main.i].Value is Image)
						{
							goto IL_036b;
						}
						goto IL_060f;
						IL_060f:
						num2 = 43;
						num5++;
						goto IL_0618;
						IL_036b:
						num2 = 24;
						val = (Image)((DataGridView)DGV_DETL)[num5, DC_Main.i].Value;
						goto IL_038c;
						IL_038c:
						num2 = 25;
						text = Path.GetTempFileName();
						goto IL_0396;
						IL_0396:
						num2 = 26;
						File.Delete(text);
						goto IL_03a1;
						IL_03a1:
						num2 = 27;
						text = Path.ChangeExtension(text, ".jpg");
						goto IL_03b2;
						IL_03b2:
						num2 = 28;
						val.Save(text, ImageFormat.Jpeg);
						goto IL_03c4;
						IL_03c4:
						num2 = 29;
						obj6 = NewLateBinding.LateGet(obj, (Type)null, "Pictures", new object[0], (string[])null, (Type[])null, (bool[])null);
						obj7 = new object[1] { text };
						array = obj7;
						obj8 = new bool[1] { true };
						array2 = obj8;
						obj9 = NewLateBinding.LateGet(obj6, (Type)null, "Insert", obj7, (string[])null, (Type[])null, obj8);
						if (array2[0])
						{
							text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
						}
						objectValue = RuntimeHelpers.GetObjectValue(obj9);
						goto IL_0437;
						IL_0140:
						num2 = 12;
						num7++;
						goto IL_0149;
						IL_00f8:
						num2 = 11;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num7 + 1,
							((DataGridView)DGV_DETL).Columns[num7].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_0140;
						IL_0437:
						num2 = 30;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(objectValue, (Type)null, "ShapeRange", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "LockAspectRatio", new object[1] { 0 }, (string[])null, (Type[])null, false, true);
						goto IL_0470;
						IL_0470:
						num2 = 31;
						obj2 = objectValue;
						goto IL_0477;
						IL_0477:
						num2 = 32;
						NewLateBinding.LateSet(obj2, (Type)null, "Top", new object[1] { NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2]
						{
							DC_Main.i + 2,
							num5 + 1
						}, (string[])null, (Type[])null, (bool[])null), (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null) }, (string[])null, (Type[])null);
						goto IL_04d8;
						IL_04d8:
						num2 = 33;
						NewLateBinding.LateSet(obj2, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2]
						{
							DC_Main.i + 2,
							num5 + 1
						}, (string[])null, (Type[])null, (bool[])null), (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)50) }, (string[])null, (Type[])null);
						goto IL_0545;
						IL_0545:
						num2 = 34;
						NewLateBinding.LateSet(obj2, (Type)null, "Width", new object[1] { 75 }, (string[])null, (Type[])null);
						goto IL_0568;
						IL_0568:
						num2 = 35;
						NewLateBinding.LateSet(obj2, (Type)null, "Height", new object[1] { 60 }, (string[])null, (Type[])null);
						goto IL_058c;
						end_IL_0001_2:
						break;
					}
					num2 = 59;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj10) when (obj10 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj10);
				try0001_dispatch = 2247;
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

	private void BtnDelete_Click(object sender, EventArgs e)
	{
	}

	private void RP_TAG_IMAGE_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0b95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9c: Expected O, but got Unknown
		//IL_0c5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c61: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6b: Expected O, but got Unknown
		//IL_0c7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8d: Expected O, but got Unknown
		//IL_0c0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1b: Expected O, but got Unknown
		//IL_0d0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1a: Expected O, but got Unknown
		//IL_0fce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdd: Expected O, but got Unknown
		//IL_0dcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ddb: Expected O, but got Unknown
		//IL_0dfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e09: Expected O, but got Unknown
		//IL_0e28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e37: Expected O, but got Unknown
		//IL_0eb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec8: Expected O, but got Unknown
		//IL_0ee7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef6: Expected O, but got Unknown
		//IL_0f15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f24: Expected O, but got Unknown
		//IL_104f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1054: Unknown result type (might be due to invalid IL or missing references)
		//IL_105a: Expected O, but got Unknown
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
		((XtraForm)this).SuspendLayout();
		((XtraForm)this).ResumeLayout();
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
			foreach (object control3 in ((Control)Panel1).Controls)
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
			((Form)this).ClientSize = new Size((int)Math.Round(DC_Main.MainPcW), (int)Math.Round(DC_Main.MainPcH));
			((Control)this).Dock = (DockStyle)5;
			ColorConverter colorConverter = new ColorConverter();
			if (DC_Main.MsCoTheme == 2)
			{
				((XtraForm)this).BackColor = Color.Silver;
				Label obj2 = lblBook;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj2).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				Label obj4 = lblBook;
				object? obj5 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj4).ForeColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj6 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
				ComboBox obj7 = cboItemTyp;
				object? obj8 = colorConverter.ConvertFromString("243, 240, 239");
				obj7.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				Panel panel = Panel1;
				object? obj9 = colorConverter.ConvertFromString("Gainsboro");
				((Control)panel).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				CheckBox obj10 = chkItSelect;
				object? obj11 = colorConverter.ConvertFromString("MistyRose");
				((ButtonBase)obj10).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				CheckBox obj12 = chkItSelect;
				object? obj13 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj12).ForeColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				((DataGridView)DGV_PR).BackgroundColor = Color.DarkGray;
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV_PR).AlternatingRowsDefaultCellStyle;
				object? obj14 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				PictureBox picImage = PicImage;
				object? obj15 = colorConverter.ConvertFromString("243, 240, 239");
				((Control)picImage).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj16 = colorConverter.ConvertFromString("200, 205, 210");
				((XtraForm)this).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				ComboBox obj17 = cboItemTyp;
				object? obj18 = colorConverter.ConvertFromString("233, 235, 240");
				obj17.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				Panel panel2 = Panel1;
				object? obj19 = colorConverter.ConvertFromString("Control");
				((Control)panel2).BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				((ButtonBase)chkItSelect).BackColor = Color.LightSlateGray;
				((Control)chkItSelect).ForeColor = Color.White;
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_PR = DGV_PR;
				object? obj20 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV_PR).BackgroundColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV_PR).AlternatingRowsDefaultCellStyle;
				object? obj21 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				PictureBox picImage2 = PicImage;
				object? obj22 = colorConverter.ConvertFromString("233, 235, 240");
				((Control)picImage2).BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj23 = colorConverter.ConvertFromString("205, 220, 220");
				((XtraForm)this).BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj24 = lblBook;
				object? obj25 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj24).ForeColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj26 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				ComboBox obj27 = cboItemTyp;
				object? obj28 = colorConverter.ConvertFromString("238, 244, 236");
				obj27.BackColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				Panel panel3 = Panel1;
				object? obj29 = colorConverter.ConvertFromString("Control");
				((Control)panel3).BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				((ButtonBase)chkItSelect).BackColor = Color.Cornsilk;
				CheckBox obj30 = chkItSelect;
				object? obj31 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj30).ForeColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_PR2 = DGV_PR;
				object? obj32 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_PR2).BackgroundColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV_PR).AlternatingRowsDefaultCellStyle;
				object? obj33 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
				PictureBox picImage3 = PicImage;
				object? obj34 = colorConverter.ConvertFromString("238, 244, 236");
				((Control)picImage3).BackColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tBookCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tBookCode).Font;
				try
				{
					foreach (Control control4 in ((Control)this).Controls)
					{
						Control val3 = control4;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is MaskedTextBox || val3 is SimpleButton || val3 is DateEdit || val3 is CheckBox) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
						{
							val3.Font = new Font(font.FontFamily, (float)num3, font.Style);
						}
					}
					((BaseEdit)tSerchAll).Font = new Font(font.FontFamily, (float)num3, font.Style);
					((Control)cboItemTyp).Font = new Font(font.FontFamily, (float)num3, font.Style);
				}
				finally
				{
					((IDisposable)font)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((Control)nLbrPrc).Font.Size * (1.0 + num2));
				Font font2 = ((Control)nLbrPrc).Font;
				try
				{
					foreach (object control5 in ((Control)Panel1).Controls)
					{
						object objectValue3 = RuntimeHelpers.GetObjectValue(control5);
						NewLateBinding.LateSet(objectValue3, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).Font.Style);
					((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).Font.Style);
					((DataGridView)DGV_DETL).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_DETL).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_DETL).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_DETL).RowTemplate.Height * (1.0 + num2));
					((DataGridView)DGV_PR).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_PR).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_PR).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_PR).Font.Style);
					((DataGridView)DGV_PR).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_PR).Font.Style);
					((DataGridView)DGV_PR).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_PR).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_PR).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_PR).RowTemplate.Height * (1.0 + num2));
				}
				num3 = (int)Math.Ceiling((double)((Control)lblBook).Font.Size * (1.0 + num2));
				((Control)lblBook).Font = new Font(((Control)lblBook).Font.FontFamily, (float)num3, ((Control)lblBook).Font.Style);
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnSave).Font.Size * (1.0 + num2));
				Font font3 = ((BaseStyleControl)BtnSave).Font;
				try
				{
					foreach (object control6 in ((Control)PnlBotam).Controls)
					{
						object objectValue4 = RuntimeHelpers.GetObjectValue(control6);
						NewLateBinding.LateSet(objectValue4, (Type)null, "Font", new object[1] { (object)new Font(font3.FontFamily, (float)num3, font3.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font3)?.Dispose();
				}
			}
			DC_Main.RsQry = "SELECT WAPP_DELAY From CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				numDelay.Value = Conversions.ToDecimal(DC_Main.Tbl.Rows[0]["WAPP_DELAY"]);
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
			PoductMast();
			mFromDt.EditValue = DC_Main.MsSysDate;
			mToDt.EditValue = DC_Main.MsSysDate;
			CurActCtrl = (Control)(object)tMobileNo;
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
		PrCode = "";
		PicImage.Image = null;
		SelectIt = "";
		((DataGridView)DGV_ITM).DataSource = null;
		((DataGridView)DGV_ITM).ClearSelection();
		((DataGridView)DGV_ITM).Rows.Clear();
		((DataGridView)DGV_ITM).Columns.Clear();
		((Control)DGV_ITM).Refresh();
		((Control)PnlIt).Visible = false;
		chkItSelect.Checked = false;
		PoductMast();
		((Control)mFromDt).Focus();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RP_TAG_IMAGE_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_TAG_IMAGE_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_TAG_IMAGE_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CurMainBook = "";
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).Columns.Clear();
		((DataGridView)DGV_DETL).Rows.Clear();
		((Control)DGV_DETL).Refresh();
		CLEAR_DATA();
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void RP_TAG_IMAGE_Activated(object sender, EventArgs e)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		Image value = default(Image);
		Image val = default(Image);
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
				case 386:
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
							goto IL_004b;
						case 4:
							goto IL_0072;
						case 5:
							goto IL_0082;
						case 6:
							goto IL_0088;
						case 7:
							goto IL_00df;
						case 8:
						case 9:
							goto IL_0107;
						case 11:
							goto IL_0115;
						case 10:
						case 12:
						case 13:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 14:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_0082:
					num2 = 5;
					value = val;
					goto IL_0088;
					IL_0088:
					num2 = 6;
					if (DGV_DETL != null && ((DataGridView)DGV_DETL).CurrentRow != null && ((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index >= 0 && ((DataGridView)DGV_DETL)[8, ((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Value != null)
					{
						goto IL_00df;
					}
					goto IL_0107;
					IL_0072:
					num2 = 4;
					PicImage.Image = val;
					goto IL_0082;
					IL_00df:
					num2 = 7;
					((DataGridView)DGV_DETL)[8, ((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Value = value;
					goto IL_0107;
					IL_000b:
					num2 = 2;
					if ((Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath ?? "", (FileAttribute)0), "", false) != 0) & (Operators.CompareString(DC_Main.MsImagePath, "", false) != 0))
					{
						goto IL_004b;
					}
					goto IL_0115;
					IL_0115:
					num2 = 11;
					PicImage.Image = null;
					break;
					IL_0107:
					num2 = 9;
					Mobile_image_Save();
					break;
					IL_004b:
					num2 = 3;
					using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
					{
						val = Image.FromStream(stream);
					}
					goto IL_0072;
					end_IL_0001_2:
					break;
				}
				num2 = 13;
				CurActCtrl.Focus();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 386;
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

	private void PoductMast()
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		((DataGridView)DGV_PR).DataSource = null;
		DC_Main.RsQry = "SELECT B.PR_CODE,C.PR_NAME FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN PRODUCT_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.PR_CODE = C.PR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "' AND A.TAG_NO <> 'N' GROUP BY B.PR_CODE,C.PR_NAME ORDER BY C.PR_NAME";
		DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(table);
		if (dataView.Count > 0)
		{
			((DataGridView)DGV_PR).MultiSelect = false;
			((DataGridView)DGV_PR).AutoGenerateColumns = false;
			((DataGridView)DGV_PR).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 11f, (FontStyle)1);
			if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
			{
				((DataGridView)DGV_PR).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
				((DataGridView)DGV_PR).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
				((DataGridView)DGV_PR).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
				((DataGridView)DGV_PR).RowTemplate.Height = DC_Main.MsGridRowHeight;
			}
			((DataGridView)DGV_PR).ColumnCount = 2;
			((DataGridView)DGV_PR).Columns[0].Visible = false;
			((DataGridView)DGV_PR).Columns[0].DataPropertyName = "PR_CODE";
			((DataGridView)DGV_PR).Columns[0].HeaderText = "Code";
			((DataGridView)DGV_PR).Columns[1].Width = checked((int)Math.Round(200.0 * ColCon));
			((DataGridView)DGV_PR).Columns[1].DataPropertyName = "PR_NAME";
			((DataGridView)DGV_PR).Columns[1].HeaderText = "Name";
			((DataGridView)DGV_PR).DataSource = dataView;
		}
	}

	private void RP_TAG_IMAGE_Closed(object sender, EventArgs e)
	{
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
		}
		else
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;
		}
		PicImage.Image = null;
	}

	private void BtnStock_Click(object sender, EventArgs e)
	{
		if (RsStkSum != null)
		{
			RsStkSum.Clear();
			RsStkSum.Columns.Clear();
		}
		Tag_Summ("Stock");
	}

	private void BtnIn_Click(object sender, EventArgs e)
	{
		if (RsStkSum != null)
		{
			RsStkSum.Clear();
			RsStkSum.Columns.Clear();
		}
		Tag_Summ("In");
	}

	private void BtnOut_Click(object sender, EventArgs e)
	{
		if (RsStkSum != null)
		{
			RsStkSum.Clear();
			RsStkSum.Columns.Clear();
		}
		Tag_Summ("Out");
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgCapture_Click(object sender, EventArgs e)
	{
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
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
					int index = ((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index;
					DC_Main.MsImageNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(((DataGridView)DGV_DETL)[2, index].Value, (object)"_"), ((DataGridView)DGV_DETL)[22, index].Value));
					DC_Main.MsImageType = "TagImage";
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						Image image;
						using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
						{
							image = Image.FromStream(stream);
						}
						PicImage.Image = image;
						((Control)PicImage).Refresh();
						GC.Collect();
						FileSystem.Kill(DC_Main.MsImagePath);
					}
					((Form)MyProject.Forms.UT_WEB_CAM).MdiParent = ((Form)this).MdiParent;
					((Control)MyProject.Forms.UT_WEB_CAM).Show();
					((Control)MyProject.Forms.UT_WEB_CAM).Focus();
					goto end_IL_0001;
				}
				case 347:
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
				try0001_dispatch = 347;
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
	private void BtnImgSelect_Click(object sender, EventArgs e)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Invalid comparison between Unknown and I4
		//IL_0616: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected O, but got Unknown
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected O, but got Unknown
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Expected O, but got Unknown
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
					((FileDialog)DlgOpen).Filter = "JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg";
					((FileDialog)DlgOpen).Title = "Open Image File";
					if ((int)((CommonDialog)DlgOpen).ShowDialog() == 1)
					{
						int index = ((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index;
						DC_Main.MsImageNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(((DataGridView)DGV_DETL)[2, index].Value, (object)"_"), ((DataGridView)DGV_DETL)[22, index].Value));
						DC_Main.MsImageType = "TagImage";
						DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
						if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
						{
							PicImage.Image.Dispose();
							PicImage.Image = null;
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
							((DataGridView)DGV_DETL)[8, ((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Value = PicImage.Image;
							Mobile_image_Save();
							Small_Image();
						}
					}
					goto end_IL_0001;
				case 1566:
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
				try0001_dispatch = 1566;
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
	private void Small_Image()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected O, but got Unknown
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Expected O, but got Unknown
		float num = float.Parse(Conversions.ToString(1));
		Bitmap val = new Bitmap(PicImage.Image);
		int width = ((Image)val).Width;
		num = ((width > 4500) ? float.Parse(Conversions.ToString(0.05)) : ((width > 4000) ? float.Parse(Conversions.ToString(0.07)) : ((width > 3500) ? float.Parse(Conversions.ToString(0.08)) : ((width > 3000) ? float.Parse(Conversions.ToString(0.09)) : ((width > 2500) ? float.Parse(Conversions.ToString(0.1)) : ((width > 2000) ? float.Parse(Conversions.ToString(0.3)) : ((width > 1900) ? float.Parse(Conversions.ToString(0.7)) : ((width > 700) ? float.Parse(Conversions.ToString(0.8)) : ((width <= 500) ? float.Parse(Conversions.ToString(1)) : float.Parse(Conversions.ToString(0.9)))))))))));
		checked
		{
			Bitmap val2 = new Bitmap((int)Math.Round((float)((Image)val).Width * num), (int)Math.Round((float)((Image)val).Height * num));
			Graphics val3 = Graphics.FromImage((Image)(object)val2);
			val3.SmoothingMode = (SmoothingMode)2;
			val3.InterpolationMode = (InterpolationMode)7;
			val3.PixelOffsetMode = (PixelOffsetMode)2;
			val3.DrawImage((Image)(object)val, 0, 0, ((Image)val2).Width + 1, ((Image)val2).Height + 1);
			PicSmall.Image = (Image)(object)val2;
			if (Operators.CompareString(FileSystem.Dir(Application.StartupPath + "\\temp.jpg", (FileAttribute)0), "", false) != 0)
			{
				FileSystem.Kill(Application.StartupPath + "\\temp.jpg");
			}
			PicSmall.Image.Save(Application.StartupPath + "\\temp.jpg");
			long num2 = FileSystem.FileLen(Application.StartupPath + "\\temp.jpg");
			nLbrPrc.Text = "";
			nTotAmt.Text = "";
			string text;
			if (num2 < 1000)
			{
				text = " Bytes";
			}
			else if (num2 > 1000000)
			{
				num2 = (long)Conversion.Int((double)num2 / 1000000.0);
				text = " Mb";
			}
			else
			{
				num2 = (long)Conversion.Int((double)num2 / 1000.0);
				text = " Kb";
			}
			nLbrPrc.Text = Conversions.ToString(num2) + text;
			int num3 = 100;
			if (Operators.CompareString(text, " Kb", false) != 0)
			{
				double num4 = Conversion.Val((object)num2);
				num3 = ((num4 > 30.0) ? 10 : ((num4 > 25.0) ? 15 : ((num4 > 20.0) ? 20 : ((num4 > 15.0) ? 25 : ((num4 > 10.0) ? 30 : ((num4 > 7.0) ? 30 : ((num4 > 5.0) ? 35 : ((num4 > 3.0) ? 35 : ((num4 > 2.0) ? 35 : ((!(num4 > 1.0)) ? 45 : 40))))))))));
			}
			else
			{
				num3 = 50;
			}
			Bitmap val4 = (Bitmap)Image.FromFile(Application.StartupPath + "\\temp.jpg");
			Ac_Image.SaveJPGWithCompressionSetting(PicSmall.Image, DC_Main.MSImageSavePath + "\\SmallImage\\" + DC_Main.MsImageNo + ".jpg", num3);
			((Image)val4).Dispose();
			PicSmall.Image.Dispose();
			PicSmall.Image = null;
			num2 = FileSystem.FileLen(DC_Main.MSImageSavePath + "\\SmallImage\\" + DC_Main.MsImageNo + ".jpg");
			if (num2 < 1000)
			{
				text = " Bytes";
			}
			else if (num2 > 1000000)
			{
				num2 = (long)Conversion.Int((double)num2 / 1000000.0);
				text = " Mb";
			}
			else
			{
				num2 = (long)Conversion.Int((double)num2 / 1000.0);
				text = " Kb";
			}
			nTotAmt.Text = Conversions.ToString(num2) + text;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void Mobile_image_Save()
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		DataRow dataRow = default(DataRow);
		string value = default(string);
		int index = default(int);
		string ftpuri = default(string);
		MemoryStream memoryStream = default(MemoryStream);
		byte[] buffer = default(byte[]);
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
				case 1159:
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
							goto IL_001e;
						case 4:
							goto IL_0048;
						case 5:
							goto IL_0088;
						case 6:
							goto IL_0094;
						case 7:
							goto IL_00d6;
						case 8:
							goto IL_00fa;
						case 9:
							goto IL_0112;
						case 10:
							goto IL_012e;
						case 11:
							goto IL_0147;
						case 12:
						case 13:
							goto IL_0163;
						case 14:
							goto IL_016d;
						case 15:
							goto IL_0193;
						case 16:
							goto IL_019f;
						case 17:
							goto IL_01ab;
						case 18:
							goto IL_023d;
						case 19:
							goto IL_024b;
						case 20:
							goto IL_02dd;
						case 21:
							goto IL_02f0;
						case 22:
							goto IL_02f9;
						case 23:
							goto IL_0309;
						case 24:
							goto IL_031e;
						case 25:
							goto IL_0333;
						case 26:
							goto IL_035a;
						case 27:
							goto IL_038c;
						case 28:
							goto IL_03a1;
						case 29:
							goto IL_03b3;
						case 30:
							goto IL_03c9;
						case 31:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 32:
						case 33:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_03a1:
					num2 = 28;
					dataRow["MOB_IMAGE"] = value;
					goto IL_03b3;
					IL_03b3:
					num2 = 29;
					RsRowImg.Rows.Add(dataRow);
					goto IL_03c9;
					IL_038c:
					num2 = 27;
					dataRow["IMAGE_TYPE"] = "T";
					goto IL_03a1;
					IL_03c9:
					num2 = 30;
					((DbDataAdapter)(object)DC_Main.Da).Update(RsRowImg);
					break;
					IL_000b:
					num2 = 2;
					index = ((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index;
					goto IL_001e;
					IL_001e:
					num2 = 3;
					((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Height = 75;
					goto IL_0048;
					IL_0048:
					num2 = 4;
					DC_Main.MsImageNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(((DataGridView)DGV_DETL)[2, index].Value, (object)"_"), ((DataGridView)DGV_DETL)[22, index].Value));
					goto IL_0088;
					IL_0088:
					num2 = 5;
					DC_Main.MsImageType = "TagImage";
					goto IL_0094;
					IL_0094:
					num2 = 6;
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					goto IL_00d6;
					IL_00d6:
					num2 = 7;
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) == 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_00fa;
					IL_00fa:
					num2 = 8;
					PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
					goto IL_0112;
					IL_0112:
					num2 = 9;
					if (Operators.CompareString(DC_Main.MsUrlPath, "", false) != 0)
					{
						goto IL_012e;
					}
					goto IL_0163;
					IL_012e:
					num2 = 10;
					ftpuri = DC_Main.MsUrlPath + DC_Main.MsImageNo + ".jpg";
					goto IL_0147;
					IL_0147:
					num2 = 11;
					Ac_Image.FtpUploadFile(DC_Main.MsImagePath, ftpuri, DC_Main.MsUrlId, DC_Main.MsUrlPwd);
					goto IL_0163;
					IL_0163:
					num2 = 13;
					memoryStream = new MemoryStream();
					goto IL_016d;
					IL_016d:
					num2 = 14;
					PicImage.Image.Save((Stream)memoryStream, PicImage.Image.RawFormat);
					goto IL_0193;
					IL_0193:
					num2 = 15;
					buffer = memoryStream.GetBuffer();
					goto IL_019f;
					IL_019f:
					num2 = 16;
					value = Convert.ToBase64String(buffer);
					goto IL_01ab;
					IL_01ab:
					num2 = 17;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '"), ((DataGridView)DGV_DETL)[2, index].Value), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[22, index].Value))), (object)""));
					goto IL_023d;
					IL_023d:
					num2 = 18;
					DC_Main.ExeQuteImg(DC_Main.RsQry);
					goto IL_024b;
					IL_024b:
					num2 = 19;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '"), ((DataGridView)DGV_DETL)[2, index].Value), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[22, index].Value))), (object)""));
					goto IL_02dd;
					IL_02dd:
					num2 = 20;
					RsRowImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
					goto IL_02f0;
					IL_02f0:
					num2 = 21;
					DC_Main.MsInsertData();
					goto IL_02f9;
					IL_02f9:
					num2 = 22;
					dataRow = RsRowImg.NewRow();
					goto IL_0309;
					IL_0309:
					num2 = 23;
					dataRow["CO_CODE"] = DC_Main.MCo_code;
					goto IL_031e;
					IL_031e:
					num2 = 24;
					dataRow["LC_CODE"] = DC_Main.MLc_code;
					goto IL_0333;
					IL_0333:
					num2 = 25;
					dataRow["TAG_NO"] = RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[2, index].Value);
					goto IL_035a;
					IL_035a:
					num2 = 26;
					dataRow["VCH_SRNO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[22, index].Value));
					goto IL_038c;
					end_IL_0001_2:
					break;
				}
				num2 = 31;
				RsRowImg.Clear();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1159;
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgDel_Click(object sender, EventArgs e)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Invalid comparison between Unknown and I4
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
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
					int index = ((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index;
					DC_Main.MsImageNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(((DataGridView)DGV_DETL)[2, index].Value, (object)"_"), ((DataGridView)DGV_DETL)[22, index].Value));
					DC_Main.MsImageType = "TagImage";
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Image now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
					{
						goto end_IL_0001;
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '"), ((DataGridView)DGV_DETL)[2, index].Value), (object)"' AND VCH_SRNO = "), ((DataGridView)DGV_DETL)[22, index].Value), (object)""));
					DC_Main.ExeQuteImg(DC_Main.RsQry);
					DC_Main.MsImageType = "TagImage";
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						Image image;
						using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
						{
							image = Image.FromStream(stream);
						}
						PicImage.Image = image;
						((Control)PicImage).Refresh();
						GC.Collect();
						FileSystem.Kill(DC_Main.MsImagePath);
					}
					if (Operators.CompareString(DC_Main.MsUrlPath, "", false) != 0)
					{
						string ftpuri = DC_Main.MsUrlPath + DC_Main.MsImageNo + ".jpg";
						Ac_Image.FtpDeleteFile(ftpuri, DC_Main.MsUrlId, DC_Main.MsUrlPwd);
					}
					PicImage.Image = null;
					goto end_IL_0001;
				}
				case 641:
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
				try0001_dispatch = 641;
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

	private void tItCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + tItCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count != 0)
		{
			return;
		}
		DC_Main.RsQry = "SELECT IT_NAME As ItNameL,IT_CODE as ItCodeL FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY IT_NAME";
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
				tItCode.Text = DC_Main.ColValue[1];
			}
			((TextBoxBase)tItCode).SelectAll();
		}
	}

	private void tGrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND GR_CODE = '" + tGrCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count != 0)
		{
			return;
		}
		DC_Main.RsQry = "SELECT GR_NAME As GrNameL,GR_CODE as GrCodeL,GR_TYPE as TypeL,TRAD_TYPE As TradTypeL FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY GR_NAME";
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
			}
			((TextBoxBase)tGrCode).SelectAll();
		}
	}

	private void DGV_PR_DoubleClick(object sender, EventArgs e)
	{
		PrCode = Conversions.ToString(((DataGridView)DGV_PR).CurrentRow.Cells[0].Value);
		if (RsStkSum != null)
		{
			RsStkSum.Clear();
			RsStkSum.Columns.Clear();
		}
		Tag_Summ("Stock");
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void DGV_DETL_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_0474: Unknown result type (might be due to invalid IL or missing references)
		//IL_047e: Expected O, but got Unknown
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		((Control)DGV_PR).Enabled = true;
		int columnIndex = ((DataGridView)DGV_DETL).CurrentCell.ColumnIndex;
		int index = ((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index;
		if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV_DETL)[0, index].Value, (object)true, false))
		{
			((DataGridView)DGV_DETL)[0, index].Value = false;
		}
		else
		{
			((DataGridView)DGV_DETL)[0, index].Value = true;
		}
		PicImage.Image = null;
		DC_Main.MsImageNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(((DataGridView)DGV_DETL)[2, index].Value, (object)"_"), ((DataGridView)DGV_DETL)[22, index].Value));
		DC_Main.MsImageType = "TagImage";
		DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
		PicImage.Image = null;
		DataTable dataTable;
		if (Operators.CompareString(DC_Main.MsHttpPath, "", false) != 0)
		{
			try
			{
				string address = ((Operators.CompareString(DC_Main.MsAppSchem, "Y", false) != 0) ? (DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg") : (DC_Main.MsHttpPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg"));
				PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '"), ((DataGridView)DGV_DETL)[2, index].Value), (object)"' AND VCH_SRNO = "), ((DataGridView)DGV_DETL)[22, index].Value), (object)""));
				dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
					{
						PicImage.Image = null;
					}
					else
					{
						object obj = Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)"");
						byte[] bA = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj));
						object objectValue = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA));
						PicImage.Image = (Image)objectValue;
					}
				}
				else if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
				{
					Image image;
					using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
					{
						image = Image.FromStream(stream);
					}
					PicImage.Image = image;
				}
				ProjectData.ClearProjectError();
				return;
			}
		}
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '"), ((DataGridView)DGV_DETL)[2, index].Value), (object)"' AND VCH_SRNO = "), ((DataGridView)DGV_DETL)[22, index].Value), (object)""));
		dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
		if (dataTable.Rows.Count > 0)
		{
			if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
			{
				PicImage.Image = null;
				return;
			}
			object obj2 = Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)"");
			byte[] bA2 = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj2));
			object objectValue2 = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA2));
			PicImage.Image = (Image)objectValue2;
		}
		else if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
		{
			Image image2;
			using (Stream stream2 = File.OpenRead(DC_Main.MsImagePath))
			{
				image2 = Image.FromStream(stream2);
			}
			PicImage.Image = image2;
		}
	}

	private void DGV_DETL_DoubleClick(object sender, EventArgs e)
	{
		int index = ((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index;
		((DataGridView)DGV_DETL).Rows[index].Cells[2].Selected = true;
		checked
		{
			if (index > ImageFillEnd)
			{
				int imageFillStart = ImageFillStart;
				int num = index - 1;
				DC_Main.i = imageFillStart;
				while (DC_Main.i <= num)
				{
					((DataGridView)DGV_DETL).Rows[DC_Main.i].Cells[8].Value = null;
					DC_Main.i++;
				}
				ImageFillStart = index;
				ImageFillEnd = index + 75;
				Image_Fill();
			}
		}
	}

	private void BtnWapp_Click(object sender, EventArgs e)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
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
					if (whatsApp.CurrentState == Module_WhatsApp.WhatsAppState.Ready)
					{
						if (Operators.CompareString(tMobileNo.Text, "", false) == 0)
						{
							Interaction.MsgBox((object)"Please Select Mobile No Firt And Try...", (MsgBoxStyle)0, (object)null);
						}
						else
						{
							DgvSms();
						}
					}
					else
					{
						Interaction.MsgBox((object)"Please First Connect Wapp Then Try...", (MsgBoxStyle)0, (object)null);
						((Form)this).Close();
					}
					goto end_IL_0001;
				case 130:
					num = -1;
					switch (num2)
					{
					case 2:
						Interaction.MsgBox((object)"Please Connect Whatsapp Firt And Try...", (MsgBoxStyle)0, (object)null);
						((Form)this).Close();
						goto end_IL_0001;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 130;
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

	private async void DgvSms()
	{
		int num = 0;
		checked
		{
			foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DGV_DETL).Rows)
			{
				DataGridViewRow val = item;
				if (Operators.ConditionalCompareObjectEqual(val.Cells[0].Value, (object)true, false))
				{
					num++;
					val.Cells[3].Value = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(val.Cells[2].Value));
				}
			}
			if (num == 0)
			{
				Interaction.MsgBox((object)"Please Select Image First And Try...", (MsgBoxStyle)0, (object)null);
				return;
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = num;
			ScelectMo = "";
			int num2 = 0;
			if (whatsApp.CurrentState == Module_WhatsApp.WhatsAppState.Ready)
			{
				foreach (DataGridViewRow item2 in (IEnumerable)((DataGridView)DGV_DETL).Rows)
				{
					DataGridViewRow val2 = item2;
					try
					{
						if (!Operators.ConditionalCompareObjectEqual(val2.Cells[0].Value, (object)true, false))
						{
							continue;
						}
						string text = ((Operators.CompareString(DC_Main.MsWappImgGwt, "Y", false) != 0) ? "" : ((Conversion.Val(RuntimeHelpers.GetObjectValue(val2.Cells[18].Value)) != 0.0) ? Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Gr Wt : ", val2.Cells[6].Value), (object)" Mrp : "), val2.Cells[18].Value))) : ((Operators.CompareString(DC_Main.SSRegSrNo, "VS023NPBU", false) != 0) ? Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Gr Wt : ", val2.Cells[6].Value), (object)" Net Wt : "), val2.Cells[7].Value))) : Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Gr Wt : ", val2.Cells[6].Value), (object)" Net Wt : "), val2.Cells[7].Value), (object)"  Size : "), val2.Cells[11].Value))))));
						ScelectMo = tMobileNo.Text;
						if (Operators.CompareString(ScelectMo, "", false) != 0)
						{
							num2++;
							string text2 = DC_Main.MsCountryId + ScelectMo;
							string text3 = Conversions.ToString(RuntimeHelpers.GetObjectValue(Interaction.IIf(text != null, (object)text, (object)null)));
							DC_Main.MsImageNo = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(Operators.ConcatenateObject(val2.Cells[2].Value, (object)"_"), val2.Cells[22].Value)));
							DC_Main.MsImageType = "TagImage";
							DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
							PicImage.Image = null;
							if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
							{
								Image image;
								using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
								{
									image = Image.FromStream(stream);
								}
								PicImage.Image = image;
							}
							else if (Operators.CompareString(DC_Main.MsHttpPath, "", false) != 0)
							{
								try
								{
									PicImage.Image = null;
									string address = ((Operators.CompareString(DC_Main.MsAppSchem, "Y", false) != 0) ? (DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg") : (DC_Main.MsHttpPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg"));
									PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
								}
								catch (Exception projectError)
								{
									ProjectData.SetProjectError(projectError);
									DC_Main.RsQry = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '"), val2.Cells[2].Value), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(val2.Cells[22].Value))), (object)"")));
									DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
									if (dataTable.Rows.Count > 0)
									{
										if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
										{
											PicImage.Image = null;
										}
										else
										{
											object obj = Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)"");
											byte[] bA = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(RuntimeHelpers.GetObjectValue(obj)));
											object objectValue = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA));
											PicImage.Image = (Image)objectValue;
										}
									}
									ProjectData.ClearProjectError();
								}
							}
							if (Operators.CompareString(FileSystem.Dir(Application.StartupPath + "\\temp.jpg", (FileAttribute)0), "", false) != 0)
							{
								FileSystem.Kill(Application.StartupPath + "\\temp.jpg");
							}
							double num3 = 0.04;
							Bitmap val3 = new Bitmap(PicImage.Image);
							int num4 = (int)Math.Round((double)((Image)val3).Width * num3);
							Font val4 = new Font("Calibri", (float)num4);
							string text4 = Conversions.ToString(RuntimeHelpers.GetObjectValue(val2.Cells[2].Value));
							Graphics val5 = Graphics.FromImage((Image)(object)val3);
							try
							{
								SolidBrush val6 = new SolidBrush(Color.Maroon);
								try
								{
									StringFormat val7 = new StringFormat();
									try
									{
										val7.Alignment = (StringAlignment)0;
										val7.LineAlignment = (StringAlignment)2;
										Rectangle rectangle = new Rectangle((int)Math.Round((double)((Image)val3).Width * num3), -(int)Math.Round((double)((Image)val3).Height * num3), ((Image)val3).Width, ((Image)val3).Height);
										val5.DrawString(text4, val4, (Brush)(object)val6, (RectangleF)rectangle, val7);
									}
									finally
									{
										((IDisposable)val7)?.Dispose();
									}
								}
								finally
								{
									((IDisposable)val6)?.Dispose();
								}
							}
							finally
							{
								((IDisposable)val5)?.Dispose();
							}
							val4.Dispose();
							((Image)val3).Save(Application.StartupPath + "\\temp.jpg");
							((Image)val3).Dispose();
							string text5 = Application.StartupPath + "\\temp.jpg";
							string text6 = Conversions.ToString(RuntimeHelpers.GetObjectValue(Interaction.IIf(text5 != null, (object)text5, (object)null)));
							if (Convert.ToInt32(numDelay.Value) > 0)
							{
								await Task.Run([SpecialName] async () =>
								{
									await Task.Delay(Convert.ToInt32(numDelay.Value) * 1000);
								});
							}
							if (text2 != null && (text3 != null || text6 != null))
							{
								MessageRequest val8 = new MessageRequest();
								val8.Phone = text2;
								val8.Message = text3;
								val8.AttachmentPath = text6;
								MessageRequest request = val8;
								RuntimeHelpers.GetObjectValue(await whatsApp.Send(request));
								val2.Cells[5].Value = "Sent";
								if (Convert.ToInt32(numDelay.Value) > 0)
								{
									await Task.Run([SpecialName] async () =>
									{
										await Task.Delay(Convert.ToInt32(numDelay.Value) * 1000);
									});
								}
								num2++;
								if (num2 == 27)
								{
									num2 = 0;
									val2.Cells[5].Value = "Not Sent";
									if (Convert.ToInt32(numDelay.Value) > 0)
									{
										await Task.Run([SpecialName] async () =>
										{
											await Task.Delay(Convert.ToInt32(numDelay.Value) * 1000);
										});
									}
									if (Operators.CompareString(DC_Main.IdWappIdNo, "", false) != 0)
									{
										MessageRequest val9 = new MessageRequest();
										val9.Phone = DC_Main.IdWappIdNo;
										val9.Message = "hi";
										val9.AttachmentPath = "";
										RuntimeHelpers.GetObjectValue(await whatsApp.Send(request));
									}
								}
								((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Selected = true;
							}
						}
						ProgressBar progressBar;
						ProgressBar val10 = (progressBar = ProgressBar1);
						progressBar.Value = val10.Value + 1;
						Application.DoEvents();
					}
					catch (Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						val2.Cells[5].Value = "Not Sent";
						ProjectData.ClearProjectError();
					}
				}
				Interaction.MsgBox((object)"All Message Sent....", (MsgBoxStyle)0, (object)null);
			}
			else
			{
				MessageBox.Show(Conversions.ToString(unchecked((int)whatsApp.CurrentState)));
			}
		}
	}

	private void BtnAc_Click(object sender, EventArgs e)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_ADD1 As AddressL,A.AC_MOBILE As MobileL,A.AC_CITY As CityL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[5];
		DC_Main.ColWidth[0] = 300.0;
		DC_Main.ColWidth[1] = 200.0;
		DC_Main.ColWidth[2] = 110.0;
		DC_Main.ColWidth[3] = 150.0;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[2], "", false) != 0)
		{
			tMobileNo.Text = DC_Main.ColValue[2];
			((Control)tMobileNo).Focus();
		}
	}

	private void tMobileNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13 && Operators.CompareString(tMobileNo.Text, "", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_ADD1 As AddressL,A.AC_MOBILE As MobileL,A.AC_CITY As CityL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[5];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 200.0;
			DC_Main.ColWidth[2] = 110.0;
			DC_Main.ColWidth[3] = 150.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[2], "", false) != 0)
			{
				tMobileNo.Text = DC_Main.ColValue[2];
				((Control)nFromWt).Focus();
			}
		}
	}

	private void nFromWt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nFromWt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nFromWt.Text)), "0.000");
			nToWt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nFromWt.Text) + 1.0), "0.000");
			((Control)nToWt).Focus();
		}
	}

	private void nToWt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nToWt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nToWt.Text)), "0.000");
			SendKeys.Send("{TAB}");
		}
	}

	private void nFromWt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)nFromWt).SelectionStart = 0;
		((TextBoxBase)nFromWt).SelectionLength = Strings.Len(nFromWt.Text);
	}

	private void nToWt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)nToWt).SelectionStart = 0;
		((TextBoxBase)nToWt).SelectionLength = Strings.Len(nToWt.Text);
	}

	private void nToRow_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13 || !((Conversion.Val(nFromRow.Text) != 0.0) & (Conversion.Val(nToRow.Text) != 0.0)))
		{
			return;
		}
		checked
		{
			int num = ((DataGridView)DGV_DETL).Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				((DataGridView)DGV_DETL)[0, DC_Main.M].Value = false;
				DC_Main.M++;
			}
			if (Conversion.Val((object)((DataGridView)DGV_DETL).Rows.Count) < Conversion.Val(nToRow.Text))
			{
				nToRow.Text = Conversions.ToString(Conversion.Val((object)((DataGridView)DGV_DETL).Rows.Count));
			}
			if (Conversion.Val(nToRow.Text) < Conversion.Val(nFromRow.Text))
			{
				Interaction.MsgBox((object)"You Cant Set From Row > To row Please change it...", (MsgBoxStyle)0, (object)null);
				((Control)nFromRow).Focus();
				return;
			}
			double a = Conversion.Val(nFromRow.Text) - 1.0;
			double a2 = Conversion.Val(nToRow.Text) - 1.0;
			int m = (int)Math.Round(a);
			int num2 = (int)Math.Round(a2);
			DC_Main.M = m;
			while (DC_Main.M <= num2)
			{
				DC_Main.R++;
				((DataGridView)DGV_DETL)[0, DC_Main.M].Value = true;
				DC_Main.M++;
			}
		}
	}

	private void nFromRow_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)nToRow).Focus();
		}
	}

	private void nToRow_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)nToRow).SelectionStart = 0;
		((TextBoxBase)nToRow).SelectionLength = Strings.Len(nToRow.Text);
	}

	private void nFromRow_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)nFromRow).SelectionStart = 0;
		((TextBoxBase)nFromRow).SelectionLength = Strings.Len(nFromRow.Text);
	}

	private void cboItemTyp_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			PoductMast();
		}
	}

	private void cboItemTyp_SelectedIndexChanged(object sender, EventArgs e)
	{
		PoductMast();
	}

	private void tBookCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13 || Operators.CompareString(tBookCode.Text, "", false) == 0)
		{
			return;
		}
		DC_Main.RsQry = "Select * From BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + tBookCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count != 0)
		{
			return;
		}
		DC_Main.RsQry = "SELECT A.BOOK_NAME As BookNameL,A.CO_BOOK As BookL FROM BOOK_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  ORDER BY A.BOOK_NAME";
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
			}
			else
			{
				tBookCode.Text = "";
			}
			((Control)tBookCode).Focus();
		}
	}

	private void chkItSelect_Click(object sender, EventArgs e)
	{
		if (chkItSelect.Checked)
		{
			((Control)PnlIt).Visible = true;
			ItmList();
		}
	}

	private void ItmList()
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		ColorConverter colorConverter = new ColorConverter();
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_CODE,A.IT_NAME FROM ITEM_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "", false) == 0, (object)"", (object)("AND IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" ORDER BY A.IT_NAME "));
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV_ITM).Rows.Count <= 0)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_ITM = DGV_ITM;
				((DataGridView)dGV_ITM).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_ITM).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_ITM).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_ITM).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)dGV_ITM).AutoGenerateColumns = false;
				DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
				((DataGridView)dGV_ITM).Columns.Add((DataGridViewColumn)(object)val);
				((DataGridView)dGV_ITM).Columns[0].Width = 50;
				((DataGridViewColumn)val).Name = "Ok";
				((DataGridView)dGV_ITM).Columns.Add("", "Sr");
				((DataGridView)dGV_ITM).Columns[1].Width = 40;
				((DataGridView)dGV_ITM).Columns.Add("", "Itm Name");
				((DataGridView)dGV_ITM).Columns[2].Width = 224;
				((DataGridView)dGV_ITM).Columns.Add("", "It Code");
				((DataGridView)dGV_ITM).Columns[3].Width = 80;
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					((DataGridView)dGV_ITM).Rows.Add();
					((DataGridView)dGV_ITM)[1, DC_Main.i].Value = DC_Main.i + 1;
					((DataGridView)dGV_ITM)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["IT_NAME"]);
					((DataGridView)dGV_ITM)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["IT_CODE"]);
					DC_Main.i++;
				}
				dGV_ITM = null;
			}
		}
	}

	private void BtnAll_Click(object sender, EventArgs e)
	{
		checked
		{
			int num = ((DataGridView)DGV_ITM).Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				((DataGridView)DGV_ITM).Rows[DC_Main.M].Cells["Ok"].Value = true;
				DC_Main.M++;
			}
		}
	}

	private void BtnOk_Click(object sender, EventArgs e)
	{
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		SelectIt = "";
		checked
		{
			int num = ((DataGridView)DGV_ITM).Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV_ITM).Rows[DC_Main.M].Cells["Ok"].Value, (object)true, false))
				{
					SelectIt = Conversions.ToString(Operators.AddObject(Operators.AddObject((object)(SelectIt + "'"), ((DataGridView)DGV_ITM).Rows[DC_Main.M].Cells[3].Value), (object)"',"));
				}
				DC_Main.M++;
			}
			if (Operators.CompareString(SelectIt, "", false) == 0)
			{
				Interaction.MsgBox((object)"Item Selection Not Done...", (MsgBoxStyle)0, (object)null);
				((Control)PnlIt).Visible = false;
			}
			else
			{
				SelectIt = Strings.Mid(SelectIt, 1, Strings.Len(SelectIt) - 1);
				((Control)PnlIt).Visible = false;
				Tag_Summ("Stock");
			}
		}
	}

	private void BtnItCancel_Click(object sender, EventArgs e)
	{
		((DataGridView)DGV_ITM).DataSource = null;
		((DataGridView)DGV_ITM).ClearSelection();
		((DataGridView)DGV_ITM).Rows.Clear();
		((Control)DGV_ITM).Refresh();
		SelectIt = "";
		((Control)PnlIt).Visible = false;
	}

	private void tVchNo_TextChanged(object sender, EventArgs e)
	{
	}

	private void tVchNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		string text = "";
		if (Operators.CompareString(tBookCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Book First....", (MsgBoxStyle)0, (object)null);
			((Control)tBookCode).Focus();
			return;
		}
		DC_Main.RsQry = "SELECT BOOK_TBL_NAME,MAIN_BOOK FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + tBookCode.Text + "' AND (BOOK_TBL_NAME <> '' OR BOOK_TBL_NAME IS NOT NULL)";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["BOOK_TBL_NAME"], (object)""));
			CurMainBook = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MAIN_BOOK"], (object)""));
			if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MAIN_BOOK"], (object)""), (object)"SALES ORDER", false))
			{
				CurMainBook = "";
			}
			DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL FROM " + text + " AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + tBookCode.Text + "' GROUP BY A.VCH_NO,A.VCH_DATE,B.AC_NAME ORDER BY A.VCH_NO";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[4];
			DC_Main.ColWidth[0] = 100.0;
			DC_Main.ColWidth[1] = 120.0;
			DC_Main.ColWidth[2] = 300.0;
			DC_Main.HelpSelect = 0;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tVchNo.Text = DC_Main.ColValue[0];
					((Control)tVchNo).Focus();
				}
				else
				{
					tVchNo.Text = "";
					CurMainBook = "";
				}
			}
		}
		else
		{
			Interaction.MsgBox((object)"Please Update User Mast Field Update and Try....", (MsgBoxStyle)0, (object)null);
		}
	}

	private void tBookCode_TextChanged(object sender, EventArgs e)
	{
	}
}
