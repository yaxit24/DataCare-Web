#define DEBUG
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxCrystal;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Container;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraBars;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class UT_AI_TRFR : Form
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__192_002D0
	{
		public string _0024VB_0024Local_url;

		public _Closure_0024__192_002D0(_Closure_0024__192_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_url = arg0._0024VB_0024Local_url;
			}
		}

		[SpecialName]
		internal Image _Lambda_0024__0()
		{
			Image result;
			try
			{
				using WebClient webClient = new WebClient();
				byte[] array = webClient.DownloadData(_0024VB_0024Local_url);
				if (array.Length > 0)
				{
					using (MemoryStream memoryStream = new MemoryStream(array))
					{
						result = Image.FromStream((Stream)memoryStream);
					}
					goto IL_0066;
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				result = null;
				ProjectData.ClearProjectError();
				goto IL_0066;
			}
			result = null;
			goto IL_0066;
			IL_0066:
			return result;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__196_002D0
	{
		public string _0024VB_0024Local_serverPath;

		public _Closure_0024__196_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__196_002D0(_Closure_0024__196_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_serverPath = arg0._0024VB_0024Local_serverPath;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			try
			{
				Ac_Image.FtpDeleteFile(_0024VB_0024Local_serverPath, DC_Main.MsUrlId, DC_Main.MsUrlPwd);
				Ac_Image.FtpUploadFile(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ftpUploadPath, _0024VB_0024Local_serverPath, DC_Main.MsUrlId, DC_Main.MsUrlPwd);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Debug.WriteLine("FTP Upload error => " + ex2.Message);
				ProjectData.ClearProjectError();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__196_002D1
	{
		public string _0024VB_0024Local_ftpUploadPath;

		public byte[] _0024VB_0024Local_imageBytes;

		public string _0024VB_0024Local_tagNo;

		public string _0024VB_0024Local_VchSrNo;

		public UT_AI_TRFR _0024VB_0024Me;

		public _Closure_0024__196_002D1(_Closure_0024__196_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_ftpUploadPath = arg0._0024VB_0024Local_ftpUploadPath;
				_0024VB_0024Local_imageBytes = arg0._0024VB_0024Local_imageBytes;
				_0024VB_0024Local_tagNo = arg0._0024VB_0024Local_tagNo;
				_0024VB_0024Local_VchSrNo = arg0._0024VB_0024Local_VchSrNo;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			string value = Convert.ToBase64String(_0024VB_0024Local_imageBytes);
			DC_Main.RsQry = ("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + _0024VB_0024Local_tagNo + "' AND VCH_SRNO = " + _0024VB_0024Local_VchSrNo) ?? "";
			DC_Main.ExeQuteImg(DC_Main.RsQry);
			DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + _0024VB_0024Local_tagNo + "' AND VCH_SRNO = " + _0024VB_0024Local_VchSrNo) ?? "";
			DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow = dataTable.NewRow();
			dataRow["CO_CODE"] = DC_Main.MCo_code;
			dataRow["LC_CODE"] = DC_Main.MLc_code;
			dataRow["TAG_NO"] = _0024VB_0024Local_tagNo;
			dataRow["VCH_SRNO"] = _0024VB_0024Local_VchSrNo;
			dataRow["IMAGE_TYPE"] = "T";
			dataRow["MOB_IMAGE"] = value;
			dataTable.Rows.Add(dataRow);
			((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__196_002D2
	{
		public string _0024VB_0024Local_AppServerPath;

		public _Closure_0024__196_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_3;

		public _Closure_0024__196_002D2(_Closure_0024__196_002D2 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_AppServerPath = arg0._0024VB_0024Local_AppServerPath;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			try
			{
				Ac_Image.FtpDeleteFile(_0024VB_0024Local_AppServerPath, _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.AppFtpId, _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.AppFtpPwd);
				Ac_Image.FtpUploadFile(_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_ftpUploadPath, _0024VB_0024Local_AppServerPath, _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.AppFtpId, _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.AppFtpPwd);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Debug.WriteLine("App FTP Upload error => " + ex2.Message);
				ProjectData.ClearProjectError();
			}
		}
	}

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
	[AccessedThroughProperty("BtnCancel")]
	private SimpleButton _BtnCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToDt")]
	private MaskedTextBox _mToDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnList")]
	private QButton _BtnList;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDt")]
	private MaskedTextBox _mFromDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnExel")]
	private SimpleButton _btnExel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tGrCode")]
	private TextBox _tGrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPrCode")]
	private TextBox _tPrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTagTrfr")]
	private QButton _btnTagTrfr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnServerData")]
	private QButton _btnServerData;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBrouser")]
	private QButton _btnBrouser;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExitUae")]
	private SimpleButton _BtnExitUae;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSaveUae")]
	private SimpleButton _btnSaveUae;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsAcSum;

	private double ColCon;

	private string CurRpt;

	private string AppFtpPath;

	private string AppFtpId;

	private string AppFtpPwd;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private const int cUSrNo = 0;

	private const int cUBookName = 1;

	private const int cUVchNo = 2;

	private const int cUVchDate = 3;

	private const int cUPrName = 4;

	private const int cUTagNo = 5;

	private const int cUGrwt = 6;

	private const int cUNetWt = 7;

	private const int cUVchSrNo = 8;

	private const int cUImgId = 9;

	private const int cUBook = 10;

	private ConcurrentDictionary<string, Image> ImageCache;

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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDelete")]
	private virtual SimpleButton _BtnDelete;

	internal virtual SimpleButton BtnDelete
	{
		get
		{
			return _BtnDelete;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnDelete = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSave")]
	private virtual SimpleButton _BtnSave;

	internal virtual SimpleButton BtnSave
	{
		get
		{
			return _BtnSave;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnSave = value;
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

	internal virtual MaskedTextBox mToDt
	{
		[CompilerGenerated]
		get
		{
			return _mToDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mToDt_KeyDown);
			EventHandler eventHandler = mToDt_GotFocus;
			MaskedTextBox val2 = _mToDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_mToDt = value;
			val2 = _mToDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
			}
		}
	}

	internal virtual QButton BtnList
	{
		[CompilerGenerated]
		get
		{
			return _BtnList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnList_Click;
			QButton val = _BtnList;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnList = value;
			val = _BtnList;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual MaskedTextBox mFromDt
	{
		[CompilerGenerated]
		get
		{
			return _mFromDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mFromDt_KeyDown);
			EventHandler eventHandler = mFromDt_GotFocus;
			MaskedTextBox val2 = _mFromDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_mFromDt = value;
			val2 = _mFromDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private virtual DevComponents.DotNetBar.Controls.DataGridViewX _DGV;

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV
	{
		get
		{
			return _DGV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DGV = value;
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
			EventHandler eventHandler = btnExel_Click;
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

	internal virtual QButton btnTagTrfr
	{
		[CompilerGenerated]
		get
		{
			return _btnTagTrfr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnTagTrfr_Click;
			QButton val = _btnTagTrfr;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTagTrfr = value;
			val = _btnTagTrfr;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("GridControl1")]
	private virtual GridControl _GridControl1;

	internal virtual GridControl GridControl1
	{
		get
		{
			return _GridControl1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_GridControl1 = value;
		}
	}

	internal virtual QButton btnServerData
	{
		[CompilerGenerated]
		get
		{
			return _btnServerData;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnServerData_Click;
			QButton val = _btnServerData;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnServerData = value;
			val = _btnServerData;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TileView1")]
	private virtual TileView _TileView1;

	internal virtual TileView TileView1
	{
		get
		{
			return _TileView1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TileView1 = value;
		}
	}

	internal virtual QButton btnBrouser
	{
		[CompilerGenerated]
		get
		{
			return _btnBrouser;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnBrouser_Click;
			QButton val = _btnBrouser;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBrouser = value;
			val = _btnBrouser;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblStatus")]
	private virtual Label _lblStatus;

	internal virtual Label lblStatus
	{
		get
		{
			return _lblStatus;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblStatus = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pnlAppFtpPath")]
	private virtual Panel _pnlAppFtpPath;

	internal virtual Panel pnlAppFtpPath
	{
		get
		{
			return _pnlAppFtpPath;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_pnlAppFtpPath = value;
		}
	}

	internal virtual SimpleButton BtnExitUae
	{
		[CompilerGenerated]
		get
		{
			return _BtnExitUae;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnExitUae_Click;
			SimpleButton val = _BtnExitUae;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnExitUae = value;
			val = _BtnExitUae;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnSaveUae
	{
		[CompilerGenerated]
		get
		{
			return _btnSaveUae;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnSaveUae_Click;
			SimpleButton val = _btnSaveUae;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSaveUae = value;
			val = _btnSaveUae;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tftpPwd")]
	private virtual TextBox _tftpPwd;

	internal virtual TextBox tftpPwd
	{
		get
		{
			return _tftpPwd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tftpPwd = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label32")]
	private virtual Label _Label32;

	internal virtual Label Label32
	{
		get
		{
			return _Label32;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label32 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tFtpId")]
	private virtual TextBox _tFtpId;

	internal virtual TextBox tFtpId
	{
		get
		{
			return _tFtpId;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tFtpId = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label33")]
	private virtual Label _Label33;

	internal virtual Label Label33
	{
		get
		{
			return _Label33;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label33 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tFtpPath")]
	private virtual TextBox _tFtpPath;

	internal virtual TextBox tFtpPath
	{
		get
		{
			return _tFtpPath;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tFtpPath = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label34")]
	private virtual Label _Label34;

	internal virtual Label Label34
	{
		get
		{
			return _Label34;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label34 = value;
		}
	}

	public int newindex { get; set; }

	public UT_AI_TRFR()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		((Form)this).Load += UT_AI_TRFR_Load;
		((Form)this).Activated += UT_AI_TRFR_Activated;
		((Form)this).Deactivate += UT_AI_TRFR_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(UT_AI_TRFR_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(UT_AI_TRFR_KeyDown);
		((Form)this).Closed += UT_AI_TRFR_Closed;
		ImageCache = new ConcurrentDictionary<string, Image>();
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
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Expected O, but got Unknown
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Expected O, but got Unknown
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Expected O, but got Unknown
		//IL_0590: Unknown result type (might be due to invalid IL or missing references)
		//IL_059a: Expected O, but got Unknown
		//IL_06b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c1: Expected O, but got Unknown
		//IL_0724: Unknown result type (might be due to invalid IL or missing references)
		//IL_072e: Expected O, but got Unknown
		//IL_07d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e1: Expected O, but got Unknown
		//IL_0844: Unknown result type (might be due to invalid IL or missing references)
		//IL_084e: Expected O, but got Unknown
		//IL_08f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0901: Expected O, but got Unknown
		//IL_0964: Unknown result type (might be due to invalid IL or missing references)
		//IL_096e: Expected O, but got Unknown
		//IL_0a12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1c: Expected O, but got Unknown
		//IL_0af5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aff: Expected O, but got Unknown
		//IL_0b6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b77: Expected O, but got Unknown
		//IL_0c29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c33: Expected O, but got Unknown
		//IL_0eb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0edb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f56: Expected O, but got Unknown
		//IL_0f79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe5: Expected O, but got Unknown
		//IL_1093: Unknown result type (might be due to invalid IL or missing references)
		//IL_109d: Expected O, but got Unknown
		//IL_114e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1158: Expected O, but got Unknown
		//IL_11ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f7: Expected O, but got Unknown
		//IL_1275: Unknown result type (might be due to invalid IL or missing references)
		//IL_127f: Expected O, but got Unknown
		//IL_1354: Unknown result type (might be due to invalid IL or missing references)
		//IL_135e: Expected O, but got Unknown
		//IL_13c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d1: Expected O, but got Unknown
		//IL_1470: Unknown result type (might be due to invalid IL or missing references)
		//IL_147a: Expected O, but got Unknown
		//IL_1528: Unknown result type (might be due to invalid IL or missing references)
		//IL_1532: Expected O, but got Unknown
		//IL_159f: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a9: Expected O, but got Unknown
		//IL_1657: Unknown result type (might be due to invalid IL or missing references)
		//IL_1661: Expected O, but got Unknown
		//IL_1921: Unknown result type (might be due to invalid IL or missing references)
		//IL_1945: Unknown result type (might be due to invalid IL or missing references)
		//IL_1969: Unknown result type (might be due to invalid IL or missing references)
		//IL_198d: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c0: Expected O, but got Unknown
		//IL_19e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a83: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a8d: Expected O, but got Unknown
		//IL_1d53: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d77: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1df2: Expected O, but got Unknown
		//IL_1e15: Unknown result type (might be due to invalid IL or missing references)
		//IL_207c: Unknown result type (might be due to invalid IL or missing references)
		//IL_20a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_20c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_20e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2111: Unknown result type (might be due to invalid IL or missing references)
		//IL_211b: Expected O, but got Unknown
		//IL_213e: Unknown result type (might be due to invalid IL or missing references)
		//IL_22c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_22d0: Expected O, but got Unknown
		//IL_2333: Unknown result type (might be due to invalid IL or missing references)
		//IL_233d: Expected O, but got Unknown
		//IL_23eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_23f5: Expected O, but got Unknown
		//IL_2458: Unknown result type (might be due to invalid IL or missing references)
		//IL_2462: Expected O, but got Unknown
		//IL_2508: Unknown result type (might be due to invalid IL or missing references)
		//IL_2512: Expected O, but got Unknown
		//IL_252f: Unknown result type (might be due to invalid IL or missing references)
		//IL_25a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_25ac: Expected O, but got Unknown
		//IL_25cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2632: Unknown result type (might be due to invalid IL or missing references)
		//IL_263c: Expected O, but got Unknown
		//IL_2659: Unknown result type (might be due to invalid IL or missing references)
		//IL_26cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_26d6: Expected O, but got Unknown
		//IL_26f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_275c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2766: Expected O, but got Unknown
		//IL_2783: Unknown result type (might be due to invalid IL or missing references)
		//IL_27f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2800: Expected O, but got Unknown
		//IL_2820: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UT_AI_TRFR));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		btnExel = new SimpleButton();
		lblStatus = new Label();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		mToDt = new MaskedTextBox();
		BtnList = new QButton();
		Label1 = new Label();
		mFromDt = new MaskedTextBox();
		DGV = new DevComponents.DotNetBar.Controls.DataGridViewX();
		Label10 = new Label();
		tGrCode = new TextBox();
		Label9 = new Label();
		tPrCode = new TextBox();
		ProgressBar1 = new ProgressBar();
		btnTagTrfr = new QButton();
		GridControl1 = new GridControl();
		TileView1 = new TileView();
		btnServerData = new QButton();
		btnBrouser = new QButton();
		pnlAppFtpPath = new Panel();
		BtnExitUae = new SimpleButton();
		btnSaveUae = new SimpleButton();
		tftpPwd = new TextBox();
		Label32 = new Label();
		tFtpId = new TextBox();
		Label33 = new Label();
		tFtpPath = new TextBox();
		Label34 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
		((ISupportInitialize)GridControl1).BeginInit();
		((ISupportInitialize)TileView1).BeginInit();
		((Control)pnlAppFtpPath).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)btnExel);
		((Control)PnlBotam).Controls.Add((Control)(object)lblStatus);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 6;
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
		BtnSave.Text = "&Save";
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
		((BaseStyleControl)btnExel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnExel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnExel).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnExel).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnExel.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnExel.ImageOptions.SvgImage");
		((Control)btnExel).Location = new Point(661, 3);
		((BaseControl)btnExel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnExel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnExel).Name = "btnExel";
		((Control)btnExel).Size = new Size(160, 37);
		((Control)btnExel).TabIndex = 8;
		btnExel.Text = "Image Import";
		((BaseButton)btnExel).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)lblStatus).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblStatus).ForeColor = Color.Black;
		lblStatus.ImeMode = (ImeMode)0;
		((Control)lblStatus).Location = new Point(513, 0);
		((Control)lblStatus).Name = "lblStatus";
		((Control)lblStatus).Size = new Size(142, 44);
		((Control)lblStatus).TabIndex = 1175;
		lblStatus.Text = "Pr Code";
		lblStatus.TextAlign = (ContentAlignment)64;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1247, 476);
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
		lblBook.Text = "Ai Image Trfr";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(144, 45);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((QControl)BtnList).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnList).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnList).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnList).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnList).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnList).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnList).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnList).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnList).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnList).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnList).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnList).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnList).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnList).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnList.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnList.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnList.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnList.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnList.Image = null;
		((QControl)BtnList).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnList).Location = new Point(530, 46);
		((Control)BtnList).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnList).Name = "BtnList";
		((Control)BtnList).Size = new Size(140, 42);
		((Control)BtnList).TabIndex = 5;
		BtnList.Text = "Ok";
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(10, 44);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(44, 20);
		((Control)Label1).TabIndex = 1167;
		Label1.Text = "Date";
		Label1.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(60, 45);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV).ColumnHeadersHeight = 30;
		((DataGridView)DGV).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).DefaultCellStyle = val3;
		((DataGridView)DGV).EnableHeadersVisualStyles = false;
		((DataGridView)DGV).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV).Location = new Point(14, 83);
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV).RowHeadersVisible = false;
		((DataGridView)DGV).RowHeadersWidth = 20;
		val5.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val5;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV).Size = new Size(1160, 443);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 1172;
		((Control)DGV).Visible = false;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(235, 48);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(64, 20);
		((Control)Label10).TabIndex = 1176;
		Label10.Text = "Gr Code";
		Label10.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tGrCode).BackColor = Color.White;
		((Control)tGrCode).Font = new Font("Tahoma", 9f);
		((Control)tGrCode).Location = new Point(305, 48);
		((TextBoxBase)tGrCode).MaxLength = 3;
		((Control)tGrCode).Name = "tGrCode";
		((Control)tGrCode).Size = new Size(53, 22);
		((Control)tGrCode).TabIndex = 1175;
		((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(364, 48);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(60, 20);
		((Control)Label9).TabIndex = 1174;
		Label9.Text = "Pr Code";
		Label9.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tPrCode).BackColor = Color.White;
		((Control)tPrCode).Font = new Font("Tahoma", 9f);
		((Control)tPrCode).Location = new Point(430, 48);
		((TextBoxBase)tPrCode).MaxLength = 2;
		((Control)tPrCode).Name = "tPrCode";
		((Control)tPrCode).Size = new Size(53, 22);
		((Control)tPrCode).TabIndex = 1173;
		((Control)ProgressBar1).Location = new Point(14, 535);
		((Control)ProgressBar1).Name = "ProgressBar1";
		((Control)ProgressBar1).Size = new Size(1161, 23);
		((Control)ProgressBar1).TabIndex = 1177;
		((QControl)btnTagTrfr).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnTagTrfr).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnTagTrfr).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnTagTrfr).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnTagTrfr).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnTagTrfr).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnTagTrfr).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnTagTrfr).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnTagTrfr).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnTagTrfr).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnTagTrfr).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnTagTrfr).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnTagTrfr).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnTagTrfr).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnTagTrfr.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTagTrfr.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTagTrfr.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTagTrfr.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnTagTrfr.Image = null;
		((QControl)btnTagTrfr).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnTagTrfr).Location = new Point(690, 46);
		((Control)btnTagTrfr).Margin = new Padding(3, 6, 3, 6);
		((Control)btnTagTrfr).Name = "btnTagTrfr";
		((Control)btnTagTrfr).Size = new Size(140, 42);
		((Control)btnTagTrfr).TabIndex = 1178;
		btnTagTrfr.Text = "Export Tag";
		((BaseStyleControl)GridControl1.EmbeddedNavigator).Appearance.BorderColor = Color.Transparent;
		((BaseStyleControl)GridControl1.EmbeddedNavigator).Appearance.Options.UseBorderColor = true;
		((Control)GridControl1).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)GridControl1).Location = new Point(14, 83);
		GridControl1.MainView = (BaseView)(object)TileView1;
		((Control)GridControl1).Name = "GridControl1";
		((Control)GridControl1).Size = new Size(1161, 443);
		((Control)GridControl1).TabIndex = 1179;
		GridControl1.ViewCollection.AddRange((BaseView[])(object)new BaseView[1] { (BaseView)TileView1 });
		((Control)GridControl1).Visible = false;
		((BaseView)TileView1).GridControl = GridControl1;
		((BaseView)TileView1).Name = "TileView1";
		((QControl)btnServerData).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnServerData).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnServerData).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnServerData).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnServerData).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnServerData).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnServerData).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnServerData).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnServerData).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnServerData).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnServerData).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnServerData).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnServerData).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnServerData).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnServerData.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnServerData.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnServerData.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnServerData.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnServerData.Image = null;
		((QControl)btnServerData).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnServerData).Location = new Point(1008, 46);
		((Control)btnServerData).Margin = new Padding(3, 6, 3, 6);
		((Control)btnServerData).Name = "btnServerData";
		((Control)btnServerData).Size = new Size(140, 42);
		((Control)btnServerData).TabIndex = 1180;
		btnServerData.Text = "Server Image";
		((QControl)btnBrouser).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnBrouser).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnBrouser).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnBrouser).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnBrouser).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnBrouser).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnBrouser).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnBrouser).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnBrouser).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnBrouser).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnBrouser).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnBrouser).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnBrouser).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnBrouser).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnBrouser.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBrouser.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBrouser.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBrouser.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBrouser.Image = null;
		((QControl)btnBrouser).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnBrouser).Location = new Point(849, 46);
		((Control)btnBrouser).Margin = new Padding(3, 6, 3, 6);
		((Control)btnBrouser).Name = "btnBrouser";
		((Control)btnBrouser).Size = new Size(140, 42);
		((Control)btnBrouser).TabIndex = 1181;
		btnBrouser.Text = "Next Ai Open";
		((Control)pnlAppFtpPath).Controls.Add((Control)(object)BtnExitUae);
		((Control)pnlAppFtpPath).Controls.Add((Control)(object)btnSaveUae);
		((Control)pnlAppFtpPath).Controls.Add((Control)(object)tftpPwd);
		((Control)pnlAppFtpPath).Controls.Add((Control)(object)Label32);
		((Control)pnlAppFtpPath).Controls.Add((Control)(object)tFtpId);
		((Control)pnlAppFtpPath).Controls.Add((Control)(object)Label33);
		((Control)pnlAppFtpPath).Controls.Add((Control)(object)tFtpPath);
		((Control)pnlAppFtpPath).Controls.Add((Control)(object)Label34);
		((Control)pnlAppFtpPath).Location = new Point(60, 393);
		((Control)pnlAppFtpPath).Name = "pnlAppFtpPath";
		((Control)pnlAppFtpPath).Size = new Size(470, 168);
		((Control)pnlAppFtpPath).TabIndex = 1176;
		((Control)pnlAppFtpPath).Visible = false;
		((BaseStyleControl)BtnExitUae).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnExitUae).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExitUae).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExitUae).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnExitUae.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExitUae.ImageOptions.SvgImage");
		((Control)BtnExitUae).Location = new Point(226, 121);
		((BaseControl)BtnExitUae).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExitUae).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExitUae).Name = "BtnExitUae";
		((Control)BtnExitUae).Size = new Size(91, 37);
		((Control)BtnExitUae).TabIndex = 1181;
		BtnExitUae.Text = "E&xit";
		((BaseButton)BtnExitUae).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btnSaveUae).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnSaveUae).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnSaveUae).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnSaveUae).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnSaveUae.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnSaveUae.ImageOptions.SvgImage");
		((Control)btnSaveUae).Location = new Point(122, 121);
		((BaseControl)btnSaveUae).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnSaveUae).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnSaveUae).Name = "btnSaveUae";
		((Control)btnSaveUae).Size = new Size(91, 37);
		((Control)btnSaveUae).TabIndex = 1180;
		btnSaveUae.Text = "&Save";
		((BaseButton)btnSaveUae).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)tftpPwd).Font = new Font("Microsoft Sans Serif", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tftpPwd).Location = new Point(79, 89);
		((Control)tftpPwd).Margin = new Padding(2);
		((TextBoxBase)tftpPwd).MaxLength = 50;
		((Control)tftpPwd).Name = "tftpPwd";
		((Control)tftpPwd).Size = new Size(372, 22);
		((Control)tftpPwd).TabIndex = 1179;
		Label32.AutoSize = true;
		((Control)Label32).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label32).Location = new Point(10, 92);
		((Control)Label32).Margin = new Padding(2, 0, 2, 0);
		((Control)Label32).Name = "Label32";
		((Control)Label32).Size = new Size(56, 16);
		((Control)Label32).TabIndex = 1178;
		Label32.Text = "Ftp Pwd";
		((Control)tFtpId).Font = new Font("Microsoft Sans Serif", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tFtpId).Location = new Point(79, 52);
		((Control)tFtpId).Margin = new Padding(2);
		((TextBoxBase)tFtpId).MaxLength = 100;
		((Control)tFtpId).Name = "tFtpId";
		((Control)tFtpId).Size = new Size(372, 22);
		((Control)tFtpId).TabIndex = 1177;
		Label33.AutoSize = true;
		((Control)Label33).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label33).Location = new Point(10, 55);
		((Control)Label33).Margin = new Padding(2, 0, 2, 0);
		((Control)Label33).Name = "Label33";
		((Control)Label33).Size = new Size(41, 16);
		((Control)Label33).TabIndex = 1176;
		Label33.Text = "Ftp Id";
		((Control)tFtpPath).Font = new Font("Microsoft Sans Serif", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tFtpPath).Location = new Point(79, 16);
		((Control)tFtpPath).Margin = new Padding(2);
		((TextBoxBase)tFtpPath).MaxLength = 100;
		((Control)tFtpPath).Name = "tFtpPath";
		((Control)tFtpPath).Size = new Size(372, 22);
		((Control)tFtpPath).TabIndex = 1175;
		Label34.AutoSize = true;
		((Control)Label34).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label34).Location = new Point(10, 19);
		((Control)Label34).Margin = new Padding(2, 0, 2, 0);
		((Control)Label34).Name = "Label34";
		((Control)Label34).Size = new Size(58, 16);
		((Control)Label34).TabIndex = 1174;
		Label34.Text = "Ftp Path";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)pnlAppFtpPath);
		((Control)this).Controls.Add((Control)(object)GridControl1);
		((Control)this).Controls.Add((Control)(object)ProgressBar1);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)tGrCode);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)tPrCode);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)BtnList);
		((Control)this).Controls.Add((Control)(object)btnTagTrfr);
		((Control)this).Controls.Add((Control)(object)btnBrouser);
		((Control)this).Controls.Add((Control)(object)btnServerData);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "UT_AI_TRFR";
		((Form)this).Text = "For Ai Image";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((ISupportInitialize)GridControl1).EndInit();
		((ISupportInitialize)TileView1).EndInit();
		((Control)pnlAppFtpPath).ResumeLayout(false);
		((Control)pnlAppFtpPath).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void EntryCheckSumm()
	{
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Expected O, but got Unknown
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_06ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f9: Expected O, but got Unknown
		//IL_0745: Unknown result type (might be due to invalid IL or missing references)
		//IL_074f: Expected O, but got Unknown
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((DataGridView)DGV).Columns.Clear();
		((Control)DGV).Refresh();
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT ROW_NUMBER() OVER (ORDER BY C.VCH_DATE,C.CO_BOOK,C.VCH_NO,C.SR_NO) AS SrNo,E.BOOK_NAME,A.IT_CODE, A.TAG_NO, C.ITM_GWT, C.ITM_NWT,  CONCAT(LTrim(RTrim(A.TAG_NO)), '_', CAST(A.VCH_SRNO AS BIGINT)) AS IMG_ID,B.PR_CODE,C.VCH_DATE,A.VCH_SRNO,D.PR_NAME,C.CO_BOOK,C.VCH_NO,C.SR_NO  FROM(((MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE And A.LC_CODE = C.LC_CODE And A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO ) LEFT JOIN ITEM_MAST As B On A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE) LEFT JOIN PRODUCT_MAST As D On B.CO_CODE = D.CO_CODE And B.PR_CODE = D.PR_CODE)LEFT JOIN BOOK_DATA AS E ON C.CO_CODE = E.CO_CODE AND C.LC_CODE = E.LC_CODE AND C.CO_BOOK = E.CO_BOOK  WHERE A.CO_CODE ='" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" AND C.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND C.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND C.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "), (object)" GROUP BY E.BOOK_NAME,A.IT_CODE, A.TAG_NO, C.ITM_GWT, C.ITM_NWT,B.PR_CODE,C.VCH_DATE,A.VCH_SRNO,D.PR_NAME,C.CO_BOOK,C.VCH_NO,C.SR_NO HAVING SUM(CASE WHEN A.ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0"));
		DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(table);
		((DataGridView)DGV).MultiSelect = false;
		((DataGridView)DGV).AutoGenerateColumns = false;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV).ColumnCount = 11;
		checked
		{
			((DataGridView)DGV).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV).Columns[0].DataPropertyName = "SrNo";
			((DataGridView)DGV).Columns[0].HeaderText = "SrNo";
			((DataGridView)DGV).Columns[1].Width = (int)Math.Round(140.0 * ColCon);
			((DataGridView)DGV).Columns[1].DataPropertyName = "BOOK_NAME";
			((DataGridView)DGV).Columns[1].HeaderText = "Book Name";
			((DataGridView)DGV).Columns[2].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[2].DataPropertyName = "VCH_NO";
			((DataGridView)DGV).Columns[2].HeaderText = "VchNo";
			((DataGridView)DGV).Columns[3].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[3].DataPropertyName = "VCH_DATE";
			((DataGridView)DGV).Columns[3].HeaderText = "VchDate";
			((DataGridView)DGV).Columns[4].Width = (int)Math.Round(170.0 * ColCon);
			((DataGridView)DGV).Columns[4].DataPropertyName = "PR_NAME";
			((DataGridView)DGV).Columns[4].HeaderText = "PrName";
			((DataGridView)DGV).Columns[5].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[5].DataPropertyName = "TAG_NO";
			((DataGridView)DGV).Columns[5].HeaderText = "TagNo";
			((DataGridView)DGV).Columns[6].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[6].DataPropertyName = "ITM_GWT";
			((DataGridView)DGV).Columns[6].HeaderText = "GrWt";
			((DataGridView)DGV).Columns[7].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[7].DataPropertyName = "ITM_NWT";
			((DataGridView)DGV).Columns[7].HeaderText = "NetWt";
			((DataGridView)DGV).Columns[8].Visible = false;
			((DataGridView)DGV).Columns[8].DataPropertyName = "VCH_SRNO";
			((DataGridView)DGV).Columns[8].HeaderText = "TagId";
			((DataGridView)DGV).Columns[9].Width = (int)Math.Round(180.0 * ColCon);
			((DataGridView)DGV).Columns[9].DataPropertyName = "IMG_ID";
			((DataGridView)DGV).Columns[9].HeaderText = "ImgId";
			((DataGridView)DGV).Columns[10].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			if (dataView.Count > 0)
			{
				((DataGridView)DGV).DataSource = dataView;
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
			}
		}
	}

	private void UT_AI_TRFR_Load(object sender, EventArgs e)
	{
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_0693: Unknown result type (might be due to invalid IL or missing references)
		//IL_069a: Expected O, but got Unknown
		//IL_070a: Unknown result type (might be due to invalid IL or missing references)
		//IL_070f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0719: Expected O, but got Unknown
		//IL_07a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b0: Expected O, but got Unknown
		//IL_0822: Unknown result type (might be due to invalid IL or missing references)
		//IL_0827: Unknown result type (might be due to invalid IL or missing references)
		//IL_082d: Expected O, but got Unknown
		//IL_08df: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ee: Expected O, but got Unknown
		//IL_090d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0912: Unknown result type (might be due to invalid IL or missing references)
		//IL_091c: Expected O, but got Unknown
		//IL_093b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0940: Unknown result type (might be due to invalid IL or missing references)
		//IL_094a: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurRpt = DC_Main.MsUserRightForm;
		lblBook.Text = "User Work Report";
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
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj7 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj8 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj9 = lblBook;
				object? obj10 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj9).ForeColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj11 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
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
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is CheckBox) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
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
			CLEAR_DATA();
			DC_Main.RsQry = "SELECT * FROM BOOK_IDTL WHERE SR_NO = 78";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				AppFtpPath = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_BOOK"], (object)""));
				AppFtpId = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
				AppFtpPwd = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SVR_PWD"], (object)""));
				tFtpPath.Text = AppFtpPath;
				tFtpId.Text = AppFtpId;
				tftpPwd.Text = AppFtpPwd;
			}
			CurActCtrl = (Control)(object)mFromDt;
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
		mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		((Control)lblStatus).Visible = false;
		((Control)GridControl1).Visible = false;
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		EntryCheckSumm();
		((Control)mFromDt).Focus();
	}

	private void UT_AI_TRFR_Activated(object sender, EventArgs e)
	{
		CurActCtrl.Focus();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			BtnExit.Text = "&Exit";
			((Control)DGV).Visible = true;
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void UT_AI_TRFR_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void UT_AI_TRFR_KeyPress(object sender, KeyPressEventArgs e)
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

	private void UT_AI_TRFR_KeyDown(object sender, KeyEventArgs e)
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
		CLEAR_DATA();
	}

	private void UT_AI_TRFR_Closed(object sender, EventArgs e)
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

	private void mToDt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mToDt;
			DC_Main.SetDate(ref MsDate);
			mToDt = MsDate;
			if (!DC_Main.RongDate)
			{
				SendKeys.Send("{tab}");
			}
		}
	}

	private void mToDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mToDt).SelectionStart = 0;
		((TextBoxBase)mToDt).SelectionLength = Strings.Len(mToDt.Text);
	}

	private void mFromDt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mFromDt;
			DC_Main.SetDate(ref MsDate);
			mFromDt = MsDate;
			if (!DC_Main.RongDate)
			{
				SendKeys.Send("{tab}");
			}
		}
	}

	private void mFromDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mFromDt).SelectionStart = 0;
		((TextBoxBase)mFromDt).SelectionLength = Strings.Len(mFromDt.Text);
	}

	private void cboUser_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void BtnList_Click(object sender, EventArgs e)
	{
		((Control)GridControl1).Visible = false;
		EntryCheckSumm();
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
		if (DC_Main.Rshlp.Rows.Count != 0)
		{
			return;
		}
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
			}
			((TextBoxBase)tPrCode).SelectAll();
		}
	}

	private void btnTagTrfr_Click(object sender, EventArgs e)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Invalid comparison between Unknown and I4
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		string text = "188.241.187.122";
		string text2 = "Vsg@2718";
		string text3 = "DcAppLink";
		DC_Main.Scm.ConnectionString = ("Data Source=" + text + ";Initial Catalog=" + text3 + ";Persist Security Info=True;User ID=sa;Password=" + text2) ?? "";
		if ((int)Interaction.MsgBox((object)"Are You Sure To Image Server All Data Remove...Then New Data Export....?", (MsgBoxStyle)260, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "DELETE FROM TAG_DATA WHERE CO_HDD = '" + DC_Main.SSRegSrNo + "' AND CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ";
			DC_Main.ExeQuteScm(DC_Main.RsQry);
		}
		else
		{
			DC_Main.RsQry = "DELETE FROM TAG_DATA WHERE CO_HDD = '" + DC_Main.SSRegSrNo + "' AND CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND IMG_IMPORT = 'Y' ";
			DC_Main.ExeQuteScm(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = ((DataGridView)DGV).Rows.Count;
		checked
		{
			int num = ((DataGridView)DGV).Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT TAG_NO FROM TAG_DATA WHERE CO_HDD = '" + DC_Main.SSRegSrNo + "' AND CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), ((DataGridView)DGV).Rows[i].Cells[5].Value), (object)"' AND VCH_SRNO ="), ((DataGridView)DGV).Rows[i].Cells[8].Value), (object)"  "));
				DC_Main.Tbl = DC_Main.OpenRecordSetScm(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_DATA(CO_HDD,CO_CODE,LC_CODE,TAG_NO,VCH_SRNO,LOGIN_NAME,  SR_NO,VCH_DATE,PR_NAME,ITM_GWT,ITM_NWT,IMG_ID)  VALUES('" + DC_Main.SSRegSrNo + "','" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), ((DataGridView)DGV).Rows[i].Cells[5].Value), (object)"',"), ((DataGridView)DGV).Rows[i].Cells[8].Value), (object)",'"), (object)DC_Main.SSRegSrNo), (object)"',"), (object)" "), ((DataGridView)DGV).Rows[i].Cells[0].Value), (object)",'"), (object)Strings.Format((object)Conversions.ToDate(((DataGridView)DGV).Rows[i].Cells[3].Value), "MM/dd/yyyy")), (object)"','"), ((DataGridView)DGV).Rows[i].Cells[4].Value), (object)"',"), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV).Rows[i].Cells[6].Value))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV).Rows[i].Cells[7].Value))), (object)",'"), ((DataGridView)DGV).Rows[i].Cells[9].Value), (object)"')"));
					DC_Main.OpenRecordSetScm(DC_Main.RsQry);
				}
				dGV = null;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			Interaction.MsgBox((object)"Tag Is Transfer...ok...", (MsgBoxStyle)0, (object)null);
		}
	}

	private async void btnServerData_Click(object sender, EventArgs e)
	{
		((Control)GridControl1).Visible = true;
		string text = "Data Source=188.241.187.122;Initial Catalog=DcAppLink;User ID=sa;Password=Vsg@2718;";
		try
		{
			DataTable dataTable = new DataTable();
			SqlConnection val = new SqlConnection(text);
			try
			{
				val.Open();
				string text2 = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT TAG_NO, PR_NAME, ITM_GWT, ITM_NWT, IMG_ID,VCH_SRNO FROM TAG_DATA WHERE CO_HDD = '" + DC_Main.SSRegSrNo + "' AND CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND SUBSTRING(TAG_NO,1,2) = '" + tPrCode.Text + "'"))), (object)"")));
				SqlDataAdapter val2 = new SqlDataAdapter(text2, val);
				try
				{
					((DbDataAdapter)(object)val2).Fill(dataTable);
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			if (!dataTable.Columns.Contains("IMAGE"))
			{
				dataTable.Columns.Add("IMAGE", typeof(Image));
			}
			if (!dataTable.Columns.Contains("SELECT"))
			{
				dataTable.Columns.Add("SELECT", typeof(bool));
			}
			GridControl1.MainView = (BaseView)(object)TileView1;
			GridControl1.DataSource = dataTable;
			((ColumnView)TileView1).PopulateColumns();
			RepositoryItemPictureEdit val3 = new RepositoryItemPictureEdit();
			val3.SizeMode = (PictureSizeMode)2;
			((EditorContainer)GridControl1).RepositoryItems.Add((RepositoryItem)(object)val3);
			((ColumnView)TileView1).Columns["IMAGE"].ColumnEdit = (RepositoryItem)(object)val3;
			RepositoryItemCheckEdit val4 = new RepositoryItemCheckEdit();
			((EditorContainer)GridControl1).RepositoryItems.Add((RepositoryItem)(object)val4);
			((ColumnView)TileView1).Columns["SELECT"].ColumnEdit = (RepositoryItem)(object)val4;
			((ColumnView)TileView1).Columns["IMG_ID"].Visible = false;
			GridControl1.MainView = (BaseView)(object)TileView1;
			GridControl1.DataSource = dataTable;
			((ColumnView)TileView1).PopulateColumns();
			val3.SizeMode = (PictureSizeMode)2;
			((EditorContainer)GridControl1).RepositoryItems.Add((RepositoryItem)(object)val3);
			((ColumnView)TileView1).Columns["IMAGE"].ColumnEdit = (RepositoryItem)(object)val3;
			((EditorContainer)GridControl1).RepositoryItems.Add((RepositoryItem)(object)val4);
			((ColumnView)TileView1).Columns["SELECT"].ColumnEdit = (RepositoryItem)(object)val4;
			((ColumnView)TileView1).Columns["IMG_ID"].Visible = false;
			TileView1.OptionsTiles.ItemSize = new Size(210, 270);
			TileView1.OptionsTiles.ColumnCount = 5;
			TileView1.OptionsTiles.Orientation = (Orientation)1;
			TileView1.OptionsTiles.RowCount = 0;
			((CollectionBase)(object)TileView1.TileTemplate).Clear();
			TileViewItemElement val5 = new TileViewItemElement();
			val5.Column = ((ColumnView)TileView1).Columns["IMAGE"];
			((TileItemElement)val5).ImageScaleMode = (TileItemImageScaleMode)5;
			((TileItemElement)val5).ImageAlignment = (TileItemContentAlignment)2;
			((TileItemElement)val5).ImageSize = new Size(180, 180);
			val5.TextVisible = false;
			TileView1.TileTemplate.Add((TileItemElement)(object)val5);
			TileViewItemElement val6 = new TileViewItemElement();
			val6.Column = ((ColumnView)TileView1).Columns["TAG_NO"];
			((TileItemElement)val6).TextAlignment = (TileItemContentAlignment)7;
			((TileItemElement)val6).TextLocation = new Point(2, -60);
			((TileItemElement)val6).Appearance.Normal.Font = new Font("Tahoma", 9f, (FontStyle)1);
			TileView1.TileTemplate.Add((TileItemElement)(object)val6);
			TileViewItemElement val7 = new TileViewItemElement();
			val7.Column = ((ColumnView)TileView1).Columns["PR_NAME"];
			((TileItemElement)val7).TextAlignment = (TileItemContentAlignment)7;
			((TileItemElement)val7).TextLocation = new Point(2, -40);
			((TileItemElement)val7).Appearance.Normal.Font = new Font("Tahoma", 9f, (FontStyle)0);
			TileView1.TileTemplate.Add((TileItemElement)(object)val7);
			((ColumnView)TileView1).Columns["ITM_GWT"].DisplayFormat.FormatType = (FormatType)1;
			((ColumnView)TileView1).Columns["ITM_GWT"].DisplayFormat.FormatString = "G: {0:n2}";
			TileViewItemElement val8 = new TileViewItemElement();
			((TileItemElement)val8).TextLocation = new Point(2, -20);
			val8.Column = ((ColumnView)TileView1).Columns["ITM_GWT"];
			((TileItemElement)val8).TextAlignment = (TileItemContentAlignment)7;
			((TileItemElement)val8).Appearance.Normal.Font = new Font("Tahoma", 9f, (FontStyle)0);
			TileView1.TileTemplate.Add((TileItemElement)(object)val8);
			((ColumnView)TileView1).Columns["ITM_NWT"].DisplayFormat.FormatType = (FormatType)1;
			((ColumnView)TileView1).Columns["ITM_NWT"].DisplayFormat.FormatString = "N: {0:n2}";
			TileViewItemElement val9 = new TileViewItemElement();
			((TileItemElement)val9).TextLocation = new Point(-2, -20);
			val9.Column = ((ColumnView)TileView1).Columns["ITM_NWT"];
			((TileItemElement)val9).TextAlignment = (TileItemContentAlignment)9;
			((TileItemElement)val9).Appearance.Normal.Font = new Font("Tahoma", 9f, (FontStyle)0);
			TileView1.TileTemplate.Add((TileItemElement)(object)val9);
			TileViewItemElement val10 = new TileViewItemElement();
			val10.Column = ((ColumnView)TileView1).Columns["VCH_SRNO"];
			((TileItemElement)val10).TextAlignment = (TileItemContentAlignment)7;
			((TileItemElement)val10).TextLocation = new Point(2, 0);
			((TileItemElement)val10).Appearance.Normal.Font = new Font("Tahoma", 9f, (FontStyle)0);
			TileView1.TileTemplate.Add((TileItemElement)(object)val10);
			TileView1.ColumnSet.CheckedColumn = ((ColumnView)TileView1).Columns["SELECT"];
			((ColumnViewOptionsSelection)TileView1.OptionsSelection).MultiSelect = true;
			await LoadImagesAsync(dataTable);
			MessageBox.Show("Data loaded OK");
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Exception ex3 = ex2;
			MessageBox.Show(ex3.Message);
			ProjectData.ClearProjectError();
		}
	}

	private async Task LoadImagesAsync(DataTable dt)
	{
		List<DataRow> list = new List<DataRow>();
		_Closure_0024__192_002D0 closure_0024__192_002D = default(_Closure_0024__192_002D0);
		foreach (DataRow row in dt.Rows)
		{
			closure_0024__192_002D = new _Closure_0024__192_002D0(closure_0024__192_002D);
			if (row["IMG_ID"] == DBNull.Value)
			{
				list.Add(row);
				continue;
			}
			string text = row["IMG_ID"].ToString().Trim();
			closure_0024__192_002D._0024VB_0024Local_url = "http://188.241.187.122:99/" + DC_Main.SSRegSrNo + "/" + text + ".jpg";
			try
			{
				Image val = await Task.Run((Func<Image>)closure_0024__192_002D._Lambda_0024__0);
				if (val != null)
				{
					row["IMAGE"] = val;
				}
				else
				{
					list.Add(row);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				list.Add(row);
				ProjectData.ClearProjectError();
			}
		}
		foreach (DataRow item in list)
		{
			dt.Rows.Remove(item);
		}
		GridControl1.DataSource = dt;
		GridControl1.RefreshDataSource();
	}

	private void btnBrouser_Click(object sender, EventArgs e)
	{
		Process.Start(new ProcessStartInfo("https://www.dcnextai.com/")
		{
			UseShellExecute = true
		});
	}

	private async void btnExel_Click(object sender, EventArgs e)
	{
		checked
		{
			try
			{
				int rowCount = TileView1.RowCount;
				if (rowCount == 0)
				{
					MessageBox.Show("No rows found!");
					return;
				}
				((Control)ProgressBar1).Visible = true;
				ProgressBar1.Minimum = 0;
				ProgressBar1.Maximum = rowCount;
				ProgressBar1.Value = 0;
				((Control)lblStatus).Visible = true;
				lblStatus.Text = "Saving images...";
				int num = rowCount - 1;
				for (int i = 0; i <= num; i++)
				{
					int rowHandle = ((ColumnView)TileView1).GetRowHandle(i);
					await SaveSingleTileImageAsync(rowHandle);
					ProgressBar1.Value = i + 1;
					lblStatus.Text = "Saving " + (i + 1) + " / " + Conversions.ToString(rowCount);
					unchecked
					{
						if (checked(i + 1) % 10 == 0)
						{
							GC.Collect();
							GC.WaitForPendingFinalizers();
						}
						Application.DoEvents();
					}
				}
				GC.Collect();
				GC.WaitForPendingFinalizers();
				lblStatus.Text = "Completed!";
				await Task.Delay(500);
				((Control)ProgressBar1).Visible = false;
				((Control)lblStatus).Visible = false;
				MessageBox.Show("Bulk Image Save Completed Successfully!");
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Exception ex3 = ex2;
				MessageBox.Show(ex3.Message);
				((Control)ProgressBar1).Visible = false;
				((Control)lblStatus).Visible = false;
				ProjectData.ClearProjectError();
			}
		}
	}

	private async Task<byte[]> DownloadImageBytesAsync(string url)
	{
		try
		{
			HttpClient val = new HttpClient();
			try
			{
				val.Timeout = TimeSpan.FromSeconds(30.0);
				byte[] array = await val.GetByteArrayAsync(url);
				if (array == null || array.Length < 5000)
				{
					Debug.WriteLine("Invalid image: " + url);
					return null;
				}
				return array;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Exception ex3 = ex2;
			Debug.WriteLine("Download error => " + ex3.Message);
			byte[] result = null;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	private async Task SaveSingleTileImageAsync(int rowHandle)
	{
		try
		{
			_Closure_0024__196_002D1 arg = default(_Closure_0024__196_002D1);
			_Closure_0024__196_002D1 CS_0024_003C_003E8__locals43 = new _Closure_0024__196_002D1(arg);
			CS_0024_003C_003E8__locals43._0024VB_0024Me = this;
			DC_Main.MsImageType = "TagImage";
			string text = ((ColumnView)TileView1).GetRowCellValue(rowHandle, "IMG_ID").ToString();
			CS_0024_003C_003E8__locals43._0024VB_0024Local_tagNo = ((ColumnView)TileView1).GetRowCellValue(rowHandle, "TAG_NO").ToString();
			CS_0024_003C_003E8__locals43._0024VB_0024Local_VchSrNo = ((ColumnView)TileView1).GetRowCellValue(rowHandle, "VCH_SRNO").ToString();
			if (Operators.CompareString(text, "", false) == 0)
			{
				return;
			}
			string text2 = text + ".jpg";
			string url = "http://188.241.187.122:99/" + DC_Main.SSRegSrNo + "/" + text2;
			_Closure_0024__196_002D1 closure_0024__196_002D = CS_0024_003C_003E8__locals43;
			TaskAwaiter<byte[]> taskAwaiter = DownloadImageBytesAsync(url).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<byte[]> taskAwaiter2 = default(TaskAwaiter<byte[]>);
				taskAwaiter = taskAwaiter2;
			}
			byte[] result = taskAwaiter.GetResult();
			closure_0024__196_002D._0024VB_0024Local_imageBytes = result;
			if (CS_0024_003C_003E8__locals43._0024VB_0024Local_imageBytes == null)
			{
				return;
			}
			string text3 = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType;
			if (!Directory.Exists(text3))
			{
				Directory.CreateDirectory(text3);
			}
			string text4 = text3 + "\\" + text2;
			if (File.Exists(text4))
			{
				string text5 = text3 + "\\" + Path.GetFileNameWithoutExtension(text2) + "_OLD" + Path.GetExtension(text2);
				if (File.Exists(text5))
				{
					File.Delete(text4);
				}
				else
				{
					File.Move(text4, text5);
				}
			}
			File.WriteAllBytes(text4, CS_0024_003C_003E8__locals43._0024VB_0024Local_imageBytes);
			CS_0024_003C_003E8__locals43._0024VB_0024Local_ftpUploadPath = text4;
			string text6 = "";
			if (CS_0024_003C_003E8__locals43._0024VB_0024Local_imageBytes.Length > 819200)
			{
				try
				{
					text6 = text3 + "\\" + Path.GetFileNameWithoutExtension(text2) + "_TEMP" + Path.GetExtension(text2);
					using MemoryStream memoryStream = new MemoryStream(CS_0024_003C_003E8__locals43._0024VB_0024Local_imageBytes);
					Image val = Image.FromStream((Stream)memoryStream);
					try
					{
						ImageCodecInfo encoderInfo = Ac_Image.GetEncoderInfo("image/jpeg");
						for (long num = 95L; num >= 5; num = checked(num - 5))
						{
							EncoderParameters val2 = new EncoderParameters(1);
							val2.Param[0] = new EncoderParameter(Encoder.Quality, num);
							using MemoryStream memoryStream2 = new MemoryStream();
							val.Save((Stream)memoryStream2, encoderInfo, val2);
							long length = memoryStream2.Length;
							if (length <= 819200)
							{
								File.WriteAllBytes(text6, memoryStream2.ToArray());
								CS_0024_003C_003E8__locals43._0024VB_0024Local_ftpUploadPath = text6;
								Debug.WriteLine("Compressed: " + Conversions.ToString(CS_0024_003C_003E8__locals43._0024VB_0024Local_imageBytes.Length) + " => " + Conversions.ToString(length) + " bytes (Quality=" + Conversions.ToString(num) + ")");
								break;
							}
						}
					}
					finally
					{
						((IDisposable)val)?.Dispose();
					}
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Exception ex3 = ex2;
					Debug.WriteLine("Compression error => " + ex3.Message);
					CS_0024_003C_003E8__locals43._0024VB_0024Local_ftpUploadPath = text4;
					ProjectData.ClearProjectError();
				}
			}
			if (Operators.CompareString(DC_Main.MsUrlPath, "", false) != 0)
			{
				_Closure_0024__196_002D0 arg2 = default(_Closure_0024__196_002D0);
				_Closure_0024__196_002D0 CS_0024_003C_003E8__locals29 = new _Closure_0024__196_002D0(arg2);
				CS_0024_003C_003E8__locals29._0024VB_0024NonLocal__0024VB_0024Closure_2 = CS_0024_003C_003E8__locals43;
				if (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0)
				{
					CS_0024_003C_003E8__locals29._0024VB_0024Local_serverPath = DC_Main.MsUrlPath + "/" + DC_Main.MsImageType + "/" + text2;
				}
				else
				{
					CS_0024_003C_003E8__locals29._0024VB_0024Local_serverPath = DC_Main.MsUrlPath + text2;
				}
				await Task.Run([SpecialName] () =>
				{
					try
					{
						Ac_Image.FtpDeleteFile(CS_0024_003C_003E8__locals29._0024VB_0024Local_serverPath, DC_Main.MsUrlId, DC_Main.MsUrlPwd);
						Ac_Image.FtpUploadFile(CS_0024_003C_003E8__locals29._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ftpUploadPath, CS_0024_003C_003E8__locals29._0024VB_0024Local_serverPath, DC_Main.MsUrlId, DC_Main.MsUrlPwd);
					}
					catch (Exception ex7)
					{
						ProjectData.SetProjectError(ex7);
						Exception ex8 = ex7;
						Debug.WriteLine("FTP Upload error => " + ex8.Message);
						ProjectData.ClearProjectError();
					}
				});
			}
			if (Operators.CompareString(AppFtpPath, "", false) != 0)
			{
				_Closure_0024__196_002D2 arg3 = default(_Closure_0024__196_002D2);
				_Closure_0024__196_002D2 CS_0024_003C_003E8__locals36 = new _Closure_0024__196_002D2(arg3);
				CS_0024_003C_003E8__locals36._0024VB_0024NonLocal__0024VB_0024Closure_3 = CS_0024_003C_003E8__locals43;
				CS_0024_003C_003E8__locals36._0024VB_0024Local_AppServerPath = AppFtpPath + text2;
				await Task.Run([SpecialName] () =>
				{
					try
					{
						Ac_Image.FtpDeleteFile(CS_0024_003C_003E8__locals36._0024VB_0024Local_AppServerPath, CS_0024_003C_003E8__locals36._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.AppFtpId, CS_0024_003C_003E8__locals36._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.AppFtpPwd);
						Ac_Image.FtpUploadFile(CS_0024_003C_003E8__locals36._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_ftpUploadPath, CS_0024_003C_003E8__locals36._0024VB_0024Local_AppServerPath, CS_0024_003C_003E8__locals36._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.AppFtpId, CS_0024_003C_003E8__locals36._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.AppFtpPwd);
					}
					catch (Exception ex7)
					{
						ProjectData.SetProjectError(ex7);
						Exception ex8 = ex7;
						Debug.WriteLine("App FTP Upload error => " + ex8.Message);
						ProjectData.ClearProjectError();
					}
				});
				if (Operators.CompareString(text6, "", false) != 0 && File.Exists(text6))
				{
					try
					{
						File.Delete(text6);
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
			}
			await Task.Run([SpecialName] () =>
			{
				string value = Convert.ToBase64String(CS_0024_003C_003E8__locals43._0024VB_0024Local_imageBytes);
				DC_Main.RsQry = ("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + CS_0024_003C_003E8__locals43._0024VB_0024Local_tagNo + "' AND VCH_SRNO = " + CS_0024_003C_003E8__locals43._0024VB_0024Local_VchSrNo) ?? "";
				DC_Main.ExeQuteImg(DC_Main.RsQry);
				DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + CS_0024_003C_003E8__locals43._0024VB_0024Local_tagNo + "' AND VCH_SRNO = " + CS_0024_003C_003E8__locals43._0024VB_0024Local_VchSrNo) ?? "";
				DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
				DC_Main.MsInsertData();
				DataRow dataRow = dataTable.NewRow();
				dataRow["CO_CODE"] = DC_Main.MCo_code;
				dataRow["LC_CODE"] = DC_Main.MLc_code;
				dataRow["TAG_NO"] = CS_0024_003C_003E8__locals43._0024VB_0024Local_tagNo;
				dataRow["VCH_SRNO"] = CS_0024_003C_003E8__locals43._0024VB_0024Local_VchSrNo;
				dataRow["IMAGE_TYPE"] = "T";
				dataRow["MOB_IMAGE"] = value;
				dataTable.Rows.Add(dataRow);
				((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
			});
			CS_0024_003C_003E8__locals43._0024VB_0024Local_imageBytes = null;
			string text7 = "Data Source=188.241.187.122;Initial Catalog=DcAppLink;User ID=sa;Password=Vsg@2718;";
			string text8 = "UPDATE TAG_DATA SET IMG_IMPORT = 'Y' WHERE CO_HDD=@HDD AND CO_CODE=@CO AND LC_CODE=@LC  AND TAG_NO=@TAG AND VCH_SRNO=@SRNO";
			SqlConnection val3 = new SqlConnection(text7);
			try
			{
				val3.Open();
				SqlCommand val4 = new SqlCommand(text8, val3);
				try
				{
					val4.Parameters.AddWithValue("@HDD", (object)DC_Main.SSRegSrNo);
					val4.Parameters.AddWithValue("@CO", (object)DC_Main.MCo_code);
					val4.Parameters.AddWithValue("@LC", (object)DC_Main.MLc_code);
					val4.Parameters.AddWithValue("@TAG", (object)CS_0024_003C_003E8__locals43._0024VB_0024Local_tagNo);
					val4.Parameters.AddWithValue("@SRNO", (object)CS_0024_003C_003E8__locals43._0024VB_0024Local_VchSrNo);
					val4.ExecuteNonQuery();
				}
				finally
				{
					((IDisposable)val4)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val3)?.Dispose();
			}
			string text9 = "Data Source=" + DC_Main.SqlServer + ";Initial Catalog=" + DC_Main.SqlData + ";User ID=" + DC_Main.SqlId + ";Password=" + DC_Main.SqlPwd + ";";
			string text10 = "UPDATE BAR_DETL SET APP_TRFR = 'R' WHERE CO_CODE=@CO AND LC_CODE=@LC  AND TAG_NO=@TAG AND VCH_SRNO=@SRNO";
			SqlConnection val5 = new SqlConnection(text9);
			try
			{
				val5.Open();
				SqlCommand val6 = new SqlCommand(text10, val5);
				try
				{
					val6.Parameters.AddWithValue("@CO", (object)DC_Main.MCo_code);
					val6.Parameters.AddWithValue("@LC", (object)DC_Main.MLc_code);
					val6.Parameters.AddWithValue("@TAG", (object)CS_0024_003C_003E8__locals43._0024VB_0024Local_tagNo);
					val6.Parameters.AddWithValue("@SRNO", (object)CS_0024_003C_003E8__locals43._0024VB_0024Local_VchSrNo);
					val6.ExecuteNonQuery();
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
		}
		catch (Exception ex4)
		{
			ProjectData.SetProjectError(ex4);
			Exception ex5 = ex4;
			Exception ex6 = ex5;
			Debug.WriteLine("Save error => " + ex6.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void PnlBotam_DoubleClick(object sender, EventArgs e)
	{
		((Control)pnlAppFtpPath).Visible = true;
	}

	private void BtnExitUae_Click(object sender, EventArgs e)
	{
		((Control)pnlAppFtpPath).Visible = false;
	}

	private void btnSaveUae_Click(object sender, EventArgs e)
	{
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "DELETE FROM BOOK_IDTL WHERE SR_NO = 78";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "Select * FROM BOOK_IDTL WHERE SR_NO = 78";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (Operators.CompareString(tFtpPath.Text, "", false) != 0)
		{
			DC_Main.RsQry = "INSERT INTO BOOK_IDTL(MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME,SVR_PWD)VALUES('" + tFtpPath.Text + "',78,'O','','" + tFtpId.Text + "','" + tftpPwd.Text + "')";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		AppFtpPath = tFtpPath.Text;
		AppFtpId = tFtpId.Text;
		AppFtpPwd = tftpPwd.Text;
		Interaction.MsgBox((object)"Server Ip is Update....Ok..", (MsgBoxStyle)0, (object)null);
	}
}
