using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class MS_PRODUCT : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPrCode")]
	private TextBox _tPrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPrName")]
	private TextBox _tPrName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Text1")]
	private TextBox _Text1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV;

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
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nSchmAmt")]
	private TextBox _nSchmAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nSchmMonth")]
	private TextBox _nSchmMonth;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboSchmType")]
	private ComboBox _cboSchmType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tHeading")]
	private TextBox _tHeading;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboforapp")]
	private ComboBox _cboforapp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nBonusMonth")]
	private TextBox _nBonusMonth;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnImgS")]
	private SimpleButton _BtnImgS;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnIp")]
	private SimpleButton _btnIp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboImgType")]
	private ComboBox _cboImgType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankAc")]
	private TextBox _tBankAc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnStkUpdate")]
	private SimpleButton _btnStkUpdate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnResetSchm")]
	private SimpleButton _btnResetSchm;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsMast;

	private double ColCon;

	private string CurDgvClear;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string CurMast;

	private bool FormLoad;

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
			CancelEventHandler cancelEventHandler = tPrCode_Validating;
			TextBox val2 = _tPrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).Validating -= cancelEventHandler;
			}
			_tPrCode = value;
			val2 = _tPrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).Validating += cancelEventHandler;
			}
		}
	}

	internal virtual TextBox tPrName
	{
		[CompilerGenerated]
		get
		{
			return _tPrName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPrName_KeyDown);
			CancelEventHandler cancelEventHandler = tPrName_Validating;
			TextBox val2 = _tPrName;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).Validating -= cancelEventHandler;
			}
			_tPrName = value;
			val2 = _tPrName;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).Validating += cancelEventHandler;
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

	public virtual TextBox Text1
	{
		[CompilerGenerated]
		get
		{
			return _Text1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Text1_TextChanged;
			EventHandler eventHandler2 = Text1_Click;
			TextBox val = _Text1;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
				((TextBoxBase)val).Click -= eventHandler2;
			}
			_Text1 = value;
			val = _Text1;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
				((TextBoxBase)val).Click += eventHandler2;
			}
		}
	}

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV
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
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(DGV_KeyDown);
			EventHandler eventHandler = DGV_DoubleClick;
			DevComponents.DotNetBar.Controls.DataGridViewX val2 = _DGV;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_DGV = value;
			val2 = _DGV;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).DoubleClick += eventHandler;
			}
		}
	}

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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = tAcCode_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tAcCode_KeyDown);
			TextBox val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tAcCode = value;
			val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
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
	[AccessedThroughProperty("LblAc")]
	private virtual Label _LblAc;

	internal virtual Label LblAc
	{
		get
		{
			return _LblAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LblAc = value;
		}
	}

	internal virtual TextBox nSchmAmt
	{
		[CompilerGenerated]
		get
		{
			return _nSchmAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nSchmAmt_KeyDown);
			TextBox val2 = _nSchmAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nSchmAmt = value;
			val2 = _nSchmAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LblAmt")]
	private virtual Label _LblAmt;

	internal virtual Label LblAmt
	{
		get
		{
			return _LblAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LblAmt = value;
		}
	}

	internal virtual TextBox nSchmMonth
	{
		[CompilerGenerated]
		get
		{
			return _nSchmMonth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nSchmMonth_KeyDown);
			TextBox val2 = _nSchmMonth;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nSchmMonth = value;
			val2 = _nSchmMonth;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblMonth")]
	private virtual Label _lblMonth;

	internal virtual Label lblMonth
	{
		get
		{
			return _lblMonth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblMonth = value;
		}
	}

	internal virtual ComboBox cboSchmType
	{
		[CompilerGenerated]
		get
		{
			return _cboSchmType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboSchmType_KeyDown);
			ComboBox val2 = _cboSchmType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboSchmType = value;
			val2 = _cboSchmType;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblSchmeType")]
	private virtual Label _lblSchmeType;

	internal virtual Label lblSchmeType
	{
		get
		{
			return _lblSchmeType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblSchmeType = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRemark")]
	private virtual TextBox _tRemark;

	internal virtual TextBox tRemark
	{
		get
		{
			return _tRemark;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tRemark = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblRemark")]
	private virtual Label _lblRemark;

	internal virtual Label lblRemark
	{
		get
		{
			return _lblRemark;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblRemark = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblheading")]
	private virtual Label _lblheading;

	internal virtual Label lblheading
	{
		get
		{
			return _lblheading;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblheading = value;
		}
	}

	internal virtual TextBox tHeading
	{
		[CompilerGenerated]
		get
		{
			return _tHeading;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tHeading_KeyDown);
			TextBox val2 = _tHeading;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tHeading = value;
			val2 = _tHeading;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual ComboBox cboforapp
	{
		[CompilerGenerated]
		get
		{
			return _cboforapp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboforapp_KeyDown);
			ComboBox val2 = _cboforapp;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboforapp = value;
			val2 = _cboforapp;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	internal virtual TextBox nBonusMonth
	{
		[CompilerGenerated]
		get
		{
			return _nBonusMonth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nBonusMonth_KeyDown);
			TextBox val2 = _nBonusMonth;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nBonusMonth = value;
			val2 = _nBonusMonth;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblBonusMonth")]
	private virtual Label _lblBonusMonth;

	internal virtual Label lblBonusMonth
	{
		get
		{
			return _lblBonusMonth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblBonusMonth = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicImage")]
	private virtual PictureBox _PicImage;

	internal virtual PictureBox PicImage
	{
		get
		{
			return _PicImage;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PicImage = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicZoom")]
	private virtual PictureBox _PicZoom;

	internal virtual PictureBox PicZoom
	{
		get
		{
			return _PicZoom;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PicZoom = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnImgD")]
	private virtual SimpleButton _BtnImgD;

	internal virtual SimpleButton BtnImgD
	{
		get
		{
			return _BtnImgD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnImgD = value;
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
	[AccessedThroughProperty("PanelAdd")]
	private virtual Panel _PanelAdd;

	internal virtual Panel PanelAdd
	{
		get
		{
			return _PanelAdd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PanelAdd = value;
		}
	}

	internal virtual SimpleButton btnIp
	{
		[CompilerGenerated]
		get
		{
			return _btnIp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnIp_Click;
			SimpleButton val = _btnIp;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnIp = value;
			val = _btnIp;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
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
	[AccessedThroughProperty("tPwd")]
	private virtual TextBox _tPwd;

	internal virtual TextBox tPwd
	{
		get
		{
			return _tPwd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tPwd = value;
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
	[AccessedThroughProperty("tDataBaseName")]
	private virtual TextBox _tDataBaseName;

	internal virtual TextBox tDataBaseName
	{
		get
		{
			return _tDataBaseName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tDataBaseName = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tServerIp")]
	private virtual TextBox _tServerIp;

	internal virtual TextBox tServerIp
	{
		get
		{
			return _tServerIp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tServerIp = value;
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

	internal virtual ComboBox cboImgType
	{
		[CompilerGenerated]
		get
		{
			return _cboImgType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = cboImgType_Click;
			EventHandler eventHandler2 = cboImgType_DropDownClosed;
			EventHandler eventHandler3 = cboImgType_SelectedValueChanged;
			ComboBox val = _cboImgType;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
				val.DropDownClosed -= eventHandler2;
				((ListControl)val).SelectedValueChanged -= eventHandler3;
			}
			_cboImgType = value;
			val = _cboImgType;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
				val.DropDownClosed += eventHandler2;
				((ListControl)val).SelectedValueChanged += eventHandler3;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblImgType")]
	private virtual Label _lblImgType;

	internal virtual Label lblImgType
	{
		get
		{
			return _lblImgType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblImgType = value;
		}
	}

	internal virtual TextBox tBankAc
	{
		[CompilerGenerated]
		get
		{
			return _tBankAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBankAc_KeyDown);
			EventHandler eventHandler = tBankAc_TextChanged;
			TextBox val2 = _tBankAc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tBankAc = value;
			val2 = _tBankAc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblbankAc")]
	private virtual Label _lblbankAc;

	internal virtual Label lblbankAc
	{
		get
		{
			return _lblbankAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblbankAc = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankName")]
	private virtual TextBox _tBankName;

	internal virtual TextBox tBankName
	{
		get
		{
			return _tBankName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tBankName = value;
		}
	}

	internal virtual SimpleButton btnStkUpdate
	{
		[CompilerGenerated]
		get
		{
			return _btnStkUpdate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnStkUpdate_Click;
			SimpleButton val = _btnStkUpdate;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnStkUpdate = value;
			val = _btnStkUpdate;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnResetSchm
	{
		[CompilerGenerated]
		get
		{
			return _btnResetSchm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnResetSchm_Click;
			SimpleButton val = _btnResetSchm;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnResetSchm = value;
			val = _btnResetSchm;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public MS_PRODUCT()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		((Form)this).Load += MS_PRODUCT_Load;
		((Form)this).Activated += MS_PRODUCT_Activated;
		((Form)this).Deactivate += UT_TASTING_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(UT_TASTING_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(MS_PRODUCT_KeyDown);
		((Form)this).Closed += MS_PRODUCT_Closed;
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
		//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Expected O, but got Unknown
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_055c: Expected O, but got Unknown
		//IL_05de: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e8: Expected O, but got Unknown
		//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bf: Expected O, but got Unknown
		//IL_071a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0724: Expected O, but got Unknown
		//IL_0865: Unknown result type (might be due to invalid IL or missing references)
		//IL_086f: Expected O, but got Unknown
		//IL_08d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dc: Expected O, but got Unknown
		//IL_094b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0955: Expected O, but got Unknown
		//IL_0a26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a30: Expected O, but got Unknown
		//IL_0b13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1d: Expected O, but got Unknown
		//IL_0b80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8a: Expected O, but got Unknown
		//IL_0bf9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c03: Expected O, but got Unknown
		//IL_0c66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c70: Expected O, but got Unknown
		//IL_0cdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce9: Expected O, but got Unknown
		//IL_0d4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d56: Expected O, but got Unknown
		//IL_0dc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dcf: Expected O, but got Unknown
		//IL_132d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1337: Expected O, but got Unknown
		//IL_13ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b5: Expected O, but got Unknown
		//IL_1545: Unknown result type (might be due to invalid IL or missing references)
		//IL_154f: Expected O, but got Unknown
		//IL_1634: Unknown result type (might be due to invalid IL or missing references)
		//IL_163e: Expected O, but got Unknown
		//IL_16e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f1: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_PRODUCT));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		lblBook = new Label();
		tPrCode = new TextBox();
		tPrName = new TextBox();
		Label2 = new Label();
		Label1 = new Label();
		Text1 = new TextBox();
		DGV = new DevComponents.DotNetBar.Controls.DataGridViewX();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		btnStkUpdate = new SimpleButton();
		btnResetSchm = new SimpleButton();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		LblAc = new Label();
		nSchmAmt = new TextBox();
		LblAmt = new Label();
		nSchmMonth = new TextBox();
		lblMonth = new Label();
		cboSchmType = new ComboBox();
		lblSchmeType = new Label();
		tRemark = new TextBox();
		lblRemark = new Label();
		lblheading = new Label();
		tHeading = new TextBox();
		cboforapp = new ComboBox();
		Label3 = new Label();
		nBonusMonth = new TextBox();
		lblBonusMonth = new Label();
		PicImage = new PictureBox();
		PicZoom = new PictureBox();
		BtnImgD = new SimpleButton();
		BtnImgS = new SimpleButton();
		DlgOpen = new OpenFileDialog();
		PanelAdd = new Panel();
		btnIp = new SimpleButton();
		Label13 = new Label();
		tPwd = new TextBox();
		Label9 = new Label();
		tDataBaseName = new TextBox();
		tServerIp = new TextBox();
		Label6 = new Label();
		cboImgType = new ComboBox();
		lblImgType = new Label();
		tBankAc = new TextBox();
		lblbankAc = new Label();
		tBankName = new TextBox();
		((ISupportInitialize)DGV).BeginInit();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((Control)PanelAdd).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		componentResourceManager.ApplyResources(lblBook, "lblBook");
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).ForeColor = Color.FromArgb(64, 0, 64);
		((Control)lblBook).Name = "lblBook";
		((TextBoxBase)tPrCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tPrCode, "tPrCode");
		((Control)tPrCode).Name = "tPrCode";
		((TextBoxBase)tPrName).BackColor = Color.White;
		componentResourceManager.ApplyResources(tPrName, "tPrName");
		((Control)tPrName).Name = "tPrName";
		componentResourceManager.ApplyResources(Label2, "Label2");
		((Control)Label2).ForeColor = Color.Black;
		((Control)Label2).Name = "Label2";
		componentResourceManager.ApplyResources(Label1, "Label1");
		((Control)Label1).ForeColor = Color.Black;
		((Control)Label1).Name = "Label1";
		Text1.AcceptsReturn = true;
		((TextBoxBase)Text1).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)Text1).BorderStyle = (BorderStyle)0;
		((Control)Text1).Cursor = Cursors.IBeam;
		componentResourceManager.ApplyResources(Text1, "Text1");
		((TextBoxBase)Text1).ForeColor = Color.Navy;
		((Control)Text1).Name = "Text1";
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
		componentResourceManager.ApplyResources(DGV, "DGV");
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
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val5;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((DataGridView)DGV).StandardTab = true;
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)btnStkUpdate);
		((Control)PnlBotam).Controls.Add((Control)(object)btnResetSchm);
		componentResourceManager.ApplyResources(PnlBotam, "PnlBotam");
		((Control)PnlBotam).Name = "PnlBotam";
		((BaseStyleControl)BtnExit).Appearance.Font = (Font)componentResourceManager.GetObject("BtnExit.Appearance.Font");
		((BaseStyleControl)BtnExit).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExit).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExit).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnExit.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExit.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnExit, "BtnExit");
		((BaseControl)BtnExit).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExit).Name = "BtnExit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnDelete).Appearance.Font = (Font)componentResourceManager.GetObject("BtnDelete.Appearance.Font");
		((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).SvgImage = Resources.actions_trash;
		componentResourceManager.ApplyResources(BtnDelete, "BtnDelete");
		((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDelete).Name = "BtnDelete";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = (Font)componentResourceManager.GetObject("BtnCancel.Appearance.Font");
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		componentResourceManager.ApplyResources(BtnCancel, "BtnCancel");
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnSave).Appearance.Font = (Font)componentResourceManager.GetObject("BtnSave.Appearance.Font");
		((BaseStyleControl)BtnSave).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSave).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSave.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSave.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnSave, "BtnSave");
		((BaseControl)BtnSave).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSave).Name = "BtnSave";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnPrint).Appearance.Font = (Font)componentResourceManager.GetObject("BtnPrint.Appearance.Font");
		((BaseStyleControl)BtnPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPrint.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnPrint, "BtnPrint");
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btnStkUpdate).Appearance.Font = (Font)componentResourceManager.GetObject("btnStkUpdate.Appearance.Font");
		((BaseStyleControl)btnStkUpdate).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnStkUpdate).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnStkUpdate).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnStkUpdate.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnStkUpdate.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(btnStkUpdate, "btnStkUpdate");
		((BaseControl)btnStkUpdate).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnStkUpdate).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnStkUpdate).Name = "btnStkUpdate";
		((BaseButton)btnStkUpdate).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btnResetSchm).Appearance.Font = (Font)componentResourceManager.GetObject("btnResetSchm.Appearance.Font");
		((BaseStyleControl)btnResetSchm).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnResetSchm).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnResetSchm).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnResetSchm.ImageOptions).SvgImage = Resources.recurrence;
		componentResourceManager.ApplyResources(btnResetSchm, "btnResetSchm");
		((BaseControl)btnResetSchm).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnResetSchm).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnResetSchm).Name = "btnResetSchm";
		((BaseButton)btnResetSchm).ToolTipAnchor = (ToolTipAnchor)1;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAcCode, "tAcCode");
		((Control)tAcCode).Name = "tAcCode";
		((TextBoxBase)tAcName).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAcName, "tAcName");
		((Control)tAcName).Name = "tAcName";
		((Control)LblAc).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(LblAc, "LblAc");
		((Control)LblAc).ForeColor = Color.Black;
		((Control)LblAc).Name = "LblAc";
		((TextBoxBase)nSchmAmt).BackColor = Color.White;
		componentResourceManager.ApplyResources(nSchmAmt, "nSchmAmt");
		((Control)nSchmAmt).Name = "nSchmAmt";
		((Control)LblAmt).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(LblAmt, "LblAmt");
		((Control)LblAmt).ForeColor = Color.Black;
		((Control)LblAmt).Name = "LblAmt";
		((TextBoxBase)nSchmMonth).BackColor = Color.White;
		componentResourceManager.ApplyResources(nSchmMonth, "nSchmMonth");
		((Control)nSchmMonth).Name = "nSchmMonth";
		((Control)lblMonth).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblMonth, "lblMonth");
		((Control)lblMonth).ForeColor = Color.Black;
		((Control)lblMonth).Name = "lblMonth";
		cboSchmType.AutoCompleteMode = (AutoCompleteMode)2;
		cboSchmType.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboSchmType, "cboSchmType");
		((ListControl)cboSchmType).FormattingEnabled = true;
		((Control)cboSchmType).Name = "cboSchmType";
		componentResourceManager.ApplyResources(lblSchmeType, "lblSchmeType");
		((Control)lblSchmeType).ForeColor = Color.Black;
		((Control)lblSchmeType).Name = "lblSchmeType";
		((TextBoxBase)tRemark).BackColor = Color.White;
		componentResourceManager.ApplyResources(tRemark, "tRemark");
		((Control)tRemark).Name = "tRemark";
		componentResourceManager.ApplyResources(lblRemark, "lblRemark");
		((Control)lblRemark).ForeColor = Color.Black;
		((Control)lblRemark).Name = "lblRemark";
		componentResourceManager.ApplyResources(lblheading, "lblheading");
		((Control)lblheading).ForeColor = Color.Black;
		((Control)lblheading).Name = "lblheading";
		((TextBoxBase)tHeading).BackColor = Color.White;
		componentResourceManager.ApplyResources(tHeading, "tHeading");
		((Control)tHeading).Name = "tHeading";
		cboforapp.AutoCompleteMode = (AutoCompleteMode)2;
		cboforapp.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboforapp, "cboforapp");
		((ListControl)cboforapp).FormattingEnabled = true;
		((Control)cboforapp).Name = "cboforapp";
		componentResourceManager.ApplyResources(Label3, "Label3");
		((Control)Label3).ForeColor = Color.Black;
		((Control)Label3).Name = "Label3";
		((TextBoxBase)nBonusMonth).BackColor = Color.White;
		componentResourceManager.ApplyResources(nBonusMonth, "nBonusMonth");
		((Control)nBonusMonth).Name = "nBonusMonth";
		((Control)lblBonusMonth).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblBonusMonth, "lblBonusMonth");
		((Control)lblBonusMonth).ForeColor = Color.Black;
		((Control)lblBonusMonth).Name = "lblBonusMonth";
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		componentResourceManager.ApplyResources(PicImage, "PicImage");
		((Control)PicImage).Name = "PicImage";
		PicImage.TabStop = false;
		((Control)PicZoom).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(PicZoom, "PicZoom");
		((Control)PicZoom).Name = "PicZoom";
		PicZoom.TabStop = false;
		BtnImgD.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgD.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgD.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnImgD, "BtnImgD");
		((BaseControl)BtnImgD).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgD).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgD).Name = "BtnImgD";
		BtnImgS.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgS.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgS.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnImgS, "BtnImgS");
		((BaseControl)BtnImgS).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgS).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgS).Name = "BtnImgS";
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((Control)PanelAdd).BackColor = Color.FromArgb(255, 224, 192);
		PanelAdd.BorderStyle = (BorderStyle)2;
		((Control)PanelAdd).Controls.Add((Control)(object)btnIp);
		((Control)PanelAdd).Controls.Add((Control)(object)Label13);
		((Control)PanelAdd).Controls.Add((Control)(object)tPwd);
		((Control)PanelAdd).Controls.Add((Control)(object)Label9);
		((Control)PanelAdd).Controls.Add((Control)(object)tDataBaseName);
		((Control)PanelAdd).Controls.Add((Control)(object)tServerIp);
		((Control)PanelAdd).Controls.Add((Control)(object)Label6);
		componentResourceManager.ApplyResources(PanelAdd, "PanelAdd");
		((Control)PanelAdd).Name = "PanelAdd";
		((BaseStyleControl)btnIp).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnIp).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnIp).Appearance.Font = (Font)componentResourceManager.GetObject("btnIp.Appearance.Font");
		((BaseStyleControl)btnIp).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnIp).Appearance.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("btnIp.Appearance.GradientMode"));
		((BaseStyleControl)btnIp).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnIp).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnIp).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnIp).Appearance.Options.UseForeColor = true;
		((BaseButton)btnIp).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnIp).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnIp).AppearanceHovered.Font = (Font)componentResourceManager.GetObject("btnIp.AppearanceHovered.Font");
		((BaseButton)btnIp).AppearanceHovered.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("btnIp.AppearanceHovered.GradientMode"));
		((BaseButton)btnIp).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnIp).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnIp).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnIp).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnIp).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnIp).AppearancePressed.Font = (Font)componentResourceManager.GetObject("btnIp.AppearancePressed.Font");
		((BaseButton)btnIp).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnIp).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnIp).AppearancePressed.Options.UseFont = true;
		componentResourceManager.ApplyResources(btnIp, "btnIp");
		((BaseControl)btnIp).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnIp).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnIp).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnIp).Name = "btnIp";
		((Control)Label13).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label13, "Label13");
		((Control)Label13).ForeColor = Color.Maroon;
		((Control)Label13).Name = "Label13";
		((TextBoxBase)tPwd).BackColor = Color.White;
		componentResourceManager.ApplyResources(tPwd, "tPwd");
		((TextBoxBase)tPwd).ForeColor = Color.Maroon;
		((Control)tPwd).Name = "tPwd";
		((Control)Label9).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label9, "Label9");
		((Control)Label9).ForeColor = Color.Maroon;
		((Control)Label9).Name = "Label9";
		((TextBoxBase)tDataBaseName).BackColor = Color.White;
		componentResourceManager.ApplyResources(tDataBaseName, "tDataBaseName");
		((TextBoxBase)tDataBaseName).ForeColor = Color.Maroon;
		((Control)tDataBaseName).Name = "tDataBaseName";
		((TextBoxBase)tServerIp).BackColor = Color.White;
		componentResourceManager.ApplyResources(tServerIp, "tServerIp");
		((TextBoxBase)tServerIp).ForeColor = Color.Maroon;
		((Control)tServerIp).Name = "tServerIp";
		((Control)Label6).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label6, "Label6");
		((Control)Label6).ForeColor = Color.Maroon;
		((Control)Label6).Name = "Label6";
		cboImgType.AutoCompleteMode = (AutoCompleteMode)2;
		cboImgType.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboImgType, "cboImgType");
		((ListControl)cboImgType).FormattingEnabled = true;
		((Control)cboImgType).Name = "cboImgType";
		componentResourceManager.ApplyResources(lblImgType, "lblImgType");
		((Control)lblImgType).ForeColor = Color.Black;
		((Control)lblImgType).Name = "lblImgType";
		((TextBoxBase)tBankAc).BackColor = Color.White;
		componentResourceManager.ApplyResources(tBankAc, "tBankAc");
		((Control)tBankAc).Name = "tBankAc";
		((Control)lblbankAc).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblbankAc, "lblbankAc");
		((Control)lblbankAc).ForeColor = Color.Black;
		((Control)lblbankAc).Name = "lblbankAc";
		((TextBoxBase)tBankName).BackColor = Color.White;
		componentResourceManager.ApplyResources(tBankName, "tBankName");
		((Control)tBankName).Name = "tBankName";
		componentResourceManager.ApplyResources(this, "$this");
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Control)this).Controls.Add((Control)(object)tBankName);
		((Control)this).Controls.Add((Control)(object)tBankAc);
		((Control)this).Controls.Add((Control)(object)lblbankAc);
		((Control)this).Controls.Add((Control)(object)lblImgType);
		((Control)this).Controls.Add((Control)(object)cboImgType);
		((Control)this).Controls.Add((Control)(object)PanelAdd);
		((Control)this).Controls.Add((Control)(object)PicZoom);
		((Control)this).Controls.Add((Control)(object)BtnImgD);
		((Control)this).Controls.Add((Control)(object)BtnImgS);
		((Control)this).Controls.Add((Control)(object)PicImage);
		((Control)this).Controls.Add((Control)(object)nBonusMonth);
		((Control)this).Controls.Add((Control)(object)lblBonusMonth);
		((Control)this).Controls.Add((Control)(object)cboforapp);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)tHeading);
		((Control)this).Controls.Add((Control)(object)lblheading);
		((Control)this).Controls.Add((Control)(object)lblRemark);
		((Control)this).Controls.Add((Control)(object)tRemark);
		((Control)this).Controls.Add((Control)(object)cboSchmType);
		((Control)this).Controls.Add((Control)(object)lblSchmeType);
		((Control)this).Controls.Add((Control)(object)nSchmMonth);
		((Control)this).Controls.Add((Control)(object)lblMonth);
		((Control)this).Controls.Add((Control)(object)nSchmAmt);
		((Control)this).Controls.Add((Control)(object)LblAmt);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)LblAc);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)Text1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tPrCode);
		((Control)this).Controls.Add((Control)(object)tPrName);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_PRODUCT";
		((ISupportInitialize)DGV).EndInit();
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((Control)PanelAdd).ResumeLayout(false);
		((Control)PanelAdd).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
	}

	private void MS_PRODUCT_Load(object sender, EventArgs e)
	{
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_079f: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a6: Expected O, but got Unknown
		//IL_080b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0810: Unknown result type (might be due to invalid IL or missing references)
		//IL_081a: Expected O, but got Unknown
		//IL_08a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b1: Expected O, but got Unknown
		//IL_0923: Unknown result type (might be due to invalid IL or missing references)
		//IL_0928: Unknown result type (might be due to invalid IL or missing references)
		//IL_092e: Expected O, but got Unknown
		//IL_09e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ef: Expected O, but got Unknown
		//IL_0a0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1d: Expected O, but got Unknown
		//IL_0a3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4b: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurMast = DC_Main.MsUserRightForm;
		lblBook.Text = CurMast;
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
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				Label obj2 = lblBook;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj2).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				Label obj4 = lblBook;
				object? obj5 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj4).ForeColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj6 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
				((DataGridView)DGV).BackgroundColor = Color.DarkGray;
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj8 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.SlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				object? obj9 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj10 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj11 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj12 = lblBook;
				object? obj13 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj12).ForeColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj14 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV2 = DGV;
				object? obj15 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj16 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tPrCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tPrCode).Font;
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
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV).RowTemplate.Height * (1.0 + num2));
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS300NUBU", false) == 0)
			{
				((Control)btnStkUpdate).Visible = false;
			}
			cboSchmType.Items.Add((object)"Amount");
			cboSchmType.Items.Add((object)"Gold");
			cboSchmType.Items.Add((object)"Silver");
			cboSchmType.SelectedIndex = 0;
			cboforapp.Items.Add((object)"No");
			cboforapp.Items.Add((object)"Yes");
			cboforapp.SelectedIndex = 0;
			cboImgType.Items.Add((object)"Scheme Img");
			cboImgType.Items.Add((object)"featured_1");
			cboImgType.Items.Add((object)"featured_2");
			cboImgType.Items.Add((object)"featured_3");
			cboImgType.Items.Add((object)"featured_4");
			cboImgType.Items.Add((object)"featured_5");
			cboImgType.Items.Add((object)"featured_6");
			cboImgType.SelectedIndex = 0;
			if (Operators.CompareString(CurMast, "Counter", false) == 0)
			{
				((TextBoxBase)tPrCode).MaxLength = 3;
				DC_Main.RsQry = "SELECT TABLE_CODE AS PR_CODE, TABLE_NAME AS PR_NAME FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY TABLE_CODE ";
			}
			else if (Operators.CompareString(CurMast, "Scheme Mast", false) == 0)
			{
				((TextBoxBase)tPrCode).MaxLength = 3;
				((TextBoxBase)tPrCode).ReadOnly = false;
				((Control)LblAc).Visible = true;
				((Control)tAcCode).Visible = true;
				((Control)tAcName).Visible = true;
				((Control)LblAmt).Visible = true;
				((Control)nSchmAmt).Visible = true;
				((Control)lblMonth).Visible = true;
				((Control)nSchmMonth).Visible = true;
				((Control)lblSchmeType).Visible = true;
				((Control)cboSchmType).Visible = true;
				((Control)lblBonusMonth).Visible = true;
				((Control)nBonusMonth).Visible = true;
				if (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0)
				{
					((Control)btnStkUpdate).Visible = true;
					((Control)lblheading).Visible = true;
					((Control)lblRemark).Visible = true;
					((Control)tHeading).Visible = true;
					((Control)tRemark).Visible = true;
					((Control)cboforapp).Visible = true;
					((Control)Label3).Visible = true;
					((Control)PicImage).Visible = true;
					((Control)BtnImgS).Visible = true;
					((Control)BtnImgD).Visible = true;
					((Control)lblImgType).Visible = true;
					((Control)cboImgType).Visible = true;
					((Control)tBankAc).Visible = true;
					((Control)lblbankAc).Visible = true;
					((Control)tBankName).Visible = true;
				}
				DC_Main.RsQry = "SELECT A.SCHM_CODE AS PR_CODE, A.SCHM_NAME AS PR_NAME,A.SCHM_AC,B.AC_NAME,A.SCHM_AMT,A.MAIN_USER,A.SCHM_MONTH,A.SCHM_TYPE,BONUS_MONTH,SCHM_HADING,SCHM_REMARK,SCHM_WITH_APP,BANK_AC FROM AD_MAST AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.SCHM_AC = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.SCHM_NAME ";
			}
			else
			{
				DC_Main.RsQry = "SELECT * FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY PR_CODE ";
			}
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DGV_FILL();
			FormLoad = true;
			EntryMode = "A";
			CurActCtrl = (Control)(object)tPrCode;
		}
	}

	private void MS_PRODUCT_Activated(object sender, EventArgs e)
	{
		if (DC_Main.MsCreat)
		{
			DC_Main.MsCreat = false;
			tAcCode.Text = DC_Main.MsCode;
			tAcName.Text = DC_Main.MsName;
			DC_Main.MsCode = "";
			DC_Main.MsName = "";
		}
		((ContainerControl)this).ActiveControl = CurActCtrl;
	}

	private void DGV_CLEAR()
	{
		((DataGridView)DGV).DataSource = null;
	}

	private void DGV_FILL()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		DGV_CLEAR();
		DataView dataView = new DataView(RsMast);
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
				((DataGridView)DGV).ColumnCount = 2;
				((DataGridView)DGV).Columns[0].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV).Columns[0].DataPropertyName = "PR_CODE";
				((DataGridView)DGV).Columns[0].HeaderText = "Code";
				((DataGridView)DGV).Columns[1].Width = (int)Math.Round(300.0 * ColCon);
				((DataGridView)DGV).Columns[1].DataPropertyName = "PR_NAME";
				((DataGridView)DGV).Columns[1].HeaderText = "Name";
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				((DataGridView)DGV).DataSource = dataView;
			}
		}
	}

	private void CLEAR_DATA()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		CurDgvClear = "N";
		foreach (Control control in ((Control)this).Controls)
		{
			Control val = control;
			if (val is TextBox)
			{
				val.Text = "";
			}
		}
		MainUser = DC_Main.MCo_User;
		CurDgvClear = "Y";
		Text1.Text = "SEARCH RECORD";
		DGV_CLEAR();
		DGV_FILL();
		if (Operators.CompareString(CurMast, "Counter", false) == 0)
		{
			((TextBoxBase)tPrCode).MaxLength = 3;
		}
		else if (Operators.CompareString(CurMast, "Scheme Mast", false) == 0)
		{
			cboSchmType.SelectedIndex = 0;
			cboforapp.SelectedIndex = 0;
			((TextBoxBase)tPrCode).MaxLength = 3;
			DC_Main.RsQry = "SELECT SCHM_CODE As CoCode From AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY CAST(SCHM_CODE AS INT) DESC ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				tPrCode.Text = "001";
			}
			else
			{
				tPrCode.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "000");
			}
		}
		else
		{
			((TextBoxBase)tPrCode).MaxLength = 2;
		}
		PicImage.Image = null;
		EntryMode = "A";
		((TextBoxBase)tPrCode).ReadOnly = false;
		((Control)tPrCode).Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void DISPLAY_DATA()
	{
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Expected O, but got Unknown
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " PR_CODE = '" + tPrCode.Text + "'";
		if (dataView.Count <= 0)
		{
			return;
		}
		DataView dataView2 = dataView;
		tPrCode.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["PR_CODE"], (object)""));
		tPrName.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["PR_NAME"], (object)""));
		if (Operators.CompareString(CurMast, "Scheme Mast", false) == 0)
		{
			tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["SCHM_AC"], (object)""));
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["AC_NAME"], (object)""));
			nSchmAmt.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["SCHM_AMT"], (object)""));
			nSchmMonth.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["SCHM_MONTH"], (object)""));
			if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView2[0]["SCHM_TYPE"], (object)""), (object)"S", false))
			{
				cboSchmType.SelectedIndex = 2;
			}
			else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView2[0]["SCHM_TYPE"], (object)""), (object)"G", false))
			{
				cboSchmType.SelectedIndex = 1;
			}
			else
			{
				cboSchmType.SelectedIndex = 0;
			}
			tHeading.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["SCHM_HADING"], (object)""));
			tRemark.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["SCHM_REMARK"], (object)""));
			cboforapp.SelectedIndex = Conversions.ToInteger(Interaction.IIf(Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView2[0]["SCHM_WITH_APP"], (object)""), (object)"Y", false), (object)1, (object)0));
			nBonusMonth.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["BONUS_MONTH"], (object)""));
			tBankAc.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["BANK_AC"], (object)""));
		}
		dataView2 = null;
		if ((Operators.CompareString(CurMast, "Scheme Mast", false) == 0) & (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0))
		{
			DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tBankAc.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				tBankName.Text = Conversions.ToString(DC_Main.Tbl.Rows[0]["AC_NAME"]);
			}
			DC_Main.MsImageNo = DC_Main.MCo_code + tPrCode.Text;
			DC_Main.MsImageType = "SchemeImg";
			DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
			if (Operators.CompareString(DC_Main.MsHttpPath, "", false) != 0)
			{
				try
				{
					string address = DC_Main.MsHttpPath + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg";
					PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
			else if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0 && Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
			{
				Image image;
				using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
				{
					image = Image.FromStream(stream);
				}
				PicImage.Image = image;
			}
		}
		EntryMode = "E";
		((TextBoxBase)tPrCode).ReadOnly = true;
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void UT_TASTING_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void UT_TASTING_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (((object)((ContainerControl)this).ActiveControl != tRemark) & ((object)((ContainerControl)this).ActiveControl != tHeading))
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
	}

	private void tPrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			((Control)Text1).Focus();
		}
		else if ((int)e.KeyCode == 13 && Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tPrCode_Validating(object sender, CancelEventArgs e)
	{
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		bool cancel = e.Cancel;
		if (RsMast.Rows.Count == 0)
		{
			return;
		}
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " PR_CODE = '" + tPrCode.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["PR_NAME"], (object)tPrName.Text, false))
			{
				if (Operators.CompareString(CurMast, "Counter", false) == 0)
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Scheme Code already Exist in  '", dataView[0]["PR_NAME"]), (object)"'  Scheme Name...Please Change Table Code..."), (MsgBoxStyle)0, (object)null);
				}
				else if (Operators.CompareString(CurMast, "Scheme Mast", false) == 0)
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Table Code already Exist in  '", dataView[0]["PR_NAME"]), (object)"'  Table Name...Please Change Scheme Code..."), (MsgBoxStyle)0, (object)null);
				}
				else
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Product Code already Exist in  '", dataView[0]["PR_NAME"]), (object)"'  Product Name...Please Change Pr Code..."), (MsgBoxStyle)0, (object)null);
				}
				cancel = true;
				((TextBoxBase)tPrCode).SelectAll();
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void tPrName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tPrName.Text, "", false) == 0)
		{
			if (Operators.CompareString(CurMast, "Counter", false) == 0)
			{
				Interaction.MsgBox((object)"Please Insert Table Name ...", (MsgBoxStyle)0, (object)null);
			}
			else if (Operators.CompareString(CurMast, "Scheme Mast", false) == 0)
			{
				Interaction.MsgBox((object)"Please Insert Scheme Name ...", (MsgBoxStyle)0, (object)null);
			}
			else
			{
				Interaction.MsgBox((object)"Please Insert Product Name ...", (MsgBoxStyle)0, (object)null);
			}
			((Control)tPrName).Focus();
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tPrName_Validating(object sender, CancelEventArgs e)
	{
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		bool cancel = e.Cancel;
		if (RsMast.Rows.Count == 0)
		{
			return;
		}
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " PR_NAME = '" + tPrName.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["PR_CODE"], (object)tPrCode.Text, false))
			{
				if (Operators.CompareString(CurMast, "Counter", false) == 0)
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Table Name already Exist in  '", dataView[0]["PR_CODE"]), (object)"'  Table Code...Please Change Table Name..."), (MsgBoxStyle)0, (object)null);
				}
				else if (Operators.CompareString(CurMast, "Scheme Mast", false) == 0)
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Scheme Name already Exist in  '", dataView[0]["PR_CODE"]), (object)"'  Scheme Code...Please Change Scheme Name..."), (MsgBoxStyle)0, (object)null);
				}
				else
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Product Name already Exist in  '", dataView[0]["PR_CODE"]), (object)"'  Product Code...Please Change Pr Name..."), (MsgBoxStyle)0, (object)null);
				}
				cancel = true;
				((TextBoxBase)tPrName).SelectAll();
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void Text1_TextChanged(object sender, EventArgs e)
	{
		if (((Operators.CompareString(Text1.Text, "", false) == 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0)) && Operators.CompareString(CurDgvClear, "N", false) != 0)
		{
			DGV_FILL();
		}
		else if ((Operators.CompareString(Text1.Text, "", false) != 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
		{
			DGV_CLEAR();
			DataView dataView = new DataView(RsMast);
			dataView.RowFilter = "PR_NAME Like  '" + Text1.Text + "%' ";
			if (dataView.Count > 0)
			{
				((DataGridView)DGV).AutoGenerateColumns = false;
				((DataGridView)DGV).Columns[0].Width = 80;
				((DataGridView)DGV).Columns[0].DataPropertyName = "PR_CODE";
				((DataGridView)DGV).Columns[1].Width = 320;
				((DataGridView)DGV).Columns[1].DataPropertyName = "PR_NAME";
				((DataGridView)DGV).DataSource = dataView;
			}
		}
	}

	private void MS_PRODUCT_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Invalid comparison between Unknown and I4
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
		if (((int)e.KeyCode == 38) | ((int)e.KeyCode == 40))
		{
			((Control)DGV).Focus();
		}
		if (((int)e.KeyCode == 112) & (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0))
		{
			DC_Main.RsQry = "SELECT * FROM BOOK_IDTL WHERE SR_NO = 150";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tServerIp.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_BOOK"], (object)""));
				tPwd.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SVR_PWD"], (object)""));
				tDataBaseName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
			}
			((Control)PanelAdd).Visible = true;
			((Control)tServerIp).Focus();
		}
	}

	private void Text1_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) == 0)
		{
			Text1.Text = "";
		}
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0625: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f3: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(tPrCode.Text, "", false) == 0)
		{
			if (Operators.CompareString(CurMast, "Counter", false) == 0)
			{
				Interaction.MsgBox((object)"Enter Table Code.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			}
			else if (Operators.CompareString(CurMast, "Scheme Mast", false) == 0)
			{
				Interaction.MsgBox((object)"Enter Scheme Code.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			}
			else
			{
				Interaction.MsgBox((object)"Enter Product Code.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			}
			((Control)tPrCode).Focus();
			return;
		}
		if (Operators.CompareString(tPrName.Text, "", false) == 0)
		{
			if (Operators.CompareString(CurMast, "Counter", false) == 0)
			{
				Interaction.MsgBox((object)"Enter Table Name.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			}
			else if (Operators.CompareString(CurMast, "Scheme Mast", false) == 0)
			{
				Interaction.MsgBox((object)"Enter Scheme Name.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			}
			else
			{
				Interaction.MsgBox((object)"Enter Product Name.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			}
			((Control)tPrName).Focus();
			return;
		}
		if (Operators.CompareString(CurMast, "Counter", false) == 0)
		{
			DC_Main.RsQry = "DELETE FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TABLE_CODE = '" + tPrCode.Text + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "INSERT INTO TABLE_MAST (CO_CODE,LC_CODE,TABLE_CODE,TABLE_NAME,MAIN_USER,DATA_TRFR) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + tPrCode.Text + "','" + tPrName.Text + "','" + MainUser + "','N')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
			DC_Main.RsQry = "SELECT TABLE_CODE As PR_CODE,TABLE_NAME AS PR_NAME,MAIN_USER FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY TABLE_CODE ";
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else if (Operators.CompareString(CurMast, "Scheme Mast", false) == 0)
		{
			DC_Main.RsQry = "DELETE FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  SCHM_CODE = '" + tPrCode.Text + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "INSERT INTO AD_MAST (CO_CODE,SCHM_CODE,SCHM_NAME,SCHM_AC,SCHM_AMT,MAIN_USER,SCHM_MONTH,DATA_TRFR,SCHM_TYPE,BONUS_MONTH,SCHM_HADING,SCHM_REMARK,SCHM_WITH_APP,BANK_AC) VALUES  ('" + DC_Main.MCo_code + "','" + tPrCode.Text + "','" + tPrName.Text + "','" + tAcCode.Text + "'," + Conversions.ToString(Conversion.Val(nSchmAmt.Text)) + ",'" + MainUser + "'," + Conversions.ToString(Conversion.Val(nSchmMonth.Text)) + ",'N','" + Strings.Mid(cboSchmType.Text, 1, 1) + "'," + Conversions.ToString(Conversion.Val(nBonusMonth.Text)) + ",'" + tHeading.Text + "','" + tRemark.Text + "','" + Strings.Mid(cboforapp.Text, 1, 1) + "','" + tBankAc.Text + "')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if ((Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0) & (cboforapp.SelectedIndex == 1))
			{
				AppSchemeTrfr();
			}
			Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
			DC_Main.RsQry = "SELECT A.SCHM_CODE AS PR_CODE, A.SCHM_NAME AS PR_NAME,A.SCHM_AC,B.AC_NAME,A.SCHM_AMT,A.MAIN_USER,A.SCHM_MONTH,SCHM_TYPE,BONUS_MONTH,SCHM_HADING,SCHM_REMARK,SCHM_WITH_APP,BANK_AC FROM AD_MAST AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.SCHM_AC = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.SCHM_NAME ";
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			if (Strings.Len(tPrCode.Text) == 1)
			{
				Interaction.MsgBox((object)"Please Insert Product Code 2 Digit...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
				return;
			}
			DC_Main.RsQry = "DELETE FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  PR_CODE = '" + tPrCode.Text + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "INSERT INTO PRODUCT_MAST (CO_CODE,PR_CODE,PR_NAME,MAIN_USER,DATA_TRFR) VALUES  ('" + DC_Main.MCo_code + "','" + tPrCode.Text + "','" + tPrName.Text + "','" + MainUser + "','N')";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
			DC_Main.RsQry = "SELECT * FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY PR_CODE ";
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		DGV_FILL();
	}

	private void AppSchemeTrfr()
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		DC_Main.RsQry = "SELECT * FROM BOOK_IDTL WHERE SR_NO = 150";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_BOOK"], (object)""));
			text2 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SVR_PWD"], (object)""));
			text3 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
			DC_Main.MsTrfrSvrMast = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CODE"], (object)""));
		}
		DC_Main.Scm.ConnectionString = ("Data Source=" + text + ";Initial Catalog=" + text3 + ";Persist Security Info=True;User ID=sa;Password=" + text2) ?? "";
		DC_Main.RsQry = "DELETE FROM CO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteScm(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM CO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			DataTable tbl = DC_Main.Tbl;
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO CO_MAST(CO_CODE,CO_NAME,LC_CODE,CO_SNAME,CO_ADD1,CO_ADD2,CO_ADD3,  CO_COUNTRY,CO_STATE_CODE,CO_STATE,CO_CITY,CO_PIN,CO_PHONE,CO_PHONE2,CO_MOBILE,CO_MOBILE2,CO_MAIL,  CO_JUD,CO_LSTNO,CO_CSTNO,CO_GST_NO,CO_PAN_NO,DHIRAN_NO,BANK_NAME,BANK_AREA,BANK_AC_NO,   CO_TYPE,ALTER_YEAR,CO_MSG,REP_ADD_TYPE,MAIN_USER,WORK_TYPE,METAL_TYPE,URL_NAME,URL_ID,URL_PWD,HTTP_NAME,MAIL_API)  VALUES('" + DC_Main.MCo_code + "','"), tbl.Rows[0]["CO_NAME"]), (object)"','"), tbl.Rows[0]["LC_CODE"]), (object)"','"), tbl.Rows[0]["CO_SNAME"]), (object)"','"), tbl.Rows[0]["CO_ADD1"]), (object)"','"), tbl.Rows[0]["CO_ADD2"]), (object)"','"), tbl.Rows[0]["CO_ADD3"]), (object)"', "), (object)" '"), tbl.Rows[0]["CO_COUNTRY"]), (object)"','"), tbl.Rows[0]["CO_STATE_CODE"]), (object)"','"), tbl.Rows[0]["CO_STATE"]), (object)"','"), tbl.Rows[0]["CO_CITY"]), (object)"','"), tbl.Rows[0]["CO_PIN"]), (object)"','"), tbl.Rows[0]["CO_PHONE"]), (object)"','"), tbl.Rows[0]["CO_PHONE2"]), (object)"','"), tbl.Rows[0]["CO_MOBILE"]), (object)"','"), tbl.Rows[0]["CO_MOBILE2"]), (object)"','"), tbl.Rows[0]["CO_MAIL"]), (object)"', "), (object)" '"), tbl.Rows[0]["CO_JUD"]), (object)"','"), tbl.Rows[0]["CO_LSTNO"]), (object)"','"), tbl.Rows[0]["CO_CSTNO"]), (object)"','"), tbl.Rows[0]["CO_GST_NO"]), (object)"','"), tbl.Rows[0]["CO_PAN_NO"]), (object)"','"), tbl.Rows[0]["DHIRAN_NO"]), (object)"','"), tbl.Rows[0]["BANK_NAME"]), (object)"','"), tbl.Rows[0]["BANK_AREA"]), (object)"','"), tbl.Rows[0]["BANK_AC_NO"]), (object)"', "), (object)" '"), tbl.Rows[0]["CO_TYPE"]), (object)"','"), tbl.Rows[0]["ALTER_YEAR"]), (object)"','"), tbl.Rows[0]["CO_MSG"]), (object)"','"), tbl.Rows[0]["REP_ADD_TYPE"]), (object)"','"), tbl.Rows[0]["MAIN_USER"]), (object)"','"), tbl.Rows[0]["WORK_TYPE"]), (object)"','"), tbl.Rows[0]["METAL_TYPE"]), (object)"','"), tbl.Rows[0]["URL_NAME"]), (object)"','"), tbl.Rows[0]["URL_ID"]), (object)"','"), tbl.Rows[0]["URL_PWD"]), (object)"','"), tbl.Rows[0]["HTTP_NAME"]), (object)"','"), tbl.Rows[0]["MAIL_API"]), (object)"')"));
			DC_Main.OpenRecordSetScm(DC_Main.RsQry);
			tbl = null;
		}
		DC_Main.RsQry = "DELETE FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '" + tPrCode.Text + "'";
		DC_Main.ExeQuteScm(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '" + tPrCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			DataTable tbl2 = DC_Main.Tbl;
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO AD_MAST(CO_CODE,SCHM_CODE,SCHM_NAME,SCHM_AMT,SCHM_AC,SCHM_TYPE,DATA_TRFR,  MAIN_USER,ADD_USER,BONUS_PRC,SCHM_MONTH,GOLD_RATE,BONUS_MONTH,SCHM_WITH_APP,SCHM_HADING,SCHM_REMARK,BANK_AC)  VALUES('" + DC_Main.MCo_code + "','"), tbl2.Rows[0]["SCHM_CODE"]), (object)"','"), tbl2.Rows[0]["SCHM_NAME"]), (object)"',"), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl2.Rows[0]["SCHM_AMT"]))), (object)",'"), tbl2.Rows[0]["SCHM_AC"]), (object)"','"), tbl2.Rows[0]["SCHM_TYPE"]), (object)"','N', "), (object)" '"), (object)DC_Main.MCo_User), (object)"','"), (object)DC_Main.MCo_User), (object)"',"), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl2.Rows[0]["BONUS_PRC"]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl2.Rows[0]["SCHM_MONTH"]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl2.Rows[0]["GOLD_RATE"]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl2.Rows[0]["BONUS_MONTH"]))), (object)",'"), tbl2.Rows[0]["SCHM_WITH_APP"]), (object)"','"), tbl2.Rows[0]["SCHM_HADING"]), (object)"','"), tbl2.Rows[0]["SCHM_REMARK"]), (object)"','"), tbl2.Rows[0]["BANK_AC"]), (object)"')"));
			DC_Main.OpenRecordSetScm(DC_Main.RsQry);
			tbl2 = null;
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Invalid comparison between Unknown and I4
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Invalid comparison between Unknown and I4
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Invalid comparison between Unknown and I4
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0530: Unknown result type (might be due to invalid IL or missing references)
		//IL_0586: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(tPrCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Product For Delete.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		}
		else if (Operators.CompareString(CurMast, "Counter", false) == 0)
		{
			if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Record now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
			{
				DC_Main.RsQry = "SELECT TBL_CODE FROM  MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TBL_CODE = '" + tPrCode.Text + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					Interaction.MsgBox((object)"You Cant Delete Record This Table in Main Stock Use in Transection....", (MsgBoxStyle)0, (object)null);
					return;
				}
				DC_Main.ExeQuteDc("DELETE FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TABLE_CODE = '" + tPrCode.Text + "'");
				Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
				CLEAR_DATA();
				DC_Main.RsQry = "SELECT TABLE_CODE AS PR_CODE,TABLE_NAME AS PR_NAME,MAIN_USER FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY TABLE_CODE ";
				RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DGV_FILL();
			}
		}
		else if (Operators.CompareString(CurMast, "Scheme Mast", false) == 0)
		{
			if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Record now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
			{
				DC_Main.RsQry = "SELECT * FROM  AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '" + tPrCode.Text + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					Interaction.MsgBox((object)"You Cant Delete Record This Scheme Use in Memb Master....", (MsgBoxStyle)0, (object)null);
					return;
				}
				DC_Main.ExeQuteDc("DELETE FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  SCHM_CODE = '" + tPrCode.Text + "'");
				Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
				CLEAR_DATA();
				DC_Main.RsQry = "SELECT A.SCHM_CODE AS PR_CODE, A.SCHM_NAME AS PR_NAME,A.SCHM_AC,B.AC_NAME,A.SCHM_AMT,A.MAIN_USER,A.SCHM_MONTH,A.SCHM_TYPE,BONUS_MONTH,SCHM_HADING,SCHM_REMARK,SCHM_WITH_APP,BANK_AC FROM AD_MAST AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.SCHM_AC = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.SCHM_NAME ";
				RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DGV_FILL();
			}
		}
		else
		{
			if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Record now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
			{
				return;
			}
			DC_Main.RsQry = "SELECT * FROM  ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + tPrCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				Interaction.MsgBox((object)"You Cant Delete Record This Product Use in Itme Master....", (MsgBoxStyle)0, (object)null);
				return;
			}
			switch (tPrCode.Text)
			{
			case "DM":
			case "EM":
			case "FN":
			case "HM":
			case "OG":
			case "OR":
			case "OS":
			case "OT":
			case "RD":
			case "SN":
				Interaction.MsgBox((object)"You Cant Delete Record, This Product Is Default Product....", (MsgBoxStyle)0, (object)null);
				return;
			}
			DC_Main.ExeQuteDc("DELETE FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  PR_CODE = '" + tPrCode.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
			DC_Main.RsQry = "SELECT * FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY PR_CODE ";
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DGV_FILL();
		}
	}

	private void DGV_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Invalid comparison between Unknown and I4
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
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
				case 327:
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
							goto IL_001b;
						case 6:
							goto IL_0034;
						case 7:
							goto IL_0046;
						case 8:
							goto IL_0074;
						case 9:
							goto IL_007d;
						case 11:
							goto IL_008f;
						case 12:
							goto IL_00a1;
						case 13:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 4:
						case 5:
						case 10:
						case 14:
						case 15:
						case 16:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_007d:
					num2 = 9;
					((Control)tPrName).Focus();
					goto end_IL_0001_3;
					IL_008f:
					num2 = 11;
					if ((int)e.KeyCode != 8)
					{
						goto end_IL_0001_3;
					}
					goto IL_00a1;
					IL_0074:
					num2 = 8;
					DISPLAY_DATA();
					goto IL_007d;
					IL_00a1:
					num2 = 12;
					if (Strings.Len(Text1.Text) <= 0)
					{
						goto end_IL_0001_3;
					}
					break;
					IL_000b:
					num2 = 2;
					if ((int)e.KeyCode == 112)
					{
						goto IL_001b;
					}
					goto IL_0034;
					IL_001b:
					num2 = 3;
					((Control)Text1).Focus();
					goto end_IL_0001_3;
					IL_0034:
					num2 = 6;
					if ((int)e.KeyCode == 13)
					{
						goto IL_0046;
					}
					goto IL_008f;
					IL_0046:
					num2 = 7;
					tPrCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
					goto IL_0074;
					end_IL_0001_2:
					break;
				}
				num2 = 13;
				Text1.Text = Strings.Mid(Text1.Text, 1, checked(Strings.Len(Text1.Text) - 1));
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 327;
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

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		tPrCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
		DISPLAY_DATA();
		((Control)tPrName).Focus();
	}

	private void MS_PRODUCT_Closed(object sender, EventArgs e)
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

	private void tAcCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "' AND AC_GR IN ('04','07')";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL, B.AC_GR_NAME AS GroupL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR IN ('04','07') ORDER BY A.AC_NAME";
			}
			else
			{
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL, B.AC_GR_NAME AS GroupL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_GR IN ('04','07') ORDER BY A.AC_NAME";
			}
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[4];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[2] = 250.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (DC_Main.HelpClose)
			{
				return;
			}
			if (DC_Main.MsCreat)
			{
				DC_Main.MsGrCode = "04";
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
		}
		else
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			SendKeys.Send("{tab}");
		}
	}

	private void nSchmAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nSchmAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nSchmAmt.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void nSchmMonth_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void cboSchmType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void nBonusMonth_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nBonusMonth.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nBonusMonth.Text)), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void cboforapp_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tHeading_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgS_Click(object sender, EventArgs e)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Invalid comparison between Unknown and I4
		((FileDialog)DlgOpen).Filter = "JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg";
		((FileDialog)DlgOpen).Title = "Open Image File";
		if ((int)((CommonDialog)DlgOpen).ShowDialog() != 1)
		{
			return;
		}
		switch (cboImgType.SelectedIndex)
		{
		case 0:
			DC_Main.MsImageNo = DC_Main.MCo_code + tPrCode.Text;
			break;
		case 1:
			DC_Main.MsImageNo = cboImgType.Text;
			break;
		case 2:
			DC_Main.MsImageNo = cboImgType.Text;
			break;
		case 3:
			DC_Main.MsImageNo = cboImgType.Text;
			break;
		case 4:
			DC_Main.MsImageNo = cboImgType.Text;
			break;
		case 5:
			DC_Main.MsImageNo = cboImgType.Text;
			break;
		case 6:
			DC_Main.MsImageNo = cboImgType.Text;
			break;
		}
		DC_Main.MsImageType = "SchemeImg";
		DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
		if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0 && Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
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
		PicImage.Image = Image.FromFile(((FileDialog)DlgOpen).FileName);
		PicImage.Image.Save(DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg");
		using (Stream stream2 = File.OpenRead(DC_Main.MsImagePath))
		{
			Image val = Image.FromStream(stream2);
		}
		if (Operators.CompareString(DC_Main.MsUrlPath, "", false) != 0)
		{
			string ftpuri = DC_Main.MsUrlPath + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg";
			Ac_Image.FtpUploadFile(DC_Main.MsImagePath, ftpuri, DC_Main.MsUrlId, DC_Main.MsUrlPwd);
		}
	}

	private void btnIp_Click(object sender, EventArgs e)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(tServerIp.Text, "", false) == 0) | (Operators.CompareString(tDataBaseName.Text, "", false) == 0) | (Operators.CompareString(tPwd.Text, "", false) == 0))
		{
			Interaction.MsgBox((object)"Please Fild Is Not Blank Alloud...", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.RsQry = "Select * FROM BOOK_IDTL WHERE SR_NO = 150";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			DC_Main.RsQry = "INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME,SVR_PWD)VALUES('" + tServerIp.Text + "',150,'O','','" + tDataBaseName.Text + "','" + tPwd.Text + "')";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Interaction.MsgBox((object)"Server Ip is Update....Ok..", (MsgBoxStyle)0, (object)null);
		}
		else
		{
			DC_Main.RsQry = "UPDATE BOOK_IDTL SET MAIN_BOOK = '" + tServerIp.Text + "',INOUT_TYPE = 'O',AC_CODE = '',AC_NAME = '" + tDataBaseName.Text + "' ,SVR_PWD = '" + tPwd.Text + "' WHERE SR_NO = 150";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Interaction.MsgBox((object)"Server Ip is Update....Ok..", (MsgBoxStyle)0, (object)null);
		}
	}

	private void cboImgType_Click(object sender, EventArgs e)
	{
	}

	private void cboImgType_DropDownClosed(object sender, EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void cboImgType_SelectedValueChanged(object sender, EventArgs e)
	{
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		if (!((Operators.CompareString(CurMast, "Scheme Mast", false) == 0) & (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0)) || !FormLoad)
		{
			return;
		}
		PicImage.Image = null;
		switch (cboImgType.SelectedIndex)
		{
		case 0:
			DC_Main.MsImageNo = DC_Main.MCo_code + tPrCode.Text;
			break;
		case 1:
			DC_Main.MsImageNo = cboImgType.Text;
			break;
		case 2:
			DC_Main.MsImageNo = cboImgType.Text;
			break;
		case 3:
			DC_Main.MsImageNo = cboImgType.Text;
			break;
		case 4:
			DC_Main.MsImageNo = cboImgType.Text;
			break;
		case 5:
			DC_Main.MsImageNo = cboImgType.Text;
			break;
		case 6:
			DC_Main.MsImageNo = cboImgType.Text;
			break;
		}
		if ((cboImgType.SelectedIndex == 0) & (Operators.CompareString(tPrCode.Text, "", false) == 0))
		{
			Interaction.MsgBox((object)"Please First Select Scheme Then try....", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.MsImageType = "SchemeImg";
		DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
		if (Operators.CompareString(DC_Main.MsHttpPath, "", false) != 0)
		{
			try
			{
				string address = DC_Main.MsHttpPath + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg";
				PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
				return;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
				return;
			}
		}
		if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0 && Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
		{
			Image image;
			using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
			{
				image = Image.FromStream(stream);
			}
			PicImage.Image = image;
		}
	}

	private void tBankAc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tBankAc.Text + "' AND AC_GR IN ('02','03','19','22','23')";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL, B.AC_GR_NAME AS GroupL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR IN ('02','03','19','22','23') ORDER BY A.AC_NAME";
			}
			else
			{
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL, B.AC_GR_NAME AS GroupL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_GR IN ('02','03','19','22','23') ORDER BY A.AC_NAME";
			}
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[4];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[2] = 250.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tBankAc.Text = DC_Main.ColValue[1];
					tBankName.Text = DC_Main.ColValue[0];
				}
				((Control)tBankAc).Focus();
			}
		}
		else
		{
			tBankName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void btnStkUpdate_Click(object sender, EventArgs e)
	{
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Expected O, but got Unknown
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Expected O, but got Unknown
		//IL_06fb: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		string text2 = "";
		string text3 = "";
		DC_Main.RsQry = "SELECT * FROM BOOK_IDTL WHERE SR_NO = 150";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_BOOK"], (object)""));
			text2 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SVR_PWD"], (object)""));
			text3 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
			DC_Main.MsTrfrSvrMast = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CODE"], (object)""));
		}
		DC_Main.Scm.ConnectionString = ("Data Source=" + text + ";Initial Catalog=" + text3 + ";Persist Security Info=True;User ID=sa;Password=" + text2) ?? "";
		DC_Main.RsQry = "DELETE FROM TAG_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
		DC_Main.ExeQuteScm(DC_Main.RsQry);
		DC_Main.RsQry = "WITH StockData AS (SELECT B.PR_CODE,C.CO_CODE,C.LC_CODE,A.TAG_NO, A.IT_CODE,C.DESIGN_NO,C.ITM_SIZE,B.IT_TYPE,B.GR_CODE,D.GR_NAME,E.PR_NAME,  C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,C.LBR_RATE, C.LBR_PRC,C.LBR_AMT, C.OTH_AMT,C.ITM_MRP,A.VCH_SRNO,C.STK_DATE,ROW_NUMBER() OVER (PARTITION BY B.PR_CODE, A.TAG_NO ORDER BY C.STK_DATE DESC) AS rnTag  FROM MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE  AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO AND A.IT_CODE = C.IT_CODE  LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  LEFT JOIN GROUP_MAST As D On A.IT_CODE = B.IT_CODE  LEFT JOIN PRODUCT_MAST As E  On B.CO_CODE = E.CO_CODE And B.PR_CODE = E.PR_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.TAG_NO <> 'N' AND B.APP_ITEM = 'Y'),DistinctTags AS  (SELECT *,ROW_NUMBER() OVER (PARTITION BY PR_CODE ORDER BY STK_DATE DESC, TAG_NO) AS rn  FROM StockData WHERE rnTag = 1),GroupCount As(Select COUNT(DISTINCT PR_CODE) As TotalGroups FROM DistinctTags),RowLimit As  (SELECT d.PR_CODE,CEILING(100 / g.TotalGroups) AS AllowedRows  FROM (SELECT DISTINCT PR_CODE FROM DistinctTags) d CROSS JOIN GroupCount g)  Select s.* FROM DistinctTags s JOIN RowLimit r On s.PR_CODE = r.PR_CODE WHERE s.rn <= r.AllowedRows  ORDER BY s.PR_CODE, s.STK_DATE DESC, s.TAG_NO";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.i = 0;
		Form val = new Form
		{
			Text = "Processing...",
			Size = new Size(500, 65),
			FormBorderStyle = (FormBorderStyle)3,
			StartPosition = (FormStartPosition)1,
			ControlBox = false
		};
		ProgressBar val2 = new ProgressBar
		{
			Dock = (DockStyle)5,
			Minimum = 0,
			Maximum = DC_Main.Tbl.Rows.Count,
			Value = 0
		};
		((Control)val).Controls.Add((Control)(object)val2);
		((Control)val).Show();
		checked
		{
			while (DC_Main.i < DC_Main.Tbl.Rows.Count)
			{
				DataTable tbl = DC_Main.Tbl;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO TAG_STOCK(CO_CODE,LC_CODE,TAG_NO,SR_NO,STK_TYPE,DESIGN_NO,ITM_SIZE,IT_TYPE,  GR_CODE,GR_NAME,PR_CODE,PR_NAME,GR_RATE,ITM_PCS,ITM_GWT,ITM_NWT,LBR_PRC,LBR_TYPE,  LBR_RATE,LBR_AMT,OTH_AMT,ITM_MRP,VCH_SRNO,DESIGN_IMG_ID,MAIN_USER)  VALUES('", tbl.Rows[DC_Main.i]["CO_CODE"]), (object)"','"), tbl.Rows[DC_Main.i]["LC_CODE"]), (object)"','"), tbl.Rows[DC_Main.i]["TAG_NO"]), (object)"','"), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl.Rows[DC_Main.i]["rn"])), "000")), (object)"','T','"), tbl.Rows[DC_Main.i]["DESIGN_NO"]), (object)"','"), tbl.Rows[DC_Main.i]["ITM_SIZE"]), (object)"','"), tbl.Rows[DC_Main.i]["IT_TYPE"]), (object)"', "), (object)" '"), tbl.Rows[DC_Main.i]["GR_CODE"]), (object)"','"), tbl.Rows[DC_Main.i]["GR_NAME"]), (object)"','"), tbl.Rows[DC_Main.i]["PR_CODE"]), (object)"','"), tbl.Rows[DC_Main.i]["PR_NAME"]), (object)"',0,"), tbl.Rows[DC_Main.i]["ITM_PCS"]), (object)","), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl.Rows[DC_Main.i]["ITM_GWT"])), "0.000")), (object)","), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl.Rows[DC_Main.i]["ITM_NWT"])), "0.000")), (object)","), tbl.Rows[DC_Main.i]["LBR_PRC"]), (object)",'G', "), (object)" "), tbl.Rows[DC_Main.i]["LBR_RATE"]), (object)","), tbl.Rows[DC_Main.i]["LBR_AMT"]), (object)","), tbl.Rows[DC_Main.i]["OTH_AMT"]), (object)","), tbl.Rows[DC_Main.i]["ITM_MRP"]), (object)","), tbl.Rows[DC_Main.i]["VCH_SRNO"]), (object)",'"), tbl.Rows[DC_Main.i]["TAG_NO"]), (object)"_"), tbl.Rows[DC_Main.i]["VCH_SRNO"]), (object)"','"), (object)DC_Main.MCo_User), (object)"')"));
				DC_Main.OpenRecordSetScm(DC_Main.RsQry);
				tbl = null;
				DC_Main.i++;
				val2.Value = DC_Main.i;
				Application.DoEvents();
			}
			val.Close();
			((Component)(object)val).Dispose();
			SchmFieldUpdate();
			ItemMastTrfr();
			Interaction.MsgBox((object)"Stock Is Transfer...", (MsgBoxStyle)0, (object)null);
		}
	}

	private void ItemMastTrfr()
	{
		DC_Main.RsQry = "DELETE FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ";
		DC_Main.ExeQuteScm(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY IT_CODE";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.i = 0;
		checked
		{
			while (DC_Main.i < DC_Main.Tbl.Rows.Count)
			{
				DataTable tbl = DC_Main.Tbl;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO ITEM_MAST(CO_CODE,IT_CODE,IT_NAME,IT_TYPE,PR_CODE,GR_CODE,RATE_TYPE,  LBR_PRC,IT_TOUCH,IT_WEST,OTH_RATE,IT_LBR_RATE,IT_GHT_PRC)  VALUES('", tbl.Rows[DC_Main.i]["CO_CODE"]), (object)"','"), tbl.Rows[DC_Main.i]["IT_CODE"]), (object)"','"), tbl.Rows[DC_Main.i]["IT_NAME"]), (object)"','"), tbl.Rows[DC_Main.i]["IT_TYPE"]), (object)"','"), tbl.Rows[DC_Main.i]["PR_CODE"]), (object)"','"), tbl.Rows[DC_Main.i]["GR_CODE"]), (object)"','"), tbl.Rows[DC_Main.i]["RATE_TYPE"]), (object)"', "), (object)" "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl.Rows[DC_Main.i]["LBR_PRC"]))), (object)","), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl.Rows[DC_Main.i]["IT_TOUCH"])), "0.000")), (object)","), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl.Rows[DC_Main.i]["IT_WEST"])), "0.000")), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl.Rows[DC_Main.i]["OTH_RATE"]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl.Rows[DC_Main.i]["IT_LBR_RATE"]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(tbl.Rows[DC_Main.i]["IT_GHT_PRC"]))), (object)")"));
				DC_Main.OpenRecordSetScm(DC_Main.RsQry);
				tbl = null;
				DC_Main.i++;
				Application.DoEvents();
			}
		}
	}

	private void SchmFieldUpdate()
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
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000b;
				case 87:
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
							goto IL_0018;
						case 4:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 5:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_000b:
					num2 = 2;
					DC_Main.ExeQuteScm("ALTER TABLE RATE_MAST ADD GR_TOUCH FLOAT NOT NULL DEFAULT 0");
					goto IL_0018;
					IL_0018:
					num2 = 3;
					DC_Main.RsQry = "CREATE TABLE ITEM_MAST(CO_CODE VARCHAR(2) Not NULL,IT_CODE VARCHAR(5) Not NULL,IT_NAME VARCHAR(50),IT_TYPE VARCHAR(1),PR_CODE VARCHAR(2),GR_CODE VARCHAR(3),RATE_TYPE VARCHAR(1),  LBR_PRC FLOAT NOT NULL DEFAULT 0,IT_TOUCH FLOAT NOT NULL DEFAULT 0,IT_WEST FLOAT NOT NULL DEFAULT 0,OTH_RATE FLOAT NOT NULL DEFAULT 0,IT_LBR_RATE FLOAT NOT NULL DEFAULT 0,IT_GHT_PRC FLOAT NOT NULL DEFAULT 0  PRIMARY KEY (CO_CODE,IT_CODE))";
					break;
					end_IL_0001_2:
					break;
				}
				num2 = 4;
				DC_Main.ExeQuteScm(DC_Main.RsQry);
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 87;
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

	private void btnResetSchm_Click(object sender, EventArgs e)
	{
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Invalid comparison between Unknown and I4
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.SSRegSrNo, "AB000NEAB", false) == 0)
		{
			string text = "";
			string text2 = "";
			string text3 = "";
			DC_Main.RsQry = "SELECT * FROM BOOK_IDTL WHERE SR_NO = 150";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_BOOK"], (object)""));
				text2 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SVR_PWD"], (object)""));
				text3 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
				DC_Main.MsTrfrSvrMast = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CODE"], (object)""));
			}
			DC_Main.Scm.ConnectionString = ("Data Source=" + text + ";Initial Catalog=" + text3 + ";Persist Security Info=True;User ID=sa;Password=" + text2) ?? "";
			if ((int)Interaction.MsgBox((object)"Are You Sure To Reset Curent Scheme Data?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
			{
				DC_Main.RsQry = "DELETE FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
				DC_Main.ExeQuteScm(DC_Main.RsQry);
				DC_Main.RsQry = "DELETE FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
				DC_Main.ExeQuteScm(DC_Main.RsQry);
				DC_Main.RsQry = "DELETE FROM APP_USER_DATA";
				DC_Main.ExeQuteScm(DC_Main.RsQry);
				DC_Main.RsQry = "DELETE FROM LIKE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
				DC_Main.ExeQuteScm(DC_Main.RsQry);
				DC_Main.RsQry = "DELETE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
				DC_Main.ExeQuteScm(DC_Main.RsQry);
				DC_Main.RsQry = "DELETE FROM DG_GOLD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
				DC_Main.ExeQuteScm(DC_Main.RsQry);
				DC_Main.RsQry = "DELETE FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "DELETE FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "DELETE FROM AD_OS WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "DELETE FROM AD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "DELETE FROM DG_GOLD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Interaction.MsgBox((object)"Reset..Is Complete...Please Stock Refresh...And AcRefresh...", (MsgBoxStyle)0, (object)null);
			}
		}
		else
		{
			Interaction.MsgBox((object)"This is Not Demo Software You Cant Reset...", (MsgBoxStyle)0, (object)null);
		}
	}

	private void PnlBotam_DoubleClick(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.SSRegSrNo, "AB000NEAB", false) == 0)
		{
			((Control)btnResetSchm).Visible = true;
		}
	}

	private void tBankAc_TextChanged(object sender, EventArgs e)
	{
	}
}
