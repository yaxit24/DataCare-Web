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
using System.Threading;
using System.Windows.Forms;
using AxCrystal;
using Crystal;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevExpress.Data;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Base;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class RP_TAG_ESTMATE : XtraForm
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlBotam")]
	private FlowLayoutPanel _PnlBotam;

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
	[AccessedThroughProperty("BtnPrint")]
	private SimpleButton _BtnPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSerchAll")]
	private SearchControl _tSerchAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private GridControl _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GridView1")]
	private GridView _GridView1;

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
	[AccessedThroughProperty("BtnSumm")]
	private SimpleButton _BtnSumm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTagNo")]
	private TextBox _tTagNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicImage")]
	private PictureBox _PicImage;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nLbrPrc")]
	private TextBox _nLbrPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nLbrRate")]
	private TextBox _nLbrRate;

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
	[AccessedThroughProperty("tPrCode")]
	private TextBox _tPrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tGrCode")]
	private TextBox _tGrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnImprt")]
	private SimpleButton _BtnImprt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSLImageDelete")]
	private SimpleButton _BtnSLImageDelete;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSvrImgConvert")]
	private SimpleButton _btnSvrImgConvert;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnOldSoftImagImport")]
	private SimpleButton _BtnOldSoftImagImport;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnImgUpload")]
	private SimpleButton _btnImgUpload;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsStkSum;

	private double ColCon;

	private DataTable RsImg;

	private bool CurImgShow;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string[] AryPrCode;

	private double ScanVchSrNo;

	private bool ImgDisplay;

	private const int cSrNo = 0;

	private const int cTagNo = 1;

	private const int cItCode = 2;

	private const int cCounter = 3;

	private const int cDesign = 4;

	private const int cSize = 5;

	private const int cBagWt = 6;

	private const int cPcs = 7;

	private const int cGrWt = 8;

	private const int cOthWt = 9;

	private const int cNetWt = 10;

	private const int cGhtPrc = 11;

	private const int cGhtWt = 12;

	private const int cTouch = 13;

	private const int cWestPrc = 14;

	private const int cFine = 15;

	private const int cItRate = 16;

	private const int cItAmt = 17;

	private const int cLbrPrc = 18;

	private const int cLbrType = 19;

	private const int cLbrRate = 20;

	private const int cLbrAmt = 21;

	private const int cOthAmt = 22;

	private const int cPrCost = 23;

	private const int cMrp = 24;

	private const int cTotAmt = 25;

	private const int cTaxPrc = 26;

	private const int cNetAmt = 27;

	private const int cRateType = 28;

	private const int cVchSrNo = 29;

	private const int cDesignImgId = 30;

	private const int c1SrNo = 0;

	private const int c1ItCode = 1;

	private const int c1ItName = 2;

	private const int c1Pcs = 3;

	private const int c1GrWt = 4;

	private const int c1ConPrc = 5;

	private const int c1RateType = 6;

	private const int c1ItRate = 7;

	private const int c1ItmAmt = 8;

	private const int c1LbrRate = 9;

	private const int c1LbrAmt = 10;

	private const int c1NetAmt = 11;

	private const int c1ConWt = 12;

	private const int c1KrWt = 13;

	private const int c1KrConWt = 14;

	private const int c1ItType = 15;

	private const int c1RowSr = 16;

	internal virtual FlowLayoutPanel PnlBotam
	{
		[CompilerGenerated]
		get
		{
			return _PnlBotam;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = PnlBotam_DoubleClick;
			FlowLayoutPanel val = _PnlBotam;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PnlBotam = value;
			val = _PnlBotam;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
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

	internal virtual SearchControl tSerchAll
	{
		[CompilerGenerated]
		get
		{
			return _tSerchAll;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = tSerchAll_TextChanged;
			SearchControl val = _tSerchAll;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
			}
			_tSerchAll = value;
			val = _tSerchAll;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
			}
		}
	}

	internal virtual GridControl DGV
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
			EventHandler eventHandler = DGV_Click;
			EventHandler eventHandler2 = DGV_DoubleClick;
			GridControl val = _DGV;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
				((Control)val).DoubleClick -= eventHandler2;
			}
			_DGV = value;
			val = _DGV;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
				((Control)val).DoubleClick += eventHandler2;
			}
		}
	}

	internal virtual GridView GridView1
	{
		[CompilerGenerated]
		get
		{
			return _GridView1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			FocusedRowChangedEventHandler val = new FocusedRowChangedEventHandler(GridView1_FocusedRowChanged);
			GridView val2 = _GridView1;
			if (val2 != null)
			{
				((ColumnView)val2).FocusedRowChanged -= val;
			}
			_GridView1 = value;
			val2 = _GridView1;
			if (val2 != null)
			{
				((ColumnView)val2).FocusedRowChanged += val;
			}
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

	internal virtual SimpleButton BtnSumm
	{
		[CompilerGenerated]
		get
		{
			return _BtnSumm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSumm_Click;
			SimpleButton val = _BtnSumm;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSumm = value;
			val = _BtnSumm;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual TextBox tTagNo
	{
		[CompilerGenerated]
		get
		{
			return _tTagNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tTagNo_KeyDown);
			EventHandler eventHandler = TTagNo_TextChanged;
			EventHandler eventHandler2 = tTagNo_LostFocus;
			TextBox val2 = _tTagNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).LostFocus -= eventHandler2;
			}
			_tTagNo = value;
			val2 = _tTagNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).LostFocus += eventHandler2;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_IDTL")]
	private virtual DevComponents.DotNetBar.Controls.DataGridViewX _DGV_IDTL;

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV_IDTL
	{
		get
		{
			return _DGV_IDTL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DGV_IDTL = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_DETL")]
	private virtual DevComponents.DotNetBar.Controls.DataGridViewX _DGV_DETL;

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV_DETL
	{
		get
		{
			return _DGV_DETL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DGV_DETL = value;
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
	[AccessedThroughProperty("nTaxAmt")]
	private virtual TextBox _nTaxAmt;

	internal virtual TextBox nTaxAmt
	{
		get
		{
			return _nTaxAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nTaxAmt = value;
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
	[AccessedThroughProperty("nNetAmt")]
	private virtual TextBox _nNetAmt;

	internal virtual TextBox nNetAmt
	{
		get
		{
			return _nNetAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nNetAmt = value;
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

	internal virtual TextBox nLbrPrc
	{
		[CompilerGenerated]
		get
		{
			return _nLbrPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nLbrPrc_KeyDown);
			TextBox val2 = _nLbrPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nLbrPrc = value;
			val2 = _nLbrPrc;
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

	internal virtual TextBox nLbrRate
	{
		[CompilerGenerated]
		get
		{
			return _nLbrRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nLbrRate_KeyDown);
			TextBox val2 = _nLbrRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nLbrRate = value;
			val2 = _nLbrRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	internal virtual SimpleButton BtnImprt
	{
		[CompilerGenerated]
		get
		{
			return _BtnImprt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnImprt_Click;
			SimpleButton val = _BtnImprt;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnImprt = value;
			val = _BtnImprt;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnSLImageDelete
	{
		[CompilerGenerated]
		get
		{
			return _BtnSLImageDelete;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSLImageDelete_Click;
			SimpleButton val = _BtnSLImageDelete;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSLImageDelete = value;
			val = _BtnSLImageDelete;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnSvrImgConvert
	{
		[CompilerGenerated]
		get
		{
			return _btnSvrImgConvert;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSvrImgConvert_Click;
			SimpleButton val = _btnSvrImgConvert;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSvrImgConvert = value;
			val = _btnSvrImgConvert;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual SimpleButton BtnOldSoftImagImport
	{
		[CompilerGenerated]
		get
		{
			return _BtnOldSoftImagImport;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOldSoftImagImport_Click;
			SimpleButton val = _BtnOldSoftImagImport;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnOldSoftImagImport = value;
			val = _BtnOldSoftImagImport;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("foldbrous")]
	private virtual XtraFolderBrowserDialog _foldbrous;

	internal virtual XtraFolderBrowserDialog foldbrous
	{
		get
		{
			return _foldbrous;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_foldbrous = value;
		}
	}

	internal virtual SimpleButton btnImgUpload
	{
		[CompilerGenerated]
		get
		{
			return _btnImgUpload;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnImgUpload_Click;
			SimpleButton val = _btnImgUpload;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnImgUpload = value;
			val = _btnImgUpload;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
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
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Expected O, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Expected O, but got Unknown
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected O, but got Unknown
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Expected O, but got Unknown
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Expected O, but got Unknown
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Expected O, but got Unknown
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Expected O, but got Unknown
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Expected O, but got Unknown
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected O, but got Unknown
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Expected O, but got Unknown
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Expected O, but got Unknown
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected O, but got Unknown
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected O, but got Unknown
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Expected O, but got Unknown
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_04e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0546: Expected O, but got Unknown
		//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b3: Expected O, but got Unknown
		//IL_065c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0666: Expected O, but got Unknown
		//IL_0771: Unknown result type (might be due to invalid IL or missing references)
		//IL_077b: Expected O, but got Unknown
		//IL_0898: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a2: Expected O, but got Unknown
		//IL_0905: Unknown result type (might be due to invalid IL or missing references)
		//IL_090f: Expected O, but got Unknown
		//IL_09b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c2: Expected O, but got Unknown
		//IL_0a25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2f: Expected O, but got Unknown
		//IL_0ad8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae2: Expected O, but got Unknown
		//IL_0b45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4f: Expected O, but got Unknown
		//IL_0c25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2f: Expected O, but got Unknown
		//IL_0d07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d11: Expected O, but got Unknown
		//IL_0dad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db7: Expected O, but got Unknown
		//IL_0efd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f07: Expected O, but got Unknown
		//IL_0f6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f79: Expected O, but got Unknown
		//IL_1051: Unknown result type (might be due to invalid IL or missing references)
		//IL_105b: Expected O, but got Unknown
		//IL_10f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1101: Expected O, but got Unknown
		//IL_124b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1255: Expected O, but got Unknown
		//IL_1344: Unknown result type (might be due to invalid IL or missing references)
		//IL_134e: Expected O, but got Unknown
		//IL_13d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_13dc: Expected O, but got Unknown
		//IL_13de: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e4: Expected O, but got Unknown
		//IL_1435: Unknown result type (might be due to invalid IL or missing references)
		//IL_143f: Expected O, but got Unknown
		//IL_1572: Unknown result type (might be due to invalid IL or missing references)
		//IL_157c: Expected O, but got Unknown
		//IL_15cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d5: Expected O, but got Unknown
		//IL_15fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1600: Expected O, but got Unknown
		//IL_1696: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a0: Expected O, but got Unknown
		//IL_16f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f9: Expected O, but got Unknown
		//IL_171e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1724: Expected O, but got Unknown
		//IL_19a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a35: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a3f: Expected O, but got Unknown
		//IL_1a62: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d08: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d50: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d74: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1da7: Expected O, but got Unknown
		//IL_1dca: Unknown result type (might be due to invalid IL or missing references)
		//IL_2070: Unknown result type (might be due to invalid IL or missing references)
		//IL_2094: Unknown result type (might be due to invalid IL or missing references)
		//IL_20b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_20dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2105: Unknown result type (might be due to invalid IL or missing references)
		//IL_210f: Expected O, but got Unknown
		//IL_212f: Unknown result type (might be due to invalid IL or missing references)
		//IL_21b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_21bc: Expected O, but got Unknown
		//IL_2226: Unknown result type (might be due to invalid IL or missing references)
		//IL_2230: Expected O, but got Unknown
		//IL_22ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_22f4: Expected O, but got Unknown
		//IL_2362: Unknown result type (might be due to invalid IL or missing references)
		//IL_236c: Expected O, but got Unknown
		//IL_26aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_26b4: Expected O, but got Unknown
		//IL_2789: Unknown result type (might be due to invalid IL or missing references)
		//IL_2793: Expected O, but got Unknown
		//IL_282c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2836: Expected O, but got Unknown
		//IL_296b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2975: Expected O, but got Unknown
		//IL_2a4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a54: Expected O, but got Unknown
		//IL_2aed: Unknown result type (might be due to invalid IL or missing references)
		//IL_2af7: Expected O, but got Unknown
		//IL_2c39: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c43: Expected O, but got Unknown
		//IL_2d18: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d22: Expected O, but got Unknown
		//IL_2dbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dc5: Expected O, but got Unknown
		//IL_3109: Unknown result type (might be due to invalid IL or missing references)
		//IL_312d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3151: Unknown result type (might be due to invalid IL or missing references)
		//IL_3175: Unknown result type (might be due to invalid IL or missing references)
		//IL_319e: Unknown result type (might be due to invalid IL or missing references)
		//IL_31a8: Expected O, but got Unknown
		//IL_31ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_3485: Unknown result type (might be due to invalid IL or missing references)
		//IL_34a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_34cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_34f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_351a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3524: Expected O, but got Unknown
		//IL_354a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3801: Unknown result type (might be due to invalid IL or missing references)
		//IL_3825: Unknown result type (might be due to invalid IL or missing references)
		//IL_3849: Unknown result type (might be due to invalid IL or missing references)
		//IL_386d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3896: Unknown result type (might be due to invalid IL or missing references)
		//IL_38a0: Expected O, but got Unknown
		//IL_38c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_393a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3944: Expected O, but got Unknown
		//IL_3a07: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a11: Expected O, but got Unknown
		//IL_3a92: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a9c: Expected O, but got Unknown
		//IL_3b3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b46: Expected O, but got Unknown
		//IL_3bc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bce: Expected O, but got Unknown
		//IL_3c7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c89: Expected O, but got Unknown
		//IL_3d07: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d11: Expected O, but got Unknown
		//IL_3db1: Unknown result type (might be due to invalid IL or missing references)
		//IL_3dbb: Expected O, but got Unknown
		//IL_3e39: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e43: Expected O, but got Unknown
		//IL_3ee3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eed: Expected O, but got Unknown
		//IL_3f9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fa6: Expected O, but got Unknown
		//IL_403b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4045: Expected O, but got Unknown
		//IL_40c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_40cd: Expected O, but got Unknown
		//IL_41b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_41bc: Expected O, but got Unknown
		//IL_4225: Unknown result type (might be due to invalid IL or missing references)
		//IL_422f: Expected O, but got Unknown
		//IL_42f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_42fb: Expected O, but got Unknown
		//IL_4397: Unknown result type (might be due to invalid IL or missing references)
		//IL_43a1: Expected O, but got Unknown
		//IL_4427: Unknown result type (might be due to invalid IL or missing references)
		//IL_4431: Expected O, but got Unknown
		//IL_451b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4525: Expected O, but got Unknown
		//IL_458e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4598: Expected O, but got Unknown
		//IL_4767: Unknown result type (might be due to invalid IL or missing references)
		//IL_4771: Expected O, but got Unknown
		//IL_47e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_47ec: Expected O, but got Unknown
		//IL_489a: Unknown result type (might be due to invalid IL or missing references)
		//IL_48a4: Expected O, but got Unknown
		//IL_4922: Unknown result type (might be due to invalid IL or missing references)
		//IL_492c: Expected O, but got Unknown
		//IL_499d: Unknown result type (might be due to invalid IL or missing references)
		//IL_49a7: Expected O, but got Unknown
		//IL_4a55: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a5f: Expected O, but got Unknown
		//IL_4acc: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ad6: Expected O, but got Unknown
		components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_TAG_ESTMATE));
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
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		BtnSumm = new SimpleButton();
		btnImgUpload = new SimpleButton();
		Cr = new AxCrystalReport();
		BtnOldSoftImagImport = new SimpleButton();
		lblBook = new Label();
		tSerchAll = new SearchControl();
		DGV = new GridControl();
		GridView1 = new GridView();
		mFromDt = new DateEdit();
		mToDt = new DateEdit();
		BtnStock = new QButton();
		BtnOut = new QButton();
		BtnIn = new QButton();
		cboItemTyp = new ComboBox();
		Label3 = new Label();
		tTagNo = new TextBox();
		Label2 = new Label();
		Panel1 = new Panel();
		btnSvrImgConvert = new SimpleButton();
		BtnSLImageDelete = new SimpleButton();
		BtnImprt = new SimpleButton();
		BtnImgCapture = new QButton();
		BtnImgSelect = new QButton();
		BtnImgDel = new QButton();
		Label6 = new Label();
		nTotAmt = new TextBox();
		Label7 = new Label();
		nTaxAmt = new TextBox();
		Label8 = new Label();
		nNetAmt = new TextBox();
		Label5 = new Label();
		nLbrPrc = new TextBox();
		Label4 = new Label();
		nLbrRate = new TextBox();
		DGV_IDTL = new DevComponents.DotNetBar.Controls.DataGridViewX();
		DGV_DETL = new DevComponents.DotNetBar.Controls.DataGridViewX();
		PicImage = new PictureBox();
		DlgOpen = new OpenFileDialog();
		PicZoom = new PictureBox();
		tPrName = new TextBox();
		Label9 = new Label();
		tPrCode = new TextBox();
		tGrName = new TextBox();
		Label10 = new Label();
		tGrCode = new TextBox();
		Label1 = new Label();
		PicSmall = new PictureBox();
		foldbrous = new XtraFolderBrowserDialog(components);
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)tSerchAll.Properties).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
		((ISupportInitialize)GridView1).BeginInit();
		((ISupportInitialize)mFromDt.Properties.CalendarTimeProperties).BeginInit();
		((ISupportInitialize)mFromDt.Properties).BeginInit();
		((ISupportInitialize)mToDt.Properties.CalendarTimeProperties).BeginInit();
		((ISupportInitialize)mToDt.Properties).BeginInit();
		((Control)Panel1).SuspendLayout();
		((ISupportInitialize)DGV_IDTL).BeginInit();
		((ISupportInitialize)DGV_DETL).BeginInit();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)PicSmall).BeginInit();
		((XtraForm)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSumm);
		((Control)PnlBotam).Controls.Add((Control)(object)btnImgUpload);
		((Control)PnlBotam).Controls.Add((Control)(object)Cr);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnOldSoftImagImport);
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
		((BaseStyleControl)btnImgUpload).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnImgUpload).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnImgUpload).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnImgUpload).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnImgUpload).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnImgUpload).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnImgUpload).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnImgUpload).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnImgUpload).Appearance.Options.UseForeColor = true;
		((BaseButton)btnImgUpload).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnImgUpload).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnImgUpload).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnImgUpload).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnImgUpload).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnImgUpload).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnImgUpload).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnImgUpload).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnImgUpload).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnImgUpload).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnImgUpload).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnImgUpload).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnImgUpload).AppearancePressed.Options.UseFont = true;
		((Control)btnImgUpload).Location = new Point(592, 3);
		((BaseControl)btnImgUpload).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnImgUpload).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnImgUpload).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnImgUpload).Name = "btnImgUpload";
		((Control)btnImgUpload).Size = new Size(132, 35);
		((Control)btnImgUpload).TabIndex = 1170;
		btnImgUpload.Text = "&Export to Server";
		((BaseControl)btnImgUpload).ToolTip = "Export to Sql Server";
		((Control)btnImgUpload).Visible = false;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(558, 3);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 10;
		((BaseStyleControl)BtnOldSoftImagImport).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnOldSoftImagImport).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnOldSoftImagImport).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnOldSoftImagImport).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnOldSoftImagImport).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnOldSoftImagImport).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnOldSoftImagImport).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnOldSoftImagImport).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnOldSoftImagImport).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnOldSoftImagImport).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnOldSoftImagImport).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnOldSoftImagImport).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnOldSoftImagImport).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnOldSoftImagImport).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnOldSoftImagImport).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnOldSoftImagImport).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnOldSoftImagImport).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnOldSoftImagImport).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnOldSoftImagImport).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnOldSoftImagImport).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnOldSoftImagImport).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnOldSoftImagImport).AppearancePressed.Options.UseFont = true;
		((Control)BtnOldSoftImagImport).Location = new Point(392, 3);
		((BaseControl)BtnOldSoftImagImport).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnOldSoftImagImport).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnOldSoftImagImport).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnOldSoftImagImport).Name = "BtnOldSoftImagImport";
		((Control)BtnOldSoftImagImport).Size = new Size(160, 35);
		((Control)BtnOldSoftImagImport).TabIndex = 1169;
		BtnOldSoftImagImport.Text = "&Old Soft Image Imp";
		((BaseControl)BtnOldSoftImagImport).ToolTip = "Party Help";
		((Control)BtnOldSoftImagImport).Visible = false;
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
		lblBook.Text = "Tag Stock Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((Control)tSerchAll).Location = new Point(685, 42);
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
		((Control)tSerchAll).TabIndex = 1;
		((Control)DGV).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)DGV).Location = new Point(21, 12);
		DGV.MainView = (BaseView)(object)GridView1;
		((Control)DGV).Name = "DGV";
		((Control)DGV).Size = new Size(793, 249);
		((Control)DGV).TabIndex = 7;
		DGV.ViewCollection.AddRange((BaseView[])(object)new BaseView[1] { (BaseView)GridView1 });
		((BaseView)GridView1).GridControl = DGV;
		((BaseView)GridView1).Name = "GridView1";
		((ColumnViewOptionsBehavior)GridView1.OptionsBehavior).Editable = false;
		GridView1.OptionsView.ShowFooter = true;
		mFromDt.EditValue = null;
		((Control)mFromDt).Location = new Point(35, 42);
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
		((Control)mFromDt).TabIndex = 8;
		mToDt.EditValue = null;
		((Control)mToDt).Location = new Point(142, 42);
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
		((Control)mToDt).TabIndex = 9;
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
		((Control)BtnStock).Location = new Point(399, 75);
		((Control)BtnStock).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnStock).Name = "BtnStock";
		((Control)BtnStock).Size = new Size(143, 37);
		((Control)BtnStock).TabIndex = 116;
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
		((Control)BtnOut).Location = new Point(214, 75);
		((Control)BtnOut).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnOut).Name = "BtnOut";
		((Control)BtnOut).Size = new Size(143, 37);
		((Control)BtnOut).TabIndex = 117;
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
		((Control)BtnIn).Location = new Point(35, 75);
		((Control)BtnIn).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnIn).Name = "BtnIn";
		((Control)BtnIn).Size = new Size(143, 37);
		((Control)BtnIn).TabIndex = 118;
		BtnIn.Text = "&In Tag";
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(685, 75);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(120, 22);
		((Control)cboItemTyp).TabIndex = 123;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(601, 75);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(74, 20);
		((Control)Label3).TabIndex = 124;
		Label3.Text = "Item Type";
		Label3.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tTagNo).BackColor = Color.FromArgb(255, 224, 192);
		((Control)tTagNo).Font = new Font("Tahoma", 9f);
		((Control)tTagNo).Location = new Point(893, 355);
		((TextBoxBase)tTagNo).MaxLength = 15;
		((Control)tTagNo).Name = "tTagNo";
		((Control)tTagNo).Size = new Size(97, 22);
		((Control)tTagNo).TabIndex = 127;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(832, 357);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(55, 20);
		((Control)Label2).TabIndex = 128;
		Label2.Text = "TagNo";
		Label2.TextAlign = (ContentAlignment)64;
		((Control)Panel1).BackColor = Color.SeaShell;
		Panel1.BorderStyle = (BorderStyle)1;
		((Control)Panel1).Controls.Add((Control)(object)btnSvrImgConvert);
		((Control)Panel1).Controls.Add((Control)(object)BtnSLImageDelete);
		((Control)Panel1).Controls.Add((Control)(object)BtnImprt);
		((Control)Panel1).Controls.Add((Control)(object)BtnImgCapture);
		((Control)Panel1).Controls.Add((Control)(object)BtnImgSelect);
		((Control)Panel1).Controls.Add((Control)(object)BtnImgDel);
		((Control)Panel1).Controls.Add((Control)(object)Label6);
		((Control)Panel1).Controls.Add((Control)(object)nTotAmt);
		((Control)Panel1).Controls.Add((Control)(object)Label7);
		((Control)Panel1).Controls.Add((Control)(object)nTaxAmt);
		((Control)Panel1).Controls.Add((Control)(object)Label8);
		((Control)Panel1).Controls.Add((Control)(object)nNetAmt);
		((Control)Panel1).Controls.Add((Control)(object)Label5);
		((Control)Panel1).Controls.Add((Control)(object)nLbrPrc);
		((Control)Panel1).Controls.Add((Control)(object)Label4);
		((Control)Panel1).Controls.Add((Control)(object)nLbrRate);
		((Control)Panel1).Controls.Add((Control)(object)DGV_IDTL);
		((Control)Panel1).Controls.Add((Control)(object)Label2);
		((Control)Panel1).Controls.Add((Control)(object)DGV_DETL);
		((Control)Panel1).Controls.Add((Control)(object)tTagNo);
		((Control)Panel1).Controls.Add((Control)(object)PicImage);
		((Control)Panel1).Controls.Add((Control)(object)DGV);
		((Control)Panel1).Location = new Point(-10, 108);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(1319, 458);
		((Control)Panel1).TabIndex = 129;
		((BaseStyleControl)btnSvrImgConvert).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnSvrImgConvert).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnSvrImgConvert).Appearance.Font = new Font("Segoe UI Semibold", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnSvrImgConvert).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnSvrImgConvert).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnSvrImgConvert).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnSvrImgConvert).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnSvrImgConvert).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnSvrImgConvert).Appearance.Options.UseForeColor = true;
		((BaseButton)btnSvrImgConvert).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnSvrImgConvert).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnSvrImgConvert).AppearanceHovered.Font = new Font("Arial", 9f);
		((BaseButton)btnSvrImgConvert).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnSvrImgConvert).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnSvrImgConvert).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnSvrImgConvert).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnSvrImgConvert).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnSvrImgConvert).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnSvrImgConvert).AppearancePressed.Font = new Font("Arial", 9f);
		((BaseButton)btnSvrImgConvert).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnSvrImgConvert).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnSvrImgConvert).AppearancePressed.Options.UseFont = true;
		((Control)btnSvrImgConvert).Location = new Point(1146, 82);
		((BaseControl)btnSvrImgConvert).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnSvrImgConvert).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnSvrImgConvert).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnSvrImgConvert).Name = "btnSvrImgConvert";
		((Control)btnSvrImgConvert).Size = new Size(39, 29);
		((Control)btnSvrImgConvert).TabIndex = 1159;
		btnSvrImgConvert.Text = "IC";
		((BaseControl)btnSvrImgConvert).ToolTip = "Server Image Convert";
		((BaseStyleControl)BtnSLImageDelete).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnSLImageDelete).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnSLImageDelete).Appearance.Font = new Font("Segoe UI Semibold", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnSLImageDelete).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnSLImageDelete).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnSLImageDelete).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnSLImageDelete).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnSLImageDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSLImageDelete).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnSLImageDelete).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnSLImageDelete).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnSLImageDelete).AppearanceHovered.Font = new Font("Arial", 9f);
		((BaseButton)BtnSLImageDelete).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnSLImageDelete).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnSLImageDelete).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnSLImageDelete).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnSLImageDelete).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnSLImageDelete).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnSLImageDelete).AppearancePressed.Font = new Font("Arial", 9f);
		((BaseButton)BtnSLImageDelete).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnSLImageDelete).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnSLImageDelete).AppearancePressed.Options.UseFont = true;
		((Control)BtnSLImageDelete).Enabled = false;
		((Control)BtnSLImageDelete).Location = new Point(1146, 47);
		((BaseControl)BtnSLImageDelete).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnSLImageDelete).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnSLImageDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSLImageDelete).Name = "BtnSLImageDelete";
		((Control)BtnSLImageDelete).Size = new Size(39, 29);
		((Control)BtnSLImageDelete).TabIndex = 1158;
		BtnSLImageDelete.Text = "SD";
		((BaseControl)BtnSLImageDelete).ToolTip = "Sales Image Delete";
		((BaseStyleControl)BtnImprt).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnImprt).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnImprt).Appearance.Font = new Font("Segoe UI Semibold", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnImprt).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnImprt).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnImprt).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnImprt).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnImprt).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnImprt).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnImprt).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnImprt).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnImprt).AppearanceHovered.Font = new Font("Arial", 9f);
		((BaseButton)BtnImprt).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnImprt).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnImprt).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnImprt).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnImprt).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnImprt).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnImprt).AppearancePressed.Font = new Font("Arial", 9f);
		((BaseButton)BtnImprt).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnImprt).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnImprt).AppearancePressed.Options.UseFont = true;
		((Control)BtnImprt).Location = new Point(1146, 12);
		((BaseControl)BtnImprt).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnImprt).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnImprt).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImprt).Name = "BtnImprt";
		((Control)BtnImprt).Size = new Size(39, 29);
		((Control)BtnImprt).TabIndex = 1157;
		BtnImprt.Text = "MI";
		((BaseControl)BtnImprt).ToolTip = "Mobile Image Import";
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
		((Control)BtnImgCapture).Location = new Point(1146, 131);
		((Control)BtnImgCapture).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnImgCapture).Name = "BtnImgCapture";
		((Control)BtnImgCapture).Size = new Size(39, 37);
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
		((Control)BtnImgSelect).Location = new Point(1146, 177);
		((Control)BtnImgSelect).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnImgSelect).Name = "BtnImgSelect";
		((Control)BtnImgSelect).Size = new Size(39, 37);
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
		((Control)BtnImgDel).Location = new Point(1146, 223);
		((Control)BtnImgDel).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnImgDel).Name = "BtnImgDel";
		((Control)BtnImgDel).Size = new Size(39, 37);
		((Control)BtnImgDel).TabIndex = 1152;
		BtnImgDel.Text = "D";
		((QControl)BtnImgDel).ToolTipText = "Image Delete";
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(999, 418);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(44, 20);
		((Control)Label6).TabIndex = 1151;
		Label6.Text = "Total";
		Label6.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nTotAmt).BackColor = Color.FromArgb(255, 224, 192);
		((Control)nTotAmt).Font = new Font("Tahoma", 15.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nTotAmt).Location = new Point(1050, 411);
		((TextBoxBase)nTotAmt).MaxLength = 15;
		((Control)nTotAmt).Name = "nTotAmt";
		((Control)nTotAmt).Size = new Size(135, 33);
		((Control)nTotAmt).TabIndex = 1150;
		nTotAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(1004, 385);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(68, 20);
		((Control)Label7).TabIndex = 1149;
		Label7.Text = "Tax";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)nTaxAmt).Font = new Font("Tahoma", 9f);
		((Control)nTaxAmt).Location = new Point(1078, 383);
		((TextBoxBase)nTaxAmt).MaxLength = 15;
		((Control)nTaxAmt).Name = "nTaxAmt";
		((Control)nTaxAmt).Size = new Size(107, 22);
		((Control)nTaxAmt).TabIndex = 1148;
		nTaxAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(996, 357);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(76, 20);
		((Control)Label8).TabIndex = 1147;
		Label8.Text = "Net Amt";
		Label8.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nNetAmt).BackColor = Color.Lavender;
		((Control)nNetAmt).Font = new Font("Tahoma", 9f);
		((Control)nNetAmt).Location = new Point(1078, 355);
		((TextBoxBase)nNetAmt).MaxLength = 15;
		((Control)nNetAmt).Name = "nNetAmt";
		((Control)nNetAmt).Size = new Size(107, 22);
		((Control)nNetAmt).TabIndex = 1146;
		nNetAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(819, 413);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(68, 20);
		((Control)Label5).TabIndex = 1145;
		Label5.Text = "Lbr %";
		Label5.TextAlign = (ContentAlignment)64;
		((Control)nLbrPrc).Font = new Font("Tahoma", 9f);
		((Control)nLbrPrc).Location = new Point(893, 411);
		((TextBoxBase)nLbrPrc).MaxLength = 15;
		((Control)nLbrPrc).Name = "nLbrPrc";
		((Control)nLbrPrc).Size = new Size(97, 22);
		((Control)nLbrPrc).TabIndex = 1144;
		nLbrPrc.TextAlign = (HorizontalAlignment)1;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(819, 385);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(68, 20);
		((Control)Label4).TabIndex = 1143;
		Label4.Text = "Lbr Rate";
		Label4.TextAlign = (ContentAlignment)64;
		((Control)nLbrRate).Font = new Font("Tahoma", 9f);
		((Control)nLbrRate).Location = new Point(893, 383);
		((TextBoxBase)nLbrRate).MaxLength = 15;
		((Control)nLbrRate).Name = "nLbrRate";
		((Control)nLbrRate).Size = new Size(97, 22);
		((Control)nLbrRate).TabIndex = 1142;
		nLbrRate.TextAlign = (HorizontalAlignment)1;
		((DataGridView)DGV_IDTL).AllowUserToAddRows = false;
		((DataGridView)DGV_IDTL).AllowUserToDeleteRows = false;
		((DataGridView)DGV_IDTL).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_IDTL).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV_IDTL).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_IDTL).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_IDTL).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_IDTL).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV_IDTL).ColumnHeadersHeight = 30;
		((DataGridView)DGV_IDTL).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(30, 57, 91);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_IDTL).DefaultCellStyle = val3;
		((DataGridView)DGV_IDTL).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_IDTL).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_IDTL).Location = new Point(21, 349);
		((Control)DGV_IDTL).Name = "DGV_IDTL";
		DGV_IDTL.PaintEnhancedSelection = false;
		((DataGridView)DGV_IDTL).ReadOnly = true;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_IDTL).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV_IDTL).RowHeadersVisible = false;
		((DataGridView)DGV_IDTL).RowHeadersWidth = 20;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_IDTL).RowsDefaultCellStyle = val5;
		DGV_IDTL.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_IDTL.SelectAllSignVisible = false;
		((DataGridView)DGV_IDTL).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_IDTL).Size = new Size(793, 94);
		((DataGridView)DGV_IDTL).StandardTab = true;
		((Control)DGV_IDTL).TabIndex = 1141;
		((DataGridView)DGV_DETL).AllowUserToAddRows = false;
		((DataGridView)DGV_DETL).AllowUserToDeleteRows = false;
		((DataGridView)DGV_DETL).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DGV_DETL).BackgroundColor = Color.SeaShell;
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
		((Control)DGV_DETL).Location = new Point(21, 267);
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
		((Control)DGV_DETL).Size = new Size(1164, 76);
		((DataGridView)DGV_DETL).StandardTab = true;
		((Control)DGV_DETL).TabIndex = 1140;
		((Control)PicImage).BackColor = Color.LavenderBlush;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(826, 12);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(310, 249);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1139;
		PicImage.TabStop = false;
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((Control)PicZoom).BackColor = Color.Transparent;
		PicZoom.ImeMode = (ImeMode)0;
		((Control)PicZoom).Location = new Point(12, 70);
		((Control)PicZoom).Name = "PicZoom";
		((Control)PicZoom).Size = new Size(12, 32);
		PicZoom.SizeMode = (PictureBoxSizeMode)4;
		PicZoom.TabIndex = 1156;
		PicZoom.TabStop = false;
		((TextBoxBase)tPrName).BackColor = Color.PapayaWhip;
		((Control)tPrName).Font = new Font("Tahoma", 9f);
		((Control)tPrName).Location = new Point(942, 42);
		((TextBoxBase)tPrName).MaxLength = 50;
		((Control)tPrName).Name = "tPrName";
		((Control)tPrName).Size = new Size(234, 22);
		((Control)tPrName).TabIndex = 1159;
		((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(815, 42);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(60, 20);
		((Control)Label9).TabIndex = 1158;
		Label9.Text = "Pr Code";
		Label9.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tPrCode).BackColor = Color.White;
		((Control)tPrCode).Font = new Font("Tahoma", 9f);
		((Control)tPrCode).Location = new Point(881, 41);
		((TextBoxBase)tPrCode).MaxLength = 2;
		((Control)tPrCode).Name = "tPrCode";
		((Control)tPrCode).Size = new Size(55, 22);
		((Control)tPrCode).TabIndex = 1157;
		((TextBoxBase)tGrName).BackColor = Color.PapayaWhip;
		((Control)tGrName).Font = new Font("Tahoma", 9f);
		((Control)tGrName).Location = new Point(942, 75);
		((TextBoxBase)tGrName).MaxLength = 50;
		((Control)tGrName).Name = "tGrName";
		((Control)tGrName).Size = new Size(234, 22);
		((Control)tGrName).TabIndex = 1162;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(811, 76);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(64, 20);
		((Control)Label10).TabIndex = 1161;
		Label10.Text = "Gr Code";
		Label10.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tGrCode).BackColor = Color.White;
		((Control)tGrCode).Font = new Font("Tahoma", 9f);
		((Control)tGrCode).Location = new Point(881, 75);
		((TextBoxBase)tGrCode).MaxLength = 3;
		((Control)tGrCode).Name = "tGrCode";
		((Control)tGrCode).Size = new Size(55, 22);
		((Control)tGrCode).TabIndex = 1160;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(601, 42);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(74, 20);
		((Control)Label1).TabIndex = 1163;
		Label1.Text = "Tag Filter";
		Label1.TextAlign = (ContentAlignment)64;
		((Control)PicSmall).BackColor = Color.LavenderBlush;
		PicSmall.BorderStyle = (BorderStyle)1;
		PicSmall.ImeMode = (ImeMode)0;
		((Control)PicSmall).Location = new Point(1244, 41);
		((Control)PicSmall).Name = "PicSmall";
		((Control)PicSmall).Size = new Size(53, 33);
		PicSmall.SizeMode = (PictureBoxSizeMode)4;
		PicSmall.TabIndex = 1160;
		PicSmall.TabStop = false;
		((Control)PicSmall).Visible = false;
		((XtraCommonDialog)foldbrous).Location = new Point(-11, 0);
		foldbrous.SelectedPath = "XtraFolderBrowserDialog1";
		((XtraForm)this).Appearance.BackColor = SystemColors.ButtonHighlight;
		((XtraForm)this).Appearance.Options.UseBackColor = true;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)PicSmall);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)tGrName);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)tGrCode);
		((Control)this).Controls.Add((Control)(object)tPrName);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)tPrCode);
		((Control)this).Controls.Add((Control)(object)PicZoom);
		((Control)this).Controls.Add((Control)(object)Panel1);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
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
		((Control)this).Name = "RP_TAG_ESTMATE";
		((XtraForm)this).Text = "Tag Stock Report";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)tSerchAll.Properties).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((ISupportInitialize)GridView1).EndInit();
		((ISupportInitialize)mFromDt.Properties.CalendarTimeProperties).EndInit();
		((ISupportInitialize)mFromDt.Properties).EndInit();
		((ISupportInitialize)mToDt.Properties.CalendarTimeProperties).EndInit();
		((ISupportInitialize)mToDt.Properties).EndInit();
		((Control)Panel1).ResumeLayout(false);
		((Control)Panel1).PerformLayout();
		((ISupportInitialize)DGV_IDTL).EndInit();
		((ISupportInitialize)DGV_DETL).EndInit();
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)PicSmall).EndInit();
		((XtraForm)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public RP_TAG_ESTMATE()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		((Form)this).Load += RP_TAG_ESTMATE_Load;
		((Form)this).Deactivate += RP_TAG_ESTMATE_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_TAG_ESTMATE_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_TAG_ESTMATE_KeyDown);
		((Form)this).Activated += RP_TAG_ESTMATE_Activated;
		((Form)this).Closed += RP_TAG_ESTMATE_Closed;
		InitializeComponent();
	}

	private void DGV_DETL_CLEAR()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_0f22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f2c: Expected O, but got Unknown
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((DataGridView)DGV_DETL).Columns.Clear();
		((Control)DGV_DETL).Refresh();
		((DataGridView)DGV_DETL).MultiSelect = false;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 9f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV_DETL).AutoGenerateColumns = false;
		((DataGridView)DGV_DETL).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "TagNo");
			((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "ItCode");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Counter");
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Design");
			((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Size");
			((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "BagWt");
			((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Pcs");
			((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns.Add("", "GrWt");
			((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "LsWt");
			((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "NetWt");
			((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Ght%");
			((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "GhtWt");
			((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Touch");
			((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "West%");
			((DataGridView)DGV_DETL).Columns[14].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Fine");
			((DataGridView)DGV_DETL).Columns[15].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "ItRate");
			((DataGridView)DGV_DETL).Columns[16].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "ItAmt");
			((DataGridView)DGV_DETL).Columns[17].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Lbr%");
			((DataGridView)DGV_DETL).Columns[18].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "LType");
			((DataGridView)DGV_DETL).Columns[19].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "LbrRate");
			((DataGridView)DGV_DETL).Columns[20].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[20].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "LbrAmt");
			((DataGridView)DGV_DETL).Columns[21].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[21].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "OthAmt");
			((DataGridView)DGV_DETL).Columns[22].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[22].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[22].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "PrCost");
			((DataGridView)DGV_DETL).Columns[23].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[23].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[23].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Mrp");
			((DataGridView)DGV_DETL).Columns[24].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[24].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[24].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "TotAmt");
			((DataGridView)DGV_DETL).Columns[25].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[25].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[25].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Tax%");
			((DataGridView)DGV_DETL).Columns[26].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[26].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[26].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "NetAmt");
			((DataGridView)DGV_DETL).Columns[27].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[27].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[27].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "RateType");
			((DataGridView)DGV_DETL).Columns[28].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "VchSrNo");
			((DataGridView)DGV_DETL).Columns[29].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "DesignId");
			((DataGridView)DGV_DETL).Columns[30].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			DataView dataView = new DataView(DC_Main.RsClDetl);
			if (dataView.Count > 0)
			{
				DC_Main.M = 1;
				do
				{
					dataView.RowFilter = " BOOK_NAME = 'TAG ESTMATE' AND COL_NAME = '" + ((DataGridView)DGV_DETL).Columns[DC_Main.M].HeaderText + "'";
					if (dataView.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(dataView[0]["YES_NO"], (object)"N", false))
						{
							((DataGridView)DGV_DETL).Columns[DC_Main.M].Visible = false;
						}
						((DataGridView)DGV_DETL).Columns[DC_Main.M].HeaderText = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);
					}
					DC_Main.M++;
				}
				while (DC_Main.M <= 26);
			}
			((DataGridView)DGV_DETL).Rows.Add();
			((DataGridView)DGV_DETL)[0, 0].Value = "1";
			DGV_IDTL_CLEAR();
		}
	}

	private void DGV_IDTL_CLEAR()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_07a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b3: Expected O, but got Unknown
		((DataGridView)DGV_IDTL).DataSource = null;
		((DataGridView)DGV_IDTL).ClearSelection();
		((DataGridView)DGV_IDTL).Rows.Clear();
		((DataGridView)DGV_IDTL).Columns.Clear();
		((Control)DGV_IDTL).Refresh();
		((DataGridView)DGV_IDTL).MultiSelect = false;
		((DataGridView)DGV_IDTL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 9f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_IDTL).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV_IDTL).AutoGenerateColumns = false;
		((DataGridView)DGV_IDTL).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV_IDTL).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns.Add("", "ItCode");
			((DataGridView)DGV_IDTL).Columns[1].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns.Add("", "ItName");
			((DataGridView)DGV_IDTL).Columns[2].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns.Add("", "Pcs");
			((DataGridView)DGV_IDTL).Columns[3].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_IDTL).Columns.Add("", "Weight");
			((DataGridView)DGV_IDTL).Columns[4].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_IDTL).Columns[4].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_IDTL).Columns.Add("", "Con%");
			((DataGridView)DGV_IDTL).Columns[5].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_IDTL).Columns[5].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_IDTL).Columns.Add("", "P/W");
			((DataGridView)DGV_IDTL).Columns[6].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns.Add("", "Rate");
			((DataGridView)DGV_IDTL).Columns[7].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_IDTL).Columns[7].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_IDTL).Columns.Add("", "ItAmt");
			((DataGridView)DGV_IDTL).Columns[8].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_IDTL).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_IDTL).Columns.Add("", "LbrRate");
			((DataGridView)DGV_IDTL).Columns[9].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_IDTL).Columns[9].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_IDTL).Columns.Add("", "LbrAmt");
			((DataGridView)DGV_IDTL).Columns[10].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_IDTL).Columns[10].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_IDTL).Columns.Add("", "NetAmt");
			((DataGridView)DGV_IDTL).Columns[11].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_IDTL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_IDTL).Columns[11].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_IDTL).Columns.Add("", "ConWt");
			((DataGridView)DGV_IDTL).Columns[12].Visible = false;
			((DataGridView)DGV_IDTL).Columns.Add("", "KrWt");
			((DataGridView)DGV_IDTL).Columns[13].Visible = false;
			((DataGridView)DGV_IDTL).Columns.Add("", "KrConWt");
			((DataGridView)DGV_IDTL).Columns[14].Visible = false;
			((DataGridView)DGV_IDTL).Columns.Add("", "ItType");
			((DataGridView)DGV_IDTL).Columns[15].Visible = false;
			((DataGridView)DGV_IDTL).Columns.Add("", "RowSrNo");
			((DataGridView)DGV_IDTL).Columns[16].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_IDTL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
		}
	}

	private void tTagNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO,A.VCH_SRNO,B.VCH_DATE FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + tTagNo.Text + "'"), Interaction.IIf(ScanVchSrNo == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(ScanVchSrNo)) ?? ""))), (object)" GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_DATE HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_DATE DESC"));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			DC_Main.RsQry = "Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_DATE From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_DATE HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_DATE DESC";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[10];
			DC_Main.ColWidth[0] = 120.0;
			DC_Main.ColWidth[1] = 300.0;
			DC_Main.ColWidth[2] = 100.0;
			DC_Main.ColWidth[3] = 120.0;
			DC_Main.ColWidth[4] = 100.0;
			DC_Main.ColWidth[5] = 100.0;
			DC_Main.ColWidth[6] = 110.0;
			DC_Main.ColWidth[7] = 0.0;
			DC_Main.ColWidth[8] = 0.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tTagNo.Text = DC_Main.ColValue[0];
					ScanVchSrNo = Conversions.ToDouble(DC_Main.ColValue[7]);
					((Control)tTagNo).Focus();
				}
				else
				{
					tTagNo.Text = "";
					ScanVchSrNo = 0.0;
					((Control)tTagNo).Focus();
				}
			}
		}
		else
		{
			ImgDisplay = false;
			ScanVchSrNo = Conversions.ToDouble(DC_Main.Rshlp.Rows[0]["VCH_SRNO"]);
			Tag_Value();
			((TextBoxBase)tTagNo).SelectAll();
			((Control)tTagNo).Focus();
		}
	}

	private void TTagNo_TextChanged(object sender, EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void Tag_Value()
	{
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1848: Unknown result type (might be due to invalid IL or missing references)
		//IL_1852: Expected O, but got Unknown
		//IL_1a6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a74: Expected O, but got Unknown
		if (ScanVchSrNo == 1.0)
		{
			DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.GR_CODE,C.GR_RATE FROM (BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE)LEFT JOIN GROUP_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.GR_CODE = C.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + tTagNo.Text + "' ORDER BY VCH_DATE DESC ";
			ScanVchSrNo = 0.0;
			if (DC_Main.Rshlp.Rows.Count > 1)
			{
				DC_Main.RsQry = string.Concat("Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_DATE From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + tTagNo.Text, "' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_DATE HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_DATE DESC");
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[10];
				DC_Main.ColWidth[0] = 120.0;
				DC_Main.ColWidth[1] = 300.0;
				DC_Main.ColWidth[2] = 100.0;
				DC_Main.ColWidth[3] = 120.0;
				DC_Main.ColWidth[4] = 100.0;
				DC_Main.ColWidth[5] = 100.0;
				DC_Main.ColWidth[6] = 110.0;
				DC_Main.ColWidth[7] = 0.0;
				DC_Main.ColWidth[8] = 0.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (DC_Main.HelpClose)
				{
					return;
				}
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tTagNo.Text = DC_Main.ColValue[0];
					ScanVchSrNo = Conversions.ToDouble(DC_Main.ColValue[7]);
					DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.GR_CODE,C.GR_RATE FROM (BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE)LEFT JOIN GROUP_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.GR_CODE = C.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + tTagNo.Text + "' AND A.VCH_SRNO = " + Conversions.ToString(ScanVchSrNo) + " ";
					ScanVchSrNo = 0.0;
				}
			}
		}
		else if (ScanVchSrNo != 0.0)
		{
			DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.GR_CODE,C.GR_RATE FROM (BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE)LEFT JOIN GROUP_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.GR_CODE = C.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + tTagNo.Text + "' AND A.VCH_SRNO = " + Conversions.ToString(ScanVchSrNo) + " ";
			ScanVchSrNo = 0.0;
		}
		else
		{
			DC_Main.RsQry = string.Concat(string.Concat("SELECT A.*,B.IT_NAME,B.GR_CODE,C.GR_RATE FROM (BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE)LEFT JOIN GROUP_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.GR_CODE = C.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + ((ColumnView)GridView1).GetFocusedRowCellValue("TagNo").ToString(), "' AND A.VCH_SRNO = '", ((ColumnView)GridView1).GetFocusedRowCellValue("TagId").ToString()), "' ");
			tTagNo.Text = ((ColumnView)GridView1).GetFocusedRowCellValue("TagNo").ToString();
		}
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL = DGV_DETL;
				((DataGridView)dGV_DETL)[16, 0].Value = "";
				((DataGridView)dGV_DETL)[17, 0].Value = "";
				((DataGridView)dGV_DETL)[18, 0].Value = "";
				((DataGridView)dGV_DETL)[20, 0].Value = "";
				((DataGridView)dGV_DETL)[21, 0].Value = "";
				((DataGridView)dGV_DETL)[22, 0].Value = "";
				((DataGridView)dGV_DETL)[2, 0].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)"");
				((DataGridView)dGV_DETL)[1, 0].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)"");
				((DataGridView)dGV_DETL)[3, 0].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)"");
				((DataGridView)dGV_DETL)[4, 0].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)"");
				((DataGridView)dGV_DETL)[5, 0].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)"");
				((DataGridView)dGV_DETL)[6, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BAG_WT"])), "0.000");
				((DataGridView)dGV_DETL)[7, 0].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
				((DataGridView)dGV_DETL)[8, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
				((DataGridView)dGV_DETL)[9, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
				((DataGridView)dGV_DETL)[10, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
				((DataGridView)dGV_DETL)[11, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
				((DataGridView)dGV_DETL)[12, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
				((DataGridView)dGV_DETL)[13, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
				((DataGridView)dGV_DETL)[14, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
				((DataGridView)dGV_DETL)[15, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
				((DataGridView)dGV_DETL)[24, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
				((DataGridView)dGV_DETL)[23, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAG_COST"])), "0.00");
				((DataGridView)dGV_DETL)[18, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
				nLbrPrc.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
				((DataGridView)dGV_DETL)[20, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
				nLbrRate.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
				((DataGridView)dGV_DETL)[19, 0].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)"");
				((DataGridView)dGV_DETL)[21, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
				((DataGridView)dGV_DETL)[22, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
				((DataGridView)dGV_DETL)[29, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VCH_SRNO"])), "0");
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[24, 0].Value)) != 0.0)
				{
					((DataGridView)dGV_DETL)[25, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
					((DataGridView)dGV_DETL)[27, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
					((DataGridView)dGV_DETL)[29, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VCH_SRNO"])), "0");
				}
				else
				{
					((DataGridView)dGV_DETL)[16, 0].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GR_RATE"], (object)"")), "0.00");
					((DataGridView)dGV_DETL)[28, 0].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)"");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[16, 0].Value)) != 0.0)
					{
						if (Operators.ConditionalCompareObjectEqual(((DataGridView)dGV_DETL)[28, 0].Value, (object)"G", false))
						{
							((DataGridView)dGV_DETL)[16, 0].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[16, 0].Value)) / 10.0, 2), "0.00");
						}
						else if (Operators.ConditionalCompareObjectEqual(((DataGridView)dGV_DETL)[28, 0].Value, (object)"K", false))
						{
							((DataGridView)dGV_DETL)[16, 0].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[16, 0].Value)) / 10.0, 2), "0.00");
						}
						else if (Operators.ConditionalCompareObjectEqual(((DataGridView)dGV_DETL)[28, 0].Value, (object)"1", false))
						{
							((DataGridView)dGV_DETL)[16, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[16, 0].Value)), "0.00");
						}
						else
						{
							((DataGridView)dGV_DETL)[16, 0].Value = "";
						}
					}
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])) != 0.0) | (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])) != 0.0))
					{
						if (Conversion.Val(nLbrPrc.Text) != 0.0)
						{
							((DataGridView)dGV_DETL)[18, 0].Value = Strings.Format((object)Conversion.Val(nLbrPrc.Text), "0.00");
						}
						else
						{
							((DataGridView)dGV_DETL)[18, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
						}
						if (Conversion.Val(nLbrRate.Text) != 0.0)
						{
							((DataGridView)dGV_DETL)[20, 0].Value = Strings.Format((object)Conversion.Val(nLbrRate.Text), "0.00");
						}
						else
						{
							((DataGridView)dGV_DETL)[20, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
						}
					}
					else
					{
						((DataGridView)dGV_DETL)[18, 0].Value = "";
						((DataGridView)dGV_DETL)[20, 0].Value = "";
					}
					((DataGridView)dGV_DETL)[30, 0].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)"");
					BILL_TOTAL();
				}
				dGV_DETL = null;
				DGV_IDTL_CLEAR();
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), ((DataGridView)DGV_DETL)[1, 0].Value), (object)"' AND A.VCH_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[29, 0].Value))), (object)" "));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
				{
					DevComponents.DotNetBar.Controls.DataGridViewX dGV_IDTL = DGV_IDTL;
					((DataGridView)dGV_IDTL).Rows.Add();
					((DataGridView)dGV_IDTL)[0, DC_Main.i].Value = DC_Main.i + 1;
					((DataGridView)dGV_IDTL)[1, DC_Main.i].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
					((DataGridView)dGV_IDTL)[2, DC_Main.i].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
					((DataGridView)dGV_IDTL)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
					((DataGridView)dGV_IDTL)[4, DC_Main.i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					((DataGridView)dGV_IDTL)[13, DC_Main.i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
					((DataGridView)dGV_IDTL)[5, DC_Main.i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
					((DataGridView)dGV_IDTL)[6, DC_Main.i].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					((DataGridView)dGV_IDTL)[7, DC_Main.i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					((DataGridView)dGV_IDTL)[8, DC_Main.i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					((DataGridView)dGV_IDTL)[9, DC_Main.i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					((DataGridView)dGV_IDTL)[10, DC_Main.i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					((DataGridView)dGV_IDTL)[11, DC_Main.i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					((DataGridView)dGV_IDTL)[12, DC_Main.i].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					((DataGridView)dGV_IDTL)[14, DC_Main.i].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
					((DataGridView)dGV_IDTL)[15, DC_Main.i].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					DC_Main.i++;
					dGV_IDTL = null;
				}
				if (Conversions.ToBoolean(Operators.AndObject((object)(((DataGridView)DGV_DETL)[30, 0].Value != null), Operators.CompareObjectNotEqual(((DataGridView)DGV_DETL)[30, 0].Value, (object)"N", false))))
				{
					DC_Main.MsImageNo = Conversions.ToString(((DataGridView)DGV_DETL)[30, 0].Value);
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
					}
					else
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '"), ((DataGridView)DGV_DETL)[30, 0].Value), (object)"' AND IMAGE_TYPE = 'D'"));
						RsImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
						if (RsImg.Rows.Count > 0)
						{
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
							{
								PicImage.Image = null;
							}
							else
							{
								object obj = Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)"");
								byte[] bA = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj));
								object objectValue = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA));
								PicImage.Image = (Image)objectValue;
							}
						}
					}
				}
				else if (!ImgDisplay)
				{
					DC_Main.MsImageNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(((DataGridView)DGV_DETL)[1, 0].Value, (object)"_"), ((DataGridView)DGV_DETL)[29, 0].Value));
					DC_Main.MsImageType = "TagImage";
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
					}
					else
					{
						DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + ((DataGridView)DGV_DETL)[1, 0].Value.ToString() + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[29, 0].Value)))) ?? "";
						RsImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
						if (RsImg.Rows.Count > 0)
						{
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
							{
								PicImage.Image = null;
							}
							else
							{
								object obj2 = Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)"");
								byte[] bA2 = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj2));
								object objectValue2 = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA2));
								PicImage.Image = (Image)objectValue2;
							}
						}
						else
						{
							PicImage.Image = null;
						}
					}
				}
				tTagNo.Text = Conversions.ToString(((DataGridView)DGV_DETL)[1, 0].Value);
				nNetAmt.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[25, 0].Value)), "0.00");
				if (Conversion.Val(nNetAmt.Text) != 0.0)
				{
					nTaxAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
					{
						Operators.DivideObject(Operators.MultiplyObject((object)nNetAmt.Text, Interaction.IIf(Operators.CompareString(DC_Main.SSRegSrNo, "HM637NEHM", false) == 0, (object)13, (object)3)), (object)100),
						0
					}, (string[])null, (Type[])null, (bool[])null)), "0.00");
				}
				nTotAmt.Text = Strings.Format((object)(Conversion.Val(nNetAmt.Text) + Conversion.Val(nTaxAmt.Text)), "0.00");
				return;
			}
			((TextBoxBase)tTagNo).SelectionStart = Strings.Len(tTagNo.Text);
			DC_Main.RsQry = "Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_DATE From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_DATE HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_DATE DESC";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[10];
			DC_Main.ColWidth[0] = 120.0;
			DC_Main.ColWidth[1] = 300.0;
			DC_Main.ColWidth[2] = 100.0;
			DC_Main.ColWidth[3] = 120.0;
			DC_Main.ColWidth[4] = 100.0;
			DC_Main.ColWidth[5] = 100.0;
			DC_Main.ColWidth[6] = 110.0;
			DC_Main.ColWidth[7] = 0.0;
			DC_Main.ColWidth[8] = 0.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tTagNo.Text = DC_Main.ColValue[0];
					ScanVchSrNo = Conversions.ToDouble(DC_Main.ColValue[7]);
					((Control)tTagNo).Focus();
				}
				else
				{
					tTagNo.Text = "";
					ScanVchSrNo = 0.0;
					((Control)tTagNo).Focus();
				}
			}
		}
	}

	private void BILL_TOTAL()
	{
		DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL = DGV_DETL;
		if ((Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[16, 0].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[8, 0].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, 0].Value)) != 0.0))
		{
			object value = ((DataGridView)dGV_DETL)[28, 0].Value;
			if (Operators.ConditionalCompareObjectEqual(value, (object)"P", false))
			{
				((DataGridView)dGV_DETL)[17, 0].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, 0].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[16, 0].Value)), 0), "0.00");
			}
			else if (Operators.ConditionalCompareObjectEqual(value, (object)"1", false))
			{
				((DataGridView)dGV_DETL)[17, 0].Value = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
				{
					Operators.MultiplyObject(Interaction.IIf(Operators.CompareString(DC_Main.MsSlAmtType, "G", false) == 0, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[8, 0].Value)), (object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[10, 0].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, 0].Value)))), (object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[16, 0].Value)) / 10.0)),
					0
				}, (string[])null, (Type[])null, (bool[])null)), "0.00");
			}
			else if (Operators.ConditionalCompareObjectEqual(value, (object)"K", false))
			{
				((DataGridView)dGV_DETL)[17, 0].Value = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
				{
					Operators.MultiplyObject(Interaction.IIf(Operators.CompareString(DC_Main.MsSlAmtType, "G", false) == 0, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[8, 0].Value)), (object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[10, 0].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, 0].Value)))), (object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[16, 0].Value)) / 1000.0)),
					0
				}, (string[])null, (Type[])null, (bool[])null)), "0.00");
			}
			else
			{
				((DataGridView)dGV_DETL)[17, 0].Value = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
				{
					Operators.MultiplyObject(Interaction.IIf(Operators.CompareString(DC_Main.MsSlAmtType, "G", false) == 0, (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[8, 0].Value)), (object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[10, 0].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, 0].Value)))), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[16, 0].Value))),
					0
				}, (string[])null, (Type[])null, (bool[])null)), "0.00");
			}
		}
		if ((Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[18, 0].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[16, 0].Value)) != 0.0))
		{
			((DataGridView)dGV_DETL)[20, 0].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[16, 0].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[18, 0].Value)) / 100.0, 0), "0.00");
		}
		if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[20, 0].Value)) != 0.0)
		{
			object value2 = ((DataGridView)dGV_DETL)[19, 0].Value;
			if (Operators.ConditionalCompareObjectEqual(value2, (object)"P", false))
			{
				((DataGridView)dGV_DETL)[21, 0].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, 0].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[20, 0].Value)), 0), "0.00");
			}
			else if (Operators.ConditionalCompareObjectEqual(value2, (object)"N", false))
			{
				((DataGridView)dGV_DETL)[21, 0].Value = Strings.Format((object)Math.Round((Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[10, 0].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, 0].Value))) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[20, 0].Value)), 0), "0.00");
			}
			else if (Operators.ConditionalCompareObjectEqual(value2, (object)"K", false))
			{
				((DataGridView)dGV_DETL)[21, 0].Value = Strings.Format((object)Math.Round((Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[10, 0].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, 0].Value))) * (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[20, 0].Value)) / 1000.0), 0), "0.00");
			}
			else if (Operators.ConditionalCompareObjectEqual(value2, (object)"G", false))
			{
				((DataGridView)dGV_DETL)[21, 0].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[8, 0].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[20, 0].Value)), 0), "0.00");
			}
			else
			{
				((DataGridView)dGV_DETL)[21, 0].Value = Strings.Format((object)Math.Round((Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[10, 0].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, 0].Value))) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[20, 0].Value)), 0), "0.00");
			}
		}
		((DataGridView)dGV_DETL)[25, 0].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[17, 0].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[21, 0].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[22, 0].Value))), "0.00");
		((DataGridView)dGV_DETL)[27, 0].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[17, 0].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[21, 0].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[22, 0].Value))), "0.00");
		if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[26, 0].Value)) != 0.0)
		{
			((DataGridView)dGV_DETL)[27, 0].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[25, 0].Value)) / (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[26, 0].Value)) + 100.0) * 100.0, 0), "0.00");
			((DataGridView)dGV_DETL)[21, 0].Value = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[27, 0].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[17, 0].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[22, 0].Value)), 0), "0.00");
			if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[21, 0].Value)) != 0.0)
			{
				if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(((DataGridView)dGV_DETL)[19, 0].Value, (object)"P", false), (object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, 0].Value)) != 0.0))))
				{
					((DataGridView)dGV_DETL)[20, 0].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[21, 0].Value)) / Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, 0].Value))), "0.00");
				}
				else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(((DataGridView)dGV_DETL)[19, 0].Value, (object)"N", false), (object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[10, 0].Value)) != 0.0))))
				{
					((DataGridView)dGV_DETL)[20, 0].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[21, 0].Value)) / (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[10, 0].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, 0].Value)))), "0.00");
				}
				else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(((DataGridView)dGV_DETL)[19, 0].Value, (object)"K", false), (object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[8, 0].Value)) != 0.0))))
				{
					((DataGridView)dGV_DETL)[20, 0].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[21, 0].Value)) / Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[8, 0].Value)) * 1000.0), "0.00");
				}
				else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(((DataGridView)dGV_DETL)[19, 0].Value, (object)"G", false), (object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[8, 0].Value)) != 0.0))))
				{
					((DataGridView)dGV_DETL)[20, 0].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[21, 0].Value)) / Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[8, 0].Value))), "0.00");
				}
			}
		}
		else
		{
			((DataGridView)dGV_DETL)[27, 0].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[25, 0].Value)), "0.00");
		}
		nNetAmt.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[25, 0].Value)), "0.00");
		if (Conversion.Val(nNetAmt.Text) != 0.0)
		{
			nTaxAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
			{
				Operators.DivideObject(Operators.MultiplyObject((object)nNetAmt.Text, Interaction.IIf(Operators.CompareString(DC_Main.SSRegSrNo, "HM637NEHM", false) == 0, (object)13, (object)3)), (object)100),
				0
			}, (string[])null, (Type[])null, (bool[])null)), "0.00");
		}
		nTotAmt.Text = Strings.Format((object)(Conversion.Val(nNetAmt.Text) + Conversion.Val(nTaxAmt.Text)), "0.00");
		dGV_DETL = null;
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		string text = "output.xlsx";
		DGV.ExportToXlsx(text);
		Process.Start(text);
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
	}

	private void RP_TAG_ESTMATE_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0c10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c17: Expected O, but got Unknown
		//IL_0cd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce6: Expected O, but got Unknown
		//IL_0cf9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cfe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d08: Expected O, but got Unknown
		//IL_0c87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c96: Expected O, but got Unknown
		//IL_0d8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d95: Expected O, but got Unknown
		//IL_1049: Unknown result type (might be due to invalid IL or missing references)
		//IL_104e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1058: Expected O, but got Unknown
		//IL_0e47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e56: Expected O, but got Unknown
		//IL_0e75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e84: Expected O, but got Unknown
		//IL_0ea3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb2: Expected O, but got Unknown
		//IL_0f34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f43: Expected O, but got Unknown
		//IL_0f62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f71: Expected O, but got Unknown
		//IL_0f90: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f9f: Expected O, but got Unknown
		//IL_10ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_10cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d5: Expected O, but got Unknown
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
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL = DGV_DETL;
				object? obj10 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_DETL).BackgroundColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj11 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_IDTL = DGV_IDTL;
				object? obj12 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_IDTL).BackgroundColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV_IDTL).AlternatingRowsDefaultCellStyle;
				object? obj13 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				PictureBox picImage = PicImage;
				object? obj14 = colorConverter.ConvertFromString("243, 240, 239");
				((Control)picImage).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj15 = colorConverter.ConvertFromString("200, 205, 210");
				((XtraForm)this).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				ComboBox obj16 = cboItemTyp;
				object? obj17 = colorConverter.ConvertFromString("233, 235, 240");
				obj16.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				Panel panel2 = Panel1;
				object? obj18 = colorConverter.ConvertFromString("Control");
				((Control)panel2).BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL2 = DGV_DETL;
				object? obj19 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_DETL2).BackgroundColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj20 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_IDTL2 = DGV_IDTL;
				object? obj21 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_IDTL2).BackgroundColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle4 = ((DataGridView)DGV_IDTL).AlternatingRowsDefaultCellStyle;
				object? obj22 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle4.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				PictureBox picImage2 = PicImage;
				object? obj23 = colorConverter.ConvertFromString("233, 235, 240");
				((Control)picImage2).BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj24 = colorConverter.ConvertFromString("205, 220, 220");
				((XtraForm)this).BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj25 = lblBook;
				object? obj26 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj25).ForeColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj27 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				ComboBox obj28 = cboItemTyp;
				object? obj29 = colorConverter.ConvertFromString("238, 244, 236");
				obj28.BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				Panel panel3 = Panel1;
				object? obj30 = colorConverter.ConvertFromString("Control");
				((Control)panel3).BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL3 = DGV_DETL;
				object? obj31 = colorConverter.ConvertFromString("205, 220, 220");
				((DataGridView)dGV_DETL3).BackgroundColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle5 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj32 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle5.BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_IDTL3 = DGV_IDTL;
				object? obj33 = colorConverter.ConvertFromString("205, 220, 220");
				((DataGridView)dGV_IDTL3).BackgroundColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle6 = ((DataGridView)DGV_IDTL).AlternatingRowsDefaultCellStyle;
				object? obj34 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle6.BackColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
				PictureBox picImage3 = PicImage;
				object? obj35 = colorConverter.ConvertFromString("238, 244, 236");
				((Control)picImage3).BackColor = ((obj35 != null) ? ((Color)obj35) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)nLbrRate).Font.Size * (1.0 + num2));
				Font font = ((Control)nLbrRate).Font;
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
				num3 = (int)Math.Ceiling((double)((Control)tTagNo).Font.Size * (1.0 + num2));
				Font font2 = ((Control)tTagNo).Font;
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
					((DataGridView)DGV_IDTL).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_IDTL).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_IDTL).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_IDTL).Font.Style);
					((DataGridView)DGV_IDTL).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_IDTL).Font.Style);
					((DataGridView)DGV_IDTL).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_IDTL).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_IDTL).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_IDTL).RowTemplate.Height * (1.0 + num2));
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
			DGV_DETL_CLEAR();
			mFromDt.EditValue = DC_Main.MsSysDate;
			mToDt.EditValue = DC_Main.MsSysDate;
			CurActCtrl = (Control)(object)tTagNo;
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
		DGV_CLEAR();
		DGV_DETL_CLEAR();
		ImgDisplay = false;
		tTagNo.Text = "";
		((Control)tTagNo).Focus();
	}

	private void DGV_CLEAR()
	{
		DGV.DataSource = null;
		((CollectionBase)(object)((ColumnView)GridView1).Columns).Clear();
	}

	private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
					int columnIndex = e.ColumnIndex;
					if ((uint)(columnIndex - 4) <= 5u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
					{
						((ConvertEventArgs)e).Value = "";
						e.FormattingApplied = true;
					}
					break;
				}
				case 103:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_009d;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 103;
				continue;
			}
			break;
			IL_009d:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void tSerchAll_TextChanged(object sender, EventArgs e)
	{
		if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) == 0)
		{
			DGV_FILL();
		}
		else if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) != 0)
		{
			DGV_CLEAR();
			DataView dataView = new DataView(RsStkSum);
			dataView.RowFilter = "TagNo Like  '%" + ((TextEdit)tSerchAll).Text + "%' ";
			if (dataView.Count > 0)
			{
				DGV.DataSource = dataView;
			}
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RP_TAG_ESTMATE_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_TAG_ESTMATE_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_TAG_ESTMATE_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
		if (((int)e.KeyCode == 38) | ((int)e.KeyCode == 40))
		{
			((Control)DGV).Focus();
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void RP_TAG_ESTMATE_Activated(object sender, EventArgs e)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		Image image = default(Image);
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
				case 245:
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
							goto IL_0048;
						case 4:
							goto IL_006f;
						case 5:
							goto IL_007f;
						case 6:
							goto IL_0088;
						case 8:
							goto IL_0095;
						case 7:
						case 9:
						case 10:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 11:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_0048:
					num2 = 3;
					using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
					{
						image = Image.FromStream(stream);
					}
					goto IL_006f;
					IL_006f:
					num2 = 4;
					PicImage.Image = image;
					goto IL_007f;
					IL_0088:
					num2 = 6;
					Small_Image();
					break;
					IL_007f:
					num2 = 5;
					Mobile_image_Save();
					goto IL_0088;
					IL_000b:
					num2 = 2;
					if ((Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath ?? "", (FileAttribute)0), "", false) != 0) & (Operators.CompareString(DC_Main.MsImagePath, "", false) != 0))
					{
						goto IL_0048;
					}
					goto IL_0095;
					IL_0095:
					num2 = 8;
					PicImage.Image = null;
					break;
					end_IL_0001_2:
					break;
				}
				num2 = 10;
				CurActCtrl.Focus();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 245;
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

	private void Tag_Summ(string RptType)
	{
		tTagNo.Text = "";
		switch (RptType)
		{
		case "In":
			DC_Main.RsQry = "SELECT A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,A.TAG_NO As TagNo,A.IT_CODE As ItCode,A.TBL_CODE As Counter,A.DESIGN_NO As Design,A.ITM_SIZE As Size,A.ITM_PCS as Pcs,A.ITM_GWT As Grwt,A.ITM_NWT AS NetWt,A.LBR_AMT LbrAmt,A.OTH_AMT OthAmt,  A.ITM_MRP As Mrp,A.KR_NAME As KrName,A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.AC_CODE As AcCode,A.VCH_SRNO As TagId  from BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.TAG_NO <> '' AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "'  ";
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
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
			}
			DC_Main.RsQry += "ORDER BY A.TAG_NO";
			break;
		case "Out":
			DC_Main.RsQry = "SELECT A.VCH_TYPE As VchTyp,A.VCH_NO VchNo,A.VCH_DATE As VchDate,A.TAG_NO As TagNo,C.DESIGN_NO AS Design,A.IT_CODE As ItCode,A.TBL_CODE As Counter,C.ITM_SIZE As Size,A.ITM_PCS as Pcs,A.ITM_GWT As Grwt,A.ITM_NWT AS NetWt,A.LBR_AMT LbrAmt,A.OTH_AMT OthAmt,  A.ITM_MRP As Mrp,C.KR_NAME As KrName,A.CO_BOOK As Book,A.BOOK_NAME As BookName,A.AC_CODE As AcCode,A.VCH_SRNO As TagId  from (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.TAG_NO <> '' AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.EditValue), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "' AND A.ITM_SIGN = '-' ";
			if (Operators.CompareString(tTagNo.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TAG_NO =  '" + tTagNo.Text + "'";
			}
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
			DC_Main.RsQry += "ORDER BY A.TAG_NO";
			break;
		case "Stock":
			DC_Main.RsQry = "SELECT A.TAG_NO As TagNo,C.DESIGN_NO As Design,C.TBL_CODE As Counter,B.IT_NAME As ItmName,C.ITM_SIZE As Size,C.ITM_PCS as Pcs,C.ITM_GWT As Grwt,C.ITM_NWT AS NetWt,(D.GR_RATE) As Rate,C.LBR_PRC As LbrPrc,C.LBR_RATE As LRate,C.LBR_AMT LbrAmt,C.OTH_AMT OthAmt,C.ITM_MRP As Mrp,C.KR_NAME As Krgr,C.VCH_SRNO As TagId,C.CO_BOOK As Book,C.VCH_NO As VchNo  from ((MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE)LEFT JOIN GROUP_MAST AS D ON B.CO_CODE = D.CO_CODE AND B.GR_CODE = D.GR_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.TAG_NO <> '' AND C.STK_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "'";
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
			if (Operators.CompareString(RptType, "Mrp", false) == 0)
			{
				DC_Main.RsQry += "AND C.ITM_MRP <> 0";
			}
			DC_Main.RsQry += " GROUP BY A.TAG_NO,C.DESIGN_NO,C.TBL_CODE,B.IT_NAME,C.ITM_SIZE,C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,D.GR_RATE,C.LBR_PRC,C.LBR_RATE,C.LBR_AMT,C.OTH_AMT,C.ITM_MRP,C.KR_NAME,C.VCH_SRNO,C.CO_BOOK,C.VCH_NO ";
			DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO";
			break;
		}
		RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_FILL();
	}

	private void DGV_FILL()
	{
		//IL_0466: Unknown result type (might be due to invalid IL or missing references)
		//IL_0470: Expected O, but got Unknown
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b4: Expected O, but got Unknown
		//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Expected O, but got Unknown
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		int num5 = default(int);
		DataView dataView = default(DataView);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					num2 = 1;
					DGV_CLEAR();
					goto IL_000b;
				case 1533:
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
							goto IL_0014;
						case 4:
							goto IL_0022;
						case 5:
							goto IL_0033;
						case 6:
							goto IL_0042;
						case 7:
						case 8:
							goto IL_0052;
						case 9:
							goto IL_0066;
						case 10:
							goto IL_0076;
						case 11:
							goto IL_007f;
						case 12:
							goto IL_009e;
						case 13:
							goto IL_00bd;
						case 14:
							goto IL_00dd;
						case 15:
							goto IL_00fd;
						case 16:
							goto IL_011e;
						case 17:
							goto IL_0141;
						case 18:
							goto IL_0161;
						case 19:
							goto IL_0181;
						case 20:
							goto IL_01a1;
						case 21:
							goto IL_01c1;
						case 22:
							goto IL_01e2;
						case 23:
							goto IL_0202;
						case 24:
							goto IL_0223;
						case 25:
							goto IL_0243;
						case 26:
							goto IL_0264;
						case 27:
							goto IL_0284;
						case 28:
							goto IL_02a5;
						case 29:
							goto IL_02c5;
						case 30:
							goto IL_02e6;
						case 31:
							goto IL_0306;
						case 32:
							goto IL_0327;
						case 33:
							goto IL_0347;
						case 34:
							goto IL_0375;
						case 35:
							goto IL_03a3;
						case 36:
							goto IL_03d1;
						case 37:
						case 38:
							goto IL_0401;
						case 39:
							goto IL_0431;
						case 40:
							goto IL_044b;
						case 41:
							goto IL_0471;
						case 42:
							goto IL_048f;
						case 43:
							goto IL_04b5;
						case 44:
							goto IL_04db;
						case 45:
							goto IL_04ff;
						case 46:
						case 47:
							goto IL_0511;
						case 48:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 49:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_04db:
					num2 = 44;
					GridView1.RowHeight = checked((int)Math.Round(22.0 * DC_Main.ScreenHight));
					goto IL_04ff;
					IL_04ff:
					num2 = 45;
					GridView1.BestFitColumns(true);
					goto IL_0511;
					IL_04b5:
					num2 = 43;
					GridView1.Appearance.FooterPanel.Font = new Font("Segoe UI Semibold", (float)num5);
					goto IL_04db;
					IL_0511:
					num2 = 47;
					Application.DoEvents();
					break;
					IL_000b:
					num2 = 2;
					CurImgShow = false;
					goto IL_0014;
					IL_0014:
					num2 = 3;
					dataView = new DataView(RsStkSum);
					goto IL_0022;
					IL_0022:
					num2 = 4;
					if (dataView.Count > 0)
					{
						goto IL_0033;
					}
					goto IL_0052;
					IL_0033:
					num2 = 5;
					DGV.DataSource = dataView;
					goto IL_0042;
					IL_0042:
					num2 = 6;
					DGV.ForceInitialize();
					goto IL_0052;
					IL_0052:
					num2 = 8;
					GridView1.OptionsView.ColumnAutoWidth = false;
					goto IL_0066;
					IL_0066:
					num2 = 9;
					GridView1.HorzScrollVisibility = (ScrollVisibility)(-1);
					goto IL_0076;
					IL_0076:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_007f;
					IL_007f:
					num2 = 11;
					if (RsStkSum.Rows.Count > 0)
					{
						goto IL_009e;
					}
					goto IL_0401;
					IL_009e:
					num2 = 12;
					((ColumnView)GridView1).Columns["TagId"].Visible = false;
					goto IL_00bd;
					IL_00bd:
					num2 = 13;
					((ColumnView)GridView1).Columns["TagNo"].Width = 70;
					goto IL_00dd;
					IL_00dd:
					num2 = 14;
					((ColumnView)GridView1).Columns["Design"].Width = 70;
					goto IL_00fd;
					IL_00fd:
					num2 = 15;
					if (((ColumnView)GridView1).Columns["ItmName"] != null)
					{
						goto IL_011e;
					}
					goto IL_0141;
					IL_011e:
					num2 = 16;
					((ColumnView)GridView1).Columns["ItmName"].Width = 130;
					goto IL_0141;
					IL_0141:
					num2 = 17;
					((ColumnView)GridView1).Columns["Size"].Width = 50;
					goto IL_0161;
					IL_0161:
					num2 = 18;
					((ColumnView)GridView1).Columns["Pcs"].Width = 45;
					goto IL_0181;
					IL_0181:
					num2 = 19;
					((ColumnView)GridView1).Columns["Grwt"].Width = 60;
					goto IL_01a1;
					IL_01a1:
					num2 = 20;
					((ColumnView)GridView1).Columns["NetWt"].Width = 60;
					goto IL_01c1;
					IL_01c1:
					num2 = 21;
					if (((ColumnView)GridView1).Columns["Rate"] != null)
					{
						goto IL_01e2;
					}
					goto IL_0202;
					IL_01e2:
					num2 = 22;
					((ColumnView)GridView1).Columns["Rate"].Width = 60;
					goto IL_0202;
					IL_0202:
					num2 = 23;
					if (((ColumnView)GridView1).Columns["LbrPrc"] != null)
					{
						goto IL_0223;
					}
					goto IL_0243;
					IL_0223:
					num2 = 24;
					((ColumnView)GridView1).Columns["LbrPrc"].Width = 45;
					goto IL_0243;
					IL_0243:
					num2 = 25;
					if (((ColumnView)GridView1).Columns["LRate"] != null)
					{
						goto IL_0264;
					}
					goto IL_0284;
					IL_0264:
					num2 = 26;
					((ColumnView)GridView1).Columns["LRate"].Width = 50;
					goto IL_0284;
					IL_0284:
					num2 = 27;
					if (((ColumnView)GridView1).Columns["LbrAmt"] != null)
					{
						goto IL_02a5;
					}
					goto IL_02c5;
					IL_02a5:
					num2 = 28;
					((ColumnView)GridView1).Columns["LbrAmt"].Width = 60;
					goto IL_02c5;
					IL_02c5:
					num2 = 29;
					if (((ColumnView)GridView1).Columns["OthAmt"] != null)
					{
						goto IL_02e6;
					}
					goto IL_0306;
					IL_02e6:
					num2 = 30;
					((ColumnView)GridView1).Columns["OthAmt"].Width = 60;
					goto IL_0306;
					IL_0306:
					num2 = 31;
					if (((ColumnView)GridView1).Columns["Mrp"] != null)
					{
						goto IL_0327;
					}
					goto IL_0347;
					IL_0327:
					num2 = 32;
					((ColumnView)GridView1).Columns["Mrp"].Width = 75;
					goto IL_0347;
					IL_0347:
					num2 = 33;
					((ColumnView)GridView1).Columns["Pcs"].Summary.Add((SummaryItemType)0, "Pcs", "{0}");
					goto IL_0375;
					IL_0375:
					num2 = 34;
					((ColumnView)GridView1).Columns["Grwt"].Summary.Add((SummaryItemType)0, "Grwt", "{0}");
					goto IL_03a3;
					IL_03a3:
					num2 = 35;
					((ColumnView)GridView1).Columns["NetWt"].Summary.Add((SummaryItemType)0, "NetWt", "{0}");
					goto IL_03d1;
					IL_03d1:
					num2 = 36;
					((ColumnView)GridView1).Columns["Mrp"].Summary.Add((SummaryItemType)0, "Mrp", "{0}");
					goto IL_0401;
					IL_0401:
					num2 = 38;
					if ((Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0) & (DC_Main.ScreenHight > 1.0))
					{
						goto IL_0431;
					}
					goto IL_0511;
					IL_0431:
					num2 = 39;
					num5 = checked((int)Math.Ceiling(9.0 * DC_Main.ScreenHight));
					goto IL_044b;
					IL_044b:
					num2 = 40;
					GridView1.Appearance.HeaderPanel.Font = new Font("Segoe UI Semibold", (float)num5);
					goto IL_0471;
					IL_0471:
					num2 = 41;
					GridView1.Appearance.HeaderPanel.ForeColor = Color.Maroon;
					goto IL_048f;
					IL_048f:
					num2 = 42;
					GridView1.Appearance.Row.Font = new Font("Segoe UI Semibold", (float)num5);
					goto IL_04b5;
					end_IL_0001_2:
					break;
				}
				num2 = 48;
				CurImgShow = true;
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1533;
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

	private void RP_TAG_ESTMATE_Closed(object sender, EventArgs e)
	{
		DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT ");
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
		}
		else
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;
		}
	}

	private void BtnStock_Click(object sender, EventArgs e)
	{
		Tag_Summ("Stock");
	}

	private void BtnIn_Click(object sender, EventArgs e)
	{
		Tag_Summ("In");
	}

	private void BtnOut_Click(object sender, EventArgs e)
	{
		Tag_Summ("Out");
	}

	private void Stk_Insert()
	{
		DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		GridView gridView = GridView1;
		((BaseView)gridView).PostEditor();
		((ColumnView)gridView).UpdateCurrentRow();
		checked
		{
			int num = gridView.RowCount - 1;
			DC_Main.X = 0;
			while (DC_Main.X <= num)
			{
				DataRow dataRow = ((ColumnView)gridView).GetDataRow(DC_Main.X);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_STOCK_PRINT(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,BOOK_NAME,  IT_CODE,TAG_NO,VCH_SRNO,ITM_SIGN,DESIGN_NO,ITM_SIZE,TBL_CODE,ITM_QTY,ITM_PCS,ITM_GWT,ITM_NWT,ITM_FINE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,BOOK_NAME,  IT_CODE,TAG_NO,VCH_SRNO,'+',DESIGN_NO,ITM_SIZE,TBL_CODE,1,ITM_PCS,ITM_GWT,ITM_NWT,ITM_FINE,'A'  FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'   AND TAG_NO ='"), dataRow[0]), (object)"' AND VCH_SRNO = "), dataRow[12]), (object)" "));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.X++;
			}
			gridView = null;
			DC_Main.RsQry = "SELECT * FROM TAG_STOCK_PRINT";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		Stk_Insert();
		string text = "Tag Wise Stock As on Date ";
		string text2 = "TagStkRpt";
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'" + text + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			DC_Main.RptName = "TagStkRpt";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = "{TAG_STOCK_PRINT.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAG_STOCK_PRINT.LC_CODE} = '" + DC_Main.MLc_code + "' AND {TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TagStkRpt.RPT";
			Cr.SelectionFormula = "{TAG_STOCK_PRINT.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAG_STOCK_PRINT.LC_CODE} = '" + DC_Main.MLc_code + "' AND {TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
			Cr[(short)0] = "RptTitel = '" + text + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
			Cr.Action = -1;
		}
	}

	private void BtnSumm_Click(object sender, EventArgs e)
	{
		Stk_Insert();
		string text = "Tag Wise Stock Summary As on Date ";
		string text2 = "TagStkRpt";
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'" + text + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			DC_Main.RptName = "TagStkSummRpt";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = "{TAG_STOCK_PRINT.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAG_STOCK_PRINT.LC_CODE} = '" + DC_Main.MLc_code + "' AND {TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
			Module_Save.ShowReportPreview();
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TagStkSummRpt.RPT";
			Cr.SelectionFormula = "{TAG_STOCK_PRINT.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAG_STOCK_PRINT.LC_CODE} = '" + DC_Main.MLc_code + "' AND {TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "MM/dd/yyyy") + "# ";
			Cr[(short)0] = "RptTitel = '" + text + Strings.Format((object)Conversions.ToDate(mToDt.EditValue), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
			Cr.Action = -1;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void GridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
	{
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Expected O, but got Unknown
		if (!CurImgShow || ((ColumnView)GridView1).GetFocusedDataSourceRowIndex() < 0)
		{
			return;
		}
		PicImage.Image = null;
		DC_Main.MsImageNo = ((ColumnView)GridView1).GetFocusedRowCellValue("TagNo").ToString() + "_" + ((ColumnView)GridView1).GetFocusedRowCellValue("TagId").ToString();
		DC_Main.MsImageType = "TagImage";
		DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
		if (Operators.CompareString(DC_Main.MsHttpPath, "", false) != 0)
		{
			try
			{
				string address = ((Operators.CompareString(DC_Main.MsAppSchem, "Y", false) != 0) ? (DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg") : (DC_Main.MsHttpPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg"));
				PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + ((ColumnView)GridView1).GetFocusedRowCellValue("TagNo").ToString() + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(((ColumnView)GridView1).GetFocusedRowCellValue("TagId").ToString()))) ?? "";
				RsImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
				if (RsImg.Rows.Count > 0)
				{
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
					{
						PicImage.Image = null;
					}
					else
					{
						object obj = Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)"");
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
			}
		}
		else
		{
			DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + ((ColumnView)GridView1).GetFocusedRowCellValue("TagNo").ToString() + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(((ColumnView)GridView1).GetFocusedRowCellValue("TagId").ToString()))) ?? "";
			RsImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
			if (RsImg.Rows.Count > 0)
			{
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
				{
					PicImage.Image = null;
				}
				else
				{
					object obj2 = Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)"");
					byte[] bA2 = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj2));
					object objectValue2 = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA2));
					PicImage.Image = (Image)objectValue2;
				}
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
		ImgDisplay = true;
		Tag_Value();
	}

	private void nLbrRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nLbrRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nLbrRate.Text)), "0.00");
			((DataGridView)DGV_DETL)[20, 0].Value = Strings.Format((object)Convert.ToDouble(Conversion.Val(nLbrRate.Text)), "0.00");
			BILL_TOTAL();
		}
	}

	private void nLbrPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nLbrPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nLbrPrc.Text)), "0.00");
			((DataGridView)DGV_DETL)[18, 0].Value = Strings.Format((object)Convert.ToDouble(Conversion.Val(nLbrPrc.Text)), "0.00");
			nLbrRate.Text = "";
			BILL_TOTAL();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgCapture_Click(object sender, EventArgs e)
	{
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
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
					DC_Main.MsImageNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(((DataGridView)DGV_DETL)[1, 0].Value, (object)"_"), ((DataGridView)DGV_DETL)[29, 0].Value));
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
						FileSystem.Kill(DC_Main.MsImagePath);
					}
					((Form)MyProject.Forms.UT_WEB_CAM).MdiParent = ((Form)this).MdiParent;
					((Control)MyProject.Forms.UT_WEB_CAM).Show();
					((Control)MyProject.Forms.UT_WEB_CAM).Focus();
					goto end_IL_0001;
				case 310:
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
				try0001_dispatch = 310;
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
	private void Mobile_image_Save()
	{
		DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL = DGV_DETL;
		DC_Main.MsImageNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(((DataGridView)dGV_DETL)[1, 0].Value, (object)"_"), ((DataGridView)dGV_DETL)[29, 0].Value));
		DC_Main.MsImageType = "TagImage";
		DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
		if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
		{
			PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
			if (Operators.CompareString(DC_Main.MsUrlPath, "", false) != 0)
			{
				if (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0)
				{
					string ftpuri = DC_Main.MsUrlPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg";
					Ac_Image.FtpUploadFile(DC_Main.MsImagePath, ftpuri, DC_Main.MsUrlId, DC_Main.MsUrlPwd);
				}
				else
				{
					string ftpuri2 = DC_Main.MsUrlPath + DC_Main.MsImageNo + ".jpg";
					Ac_Image.FtpUploadFile(DC_Main.MsImagePath, ftpuri2, DC_Main.MsUrlId, DC_Main.MsUrlPwd);
				}
			}
			MemoryStream memoryStream = new MemoryStream();
			PicImage.Image.Save((Stream)memoryStream, PicImage.Image.RawFormat);
			byte[] buffer = memoryStream.GetBuffer();
			string value = Convert.ToBase64String(buffer);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '"), ((DataGridView)dGV_DETL)[1, 0].Value), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[29, 0].Value))), (object)""));
			DC_Main.ExeQuteImg(DC_Main.RsQry);
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '"), ((DataGridView)dGV_DETL)[1, 0].Value), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[29, 0].Value))), (object)""));
			RsImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow = RsImg.NewRow();
			dataRow["CO_CODE"] = DC_Main.MCo_code;
			dataRow["LC_CODE"] = DC_Main.MLc_code;
			dataRow["TAG_NO"] = RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[1, 0].Value);
			dataRow["VCH_SRNO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[29, 0].Value));
			dataRow["IMAGE_TYPE"] = "T";
			dataRow["MOB_IMAGE"] = value;
			RsImg.Rows.Add(dataRow);
			((DbDataAdapter)(object)DC_Main.Da).Update(RsImg);
			RsImg.Clear();
		}
		dGV_DETL = null;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void PicImage_DoubleClick(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK165NEVK", false) == 0)
		{
			DC_Main.MsImageNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(((DataGridView)DGV_DETL)[1, 0].Value, (object)"_"), ((DataGridView)DGV_DETL)[29, 0].Value));
			DC_Main.MsImageType = "TagImage";
			DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
			if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
			{
				Process.Start(DC_Main.MsImagePath);
				return;
			}
			PicZoom.Image = PicImage.Image;
			((Control)PicZoom).Left = ((Control)this).Left;
			((Control)PicZoom).Top = ((Control)this).Top;
			((Control)PicZoom).Width = ((Control)this).Width;
			((Control)PicZoom).Height = ((Control)this).Height;
			((Control)PicZoom).BringToFront();
			((Control)PicZoom).Visible = true;
		}
		else
		{
			PicZoom.Image = PicImage.Image;
			((Control)PicZoom).Left = ((Control)this).Left;
			((Control)PicZoom).Top = ((Control)this).Top;
			((Control)PicZoom).Width = ((Control)this).Width;
			((Control)PicZoom).Height = ((Control)this).Height;
			((Control)PicZoom).BringToFront();
			((Control)PicZoom).Visible = true;
		}
	}

	private void PicZoom_DoubleClick(object sender, EventArgs e)
	{
		if (((Control)PicZoom).Visible)
		{
			PicZoom.Image = null;
			((Control)PicZoom).Dock = (DockStyle)0;
			((Control)PicZoom).Visible = false;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgDel_Click(object sender, EventArgs e)
	{
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Invalid comparison between Unknown and I4
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
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
					DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL = DGV_DETL;
					DC_Main.MsImageNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(((DataGridView)dGV_DETL)[1, 0].Value, (object)"_"), ((DataGridView)dGV_DETL)[29, 0].Value));
					DC_Main.MsImageType = "TagImage";
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Image now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '"), ((DataGridView)dGV_DETL)[1, 0].Value), (object)"' AND VCH_SRNO = "), ((DataGridView)dGV_DETL)[29, 0].Value), (object)""));
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
							FileSystem.Kill(DC_Main.MsImagePath);
						}
						if (Operators.CompareString(DC_Main.MsUrlPath, "", false) != 0)
						{
							DC_Main.MsImageNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(((DataGridView)dGV_DETL)[1, 0].Value, (object)"_"), ((DataGridView)dGV_DETL)[29, 0].Value));
							string ftpuri = DC_Main.MsUrlPath + DC_Main.MsImageNo + ".jpg";
							Ac_Image.FtpDeleteFile(ftpuri, DC_Main.MsUrlId, DC_Main.MsUrlPwd);
						}
						PicImage.Image = null;
					}
					dGV_DETL = null;
					goto end_IL_0001;
				}
				case 649:
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
				try0001_dispatch = 649;
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
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
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
					tGrName.Text = DC_Main.ColValue[0];
				}
				((TextBoxBase)tGrCode).SelectAll();
			}
		}
		else
		{
			tGrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GR_NAME"], (object)""));
		}
	}

	private void DGV_Click(object sender, EventArgs e)
	{
	}

	private void BtnSLImageDelete_Click(object sender, EventArgs e)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Invalid comparison between Unknown and I4
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
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
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_000b;
					case 624:
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
								goto IL_0027;
							case 4:
								goto IL_0071;
							case 5:
								goto IL_0092;
							case 6:
							case 7:
								goto IL_00ba;
							case 8:
								goto IL_00db;
							case 9:
							case 10:
								goto IL_0103;
							case 11:
								goto IL_011a;
							case 12:
								goto IL_012c;
							case 15:
								goto IL_013a;
							case 16:
								goto IL_01b5;
							case 17:
								goto IL_01c3;
							case 13:
							case 14:
							case 18:
								goto IL_01d3;
							case 19:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 20:
							case 21:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_013a:
						num2 = 15;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO = '"), DC_Main.Tbl.Rows[DC_Main.X]["TagNo"]), (object)"' AND VCH_SRNO = "), DC_Main.Tbl.Rows[DC_Main.X]["TagId"]), (object)""));
						goto IL_01b5;
						IL_01b5:
						num2 = 16;
						DC_Main.ExeQuteImg(DC_Main.RsQry);
						goto IL_01c3;
						IL_01d3:
						num2 = 14;
						if (DC_Main.X >= DC_Main.Tbl.Rows.Count)
						{
							break;
						}
						goto IL_013a;
						IL_01c3:
						num2 = 17;
						DC_Main.X++;
						goto IL_01d3;
						IL_000b:
						num2 = 2;
						if (unchecked((int)Interaction.MsgBox((object)"Are You Sure To Delete Sales Tag Image From Database...?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) != 6)
						{
							goto end_IL_0001_3;
						}
						goto IL_0027;
						IL_0027:
						num2 = 3;
						DC_Main.RsQry = "SELECT A.TAG_NO As TagNo,A.VCH_SRNO As TagId from MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' and A.TAG_NO <> 'N' AND A.ITM_SIGN = '-' ";
						goto IL_0071;
						IL_0071:
						num2 = 4;
						if (Operators.CompareString(tPrCode.Text, "", false) != 0)
						{
							goto IL_0092;
						}
						goto IL_00ba;
						IL_0092:
						num2 = 5;
						DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + tPrCode.Text + "'";
						goto IL_00ba;
						IL_00ba:
						num2 = 7;
						if (Operators.CompareString(tGrCode.Text, "", false) != 0)
						{
							goto IL_00db;
						}
						goto IL_0103;
						IL_00db:
						num2 = 8;
						DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + tGrCode.Text + "'";
						goto IL_0103;
						IL_0103:
						num2 = 10;
						DC_Main.RsQry += "ORDER BY A.TAG_NO";
						goto IL_011a;
						IL_011a:
						num2 = 11;
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_012c;
						IL_012c:
						num2 = 12;
						DC_Main.X = 0;
						goto IL_01d3;
						end_IL_0001_2:
						break;
					}
					num2 = 19;
					Interaction.MsgBox((object)"Image Is Deleted...", (MsgBoxStyle)0, (object)null);
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 624;
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

	private ImageCodecInfo GetEncoderInfo(string mimeType)
	{
		ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
		int num = imageEncoders.Length;
		for (int i = 0; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(imageEncoders[i].MimeType, mimeType, false) == 0)
			{
				return imageEncoders[i];
			}
		}
		return null;
	}

	private void SaveJPGWithCompressionSetting(Image image, string szFileName, long lCompression)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		EncoderParameters val = default(EncoderParameters);
		ImageCodecInfo encoderInfo = default(ImageCodecInfo);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				int num4;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = 2;
					goto IL_000a;
				case 225:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 2:
							break;
						case 1:
							goto IL_00ad;
						default:
							goto end_IL_0001;
						}
						goto IL_0047;
					}
					IL_0013:
					num2 = 3;
					val.Param[0] = new EncoderParameter(Encoder.Quality, lCompression);
					goto IL_0028;
					IL_0028:
					num2 = 4;
					encoderInfo = GetEncoderInfo("image/jpeg");
					goto IL_0037;
					IL_000a:
					num2 = 2;
					val = new EncoderParameters(1);
					goto IL_0013;
					IL_0047:
					num2 = 7;
					Interaction.MsgBox((object)("Error: " + Conversions.ToString(Information.Err().Number) + " " + Information.Err().Description + "\r\nChoose a different name for file."), (MsgBoxStyle)0, (object)null);
					goto IL_0093;
					IL_0093:
					num2 = 8;
					ProjectData.ClearProjectError();
					if (num == 0)
					{
						throw ProjectData.CreateProjectError(-2146828268);
					}
					goto IL_00ad;
					IL_0037:
					num2 = 5;
					image.Save(szFileName, encoderInfo, val);
					goto end_IL_0001_2;
					IL_00ad:
					num4 = num + 1;
					num = 0;
					switch (num4)
					{
					case 1:
						break;
					case 2:
						goto IL_000a;
					case 3:
						goto IL_0013;
					case 4:
						goto IL_0028;
					case 5:
						goto IL_0037;
					case 7:
						goto IL_0047;
					case 8:
						goto IL_0093;
					default:
						goto end_IL_0001;
					case 6:
					case 9:
						goto end_IL_0001_2;
					}
					goto default;
					end_IL_0001:
					break;
				}
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 225;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0001_2:
			break;
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnSvrImgConvert_Click(object sender, EventArgs e)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		string text = default(string);
		MemoryStream memoryStream = default(MemoryStream);
		byte[] buffer = default(byte[]);
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
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_000b;
					case 873:
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
								goto IL_0018;
							case 4:
								goto IL_0034;
							case 5:
								goto IL_0040;
							case 6:
								goto IL_007a;
							case 7:
								goto IL_008b;
							case 10:
								goto IL_0098;
							case 11:
								goto IL_00f0;
							case 12:
								goto IL_0111;
							case 13:
								goto IL_0136;
							case 14:
								goto IL_014f;
							case 15:
								goto IL_0159;
							case 16:
								goto IL_017f;
							case 17:
								goto IL_018b;
							case 18:
								goto IL_0197;
							case 19:
								goto IL_01a0;
							case 20:
								goto IL_025b;
							case 21:
								goto IL_0269;
							case 22:
							case 23:
								goto IL_0276;
							case 8:
							case 9:
							case 24:
								goto IL_0286;
							case 25:
								goto IL_02a8;
							case 26:
								goto IL_02b8;
							case 27:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 28:
							case 29:
							case 30:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_025b:
						num2 = 20;
						DC_Main.ExeQuteImg(DC_Main.RsQry);
						goto IL_0269;
						IL_0269:
						num2 = 21;
						Thread.Sleep(100);
						goto IL_0276;
						IL_01a0:
						num2 = 19;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE TAG_IMAGE_DATA SET MOB_IMAGE = '" + text + "',CONV_IMAGE = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"]), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"], (object)""))), (object)""));
						goto IL_025b;
						IL_0276:
						num2 = 23;
						DC_Main.i++;
						goto IL_0286;
						IL_000b:
						num2 = 2;
						DC_Main.ExeQuteImg("UPDATE TAG_IMAGE_DATA SET CONV_IMAGE = 'N' WHERE CONV_IMAGE IS NULL ");
						goto IL_0018;
						IL_0018:
						num2 = 3;
						if (unchecked((int)Interaction.MsgBox((object)"Are You Sure To Convert Server Image To Small Size?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) != 6)
						{
							goto end_IL_0001_3;
						}
						goto IL_0034;
						IL_0034:
						num2 = 4;
						DC_Main.MsImageType = "TagImage";
						goto IL_0040;
						IL_0040:
						num2 = 5;
						DC_Main.RsQry = "SELECT A.TAG_NO,A.VCH_SRNO FROM TAG_IMAGE_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CONV_IMAGE = 'N' ";
						goto IL_007a;
						IL_007a:
						num2 = 6;
						DC_Main.Rshlp = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
						goto IL_008b;
						IL_008b:
						num2 = 7;
						DC_Main.i = 0;
						goto IL_0286;
						IL_0286:
						num2 = 9;
						if (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							goto IL_0098;
						}
						goto IL_02a8;
						IL_02a8:
						num2 = 25;
						Interaction.MsgBox((object)"Image Convert Process is Complite...", (MsgBoxStyle)0, (object)null);
						goto IL_02b8;
						IL_02b8:
						num2 = 26;
						PicImage.Image = null;
						break;
						IL_0098:
						num2 = 10;
						DC_Main.MsImageNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"], (object)"_"), DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"]));
						goto IL_00f0;
						IL_00f0:
						num2 = 11;
						DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\SmallImage\\" + DC_Main.MsImageNo + ".jpg";
						goto IL_0111;
						IL_0111:
						num2 = 12;
						if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
						{
							goto IL_0136;
						}
						goto IL_0276;
						IL_0136:
						num2 = 13;
						PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
						goto IL_014f;
						IL_014f:
						num2 = 14;
						memoryStream = new MemoryStream();
						goto IL_0159;
						IL_0159:
						num2 = 15;
						PicImage.Image.Save((Stream)memoryStream, PicImage.Image.RawFormat);
						goto IL_017f;
						IL_017f:
						num2 = 16;
						buffer = memoryStream.GetBuffer();
						goto IL_018b;
						IL_018b:
						num2 = 17;
						text = Convert.ToBase64String(buffer);
						goto IL_0197;
						IL_0197:
						num2 = 18;
						Application.DoEvents();
						goto IL_01a0;
						end_IL_0001_2:
						break;
					}
					num2 = 27;
					PicSmall.Image = null;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 873;
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

	private void PnlBotam_DoubleClick(object sender, EventArgs e)
	{
		((Control)BtnSLImageDelete).Enabled = true;
		((Control)BtnOldSoftImagImport).Visible = true;
		((Control)btnImgUpload).Visible = true;
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnOldSoftImagImport_Click(object sender, EventArgs e)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Invalid comparison between Unknown and I4
		//IL_08b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		//IL_05c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cf: Expected O, but got Unknown
		if (((ColumnView)GridView1).GetFocusedDataSourceRowIndex() < 0)
		{
			Interaction.MsgBox((object)"No Data Found In Data Grid Pleas Select Data First And Try", (MsgBoxStyle)0, (object)null);
			return;
		}
		string text = "";
		if (Operators.CompareString(text, "", false) == 0)
		{
			FolderBrowserDialog val = new FolderBrowserDialog();
			if ((int)((CommonDialog)val).ShowDialog() == 1)
			{
				text = val.SelectedPath;
				Interaction.SaveSetting("DATACARE APP", "BACKUP_DATABASE", "BACKUP_PATH", text);
			}
		}
		checked
		{
			if (Operators.CompareString(text, "", false) != 0)
			{
				int num = ((BaseView)GridView1).DataRowCount - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					DC_Main.MsImageNo = GridView1.GetRowCellValue(DC_Main.M, "TagNo").ToString() + "_" + GridView1.GetRowCellValue(DC_Main.M, "TagId").ToString();
					string text2 = GridView1.GetRowCellValue(DC_Main.M, "TagNo").ToString();
					string text3 = text + "\\" + text2 + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(text3, (FileAttribute)0), "", false) != 0)
					{
						DC_Main.MsImageType = "TagImage";
						DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
						if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) == 0)
						{
							PicImage.Image = Image.FromFile(text3);
							Application.DoEvents();
							Thread.Sleep(100);
							if (Operators.CompareString(FileSystem.Dir(Application.StartupPath + "\\temp.jpg", (FileAttribute)0), "", false) != 0)
							{
								FileSystem.Kill(Application.StartupPath + "\\temp.jpg");
							}
							float num2 = float.Parse(Conversions.ToString(1));
							Bitmap val2 = new Bitmap(PicImage.Image);
							int width = ((Image)val2).Width;
							num2 = ((width > 5000) ? float.Parse(Conversions.ToString(0.5)) : ((width > 4500) ? float.Parse(Conversions.ToString(0.6)) : ((width > 4000) ? float.Parse(Conversions.ToString(0.7)) : ((width > 3500) ? float.Parse(Conversions.ToString(0.8)) : ((width > 3000) ? float.Parse(Conversions.ToString(0.75)) : ((width > 2500) ? float.Parse(Conversions.ToString(0.8)) : ((width <= 2000) ? float.Parse(Conversions.ToString(1)) : float.Parse(Conversions.ToString(0.9)))))))));
							Bitmap val3 = new Bitmap((int)Math.Round((float)((Image)val2).Width * num2), (int)Math.Round((float)((Image)val2).Height * num2));
							Graphics val4 = Graphics.FromImage((Image)(object)val3);
							val4.SmoothingMode = (SmoothingMode)2;
							val4.InterpolationMode = (InterpolationMode)7;
							val4.PixelOffsetMode = (PixelOffsetMode)2;
							val4.DrawImage((Image)(object)val2, 0, 0, ((Image)val3).Width + 1, ((Image)val3).Height + 1);
							PicImage.Image = (Image)(object)val3;
							PicImage.Image.Save(Application.StartupPath + "\\temp.jpg");
							long num3 = FileSystem.FileLen(Application.StartupPath + "\\temp.jpg");
							string text4;
							if (num3 < 1000)
							{
								text4 = " Bytes";
							}
							else if (num3 > 1000000)
							{
								num3 = (long)Conversion.Int((double)num3 / 1000000.0);
								text4 = " Mb";
							}
							else
							{
								num3 = (long)Conversion.Int((double)num3 / 1000.0);
								text4 = " Kb";
							}
							string text5 = Conversions.ToString(num3) + text4;
							int num4 = 100;
							if (Operators.CompareString(text4, " Kb", false) != 0)
							{
								double num5 = Conversion.Val((object)num3);
								num4 = ((num5 > 30.0) ? 20 : ((num5 > 25.0) ? 30 : ((num5 > 20.0) ? 35 : ((num5 > 15.0) ? 40 : ((num5 > 10.0) ? 50 : ((num5 > 7.0) ? 55 : ((num5 > 5.0) ? 70 : ((num5 > 3.0) ? 75 : ((num5 > 2.0) ? 80 : ((!(num5 > 1.0)) ? 90 : 85))))))))));
							}
							Bitmap val5 = (Bitmap)Image.FromFile(Application.StartupPath + "\\temp.jpg");
							SaveJPGWithCompressionSetting(PicImage.Image, DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg", num4);
							((Image)val5).Dispose();
							PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
							MemoryStream memoryStream = new MemoryStream();
							PicImage.Image.Save((Stream)memoryStream, PicImage.Image.RawFormat);
							byte[] buffer = memoryStream.GetBuffer();
							string value = Convert.ToBase64String(buffer);
							DC_Main.RsQry = ("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + GridView1.GetRowCellValue(DC_Main.M, "TagNo").ToString() + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(GridView1.GetRowCellValue(DC_Main.M, "TagId").ToString()))) ?? "";
							DC_Main.ExeQuteImg(DC_Main.RsQry);
							DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + GridView1.GetRowCellValue(DC_Main.M, "TagNo").ToString() + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(GridView1.GetRowCellValue(DC_Main.M, "TagId").ToString()))) ?? "";
							RsImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
							DC_Main.MsInsertData();
							DataRow dataRow = RsImg.NewRow();
							dataRow["CO_CODE"] = DC_Main.MCo_code;
							dataRow["LC_CODE"] = DC_Main.MLc_code;
							dataRow["TAG_NO"] = GridView1.GetRowCellValue(DC_Main.M, "TagNo").ToString();
							dataRow["VCH_SRNO"] = Conversion.Val(GridView1.GetRowCellValue(DC_Main.M, "TagId").ToString());
							dataRow["IMAGE_TYPE"] = "T";
							dataRow["MOB_IMAGE"] = value;
							RsImg.Rows.Add(dataRow);
							((DbDataAdapter)(object)DC_Main.Da).Update(RsImg);
							RsImg.Clear();
							Application.DoEvents();
						}
					}
					DC_Main.M++;
				}
			}
			Interaction.MsgBox((object)"Image Import Process is Complite...", (MsgBoxStyle)0, (object)null);
			PicImage.Image = null;
		}
	}

	private void tTagNo_LostFocus(object sender, EventArgs e)
	{
		((TextBoxBase)tTagNo).SelectionStart = Strings.Len(tTagNo.Text);
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgUpload_Click(object sender, EventArgs e)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Invalid comparison between Unknown and I4
		//IL_0454: Unknown result type (might be due to invalid IL or missing references)
		if (((ColumnView)GridView1).GetFocusedDataSourceRowIndex() < 0)
		{
			Interaction.MsgBox((object)"No Data Found In Data Grid Pleas Select Data First And Try", (MsgBoxStyle)0, (object)null);
			return;
		}
		string text = "";
		if (Operators.CompareString(text, "", false) == 0)
		{
			FolderBrowserDialog val = new FolderBrowserDialog();
			if ((int)((CommonDialog)val).ShowDialog() == 1)
			{
				text = val.SelectedPath;
				Interaction.SaveSetting("DATACARE APP", "BACKUP_DATABASE", "BACKUP_PATH", text);
			}
		}
		checked
		{
			if (Operators.CompareString(text, "", false) != 0)
			{
				int num = ((BaseView)GridView1).DataRowCount - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					DC_Main.MsImageNo = GridView1.GetRowCellValue(DC_Main.M, "TagNo").ToString() + "_" + GridView1.GetRowCellValue(DC_Main.M, "TagId").ToString();
					string text2 = GridView1.GetRowCellValue(DC_Main.M, "TagNo").ToString() + "_" + GridView1.GetRowCellValue(DC_Main.M, "TagId").ToString();
					string text3 = text + "\\" + text2 + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(text3, (FileAttribute)0), "", false) != 0)
					{
						DC_Main.MsImageType = "TagImage";
						DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
						PicImage.Image = Image.FromFile(text3);
						Application.DoEvents();
						Thread.Sleep(100);
						MemoryStream memoryStream = new MemoryStream();
						PicImage.Image.Save((Stream)memoryStream, PicImage.Image.RawFormat);
						byte[] buffer = memoryStream.GetBuffer();
						string value = Convert.ToBase64String(buffer);
						DC_Main.RsQry = ("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + GridView1.GetRowCellValue(DC_Main.M, "TagNo").ToString() + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(GridView1.GetRowCellValue(DC_Main.M, "TagId").ToString()))) ?? "";
						DC_Main.ExeQuteImg(DC_Main.RsQry);
						DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + GridView1.GetRowCellValue(DC_Main.M, "TagNo").ToString() + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(GridView1.GetRowCellValue(DC_Main.M, "TagId").ToString()))) ?? "";
						RsImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
						DC_Main.MsInsertData();
						DataRow dataRow = RsImg.NewRow();
						dataRow["CO_CODE"] = DC_Main.MCo_code;
						dataRow["LC_CODE"] = DC_Main.MLc_code;
						dataRow["TAG_NO"] = GridView1.GetRowCellValue(DC_Main.M, "TagNo").ToString();
						dataRow["VCH_SRNO"] = Conversion.Val(GridView1.GetRowCellValue(DC_Main.M, "TagId").ToString());
						dataRow["IMAGE_TYPE"] = "T";
						dataRow["IMG_IMPORT"] = "Y";
						dataRow["MOB_IMAGE"] = value;
						RsImg.Rows.Add(dataRow);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsImg);
						RsImg.Clear();
						Application.DoEvents();
					}
					DC_Main.M++;
				}
			}
			Interaction.MsgBox((object)"Image Import Process is Complite...", (MsgBoxStyle)0, (object)null);
			PicImage.Image = null;
		}
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0 && Operators.CompareString(((ColumnView)GridView1).GetFocusedRowCellValue("CoCode").ToString() ?? "", DC_Main.MCo_code, false) != 0)
		{
			return;
		}
		DC_Main.RsQry = string.Concat("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND CO_BOOK = '" + ((ColumnView)GridView1).GetFocusedRowCellValue("Book").ToString(), "' ");
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (dataTable.Rows.Count <= 0)
		{
			return;
		}
		DC_Main.CurBook = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["CO_BOOK"], (object)""));
		DC_Main.CurBookName = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_NAME"], (object)""));
		DC_Main.CurBookType = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_TYPE"], (object)""));
		DC_Main.CurBookItm = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["ITM_TYPE"], (object)""));
		DC_Main.CurBookMain = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["MAIN_BOOK"], (object)""));
		DC_Main.CurBookSname = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_SNAME"], (object)""));
		DC_Main.CurBookInOut = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_INOUT"], (object)""));
		DC_Main.MsUserRightForm = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["MENU_NAME"], (object)""));
		DC_Main.CurBookVch = ((ColumnView)GridView1).GetFocusedRowCellValue("VchNo").ToString() ?? "";
		if (Operators.CompareString(DC_Main.CurBookMain, "OPSTK", false) == 0)
		{
			if (Strings.Len(DC_Main.CurBookVch) != 1)
			{
				((Form)MyProject.Forms.TR_TAG_OPBL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)MyProject.Forms.TR_TAG_OPBL).Show();
				((Control)MyProject.Forms.TR_TAG_OPBL).Focus();
			}
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "TAG GEN", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR TAG", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG TAG", false) == 0))
		{
			TR_TAG_OPBL tR_TAG_OPBL = new TR_TAG_OPBL();
			((Form)tR_TAG_OPBL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_OPBL).Show();
			((Control)tR_TAG_OPBL).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG CANCEL", false) == 0)
		{
			TR_TAG_CAN tR_TAG_CAN = new TR_TAG_CAN();
			((Form)tR_TAG_CAN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN).Show();
			((Control)tR_TAG_CAN).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "STOCK ADJUST", false) == 0)
		{
			TR_TAG_CAN tR_TAG_CAN2 = new TR_TAG_CAN();
			((Form)tR_TAG_CAN2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN2).Show();
			((Control)tR_TAG_CAN2).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "APR ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CON REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CON ISU", false) == 0))
		{
			TR_APR_ISU tR_APR_ISU = new TR_APR_ISU();
			((Form)tR_APR_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_APR_ISU).Show();
			((Control)tR_APR_ISU).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "APR RTN", false) == 0)
		{
			TR_APR_ISU tR_APR_ISU2 = new TR_APR_ISU();
			((Form)tR_APR_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_APR_ISU2).Show();
			((Control)tR_APR_ISU2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES ORDER", false) == 0)
		{
			TR_SALE_ORD tR_SALE_ORD = new TR_SALE_ORD();
			((Form)tR_SALE_ORD).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SALE_ORD).Show();
			((Control)tR_SALE_ORD).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsSalesWithHmTax, "Y", false) == 0)
			{
				TR_SALE_HM tR_SALE_HM = new TR_SALE_HM();
				((Form)tR_SALE_HM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_HM).Show();
				((Control)tR_SALE_HM).Focus();
			}
			else
			{
				TR_SALE tR_SALE = new TR_SALE();
				((Form)tR_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE).Show();
				((Control)tR_SALE).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "PURCHASE", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsPurcWithHmTax, "Y", false) == 0)
			{
				TR_PURC_HM tR_PURC_HM = new TR_PURC_HM();
				((Form)tR_PURC_HM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_PURC_HM).Show();
				((Control)tR_PURC_HM).Focus();
			}
			else
			{
				TR_PURC tR_PURC = new TR_PURC();
				((Form)tR_PURC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_PURC).Show();
				((Control)tR_PURC).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "PURC RETURN", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				TR_SALE_RTN_UAE tR_SALE_RTN_UAE = new TR_SALE_RTN_UAE();
				((Form)tR_SALE_RTN_UAE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN_UAE).Show();
				((Control)tR_SALE_RTN_UAE).Focus();
			}
			else
			{
				TR_KR_ISU tR_KR_ISU = new TR_KR_ISU();
				((Form)tR_KR_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_KR_ISU).Show();
				((Control)tR_KR_ISU).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "B2B SALES", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE).Show();
			((Control)tR_PR_SL_UAE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "B2B PURC", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE2 = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE2).Show();
			((Control)tR_PR_SL_UAE2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "HEDGING FIX", false) == 0)
		{
			TR_PR_SL_HEDG tR_PR_SL_HEDG = new TR_PR_SL_HEDG();
			((Form)tR_PR_SL_HEDG).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_HEDG).Show();
			((Control)tR_PR_SL_HEDG).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "WH SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "RATE CUT", false) == 0))
		{
			TR_WH_SALE tR_WH_SALE = new TR_WH_SALE();
			((Form)tR_WH_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_WH_SALE).Show();
			((Control)tR_WH_SALE).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "KARIGAR ISSUE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MTL ISU", false) == 0))
		{
			TR_KR_ISU tR_KR_ISU2 = new TR_KR_ISU();
			((Form)tR_KR_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_KR_ISU2).Show();
			((Control)tR_KR_ISU2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "KARIGAR RECEIPT", false) == 0)
		{
			TR_PURC tR_PURC2 = new TR_PURC();
			((Form)tR_PURC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC2).Show();
			((Control)tR_PURC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG WT CHANGE", false) == 0)
		{
			TR_TAG_WT_DIFF tR_TAG_WT_DIFF = new TR_TAG_WT_DIFF();
			((Form)tR_TAG_WT_DIFF).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_WT_DIFF).Show();
			((Control)tR_TAG_WT_DIFF).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LABOUR WORK", false) == 0)
		{
			TR_SALE_LBR tR_SALE_LBR = new TR_SALE_LBR();
			((Form)tR_SALE_LBR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SALE_LBR).Show();
			((Control)tR_SALE_LBR).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES RETURNE", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				TR_SALE_RTN_UAE tR_SALE_RTN_UAE2 = new TR_SALE_RTN_UAE();
				((Form)tR_SALE_RTN_UAE2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN_UAE2).Show();
				((Control)tR_SALE_RTN_UAE2).Focus();
			}
			else
			{
				TR_SALE_RTN tR_SALE_RTN = new TR_SALE_RTN();
				((Form)tR_SALE_RTN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN).Show();
				((Control)tR_SALE_RTN).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN REC", false) == 0)
		{
			TR_DHRN_ISU tR_DHRN_ISU = new TR_DHRN_ISU();
			((Form)tR_DHRN_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_ISU).Show();
			((Control)tR_DHRN_ISU).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN INT ENTRY", false) == 0)
		{
			TR_DHRN_INTREC tR_DHRN_INTREC = new TR_DHRN_INTREC();
			((Form)tR_DHRN_INTREC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_INTREC).Show();
			((Control)tR_DHRN_INTREC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN ISSUE", false) == 0)
		{
			TR_DHRN_REC tR_DHRN_REC = new TR_DHRN_REC();
			((Form)tR_DHRN_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_REC).Show();
			((Control)tR_DHRN_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OLD ITEM SALES", false) == 0)
		{
			TR_PURC tR_PURC3 = new TR_PURC();
			((Form)tR_PURC3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC3).Show();
			((Control)tR_PURC3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH EXP", false) == 0)
		{
			TR_OTH_PURC tR_OTH_PURC = new TR_OTH_PURC();
			((Form)tR_OTH_PURC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_PURC).Show();
			((Control)tR_OTH_PURC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH INC", false) == 0)
		{
			TR_OTH_PURC tR_OTH_PURC2 = new TR_OTH_PURC();
			((Form)tR_OTH_PURC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_PURC2).Show();
			((Control)tR_OTH_PURC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BILL REC", false) == 0)
		{
			TR_BILL_TO tR_BILL_TO = new TR_BILL_TO();
			((Form)tR_BILL_TO).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_BILL_TO).Show();
			((Control)tR_BILL_TO).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG TRFR", false) == 0)
		{
			TR_TAG_CAN tR_TAG_CAN3 = new TR_TAG_CAN();
			((Form)tR_TAG_CAN3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN3).Show();
			((Control)tR_TAG_CAN3).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "CUSTREP RECEIPT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "KRREP ISSUE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "KRREP RECEIPT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CUSTREP ISSUE", false) == 0))
		{
			TR_REP_REC tR_REP_REC = new TR_REP_REC();
			((Form)tR_REP_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_REP_REC).Show();
			((Control)tR_REP_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CON PUR", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE3 = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE3).Show();
			((Control)tR_PR_SL_UAE3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "EMP JV", false) == 0)
		{
			TR_EMP_JV tR_EMP_JV = new TR_EMP_JV();
			((Form)tR_EMP_JV).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_EMP_JV).Show();
			((Control)tR_EMP_JV).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "VP PARCEL", false) == 0)
		{
			TR_VP tR_VP = new TR_VP();
			((Form)tR_VP).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_VP).Show();
			((Control)tR_VP).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CARD ADJUST", false) == 0)
		{
			TR_CARD_REC tR_CARD_REC = new TR_CARD_REC();
			((Form)tR_CARD_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CARD_REC).Show();
			((Control)tR_CARD_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BUL WH SALE", false) == 0)
		{
			TR_BUL_SALE tR_BUL_SALE = new TR_BUL_SALE();
			((Form)tR_BUL_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_BUL_SALE).Show();
			((Control)tR_BUL_SALE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "E INVOICE", false) == 0)
		{
			TR_SL_EBILL tR_SL_EBILL = new TR_SL_EBILL();
			((Form)tR_SL_EBILL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_EBILL).Show();
			((Control)tR_SL_EBILL).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "GHAT REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FTNG ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FTNG REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CHEDIYA ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CHEDIYA REC", false) == 0))
		{
			TR_JDT_REC tR_JDT_REC = new TR_JDT_REC();
			((Form)tR_JDT_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_JDT_REC).Show();
			((Control)tR_JDT_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH COMM", false) == 0)
		{
			TR_OTH_COMM tR_OTH_COMM = new TR_OTH_COMM();
			((Form)tR_OTH_COMM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_COMM).Show();
			((Control)tR_OTH_COMM).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG SPLIT", false) == 0)
		{
			TR_TAG_SPLIT tR_TAG_SPLIT = new TR_TAG_SPLIT();
			((Form)tR_TAG_SPLIT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_SPLIT).Show();
			((Control)tR_TAG_SPLIT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TOUR SALES", false) == 0)
		{
			TR_TOUR_SALE tR_TOUR_SALE = new TR_TOUR_SALE();
			((Form)tR_TOUR_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TOUR_SALE).Show();
			((Control)tR_TOUR_SALE).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "AMT OUT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "AMT IN", false) == 0))
		{
			TR_LOCT_AMT tR_LOCT_AMT = new TR_LOCT_AMT();
			((Form)tR_LOCT_AMT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_LOCT_AMT).Show();
			((Control)tR_LOCT_AMT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG PURCHASE", false) == 0)
		{
			TR_PURC_HM tR_PURC_HM2 = new TR_PURC_HM();
			((Form)tR_PURC_HM2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC_HM2).Show();
			((Control)tR_PURC_HM2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "ITM LOT", false) == 0)
		{
			TR_ITM_LOT tR_ITM_LOT = new TR_ITM_LOT();
			((Form)tR_ITM_LOT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_ITM_LOT).Show();
			((Control)tR_ITM_LOT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LD ADJUST", false) == 0)
		{
			TR_LEDR_ADJ tR_LEDR_ADJ = new TR_LEDR_ADJ();
			((Form)tR_LEDR_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_LEDR_ADJ).Show();
			((Control)tR_LEDR_ADJ).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "WH RTN", false) == 0)
		{
			TR_WH_SALE_RTN tR_WH_SALE_RTN = new TR_WH_SALE_RTN();
			((Form)tR_WH_SALE_RTN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_WH_SALE_RTN).Show();
			((Control)tR_WH_SALE_RTN).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "FINE SALE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FINE PURC", false) == 0))
		{
			TR_FINE_SL_PR tR_FINE_SL_PR = new TR_FINE_SL_PR();
			((Form)tR_FINE_SL_PR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_FINE_SL_PR).Show();
			((Control)tR_FINE_SL_PR).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "ITEM SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "ITEM PURC", false) == 0))
		{
			TR_SL_PR_ITEM tR_SL_PR_ITEM = new TR_SL_PR_ITEM();
			((Form)tR_SL_PR_ITEM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_PR_ITEM).Show();
			((Control)tR_SL_PR_ITEM).Focus();
		}
	}

	private Image LoadImageSafe(string path)
	{
		using FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		return Image.FromStream((Stream)fileStream);
	}

	private void SaveImageSafe(Image img, string path, int quality)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		ImageCodecInfo val = ImageCodecInfo.GetImageEncoders().FirstOrDefault([SpecialName] (ImageCodecInfo c) => c.FormatID == ImageFormat.Jpeg.Guid);
		EncoderParameters val2 = new EncoderParameters(1);
		val2.Param[0] = new EncoderParameter(Encoder.Quality, (long)quality);
		Bitmap val3 = new Bitmap(img);
		try
		{
			((Image)val3).Save(path, val, val2);
		}
		finally
		{
			((IDisposable)val3)?.Dispose();
		}
	}

	private Image GetImageWithoutLock(string path)
	{
		if (!File.Exists(path))
		{
			return null;
		}
		byte[] buffer = File.ReadAllBytes(path);
		MemoryStream memoryStream = new MemoryStream(buffer);
		return Image.FromStream((Stream)memoryStream);
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImprt_Click(object sender, EventArgs e)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected O, but got Unknown
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Expected O, but got Unknown
		//IL_04be: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c5: Expected O, but got Unknown
		//IL_0663: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		object obj = default(object);
		byte[] bA = default(byte[]);
		object objectValue = default(object);
		float num5 = default(float);
		Bitmap val = default(Bitmap);
		int width = default(int);
		Bitmap val2 = default(Bitmap);
		Graphics val3 = default(Graphics);
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
						DC_Main.ExeQuteImg("UPDATE TAG_IMAGE_DATA SET IMG_IMPORT = 'N' WHERE IMG_IMPORT IS NULL ");
						goto IL_000f;
					case 1978:
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
								goto IL_000f;
							case 3:
								goto IL_0018;
							case 4:
								goto IL_0034;
							case 5:
								goto IL_0040;
							case 6:
								goto IL_007a;
							case 7:
								goto IL_008b;
							case 10:
								goto IL_0098;
							case 11:
								goto IL_00f0;
							case 12:
								goto IL_0133;
							case 13:
								goto IL_0155;
							case 14:
							case 15:
								goto IL_0165;
							case 16:
								goto IL_0175;
							case 17:
								goto IL_0223;
							case 18:
								goto IL_0235;
							case 19:
								goto IL_0253;
							case 20:
								goto IL_027c;
							case 21:
								goto IL_028d;
							case 22:
								goto IL_029e;
							case 23:
								goto IL_02b4;
							case 24:
								goto IL_02e0;
							case 25:
							case 26:
								goto IL_02fa;
							case 27:
								goto IL_030a;
							case 28:
								goto IL_0324;
							case 29:
								goto IL_033a;
							case 31:
								goto IL_0346;
							case 32:
								goto IL_0358;
							case 34:
								goto IL_0375;
							case 35:
								goto IL_0387;
							case 37:
								goto IL_03a4;
							case 38:
								goto IL_03b6;
							case 40:
								goto IL_03d3;
							case 41:
								goto IL_03e5;
							case 43:
								goto IL_0402;
							case 44:
								goto IL_0414;
							case 46:
								goto IL_042e;
							case 47:
								goto IL_0440;
							case 49:
								goto IL_045a;
							case 50:
								goto IL_046c;
							case 52:
								goto IL_0486;
							case 30:
							case 33:
							case 36:
							case 39:
							case 42:
							case 45:
							case 48:
							case 51:
							case 53:
								goto IL_0497;
							case 54:
								goto IL_04c5;
							case 55:
								goto IL_04d1;
							case 56:
								goto IL_04dd;
							case 57:
								goto IL_04e9;
							case 58:
								goto IL_04f5;
							case 59:
								goto IL_0516;
							case 60:
								goto IL_0527;
							case 61:
								goto IL_054a;
							case 62:
								goto IL_0554;
							case 63:
							case 64:
							case 65:
								goto IL_0562;
							case 66:
								goto IL_0610;
							case 67:
								goto IL_061e;
							case 68:
								goto IL_062d;
							case 8:
							case 9:
							case 69:
								goto IL_0637;
							case 70:
								goto IL_0659;
							case 71:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 72:
							case 73:
							case 74:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0610:
						num2 = 66;
						DC_Main.ExeQuteImg(DC_Main.RsQry);
						goto IL_061e;
						IL_061e:
						num2 = 67;
						DC_Main.i++;
						goto IL_062d;
						IL_0562:
						num2 = 65;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE TAG_IMAGE_DATA SET IMG_IMPORT = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"]), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"], (object)""))), (object)""));
						goto IL_0610;
						IL_062d:
						num2 = 68;
						Application.DoEvents();
						goto IL_0637;
						IL_000f:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_0018;
						IL_0018:
						num2 = 3;
						if (unchecked((int)Interaction.MsgBox((object)"Are You Sure To Import Image to Pc Folder now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) != 6)
						{
							goto end_IL_0001_3;
						}
						goto IL_0034;
						IL_0034:
						num2 = 4;
						DC_Main.MsImageType = "TagImage";
						goto IL_0040;
						IL_0040:
						num2 = 5;
						DC_Main.RsQry = "SELECT TOP 250 A.TAG_NO,A.VCH_SRNO FROM TAG_IMAGE_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.IMG_IMPORT = 'N' ORDER BY TAG_NO ";
						goto IL_007a;
						IL_007a:
						num2 = 6;
						DC_Main.Rshlp = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
						goto IL_008b;
						IL_008b:
						num2 = 7;
						DC_Main.i = 0;
						goto IL_0637;
						IL_0637:
						num2 = 9;
						if (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							goto IL_0098;
						}
						goto IL_0659;
						IL_0659:
						num2 = 70;
						Interaction.MsgBox((object)"Image Is Import Process is Complite...", (MsgBoxStyle)0, (object)null);
						break;
						IL_0098:
						num2 = 10;
						DC_Main.MsImageNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"], (object)"_"), DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"]));
						goto IL_00f0;
						IL_00f0:
						num2 = 11;
						DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
						goto IL_0133;
						IL_0133:
						num2 = 12;
						if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
						{
							goto IL_0155;
						}
						goto IL_0165;
						IL_0155:
						num2 = 13;
						FileSystem.Kill(DC_Main.MsImagePath);
						goto IL_0165;
						IL_0165:
						num2 = 15;
						PicImage.Image = null;
						goto IL_0175;
						IL_0175:
						num2 = 16;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT MOB_IMAGE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"]), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"], (object)""))), (object)""));
						goto IL_0223;
						IL_0223:
						num2 = 17;
						DC_Main.Tbl = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
						goto IL_0235;
						IL_0235:
						num2 = 18;
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							goto IL_0253;
						}
						goto IL_0562;
						IL_0253:
						num2 = 19;
						obj = Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MOB_IMAGE"], (object)"");
						goto IL_027c;
						IL_027c:
						num2 = 20;
						bA = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj));
						goto IL_028d;
						IL_028d:
						num2 = 21;
						objectValue = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA));
						goto IL_029e;
						IL_029e:
						num2 = 22;
						PicImage.Image = (Image)objectValue;
						goto IL_02b4;
						IL_02b4:
						num2 = 23;
						if (Operators.CompareString(FileSystem.Dir(Application.StartupPath + "\\temp.jpg", (FileAttribute)0), "", false) != 0)
						{
							goto IL_02e0;
						}
						goto IL_02fa;
						IL_02e0:
						num2 = 24;
						FileSystem.Kill(Application.StartupPath + "\\temp.jpg");
						goto IL_02fa;
						IL_02fa:
						num2 = 26;
						num5 = float.Parse(Conversions.ToString(1));
						goto IL_030a;
						IL_030a:
						num2 = 27;
						if (PicImage.Image != null)
						{
							goto IL_0324;
						}
						goto IL_0562;
						IL_0324:
						num2 = 28;
						val = new Bitmap(PicImage.Image);
						goto IL_033a;
						IL_033a:
						num2 = 29;
						width = ((Image)val).Width;
						goto IL_0346;
						IL_0346:
						num2 = 31;
						if (width > 5000)
						{
							goto IL_0358;
						}
						goto IL_0375;
						IL_0358:
						num2 = 32;
						num5 = float.Parse(Conversions.ToString(0.4));
						goto IL_0497;
						IL_0375:
						num2 = 34;
						if (width > 4500)
						{
							goto IL_0387;
						}
						goto IL_03a4;
						IL_0387:
						num2 = 35;
						num5 = float.Parse(Conversions.ToString(0.5));
						goto IL_0497;
						IL_03a4:
						num2 = 37;
						if (width > 4000)
						{
							goto IL_03b6;
						}
						goto IL_03d3;
						IL_03b6:
						num2 = 38;
						num5 = float.Parse(Conversions.ToString(0.6));
						goto IL_0497;
						IL_03d3:
						num2 = 40;
						if (width > 3500)
						{
							goto IL_03e5;
						}
						goto IL_0402;
						IL_03e5:
						num2 = 41;
						num5 = float.Parse(Conversions.ToString(0.7));
						goto IL_0497;
						IL_0402:
						num2 = 43;
						if (width > 3000)
						{
							goto IL_0414;
						}
						goto IL_042e;
						IL_0414:
						num2 = 44;
						num5 = float.Parse(Conversions.ToString(0.7));
						goto IL_0497;
						IL_042e:
						num2 = 46;
						if (width > 2500)
						{
							goto IL_0440;
						}
						goto IL_045a;
						IL_0440:
						num2 = 47;
						num5 = float.Parse(Conversions.ToString(0.8));
						goto IL_0497;
						IL_045a:
						num2 = 49;
						if (width > 2000)
						{
							goto IL_046c;
						}
						goto IL_0486;
						IL_046c:
						num2 = 50;
						num5 = float.Parse(Conversions.ToString(0.9));
						goto IL_0497;
						IL_0486:
						num2 = 52;
						num5 = float.Parse(Conversions.ToString(1));
						goto IL_0497;
						IL_0497:
						num2 = 53;
						val2 = new Bitmap((int)Math.Round((float)((Image)val).Width * num5), (int)Math.Round((float)((Image)val).Height * num5));
						goto IL_04c5;
						IL_04c5:
						num2 = 54;
						val3 = Graphics.FromImage((Image)(object)val2);
						goto IL_04d1;
						IL_04d1:
						num2 = 55;
						val3.SmoothingMode = (SmoothingMode)2;
						goto IL_04dd;
						IL_04dd:
						num2 = 56;
						val3.InterpolationMode = (InterpolationMode)7;
						goto IL_04e9;
						IL_04e9:
						num2 = 57;
						val3.PixelOffsetMode = (PixelOffsetMode)2;
						goto IL_04f5;
						IL_04f5:
						num2 = 58;
						val3.DrawImage((Image)(object)val, 0, 0, ((Image)val2).Width + 1, ((Image)val2).Height + 1);
						goto IL_0516;
						IL_0516:
						num2 = 59;
						PicImage.Image = (Image)(object)val2;
						goto IL_0527;
						IL_0527:
						num2 = 60;
						PicImage.Image.Save(Application.StartupPath + "\\temp.jpg");
						goto IL_054a;
						IL_054a:
						num2 = 61;
						Main_image_mi();
						goto IL_0554;
						IL_0554:
						num2 = 62;
						Small_Image();
						goto IL_0562;
						end_IL_0001_2:
						break;
					}
					num2 = 71;
					PicImage.Image = null;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj2) when (obj2 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj2);
				try0001_dispatch = 1978;
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

	private void Main_image_mi()
	{
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		long num = FileSystem.FileLen(Application.StartupPath + "\\temp.jpg");
		nLbrPrc.Text = "";
		nTotAmt.Text = "";
		checked
		{
			string text;
			if (num < 1000)
			{
				text = " Bytes";
			}
			else if (num > 1000000)
			{
				num = (long)Conversion.Int((double)num / 1000000.0);
				text = " Mb";
			}
			else
			{
				num = (long)Conversion.Int((double)num / 1000.0);
				text = " Kb";
			}
			nLbrPrc.Text = Conversions.ToString(num) + text;
			int num2 = 100;
			if (Operators.CompareString(text, " Kb", false) != 0)
			{
				double num3 = Conversion.Val((object)num);
				num2 = ((num3 > 30.0) ? 10 : ((num3 > 25.0) ? 15 : ((num3 > 20.0) ? 20 : ((num3 > 15.0) ? 25 : ((num3 > 10.0) ? 30 : ((num3 > 7.0) ? 30 : ((num3 > 5.0) ? 35 : ((num3 > 3.0) ? 35 : ((num3 > 2.0) ? 35 : ((!(num3 > 1.0)) ? 45 : 40))))))))));
			}
			Bitmap val = (Bitmap)Image.FromFile(Application.StartupPath + "\\temp.jpg");
			SaveJPGWithCompressionSetting(PicImage.Image, DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg", num2);
			((Image)val).Dispose();
			PicImage.Image.Dispose();
			PicImage.Image = null;
			DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
			if (Operators.CompareString(DC_Main.MsUrlPath, "", false) != 0)
			{
				string ftpuri = DC_Main.MsUrlPath + DC_Main.MsImageNo + ".jpg";
				Ac_Image.FtpUploadFile(DC_Main.MsImagePath, ftpuri, DC_Main.MsUrlId, DC_Main.MsUrlPwd);
			}
			PicImage.Image = Image.FromFile(DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg");
			num = FileSystem.FileLen(DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg");
			if (num < 1000)
			{
				text = " Bytes";
			}
			else if (num > 1000000)
			{
				num = (long)Conversion.Int((double)num / 1000000.0);
				text = " Mb";
			}
			else
			{
				num = (long)Conversion.Int((double)num / 1000.0);
				text = " Kb";
			}
			nTotAmt.Text = Conversions.ToString(num) + text;
		}
	}

	private void Main_image(string SourcePath)
	{
		if (File.Exists(SourcePath))
		{
			long num = FileSystem.FileLen(SourcePath);
			string text = "";
			double num2 = num;
			if (num < 1000)
			{
				text = " Bytes";
			}
			else if (num > 1000000)
			{
				num2 = Conversion.Int((double)num / 1000000.0);
				text = " Mb";
			}
			else
			{
				num2 = Conversion.Int((double)num / 1000.0);
				text = " Kb";
			}
			nLbrPrc.Text = Conversions.ToString(num2) + text;
			int num3 = 100;
			if (Operators.CompareString(text, " Kb", false) != 0)
			{
				double num4 = num2;
				num3 = ((num4 > 30.0) ? 10 : ((num4 > 25.0) ? 15 : ((num4 > 20.0) ? 20 : ((num4 > 15.0) ? 25 : ((num4 > 10.0) ? 30 : ((num4 > 7.0) ? 30 : ((num4 > 5.0) ? 35 : ((num4 > 3.0) ? 35 : ((num4 > 2.0) ? 35 : ((!(num4 > 1.0)) ? 45 : 40))))))))));
			}
			Image imageWithoutLock = GetImageWithoutLock(SourcePath);
			string text2 = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
			if (File.Exists(text2))
			{
				File.Delete(text2);
			}
			SaveJPGWithCompressionSetting(imageWithoutLock, text2, num3);
			imageWithoutLock.Dispose();
			if (Operators.CompareString(DC_Main.MsUrlPath, "", false) != 0)
			{
				string ftpuri = DC_Main.MsUrlPath + DC_Main.MsImageNo + ".jpg";
				Ac_Image.FtpUploadFile(text2, ftpuri, DC_Main.MsUrlId, DC_Main.MsUrlPwd);
			}
			num = FileSystem.FileLen(text2);
			if (num > 1000000)
			{
				nTotAmt.Text = Conversions.ToString(Conversion.Int((double)num / 1000000.0)) + " Mb";
			}
			else
			{
				nTotAmt.Text = Conversions.ToString(Conversion.Int((double)num / 1000.0)) + " Kb";
			}
			PicImage.Image = GetImageWithoutLock(text2);
		}
	}

	private void Small_Image(string SourcePath)
	{
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		checked
		{
			if (File.Exists(SourcePath))
			{
				Image imageWithoutLock = GetImageWithoutLock(SourcePath);
				float num = 1f;
				int width = imageWithoutLock.Width;
				num = ((width > 4500) ? 0.05f : ((width > 4000) ? 0.07f : ((width > 3500) ? 0.08f : ((width > 3000) ? 0.09f : ((width > 2500) ? 0.1f : ((width > 2000) ? 0.3f : ((width > 1900) ? 0.7f : ((width > 700) ? 0.8f : ((width <= 500) ? 1f : 0.9f)))))))));
				Bitmap val = new Bitmap((int)Math.Round((float)imageWithoutLock.Width * num), (int)Math.Round((float)imageWithoutLock.Height * num));
				Graphics val2 = Graphics.FromImage((Image)(object)val);
				try
				{
					val2.SmoothingMode = (SmoothingMode)2;
					val2.InterpolationMode = (InterpolationMode)7;
					val2.PixelOffsetMode = (PixelOffsetMode)2;
					val2.DrawImage(imageWithoutLock, 0, 0, ((Image)val).Width + 1, ((Image)val).Height + 1);
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				imageWithoutLock.Dispose();
				string text = Application.StartupPath + "\\temp_small.jpg";
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				((Image)val).Save(text);
				long num2 = FileSystem.FileLen(text);
				string text2 = "";
				double num3 = num2;
				if (num2 > 1000000)
				{
					text2 = " Mb";
					num3 = Conversion.Int((double)num2 / 1000000.0);
				}
				else
				{
					text2 = " Kb";
					num3 = Conversion.Int((double)num2 / 1000.0);
				}
				int num4 = 50;
				if (Operators.CompareString(text2, " Kb", false) != 0)
				{
					double num5 = num3;
					num4 = ((num5 > 30.0) ? 10 : ((!(num5 > 25.0)) ? 45 : 15));
				}
				string text3 = DC_Main.MSImageSavePath + "\\SmallImage\\" + DC_Main.MsImageNo + ".jpg";
				if (File.Exists(text3))
				{
					File.Delete(text3);
				}
				SaveJPGWithCompressionSetting((Image)(object)val, text3, num4);
				((Image)val).Dispose();
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				if (PicSmall.Image != null)
				{
					PicSmall.Image.Dispose();
				}
				PicSmall.Image = GetImageWithoutLock(text3);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgSelect_Click(object sender, EventArgs e)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Invalid comparison between Unknown and I4
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected O, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Expected O, but got Unknown
		//IL_0535: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Expected O, but got Unknown
		((FileDialog)DlgOpen).Filter = "JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg";
		((FileDialog)DlgOpen).Title = "Open Image File";
		if ((int)((CommonDialog)DlgOpen).ShowDialog() != 1)
		{
			return;
		}
		DC_Main.MsImageNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(((DataGridView)DGV_DETL)[1, 0].Value, (object)"_"), ((DataGridView)DGV_DETL)[29, 0].Value));
		DC_Main.MsImageType = "TagImage";
		DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
		if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
		{
			if (PicImage.Image != null)
			{
				PicImage.Image.Dispose();
				PicImage.Image = null;
				GC.Collect();
				GC.WaitForPendingFinalizers();
			}
			FileSystem.Kill(DC_Main.MsImagePath);
		}
		PicImage.Image = Image.FromFile(((FileDialog)DlgOpen).FileName);
		if (Operators.CompareString(FileSystem.Dir(Application.StartupPath + "\\temp.jpg", (FileAttribute)0), "", false) != 0)
		{
			FileSystem.Kill(Application.StartupPath + "\\temp.jpg");
		}
		float num = float.Parse(Conversions.ToString(1));
		Bitmap val = new Bitmap(PicImage.Image);
		int width = ((Image)val).Width;
		num = ((width > 5000) ? float.Parse(Conversions.ToString(0.5)) : ((width > 4500) ? float.Parse(Conversions.ToString(0.6)) : ((width > 4000) ? float.Parse(Conversions.ToString(0.7)) : ((width > 3500) ? float.Parse(Conversions.ToString(0.8)) : ((width > 3000) ? float.Parse(Conversions.ToString(0.75)) : ((width > 2500) ? float.Parse(Conversions.ToString(0.8)) : ((width <= 2000) ? float.Parse(Conversions.ToString(1)) : float.Parse(Conversions.ToString(0.9)))))))));
		checked
		{
			Bitmap val2 = new Bitmap((int)Math.Round((float)((Image)val).Width * num), (int)Math.Round((float)((Image)val).Height * num));
			Graphics val3 = Graphics.FromImage((Image)(object)val2);
			val3.SmoothingMode = (SmoothingMode)2;
			val3.InterpolationMode = (InterpolationMode)7;
			val3.PixelOffsetMode = (PixelOffsetMode)2;
			val3.DrawImage((Image)(object)val, 0, 0, ((Image)val2).Width + 1, ((Image)val2).Height + 1);
			PicImage.Image = (Image)(object)val2;
			PicImage.Image.Save(Application.StartupPath + "\\temp.jpg");
			long num2 = FileSystem.FileLen(Application.StartupPath + "\\temp.jpg");
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
			string text2 = Conversions.ToString(num2) + text;
			int num3 = 100;
			if (Operators.CompareString(text, " Kb", false) != 0)
			{
				double num4 = Conversion.Val((object)num2);
				num3 = ((num4 > 30.0) ? 20 : ((num4 > 25.0) ? 30 : ((num4 > 20.0) ? 35 : ((num4 > 15.0) ? 40 : ((num4 > 10.0) ? 50 : ((num4 > 7.0) ? 55 : ((num4 > 5.0) ? 70 : ((num4 > 3.0) ? 75 : ((num4 > 2.0) ? 80 : ((!(num4 > 1.0)) ? 90 : 85))))))))));
			}
			Bitmap val4 = (Bitmap)Image.FromFile(Application.StartupPath + "\\temp.jpg");
			SaveJPGWithCompressionSetting(PicImage.Image, DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg", num3);
			((Image)val4).Dispose();
			PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
			Mobile_image_Save();
			Small_Image();
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
			SaveJPGWithCompressionSetting(PicSmall.Image, DC_Main.MSImageSavePath + "\\SmallImage\\" + DC_Main.MsImageNo + ".jpg", num3);
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
}
