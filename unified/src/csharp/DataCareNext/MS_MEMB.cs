using System;
using System.Collections;
using System.Collections.Generic;
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
using Crystal;
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
using QRCoder;

namespace DataCareNext;

[DesignerGenerated]
public class MS_MEMB : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Text1")]
	private TextBox _Text1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tdistrict")]
	private TextBox _tdistrict;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TState")]
	private TextBox _TState;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCountry")]
	private TextBox _tCountry;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRefAc")]
	private TextBox _tRefAc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankName")]
	private TextBox _tBankName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankArea")]
	private TextBox _tBankArea;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankAcNo")]
	private TextBox _tBankAcNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRtgsNo")]
	private TextBox _tRtgsNo;

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
	[AccessedThroughProperty("cboArea")]
	private ComboBox _cboArea;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboDistrict")]
	private ComboBox _cboDistrict;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCity")]
	private ComboBox _cboCity;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSchmCode")]
	private TextBox _tSchmCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmail")]
	private TextBox _tEmail;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPhone")]
	private TextBox _tPhone;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAddress3")]
	private TextBox _tAddress3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAddress2")]
	private TextBox _tAddress2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAddress1")]
	private TextBox _tAddress1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPinCode")]
	private TextBox _tPinCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicImage")]
	private PictureBox _PicImage;

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
	[AccessedThroughProperty("nGoldFine")]
	private TextBox _nGoldFine;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nMembAmt")]
	private TextBox _nMembAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnF1")]
	private SimpleButton _BtnF1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcName")]
	private TextBox _tAcName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tIdProof")]
	private TextBox _tIdProof;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMobile")]
	private TextBox _tMobile;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMobile2")]
	private TextBox _tMobile2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPhone2")]
	private TextBox _tPhone2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicZoom")]
	private PictureBox _PicZoom;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmpCode")]
	private TextBox _tEmpCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mAnDate")]
	private MaskedTextBox _mAnDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mBhDate")]
	private MaskedTextBox _mBhDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mExpDate")]
	private MaskedTextBox _mExpDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mJoinDate")]
	private MaskedTextBox _mJoinDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mBhlDate")]
	private MaskedTextBox _mBhlDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tNomini")]
	private TextBox _tNomini;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnMemb")]
	private SimpleButton _btnMemb;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnQr")]
	private SimpleButton _btnQr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnAcimp")]
	private SimpleButton _BtnAcimp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnAdd")]
	private SimpleButton _BtnAdd;

	private Queue<string> Q;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsMast;

	private double ColCon;

	private bool DletHoAc;

	private string CurPrnVch;

	private int CodLenth;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string OldScheme;

	private string OldSchmName;

	private double OldAmt;

	private int OldSchmMonth;

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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Pnl2")]
	private virtual Panel _Pnl2;

	internal virtual Panel Pnl2
	{
		get
		{
			return _Pnl2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Pnl2 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Pnl3")]
	private virtual Panel _Pnl3;

	internal virtual Panel Pnl3
	{
		get
		{
			return _Pnl3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Pnl3 = value;
		}
	}

	internal virtual TextBox tdistrict
	{
		[CompilerGenerated]
		get
		{
			return _tdistrict;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tJudrection_KeyDown);
			TextBox val2 = _tdistrict;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tdistrict = value;
			val2 = _tdistrict;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox TState
	{
		[CompilerGenerated]
		get
		{
			return _TState;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(TState_KeyDown);
			TextBox val2 = _TState;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_TState = value;
			val2 = _TState;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tCountry
	{
		[CompilerGenerated]
		get
		{
			return _tCountry;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tCountry_KeyDown);
			TextBox val2 = _tCountry;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tCountry = value;
			val2 = _tCountry;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRefAcName")]
	private virtual TextBox _tRefAcName;

	internal virtual TextBox tRefAcName
	{
		get
		{
			return _tRefAcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tRefAcName = value;
		}
	}

	internal virtual TextBox tRefAc
	{
		[CompilerGenerated]
		get
		{
			return _tRefAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tRefAc_KeyDown);
			TextBox val2 = _tRefAc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tRefAc = value;
			val2 = _tRefAc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox tBankArea
	{
		[CompilerGenerated]
		get
		{
			return _tBankArea;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBankArea_KeyDown);
			TextBox val2 = _tBankArea;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBankArea = value;
			val2 = _tBankArea;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tBankAcNo
	{
		[CompilerGenerated]
		get
		{
			return _tBankAcNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBankAcNo_KeyDown);
			TextBox val2 = _tBankAcNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBankAcNo = value;
			val2 = _tBankAcNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tRtgsNo
	{
		[CompilerGenerated]
		get
		{
			return _tRtgsNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tRtgsNo_KeyDown);
			TextBox val2 = _tRtgsNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tRtgsNo = value;
			val2 = _tRtgsNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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
	[AccessedThroughProperty("Pnl1")]
	private virtual Panel _Pnl1;

	internal virtual Panel Pnl1
	{
		get
		{
			return _Pnl1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Pnl1 = value;
		}
	}

	internal virtual ComboBox cboArea
	{
		[CompilerGenerated]
		get
		{
			return _cboArea;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboArea_KeyDown);
			ComboBox val2 = _cboArea;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboArea = value;
			val2 = _cboArea;
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

	internal virtual ComboBox cboDistrict
	{
		[CompilerGenerated]
		get
		{
			return _cboDistrict;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboDistrict_KeyDown);
			ComboBox val2 = _cboDistrict;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboDistrict = value;
			val2 = _cboDistrict;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual ComboBox cboCity
	{
		[CompilerGenerated]
		get
		{
			return _cboCity;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboCity_KeyDown);
			ComboBox val2 = _cboCity;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboCity = value;
			val2 = _cboCity;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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
			TextBox val2 = _tSchmCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tSchmCode = value;
			val2 = _tSchmCode;
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

	internal virtual TextBox tEmail
	{
		[CompilerGenerated]
		get
		{
			return _tEmail;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tEmail_KeyDown);
			TextBox val2 = _tEmail;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tEmail = value;
			val2 = _tEmail;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tPhone
	{
		[CompilerGenerated]
		get
		{
			return _tPhone;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPhone_KeyDown);
			TextBox val2 = _tPhone;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPhone = value;
			val2 = _tPhone;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tAddress3
	{
		[CompilerGenerated]
		get
		{
			return _tAddress3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAddress3_KeyDown);
			TextBox val2 = _tAddress3;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAddress3 = value;
			val2 = _tAddress3;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tAddress2
	{
		[CompilerGenerated]
		get
		{
			return _tAddress2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAddress2_KeyDown);
			TextBox val2 = _tAddress2;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAddress2 = value;
			val2 = _tAddress2;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tAddress1
	{
		[CompilerGenerated]
		get
		{
			return _tAddress1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAddress1_KeyDown);
			TextBox val2 = _tAddress1;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAddress1 = value;
			val2 = _tAddress1;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tPinCode
	{
		[CompilerGenerated]
		get
		{
			return _tPinCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPinCode_KeyDown);
			TextBox val2 = _tPinCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPinCode = value;
			val2 = _tPinCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblEmail")]
	private virtual Label _lblEmail;

	internal virtual Label lblEmail
	{
		get
		{
			return _lblEmail;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblEmail = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblPhone")]
	private virtual Label _lblPhone;

	internal virtual Label lblPhone
	{
		get
		{
			return _lblPhone;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblPhone = value;
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
	[AccessedThroughProperty("lblAdd3")]
	private virtual Label _lblAdd3;

	internal virtual Label lblAdd3
	{
		get
		{
			return _lblAdd3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAdd3 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblAdd2")]
	private virtual Label _lblAdd2;

	internal virtual Label lblAdd2
	{
		get
		{
			return _lblAdd2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAdd2 = value;
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
	[AccessedThroughProperty("lblBookCo")]
	private virtual Label _lblBookCo;

	internal virtual Label lblBookCo
	{
		get
		{
			return _lblBookCo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblBookCo = value;
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

	internal virtual TextBox nGoldFine
	{
		[CompilerGenerated]
		get
		{
			return _nGoldFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nGoldFine_KeyDown);
			TextBox val2 = _nGoldFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nGoldFine = value;
			val2 = _nGoldFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nMembAmt
	{
		[CompilerGenerated]
		get
		{
			return _nMembAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nMembAmt_KeyDown);
			TextBox val2 = _nMembAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nMembAmt = value;
			val2 = _nMembAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			EventHandler eventHandler = tAcName_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tAcName_KeyUp);
			CancelEventHandler cancelEventHandler = tAcName_Validating;
			KeyEventHandler val2 = new KeyEventHandler(tAcName_KeyDown);
			TextBox val3 = _tAcName;
			if (val3 != null)
			{
				((Control)val3).TextChanged -= eventHandler;
				((Control)val3).KeyUp -= val;
				((Control)val3).Validating -= cancelEventHandler;
				((Control)val3).KeyDown -= val2;
			}
			_tAcName = value;
			val3 = _tAcName;
			if (val3 != null)
			{
				((Control)val3).TextChanged += eventHandler;
				((Control)val3).KeyUp += val;
				((Control)val3).Validating += cancelEventHandler;
				((Control)val3).KeyDown += val2;
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
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAcCode_KeyDown);
			CancelEventHandler cancelEventHandler = tAcCode_Validating;
			TextBox val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).Validating -= cancelEventHandler;
			}
			_tAcCode = value;
			val2 = _tAcCode;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCustDetl")]
	private virtual TextBox _tCustDetl;

	public virtual TextBox tCustDetl
	{
		get
		{
			return _tCustDetl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tCustDetl = value;
		}
	}

	internal virtual TextBox tIdProof
	{
		[CompilerGenerated]
		get
		{
			return _tIdProof;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tIdProof_KeyDown);
			TextBox val2 = _tIdProof;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tIdProof = value;
			val2 = _tIdProof;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	internal virtual TextBox tMobile
	{
		[CompilerGenerated]
		get
		{
			return _tMobile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tmobile_KeyDown);
			TextBox val2 = _tMobile;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tMobile = value;
			val2 = _tMobile;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblMoNo")]
	private virtual Label _lblMoNo;

	internal virtual Label lblMoNo
	{
		get
		{
			return _lblMoNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblMoNo = value;
		}
	}

	internal virtual TextBox tMobile2
	{
		[CompilerGenerated]
		get
		{
			return _tMobile2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tMobile2_KeyDown);
			TextBox val2 = _tMobile2;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tMobile2 = value;
			val2 = _tMobile2;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	internal virtual TextBox tPhone2
	{
		[CompilerGenerated]
		get
		{
			return _tPhone2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPhone2_KeyDown);
			TextBox val2 = _tPhone2;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPhone2 = value;
			val2 = _tPhone2;
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = tEmpCode_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tEmpCode_KeyDown);
			TextBox val2 = _tEmpCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tEmpCode = value;
			val2 = _tEmpCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
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

	internal virtual MaskedTextBox mAnDate
	{
		[CompilerGenerated]
		get
		{
			return _mAnDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mAnDate_KeyDown);
			MaskedTextBox val2 = _mAnDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mAnDate = value;
			val2 = _mAnDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual MaskedTextBox mBhDate
	{
		[CompilerGenerated]
		get
		{
			return _mBhDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mBhDate_KeyDown);
			MaskedTextBox val2 = _mBhDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mBhDate = value;
			val2 = _mBhDate;
			if (val2 != null)
			{
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
	[AccessedThroughProperty("lblAnvDate")]
	private virtual Label _lblAnvDate;

	internal virtual Label lblAnvDate
	{
		get
		{
			return _lblAnvDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAnvDate = value;
		}
	}

	internal virtual MaskedTextBox mExpDate
	{
		[CompilerGenerated]
		get
		{
			return _mExpDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mExpDate_KeyDown);
			MaskedTextBox val2 = _mExpDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mExpDate = value;
			val2 = _mExpDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual MaskedTextBox mJoinDate
	{
		[CompilerGenerated]
		get
		{
			return _mJoinDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mJoinDate_KeyDown);
			MaskedTextBox val2 = _mJoinDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mJoinDate = value;
			val2 = _mJoinDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual MaskedTextBox mBhlDate
	{
		[CompilerGenerated]
		get
		{
			return _mBhlDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mBhlDate_KeyDown);
			MaskedTextBox val2 = _mBhlDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mBhlDate = value;
			val2 = _mBhlDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tNomini
	{
		[CompilerGenerated]
		get
		{
			return _tNomini;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tNomini_KeyDown);
			TextBox val2 = _tNomini;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tNomini = value;
			val2 = _tNomini;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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
	[AccessedThroughProperty("TabMenu")]
	private virtual SuperTabControl _TabMenu;

	internal virtual SuperTabControl TabMenu
	{
		get
		{
			return _TabMenu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TabMenu = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabPanel1")]
	private virtual SuperTabControlPanel _TabPanel1;

	internal virtual SuperTabControlPanel TabPanel1
	{
		get
		{
			return _TabPanel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TabPanel1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Tab1")]
	private virtual SuperTabItem _Tab1;

	internal virtual SuperTabItem Tab1
	{
		get
		{
			return _Tab1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Tab1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabPanel3")]
	private virtual SuperTabControlPanel _TabPanel3;

	internal virtual SuperTabControlPanel TabPanel3
	{
		get
		{
			return _TabPanel3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TabPanel3 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Tab3")]
	private virtual SuperTabItem _Tab3;

	internal virtual SuperTabItem Tab3
	{
		get
		{
			return _Tab3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Tab3 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabPanel2")]
	private virtual SuperTabControlPanel _TabPanel2;

	internal virtual SuperTabControlPanel TabPanel2
	{
		get
		{
			return _TabPanel2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TabPanel2 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Tab2")]
	private virtual SuperTabItem _Tab2;

	internal virtual SuperTabItem Tab2
	{
		get
		{
			return _Tab2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Tab2 = value;
		}
	}

	internal virtual SimpleButton btnMemb
	{
		[CompilerGenerated]
		get
		{
			return _btnMemb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnMemb_Click;
			SimpleButton val = _btnMemb;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnMemb = value;
			val = _btnMemb;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnQr
	{
		[CompilerGenerated]
		get
		{
			return _btnQr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnQr_Click;
			SimpleButton val = _btnQr;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnQr = value;
			val = _btnQr;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnAcimp
	{
		[CompilerGenerated]
		get
		{
			return _BtnAcimp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAcimp_Click;
			SimpleButton val = _BtnAcimp;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnAcimp = value;
			val = _BtnAcimp;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnAdd
	{
		[CompilerGenerated]
		get
		{
			return _BtnAdd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAdd_Click;
			SimpleButton val = _BtnAdd;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnAdd = value;
			val = _BtnAdd;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public int newindex { get; set; }

	public MS_MEMB()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		((Form)this).Load += MS_MEMB_Load;
		((Form)this).Activated += MS_MEMB_Activated;
		((Form)this).Deactivate += MS_MEMB_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_MEMB_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(MS_MEMB_KeyDown);
		((Form)this).Closed += MS_MEMB_Closed;
		Q = new Queue<string>();
		DletHoAc = false;
		CodLenth = 3;
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
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Expected O, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Expected O, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected O, but got Unknown
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Expected O, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Expected O, but got Unknown
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Expected O, but got Unknown
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Expected O, but got Unknown
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected O, but got Unknown
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Expected O, but got Unknown
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Expected O, but got Unknown
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Expected O, but got Unknown
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Expected O, but got Unknown
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Expected O, but got Unknown
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Expected O, but got Unknown
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Expected O, but got Unknown
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Expected O, but got Unknown
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Expected O, but got Unknown
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Expected O, but got Unknown
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Expected O, but got Unknown
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Expected O, but got Unknown
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Expected O, but got Unknown
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Expected O, but got Unknown
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Expected O, but got Unknown
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Expected O, but got Unknown
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Expected O, but got Unknown
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Expected O, but got Unknown
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Expected O, but got Unknown
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Expected O, but got Unknown
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Expected O, but got Unknown
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Expected O, but got Unknown
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Expected O, but got Unknown
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Expected O, but got Unknown
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Expected O, but got Unknown
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0498: Expected O, but got Unknown
		//IL_049a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a4: Expected O, but got Unknown
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b0: Expected O, but got Unknown
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Expected O, but got Unknown
		//IL_04be: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c8: Expected O, but got Unknown
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Expected O, but got Unknown
		//IL_0d25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2f: Expected O, but got Unknown
		//IL_0e14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e1e: Expected O, but got Unknown
		//IL_0ec7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed1: Expected O, but got Unknown
		//IL_0fb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc0: Expected O, but got Unknown
		//IL_10a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10af: Expected O, but got Unknown
		//IL_1158: Unknown result type (might be due to invalid IL or missing references)
		//IL_1162: Expected O, but got Unknown
		//IL_163c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1646: Expected O, but got Unknown
		//IL_172b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1735: Expected O, but got Unknown
		//IL_17de: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e8: Expected O, but got Unknown
		//IL_2745: Unknown result type (might be due to invalid IL or missing references)
		//IL_274f: Expected O, but got Unknown
		//IL_27b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_27bc: Expected O, but got Unknown
		//IL_282b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2835: Expected O, but got Unknown
		//IL_2906: Unknown result type (might be due to invalid IL or missing references)
		//IL_2910: Expected O, but got Unknown
		//IL_29f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_29fd: Expected O, but got Unknown
		//IL_2a60: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a6a: Expected O, but got Unknown
		//IL_2ad9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ae3: Expected O, but got Unknown
		//IL_2b46: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b50: Expected O, but got Unknown
		//IL_2bbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bc9: Expected O, but got Unknown
		//IL_2c2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c36: Expected O, but got Unknown
		//IL_2d05: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d0f: Expected O, but got Unknown
		//IL_2d83: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d8d: Expected O, but got Unknown
		//IL_2e01: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e0b: Expected O, but got Unknown
		//IL_2f19: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f23: Expected O, but got Unknown
		//IL_2fb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fc2: Expected O, but got Unknown
		//IL_3044: Unknown result type (might be due to invalid IL or missing references)
		//IL_304e: Expected O, but got Unknown
		//IL_311b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3125: Expected O, but got Unknown
		//IL_3180: Unknown result type (might be due to invalid IL or missing references)
		//IL_318a: Expected O, but got Unknown
		//IL_3285: Unknown result type (might be due to invalid IL or missing references)
		//IL_328f: Expected O, but got Unknown
		//IL_32d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_32dc: Expected O, but got Unknown
		//IL_33c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_33cb: Expected O, but got Unknown
		//IL_3474: Unknown result type (might be due to invalid IL or missing references)
		//IL_347e: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_MEMB));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		lblBook = new Label();
		Text1 = new TextBox();
		TabMenu = new SuperTabControl();
		TabPanel1 = new SuperTabControlPanel();
		Pnl1 = new Panel();
		BtnAcimp = new SimpleButton();
		btnMemb = new SimpleButton();
		tNomini = new TextBox();
		mExpDate = new MaskedTextBox();
		mJoinDate = new MaskedTextBox();
		Label16 = new Label();
		Label18 = new Label();
		mBhlDate = new MaskedTextBox();
		tEmpName = new TextBox();
		tEmpCode = new TextBox();
		Label8 = new Label();
		Label4 = new Label();
		mAnDate = new MaskedTextBox();
		mBhDate = new MaskedTextBox();
		lblBDate = new Label();
		lblAnvDate = new Label();
		tIdProof = new TextBox();
		Label9 = new Label();
		tMobile = new TextBox();
		nGoldFine = new TextBox();
		lblMoNo = new Label();
		BtnF1 = new SimpleButton();
		Label19 = new Label();
		nMembAmt = new TextBox();
		Label10 = new Label();
		cboArea = new ComboBox();
		Label17 = new Label();
		cboDistrict = new ComboBox();
		tSchmName = new TextBox();
		Label15 = new Label();
		cboCity = new ComboBox();
		tSchmCode = new TextBox();
		lblBookCo = new Label();
		lblCity = new Label();
		Label7 = new Label();
		tPinCode = new TextBox();
		Label3 = new Label();
		tEmail = new TextBox();
		tPhone = new TextBox();
		tAddress3 = new TextBox();
		tAddress2 = new TextBox();
		tAddress1 = new TextBox();
		lblEmail = new Label();
		lblPhone = new Label();
		lblAdd3 = new Label();
		lblAdd2 = new Label();
		lblAdd1 = new Label();
		tAcName = new TextBox();
		tAcCode = new TextBox();
		Label2 = new Label();
		Label1 = new Label();
		Tab1 = new SuperTabItem();
		TabPanel2 = new SuperTabControlPanel();
		Pnl2 = new Panel();
		tMobile2 = new TextBox();
		Label6 = new Label();
		tPhone2 = new TextBox();
		Label5 = new Label();
		tRtgsNo = new TextBox();
		tBankAcNo = new TextBox();
		tBankArea = new TextBox();
		tBankName = new TextBox();
		Label11 = new Label();
		Label12 = new Label();
		Label13 = new Label();
		Label14 = new Label();
		tRefAcName = new TextBox();
		tRefAc = new TextBox();
		Label20 = new Label();
		Tab2 = new SuperTabItem();
		TabPanel3 = new SuperTabControlPanel();
		Pnl3 = new Panel();
		Tab3 = new SuperTabItem();
		tdistrict = new TextBox();
		TState = new TextBox();
		tCountry = new TextBox();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		btnQr = new SimpleButton();
		PicImage = new PictureBox();
		BtnImgC = new SimpleButton();
		BtnImgS = new SimpleButton();
		BtnImgD = new SimpleButton();
		tCustDetl = new TextBox();
		DlgOpen = new OpenFileDialog();
		DGV = new DevComponents.DotNetBar.Controls.DataGridViewX();
		PicZoom = new PictureBox();
		PictureBox1 = new PictureBox();
		Cr = new AxCrystalReport();
		BtnAdd = new SimpleButton();
		((ISupportInitialize)TabMenu).BeginInit();
		((Control)TabMenu).SuspendLayout();
		((Control)TabPanel1).SuspendLayout();
		((Control)Pnl1).SuspendLayout();
		((Control)TabPanel2).SuspendLayout();
		((Control)Pnl2).SuspendLayout();
		((Control)TabPanel3).SuspendLayout();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)PictureBox1).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((Control)this).SuspendLayout();
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		componentResourceManager.ApplyResources(lblBook, "lblBook");
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).ForeColor = Color.FromArgb(64, 0, 64);
		((Control)lblBook).Name = "lblBook";
		Text1.AcceptsReturn = true;
		((TextBoxBase)Text1).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)Text1).BorderStyle = (BorderStyle)0;
		((Control)Text1).Cursor = Cursors.IBeam;
		componentResourceManager.ApplyResources(Text1, "Text1");
		((TextBoxBase)Text1).ForeColor = Color.Navy;
		((Control)Text1).Name = "Text1";
		((BaseItem)TabMenu.ControlBox.CloseBox).Name = "";
		((BaseItem)TabMenu.ControlBox.MenuBox).Name = "";
		((BaseItem)TabMenu.ControlBox).Name = "";
		((BaseItem)TabMenu.ControlBox).SubItems.AddRange((BaseItem[])(object)new BaseItem[2]
		{
			(BaseItem)TabMenu.ControlBox.MenuBox,
			(BaseItem)TabMenu.ControlBox.CloseBox
		});
		((Control)TabMenu).Controls.Add((Control)(object)TabPanel1);
		((Control)TabMenu).Controls.Add((Control)(object)TabPanel2);
		((Control)TabMenu).Controls.Add((Control)(object)TabPanel3);
		componentResourceManager.ApplyResources(TabMenu, "TabMenu");
		((Control)TabMenu).Name = "TabMenu";
		TabMenu.ReorderTabsEnabled = true;
		TabMenu.SelectedTabIndex = 0;
		TabMenu.TabAlignment = (eTabStripAlignment)3;
		TabMenu.TabLayoutType = (eSuperTabLayoutType)1;
		TabMenu.Tabs.AddRange((BaseItem[])(object)new BaseItem[3]
		{
			(BaseItem)Tab1,
			(BaseItem)Tab2,
			(BaseItem)Tab3
		});
		TabMenu.TabStyle = (eSuperTabStyle)1;
		((PanelControl)TabPanel1).CanvasColor = Color.Black;
		((Control)TabPanel1).Controls.Add((Control)(object)Pnl1);
		componentResourceManager.ApplyResources(TabPanel1, "TabPanel1");
		((Control)TabPanel1).Name = "TabPanel1";
		TabPanel1.TabItem = Tab1;
		((Control)Pnl1).Controls.Add((Control)(object)BtnAdd);
		((Control)Pnl1).Controls.Add((Control)(object)BtnAcimp);
		((Control)Pnl1).Controls.Add((Control)(object)btnMemb);
		((Control)Pnl1).Controls.Add((Control)(object)tNomini);
		((Control)Pnl1).Controls.Add((Control)(object)mExpDate);
		((Control)Pnl1).Controls.Add((Control)(object)mJoinDate);
		((Control)Pnl1).Controls.Add((Control)(object)Label16);
		((Control)Pnl1).Controls.Add((Control)(object)Label18);
		((Control)Pnl1).Controls.Add((Control)(object)mBhlDate);
		((Control)Pnl1).Controls.Add((Control)(object)tEmpName);
		((Control)Pnl1).Controls.Add((Control)(object)tEmpCode);
		((Control)Pnl1).Controls.Add((Control)(object)Label8);
		((Control)Pnl1).Controls.Add((Control)(object)Label4);
		((Control)Pnl1).Controls.Add((Control)(object)mAnDate);
		((Control)Pnl1).Controls.Add((Control)(object)mBhDate);
		((Control)Pnl1).Controls.Add((Control)(object)lblBDate);
		((Control)Pnl1).Controls.Add((Control)(object)lblAnvDate);
		((Control)Pnl1).Controls.Add((Control)(object)tIdProof);
		((Control)Pnl1).Controls.Add((Control)(object)Label9);
		((Control)Pnl1).Controls.Add((Control)(object)tMobile);
		((Control)Pnl1).Controls.Add((Control)(object)nGoldFine);
		((Control)Pnl1).Controls.Add((Control)(object)lblMoNo);
		((Control)Pnl1).Controls.Add((Control)(object)BtnF1);
		((Control)Pnl1).Controls.Add((Control)(object)Label19);
		((Control)Pnl1).Controls.Add((Control)(object)nMembAmt);
		((Control)Pnl1).Controls.Add((Control)(object)Label10);
		((Control)Pnl1).Controls.Add((Control)(object)cboArea);
		((Control)Pnl1).Controls.Add((Control)(object)Label17);
		((Control)Pnl1).Controls.Add((Control)(object)cboDistrict);
		((Control)Pnl1).Controls.Add((Control)(object)tSchmName);
		((Control)Pnl1).Controls.Add((Control)(object)Label15);
		((Control)Pnl1).Controls.Add((Control)(object)cboCity);
		((Control)Pnl1).Controls.Add((Control)(object)tSchmCode);
		((Control)Pnl1).Controls.Add((Control)(object)lblBookCo);
		((Control)Pnl1).Controls.Add((Control)(object)lblCity);
		((Control)Pnl1).Controls.Add((Control)(object)Label7);
		((Control)Pnl1).Controls.Add((Control)(object)tPinCode);
		((Control)Pnl1).Controls.Add((Control)(object)Label3);
		((Control)Pnl1).Controls.Add((Control)(object)tEmail);
		((Control)Pnl1).Controls.Add((Control)(object)tPhone);
		((Control)Pnl1).Controls.Add((Control)(object)tAddress3);
		((Control)Pnl1).Controls.Add((Control)(object)tAddress2);
		((Control)Pnl1).Controls.Add((Control)(object)tAddress1);
		((Control)Pnl1).Controls.Add((Control)(object)lblEmail);
		((Control)Pnl1).Controls.Add((Control)(object)lblPhone);
		((Control)Pnl1).Controls.Add((Control)(object)lblAdd3);
		((Control)Pnl1).Controls.Add((Control)(object)lblAdd2);
		((Control)Pnl1).Controls.Add((Control)(object)lblAdd1);
		((Control)Pnl1).Controls.Add((Control)(object)tAcName);
		((Control)Pnl1).Controls.Add((Control)(object)tAcCode);
		((Control)Pnl1).Controls.Add((Control)(object)Label2);
		((Control)Pnl1).Controls.Add((Control)(object)Label1);
		componentResourceManager.ApplyResources(Pnl1, "Pnl1");
		((Control)Pnl1).Name = "Pnl1";
		((BaseStyleControl)BtnAcimp).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnAcimp).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnAcimp).Appearance.Font = (Font)componentResourceManager.GetObject("BtnAcimp.Appearance.Font");
		((BaseStyleControl)BtnAcimp).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnAcimp).Appearance.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("BtnAcimp.Appearance.GradientMode"));
		((BaseStyleControl)BtnAcimp).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnAcimp).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnAcimp).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnAcimp).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnAcimp).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnAcimp).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnAcimp).AppearanceHovered.Font = (Font)componentResourceManager.GetObject("BtnAcimp.AppearanceHovered.Font");
		((BaseButton)BtnAcimp).AppearanceHovered.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("BtnAcimp.AppearanceHovered.GradientMode"));
		((BaseButton)BtnAcimp).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnAcimp).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnAcimp).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnAcimp).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnAcimp).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnAcimp).AppearancePressed.Font = (Font)componentResourceManager.GetObject("BtnAcimp.AppearancePressed.Font");
		((BaseButton)BtnAcimp).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnAcimp).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnAcimp).AppearancePressed.Options.UseFont = true;
		componentResourceManager.ApplyResources(BtnAcimp, "BtnAcimp");
		((BaseControl)BtnAcimp).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnAcimp).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnAcimp).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnAcimp).Name = "BtnAcimp";
		((BaseStyleControl)btnMemb).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnMemb).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnMemb).Appearance.Font = (Font)componentResourceManager.GetObject("btnMemb.Appearance.Font");
		((BaseStyleControl)btnMemb).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnMemb).Appearance.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("btnMemb.Appearance.GradientMode"));
		((BaseStyleControl)btnMemb).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnMemb).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnMemb).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnMemb).Appearance.Options.UseForeColor = true;
		((BaseButton)btnMemb).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnMemb).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnMemb).AppearanceHovered.Font = (Font)componentResourceManager.GetObject("btnMemb.AppearanceHovered.Font");
		((BaseButton)btnMemb).AppearanceHovered.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("btnMemb.AppearanceHovered.GradientMode"));
		((BaseButton)btnMemb).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnMemb).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnMemb).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnMemb).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnMemb).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnMemb).AppearancePressed.Font = (Font)componentResourceManager.GetObject("btnMemb.AppearancePressed.Font");
		((BaseButton)btnMemb).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnMemb).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnMemb).AppearancePressed.Options.UseFont = true;
		componentResourceManager.ApplyResources(btnMemb, "btnMemb");
		((BaseControl)btnMemb).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnMemb).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnMemb).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnMemb).Name = "btnMemb";
		((TextBoxBase)tNomini).BackColor = Color.White;
		componentResourceManager.ApplyResources(tNomini, "tNomini");
		((Control)tNomini).Name = "tNomini";
		componentResourceManager.ApplyResources(mExpDate, "mExpDate");
		((Control)mExpDate).Name = "mExpDate";
		mExpDate.ValidatingType = typeof(DateTime);
		componentResourceManager.ApplyResources(mJoinDate, "mJoinDate");
		((Control)mJoinDate).Name = "mJoinDate";
		mJoinDate.ValidatingType = typeof(DateTime);
		componentResourceManager.ApplyResources(Label16, "Label16");
		((Control)Label16).ForeColor = Color.Black;
		((Control)Label16).Name = "Label16";
		componentResourceManager.ApplyResources(Label18, "Label18");
		((Control)Label18).ForeColor = Color.Black;
		((Control)Label18).Name = "Label18";
		componentResourceManager.ApplyResources(mBhlDate, "mBhlDate");
		((Control)mBhlDate).Name = "mBhlDate";
		mBhlDate.ValidatingType = typeof(DateTime);
		((TextBoxBase)tEmpName).BackColor = Color.White;
		componentResourceManager.ApplyResources(tEmpName, "tEmpName");
		((Control)tEmpName).Name = "tEmpName";
		((TextBoxBase)tEmpCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tEmpCode, "tEmpCode");
		((Control)tEmpCode).Name = "tEmpCode";
		componentResourceManager.ApplyResources(Label8, "Label8");
		((Control)Label8).ForeColor = Color.Black;
		((Control)Label8).Name = "Label8";
		componentResourceManager.ApplyResources(Label4, "Label4");
		((Control)Label4).ForeColor = Color.Black;
		((Control)Label4).Name = "Label4";
		componentResourceManager.ApplyResources(mAnDate, "mAnDate");
		((Control)mAnDate).Name = "mAnDate";
		mAnDate.ValidatingType = typeof(DateTime);
		componentResourceManager.ApplyResources(mBhDate, "mBhDate");
		((Control)mBhDate).Name = "mBhDate";
		mBhDate.ValidatingType = typeof(DateTime);
		componentResourceManager.ApplyResources(lblBDate, "lblBDate");
		((Control)lblBDate).ForeColor = Color.Black;
		((Control)lblBDate).Name = "lblBDate";
		componentResourceManager.ApplyResources(lblAnvDate, "lblAnvDate");
		((Control)lblAnvDate).ForeColor = Color.Black;
		((Control)lblAnvDate).Name = "lblAnvDate";
		componentResourceManager.ApplyResources(tIdProof, "tIdProof");
		((Control)tIdProof).Name = "tIdProof";
		componentResourceManager.ApplyResources(Label9, "Label9");
		((Control)Label9).ForeColor = Color.Black;
		((Control)Label9).Name = "Label9";
		((TextBoxBase)tMobile).BackColor = Color.White;
		componentResourceManager.ApplyResources(tMobile, "tMobile");
		((Control)tMobile).Name = "tMobile";
		((TextBoxBase)nGoldFine).BackColor = Color.White;
		componentResourceManager.ApplyResources(nGoldFine, "nGoldFine");
		((Control)nGoldFine).Name = "nGoldFine";
		((Control)lblMoNo).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblMoNo, "lblMoNo");
		((Control)lblMoNo).ForeColor = Color.Black;
		((Control)lblMoNo).Name = "lblMoNo";
		((BaseStyleControl)BtnF1).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnF1).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnF1).Appearance.Font = (Font)componentResourceManager.GetObject("BtnF1.Appearance.Font");
		((BaseStyleControl)BtnF1).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnF1).Appearance.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("BtnF1.Appearance.GradientMode"));
		((BaseStyleControl)BtnF1).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnF1).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnF1).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnF1).AppearanceHovered.Font = (Font)componentResourceManager.GetObject("BtnF1.AppearanceHovered.Font");
		((BaseButton)BtnF1).AppearanceHovered.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("BtnF1.AppearanceHovered.GradientMode"));
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnF1).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnF1).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnF1).AppearancePressed.Font = (Font)componentResourceManager.GetObject("BtnF1.AppearancePressed.Font");
		((BaseButton)BtnF1).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseFont = true;
		componentResourceManager.ApplyResources(BtnF1, "BtnF1");
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)Label19).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label19, "Label19");
		((Control)Label19).ForeColor = Color.Black;
		((Control)Label19).Name = "Label19";
		((TextBoxBase)nMembAmt).BackColor = Color.White;
		componentResourceManager.ApplyResources(nMembAmt, "nMembAmt");
		((Control)nMembAmt).Name = "nMembAmt";
		((Control)Label10).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label10, "Label10");
		((Control)Label10).ForeColor = Color.Black;
		((Control)Label10).Name = "Label10";
		cboArea.AutoCompleteMode = (AutoCompleteMode)3;
		cboArea.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboArea, "cboArea");
		((ListControl)cboArea).FormattingEnabled = true;
		((Control)cboArea).Name = "cboArea";
		((Control)Label17).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label17, "Label17");
		((Control)Label17).ForeColor = Color.Black;
		((Control)Label17).Name = "Label17";
		cboDistrict.AutoCompleteMode = (AutoCompleteMode)2;
		cboDistrict.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboDistrict, "cboDistrict");
		((ListControl)cboDistrict).FormattingEnabled = true;
		((Control)cboDistrict).Name = "cboDistrict";
		((TextBoxBase)tSchmName).BackColor = Color.PapayaWhip;
		componentResourceManager.ApplyResources(tSchmName, "tSchmName");
		((Control)tSchmName).Name = "tSchmName";
		componentResourceManager.ApplyResources(Label15, "Label15");
		((Control)Label15).ForeColor = Color.Black;
		((Control)Label15).Name = "Label15";
		cboCity.AutoCompleteMode = (AutoCompleteMode)3;
		cboCity.AutoCompleteSource = (AutoCompleteSource)256;
		componentResourceManager.ApplyResources(cboCity, "cboCity");
		((ListControl)cboCity).FormattingEnabled = true;
		((Control)cboCity).Name = "cboCity";
		((TextBoxBase)tSchmCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tSchmCode, "tSchmCode");
		((Control)tSchmCode).Name = "tSchmCode";
		((Control)lblBookCo).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblBookCo, "lblBookCo");
		((Control)lblBookCo).ForeColor = Color.Black;
		((Control)lblBookCo).Name = "lblBookCo";
		((Control)lblCity).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblCity, "lblCity");
		((Control)lblCity).ForeColor = Color.Black;
		((Control)lblCity).Name = "lblCity";
		((Control)Label7).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label7, "Label7");
		((Control)Label7).ForeColor = Color.Black;
		((Control)Label7).Name = "Label7";
		((TextBoxBase)tPinCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tPinCode, "tPinCode");
		((Control)tPinCode).Name = "tPinCode";
		((Control)Label3).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label3, "Label3");
		((Control)Label3).ForeColor = Color.Black;
		((Control)Label3).Name = "Label3";
		((TextBoxBase)tEmail).BackColor = Color.White;
		tEmail.CharacterCasing = (CharacterCasing)2;
		componentResourceManager.ApplyResources(tEmail, "tEmail");
		((Control)tEmail).Name = "tEmail";
		((TextBoxBase)tPhone).BackColor = Color.White;
		componentResourceManager.ApplyResources(tPhone, "tPhone");
		((Control)tPhone).Name = "tPhone";
		((TextBoxBase)tAddress3).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAddress3, "tAddress3");
		((Control)tAddress3).Name = "tAddress3";
		((TextBoxBase)tAddress2).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAddress2, "tAddress2");
		((Control)tAddress2).Name = "tAddress2";
		((TextBoxBase)tAddress1).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAddress1, "tAddress1");
		((Control)tAddress1).Name = "tAddress1";
		((Control)lblEmail).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblEmail, "lblEmail");
		((Control)lblEmail).ForeColor = Color.Black;
		((Control)lblEmail).Name = "lblEmail";
		((Control)lblPhone).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblPhone, "lblPhone");
		((Control)lblPhone).ForeColor = Color.Black;
		((Control)lblPhone).Name = "lblPhone";
		((Control)lblAdd3).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblAdd3, "lblAdd3");
		((Control)lblAdd3).ForeColor = Color.Black;
		((Control)lblAdd3).Name = "lblAdd3";
		((Control)lblAdd2).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblAdd2, "lblAdd2");
		((Control)lblAdd2).ForeColor = Color.Black;
		((Control)lblAdd2).Name = "lblAdd2";
		((Control)lblAdd1).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(lblAdd1, "lblAdd1");
		((Control)lblAdd1).ForeColor = Color.Black;
		((Control)lblAdd1).Name = "lblAdd1";
		((TextBoxBase)tAcName).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAcName, "tAcName");
		((Control)tAcName).Name = "tAcName";
		((TextBoxBase)tAcCode).BackColor = Color.White;
		componentResourceManager.ApplyResources(tAcCode, "tAcCode");
		((Control)tAcCode).Name = "tAcCode";
		((Control)Label2).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label2, "Label2");
		((Control)Label2).ForeColor = Color.Black;
		((Control)Label2).Name = "Label2";
		((Control)Label1).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label1, "Label1");
		((Control)Label1).ForeColor = Color.Black;
		((Control)Label1).Name = "Label1";
		Tab1.AttachedControl = (Control)(object)TabPanel1;
		((BaseItem)Tab1).GlobalItem = false;
		((BaseItem)Tab1).Name = "Tab1";
		componentResourceManager.ApplyResources(Tab1, "Tab1");
		Tab1.TextAlignment = (eItemAlignment)2;
		((Control)TabPanel2).Controls.Add((Control)(object)Pnl2);
		componentResourceManager.ApplyResources(TabPanel2, "TabPanel2");
		((Control)TabPanel2).Name = "TabPanel2";
		TabPanel2.TabItem = Tab2;
		((Control)Pnl2).Controls.Add((Control)(object)tMobile2);
		((Control)Pnl2).Controls.Add((Control)(object)Label6);
		((Control)Pnl2).Controls.Add((Control)(object)tPhone2);
		((Control)Pnl2).Controls.Add((Control)(object)Label5);
		((Control)Pnl2).Controls.Add((Control)(object)tRtgsNo);
		((Control)Pnl2).Controls.Add((Control)(object)tBankAcNo);
		((Control)Pnl2).Controls.Add((Control)(object)tBankArea);
		((Control)Pnl2).Controls.Add((Control)(object)tBankName);
		((Control)Pnl2).Controls.Add((Control)(object)Label11);
		((Control)Pnl2).Controls.Add((Control)(object)Label12);
		((Control)Pnl2).Controls.Add((Control)(object)Label13);
		((Control)Pnl2).Controls.Add((Control)(object)Label14);
		((Control)Pnl2).Controls.Add((Control)(object)tRefAcName);
		((Control)Pnl2).Controls.Add((Control)(object)tRefAc);
		((Control)Pnl2).Controls.Add((Control)(object)Label20);
		componentResourceManager.ApplyResources(Pnl2, "Pnl2");
		((Control)Pnl2).Name = "Pnl2";
		((TextBoxBase)tMobile2).BackColor = Color.White;
		componentResourceManager.ApplyResources(tMobile2, "tMobile2");
		((Control)tMobile2).Name = "tMobile2";
		((Control)Label6).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label6, "Label6");
		((Control)Label6).ForeColor = Color.Black;
		((Control)Label6).Name = "Label6";
		((TextBoxBase)tPhone2).BackColor = Color.White;
		componentResourceManager.ApplyResources(tPhone2, "tPhone2");
		((Control)tPhone2).Name = "tPhone2";
		((Control)Label5).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(Label5, "Label5");
		((Control)Label5).ForeColor = Color.Black;
		((Control)Label5).Name = "Label5";
		componentResourceManager.ApplyResources(tRtgsNo, "tRtgsNo");
		((Control)tRtgsNo).Name = "tRtgsNo";
		componentResourceManager.ApplyResources(tBankAcNo, "tBankAcNo");
		((Control)tBankAcNo).Name = "tBankAcNo";
		componentResourceManager.ApplyResources(tBankArea, "tBankArea");
		((Control)tBankArea).Name = "tBankArea";
		componentResourceManager.ApplyResources(tBankName, "tBankName");
		((Control)tBankName).Name = "tBankName";
		componentResourceManager.ApplyResources(Label11, "Label11");
		((Control)Label11).ForeColor = Color.Black;
		((Control)Label11).Name = "Label11";
		componentResourceManager.ApplyResources(Label12, "Label12");
		((Control)Label12).ForeColor = Color.Black;
		((Control)Label12).Name = "Label12";
		componentResourceManager.ApplyResources(Label13, "Label13");
		((Control)Label13).ForeColor = Color.Black;
		((Control)Label13).Name = "Label13";
		componentResourceManager.ApplyResources(Label14, "Label14");
		((Control)Label14).ForeColor = Color.Black;
		((Control)Label14).Name = "Label14";
		((TextBoxBase)tRefAcName).BackColor = Color.White;
		componentResourceManager.ApplyResources(tRefAcName, "tRefAcName");
		((Control)tRefAcName).Name = "tRefAcName";
		((TextBoxBase)tRefAc).BackColor = Color.White;
		componentResourceManager.ApplyResources(tRefAc, "tRefAc");
		((Control)tRefAc).Name = "tRefAc";
		componentResourceManager.ApplyResources(Label20, "Label20");
		((Control)Label20).ForeColor = Color.Black;
		((Control)Label20).Name = "Label20";
		Tab2.AttachedControl = (Control)(object)TabPanel2;
		((BaseItem)Tab2).GlobalItem = false;
		((BaseItem)Tab2).Name = "Tab2";
		componentResourceManager.ApplyResources(Tab2, "Tab2");
		Tab2.TextAlignment = (eItemAlignment)2;
		((Control)TabPanel3).Controls.Add((Control)(object)Pnl3);
		componentResourceManager.ApplyResources(TabPanel3, "TabPanel3");
		((Control)TabPanel3).Name = "TabPanel3";
		TabPanel3.TabItem = Tab3;
		componentResourceManager.ApplyResources(Pnl3, "Pnl3");
		((Control)Pnl3).Name = "Pnl3";
		Tab3.AttachedControl = (Control)(object)TabPanel3;
		((BaseItem)Tab3).GlobalItem = false;
		((BaseItem)Tab3).Name = "Tab3";
		componentResourceManager.ApplyResources(Tab3, "Tab3");
		Tab3.TextAlignment = (eItemAlignment)2;
		((TextBoxBase)tdistrict).BackColor = Color.White;
		componentResourceManager.ApplyResources(tdistrict, "tdistrict");
		((Control)tdistrict).Name = "tdistrict";
		((TextBoxBase)TState).BackColor = Color.White;
		componentResourceManager.ApplyResources(TState, "TState");
		((Control)TState).Name = "TState";
		((TextBoxBase)tCountry).BackColor = Color.White;
		componentResourceManager.ApplyResources(tCountry, "tCountry");
		((Control)tCountry).Name = "tCountry";
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)btnQr);
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
		((BaseStyleControl)btnQr).Appearance.Font = (Font)componentResourceManager.GetObject("btnQr.Appearance.Font");
		((BaseStyleControl)btnQr).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnQr).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnQr).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnQr.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnQr.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(btnQr, "btnQr");
		((BaseControl)btnQr).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnQr).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnQr).Name = "btnQr";
		((BaseButton)btnQr).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		componentResourceManager.ApplyResources(PicImage, "PicImage");
		((Control)PicImage).Name = "PicImage";
		PicImage.TabStop = false;
		BtnImgC.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgC.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgC.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnImgC, "BtnImgC");
		((BaseControl)BtnImgC).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgC).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgC).Name = "BtnImgC";
		BtnImgS.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgS.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgS.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnImgS, "BtnImgS");
		((BaseControl)BtnImgS).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgS).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgS).Name = "BtnImgS";
		BtnImgD.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgD.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgD.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnImgD, "BtnImgD");
		((BaseControl)BtnImgD).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgD).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgD).Name = "BtnImgD";
		tCustDetl.AcceptsReturn = true;
		((TextBoxBase)tCustDetl).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)tCustDetl).BorderStyle = (BorderStyle)0;
		((Control)tCustDetl).Cursor = Cursors.IBeam;
		componentResourceManager.ApplyResources(tCustDetl, "tCustDetl");
		((TextBoxBase)tCustDetl).ForeColor = Color.Navy;
		((Control)tCustDetl).Name = "tCustDetl";
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
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
		((Control)PicZoom).BackColor = Color.Transparent;
		componentResourceManager.ApplyResources(PicZoom, "PicZoom");
		((Control)PicZoom).Name = "PicZoom";
		PicZoom.TabStop = false;
		componentResourceManager.ApplyResources(PictureBox1, "PictureBox1");
		((Control)PictureBox1).Name = "PictureBox1";
		PictureBox1.TabStop = false;
		componentResourceManager.ApplyResources(Cr, "Cr");
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((BaseStyleControl)BtnAdd).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnAdd).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnAdd).Appearance.Font = (Font)componentResourceManager.GetObject("BtnAdd.Appearance.Font");
		((BaseStyleControl)BtnAdd).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnAdd).Appearance.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("BtnAdd.Appearance.GradientMode"));
		((BaseStyleControl)BtnAdd).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnAdd).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnAdd).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnAdd).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnAdd).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnAdd).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnAdd).AppearanceHovered.Font = (Font)componentResourceManager.GetObject("BtnAdd.AppearanceHovered.Font");
		((BaseButton)BtnAdd).AppearanceHovered.GradientMode = (LinearGradientMode)Conversions.ToInteger(componentResourceManager.GetObject("BtnAdd.AppearanceHovered.GradientMode"));
		((BaseButton)BtnAdd).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnAdd).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnAdd).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnAdd).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnAdd).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnAdd).AppearancePressed.Font = (Font)componentResourceManager.GetObject("BtnAdd.AppearancePressed.Font");
		((BaseButton)BtnAdd).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnAdd).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnAdd).AppearancePressed.Options.UseFont = true;
		componentResourceManager.ApplyResources(BtnAdd, "BtnAdd");
		((BaseControl)BtnAdd).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnAdd).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnAdd).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnAdd).Name = "BtnAdd";
		componentResourceManager.ApplyResources(this, "$this");
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)PictureBox1);
		((Control)this).Controls.Add((Control)(object)PicZoom);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)tCustDetl);
		((Control)this).Controls.Add((Control)(object)BtnImgD);
		((Control)this).Controls.Add((Control)(object)BtnImgS);
		((Control)this).Controls.Add((Control)(object)BtnImgC);
		((Control)this).Controls.Add((Control)(object)PicImage);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)TabMenu);
		((Control)this).Controls.Add((Control)(object)Text1);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)tdistrict);
		((Control)this).Controls.Add((Control)(object)TState);
		((Control)this).Controls.Add((Control)(object)tCountry);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_MEMB";
		((ISupportInitialize)TabMenu).EndInit();
		((Control)TabMenu).ResumeLayout(false);
		((Control)TabPanel1).ResumeLayout(false);
		((Control)Pnl1).ResumeLayout(false);
		((Control)Pnl1).PerformLayout();
		((Control)TabPanel2).ResumeLayout(false);
		((Control)Pnl2).ResumeLayout(false);
		((Control)Pnl2).PerformLayout();
		((Control)TabPanel3).ResumeLayout(false);
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)PictureBox1).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MS_MEMB_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_1220: Unknown result type (might be due to invalid IL or missing references)
		//IL_1227: Expected O, but got Unknown
		//IL_1297: Unknown result type (might be due to invalid IL or missing references)
		//IL_129c: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a6: Expected O, but got Unknown
		//IL_1314: Unknown result type (might be due to invalid IL or missing references)
		//IL_1319: Unknown result type (might be due to invalid IL or missing references)
		//IL_131f: Expected O, but got Unknown
		//IL_138d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1392: Unknown result type (might be due to invalid IL or missing references)
		//IL_1398: Expected O, but got Unknown
		//IL_1406: Unknown result type (might be due to invalid IL or missing references)
		//IL_140b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1411: Expected O, but got Unknown
		//IL_147f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1484: Unknown result type (might be due to invalid IL or missing references)
		//IL_148a: Expected O, but got Unknown
		//IL_1512: Unknown result type (might be due to invalid IL or missing references)
		//IL_1517: Unknown result type (might be due to invalid IL or missing references)
		//IL_1521: Expected O, but got Unknown
		//IL_1593: Unknown result type (might be due to invalid IL or missing references)
		//IL_1598: Unknown result type (might be due to invalid IL or missing references)
		//IL_159e: Expected O, but got Unknown
		//IL_1650: Unknown result type (might be due to invalid IL or missing references)
		//IL_1655: Unknown result type (might be due to invalid IL or missing references)
		//IL_165f: Expected O, but got Unknown
		//IL_167e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1683: Unknown result type (might be due to invalid IL or missing references)
		//IL_168d: Expected O, but got Unknown
		//IL_16ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_16bb: Expected O, but got Unknown
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
			Panel pnl;
			((Control)(pnl = Pnl1)).Width = ((Control)pnl).Width + (int)Math.Round((double)((Control)Pnl1).Width * num);
			((Control)(pnl = Pnl1)).Height = ((Control)pnl).Height + (int)Math.Round((double)((Control)Pnl1).Height * num2);
			((Control)(pnl = Pnl1)).Left = ((Control)pnl).Left + (int)Math.Round((double)((Control)Pnl1).Left * num);
			((Control)(pnl = Pnl1)).Top = ((Control)pnl).Top + (int)Math.Round((double)((Control)Pnl1).Top * num2);
			((Control)(pnl = Pnl2)).Width = ((Control)pnl).Width + (int)Math.Round((double)((Control)Pnl2).Width * num);
			((Control)(pnl = Pnl2)).Height = ((Control)pnl).Height + (int)Math.Round((double)((Control)Pnl2).Height * num2);
			((Control)(pnl = Pnl2)).Left = ((Control)pnl).Left + (int)Math.Round((double)((Control)Pnl2).Left * num);
			((Control)(pnl = Pnl2)).Top = ((Control)pnl).Top + (int)Math.Round((double)((Control)Pnl2).Top * num2);
			((Control)(pnl = Pnl3)).Width = ((Control)pnl).Width + (int)Math.Round((double)((Control)Pnl3).Width * num);
			((Control)(pnl = Pnl3)).Height = ((Control)pnl).Height + (int)Math.Round((double)((Control)Pnl3).Height * num2);
			((Control)(pnl = Pnl3)).Left = ((Control)pnl).Left + (int)Math.Round((double)((Control)Pnl3).Left * num);
			((Control)(pnl = Pnl3)).Top = ((Control)pnl).Top + (int)Math.Round((double)((Control)Pnl3).Top * num2);
			foreach (object control3 in ((Control)Pnl1).Controls)
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
			foreach (object control4 in ((Control)Pnl2).Controls)
			{
				object objectValue3 = RuntimeHelpers.GetObjectValue(control4);
				object obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control5 in ((Control)Pnl3).Controls)
			{
				object objectValue4 = RuntimeHelpers.GetObjectValue(control5);
				object obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control6 in ((Control)TabMenu).Controls)
			{
				object objectValue5 = RuntimeHelpers.GetObjectValue(control6);
				object obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			((Form)this).ClientSize = new Size((int)Math.Round(DC_Main.MainPcW), (int)Math.Round(DC_Main.MainPcH));
			((Control)this).Dock = (DockStyle)5;
			ColorConverter colorConverter = new ColorConverter();
			if (DC_Main.MsCoTheme == 2)
			{
				((Form)this).BackColor = Color.Silver;
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((TextBoxBase)tCustDetl).BackColor = ((Form)this).BackColor;
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
				TextBox obj8 = tSchmName;
				object? obj9 = colorConverter.ConvertFromString("MistyRose");
				((TextBoxBase)obj8).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj10 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((TextBoxBase)tCustDetl).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj11 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				object? obj12 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj13 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				TextBox obj14 = tSchmName;
				object? obj15 = colorConverter.ConvertFromString("233, 235, 240");
				((TextBoxBase)obj14).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj16 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((TextBoxBase)tCustDetl).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj17 = lblBook;
				object? obj18 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj17).ForeColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj19 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj20 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV2 = DGV;
				object? obj21 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj22 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				((TextBoxBase)tSchmName).BackColor = Color.Cornsilk;
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tAcName).Font.Size * (1.0 + num2));
				Font font = ((Control)tAcName).Font;
				try
				{
					foreach (Control control7 in ((Control)this).Controls)
					{
						Control val3 = control7;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is CheckBox || val3 is SimpleButton) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
						{
							val3.Font = new Font(font.FontFamily, (float)num3, font.Style);
						}
					}
					foreach (object control8 in ((Control)Pnl1).Controls)
					{
						object objectValue6 = RuntimeHelpers.GetObjectValue(control8);
						NewLateBinding.LateSet(objectValue6, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control9 in ((Control)Pnl2).Controls)
					{
						object objectValue7 = RuntimeHelpers.GetObjectValue(control9);
						NewLateBinding.LateSet(objectValue7, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control10 in ((Control)Pnl3).Controls)
					{
						object objectValue8 = RuntimeHelpers.GetObjectValue(control10);
						NewLateBinding.LateSet(objectValue8, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
					foreach (object control11 in ((Control)TabMenu).Controls)
					{
						object objectValue9 = RuntimeHelpers.GetObjectValue(control11);
						NewLateBinding.LateSet(objectValue9, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
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
					foreach (object control12 in ((Control)PnlBotam).Controls)
					{
						object objectValue10 = RuntimeHelpers.GetObjectValue(control12);
						NewLateBinding.LateSet(objectValue10, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
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
			mBhDate.Text = DC_Main.MMask;
			mAnDate.Text = DC_Main.MMask;
			mBhlDate.Text = DC_Main.MMask;
			EntryMode = "A";
			CurActCtrl = (Control)(object)tSchmCode;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void MS_MEMB_Activated(object sender, EventArgs e)
	{
		if ((Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath ?? "", (FileAttribute)0), "", false) != 0) & (Operators.CompareString(DC_Main.MsImagePath, "", false) != 0))
		{
			PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
		}
		else
		{
			PicImage.Image = null;
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
				((DataGridView)DGV).Columns[0].DataPropertyName = "MEMB_CODE";
				((DataGridView)DGV).Columns[0].HeaderText = "Code";
				((DataGridView)DGV).Columns[1].Width = (int)Math.Round(300.0 * ColCon);
				((DataGridView)DGV).Columns[1].DataPropertyName = "MEMB_NAME";
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
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected O, but got Unknown
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		foreach (Control control in ((Control)this).Controls)
		{
			Control val = control;
			if (val is TextBox)
			{
				val.Text = "";
			}
		}
		MainUser = DC_Main.MCo_User;
		foreach (object control2 in ((Control)Pnl1).Controls)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(control2);
			if ((object)objectValue.GetType() == typeof(TextBox))
			{
				TextBox val2 = (TextBox)objectValue;
				val2.Text = "";
			}
			else if ((object)objectValue.GetType() == typeof(ComboBox))
			{
				ComboBox val3 = (ComboBox)objectValue;
				val3.Text = "";
			}
		}
		foreach (object control3 in ((Control)Pnl2).Controls)
		{
			object objectValue2 = RuntimeHelpers.GetObjectValue(control3);
			if ((object)objectValue2.GetType() == typeof(TextBox))
			{
				TextBox val4 = (TextBox)objectValue2;
				val4.Text = "";
			}
			if ((object)objectValue2.GetType() == typeof(MaskedTextBox))
			{
				MaskedTextBox val5 = (MaskedTextBox)objectValue2;
				val5.Text = "";
			}
		}
		foreach (object control4 in ((Control)Pnl3).Controls)
		{
			object objectValue3 = RuntimeHelpers.GetObjectValue(control4);
			if ((object)objectValue3.GetType() == typeof(TextBox))
			{
				TextBox val6 = (TextBox)objectValue3;
				val6.Text = "";
			}
		}
		nMembAmt.Text = "";
		nGoldFine.Text = "";
		TabMenu.SelectedTab = Tab1;
		PicImage.Image = null;
		DC_Main.MsImagePath = "";
		tSchmCode.Text = OldScheme;
		tSchmName.Text = OldSchmName;
		nMembAmt.Text = Conversions.ToString(OldAmt);
		((TextBoxBase)tAcCode).ReadOnly = false;
		mBhDate.Text = DC_Main.MMask;
		mAnDate.Text = DC_Main.MMask;
		mBhlDate.Text = DC_Main.MMask;
		DC_Main.RsQry = "SELECT SCHM_CODE,MEMB_CODE,MEMB_NAME FROM AD_MEMB  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SCHM_CODE = '" + OldScheme + "' ORDER BY CAST(MEMB_CODE AS INT) desc ";
		RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_CLEAR();
		DGV_FILL();
		AddCboItem();
		Text1.Text = "SEARCH RECORD";
		((TextBoxBase)tAcCode).MaxLength = 8;
		DC_Main.RsQry = "Select MEMB_CODE As CoCode From AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SCHM_CODE = '" + tSchmCode.Text + "' ORDER BY CAST(MEMB_CODE AS INT) DESC ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)
		{
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				tAcCode.Text = "0001";
			}
			else
			{
				CodLenth = Strings.Len(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"]));
				if (CodLenth == 3)
				{
					tAcCode.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "000");
				}
				else if (CodLenth == 4)
				{
					tAcCode.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "0000");
				}
				else if (CodLenth == 5)
				{
					tAcCode.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "00000");
				}
			}
		}
		else if (DC_Main.Rshlp.Rows.Count == 0)
		{
			tAcCode.Text = Strings.Mid(DC_Main.MLc_code, 2, 1) + "0001";
		}
		else
		{
			tAcCode.Text = Strings.Mid(DC_Main.MLc_code, 2, 1) + Strings.Format((object)(Conversion.Val(Strings.Mid(Conversions.ToString(DC_Main.Rshlp.Rows[0]["CoCode"]), 2, 4)) + 1.0), "0000");
		}
		EntryMode = "A";
		((Control)tEmpCode).Focus();
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void DISPLAY_DATA()
	{
		DC_Main.RsQry = "SELECT * from AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SCHM_CODE = '" + tSchmCode.Text + "' AND MEMB_CODE = '" + tAcCode.Text + "' ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			DataTable rshlp = DC_Main.Rshlp;
			tSchmCode.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["SCHM_CODE"], (object)""));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc("SELECT * FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '" + tSchmCode.Text + "'");
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tSchmName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SCHM_NAME"], (object)""));
			}
			tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["MEMB_CODE"], (object)""));
			CurPrnVch = tAcCode.Text;
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["MEMB_NAME"], (object)""));
			nMembAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[0]["MEMB_AMT"]), "0.00");
			nGoldFine.Text = Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[0]["ITM_GWT"]), "0.000");
			tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["EMP_CODE"], (object)""));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc("SELECT * FROM EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'");
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["EMP_NAME"], (object)""));
			}
			tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_MOBILE"], (object)""));
			tPhone.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_PHONE"], (object)""));
			tAddress1.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_ADD1"], (object)""));
			tAddress2.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_ADD2"], (object)""));
			tAddress3.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_ADD3"], (object)""));
			cboDistrict.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_DISTRICT"], (object)""));
			cboCity.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_CITY"], (object)""));
			cboArea.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_AREA"], (object)""));
			tPinCode.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_PIN"], (object)""));
			tNomini.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["NOMINEE_NAME"], (object)""));
			tIdProof.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["ID_PROF"], (object)""));
			tEmail.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_EMAIL"], (object)""));
			mBhDate.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["BIRTH_DATE"], (object)""));
			mAnDate.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["ANV_DATE"], (object)""));
			mBhlDate.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["L_BR_DATE"], (object)""));
			mJoinDate.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["JOIN_DATE"], (object)""));
			mExpDate.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["EXP_DATE"], (object)""));
			tPhone2.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_PHONE2"], (object)""));
			tMobile2.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_MOBILE2"], (object)""));
			tBankName.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["BANK_NAME"], (object)""));
			tBankArea.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["BANK_AREA"], (object)""));
			tBankAcNo.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["BANK_AC_NO"], (object)""));
			tRtgsNo.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["BANK_RTGS_NO"], (object)""));
			MainUser = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["MAIN_USER"], (object)""));
			tRefAc.Text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[0]["AC_REF_CODE"], (object)""));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc("SELECT * FROM AC_MAST WHERE AC_CODE = '" + tRefAc.Text + "'");
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tRefAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
			}
			rshlp = null;
			DC_Main.Rshlp.Clear();
			EntryMode = "E";
			((TextBoxBase)tAcCode).ReadOnly = true;
		}
		DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + tSchmCode.Text + tAcCode.Text;
		DC_Main.MsImageType = "AcImage";
		DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
		if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
		{
			PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
		}
		else
		{
			PicImage.Image = null;
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		OldScheme = "";
		OldSchmName = "";
		OldAmt = 0.0;
		OldSchmMonth = 0;
		CLEAR_DATA();
		((Control)tSchmCode).Focus();
	}

	private void MS_MEMB_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_MEMB_KeyPress(object sender, KeyPressEventArgs e)
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

	private void Text1_TextChanged(object sender, EventArgs e)
	{
		checked
		{
			if ((Operators.CompareString(Text1.Text, "", false) == 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
			{
				DGV_FILL();
			}
			else if ((Operators.CompareString(Text1.Text, "", false) != 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
			{
				DGV_CLEAR();
				DataView dataView = new DataView(RsMast);
				dataView.RowFilter = "MEMB_NAME Like  '" + Text1.Text + "%' ";
				if (dataView.Count > 0)
				{
					((DataGridView)DGV).AutoGenerateColumns = false;
					((DataGridView)DGV).Columns[0].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV).Columns[0].DataPropertyName = "MEMB_CODE";
					((DataGridView)DGV).Columns[1].Width = (int)Math.Round(320.0 * ColCon);
					((DataGridView)DGV).Columns[1].DataPropertyName = "MEMB_NAME";
					((DataGridView)DGV).DataSource = dataView;
				}
			}
		}
	}

	private void Text1_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) == 0)
		{
			Text1.Text = "";
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
		if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)
		{
			return;
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsCustMail = "";
			DC_Main.MsCustWappNo = "";
			string rptName = "MembVch";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = rptName;
			DC_Main.RptFormula = "{AD_MEMB.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AD_MEMB.LC_CODE} = '" + DC_Main.MLc_code + "'  AND {AD_MEMB.SCHM_CODE} = '" + tSchmCode.Text + "' AND {AD_MEMB.MEMB_CODE} = '" + CurPrnVch + "'";
			if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
			{
				Module_Save.PrintReportDirect();
				Application.DoEvents();
			}
			else
			{
				Module_Save.ShowReportPreview();
			}
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MembVch.RPT";
			Cr.SelectionFormula = "{AD_MEMB.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AD_MEMB.LC_CODE} = '" + DC_Main.MLc_code + "'  AND {AD_MEMB.SCHM_CODE} = '" + tSchmCode.Text + "' AND {AD_MEMB.MEMB_CODE} = '" + CurPrnVch + "' ";
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

	private void DGV_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Invalid comparison between Unknown and I4
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			((Control)Text1).Focus();
		}
		else if ((int)e.KeyCode == 13)
		{
			tAcCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
			DISPLAY_DATA();
			((Control)tAcName).Focus();
		}
		else if ((int)e.KeyCode == 8 && Strings.Len(Text1.Text) > 0)
		{
			Text1.Text = Strings.Mid(Text1.Text, 1, checked(Strings.Len(Text1.Text) - 1));
		}
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		tAcCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
		DISPLAY_DATA();
		((Control)tAcName).Focus();
	}

	private void MS_MEMB_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Invalid comparison between Unknown and I4
		if (((int)e.KeyCode == 69) & e.Control)
		{
			((TextBoxBase)tAcCode).ReadOnly = false;
			((Control)tAcCode).Enabled = true;
			((TextBoxBase)tAcCode).BackColor = Color.MistyRose;
			((Control)tAcCode).Focus();
		}
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
	}

	private void tAddress1_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tAddress2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tAddress3_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tCountry_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void TState_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tPinCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tPhone_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tPhone2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tmobile_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM427NEHP", false) != 0 && ((Operators.CompareString(EntryMode, "A", false) == 0) & (Operators.CompareString(tMobile.Text, "", false) != 0)))
		{
			DC_Main.RsQry = "SELECT * FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SCHM_CODE = '" + tSchmCode.Text + "' AND AC_MOBILE = '" + tMobile.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Mobile No = ", DC_Main.Rshlp.Rows[0]["MEMB_NAME"]), (object)" "), (object)" With this Account ....."), (MsgBoxStyle)0, (object)null);
				return;
			}
		}
		SendKeys.Send("{tab}");
	}

	private void tMobile2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tEmail_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tJudrection_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tIdProof_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tSchmCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND SCHM_CODE = '" + tSchmCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT SCHM_CODE as SchmCode,SCHM_NAME As SchemeNameL,SCHM_AMT AS SchmAmtR FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY SCHM_CODE";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[4];
			DC_Main.ColWidth[0] = 100.0;
			DC_Main.ColWidth[1] = 300.0;
			DC_Main.ColWidth[2] = 100.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tSchmCode.Text = DC_Main.ColValue[0];
					tSchmName.Text = DC_Main.ColValue[1];
				}
				EntryMode = "E";
				((Control)tSchmCode).Focus();
			}
		}
		else
		{
			tSchmName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SCHM_NAME"], (object)""));
			nMembAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["SCHM_AMT"]), "0.00");
			OldScheme = tSchmCode.Text;
			OldSchmName = tSchmName.Text;
			OldAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["SCHM_AMT"]), "0.00"));
			OldSchmMonth = Conversions.ToInteger(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["SCHM_MONTH"]), "0"));
			CLEAR_DATA();
		}
	}

	private void AddCboItem()
	{
		DC_Main.RsQry = "SELECT AC_DISTRICT FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_DISTRICT ORDER BY AC_DISTRICT ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboDistrict.Items.Clear();
				int num = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 1;
				while (DC_Main.X <= num)
				{
					cboDistrict.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_DISTRICT"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboDistrict.Items.Add((object)"");
			}
			DC_Main.RsQry = "SELECT AC_CITY FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_CITY ORDER BY AC_CITY ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboCity.Items.Clear();
				int num2 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 1;
				while (DC_Main.X <= num2)
				{
					cboCity.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_CITY"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboCity.Items.Add((object)"");
			}
			DC_Main.RsQry = "SELECT AC_AREA FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_AREA ORDER BY AC_AREA ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboArea.Items.Clear();
				int num3 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 1;
				while (DC_Main.X <= num3)
				{
					cboArea.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_AREA"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboArea.Items.Add((object)"");
			}
		}
	}

	private void cboCity_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboState_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboDistrict_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboArea_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tAcName_TextChanged(object sender, EventArgs e)
	{
		tCustDetl.Text = tAcCode.Text + " - " + tAcName.Text + "  ( Mo - " + tMobile.Text + " )";
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tRefAc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tRefAc.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tRefAc.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE as AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[7];
				DC_Main.ColWidth[0] = 300.0;
				DC_Main.ColWidth[1] = 100.0;
				DC_Main.ColWidth[2] = 75.0;
				DC_Main.ColWidth[3] = 300.0;
				DC_Main.ColWidth[4] = 100.0;
				DC_Main.ColWidth[5] = 100.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tRefAc.Text = DC_Main.ColValue[1];
						tRefAcName.Text = DC_Main.ColValue[0];
					}
					((Control)tRefAc).Focus();
				}
			}
			else
			{
				tRefAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				((Control)BtnSave).Focus();
			}
		}
		else
		{
			((Control)BtnSave).Focus();
		}
	}

	private void tAcName_KeyUp(object sender, KeyEventArgs e)
	{
		DGV_CLEAR();
		DC_Main.RsQry = "SELECT TOP 99 MEMB_CODE,MEMB_NAME FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SCHM_CODE = '" + tSchmCode.Text + "' AND MEMB_NAME LIKE  '" + tAcName.Text + "%' ";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				((DataGridView)DGV).AutoGenerateColumns = false;
				((DataGridView)DGV).Columns[0].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV).Columns[0].Name = "MEMB_CODE";
				((DataGridView)DGV).Columns[1].Width = (int)Math.Round(300.0 * ColCon);
				((DataGridView)DGV).Columns[1].Name = "MEMB_NAME";
				((DataGridView)DGV).DataSource = DC_Main.Tbl;
			}
		}
	}

	private void tBankName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tBankArea_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tBankAcNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tRtgsNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tAcName_Validating(object sender, CancelEventArgs e)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		bool cancel = e.Cancel;
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " MEMB_NAME = '" + tAcName.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["MEMB_CODE"], (object)tAcCode.Text, false))
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Ac Name already Exist in  '", dataView[0]["MEMB_CODE"]), (object)"'  Memb Code... Please Change Member Name..."), (MsgBoxStyle)0, (object)null);
				cancel = true;
				((TextBoxBase)tAcName).SelectAll();
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fb: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0669: Unknown result type (might be due to invalid IL or missing references)
		//IL_0670: Expected O, but got Unknown
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
					if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
					{
						Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001;
					}
					ProjectData.ClearProjectError();
					num2 = 2;
					if ((Operators.CompareString(tAcCode.Text, "", false) == 0) | (Operators.CompareString(tAcName.Text, "", false) == 0) | (Operators.CompareString(tSchmCode.Text, "", false) == 0))
					{
						Interaction.MsgBox((object)"Enter Membaer Name and Scheme Detail", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
						((Control)tSchmCode).Focus();
						goto end_IL_0001;
					}
					DC_Main.RsQry = "DELETE FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SCHM_CODE = '" + tSchmCode.Text + "' AND MEMB_CODE = '" + tAcCode.Text + "' ";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.RsQry = "SELECT * FROM AD_MEMB  WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SCHM_CODE = '" + tSchmCode.Text + "' AND MEMB_CODE = '" + tAcCode.Text + "'";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow = DC_Main.Rshlp.NewRow();
					dataRow["CO_CODE"] = DC_Main.MCo_code;
					dataRow["LC_CODE"] = DC_Main.MLc_code;
					dataRow["SCHM_CODE"] = tSchmCode.Text;
					dataRow["MEMB_CODE"] = tAcCode.Text;
					dataRow["MEMB_NAME"] = tAcName.Text;
					dataRow["EMP_CODE"] = tEmpCode.Text;
					dataRow["MEMB_AMT"] = Conversion.Val(nMembAmt.Text);
					dataRow["ITM_GWT"] = Conversion.Val(nGoldFine.Text);
					dataRow["AC_MOBILE"] = tMobile.Text;
					dataRow["AC_PHONE"] = tPhone.Text;
					dataRow["AC_ADD1"] = tAddress1.Text;
					dataRow["AC_ADD2"] = tAddress2.Text;
					dataRow["AC_ADD3"] = tAddress3.Text;
					dataRow["AC_DISTRICT"] = cboDistrict.Text;
					dataRow["AC_CITY"] = cboCity.Text;
					dataRow["AC_PIN"] = tPinCode.Text;
					dataRow["AC_AREA"] = cboArea.Text;
					dataRow["NOMINEE_NAME"] = tNomini.Text;
					dataRow["ID_PROF"] = tIdProof.Text;
					dataRow["AC_EMAIL"] = tEmail.Text;
					dataRow["BIRTH_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mBhDate.Text), (object)DBNull.Value, (object)mBhDate.Text));
					dataRow["ANV_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mAnDate.Text), (object)DBNull.Value, (object)mAnDate.Text));
					dataRow["L_BR_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mBhlDate.Text), (object)DBNull.Value, (object)mBhlDate.Text));
					dataRow["JOIN_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mJoinDate.Text), (object)DBNull.Value, (object)mJoinDate.Text));
					dataRow["EXP_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mExpDate.Text), (object)DBNull.Value, (object)mExpDate.Text));
					dataRow["AC_PHONE2"] = tPhone2.Text;
					dataRow["AC_MOBILE2"] = tMobile2.Text;
					dataRow["BANK_NAME"] = tBankName.Text;
					dataRow["BANK_AREA"] = tBankArea.Text;
					dataRow["BANK_AC_NO"] = tBankAcNo.Text;
					dataRow["BANK_RTGS_NO"] = tRtgsNo.Text;
					dataRow["AC_REF_CODE"] = tRefAc.Text;
					dataRow["MAIN_USER"] = MainUser;
					dataRow["DATA_TRFR"] = "N";
					DC_Main.Rshlp.Rows.Add(dataRow);
					((DbDataAdapter)(object)DC_Main.Da).Update(DC_Main.Rshlp);
					DC_Main.Rshlp.Clear();
					DC_Main.ExeQuteDc("DELETE FROM IMAGE_DATA");
					DC_Main.RsQry = "SELECT * FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
					DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow2 = dataTable.NewRow();
					QRCodeGenerator val = new QRCodeGenerator();
					string text = ((!((Operators.CompareString(DC_Main.SSRegSrNo, "HM131NEPK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM360NAPK", false) == 0))) ? tAcCode.Text : (tSchmCode.Text + tAcCode.Text));
					QRCodeData val2 = val.CreateQrCode(text, (ECCLevel)2, false, false, (EciMode)0, -1);
					QRCode val3 = new QRCode(val2);
					PictureBox1.Image = (Image)(object)val3.GetGraphic(3);
					MemoryStream memoryStream = new MemoryStream();
					PictureBox1.Image.Save((Stream)memoryStream, ImageFormat.Jpeg);
					byte[] value = memoryStream.ToArray();
					dataRow2["CO_CODE"] = DC_Main.MCo_code;
					dataRow2["LC_CODE"] = DC_Main.MLc_code;
					dataRow2["SR_NO"] = 1;
					dataRow2["TAG_NO"] = tAcCode.Text;
					dataRow2["VCH_SRNO"] = 0;
					dataRow2["SCHM_CODE"] = tSchmCode.Text;
					dataRow2["MEMB_CODE"] = tAcCode.Text;
					dataRow2["TAG_IMAGE"] = value;
					dataTable.Rows.Add(dataRow2);
					((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
					dataTable.Clear();
					if (DC_Main.MsCreat)
					{
						DC_Main.MsCode = tAcCode.Text;
						DC_Main.MsName = tAcName.Text;
						((Form)this).Close();
						goto end_IL_0001;
					}
					CurPrnVch = tAcCode.Text;
					OldScheme = tSchmCode.Text;
					OldSchmName = tSchmName.Text;
					DC_Main.RsQry = "SELECT * FROM AD_MEMB  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SCHM_CODE = '" + OldScheme + "' ORDER BY MEMB_CODE ";
					RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					tSchmCode.Text = OldScheme;
					tSchmName.Text = OldSchmName;
					CLEAR_DATA();
					DGV_FILL();
					AddCboItem();
					BtnPrint_Click(BtnPrint, new EventArgs());
					CurPrnVch = "";
					goto end_IL_0001;
				}
				case 2227:
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
				try0001_dispatch = 2227;
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

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Invalid comparison between Unknown and I4
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(tAcCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select AcCode For Delete.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			return;
		}
		DC_Main.RsQry = "SELECT * FROM  AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_NO <> '00000' AND SCHM_CODE = '" + tSchmCode.Text + "' AND MEMB_CODE = '" + tAcCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			Interaction.MsgBox((object)"You Can't Delete Record This Party Code Use in Transection....", (MsgBoxStyle)0, (object)null);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Account now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "DELETE FROM AD_MEMB WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SCHM_CODE = '" + tSchmCode.Text + "'  AND MEMB_CODE = '" + tAcCode.Text + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
			DC_Main.RsQry = "SELECT * FROM AD_MEMB  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SCHM_CODE = '" + tSchmCode.Text + "' ORDER BY MEMB_CODE ";
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DGV_FILL();
		}
	}

	private void MS_MEMB_Closed(object sender, EventArgs e)
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

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT MEMB_NAME As MemberNameL,MEMB_CODE as MembCodeL, SCHM_CODE AS SchmL,AC_ADD1 As AddressL,AC_MOBILE As MobileL,MEMB_AMT As MembAmtR,ITM_GWT As GoldW FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SCHM_CODE = '" + tSchmCode.Text + "' ORDER BY MEMB_NAME";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[8];
		DC_Main.ColWidth[0] = 300.0;
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[2] = 75.0;
		DC_Main.ColWidth[3] = 300.0;
		DC_Main.ColWidth[4] = 100.0;
		DC_Main.ColWidth[5] = 100.0;
		DC_Main.ColWidth[6] = 100.0;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tAcCode.Text = DC_Main.ColValue[1];
				tAcName.Text = DC_Main.ColValue[0];
			}
			DISPLAY_DATA();
			EntryMode = "E";
			((Control)tAcName).Focus();
		}
	}

	private void nMembAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(nMembAmt.Text, "", false) == 0)
			{
				SendKeys.Send("{TAB}");
				return;
			}
			nMembAmt.Text = Strings.Format((object)Convert.ToDouble(nMembAmt.Text), "0.00");
			SendKeys.Send("{TAB}");
		}
	}

	private void cboAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void nGoldFine_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(nGoldFine.Text, "", false) == 0)
			{
				SendKeys.Send("{TAB}");
				return;
			}
			nGoldFine.Text = Strings.Format((object)Convert.ToDouble(nGoldFine.Text), "0.000");
			SendKeys.Send("{TAB}");
		}
	}

	private void cboGold_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboSilver_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			TabMenu.SelectNextTab();
			((Control)tMobile2).Focus();
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
	private void BtnImgS_Click(object sender, EventArgs e)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Invalid comparison between Unknown and I4
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
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
						DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + tSchmCode.Text + tAcCode.Text;
						DC_Main.MsImageType = "AcImage";
						DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
						if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
						{
							PicImage.Image.Dispose();
							PicImage.Image = null;
							FileSystem.Kill(DC_Main.MsImagePath);
						}
						PicImage.Image = Image.FromFile(((FileDialog)DlgOpen).FileName);
						PicImage.Image.Save(DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg");
					}
					goto end_IL_0001;
				case 377:
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
				try0001_dispatch = 377;
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
	private void BtnImgC_Click(object sender, EventArgs e)
	{
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
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
					DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + tSchmCode.Text + tAcCode.Text;
					DC_Main.MsImageType = "AcImage";
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
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
				case 270:
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
				try0001_dispatch = 270;
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

	private void cboGstType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tEmpCode_TextChanged(object sender, EventArgs e)
	{
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

	private void mJoinDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		MaskedTextBox MsDate = mJoinDate;
		DC_Main.SetDate(ref MsDate);
		mJoinDate = MsDate;
		if (DC_Main.RongDate)
		{
			return;
		}
		if (OldSchmMonth != 0)
		{
			if (OldSchmMonth == 12)
			{
				mExpDate.Text = Conversions.ToString(Conversions.ToDate(mJoinDate.Text).AddDays(364.0));
			}
			else
			{
				mExpDate.Text = Conversions.ToString(Conversions.ToDate(mJoinDate.Text).AddDays(checked(OldSchmMonth * 30)));
			}
		}
		else
		{
			mExpDate.Text = Conversions.ToString(Conversions.ToDate(mJoinDate.Text).AddDays(364.0));
		}
		SendKeys.Send("{tab}");
	}

	private void mExpDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			TabMenu.SelectNextTab();
			((Control)tMobile2).Focus();
		}
	}

	private void mBhDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void mAnDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void mBhlDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tAcName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tNomini_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void BtnMemb_Click(object sender, EventArgs e)
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT MEMB_NAME As AcNameL,MEMB_CODE as MembCodeL, SCHM_CODE AS SchmCodeL,AC_ADD1 AS AddressL,AC_CITY AS CityL FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY MEMB_NAME";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[6];
		DC_Main.ColWidth[0] = 350.0;
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[2] = 100.0;
		DC_Main.ColWidth[3] = 275.0;
		DC_Main.ColWidth[4] = 200.0;
		DC_Main.HelpSelect = 1;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
		{
			DC_Main.RsQry = "select * from AD_MEMB where CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND MEMB_CODE = '" + DC_Main.ColValue[1] + "' AND SCHM_CODE = '" + DC_Main.ColValue[2] + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboArea.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_AREA"], (object)""));
				tAddress1.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD1"], (object)""));
				tAddress2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD2"], (object)""));
				tAddress3.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD3"], (object)""));
				cboCity.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CITY"], (object)""));
				tPhone.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_PHONE"], (object)""));
				tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_MOBILE"], (object)""));
				tMobile2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_MOBILE2"], (object)""));
				tEmail.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_EMAIL"], (object)""));
				mBhDate.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BIRTH_DATE"], (object)""));
				mAnDate.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ANV_DATE"], (object)""));
				((Control)tAcName).Focus();
			}
		}
	}

	private void BtnQr_Click(object sender, EventArgs e)
	{
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MembQr.RPT";
		Cr.SelectionFormula = "{AD_MEMB.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AD_MEMB.LC_CODE} = '" + DC_Main.MLc_code + "'  AND {AD_MEMB.SCHM_CODE} = '" + tSchmCode.Text + "' AND {AD_MEMB.MEMB_CODE} = '" + CurPrnVch + "' ";
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

	private void tAcCode_Validating(object sender, CancelEventArgs e)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			bool cancel = e.Cancel;
			DataView dataView = new DataView(RsMast);
			dataView.RowFilter = " MEMB_CODE = '" + tAcCode.Text + "'";
			if (dataView.Count > 0)
			{
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Member Code already Exist in  '", dataView[0]["MEMB_NAME"]), (object)"'  Member Name...Please Change Member Code..."), (MsgBoxStyle)0, (object)null);
				cancel = true;
				((TextBoxBase)tAcCode).SelectAll();
			}
			else
			{
				cancel = false;
			}
			e.Cancel = cancel;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgD_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Image now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.MsImageType = "AcImage";
			DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + tSchmCode.Text + tAcCode.Text;
			DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
			if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
			{
				PicImage.Image.Dispose();
				PicImage.Image = null;
				FileSystem.Kill(DC_Main.MsImagePath);
			}
		}
	}

	private void BtnAcimp_Click(object sender, EventArgs e)
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE as AcCodeL, AC_AREA AS AreaL,AC_ADD1 AS AddressL,AC_CITY AS CityL FROM AC_MAST   WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(AC_CODE AS INT) > 99 ORDER BY AC_NAME";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[6];
		DC_Main.ColWidth[0] = 350.0;
		DC_Main.ColWidth[1] = 110.0;
		DC_Main.ColWidth[2] = 200.0;
		DC_Main.ColWidth[3] = 250.0;
		DC_Main.ColWidth[4] = 200.0;
		DC_Main.HelpSelect = 1;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
		{
			DC_Main.RsQry = "select * from AC_MAST where CO_CODE = '" + DC_Main.MCo_code + "' AND  AC_CODE = '" + DC_Main.ColValue[1] + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
				cboArea.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_AREA"], (object)""));
				tAddress1.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD1"], (object)""));
				tAddress2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD2"], (object)""));
				tAddress3.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD3"], (object)""));
				cboCity.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CITY"], (object)""));
				tPhone.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_PHONE"], (object)""));
				tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_MOBILE"], (object)""));
				tMobile2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_MOBILE2"], (object)""));
				tEmail.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_EMAIL"], (object)""));
				((Control)tAcName).Focus();
			}
		}
	}

	private void BtnAdd_Click(object sender, EventArgs e)
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE as AcCodeL, AC_AREA AS AreaL,AC_ADD1 AS AddressL,AC_CITY AS CityL FROM ADD_MAST   WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY AC_NAME";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[6];
		DC_Main.ColWidth[0] = 350.0;
		DC_Main.ColWidth[1] = 110.0;
		DC_Main.ColWidth[2] = 200.0;
		DC_Main.ColWidth[3] = 250.0;
		DC_Main.ColWidth[4] = 200.0;
		DC_Main.HelpSelect = 1;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
		{
			DC_Main.RsQry = "select * from ADD_MAST where CO_CODE = '" + DC_Main.MCo_code + "' AND  AC_CODE = '" + DC_Main.ColValue[1] + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
				cboArea.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_AREA"], (object)""));
				tAddress1.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD1"], (object)""));
				tAddress2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD2"], (object)""));
				tAddress3.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_ADD3"], (object)""));
				cboCity.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CITY"], (object)""));
				tPhone.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_PHONE"], (object)""));
				tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_MOBILE"], (object)""));
				tMobile2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_MOBILE2"], (object)""));
				tEmail.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_EMAIL"], (object)""));
				mBhDate.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BR_DATE"], (object)""));
				mAnDate.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AN_DATE"], (object)""));
				((Control)tAcName).Focus();
			}
		}
	}
}
