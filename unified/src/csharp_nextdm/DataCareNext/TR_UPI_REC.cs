using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxMSFlexGridLib;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class TR_UPI_REC : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ENTRY")]
	private TextBox _TEXT_ENTRY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG")]
	private AxMSFlexGrid _MSG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExit")]
	private SimpleButton _BtnExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnCancel")]
	private SimpleButton _BtnCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSave")]
	private SimpleButton _BtnSave;

	private string EntryMode;

	private Control CurActCtrl;

	private bool MsgClear;

	private bool UpDown;

	private int MsgOldRow;

	private bool Msgleft;

	private string UserEdit;

	private bool UpiTypeAdd;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private DataTable RsDetl;

	private double ColCon;

	private string MaxVchNo;

	private long FGRow;

	private string CurUpiBook;

	private string CurUpiVchNo;

	private string CurUpiAcCode;

	private string CurMast;

	private const int cSrNo = 0;

	private const int cAcCode = 1;

	private const int cAcName = 2;

	private const int cUpiType = 3;

	private const int cUpiId = 4;

	private const int cUpiAmt = 5;

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
			AxMSFlexGrid val = _MSG;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
				val.RowColChange -= eventHandler4;
			}
			_MSG = value;
			val = _MSG;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
				val.RowColChange += eventHandler4;
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
	[AccessedThroughProperty("tVchNo")]
	private virtual TextBox _tVchNo;

	internal virtual TextBox tVchNo
	{
		get
		{
			return _tVchNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tVchNo = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mVchDate")]
	private virtual MaskedTextBox _mVchDate;

	internal virtual MaskedTextBox mVchDate
	{
		get
		{
			return _mVchDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_mVchDate = value;
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
	[AccessedThroughProperty("tAcCode")]
	private virtual TextBox _tAcCode;

	internal virtual TextBox tAcCode
	{
		get
		{
			return _tAcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tAcCode = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcName")]
	private virtual TextBox _tAcName;

	internal virtual TextBox tAcName
	{
		get
		{
			return _tAcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tAcName = value;
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
	[AccessedThroughProperty("tCoBook")]
	private virtual TextBox _tCoBook;

	internal virtual TextBox tCoBook
	{
		get
		{
			return _tCoBook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tCoBook = value;
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
	[AccessedThroughProperty("nUpiTotAmt")]
	private virtual TextBox _nUpiTotAmt;

	internal virtual TextBox nUpiTotAmt
	{
		get
		{
			return _nUpiTotAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nUpiTotAmt = value;
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
	[AccessedThroughProperty("nbillOsAmt")]
	private virtual TextBox _nbillOsAmt;

	internal virtual TextBox nbillOsAmt
	{
		get
		{
			return _nbillOsAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nbillOsAmt = value;
		}
	}

	public TR_UPI_REC()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((Form)this).Load += TR_UPI_REC_Load;
		((Form)this).Activated += TR_UPI_REC_Activated;
		((Form)this).Deactivate += TR_UPI_REC_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_UPI_REC_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_UPI_REC_KeyDown);
		((Control)this).KeyUp += new KeyEventHandler(TR_UPI_REC_KeyUp);
		((Form)this).Closed += TR_UPI_REC_Closed;
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
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected O, but got Unknown
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Expected O, but got Unknown
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Expected O, but got Unknown
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Expected O, but got Unknown
		//IL_052b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Expected O, but got Unknown
		//IL_0651: Unknown result type (might be due to invalid IL or missing references)
		//IL_065b: Expected O, but got Unknown
		//IL_06be: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c8: Expected O, but got Unknown
		//IL_076a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0774: Expected O, but got Unknown
		//IL_0832: Unknown result type (might be due to invalid IL or missing references)
		//IL_083c: Expected O, but got Unknown
		//IL_08d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e1: Expected O, but got Unknown
		//IL_0989: Unknown result type (might be due to invalid IL or missing references)
		//IL_0993: Expected O, but got Unknown
		//IL_0a1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a24: Expected O, but got Unknown
		//IL_0ae2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aec: Expected O, but got Unknown
		//IL_0b7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b84: Expected O, but got Unknown
		//IL_0c09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c13: Expected O, but got Unknown
		//IL_0cb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cba: Expected O, but got Unknown
		//IL_0d78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d82: Expected O, but got Unknown
		//IL_0e09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e13: Expected O, but got Unknown
		//IL_0ed4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ede: Expected O, but got Unknown
		//IL_0f75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f7f: Expected O, but got Unknown
		//IL_103d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1047: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_UPI_REC));
		lblBook = new Label();
		TEXT_ENTRY = new TextBox();
		MSG = new AxMSFlexGrid();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		Label2 = new Label();
		tVchNo = new TextBox();
		mTime = new TextBox();
		mVchDate = new MaskedTextBox();
		lblBDate = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label1 = new Label();
		Label3 = new Label();
		tCoBook = new TextBox();
		Label4 = new Label();
		nUpiTotAmt = new TextBox();
		Label5 = new Label();
		nbillOsAmt = new TextBox();
		((ISupportInitialize)MSG).BeginInit();
		((Control)PnlBotam).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		((Control)lblBook).Dock = (DockStyle)1;
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).Font = new Font("Segoe UI", 14.25f);
		((Control)lblBook).ForeColor = Color.FromArgb(64, 0, 64);
		lblBook.ImeMode = (ImeMode)0;
		((Control)lblBook).Location = new Point(0, 0);
		((Control)lblBook).Name = "lblBook";
		((Control)lblBook).Size = new Size(1072, 32);
		((Control)lblBook).TabIndex = 101;
		lblBook.Text = "Upi Amount Rec";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(554, 275);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 1;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)MSG).Location = new Point(218, 150);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(748, 310);
		((Control)MSG).TabIndex = 1;
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 528);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1072, 41);
		((Control)PnlBotam).TabIndex = 1133;
		((BaseStyleControl)BtnExit).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1);
		((BaseStyleControl)BtnExit).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExit).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExit).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnExit.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExit.ImageOptions.SvgImage");
		((Control)BtnExit).Location = new Point(978, 3);
		((BaseControl)BtnExit).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExit).Name = "BtnExit";
		((Control)BtnExit).Size = new Size(91, 37);
		((Control)BtnExit).TabIndex = 25;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1);
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		((Control)BtnCancel).Location = new Point(881, 3);
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((Control)BtnCancel).Size = new Size(91, 37);
		((Control)BtnCancel).TabIndex = 23;
		BtnCancel.Text = "&Cancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnSave).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1);
		((BaseStyleControl)BtnSave).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSave).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSave.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSave.ImageOptions.SvgImage");
		((Control)BtnSave).Location = new Point(784, 3);
		((BaseControl)BtnSave).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSave).Name = "BtnSave";
		((Control)BtnSave).Size = new Size(91, 37);
		((Control)BtnSave).TabIndex = 22;
		BtnSave.Text = "&Save";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(412, 85);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(62, 20);
		((Control)Label2).TabIndex = 1135;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Enabled = false;
		((Control)tVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchNo).Location = new Point(480, 85);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 23);
		((Control)tVchNo).TabIndex = 1134;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Enabled = false;
		((Control)mTime).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mTime).Location = new Point(735, 85);
		((TextBoxBase)mTime).MaxLength = 8;
		((Control)mTime).Name = "mTime";
		((TextBoxBase)mTime).ReadOnly = true;
		((Control)mTime).Size = new Size(83, 23);
		((Control)mTime).TabIndex = 1138;
		mTime.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Enabled = false;
		((Control)mVchDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mVchDate).Location = new Point(653, 85);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 1136;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(571, 86);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1137;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Enabled = false;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(315, 113);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 1158;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Enabled = false;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(397, 113);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(421, 23);
		((Control)tAcName).TabIndex = 1159;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(226, 112);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(75, 20);
		((Control)Label1).TabIndex = 1160;
		Label1.Text = "Party Code";
		Label1.TextAlign = (ContentAlignment)16;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(225, 82);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(102, 20);
		((Control)Label3).TabIndex = 1162;
		Label3.Text = "Book Code";
		Label3.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tCoBook).BackColor = Color.White;
		((Control)tCoBook).Enabled = false;
		((Control)tCoBook).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tCoBook).Location = new Point(315, 82);
		((TextBoxBase)tCoBook).MaxLength = 8;
		((Control)tCoBook).Name = "tCoBook";
		((TextBoxBase)tCoBook).ReadOnly = true;
		((Control)tCoBook).Size = new Size(76, 23);
		((Control)tCoBook).TabIndex = 1161;
		((Control)Label4).Enabled = false;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(736, 471);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(98, 20);
		((Control)Label4).TabIndex = 1164;
		Label4.Text = "Upi Tot Amt";
		Label4.TextAlign = (ContentAlignment)16;
		((TextBoxBase)nUpiTotAmt).BackColor = Color.White;
		((Control)nUpiTotAmt).Enabled = false;
		((Control)nUpiTotAmt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nUpiTotAmt).Location = new Point(849, 468);
		((TextBoxBase)nUpiTotAmt).MaxLength = 8;
		((Control)nUpiTotAmt).Name = "nUpiTotAmt";
		((TextBoxBase)nUpiTotAmt).ReadOnly = true;
		((Control)nUpiTotAmt).Size = new Size(89, 23);
		((Control)nUpiTotAmt).TabIndex = 1163;
		nUpiTotAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label5).Enabled = false;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(824, 85);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(98, 20);
		((Control)Label5).TabIndex = 1165;
		Label5.Text = "Bill Os Amt";
		Label5.TextAlign = (ContentAlignment)16;
		((TextBoxBase)nbillOsAmt).BackColor = Color.White;
		((Control)nbillOsAmt).Enabled = false;
		((Control)nbillOsAmt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nbillOsAmt).Location = new Point(824, 113);
		((TextBoxBase)nbillOsAmt).MaxLength = 8;
		((Control)nbillOsAmt).Name = "nbillOsAmt";
		((TextBoxBase)nbillOsAmt).ReadOnly = true;
		((Control)nbillOsAmt).Size = new Size(89, 23);
		((Control)nbillOsAmt).TabIndex = 1166;
		nbillOsAmt.TextAlign = (HorizontalAlignment)1;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1072, 569);
		((Form)this).ControlBox = false;
		((Control)this).Controls.Add((Control)(object)nbillOsAmt);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)nUpiTotAmt);
		((Control)this).Controls.Add((Control)(object)tCoBook);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)mTime);
		((Control)this).Controls.Add((Control)(object)mVchDate);
		((Control)this).Controls.Add((Control)(object)lblBDate);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tVchNo);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "TR_UPI_REC";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Upi Rec";
		((ISupportInitialize)MSG).EndInit();
		((Control)PnlBotam).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 6;
		mSG.Rows = 2;
		mSG.Row = 0;
		mSG[0] = 325;
		checked
		{
			mSG[0] = (int)Math.Round(450.0 * ColCon);
			mSG[0] = 3;
			mSG[0, 0] = "Sr.";
			mSG[1] = (int)Math.Round(1300.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "AcCode";
			mSG[2] = (int)Math.Round(3500.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "Upi Bank Name";
			mSG[3] = (int)Math.Round(1500.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "UpiType";
			mSG[4] = (int)Math.Round(2500.0 * ColCon);
			mSG[4] = 0;
			mSG[0, 4] = "Upi Id";
			mSG[5] = (int)Math.Round(1600.0 * ColCon);
			mSG[5] = 7;
			mSG[0, 5] = "UpiAmt";
			mSG.Row = 1;
			mSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			mSG = null;
		}
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
				case 1:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 3:
				case 4:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 25;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 5:
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
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
				MSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 5:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				TotAmt();
				break;
			}
			mSG = null;
		}
	}

	private void TotAmt()
	{
		nUpiTotAmt.Text = "";
		checked
		{
			int num = MSG.Rows - 1;
			double num2 = default(double);
			for (int i = 1; i <= num; i++)
			{
				if ((Operators.CompareString(MSG[i, 1], "", false) != 0) & (Conversion.Val(MSG[i, 5]) != 0.0))
				{
					num2 += Conversion.Val(MSG[i, 5]);
				}
			}
			nUpiTotAmt.Text = Strings.Format((object)num2, "0.00");
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG = null;
	}

	private void TR_UPI_REC_Load(object sender, EventArgs e)
	{
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurMast = DC_Main.MsUserRightForm;
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
			((Control)this).Width = ((Control)MSG).Width + 25;
			((Control)this).Height = ((Control)MSG).Height + 107;
			CLEAR_DATA();
			CurUpiBook = DC_Main.MsUpiDbCd;
			CurUpiVchNo = DC_Main.MsUpiVchNo;
			CurUpiAcCode = DC_Main.MsUpiAcCode;
			tCoBook.Text = DC_Main.MsUpiDbCd;
			tVchNo.Text = DC_Main.MsUpiVchNo;
			tAcCode.Text = DC_Main.MsUpiAcCode;
			tAcName.Text = DC_Main.MsUpiAcName;
			mVchDate.Text = Strings.Format((object)DC_Main.MsUpiDate, "dd/MM/yyyy");
			mTime.Text = Strings.Format((object)DateAndTime.Now, "HH:mm");
			nbillOsAmt.Text = Strings.Format((object)DC_Main.MsUpiBillOsAmt, "0.00");
			DC_Main.MsUpiDbCd = "";
			DC_Main.MsUpiVchNo = "";
			DC_Main.MsUpiAcCode = "";
			DC_Main.MsUpiAcName = "";
			DC_Main.MsUpiAmt = 0.0;
			DC_Main.MsUpiBillOsAmt = 0.0;
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
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj10 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AxMSFlexGrid mSG4 = MSG;
				object? obj11 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj12 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj12 != null) ? ((Color)obj12) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj13 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj13 != null) ? ((Color)obj13) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj14 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj15 = lblBook;
				object? obj16 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj15).ForeColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj17 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj18 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj19 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj20 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj20 != null) ? ((Color)obj20) : default(Color));
			}
			DISPLAY_DATA();
			CurActCtrl = (Control)(object)TEXT_ENTRY;
		}
	}

	private void TR_UPI_REC_Activated(object sender, EventArgs e)
	{
		((ContainerControl)this).ActiveControl = CurActCtrl;
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
		}
		MainUser = DC_Main.MCo_User;
		MSG_CLEAR();
		CommPassAdd();
		UpiTypeAdd = false;
		EntryMode = "A";
		((Control)TEXT_ENTRY).Focus();
	}

	private void DISPLAY_DATA()
	{
		MSG_CLEAR();
		DC_Main.RsQry = "SELECT * FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + CurUpiBook + "' AND VCH_NO = '" + CurUpiVchNo + "' ORDER BY SR_NO ";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				DC_Main.i = 0;
				tCoBook.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["CO_BOOK"], (object)""));
				tVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["VCH_NO"], (object)""));
				mVchDate.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["VCH_DATE"], (object)""));
				mTime.Text = Strings.Format((object)Conversions.ToDate(DC_Main.Tbl.Rows[0]["VCH_TIME"]), "HH:mm");
				tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["AC_CODE"], (object)""));
				tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["AC_CODE"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < DC_Main.Tbl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["UPI_AC_CODE"], (object)""));
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["UPI_AC_NAME"], (object)""));
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["UPI_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["UPI_ID"], (object)""));
					mSG[DC_Main.i + 1, 5] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["UPI_AMT"]), "0.00");
					if (Conversion.Val(mSG[DC_Main.i + 1, 5]) == 0.0)
					{
						mSG[DC_Main.i + 1, 5] = "";
					}
					mSG.Rows += 1;
					DC_Main.i++;
				}
				if (mSG.Rows > 2)
				{
					mSG.Rows -= 1;
				}
				mSG = null;
				EntryMode = "E";
			}
			else
			{
				EntryMode = "A";
				MSG[1, 0] = Conversions.ToString(1);
			}
			TotAmt();
			MSG.Col = 1;
			MSG.Row = MSG.Rows - 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.MsUpiAmt = 0.0;
		DC_Main.RsQry = "DELETE FROM UPI_DATA WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + CurUpiBook + "' AND VCH_NO = '" + CurUpiVchNo + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM UPI_DATA WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + CurUpiBook + "' AND VCH_NO = '" + CurUpiVchNo + "'";
		RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow = RsDetl.NewRow();
		checked
		{
			int num = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				if ((Operators.CompareString(MSG[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(MSG[DC_Main.i, 5]) != 0.0))
				{
					dataRow["CO_CODE"] = DC_Main.MCo_code;
					dataRow["LC_CODE"] = DC_Main.MLc_code;
					dataRow["CO_YEAR"] = DC_Main.MCo_year;
					dataRow["CO_BOOK"] = CurUpiBook;
					dataRow["VCH_NO"] = CurUpiVchNo;
					dataRow["SR_NO"] = DC_Main.i;
					dataRow["AC_CODE"] = tAcCode.Text;
					dataRow["VCH_DATE"] = mVchDate.Text;
					dataRow["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow["UPI_AC_CODE"] = MSG[DC_Main.i, 1];
					dataRow["UPI_AC_NAME"] = MSG[DC_Main.i, 2];
					dataRow["UPI_TYPE"] = MSG[DC_Main.i, 3];
					dataRow["UPI_ID"] = MSG[DC_Main.i, 4];
					dataRow["UPI_AMT"] = Conversion.Val(MSG[DC_Main.i, 5]);
					DC_Main.MsUpiAmt += Conversion.Val(MSG[DC_Main.i, 5]);
					DC_Main.MsUpiCurAcCode = tAcCode.Text;
					RsDetl.Rows.Add(dataRow);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
					RsDetl.Clear();
				}
				DC_Main.i++;
			}
			DC_Main.MsUpiFormOpen = "N";
			CLEAR_DATA();
			((Form)this).Close();
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		DC_Main.MsUpiFormOpen = "N";
		if (DC_Main.MsUpiAmt == 0.0)
		{
			DC_Main.MsUpiAmt = -5.0;
		}
		((Form)this).Close();
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void TR_UPI_REC_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_UPI_REC_KeyPress(object sender, KeyPressEventArgs e)
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

	private void TR_UPI_REC_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			if (((Control)TEXT_ENTRY).Visible)
			{
				((Control)BtnSave).Enabled = true;
				((Control)BtnSave).Focus();
			}
			else
			{
				((Form)this).Close();
			}
		}
	}

	private void TR_UPI_REC_KeyUp(object sender, KeyEventArgs e)
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

	private void MSG_TOT_Scroll(object sender, EventArgs e)
	{
	}

	private void MSG_RowColChange(object sender, EventArgs e)
	{
		if (MsgOldRow != MSG.Row)
		{
			MsgOldRow = MSG.Row;
		}
	}

	private void TEXT_ENTRY_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_ENTRY_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Invalid comparison between Unknown and I4
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Invalid comparison between Unknown and I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Invalid comparison between Unknown and I4
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Invalid comparison between Unknown and I4
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Invalid comparison between Unknown and I4
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Invalid comparison between Unknown and I4
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Invalid comparison between Unknown and I4
		//IL_0742: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f6: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == 112)
		{
			if (mSG.Col == 3)
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
					int num = mSG.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
					{
						mSG[mSG.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					TEXT_ENTRY.Text = "";
					TotAmt();
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG.Col > 1)
				{
					mSG.Col = checked(mSG.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				checked
				{
					if (mSG.Col < mSG.Cols - 1)
					{
						mSG.Col += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 38)
			{
				if (mSG.Row > 1)
				{
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
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + TEXT_ENTRY.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '19','22','23') ORDER BY A.LC_CODE,A.AC_NAME";
							}
							else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
							{
								DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND C.AC_GR in( '19','22','23') AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(A.AC_CODE AS INT) >=200 AND A.AC_GR in( '19','22','23') ORDER BY C.AC_NAME ";
							}
							else
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_GR in( '19','22','23') ORDER BY A.AC_NAME";
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
							return;
						}
						mSG[mSG.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CODE"], (object)""));
						mSG[mSG.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
						break;
					case 3:
					{
						DC_Main.RsQry = "SELECT UPI_TYPE As UpiTypeL  From UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND UPI_TYPE = '" + TEXT_ENTRY.Text + "' ORDER BY UPI_TYPE";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count != 0)
						{
							break;
						}
						int num2 = MSG.Rows - 1;
						for (int i = 1; i <= num2; i++)
						{
							if (Operators.CompareString(mSG[i, 3], TEXT_ENTRY.Text, false) == 0)
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
								TEXT_ENTRY.Text = DC_Main.ColValue[0];
							}
							return;
						}
						UpiTypeAdd = false;
						break;
					}
					case 4:
						if (Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0)
						{
							DC_Main.RsQry = "SELECT UPI_ID,CO_BOOK,VCH_NO FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND UPI_ID = '" + TEXT_ENTRY.Text + "'";
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Tbl.Rows.Count > 0)
							{
								Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This UpiId already Exist In Book No =  ", DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)" AND VchNo = "), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)" Please Change Upi Id ..."), (MsgBoxStyle)0, (object)null);
								((TextBoxBase)TEXT_ENTRY).SelectAll();
								return;
							}
						}
						break;
					case 5:
						if (Conversion.Val(TEXT_ENTRY.Text) != 0.0)
						{
							if (mSG.Row == mSG.Rows - 1)
							{
								mSG.Rows += 1;
								mSG.Row += 1;
								CommPassAdd();
								mSG.Col = 1;
							}
							else
							{
								mSG.Row += 1;
								mSG.Col = 1;
								((Control)TEXT_ENTRY).Visible = true;
								((Control)TEXT_ENTRY).Focus();
							}
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

	private void TR_UPI_REC_Closed(object sender, EventArgs e)
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
}
