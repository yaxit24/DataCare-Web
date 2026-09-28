using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[StandardModule]
internal sealed class Ac_Image
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__13_002D0
	{
		public RowCellCustomDrawEventArgs _0024VB_0024Local_e;
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__13_002D1
	{
		public CancellationTokenSource _0024VB_0024Local_cancelSource;

		public _Closure_0024__13_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		[SpecialName]
		[DebuggerHidden]
		internal void _Lambda_0024__R2(object a0)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			AsyncLoadImageDrawCell(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_e, _0024VB_0024Local_cancelSource);
		}
	}

	public static Image[] imageArr;

	private const int THUMBNAIL_IMG_HEIGHT = 80;

	private static CancellationTokenSource cancelTaskSourceGridView = new CancellationTokenSource();

	private static List<CancellationTokenSource> listCancelTaskSourceVisibleRow = new List<CancellationTokenSource>();

	private static GridView myView;

	private static void WappFree()
	{
		LastWappReg();
		checked
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS233NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("01/01/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS264NUVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("01/01/2025").AddDays(60.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ041NUKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("20/01/2025").AddDays(60.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK227NUDS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("28/01/2025").AddDays(60.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS273NEVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("28/01/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK228NPPH", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("01/04/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS249NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("01/04/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ045NEKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("01/04/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ047NBKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("09/04/2025").AddDays(7.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS242NEVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("31/03/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM607NSPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/04/2025").AddDays(5.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM311NPHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/04/2025").AddDays(31.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS132NSVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("01/08/2025").AddDays(5.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ005NEKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("12/09/2025").AddDays(5.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS261NUBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("12/11/2025").AddDays(31.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ037NUKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("19/11/2025").AddDays(5.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS288NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/11/2025").AddDays(150.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM208NEPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("23/12/2025").AddDays(5.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			DC_Main.MsWhatsAppOpen = "Y";
		}
	}

	public static void WappReg()
	{
		checked
		{
			if (Strings.Len(DC_Main.SSRegSrNo) == 1)
			{
				DC_Main.MsWhatsAppOpen = "Y";
				DC_Main.RsQry = "SELECT TRY_DATE FROM LOCT_MAST WHERE CO_CODE = '01' AND LC_CODE = '00' AND TRY_DATE >= '" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate(DC_Main.Rshlp.Rows[0]["TRY_DATE"]), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				}
			}
			else
			{
				DC_Main.MsWhatsAppOpen = "N";
				DC_Main.MsWappEndDay = 0;
				DC_Main.MsWappMember = false;
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM208NEPK", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS288NEBU", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ037NUKJ", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS261NUBU", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ005NEKJ", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS132NSVS", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM311NPHM", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM607NSPK", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS242NEVS", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ047NBKJ", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ045NEKJ", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS249NEBU", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS273NEVS", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK227NUDS", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ041NUKJ", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK228NPPH", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS264NUVS", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS233NEBU", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM569NUSR", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS144NSBU", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ001NEKJ", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ037NUKJ", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM509NSKU", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM513NSHM", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK048NPAK", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK205NPPH", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS227NPVS", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM059NSDG", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM094NEPK", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ004NPKJ", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK183NPPH", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK179NAVK", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM290NAPK", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM470NPHM", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM469NPHM", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK189NSVK", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK189NSVK", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK188NESD", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM467NSPK", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS217NSBU", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS216NPBU", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS215NSBU", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS214NSBU", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM052NEDM", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM466NSKU", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK182NSPJ", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM455NPHM", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK174NSVK", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK186NSSD", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM458NEKU", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM447NEKU", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK040NSAK", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM455NPHM", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM050NPDM", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK181NSPH", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS211NPBU", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM453NEHP", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM451NPHP", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM450NSHP", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK171NEVK", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM017NEDM", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS205NSBU", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS204NPVS", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM443NEKU", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM045NSDM", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM281NSKU", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM273NPKU", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK034NPAK", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM270NEHP", false) == 0)
			{
				DC_Main.MsWappFree = "Y";
			}
			if (Operators.CompareString(DC_Main.MsWappFree, "Y", false) == 0)
			{
				WappFree();
				if (DC_Main.MembReg)
				{
					DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("06/07/2024").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
					DC_Main.MsWappMember = true;
					if (DC_Main.MsWappEndDay > 0)
					{
					}
				}
				return;
			}
			if (DC_Main.MembReg)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("06/07/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM198NEPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/07/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM208NEPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/07/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM159NPHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("12/07/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM207NSHP", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("14/07/2022").AddDays(31.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM075NSHP", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("15/07/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS009NSVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("15/07/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS032NPBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/07/2022").AddDays(31.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS085NPBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("26/07/2022").AddDays(31.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK093NPVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("04/08/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM039NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("16/08/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS081NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("17/08/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS039NPVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("23/08/2022").AddDays(31.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK019NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("31/08/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM171NSHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/09/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS067NPBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("14/09/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM122NEPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("12/09/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM212NPPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("17/09/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK007NEAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/09/2022").AddDays(397.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS125NPBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("30/09/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS124NEVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("26/09/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS128NSVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/09/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK078NPVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("05/10/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM011NSHP", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("15/10/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM157NPHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("17/11/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM236NPHP", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("25/11/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS136NSBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/11/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM256NSHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("14/12/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS138NPBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("19/12/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSCompSrNo1, "ANBMRF11003444B91643400Z", false) == 0 && Operators.CompareString(DC_Main.SSRegSrNo, "AK004NEAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("30/12/2022").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK017NSAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("12/03/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS029NPBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("11/01/2023").AddDays(31.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS120NSVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("25/03/2023").AddDays(92.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM019NEDM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("30/03/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK115NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("03/04/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM024NSDM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("04/04/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM204NSHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("06/04/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM018NSPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("10/04/2023").AddDays(31.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM316NPPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("17/04/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM321NAHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("25/04/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK113NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("25/04/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK024NSAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/04/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK120NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("19/05/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK121NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("19/05/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM331NSHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("23/05/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK025NLAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/05/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK026NLAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("01/06/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM336NPHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("05/06/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK138NPSD", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("15/07/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS007NPVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/07/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM360NAPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/07/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM349NEPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/07/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM175NAPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/07/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DD025NSDD", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/07/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK146NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/07/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM012NEDM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("01/08/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0 && Operators.CompareString(DC_Main.SSRegSrNo, "HM310NEPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/08/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM379NPHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("14/08/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM382NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("25/08/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK001NAAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("28/08/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM055NPPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("21/09/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS105NPBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("13/09/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM390NSHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("20/09/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK076NESD", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("11/10/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ020NPKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("14/10/2023").AddDays(91.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS103NPBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("23/10/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ021NPKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("27/10/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS061NSVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("28/10/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK033NBAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("02/11/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS118NEVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("04/11/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS178NSVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("04/11/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM402NBHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/11/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS078NPVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("25/11/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS182NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("27/11/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS055NEVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("25/11/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM416NEPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("16/12/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM111NPHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("21/12/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM410NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("21/12/2023").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM247NEPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("06/01/2024").AddDays(10.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM043NEDM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("15/01/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM307NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/01/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK036NEAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("02/02/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK164NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("07/02/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS151NSVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("16/02/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK056NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/02/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM047NSDM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("28/02/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM094NEPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("01/03/2024").AddDays(60.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS197NSVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("04/03/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK038NSAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("12/03/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS077NEVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("14/03/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS202NSVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("15/03/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK178NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("20/03/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS192NPBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("09/04/2024").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DD014NSDD", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("10/04/2024").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS156NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("11/04/2024").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK177NESD", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("12/04/2024").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM098NPHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("30/04/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK191NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("04/05/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM303NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/05/2024").AddDays(7.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK043NSAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("13/05/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM305NPKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("16/05/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK197NSVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("27/05/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK006NPVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("03/06/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM402NBHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("10/06/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK200NSPH", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("17/06/2024").AddDays(549.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM087NSKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("17/06/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK192NBVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/06/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ027NPKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/06/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM481NPHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/06/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM476NBPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("03/07/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM021NEHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/07/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK046NBAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("12/07/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS059NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/07/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM005NSDM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("19/07/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS117NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("20/07/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM417NSHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/07/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/07/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS044NPBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("30/08/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM226NSPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("31/07/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK047NPAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("31/07/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM010NADM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/08/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK093NAVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("23/08/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM068NSPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("28/08/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM495NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("04/09/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK106NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("05/09/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS159NPVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("09/09/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK088NPSD", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/09/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM006NPHP", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("13/09/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS123NPVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("21/09/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DD021NEDD", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("19/09/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS176NPBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("25/09/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS129NPBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("25/09/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM515NBHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("25/09/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM480NAKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("26/09/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK209NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("02/10/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM283NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("02/10/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM516NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("03/10/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK031NLAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("03/10/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM049NPPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("04/10/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS121NPVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("07/10/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS119NPBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("09/10/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM243NPKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("09/10/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM070NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("09/10/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM057NEDG", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("11/10/2024").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK052NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("23/10/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK047NEHR", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("26/10/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK018NPAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("28/10/2024").AddDays(31.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK051NEAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("03/11/2024").AddDays(31.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM071NPKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/11/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DD023NPDD", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/11/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK005NPAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("14/11/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS191NAVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("16/11/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM529NPHP", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("20/11/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ024NEKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/11/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM241NSHP", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("04/12/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM167NAPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("10/12/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS106NPBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("10/12/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS134NSBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("16/12/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK105NPVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("17/12/2024").AddDays(30.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK060NPVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("19/12/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK217NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("24/12/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK053NUAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("27/12/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM066NEDM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("31/12/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK054NUAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("31/12/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK055NLAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("31/12/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM565NEHP", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("31/12/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM244NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("01/01/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK009NPAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("02/01/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK183NEPH", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("02/01/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS244NEVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/12/2024").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM568NPSR", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("06/01/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK058NBAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("11/01/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK061NLAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("16/01/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK062NUAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("20/01/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM386NUHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("20/01/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM320NPPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/01/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM215NSHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("23/01/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK064NBAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("26/01/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK065NBAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("26/01/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ040NUKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("27/01/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS184NUVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("27/01/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK103NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/01/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ014NPKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/01/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK029NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("07/02/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM287NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("09/02/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS188NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("13/02/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM239NSPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("13/02/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS001NAVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("17/02/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS195NAVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("17/02/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS198NSBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("17/02/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM581NBHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("26/02/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DD013NSDD", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("27/02/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK059NEAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("28/02/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK008NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("04/03/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS200NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/03/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK055NPVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("20/03/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK066NLAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("12/03/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM053NSDM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("15/03/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK204NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/03/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM013NEDM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("21/03/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM020NSDM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/03/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK083NASD", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/03/2025").AddDays(375.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK163NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("01/04/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS286NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("27/03/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DD026NSDD", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("28/03/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM616NBPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/03/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM135NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("31/03/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM026NADM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("01/04/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM016NPDM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("01/04/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM139NSHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/04/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK243NSPH", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/04/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK244NSPH", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/04/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS234NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("09/04/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK070NLAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("10/04/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS285NEVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("11/04/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM619NBHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("17/04/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM622NBPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/04/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM521NPPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/04/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM597NEPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/04/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS254NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/04/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK071NBAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/04/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ042NUKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("10/05/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK073NUAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("27/04/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK015NPAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("27/04/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK072NBAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("28/04/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS269NPVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("07/05/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK042NEAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("10/05/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK074NBAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("10/05/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM425NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("24/05/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS284NPVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("27/05/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS282NPVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("27/05/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM041NEDG", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("02/06/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS185NPBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("02/06/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK075NLAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("04/06/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK016NPAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("10/06/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK027NSAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("14/06/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS022NPHG", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("15/06/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM328NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/06/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK076NLAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("19/06/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS287NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("21/06/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS084NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("21/06/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK077NUAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("26/06/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM454NSHP", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/06/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS024NEVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("30/06/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM090NSDM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("30/06/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM269NEHP", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("03/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS300NUBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("02/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS265NUBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("05/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS220NPVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("05/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK078NLAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("06/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM102NPHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("07/07/2025").AddDays(30.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK045NSAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("07/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM131NEPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK137NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM039NBDM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("15/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK081NPAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("16/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK029NEAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("19/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS297NABU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("19/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM066NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("19/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS222NEVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("19/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM224NSPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM314NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM092NADG", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM190NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("23/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK263NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("23/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM026NSPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("28/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK272NAST", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("28/07/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK030NPAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("02/08/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM184NSKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("01/08/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ054NBKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("03/08/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK028NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("09/08/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM585NUHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("07/08/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK023NPAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("07/08/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK079NPVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("19/08/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS310NUBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/08/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK021NPVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("26/08/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK073NPVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("28/08/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM259NEPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("30/08/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK037NPAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("02/09/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ007NPKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("04/09/2025").AddDays(335.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM033NEPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("06/09/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM387NEPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("09/09/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM248NPPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("09/09/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS229NEVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("10/09/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM012NPHP", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("10/09/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS012NPHG", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("10/09/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM176NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("13/09/2025").AddDays(31.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK049NPAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("13/09/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK022NSAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("14/09/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS171NAVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("16/09/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM124NEHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("20/09/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM147NEKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/09/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM374NPKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/09/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM680NUPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/09/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS095NSVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/09/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM199NEPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("23/09/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM197NSHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("24/09/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS052NABU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("24/09/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS110NPBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("25/09/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK102NSSD", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("30/09/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK295NUPJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("01/09/2025").AddDays(731.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK050NBAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("04/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM047NEPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("04/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK083NAAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("04/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK282NAST", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("06/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DD017NSDD", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS235NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("10/10/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK157NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("22/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM073NPHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("21/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK085NBAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("09/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK084NLAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("06/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK085NPSD", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("28/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK086NLAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("13/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK038NEVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("13/10/2025").AddDays(31.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM306NPHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("13/10/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM178NEPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("13/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS109NPVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("13/10/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM180NPHP", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("13/10/2025").AddDays(31.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS066NSBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("14/10/2025").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK013NEAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("15/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK269NPPJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("17/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM063NEHP", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK008NPAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("20/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ035NEKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS238NEVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("27/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK011NEAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("27/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK081NSVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM113NPKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("31/10/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM422NPHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("03/11/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK104NAVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("04/11/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM136NPHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("13/11/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK090NAAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("13/11/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS272NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("26/11/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS327NEVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("27/11/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM014NSHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/12/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM404NSHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/12/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM249NEHP", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("16/12/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK317NAPH", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("19/12/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK222NAPH", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("19/12/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS276NAVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("23/12/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS313NUBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("26/12/2025").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS088NPBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("01/01/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("16/01/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK057NLAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("16/01/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK060NBAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("16/01/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK310NBSS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("16/01/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM561NUHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("19/01/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS018NEHG", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("23/01/2026").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM562NUHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("31/01/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM733NAPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("02/02/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM312NAPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("02/02/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM427NEHP", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("06/02/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM602NUHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("11/02/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM576NUHP", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("12/02/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK101NSVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("13/02/2026").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM485NBPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/02/2026").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM743NBHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("24/02/2026").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS341NBBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("25/02/2026").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DD020NADD", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("15/01/2026").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK095NAAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("09/03/2026").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM142NSHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/03/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK090NEAK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("18/03/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM754NPPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("25/03/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK100NSVK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("28/03/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS209NAVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("04/04/2026").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM288NPPK", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("06/04/2026").AddDays(365.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS137NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("07/04/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM113NPDM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("11/04/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ023NEKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("15/04/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM433NSKU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("16/04/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS344NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("17/04/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM465NSHP", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("23/04/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS289NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("24/04/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS160NSVS", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/04/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM177NPHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("30/04/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK235NPPH", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("30/04/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ026NBKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("01/05/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ071NBKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("01/05/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ039NPKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/05/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS100NEHG", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/06/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ049NSKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("09/06/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM186NPHM", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("20/05/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS169NEBU", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("28/05/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DD027NSDD", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/05/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ078NPKJ", false) == 0)
			{
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("08/06/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					return;
				}
			}
			DC_Main.MsWhatsAppOpen = "Y";
		}
	}

	private static void LastWappReg()
	{
	}

	public static void GridControl_DataSourceChanged(object sender, EventArgs e)
	{
		GridControl val = (GridControl)((sender is GridControl) ? sender : null);
		BaseView focusedView = val.FocusedView;
		myView = (GridView)(object)((focusedView is GridView) ? focusedView : null);
		DataTable dataTable = val.DataSource as DataTable;
		cancelTaskSourceGridView.Cancel();
		DisposeImageArr();
		if (dataTable == null)
		{
			return;
		}
		imageArr = (Image[])(object)new Image[checked(dataTable.Rows.Count - 1 + 1)];
		cancelTaskSourceGridView = new CancellationTokenSource();
		Task.Factory.StartNew([SpecialName] [DebuggerHidden] (object a0) =>
		{
			((VB_0024AnonymousDelegate_0)([SpecialName] () =>
			{
				AsyncLoadImage(cancelTaskSourceGridView);
			}))();
		}, cancelTaskSourceGridView);
	}

	private static void AsyncLoadImage(CancellationTokenSource cancelSource)
	{
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		Image val = default(Image);
		Image[] array = default(Image[]);
		object objectValue = default(object);
		DataTable dataTable = default(DataTable);
		int num5 = default(int);
		string text = default(string);
		object obj = default(object);
		byte[] bA = default(byte[]);
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
					case 493:
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
								goto IL_0022;
							case 4:
								goto IL_002b;
							case 5:
								goto IL_0047;
							case 6:
								goto IL_0064;
							case 7:
								goto IL_0091;
							case 8:
								goto IL_0096;
							case 9:
								goto IL_00b1;
							case 10:
								goto IL_00e9;
							case 11:
								goto IL_0112;
							case 12:
								goto IL_0123;
							case 13:
								goto IL_0134;
							case 16:
								goto IL_0146;
							case 14:
							case 15:
							case 17:
							case 18:
								goto IL_014d;
							case 19:
							case 21:
							case 22:
								goto IL_0161;
							default:
								goto end_IL_0001;
							case 20:
							case 23:
								goto end_IL_0001_2;
							}
							goto default;
						}
						IL_0146:
						num2 = 16;
						val = null;
						goto IL_014d;
						IL_014d:
						num2 = 18;
						array[DC_Main.R] = val;
						goto IL_0161;
						IL_0134:
						num2 = 13;
						val = (Image)objectValue;
						goto IL_014d;
						IL_0161:
						num2 = 22;
						DC_Main.R++;
						goto IL_0170;
						IL_000b:
						num2 = 2;
						dataTable = ((BaseView)myView).GridControl.DataSource as DataTable;
						goto IL_0022;
						IL_0022:
						num2 = 3;
						array = imageArr;
						goto IL_002b;
						IL_002b:
						num2 = 4;
						num5 = dataTable.Rows.Count - 1;
						DC_Main.R = 0;
						goto IL_0170;
						IL_0170:
						if (DC_Main.R > num5)
						{
							goto end_IL_0001_2;
						}
						goto IL_0047;
						IL_0047:
						num2 = 5;
						if (cancelSource.Token.IsCancellationRequested)
						{
							goto end_IL_0001_2;
						}
						goto IL_0064;
						IL_0064:
						num2 = 6;
						text = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.R]["MOB_IMAGE"], (object)""));
						goto IL_0091;
						IL_0091:
						num2 = 7;
						val = null;
						goto IL_0096;
						IL_0096:
						num2 = 8;
						if (Operators.CompareString(text, "", false) != 0)
						{
							goto IL_00b1;
						}
						goto IL_0146;
						IL_00b1:
						num2 = 9;
						if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(dataTable.Rows[DC_Main.R]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
						{
							goto IL_00e9;
						}
						goto IL_014d;
						IL_00e9:
						num2 = 10;
						obj = Operators.ConcatenateObject(dataTable.Rows[DC_Main.R]["MOB_IMAGE"], (object)"");
						goto IL_0112;
						IL_0112:
						num2 = 11;
						bA = ConvertBase64ToByteArray(Conversions.ToString(obj));
						goto IL_0123;
						IL_0123:
						num2 = 12;
						objectValue = RuntimeHelpers.GetObjectValue(convertbytetoimage(bA));
						goto IL_0134;
						end_IL_0001:
						break;
					}
				}
			}
			catch (object obj2) when (obj2 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj2);
				try0001_dispatch = 493;
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

	public static byte[] ConvertBase64ToByteArray(string base64)
	{
		return Convert.FromBase64String(base64);
	}

	public static object convertbytetoimage(byte[] BA)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		MemoryStream memoryStream = default(MemoryStream);
		Image val = default(Image);
		object result = default(object);
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
				case 77:
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
							goto IL_0015;
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
					memoryStream = new MemoryStream(BA);
					goto IL_0015;
					IL_0015:
					num2 = 3;
					val = Image.FromStream((Stream)memoryStream);
					break;
					end_IL_0001_2:
					break;
				}
				num2 = 4;
				result = val;
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 77;
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
		return result;
	}

	public static void GridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
	{
		_Closure_0024__13_002D0 closure_0024__13_002D = new _Closure_0024__13_002D0();
		closure_0024__13_002D._0024VB_0024Local_e = e;
		if (Operators.CompareString(closure_0024__13_002D._0024VB_0024Local_e.Column.FieldName, "Display Image", false) != 0)
		{
			return;
		}
		checked
		{
			if (imageArr != null)
			{
				int dataSourceRowIndex = ((ColumnView)myView).GetDataSourceRowIndex(closure_0024__13_002D._0024VB_0024Local_e.RowHandle);
				if (dataSourceRowIndex > -1 && imageArr[dataSourceRowIndex] != null)
				{
					Image val = imageArr[dataSourceRowIndex];
					Rectangle bounds = ((CustomDrawEventArgs)closure_0024__13_002D._0024VB_0024Local_e).Bounds;
					double num = Math.Min((double)bounds.Width / (double)val.Width, (double)bounds.Height / (double)val.Height);
					bounds.Width = Convert.ToInt32((double)val.Width * num);
					bounds.Height = Convert.ToInt32((double)val.Height * num);
					bounds.X += Convert.ToInt32((double)(((CustomDrawEventArgs)closure_0024__13_002D._0024VB_0024Local_e).Bounds.Width - bounds.Width) / 2.0);
					bounds.Y += Convert.ToInt32((double)(((CustomDrawEventArgs)closure_0024__13_002D._0024VB_0024Local_e).Bounds.Height - bounds.Height) / 2.0);
					((CustomDrawEventArgs)closure_0024__13_002D._0024VB_0024Local_e).Graphics.DrawImage(val, bounds);
				}
				else
				{
					_Closure_0024__13_002D1 CS_0024_003C_003E8__locals5 = new _Closure_0024__13_002D1();
					CS_0024_003C_003E8__locals5._0024VB_0024NonLocal__0024VB_0024Closure_2 = closure_0024__13_002D;
					CS_0024_003C_003E8__locals5._0024VB_0024Local_cancelSource = new CancellationTokenSource();
					lock (listCancelTaskSourceVisibleRow)
					{
						listCancelTaskSourceVisibleRow.Add(CS_0024_003C_003E8__locals5._0024VB_0024Local_cancelSource);
						if (listCancelTaskSourceVisibleRow.Count > 20)
						{
							listCancelTaskSourceVisibleRow[0].Cancel();
							listCancelTaskSourceVisibleRow.RemoveAt(0);
						}
					}
					Task.Factory.StartNew([SpecialName] [DebuggerHidden] (object a0) =>
					{
						CS_0024_003C_003E8__locals5._Lambda_0024__0();
					}, CS_0024_003C_003E8__locals5._0024VB_0024Local_cancelSource);
				}
			}
			((CustomDrawEventArgs)closure_0024__13_002D._0024VB_0024Local_e).Handled = true;
		}
	}

	private static void AsyncLoadImageDrawCell(RowCellCustomDrawEventArgs e, CancellationTokenSource cancelSource)
	{
	}

	public static void DisposeImageArr()
	{
		if (imageArr == null)
		{
			return;
		}
		checked
		{
			int num = imageArr.Length - 1;
			DC_Main.R = 0;
			while (DC_Main.R <= num)
			{
				if (imageArr[DC_Main.R] != null)
				{
					imageArr[DC_Main.R].Dispose();
				}
				DC_Main.R++;
			}
			imageArr = null;
		}
	}

	public static ImageCodecInfo GetEncoderInfo(string mimeType)
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

	public static void SaveJPGWithCompressionSetting(Image image, string szFileName, long lCompression)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
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
				case 224:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 2:
							break;
						case 1:
							goto IL_00ac;
						default:
							goto end_IL_0001;
						}
						goto IL_0046;
					}
					IL_0013:
					num2 = 3;
					val.Param[0] = new EncoderParameter(Encoder.Quality, lCompression);
					goto IL_0028;
					IL_0028:
					num2 = 4;
					encoderInfo = GetEncoderInfo("image/jpeg");
					goto IL_0036;
					IL_000a:
					num2 = 2;
					val = new EncoderParameters(1);
					goto IL_0013;
					IL_0046:
					num2 = 7;
					Interaction.MsgBox((object)("Error: " + Conversions.ToString(Information.Err().Number) + " " + Information.Err().Description + "\r\nChoose a different name for file."), (MsgBoxStyle)0, (object)null);
					goto IL_0092;
					IL_0092:
					num2 = 8;
					ProjectData.ClearProjectError();
					if (num == 0)
					{
						throw ProjectData.CreateProjectError(-2146828268);
					}
					goto IL_00ac;
					IL_0036:
					num2 = 5;
					image.Save(szFileName, encoderInfo, val);
					goto end_IL_0001_2;
					IL_00ac:
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
						goto IL_0036;
					case 7:
						goto IL_0046;
					case 8:
						goto IL_0092;
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
				try0001_dispatch = 224;
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

	public static void FtpUploadFile(string filetoupload, string ftpuri, string ftpusername, string ftppassword)
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(ftpuri);
		try
		{
			ftpWebRequest.Method = "STOR";
			ftpWebRequest.Credentials = new NetworkCredential(ftpusername, ftppassword);
			byte[] array = File.ReadAllBytes(filetoupload);
			ftpWebRequest.ContentLength = array.Length;
			using Stream stream = ftpWebRequest.GetRequestStream();
			stream.Write(array, 0, array.Length);
			stream.Close();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	public static void FtpDeleteFile(string ftpuri, string ftpusername, string ftppassword)
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		FtpWebRequest ftpWebRequest = default(FtpWebRequest);
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
				case 112:
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
							goto IL_0019;
						case 4:
							goto IL_0029;
						case 5:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 6:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_000b:
					num2 = 2;
					ftpWebRequest = (FtpWebRequest)WebRequest.Create(ftpuri);
					goto IL_0019;
					IL_0019:
					num2 = 3;
					ftpWebRequest.Credentials = new NetworkCredential(ftpusername, ftppassword);
					goto IL_0029;
					IL_0029:
					num2 = 4;
					ftpWebRequest.Method = "DELE";
					break;
					end_IL_0001_2:
					break;
				}
				num2 = 5;
				FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 112;
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

	public static void All_Co_ItmMast_Same()
	{
		DC_Main.RsQry = "SELECT * FROM PRODUCT_MAST WHERE CO_CODE = '01' AND DATA_TRFR = 'N'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '"), rshlp.Rows[DC_Main.M]["PR_CODE"]), (object)"'"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO PRODUCT_MAST(CO_CODE,PR_CODE,PR_NAME,MAIN_USER,DATA_TRFR)   VALUES ('" + DC_Main.MCo_code + "','"), rshlp.Rows[DC_Main.M]["PR_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["PR_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','Y')"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE PRODUCT_MAST SET DATA_TRFR = 'Y' WHERE CO_CODE = '01' AND PR_CODE = '", rshlp.Rows[DC_Main.M]["PR_CODE"]), (object)"'"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				rshlp = null;
				DC_Main.M++;
				Application.DoEvents();
			}
			DC_Main.RsQry = "SELECT * FROM GROUP_MAST WHERE CO_CODE = '01' AND DATA_TRFR = 'N'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			Application.DoEvents();
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp2 = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND GR_CODE = '"), rshlp2.Rows[DC_Main.M]["GR_CODE"]), (object)"'"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO GROUP_MAST(CO_CODE,GR_CODE,GR_NAME,GR_TYPE,TRAD_TYPE,GR_TOUCH,GR_PURC_TOUCH,MELTING_PRC,  GR_RATE,WEST_PRC,SALE_AC,PURC_AC,HSN_CODE,MAIN_USER,TAX_PRC,AVG_TOUCH,AVG_FINE,AVG_NWT,DAY_OP_PCS,DAY_OP_WT,  DAY_CL_PCS,DAY_CL_WT,RATE_DISPLAY)   VALUES ('" + DC_Main.MCo_code + "','"), rshlp2.Rows[DC_Main.M]["GR_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["GR_NAME"]), (object)"','"), rshlp2.Rows[DC_Main.M]["GR_TYPE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["TRAD_TYPE"]), (object)"',"), rshlp2.Rows[DC_Main.M]["GR_TOUCH"]), (object)","), rshlp2.Rows[DC_Main.M]["GR_PURC_TOUCH"]), (object)","), rshlp2.Rows[DC_Main.M]["MELTING_PRC"]), (object)", "), (object)" "), rshlp2.Rows[DC_Main.M]["GR_RATE"]), (object)","), rshlp2.Rows[DC_Main.M]["WEST_PRC"]), (object)",'"), rshlp2.Rows[DC_Main.M]["SALE_AC"]), (object)"','"), rshlp2.Rows[DC_Main.M]["PURC_AC"]), (object)"','"), rshlp2.Rows[DC_Main.M]["HSN_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["MAIN_USER"]), (object)"',"), rshlp2.Rows[DC_Main.M]["TAX_PRC"]), (object)","), rshlp2.Rows[DC_Main.M]["AVG_TOUCH"]), (object)","), rshlp2.Rows[DC_Main.M]["AVG_FINE"]), (object)","), rshlp2.Rows[DC_Main.M]["AVG_NWT"]), (object)",0,0, "), (object)" 0,0,'"), rshlp2.Rows[DC_Main.M]["RATE_DISPLAY"]), (object)"')"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE GROUP_MAST SET DATA_TRFR = 'Y' WHERE CO_CODE = '01' AND GR_CODE = '", rshlp2.Rows[DC_Main.M]["GR_CODE"]), (object)"'"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				rshlp2 = null;
				DC_Main.M++;
				Application.DoEvents();
			}
			DC_Main.RsQry = "SELECT * FROM ITEM_MAST WHERE CO_CODE = '01' AND DATA_TRFR = 'N'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			Application.DoEvents();
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp3 = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '"), rshlp3.Rows[DC_Main.M]["IT_CODE"]), (object)"'"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO ITEM_MAST(CO_CODE,IT_CODE,IT_NAME,IT_TYPE,TAG_TYPE,PR_CODE,GR_CODE,TRAD_TYPE,UNIT_NAME,  RATE_TYPE,HSN_CODE,ITEM_RATE,LBR_PRC,CON_PRC,DISC_PRC,IT_TOUCH,IT_WEST,OTHER_RATE,MIN_STK,MAIN_USER,  AVG_TOUCH,AVG_FINE,AVG_NWT,AC_ITEM,STK_DISPLAY,OTH_RATE,AVG_RATE,SAFE_NAME)   VALUES ('" + DC_Main.MCo_code + "','"), rshlp3.Rows[DC_Main.M]["IT_CODE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["IT_NAME"]), (object)"','"), rshlp3.Rows[DC_Main.M]["IT_TYPE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["TAG_TYPE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["PR_CODE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["GR_CODE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["TRAD_TYPE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["UNIT_NAME"]), (object)"', "), (object)" '"), rshlp3.Rows[DC_Main.M]["RATE_TYPE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["HSN_CODE"]), (object)"',"), rshlp3.Rows[DC_Main.M]["ITEM_RATE"]), (object)","), rshlp3.Rows[DC_Main.M]["LBR_PRC"]), (object)","), rshlp3.Rows[DC_Main.M]["CON_PRC"]), (object)","), rshlp3.Rows[DC_Main.M]["DISC_PRC"]), (object)","), rshlp3.Rows[DC_Main.M]["IT_TOUCH"]), (object)","), rshlp3.Rows[DC_Main.M]["IT_WEST"]), (object)","), rshlp3.Rows[DC_Main.M]["OTHER_RATE"]), (object)","), rshlp3.Rows[DC_Main.M]["MIN_STK"]), (object)",'"), rshlp3.Rows[DC_Main.M]["MAIN_USER"]), (object)"', "), (object)" "), rshlp3.Rows[DC_Main.M]["AVG_TOUCH"]), (object)","), rshlp3.Rows[DC_Main.M]["AVG_FINE"]), (object)","), rshlp3.Rows[DC_Main.M]["AVG_NWT"]), (object)",'"), rshlp3.Rows[DC_Main.M]["AC_ITEM"]), (object)"','"), rshlp3.Rows[DC_Main.M]["STK_DISPLAY"]), (object)"',"), rshlp3.Rows[DC_Main.M]["OTH_RATE"]), (object)","), rshlp3.Rows[DC_Main.M]["AVG_RATE"]), (object)",'"), rshlp3.Rows[DC_Main.M]["SAFE_NAME"]), (object)"')"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE ITEM_MAST SET DATA_TRFR = 'Y' WHERE CO_CODE = '01' AND IT_CODE = '", rshlp3.Rows[DC_Main.M]["IT_CODE"]), (object)"'"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				rshlp3 = null;
				DC_Main.M++;
				Application.DoEvents();
			}
		}
	}

	public static void CoFieldAdd()
	{
		//IL_2990: Unknown result type (might be due to invalid IL or missing references)
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
				case 13069:
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
							goto IL_002b;
						case 5:
							goto IL_0038;
						case 6:
							goto IL_0045;
						case 7:
							goto IL_005a;
						case 8:
							goto IL_0067;
						case 9:
							goto IL_0074;
						case 10:
							goto IL_0082;
						case 11:
							goto IL_0098;
						case 12:
							goto IL_00a6;
						case 13:
							goto IL_00b4;
						case 14:
							goto IL_00c2;
						case 15:
							goto IL_00d8;
						case 16:
							goto IL_00e6;
						case 17:
							goto IL_00f4;
						case 18:
							goto IL_0102;
						case 19:
							goto IL_0118;
						case 20:
							goto IL_0126;
						case 21:
							goto IL_0134;
						case 22:
							goto IL_0142;
						case 23:
							goto IL_0158;
						case 24:
							goto IL_0166;
						case 25:
							goto IL_0174;
						case 26:
							goto IL_0182;
						case 27:
							goto IL_0198;
						case 28:
							goto IL_01a6;
						case 29:
							goto IL_01b4;
						case 30:
							goto IL_01c2;
						case 31:
							goto IL_01d8;
						case 32:
							goto IL_01e6;
						case 33:
							goto IL_01f4;
						case 34:
							goto IL_020a;
						case 35:
							goto IL_0218;
						case 36:
							goto IL_0226;
						case 37:
							goto IL_0234;
						case 38:
							goto IL_024a;
						case 39:
							goto IL_0258;
						case 40:
							goto IL_0266;
						case 41:
							goto IL_0274;
						case 42:
							goto IL_028a;
						case 43:
							goto IL_0298;
						case 44:
							goto IL_02a6;
						case 45:
							goto IL_02b4;
						case 46:
							goto IL_02ca;
						case 47:
							goto IL_02d8;
						case 48:
							goto IL_02e6;
						case 49:
							goto IL_02f4;
						case 50:
							goto IL_030a;
						case 51:
							goto IL_0318;
						case 52:
							goto IL_0326;
						case 53:
							goto IL_0334;
						case 54:
							goto IL_034a;
						case 55:
							goto IL_0358;
						case 56:
							goto IL_0366;
						case 57:
							goto IL_0374;
						case 58:
							goto IL_038a;
						case 59:
							goto IL_0398;
						case 60:
							goto IL_03a6;
						case 61:
							goto IL_03b4;
						case 62:
							goto IL_03ca;
						case 63:
							goto IL_03d8;
						case 64:
							goto IL_03e6;
						case 65:
							goto IL_03f4;
						case 66:
							goto IL_040a;
						case 67:
							goto IL_0418;
						case 68:
							goto IL_0426;
						case 69:
							goto IL_0434;
						case 70:
							goto IL_044a;
						case 71:
							goto IL_0458;
						case 72:
							goto IL_0466;
						case 73:
							goto IL_0474;
						case 74:
							goto IL_048a;
						case 75:
							goto IL_0498;
						case 76:
							goto IL_04a6;
						case 77:
							goto IL_04b4;
						case 78:
							goto IL_04ca;
						case 79:
							goto IL_04d8;
						case 80:
							goto IL_04e6;
						case 81:
							goto IL_04f4;
						case 82:
							goto IL_050a;
						case 83:
							goto IL_0518;
						case 84:
							goto IL_0526;
						case 85:
							goto IL_0534;
						case 86:
							goto IL_054a;
						case 87:
							goto IL_0558;
						case 88:
							goto IL_0566;
						case 89:
							goto IL_0574;
						case 90:
							goto IL_058a;
						case 91:
							goto IL_0598;
						case 92:
							goto IL_05a6;
						case 93:
							goto IL_05b4;
						case 94:
							goto IL_05ca;
						case 95:
							goto IL_05d8;
						case 96:
							goto IL_05e6;
						case 97:
							goto IL_05f4;
						case 98:
							goto IL_060a;
						case 99:
							goto IL_0618;
						case 100:
							goto IL_0626;
						case 101:
							goto IL_0634;
						case 102:
							goto IL_064a;
						case 103:
							goto IL_0658;
						case 104:
							goto IL_0666;
						case 105:
							goto IL_0674;
						case 106:
							goto IL_068a;
						case 107:
							goto IL_0698;
						case 108:
							goto IL_06a6;
						case 109:
							goto IL_06b4;
						case 110:
							goto IL_06ca;
						case 111:
							goto IL_06d8;
						case 112:
							goto IL_06e6;
						case 113:
							goto IL_06f4;
						case 114:
							goto IL_070a;
						case 115:
							goto IL_0718;
						case 116:
							goto IL_0726;
						case 117:
							goto IL_0734;
						case 118:
							goto IL_074a;
						case 119:
							goto IL_0758;
						case 120:
							goto IL_0766;
						case 121:
							goto IL_0774;
						case 122:
							goto IL_078a;
						case 123:
							goto IL_0798;
						case 124:
							goto IL_07a6;
						case 125:
							goto IL_07b4;
						case 126:
							goto IL_07ca;
						case 127:
							goto IL_07d8;
						case 128:
							goto IL_07e6;
						case 129:
							goto IL_07f7;
						case 130:
							goto IL_0810;
						case 131:
							goto IL_0821;
						case 132:
							goto IL_0832;
						case 133:
							goto IL_0843;
						case 134:
							goto IL_085c;
						case 135:
							goto IL_086d;
						case 136:
							goto IL_087e;
						case 137:
							goto IL_088f;
						case 138:
							goto IL_08a8;
						case 139:
							goto IL_08b9;
						case 140:
							goto IL_08ca;
						case 141:
							goto IL_08db;
						case 142:
							goto IL_08f4;
						case 143:
							goto IL_0905;
						case 144:
							goto IL_0916;
						case 145:
							goto IL_0927;
						case 146:
							goto IL_0940;
						case 147:
							goto IL_0951;
						case 148:
							goto IL_0961;
						case 149:
							goto IL_0972;
						case 150:
							goto IL_0991;
						case 151:
							goto IL_09a6;
						case 152:
							goto IL_09c4;
						case 153:
							goto IL_09e3;
						case 154:
						case 155:
							goto IL_09f6;
						case 156:
							goto IL_0a07;
						case 157:
							goto IL_0a18;
						case 158:
							goto IL_0a31;
						case 159:
							goto IL_0a42;
						case 160:
							goto IL_0a53;
						case 161:
							goto IL_0a64;
						case 162:
							goto IL_0a7d;
						case 163:
							goto IL_0a8e;
						case 164:
							goto IL_0a9f;
						case 165:
							goto IL_0ab0;
						case 166:
							goto IL_0ac9;
						case 167:
							goto IL_0ada;
						case 168:
							goto IL_0aeb;
						case 169:
							goto IL_0afc;
						case 170:
							goto IL_0b15;
						case 171:
							goto IL_0b26;
						case 172:
							goto IL_0b37;
						case 173:
							goto IL_0b48;
						case 174:
							goto IL_0b61;
						case 175:
							goto IL_0b72;
						case 176:
							goto IL_0b83;
						case 177:
							goto IL_0b94;
						case 178:
							goto IL_0ba5;
						case 179:
							goto IL_0bb6;
						case 180:
							goto IL_0bcf;
						case 181:
							goto IL_0be0;
						case 182:
							goto IL_0bf1;
						case 183:
							goto IL_0c02;
						case 184:
							goto IL_0c1b;
						case 185:
							goto IL_0c2c;
						case 186:
							goto IL_0c3d;
						case 187:
							goto IL_0c4e;
						case 188:
							goto IL_0c67;
						case 189:
							goto IL_0c78;
						case 190:
							goto IL_0c89;
						case 191:
							goto IL_0c9a;
						case 192:
							goto IL_0cb3;
						case 193:
							goto IL_0cc4;
						case 194:
							goto IL_0cd5;
						case 195:
							goto IL_0ce6;
						case 196:
							goto IL_0cff;
						case 197:
							goto IL_0d10;
						case 198:
							goto IL_0d21;
						case 199:
							goto IL_0d32;
						case 200:
							goto IL_0d4b;
						case 201:
							goto IL_0d5c;
						case 202:
							goto IL_0d6d;
						case 203:
							goto IL_0d7e;
						case 204:
							goto IL_0d97;
						case 205:
							goto IL_0da8;
						case 206:
							goto IL_0db9;
						case 207:
							goto IL_0dca;
						case 208:
							goto IL_0de3;
						case 209:
							goto IL_0df4;
						case 210:
							goto IL_0e05;
						case 211:
							goto IL_0e16;
						case 212:
							goto IL_0e2f;
						case 213:
							goto IL_0e40;
						case 214:
							goto IL_0e51;
						case 215:
							goto IL_0e62;
						case 216:
							goto IL_0e7b;
						case 217:
							goto IL_0e8c;
						case 218:
							goto IL_0e9d;
						case 219:
							goto IL_0eae;
						case 220:
							goto IL_0ec7;
						case 221:
							goto IL_0ed8;
						case 222:
							goto IL_0ee9;
						case 223:
							goto IL_0efa;
						case 224:
							goto IL_0f13;
						case 225:
							goto IL_0f24;
						case 226:
							goto IL_0f35;
						case 227:
							goto IL_0f46;
						case 228:
							goto IL_0f57;
						case 229:
							goto IL_0f68;
						case 230:
							goto IL_0f79;
						case 231:
							goto IL_0f8a;
						case 232:
							goto IL_0f9b;
						case 233:
							goto IL_0fac;
						case 234:
							goto IL_0fc5;
						case 235:
							goto IL_0fd6;
						case 236:
							goto IL_0fe7;
						case 237:
							goto IL_0ff8;
						case 238:
							goto IL_1011;
						case 239:
							goto IL_1022;
						case 240:
							goto IL_1033;
						case 241:
							goto IL_1044;
						case 242:
							goto IL_105d;
						case 243:
							goto IL_106e;
						case 244:
							goto IL_107f;
						case 245:
							goto IL_1090;
						case 246:
							goto IL_10a9;
						case 247:
							goto IL_10ba;
						case 248:
							goto IL_10cb;
						case 249:
							goto IL_10dc;
						case 250:
							goto IL_10f5;
						case 251:
							goto IL_1106;
						case 252:
							goto IL_1117;
						case 253:
							goto IL_1128;
						case 254:
							goto IL_1141;
						case 255:
							goto IL_1152;
						case 256:
							goto IL_1163;
						case 257:
							goto IL_1174;
						case 258:
							goto IL_118d;
						case 259:
							goto IL_119e;
						case 260:
							goto IL_11af;
						case 261:
							goto IL_11c0;
						case 262:
							goto IL_11d1;
						case 263:
							goto IL_11e2;
						case 264:
							goto IL_11f3;
						case 265:
							goto IL_1204;
						case 266:
							goto IL_1215;
						case 267:
							goto IL_1226;
						case 268:
							goto IL_1237;
						case 269:
							goto IL_1248;
						case 270:
							goto IL_1259;
						case 271:
							goto IL_126a;
						case 272:
							goto IL_127b;
						case 273:
							goto IL_128c;
						case 274:
							goto IL_129d;
						case 275:
							goto IL_12ae;
						case 276:
							goto IL_12c7;
						case 277:
							goto IL_12d8;
						case 278:
							goto IL_12e9;
						case 279:
							goto IL_1302;
						case 280:
							goto IL_1313;
						case 281:
							goto IL_1324;
						case 282:
							goto IL_1335;
						case 283:
							goto IL_1346;
						case 284:
							goto IL_1357;
						case 285:
							goto IL_1368;
						case 286:
							goto IL_1379;
						case 287:
							goto IL_138a;
						case 288:
							goto IL_139b;
						case 289:
							goto IL_13ac;
						case 290:
							goto IL_13bd;
						case 291:
							goto IL_13ce;
						case 292:
							goto IL_13df;
						case 293:
							goto IL_13f0;
						case 294:
							goto IL_1401;
						case 295:
							goto IL_1412;
						case 296:
							goto IL_1423;
						case 297:
							goto IL_1434;
						case 298:
							goto IL_1445;
						case 299:
							goto IL_1456;
						case 300:
							goto IL_1467;
						case 301:
							goto IL_1478;
						case 302:
							goto IL_1489;
						case 303:
							goto IL_149a;
						case 304:
							goto IL_14ab;
						case 305:
							goto IL_14bc;
						case 306:
							goto IL_14cd;
						case 307:
							goto IL_14de;
						case 308:
							goto IL_14ef;
						case 309:
							goto IL_1500;
						case 310:
							goto IL_1511;
						case 311:
							goto IL_1522;
						case 312:
							goto IL_1533;
						case 313:
							goto IL_1544;
						case 314:
							goto IL_1555;
						case 315:
							goto IL_1566;
						case 316:
							goto IL_1577;
						case 317:
							goto IL_1588;
						case 318:
							goto IL_1599;
						case 319:
							goto IL_15aa;
						case 320:
							goto IL_15bb;
						case 321:
							goto IL_15cc;
						case 322:
							goto IL_15dd;
						case 323:
							goto IL_15ee;
						case 324:
							goto IL_15ff;
						case 325:
							goto IL_1610;
						case 326:
							goto IL_1621;
						case 327:
							goto IL_1632;
						case 328:
							goto IL_1643;
						case 329:
							goto IL_1654;
						case 330:
							goto IL_1665;
						case 331:
							goto IL_1676;
						case 332:
							goto IL_1687;
						case 333:
							goto IL_1698;
						case 334:
							goto IL_16a9;
						case 335:
							goto IL_16ba;
						case 336:
							goto IL_16d3;
						case 337:
							goto IL_16e4;
						case 338:
							goto IL_16f5;
						case 339:
							goto IL_170e;
						case 340:
							goto IL_171f;
						case 341:
							goto IL_1730;
						case 342:
							goto IL_1749;
						case 343:
							goto IL_175a;
						case 344:
							goto IL_176b;
						case 345:
							goto IL_1784;
						case 346:
							goto IL_1795;
						case 347:
							goto IL_17a6;
						case 348:
							goto IL_17b7;
						case 349:
							goto IL_17c8;
						case 350:
							goto IL_17d9;
						case 351:
							goto IL_17ea;
						case 352:
							goto IL_17fb;
						case 353:
							goto IL_180c;
						case 354:
							goto IL_181d;
						case 355:
							goto IL_182e;
						case 356:
							goto IL_183f;
						case 357:
							goto IL_1850;
						case 358:
							goto IL_1861;
						case 359:
							goto IL_1872;
						case 360:
							goto IL_1883;
						case 361:
							goto IL_1894;
						case 362:
							goto IL_18a5;
						case 363:
							goto IL_18b6;
						case 364:
							goto IL_18c7;
						case 365:
							goto IL_18d8;
						case 366:
							goto IL_18e9;
						case 367:
							goto IL_18fa;
						case 368:
							goto IL_190b;
						case 369:
							goto IL_191c;
						case 370:
							goto IL_192d;
						case 371:
							goto IL_193e;
						case 372:
							goto IL_194f;
						case 373:
							goto IL_1960;
						case 374:
							goto IL_1971;
						case 375:
							goto IL_1982;
						case 376:
							goto IL_1993;
						case 377:
							goto IL_19a4;
						case 378:
							goto IL_19b5;
						case 379:
							goto IL_19c6;
						case 380:
							goto IL_19d7;
						case 381:
							goto IL_19e8;
						case 382:
							goto IL_19f9;
						case 383:
							goto IL_1a0a;
						case 384:
							goto IL_1a1b;
						case 385:
							goto IL_1a2c;
						case 386:
							goto IL_1a3d;
						case 387:
							goto IL_1a4e;
						case 388:
							goto IL_1a5f;
						case 389:
							goto IL_1a70;
						case 390:
							goto IL_1a81;
						case 391:
							goto IL_1a9a;
						case 392:
							goto IL_1aab;
						case 393:
							goto IL_1abc;
						case 394:
							goto IL_1ad5;
						case 395:
							goto IL_1ae6;
						case 396:
							goto IL_1af7;
						case 397:
							goto IL_1b08;
						case 398:
							goto IL_1b19;
						case 399:
							goto IL_1b2a;
						case 400:
							goto IL_1b3b;
						case 401:
							goto IL_1b4c;
						case 402:
							goto IL_1b5d;
						case 403:
							goto IL_1b6e;
						case 404:
							goto IL_1b7f;
						case 405:
							goto IL_1b90;
						case 406:
							goto IL_1ba9;
						case 407:
							goto IL_1bba;
						case 408:
							goto IL_1bcb;
						case 409:
							goto IL_1be4;
						case 410:
							goto IL_1bf5;
						case 411:
							goto IL_1c06;
						case 412:
							goto IL_1c1f;
						case 413:
							goto IL_1c30;
						case 414:
							goto IL_1c41;
						case 415:
							goto IL_1c52;
						case 416:
							goto IL_1c63;
						case 417:
							goto IL_1c74;
						case 418:
							goto IL_1c85;
						case 419:
							goto IL_1c96;
						case 420:
							goto IL_1ca7;
						case 421:
							goto IL_1cb8;
						case 422:
							goto IL_1cc9;
						case 423:
							goto IL_1cda;
						case 424:
							goto IL_1ceb;
						case 425:
							goto IL_1cfc;
						case 426:
							goto IL_1d0d;
						case 427:
							goto IL_1d1e;
						case 428:
							goto IL_1d2f;
						case 429:
							goto IL_1d40;
						case 430:
							goto IL_1d51;
						case 431:
							goto IL_1d62;
						case 432:
							goto IL_1d7b;
						case 433:
							goto IL_1d8c;
						case 434:
							goto IL_1d9d;
						case 435:
							goto IL_1dae;
						case 436:
							goto IL_1dbf;
						case 437:
							goto IL_1dd8;
						case 438:
							goto IL_1de9;
						case 439:
							goto IL_1dfa;
						case 440:
							goto IL_1e0b;
						case 441:
							goto IL_1e1c;
						case 442:
							goto IL_1e2d;
						case 443:
							goto IL_1e3e;
						case 444:
							goto IL_1e4f;
						case 445:
							goto IL_1e60;
						case 446:
							goto IL_1e71;
						case 447:
							goto IL_1e82;
						case 448:
							goto IL_1e93;
						case 449:
							goto IL_1ea4;
						case 450:
							goto IL_1ebd;
						case 451:
							goto IL_1ece;
						case 452:
							goto IL_1edf;
						case 453:
							goto IL_1ef8;
						case 454:
							goto IL_1f09;
						case 455:
							goto IL_1f1a;
						case 456:
							goto IL_1f2b;
						case 457:
							goto IL_1f3c;
						case 458:
							goto IL_1f4d;
						case 459:
							goto IL_1f5e;
						case 460:
							goto IL_1f6f;
						case 461:
							goto IL_1f88;
						case 462:
							goto IL_1f99;
						case 463:
							goto IL_1faa;
						case 464:
							goto IL_1fc3;
						case 465:
							goto IL_1fd4;
						case 466:
							goto IL_1fe5;
						case 467:
							goto IL_1ffe;
						case 468:
							goto IL_200f;
						case 469:
							goto IL_2020;
						case 470:
							goto IL_2039;
						case 471:
							goto IL_204a;
						case 472:
							goto IL_205b;
						case 473:
							goto IL_206c;
						case 474:
							goto IL_2085;
						case 475:
							goto IL_2096;
						case 476:
							goto IL_20a7;
						case 477:
							goto IL_20c0;
						case 478:
							goto IL_20d1;
						case 479:
							goto IL_20e2;
						case 480:
							goto IL_20f3;
						case 481:
							goto IL_2104;
						case 482:
							goto IL_2115;
						case 483:
							goto IL_2126;
						case 484:
							goto IL_2137;
						case 485:
							goto IL_2148;
						case 486:
							goto IL_2159;
						case 487:
							goto IL_216a;
						case 488:
							goto IL_217b;
						case 489:
							goto IL_218c;
						case 490:
							goto IL_219d;
						case 491:
							goto IL_21b6;
						case 492:
							goto IL_21c7;
						case 493:
							goto IL_21d8;
						case 494:
							goto IL_21e9;
						case 495:
							goto IL_21fa;
						case 496:
							goto IL_220b;
						case 497:
							goto IL_2224;
						case 498:
							goto IL_2235;
						case 499:
							goto IL_2246;
						case 500:
							goto IL_2257;
						case 501:
							goto IL_2270;
						case 502:
							goto IL_2281;
						case 503:
							goto IL_2292;
						case 504:
							goto IL_22ab;
						case 505:
							goto IL_22bc;
						case 506:
							goto IL_22cd;
						case 507:
							goto IL_22e6;
						case 508:
							goto IL_22f7;
						case 509:
							goto IL_2308;
						case 510:
							goto IL_2321;
						case 511:
							goto IL_2332;
						case 512:
							goto IL_2343;
						case 513:
							goto IL_235c;
						case 514:
							goto IL_236d;
						case 515:
							goto IL_237e;
						case 516:
							goto IL_2397;
						case 517:
							goto IL_23a8;
						case 518:
							goto IL_23b9;
						case 519:
							goto IL_23d2;
						case 520:
							goto IL_23e3;
						case 521:
							goto IL_23f4;
						case 522:
							goto IL_240d;
						case 523:
							goto IL_241e;
						case 524:
							goto IL_242f;
						case 525:
							goto IL_2448;
						case 526:
							goto IL_2459;
						case 527:
							goto IL_246a;
						case 528:
							goto IL_2483;
						case 529:
							goto IL_2494;
						case 530:
							goto IL_24a5;
						case 531:
							goto IL_24b6;
						case 532:
							goto IL_24c7;
						case 533:
							goto IL_24d8;
						case 534:
							goto IL_24f1;
						case 535:
							goto IL_2502;
						case 536:
							goto IL_2513;
						case 537:
							goto IL_252c;
						case 538:
							goto IL_253d;
						case 539:
							goto IL_254e;
						case 540:
							goto IL_2567;
						case 541:
							goto IL_2578;
						case 542:
							goto IL_2589;
						case 543:
							goto IL_25a2;
						case 544:
							goto IL_25b3;
						case 545:
							goto IL_25c4;
						case 546:
							goto IL_25dd;
						case 547:
							goto IL_25ee;
						case 548:
							goto IL_25ff;
						case 549:
							goto IL_2610;
						case 550:
							goto IL_2629;
						case 551:
							goto IL_263a;
						case 552:
							goto IL_264b;
						case 553:
							goto IL_2664;
						case 554:
							goto IL_2675;
						case 555:
							goto IL_2686;
						case 556:
							goto IL_2697;
						case 557:
							goto IL_26a8;
						case 558:
							goto IL_26b9;
						case 559:
							goto IL_26d2;
						case 560:
							goto IL_26e3;
						case 561:
							goto IL_26f4;
						case 562:
							goto IL_270d;
						case 563:
							goto IL_271e;
						case 564:
							goto IL_272f;
						case 565:
							goto IL_2740;
						case 566:
							goto IL_2759;
						case 567:
							goto IL_276a;
						case 568:
							goto IL_277b;
						case 569:
							goto IL_2794;
						case 570:
							goto IL_27a5;
						case 571:
							goto IL_27b6;
						case 572:
							goto IL_27cf;
						case 573:
							goto IL_27e0;
						case 574:
							goto IL_27f1;
						case 575:
							goto IL_280a;
						case 576:
							goto IL_281b;
						case 577:
							goto IL_282c;
						case 578:
							goto IL_2845;
						case 579:
							goto IL_2856;
						case 580:
							goto IL_2867;
						case 581:
							goto IL_2880;
						case 582:
							goto IL_2891;
						case 583:
							goto IL_28a2;
						case 584:
							goto IL_28bb;
						case 585:
							goto IL_28cc;
						case 586:
							goto IL_28dd;
						case 587:
							goto IL_28f6;
						case 588:
							goto IL_2907;
						case 589:
							goto IL_2918;
						case 590:
							goto IL_2931;
						case 591:
							goto IL_2942;
						case 592:
							goto IL_2953;
						case 593:
							goto IL_2964;
						case 594:
							goto IL_2983;
						case 595:
						case 596:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 597:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_2953:
					num2 = 592;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD RENDOM_WITH_PRCODE VARCHAR(1)Not NULL DEFAULT 'Y'");
					goto IL_2964;
					IL_2964:
					num2 = 593;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "HM530NEHP", false) == 0)
					{
						break;
					}
					goto IL_2983;
					IL_2942:
					num2 = 591;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD RENDOM_TAG VARCHAR(1)Not NULL DEFAULT 'N'");
					goto IL_2953;
					IL_2983:
					num2 = 594;
					Interaction.MsgBox((object)"New Field is Add....Please Reopen Software and Continue....", (MsgBoxStyle)0, (object)null);
					break;
					IL_000b:
					num2 = 2;
					DC_Main.ExeQuteDc("ALTER TABLE SRNO_MAST ADD IT_CODE VARCHAR(6)");
					goto IL_0018;
					IL_0018:
					num2 = 3;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_002b;
					}
					goto IL_0038;
					IL_002b:
					num2 = 4;
					DC_Main.Dc.Close();
					goto IL_0038;
					IL_0038:
					num2 = 5;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD TAG_RPT VARCHAR(1)");
					goto IL_0045;
					IL_0045:
					num2 = 6;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_005a;
					}
					goto IL_0067;
					IL_005a:
					num2 = 7;
					DC_Main.Dc.Close();
					goto IL_0067;
					IL_0067:
					num2 = 8;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET TAG_RPT = 'N' WHERE TAG_RPT IS NULL");
					goto IL_0074;
					IL_0074:
					num2 = 9;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD FINE_STK_TYPE VARCHAR(1)");
					goto IL_0082;
					IL_0082:
					num2 = 10;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0098;
					}
					goto IL_00a6;
					IL_0098:
					num2 = 11;
					DC_Main.Dc.Close();
					goto IL_00a6;
					IL_00a6:
					num2 = 12;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET FINE_STK_TYPE = 'F' WHERE FINE_STK_TYPE IS NULL");
					goto IL_00b4;
					IL_00b4:
					num2 = 13;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD RATE_MAST_OPEN VARCHAR(1)");
					goto IL_00c2;
					IL_00c2:
					num2 = 14;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_00d8;
					}
					goto IL_00e6;
					IL_00d8:
					num2 = 15;
					DC_Main.Dc.Close();
					goto IL_00e6;
					IL_00e6:
					num2 = 16;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET RATE_MAST_OPEN = 'Y' WHERE RATE_MAST_OPEN IS NULL");
					goto IL_00f4;
					IL_00f4:
					num2 = 17;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD LBR_RATE_GEN VARCHAR(1)");
					goto IL_0102;
					IL_0102:
					num2 = 18;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0118;
					}
					goto IL_0126;
					IL_0118:
					num2 = 19;
					DC_Main.Dc.Close();
					goto IL_0126;
					IL_0126:
					num2 = 20;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET LBR_RATE_GEN = 'N' WHERE LBR_RATE_GEN IS NULL");
					goto IL_0134;
					IL_0134:
					num2 = 21;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD VB_IMPORT VARCHAR(1)");
					goto IL_0142;
					IL_0142:
					num2 = 22;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0158;
					}
					goto IL_0166;
					IL_0158:
					num2 = 23;
					DC_Main.Dc.Close();
					goto IL_0166;
					IL_0166:
					num2 = 24;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET VB_IMPORT = 'N' WHERE VB_IMPORT IS NULL");
					goto IL_0174;
					IL_0174:
					num2 = 25;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD SL_ROW_CHANGE VARCHAR(1)");
					goto IL_0182;
					IL_0182:
					num2 = 26;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0198;
					}
					goto IL_01a6;
					IL_0198:
					num2 = 27;
					DC_Main.Dc.Close();
					goto IL_01a6;
					IL_01a6:
					num2 = 28;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET SL_ROW_CHANGE = 'N' WHERE SL_ROW_CHANGE IS NULL");
					goto IL_01b4;
					IL_01b4:
					num2 = 29;
					DC_Main.ExeQuteDc("CREATE TABLE HDD_MAST(REF_NO VARCHAR(10))");
					goto IL_01c2;
					IL_01c2:
					num2 = 30;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_01d8;
					}
					goto IL_01e6;
					IL_01d8:
					num2 = 31;
					DC_Main.Dc.Close();
					goto IL_01e6;
					IL_01e6:
					num2 = 32;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD DHRN_INT_TYPE VARCHAR(1)");
					goto IL_01f4;
					IL_01f4:
					num2 = 33;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_020a;
					}
					goto IL_0218;
					IL_020a:
					num2 = 34;
					DC_Main.Dc.Close();
					goto IL_0218;
					IL_0218:
					num2 = 35;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET DHRN_INT_TYPE = 'M' WHERE DHRN_INT_TYPE IS NULL");
					goto IL_0226;
					IL_0226:
					num2 = 36;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD INT_YEAR_DAYS FLOAT Not NULL DEFAULT 0");
					goto IL_0234;
					IL_0234:
					num2 = 37;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_024a;
					}
					goto IL_0258;
					IL_024a:
					num2 = 38;
					DC_Main.Dc.Close();
					goto IL_0258;
					IL_0258:
					num2 = 39;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET INT_YEAR_DAYS = 360 WHERE INT_YEAR_DAYS IS NULL");
					goto IL_0266;
					IL_0266:
					num2 = 40;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD OP_DHRN VARCHAR(1)");
					goto IL_0274;
					IL_0274:
					num2 = 41;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_028a;
					}
					goto IL_0298;
					IL_028a:
					num2 = 42;
					DC_Main.Dc.Close();
					goto IL_0298;
					IL_0298:
					num2 = 43;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET OP_DHRN = 'Y' WHERE OP_DHRN IS NULL");
					goto IL_02a6;
					IL_02a6:
					num2 = 44;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD INT_DAY VARCHAR(1)");
					goto IL_02b4;
					IL_02b4:
					num2 = 45;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_02ca;
					}
					goto IL_02d8;
					IL_02ca:
					num2 = 46;
					DC_Main.Dc.Close();
					goto IL_02d8;
					IL_02d8:
					num2 = 47;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET INT_DAY = '1' WHERE INT_DAY IS NULL");
					goto IL_02e6;
					IL_02e6:
					num2 = 48;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD HELP_SERCH VARCHAR(1)");
					goto IL_02f4;
					IL_02f4:
					num2 = 49;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_030a;
					}
					goto IL_0318;
					IL_030a:
					num2 = 50;
					DC_Main.Dc.Close();
					goto IL_0318;
					IL_0318:
					num2 = 51;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET HELP_SERCH = 'S' WHERE HELP_SERCH IS NULL");
					goto IL_0326;
					IL_0326:
					num2 = 52;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD WEIGHT_PORT VARCHAR(7)");
					goto IL_0334;
					IL_0334:
					num2 = 53;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_034a;
					}
					goto IL_0358;
					IL_034a:
					num2 = 54;
					DC_Main.Dc.Close();
					goto IL_0358;
					IL_0358:
					num2 = 55;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET WEIGHT_PORT = '0' WHERE WEIGHT_PORT IS NULL");
					goto IL_0366;
					IL_0366:
					num2 = 56;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD LDR_SUMM VARCHAR(7)");
					goto IL_0374;
					IL_0374:
					num2 = 57;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_038a;
					}
					goto IL_0398;
					IL_038a:
					num2 = 58;
					DC_Main.Dc.Close();
					goto IL_0398;
					IL_0398:
					num2 = 59;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET LDR_SUMM = 'N' WHERE LDR_SUMM IS NULL");
					goto IL_03a6;
					IL_03a6:
					num2 = 60;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD SL_AMT_TYPE VARCHAR(1)");
					goto IL_03b4;
					IL_03b4:
					num2 = 61;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_03ca;
					}
					goto IL_03d8;
					IL_03ca:
					num2 = 62;
					DC_Main.Dc.Close();
					goto IL_03d8;
					IL_03d8:
					num2 = 63;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET SL_AMT_TYPE = 'N' WHERE SL_AMT_TYPE IS NULL");
					goto IL_03e6;
					IL_03e6:
					num2 = 64;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD SMS_LINK VARCHAR(3)");
					goto IL_03f4;
					IL_03f4:
					num2 = 65;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_040a;
					}
					goto IL_0418;
					IL_040a:
					num2 = 66;
					DC_Main.Dc.Close();
					goto IL_0418;
					IL_0418:
					num2 = 67;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET SMS_LINK = '001' WHERE SMS_LINK IS NULL");
					goto IL_0426;
					IL_0426:
					num2 = 68;
					DC_Main.ExeQuteDc("ALTER TABLE ITEM_MAST ADD STK_DISPLAY VARCHAR(1)");
					goto IL_0434;
					IL_0434:
					num2 = 69;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_044a;
					}
					goto IL_0458;
					IL_044a:
					num2 = 70;
					DC_Main.Dc.Close();
					goto IL_0458;
					IL_0458:
					num2 = 71;
					DC_Main.ExeQuteDc("UPDATE ITEM_MAST SET STK_DISPLAY = 'Y' WHERE STK_DISPLAY IS NULL");
					goto IL_0466;
					IL_0466:
					num2 = 72;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD OP_LOAN VARCHAR(1)");
					goto IL_0474;
					IL_0474:
					num2 = 73;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_048a;
					}
					goto IL_0498;
					IL_048a:
					num2 = 74;
					DC_Main.Dc.Close();
					goto IL_0498;
					IL_0498:
					num2 = 75;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET OP_LOAN = 'Y' WHERE OP_LOAN IS NULL");
					goto IL_04a6;
					IL_04a6:
					num2 = 76;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD LOAN_INT_TYPE VARCHAR(1)");
					goto IL_04b4;
					IL_04b4:
					num2 = 77;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_04ca;
					}
					goto IL_04d8;
					IL_04ca:
					num2 = 78;
					DC_Main.Dc.Close();
					goto IL_04d8;
					IL_04d8:
					num2 = 79;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET LOAN_INT_TYPE = 'M' WHERE LOAN_INT_TYPE IS NULL");
					goto IL_04e6;
					IL_04e6:
					num2 = 80;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD TRAD_FINE VARCHAR(1)");
					goto IL_04f4;
					IL_04f4:
					num2 = 81;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_050a;
					}
					goto IL_0518;
					IL_050a:
					num2 = 82;
					DC_Main.Dc.Close();
					goto IL_0518;
					IL_0518:
					num2 = 83;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET TRAD_FINE = 'N' WHERE TRAD_FINE IS NULL");
					goto IL_0526;
					IL_0526:
					num2 = 84;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD LBR_ROF FLOAT Not NULL DEFAULT 0");
					goto IL_0534;
					IL_0534:
					num2 = 85;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_054a;
					}
					goto IL_0558;
					IL_054a:
					num2 = 86;
					DC_Main.Dc.Close();
					goto IL_0558;
					IL_0558:
					num2 = 87;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET LBR_ROF = 0 WHERE LBR_ROF IS NULL");
					goto IL_0566;
					IL_0566:
					num2 = 88;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD REMINDER_OPEN VARCHAR(1)");
					goto IL_0574;
					IL_0574:
					num2 = 89;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_058a;
					}
					goto IL_0598;
					IL_058a:
					num2 = 90;
					DC_Main.Dc.Close();
					goto IL_0598;
					IL_0598:
					num2 = 91;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET REMINDER_OPEN = 'N' WHERE REMINDER_OPEN IS NULL");
					goto IL_05a6;
					IL_05a6:
					num2 = 92;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD ITM_RATE_ROF FLOAT Not NULL DEFAULT 0");
					goto IL_05b4;
					IL_05b4:
					num2 = 93;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_05ca;
					}
					goto IL_05d8;
					IL_05ca:
					num2 = 94;
					DC_Main.Dc.Close();
					goto IL_05d8;
					IL_05d8:
					num2 = 95;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET ITM_RATE_ROF = 0 WHERE ITM_RATE_ROF IS NULL");
					goto IL_05e6;
					IL_05e6:
					num2 = 96;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD ADMIN_SMS VARCHAR(1)");
					goto IL_05f4;
					IL_05f4:
					num2 = 97;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_060a;
					}
					goto IL_0618;
					IL_060a:
					num2 = 98;
					DC_Main.Dc.Close();
					goto IL_0618;
					IL_0618:
					num2 = 99;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET ADMIN_SMS = 'N' WHERE ADMIN_SMS IS NULL");
					goto IL_0626;
					IL_0626:
					num2 = 100;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD CUST_SMS VARCHAR(1)");
					goto IL_0634;
					IL_0634:
					num2 = 101;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_064a;
					}
					goto IL_0658;
					IL_064a:
					num2 = 102;
					DC_Main.Dc.Close();
					goto IL_0658;
					IL_0658:
					num2 = 103;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET CUST_SMS = 'N' WHERE CUST_SMS IS NULL");
					goto IL_0666;
					IL_0666:
					num2 = 104;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD PURC_WITH_LBR VARCHAR(1)");
					goto IL_0674;
					IL_0674:
					num2 = 105;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_068a;
					}
					goto IL_0698;
					IL_068a:
					num2 = 106;
					DC_Main.Dc.Close();
					goto IL_0698;
					IL_0698:
					num2 = 107;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET PURC_WITH_LBR = 'Y' WHERE PURC_WITH_LBR IS NULL");
					goto IL_06a6;
					IL_06a6:
					num2 = 108;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD DHIRN_COMPOUND VARCHAR(1)");
					goto IL_06b4;
					IL_06b4:
					num2 = 109;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_06ca;
					}
					goto IL_06d8;
					IL_06ca:
					num2 = 110;
					DC_Main.Dc.Close();
					goto IL_06d8;
					IL_06d8:
					num2 = 111;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET DHIRN_COMPOUND = 'Y' WHERE DHIRN_COMPOUND IS NULL");
					goto IL_06e6;
					IL_06e6:
					num2 = 112;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD GRID_SCROLL VARCHAR(1)");
					goto IL_06f4;
					IL_06f4:
					num2 = 113;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_070a;
					}
					goto IL_0718;
					IL_070a:
					num2 = 114;
					DC_Main.Dc.Close();
					goto IL_0718;
					IL_0718:
					num2 = 115;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET GRID_SCROLL = 'Y' WHERE GRID_SCROLL IS NULL");
					goto IL_0726;
					IL_0726:
					num2 = 116;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD STK_RPT_TYPE VARCHAR(1)");
					goto IL_0734;
					IL_0734:
					num2 = 117;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_074a;
					}
					goto IL_0758;
					IL_074a:
					num2 = 118;
					DC_Main.Dc.Close();
					goto IL_0758;
					IL_0758:
					num2 = 119;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET STK_RPT_TYPE = 'N' WHERE STK_RPT_TYPE IS NULL");
					goto IL_0766;
					IL_0766:
					num2 = 120;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD TOUCH_AUTO_SAVE VARCHAR(1)");
					goto IL_0774;
					IL_0774:
					num2 = 121;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_078a;
					}
					goto IL_0798;
					IL_078a:
					num2 = 122;
					DC_Main.Dc.Close();
					goto IL_0798;
					IL_0798:
					num2 = 123;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET TOUCH_AUTO_SAVE = 'N' WHERE TOUCH_AUTO_SAVE IS NULL");
					goto IL_07a6;
					IL_07a6:
					num2 = 124;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD PAN_CARD_VAL FLOAT Not NULL DEFAULT 200000");
					goto IL_07b4;
					IL_07b4:
					num2 = 125;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_07ca;
					}
					goto IL_07d8;
					IL_07ca:
					num2 = 126;
					DC_Main.Dc.Close();
					goto IL_07d8;
					IL_07d8:
					num2 = 127;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET PAN_CARD_VAL = 200000 WHERE PAN_CARD_VAL Is NULL");
					goto IL_07e6;
					IL_07e6:
					num2 = 128;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD DHRN_PRC FLOAT Not NULL DEFAULT 2");
					goto IL_07f7;
					IL_07f7:
					num2 = 129;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0810;
					}
					goto IL_0821;
					IL_0810:
					num2 = 130;
					DC_Main.Dc.Close();
					goto IL_0821;
					IL_0821:
					num2 = 131;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET DHRN_PRC = 2 WHERE DHRN_PRC Is NULL");
					goto IL_0832;
					IL_0832:
					num2 = 132;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD DUP_PRINT VARCHAR(1)");
					goto IL_0843;
					IL_0843:
					num2 = 133;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_085c;
					}
					goto IL_086d;
					IL_085c:
					num2 = 134;
					DC_Main.Dc.Close();
					goto IL_086d;
					IL_086d:
					num2 = 135;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET DUP_PRINT = 'N' WHERE DUP_PRINT Is NULL");
					goto IL_087e;
					IL_087e:
					num2 = 136;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD TAX_CODE VARCHAR(2)");
					goto IL_088f;
					IL_088f:
					num2 = 137;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_08a8;
					}
					goto IL_08b9;
					IL_08a8:
					num2 = 138;
					DC_Main.Dc.Close();
					goto IL_08b9;
					IL_08b9:
					num2 = 139;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET TAX_CODE = '10' WHERE TAX_CODE Is NULL");
					goto IL_08ca;
					IL_08ca:
					num2 = 140;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD IP_WITH_PC VARCHAR(1)");
					goto IL_08db;
					IL_08db:
					num2 = 141;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_08f4;
					}
					goto IL_0905;
					IL_08f4:
					num2 = 142;
					DC_Main.Dc.Close();
					goto IL_0905;
					IL_0905:
					num2 = 143;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET IP_WITH_PC = 'A' WHERE IP_WITH_PC Is NULL");
					goto IL_0916;
					IL_0916:
					num2 = 144;
					DC_Main.ExeQuteDc("CREATE TABLE CO_SET_NEW(CO_CODE VARCHAR(2) Not NULL DEFAULT '00',COUNTER_STK VARCHAR(1) DEFAULT 'N' PRIMARY KEY (CO_CODE))");
					goto IL_0927;
					IL_0927:
					num2 = 145;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0940;
					}
					goto IL_0951;
					IL_0940:
					num2 = 146;
					DC_Main.Dc.Close();
					goto IL_0951;
					IL_0951:
					num2 = 147;
					DC_Main.RsQry = "INSERT INTO CO_SET_NEW (CO_CODE,COUNTER_STK) VALUES ('00','N')";
					goto IL_0961;
					IL_0961:
					num2 = 148;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_0972;
					IL_0972:
					num2 = 149;
					DC_Main.RsQry = "SELECT CO_CODE FROM CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
					goto IL_0991;
					IL_0991:
					num2 = 150;
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_09a6;
					IL_09a6:
					num2 = 151;
					if (DC_Main.Rshlp.Rows.Count == 0)
					{
						goto IL_09c4;
					}
					goto IL_09f6;
					IL_09c4:
					num2 = 152;
					DC_Main.RsQry = "INSERT INTO CO_SET_NEW (CO_CODE,COUNTER_STK) VALUES ('" + DC_Main.MCo_code + "','N')";
					goto IL_09e3;
					IL_09e3:
					num2 = 153;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_09f6;
					IL_09f6:
					num2 = 155;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET COUNTER_STK = 'N' WHERE COUNTER_STK Is NULL");
					goto IL_0a07;
					IL_0a07:
					num2 = 156;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD ESTMATE_BANK_LOCK VARCHAR(1)");
					goto IL_0a18;
					IL_0a18:
					num2 = 157;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0a31;
					}
					goto IL_0a42;
					IL_0a31:
					num2 = 158;
					DC_Main.Dc.Close();
					goto IL_0a42;
					IL_0a42:
					num2 = 159;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET ESTMATE_BANK_LOCK = 'N' WHERE ESTMATE_BANK_LOCK IS NULL");
					goto IL_0a53;
					IL_0a53:
					num2 = 160;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD OLD_PURC_TOUCH VARCHAR(1)");
					goto IL_0a64;
					IL_0a64:
					num2 = 161;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0a7d;
					}
					goto IL_0a8e;
					IL_0a7d:
					num2 = 162;
					DC_Main.Dc.Close();
					goto IL_0a8e;
					IL_0a8e:
					num2 = 163;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET OLD_PURC_TOUCH = 'N' WHERE OLD_PURC_TOUCH IS NULL");
					goto IL_0a9f;
					IL_0a9f:
					num2 = 164;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD NEGATIVE_STK_SALE VARCHAR(1)");
					goto IL_0ab0;
					IL_0ab0:
					num2 = 165;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0ac9;
					}
					goto IL_0ada;
					IL_0ac9:
					num2 = 166;
					DC_Main.Dc.Close();
					goto IL_0ada;
					IL_0ada:
					num2 = 167;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET NEGATIVE_STK_SALE = 'Y' WHERE NEGATIVE_STK_SALE IS NULL");
					goto IL_0aeb;
					IL_0aeb:
					num2 = 168;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD SL_NWT_LOCK VARCHAR(1)");
					goto IL_0afc;
					IL_0afc:
					num2 = 169;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0b15;
					}
					goto IL_0b26;
					IL_0b15:
					num2 = 170;
					DC_Main.Dc.Close();
					goto IL_0b26;
					IL_0b26:
					num2 = 171;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET SL_NWT_LOCK = 'N' WHERE SL_NWT_LOCK IS NULL");
					goto IL_0b37;
					IL_0b37:
					num2 = 172;
					DC_Main.ExeQuteDc("ALTER TABLE GROUP_MAST ADD RATE_DISPLAY VARCHAR(1)");
					goto IL_0b48;
					IL_0b48:
					num2 = 173;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0b61;
					}
					goto IL_0b72;
					IL_0b61:
					num2 = 174;
					DC_Main.Dc.Close();
					goto IL_0b72;
					IL_0b72:
					num2 = 175;
					DC_Main.ExeQuteDc("UPDATE GROUP_MAST SET RATE_DISPLAY = 'Y' WHERE RATE_DISPLAY Is NULL AND GR_CODE = 'FGL'");
					goto IL_0b83;
					IL_0b83:
					num2 = 176;
					DC_Main.ExeQuteDc("UPDATE GROUP_MAST SET RATE_DISPLAY = 'Y' WHERE RATE_DISPLAY Is NULL AND GR_CODE = 'FSL'");
					goto IL_0b94;
					IL_0b94:
					num2 = 177;
					DC_Main.ExeQuteDc("UPDATE GROUP_MAST SET RATE_DISPLAY = 'N' WHERE RATE_DISPLAY Is NULL");
					goto IL_0ba5;
					IL_0ba5:
					num2 = 178;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD WH_BILL_IMG VARCHAR(1)");
					goto IL_0bb6;
					IL_0bb6:
					num2 = 179;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0bcf;
					}
					goto IL_0be0;
					IL_0bcf:
					num2 = 180;
					DC_Main.Dc.Close();
					goto IL_0be0;
					IL_0be0:
					num2 = 181;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET WH_BILL_IMG = 'N' WHERE WH_BILL_IMG Is NULL");
					goto IL_0bf1;
					IL_0bf1:
					num2 = 182;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD PROFIT_RPT_TYPE VARCHAR(1)");
					goto IL_0c02;
					IL_0c02:
					num2 = 183;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0c1b;
					}
					goto IL_0c2c;
					IL_0c1b:
					num2 = 184;
					DC_Main.Dc.Close();
					goto IL_0c2c;
					IL_0c2c:
					num2 = 185;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET PROFIT_RPT_TYPE = 'F' WHERE PROFIT_RPT_TYPE Is NULL");
					goto IL_0c3d;
					IL_0c3d:
					num2 = 186;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD WEB_IMAGE VARCHAR(1)");
					goto IL_0c4e;
					IL_0c4e:
					num2 = 187;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0c67;
					}
					goto IL_0c78;
					IL_0c67:
					num2 = 188;
					DC_Main.Dc.Close();
					goto IL_0c78;
					IL_0c78:
					num2 = 189;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET WEB_IMAGE = 'N' WHERE WEB_IMAGE Is NULL");
					goto IL_0c89;
					IL_0c89:
					num2 = 190;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD WEB_PATH VARCHAR(50)");
					goto IL_0c9a;
					IL_0c9a:
					num2 = 191;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0cb3;
					}
					goto IL_0cc4;
					IL_0cb3:
					num2 = 192;
					DC_Main.Dc.Close();
					goto IL_0cc4;
					IL_0cc4:
					num2 = 193;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET WEB_PATH = '' WHERE WEB_PATH Is NULL");
					goto IL_0cd5;
					IL_0cd5:
					num2 = 194;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD QR_CODE_GEN VARCHAR(1)");
					goto IL_0ce6;
					IL_0ce6:
					num2 = 195;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0cff;
					}
					goto IL_0d10;
					IL_0cff:
					num2 = 196;
					DC_Main.Dc.Close();
					goto IL_0d10;
					IL_0d10:
					num2 = 197;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET QR_CODE_GEN = 'N' WHERE QR_CODE_GEN Is NULL");
					goto IL_0d21;
					IL_0d21:
					num2 = 198;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD OS_BILL_SMS VARCHAR(1)");
					goto IL_0d32;
					IL_0d32:
					num2 = 199;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0d4b;
					}
					goto IL_0d5c;
					IL_0d4b:
					num2 = 200;
					DC_Main.Dc.Close();
					goto IL_0d5c;
					IL_0d5c:
					num2 = 201;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET OS_BILL_SMS = 'N' WHERE OS_BILL_SMS Is NULL");
					goto IL_0d6d;
					IL_0d6d:
					num2 = 202;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD SL_BILL_IMG VARCHAR(1)");
					goto IL_0d7e;
					IL_0d7e:
					num2 = 203;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0d97;
					}
					goto IL_0da8;
					IL_0d97:
					num2 = 204;
					DC_Main.Dc.Close();
					goto IL_0da8;
					IL_0da8:
					num2 = 205;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET SL_BILL_IMG = 'N' WHERE SL_BILL_IMG Is NULL");
					goto IL_0db9;
					IL_0db9:
					num2 = 206;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD CO_STK_MERGE VARCHAR(1)");
					goto IL_0dca;
					IL_0dca:
					num2 = 207;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0de3;
					}
					goto IL_0df4;
					IL_0de3:
					num2 = 208;
					DC_Main.Dc.Close();
					goto IL_0df4;
					IL_0df4:
					num2 = 209;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET CO_STK_MERGE = 'N' WHERE CO_STK_MERGE Is NULL");
					goto IL_0e05;
					IL_0e05:
					num2 = 210;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD TOT_FINE_STK_TYPE VARCHAR(1)");
					goto IL_0e16;
					IL_0e16:
					num2 = 211;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0e2f;
					}
					goto IL_0e40;
					IL_0e2f:
					num2 = 212;
					DC_Main.Dc.Close();
					goto IL_0e40;
					IL_0e40:
					num2 = 213;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET TOT_FINE_STK_TYPE = 'G' WHERE SL_BILL_IMG Is NULL");
					goto IL_0e51;
					IL_0e51:
					num2 = 214;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD OPBL_TRFR_BTN VARCHAR(1)");
					goto IL_0e62;
					IL_0e62:
					num2 = 215;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0e7b;
					}
					goto IL_0e8c;
					IL_0e7b:
					num2 = 216;
					DC_Main.Dc.Close();
					goto IL_0e8c;
					IL_0e8c:
					num2 = 217;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET OPBL_TRFR_BTN = 'N' WHERE OPBL_TRFR_BTN Is NULL");
					goto IL_0e9d;
					IL_0e9d:
					num2 = 218;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD TAG_VCH_AUTO_SAVE VARCHAR(1)");
					goto IL_0eae;
					IL_0eae:
					num2 = 219;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0ec7;
					}
					goto IL_0ed8;
					IL_0ec7:
					num2 = 220;
					DC_Main.Dc.Close();
					goto IL_0ed8;
					IL_0ed8:
					num2 = 221;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET TAG_VCH_AUTO_SAVE = 'N' WHERE TAG_VCH_AUTO_SAVE Is NULL");
					goto IL_0ee9;
					IL_0ee9:
					num2 = 222;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD DESIGN_HELP VARCHAR(1)");
					goto IL_0efa;
					IL_0efa:
					num2 = 223;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0f13;
					}
					goto IL_0f24;
					IL_0f13:
					num2 = 224;
					DC_Main.Dc.Close();
					goto IL_0f24;
					IL_0f24:
					num2 = 225;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET DESIGN_HELP = 'N' WHERE DESIGN_HELP Is NULL");
					goto IL_0f35;
					IL_0f35:
					num2 = 226;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD SALES_WITH_HMTAX VARCHAR(1)");
					goto IL_0f46;
					IL_0f46:
					num2 = 227;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET SALES_WITH_HMTAX = 'N' WHERE SALES_WITH_HMTAX IS NULL");
					goto IL_0f57;
					IL_0f57:
					num2 = 228;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD TILE_MENU VARCHAR(1)");
					goto IL_0f68;
					IL_0f68:
					num2 = 229;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET TILE_MENU = 'L' WHERE TILE_MENU IS NULL");
					goto IL_0f79;
					IL_0f79:
					num2 = 230;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD STK_RPT_VIEW VARCHAR(3)");
					goto IL_0f8a;
					IL_0f8a:
					num2 = 231;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET STK_RPT_VIEW = 'OLD' WHERE STK_RPT_VIEW IS NULL");
					goto IL_0f9b;
					IL_0f9b:
					num2 = 232;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD PR_RATE_ROF FLOAT Not NULL DEFAULT 2");
					goto IL_0fac;
					IL_0fac:
					num2 = 233;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0fc5;
					}
					goto IL_0fd6;
					IL_0fc5:
					num2 = 234;
					DC_Main.Dc.Close();
					goto IL_0fd6;
					IL_0fd6:
					num2 = 235;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET PR_RATE_ROF = 2 WHERE PR_RATE_ROF IS NULL");
					goto IL_0fe7;
					IL_0fe7:
					num2 = 236;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD LEN_IMG_PATH VARCHAR(250) DEFAULT ''");
					goto IL_0ff8;
					IL_0ff8:
					num2 = 237;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_1011;
					}
					goto IL_1022;
					IL_1011:
					num2 = 238;
					DC_Main.Dc.Close();
					goto IL_1022;
					IL_1022:
					num2 = 239;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET LEN_IMG_PATH = '' WHERE LEN_IMG_PATH IS NULL");
					goto IL_1033;
					IL_1033:
					num2 = 240;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD SL_TDS_TAX VARCHAR(1) DEFAULT 'N'");
					goto IL_1044;
					IL_1044:
					num2 = 241;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_105d;
					}
					goto IL_106e;
					IL_105d:
					num2 = 242;
					DC_Main.Dc.Close();
					goto IL_106e;
					IL_106e:
					num2 = 243;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET SL_TDS_TAX = 'N' WHERE SL_TDS_TAX IS NULL");
					goto IL_107f;
					IL_107f:
					num2 = 244;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD PR_TDS_TAX VARCHAR(1) DEFAULT 'N'");
					goto IL_1090;
					IL_1090:
					num2 = 245;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_10a9;
					}
					goto IL_10ba;
					IL_10a9:
					num2 = 246;
					DC_Main.Dc.Close();
					goto IL_10ba;
					IL_10ba:
					num2 = 247;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET PR_TDS_TAX = 'N' WHERE PR_TDS_TAX IS NULL");
					goto IL_10cb;
					IL_10cb:
					num2 = 248;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD PR_AMT_TYPE VARCHAR(1) DEFAULT 'F'");
					goto IL_10dc;
					IL_10dc:
					num2 = 249;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_10f5;
					}
					goto IL_1106;
					IL_10f5:
					num2 = 250;
					DC_Main.Dc.Close();
					goto IL_1106;
					IL_1106:
					num2 = 251;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET PR_AMT_TYPE = 'F' WHERE PR_AMT_TYPE IS NULL");
					goto IL_1117;
					IL_1117:
					num2 = 252;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD CARD_COM_ADJ VARCHAR(1) DEFAULT 'N'");
					goto IL_1128;
					IL_1128:
					num2 = 253;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_1141;
					}
					goto IL_1152;
					IL_1141:
					num2 = 254;
					DC_Main.Dc.Close();
					goto IL_1152;
					IL_1152:
					num2 = 255;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET CARD_COM_ADJ = 'N' WHERE CARD_COM_ADJ IS NULL");
					goto IL_1163;
					IL_1163:
					num2 = 256;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD OS_FINE_INT VARCHAR(1) DEFAULT 'N'");
					goto IL_1174;
					IL_1174:
					num2 = 257;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_118d;
					}
					goto IL_119e;
					IL_118d:
					num2 = 258;
					DC_Main.Dc.Close();
					goto IL_119e;
					IL_119e:
					num2 = 259;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET OS_FINE_INT = 'N' WHERE OS_FINE_INT IS NULL");
					goto IL_11af;
					IL_11af:
					num2 = 260;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD PURC_WITH_HMTAX VARCHAR(1)");
					goto IL_11c0;
					IL_11c0:
					num2 = 261;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET PURC_WITH_HMTAX = 'N' WHERE PURC_WITH_HMTAX IS NULL");
					goto IL_11d1;
					IL_11d1:
					num2 = 262;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD SL_TAG_WT_DIFF VARCHAR(1) DEFAULT 'N'");
					goto IL_11e2;
					IL_11e2:
					num2 = 263;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET SL_TAG_WT_DIFF = 'N' WHERE SL_TAG_WT_DIFF IS NULL");
					goto IL_11f3;
					IL_11f3:
					num2 = 264;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD COUNTRY_ID VARCHAR(3) DEFAULT '91'");
					goto IL_1204;
					IL_1204:
					num2 = 265;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET COUNTRY_ID = '91' WHERE COUNTRY_ID IS NULL");
					goto IL_1215;
					IL_1215:
					num2 = 266;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD WAPP_SL_PRINT VARCHAR(1) DEFAULT 'N'");
					goto IL_1226;
					IL_1226:
					num2 = 267;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET WAPP_SL_PRINT = 'N' WHERE WAPP_SL_PRINT IS NULL");
					goto IL_1237;
					IL_1237:
					num2 = 268;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD BILL_PROFIT VARCHAR(1) DEFAULT 'N'");
					goto IL_1248;
					IL_1248:
					num2 = 269;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET BILL_PROFIT = 'N' WHERE BILL_PROFIT IS NULL");
					goto IL_1259;
					IL_1259:
					num2 = 270;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD BILL_PROFIT VARCHAR(1) DEFAULT 'N'");
					goto IL_126a;
					IL_126a:
					num2 = 271;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET BILL_PROFIT = 'N' WHERE BILL_PROFIT IS NULL");
					goto IL_127b;
					IL_127b:
					num2 = 272;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD OLD_GOLD_TYPE VARCHAR(1) DEFAULT 'N'");
					goto IL_128c;
					IL_128c:
					num2 = 273;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET OLD_GOLD_TYPE = 'N' WHERE OLD_GOLD_TYPE IS NULL");
					goto IL_129d;
					IL_129d:
					num2 = 274;
					DC_Main.ExeQuteDc("CREATE TABLE POINT_MAST(CO_CODE VARCHAR(2),POINT_CODE VARCHAR(2),SR_NO FLOAT Not NULL DEFAULT 0,POINT_NAME VARCHAR(30),POINT_TYPE VARCHAR(1),  FIX_POINT FLOAT Not NULL DEFAULT 0,SL_AMT FLOAT Not NULL DEFAULT 0,SL_POINT FLOAT Not NULL DEFAULT 0,POINT_AMT FLOAT Not NULL DEFAULT 0,MIN_POINT FLOAT Not NULL DEFAULT 0,GRM_POINT FLOAT Not NULL DEFAULT 0,  MAIN_USER VARCHAR(15),DATA_TRFR VARCHAR(1) DEFAULT 'N'  PRIMARY KEY (CO_CODE,POINT_CODE,SR_NO))");
					goto IL_12ae;
					IL_12ae:
					num2 = 275;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_12c7;
					}
					goto IL_12d8;
					IL_12c7:
					num2 = 276;
					DC_Main.Dc.Close();
					goto IL_12d8;
					IL_12d8:
					num2 = 277;
					DC_Main.ExeQuteDc("ALTER TABLE POINT_MAST ADD CUR_IN_USE VARCHAR(1)");
					goto IL_12e9;
					IL_12e9:
					num2 = 278;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_1302;
					}
					goto IL_1313;
					IL_1302:
					num2 = 279;
					DC_Main.Dc.Close();
					goto IL_1313;
					IL_1313:
					num2 = 280;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD TAG_ENTRY_DESIGN_GEN VARCHAR(1) DEFAULT 'N'");
					goto IL_1324;
					IL_1324:
					num2 = 281;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET TAG_ENTRY_DESIGN_GEN = 'N' WHERE TAG_ENTRY_DESIGN_GEN IS NULL");
					goto IL_1335;
					IL_1335:
					num2 = 282;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD ORD_IMG_PRINT VARCHAR(1) DEFAULT 'N'");
					goto IL_1346;
					IL_1346:
					num2 = 283;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET ORD_IMG_PRINT = 'N' WHERE ORD_IMG_PRINT IS NULL");
					goto IL_1357;
					IL_1357:
					num2 = 284;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD OS_BILL_ORNA_ISU VARCHAR(1) DEFAULT 'Y'");
					goto IL_1368;
					IL_1368:
					num2 = 285;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET OS_BILL_ORNA_ISU = 'Y' WHERE OS_BILL_ORNA_ISU IS NULL");
					goto IL_1379;
					IL_1379:
					num2 = 286;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD PURC_LOT VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_138a;
					IL_138a:
					num2 = 287;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET PURC_LOT = 'N' WHERE PURC_LOT IS NULL");
					goto IL_139b;
					IL_139b:
					num2 = 288;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD MOBILE_HELP VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_13ac;
					IL_13ac:
					num2 = 289;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET MOBILE_HELP = 'N' WHERE MOBILE_HELP IS NULL");
					goto IL_13bd;
					IL_13bd:
					num2 = 290;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD CASH_PURC_AC VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_13ce;
					IL_13ce:
					num2 = 291;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET CASH_PURC_AC = 'N' WHERE CASH_PURC_AC IS NULL");
					goto IL_13df;
					IL_13df:
					num2 = 292;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD PRINT_FORM_BTN VARCHAR(1) Not NULL DEFAULT 'E'");
					goto IL_13f0;
					IL_13f0:
					num2 = 293;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET PRINT_FORM_BTN = 'E' WHERE CASH_PURC_AC IS NULL");
					goto IL_1401;
					IL_1401:
					num2 = 294;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD EMP_CODE_MANDATORY VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_1412;
					IL_1412:
					num2 = 295;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET EMP_CODE_MANDATORY = 'N' WHERE EMP_CODE_MANDATORY IS NULL");
					goto IL_1423;
					IL_1423:
					num2 = 296;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD FONT_CHANGE VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_1434;
					IL_1434:
					num2 = 297;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET FONT_CHANGE = 'N' WHERE FONT_CHANGE IS NULL");
					goto IL_1445;
					IL_1445:
					num2 = 298;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD FONT_SIZE FLOAT Not NULL Default 11");
					goto IL_1456;
					IL_1456:
					num2 = 299;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set FONT_SIZE = 11 WHERE FONT_SIZE Is NULL");
					goto IL_1467;
					IL_1467:
					num2 = 300;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD FONT_NAME VARCHAR(25) Not NULL DEFAULT 'Calibri'");
					goto IL_1478;
					IL_1478:
					num2 = 301;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET FONT_NAME = 'Calibri' WHERE FONT_NAME IS NULL");
					goto IL_1489;
					IL_1489:
					num2 = 302;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD FONT_STYLE_TYPE INTEGER Not NULL Default 0");
					goto IL_149a;
					IL_149a:
					num2 = 303;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set FONT_STYLE_TYPE = 1 WHERE FONT_STYLE_TYPE Is NULL");
					goto IL_14ab;
					IL_14ab:
					num2 = 304;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD GRID_ROW_HIGHT INTEGER Not NULL Default 20");
					goto IL_14bc;
					IL_14bc:
					num2 = 305;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set GRID_ROW_HIGHT = 25 WHERE GRID_ROW_HIGHT Is NULL");
					goto IL_14cd;
					IL_14cd:
					num2 = 306;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD STOCK_RPT_TYPE VARCHAR(3) Not NULL DEFAULT 'OLD'");
					goto IL_14de;
					IL_14de:
					num2 = 307;
					DC_Main.ExeQuteDc("UPDATE CO_SET SET STOCK_RPT_TYPE = 'OLD' WHERE FONT_NAME IS NULL");
					goto IL_14ef;
					IL_14ef:
					num2 = 308;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD LAST_DAY_LOCK VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_1500;
					IL_1500:
					num2 = 309;
					DC_Main.ExeQuteDc("UPDATE CO_SET Set LAST_DAY_LOCK = 'N' WHERE LAST_DAY_LOCK Is NULL");
					goto IL_1511;
					IL_1511:
					num2 = 310;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD CASH_LIMIT FLOAT Not NULL Default 0");
					goto IL_1522;
					IL_1522:
					num2 = 311;
					DC_Main.ExeQuteDc("UPDATE CO_SET Set CASH_LIMIT = 0 WHERE CASH_LIMIT Is NULL");
					goto IL_1533;
					IL_1533:
					num2 = 312;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD TOT_AMT_ROF INTEGER Not NULL DEFAULT 0");
					goto IL_1544;
					IL_1544:
					num2 = 313;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set TOT_AMT_ROF = 0 WHERE TOT_AMT_ROF Is NULL");
					goto IL_1555;
					IL_1555:
					num2 = 314;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD ESTMATE_TAX VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_1566;
					IL_1566:
					num2 = 315;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set ESTMATE_TAX = 'N' WHERE ESTMATE_TAX Is NULL");
					goto IL_1577;
					IL_1577:
					num2 = 316;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD TAG_AUTO_PRINT VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_1588;
					IL_1588:
					num2 = 317;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set TAG_AUTO_PRINT = 'N' WHERE TAG_AUTO_PRINT Is NULL");
					goto IL_1599;
					IL_1599:
					num2 = 318;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD DHRN_WAPP VARCHAR(1) Not NULL DEFAULT 'N',SCHM_WAPP VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_15aa;
					IL_15aa:
					num2 = 319;
					DC_Main.ExeQuteDc("UPDATE CO_SET Set DHRN_WAPP = CUST_SMS WHERE DHRN_WAPP Is NULL");
					goto IL_15bb;
					IL_15bb:
					num2 = 320;
					DC_Main.ExeQuteDc("UPDATE CO_SET Set SCHM_WAPP = CUST_SMS WHERE SCHM_WAPP Is NULL");
					goto IL_15cc;
					IL_15cc:
					num2 = 321;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD RPT_TOT_SHOW VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_15dd;
					IL_15dd:
					num2 = 322;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set RPT_TOT_SHOW = 'N' WHERE RPT_TOT_SHOW Is NULL");
					goto IL_15ee;
					IL_15ee:
					num2 = 323;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD DEFAULT_REMINDER VARCHAR(1) Not NULL DEFAULT 'R'");
					goto IL_15ff;
					IL_15ff:
					num2 = 324;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set DEFAULT_REMINDER = 'R' WHERE DEFAULT_REMINDER Is NULL");
					goto IL_1610;
					IL_1610:
					num2 = 325;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD VCH_DESC_HELP_LENT INTEGER Not NULL DEFAULT 25");
					goto IL_1621;
					IL_1621:
					num2 = 326;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD ORD_TAG_STK_LESS VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_1632;
					IL_1632:
					num2 = 327;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set ORD_TAG_STK_LESS = 'N' WHERE ORD_TAG_STK_LESS Is NULL");
					goto IL_1643;
					IL_1643:
					num2 = 328;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD BRANCH_ALL_AC_SHOW VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_1654;
					IL_1654:
					num2 = 329;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set BRANCH_ALL_AC_SHOW = 'N' WHERE BRANCH_ALL_AC_SHOW Is NULL");
					goto IL_1665;
					IL_1665:
					num2 = 330;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD SL_MRP_TAX_REVERC VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_1676;
					IL_1676:
					num2 = 331;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set SL_MRP_TAX_REVERC = 'N' WHERE SL_MRP_TAX_REVERC Is NULL");
					goto IL_1687;
					IL_1687:
					num2 = 332;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD EMP_AS_USER VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_1698;
					IL_1698:
					num2 = 333;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set EMP_AS_USER = 'N' WHERE EMP_AS_USER Is NULL");
					goto IL_16a9;
					IL_16a9:
					num2 = 334;
					DC_Main.ExeQuteMc("ALTER TABLE CO_MAST ADD URL_NAME VARCHAR(150) DEFAULT '',URL_ID VARCHAR(50) DEFAULT '',URL_PWD VARCHAR(25) DEFAULT ''");
					goto IL_16ba;
					IL_16ba:
					num2 = 335;
					if (DC_Main.Mc.State == ConnectionState.Open)
					{
						goto IL_16d3;
					}
					goto IL_16e4;
					IL_16d3:
					num2 = 336;
					DC_Main.Mc.Close();
					goto IL_16e4;
					IL_16e4:
					num2 = 337;
					DC_Main.ExeQuteDc("ALTER TABLE CO_MAST ADD URL_NAME VARCHAR(150) DEFAULT '',URL_ID VARCHAR(50) DEFAULT '',URL_PWD VARCHAR(25) DEFAULT ''");
					goto IL_16f5;
					IL_16f5:
					num2 = 338;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_170e;
					}
					goto IL_171f;
					IL_170e:
					num2 = 339;
					DC_Main.Dc.Close();
					goto IL_171f;
					IL_171f:
					num2 = 340;
					DC_Main.ExeQuteMc("ALTER TABLE CO_MAST ADD HTTP_NAME VARCHAR(150) DEFAULT ''");
					goto IL_1730;
					IL_1730:
					num2 = 341;
					if (DC_Main.Mc.State == ConnectionState.Open)
					{
						goto IL_1749;
					}
					goto IL_175a;
					IL_1749:
					num2 = 342;
					DC_Main.Mc.Close();
					goto IL_175a;
					IL_175a:
					num2 = 343;
					DC_Main.ExeQuteDc("ALTER TABLE CO_MAST ADD HTTP_NAME VARCHAR(150) DEFAULT ''");
					goto IL_176b;
					IL_176b:
					num2 = 344;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_1784;
					}
					goto IL_1795;
					IL_1784:
					num2 = 345;
					DC_Main.Dc.Close();
					goto IL_1795;
					IL_1795:
					num2 = 346;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD WAPP_IMG_GWT VARCHAR(1) Not NULL DEFAULT 'Y'");
					goto IL_17a6;
					IL_17a6:
					num2 = 347;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set WAPP_IMG_GWT = 'Y' WHERE WAPP_IMG_GWT Is NULL");
					goto IL_17b7;
					IL_17b7:
					num2 = 348;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD YEAR_GOLD_SL FLOAT Not NULL Default 0,YEAR_SILVER_SL FLOAT Not NULL Default 0");
					goto IL_17c8;
					IL_17c8:
					num2 = 349;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD F_DISC_DATE DATE Not NULL DEFAULT '04-04-2023',T_DISC_DATE DATE Not NULL DEFAULT '04-04-2023'");
					goto IL_17d9;
					IL_17d9:
					num2 = 350;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD DHRN_IMG_PRINT VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_17ea;
					IL_17ea:
					num2 = 351;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD LBR_WITH_GHT VARCHAR(1) Not NULL DEFAULT 'Y'");
					goto IL_17fb;
					IL_17fb:
					num2 = 352;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set LBR_WITH_GHT = 'Y' WHERE LBR_WITH_GHT Is NULL");
					goto IL_180c;
					IL_180c:
					num2 = 353;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD APR_IMG_PRINT VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_181d;
					IL_181d:
					num2 = 354;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set APR_IMG_PRINT = 'N' WHERE APR_IMG_PRINT Is NULL");
					goto IL_182e;
					IL_182e:
					num2 = 355;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD OTH_ITM_WT_REMOVE VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_183f;
					IL_183f:
					num2 = 356;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set OTH_ITM_WT_REMOVE = 'N' WHERE OTH_ITM_WT_REMOVE Is NULL");
					goto IL_1850;
					IL_1850:
					num2 = 357;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD SILVER_THREE_DIGIT VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_1861;
					IL_1861:
					num2 = 358;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set SILVER_THREE_DIGIT = 'N' WHERE SILVER_THREE_DIGIT Is NULL");
					goto IL_1872;
					IL_1872:
					num2 = 359;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD LEDR_BILL_COL VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_1883;
					IL_1883:
					num2 = 360;
					DC_Main.ExeQuteDc("UPDATE CO_SET Set LEDR_BILL_COL = 'N' WHERE LEDR_BILL_COL Is NULL");
					goto IL_1894;
					IL_1894:
					num2 = 361;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD ALL_ROF_REMOVE VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_18a5;
					IL_18a5:
					num2 = 362;
					DC_Main.ExeQuteDc("UPDATE CO_SET Set ALL_ROF_REMOVE = 'N' WHERE ALL_ROF_REMOVE Is NULL");
					goto IL_18b6;
					IL_18b6:
					num2 = 363;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD KR_DESIGN_IMG_PRINT VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_18c7;
					IL_18c7:
					num2 = 364;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set KR_DESIGN_IMG_PRINT = 'N' WHERE KR_DESIGN_IMG_PRINT Is NULL");
					goto IL_18d8;
					IL_18d8:
					num2 = 365;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD ITM_WITH_LOT_STK VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_18e9;
					IL_18e9:
					num2 = 366;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set ITM_WITH_LOT_STK = 'N' WHERE ITM_LOT_STOCK Is NULL");
					goto IL_18fa;
					IL_18fa:
					num2 = 367;
					DC_Main.ExeQuteDc("ALTER TABLE APR_DETL ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_190b;
					IL_190b:
					num2 = 368;
					DC_Main.ExeQuteDc("ALTER TABLE BAR_CAN_DETL ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_191c;
					IL_191c:
					num2 = 369;
					DC_Main.ExeQuteDc("ALTER TABLE INOUT_DETL ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_192d;
					IL_192d:
					num2 = 370;
					DC_Main.ExeQuteDc("ALTER TABLE KR_DETL ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_193e;
					IL_193e:
					num2 = 371;
					DC_Main.ExeQuteDc("ALTER TABLE LBR_ISU_DETL ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_194f;
					IL_194f:
					num2 = 372;
					DC_Main.ExeQuteDc("ALTER TABLE LOT_DETL ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_1960;
					IL_1960:
					num2 = 373;
					DC_Main.ExeQuteDc("ALTER TABLE MLT_DETL ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_1971;
					IL_1971:
					num2 = 374;
					DC_Main.ExeQuteDc("ALTER TABLE PR_DETL ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_1982;
					IL_1982:
					num2 = 375;
					DC_Main.ExeQuteDc("ALTER TABLE RATE_CUT_ISU ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_1993;
					IL_1993:
					num2 = 376;
					DC_Main.ExeQuteDc("ALTER TABLE RATE_CUT_ISU_REC ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_19a4;
					IL_19a4:
					num2 = 377;
					DC_Main.ExeQuteDc("ALTER TABLE RATE_CUT_REC ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_19b5;
					IL_19b5:
					num2 = 378;
					DC_Main.ExeQuteDc("ALTER TABLE REP_DETL ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_19c6;
					IL_19c6:
					num2 = 379;
					DC_Main.ExeQuteDc("ALTER TABLE SL_DETL ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_19d7;
					IL_19d7:
					num2 = 380;
					DC_Main.ExeQuteDc("ALTER TABLE SL_DETL_RTN ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_19e8;
					IL_19e8:
					num2 = 381;
					DC_Main.ExeQuteDc("ALTER TABLE SL_ORD_DETL ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_19f9;
					IL_19f9:
					num2 = 382;
					DC_Main.ExeQuteDc("ALTER TABLE SL_PR_DETL ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_1a0a;
					IL_1a0a:
					num2 = 383;
					DC_Main.ExeQuteDc("ALTER TABLE TAG_DATA ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_1a1b;
					IL_1a1b:
					num2 = 384;
					DC_Main.ExeQuteDc("ALTER TABLE TAG_PRINT_DATA ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_1a2c;
					IL_1a2c:
					num2 = 385;
					DC_Main.ExeQuteDc("ALTER TABLE TAG_STOCK_PRINT ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_1a3d;
					IL_1a3d:
					num2 = 386;
					DC_Main.ExeQuteDc("ALTER TABLE TAG_SUM_DATA ADD ITM_LOT VARCHAR(10) Not NULL DEFAULT ''");
					goto IL_1a4e;
					IL_1a4e:
					num2 = 387;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD USER_KR_TOUCH_HIDE VARCHAR(1) Not NULL DEFAULT 'N'");
					goto IL_1a5f;
					IL_1a5f:
					num2 = 388;
					DC_Main.ExeQuteDc("UPDATE CO_SET_NEW Set USER_KR_TOUCH_HIDE = 'N' WHERE USER_KR_TOUCH_HIDE Is NULL");
					goto IL_1a70;
					IL_1a70:
					num2 = 389;
					DC_Main.ExeQuteMc("ALTER TABLE LOCT_MAST ADD ITEM_DISCOUNT VARCHAR(1)Not NULL DEFAULT 'Y'");
					goto IL_1a81;
					IL_1a81:
					num2 = 390;
					if (DC_Main.Mc.State == ConnectionState.Open)
					{
						goto IL_1a9a;
					}
					goto IL_1aab;
					IL_1a9a:
					num2 = 391;
					DC_Main.Mc.Close();
					goto IL_1aab;
					IL_1aab:
					num2 = 392;
					DC_Main.ExeQuteDc("ALTER TABLE LOCT_MAST ADD ITEM_DISCOUNT VARCHAR(1)Not NULL DEFAULT 'Y'");
					goto IL_1abc;
					IL_1abc:
					num2 = 393;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_1ad5;
					}
					goto IL_1ae6;
					IL_1ad5:
					num2 = 394;
					DC_Main.Dc.Close();
					goto IL_1ae6;
					IL_1ae6:
					num2 = 395;
					DC_Main.ExeQuteMc("UPDATE LOCT_MAST SET ITEM_DISCOUNT = 'Y' WHERE ITEM_DISCOUNT Is NULL");
					goto IL_1af7;
					IL_1af7:
					num2 = 396;
					DC_Main.ExeQuteDc("UPDATE LOCT_MAST SET ITEM_DISCOUNT = 'Y' WHERE ITEM_DISCOUNT Is NULL");
					goto IL_1b08;
					IL_1b08:
					num2 = 397;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD CUR_DAY_POSTING VARCHAR(1)Not NULL DEFAULT 'N'");
					goto IL_1b19;
					IL_1b19:
					num2 = 398;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD MAIN_FONT_CHANGE VARCHAR(1)Not NULL DEFAULT 'N'");
					goto IL_1b2a;
					IL_1b2a:
					num2 = 399;
					DC_Main.ExeQuteDc("ALTER TABLE APR_DETL ADD ISU_LC_CODE VARCHAR(2)Not NULL DEFAULT '00'");
					goto IL_1b3b;
					IL_1b3b:
					num2 = 400;
					DC_Main.ExeQuteDc("ALTER TABLE BAR_DETL ADD ORD_LC_CODE VARCHAR(2)Not NULL DEFAULT '00'");
					goto IL_1b4c;
					IL_1b4c:
					num2 = 401;
					DC_Main.ExeQuteDc("ALTER TABLE AD_DATA ADD WITH_UPI VARCHAR(1)Not NULL DEFAULT 'N'");
					goto IL_1b5d;
					IL_1b5d:
					num2 = 402;
					DC_Main.ExeQuteDc("ALTER TABLE UPI_DATA ADD SCHM_CODE VARCHAR(3)Not NULL DEFAULT '',ISR_NO FLOAT Not NULL Default 0");
					goto IL_1b6e;
					IL_1b6e:
					num2 = 403;
					DC_Main.ExeQuteDc("ALTER TABLE BAR_DETL ADD MFG_YRCD VARCHAR(10)Not NULL DEFAULT '',MFG_DBCD VARCHAR(3)Not NULL DEFAULT '',MFG_NO VARCHAR(10)Not NULL DEFAULT '',MFG_SRNO FLOAT Not NULL Default 0");
					goto IL_1b7f;
					IL_1b7f:
					num2 = 404;
					DC_Main.ExeQuteDc("ALTER TABLE PR_DATA ADD RATE_UNFIX VARCHAR(1)Not NULL DEFAULT 'N'");
					goto IL_1b90;
					IL_1b90:
					num2 = 405;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_1ba9;
					}
					goto IL_1bba;
					IL_1ba9:
					num2 = 406;
					DC_Main.Dc.Close();
					goto IL_1bba;
					IL_1bba:
					num2 = 407;
					DC_Main.ExeQuteDc("ALTER TABLE KR_DATA ADD RATE_UNFIX VARCHAR(1)Not NULL DEFAULT 'N'");
					goto IL_1bcb;
					IL_1bcb:
					num2 = 408;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_1be4;
					}
					goto IL_1bf5;
					IL_1be4:
					num2 = 409;
					DC_Main.Dc.Close();
					goto IL_1bf5;
					IL_1bf5:
					num2 = 410;
					DC_Main.ExeQuteDc("ALTER TABLE BOOK_DATA ADD BOOK_TBL_DETL VARCHAR(25) Not NULL DEFAULT ''");
					goto IL_1c06;
					IL_1c06:
					num2 = 411;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_1c1f;
					}
					goto IL_1c30;
					IL_1c1f:
					num2 = 412;
					DC_Main.Dc.Close();
					goto IL_1c30;
					IL_1c30:
					num2 = 413;
					DC_Main.ExeQuteDc("ALTER TABLE ITM_WT_MAST ADD MIN_LBR_PRC FLOAT Not NULL Default 0");
					goto IL_1c41;
					IL_1c41:
					num2 = 414;
					DC_Main.ExeQuteDc("ALTER TABLE UPI_DATA ADD HD_VCH_NO VARCHAR(10)Not NULL DEFAULT ''");
					goto IL_1c52;
					IL_1c52:
					num2 = 415;
					DC_Main.ExeQuteDc("ALTER TABLE RATE_CUT_REC ADD OLD_VCH_SRNO FLOAT Not NULL Default 0");
					goto IL_1c63;
					IL_1c63:
					num2 = 416;
					DC_Main.ExeQuteDc("ALTER TABLE INOUT_DETL ADD DATA_TYPE VARCHAR(1)Not NULL DEFAULT 'A'");
					goto IL_1c74;
					IL_1c74:
					num2 = 417;
					DC_Main.ExeQuteDc("UPDATE INOUT_DETL SET DATA_TYPE = 'A' WHERE DATA_TYPE Is NULL");
					goto IL_1c85;
					IL_1c85:
					num2 = 418;
					DC_Main.ExeQuteDc("ALTER TABLE BAR_IDTL ADD KR_RATE_TYPE VARCHAR(1)Not NULL DEFAULT '',IT_DISC_PRC FLOAT Not NULL Default 0,IT_DISC_AMT FLOAT Not NULL Default 0");
					goto IL_1c96;
					IL_1c96:
					num2 = 419;
					DC_Main.ExeQuteDc("ALTER TABLE SL_IDTL ADD KR_RATE_TYPE VARCHAR(1)Not NULL DEFAULT '',IT_DISC_PRC FLOAT Not NULL Default 0,IT_DISC_AMT FLOAT Not NULL Default 0");
					goto IL_1ca7;
					IL_1ca7:
					num2 = 420;
					DC_Main.ExeQuteDc("ALTER TABLE SL_ORD_IDTL ADD KR_RATE_TYPE VARCHAR(1)Not NULL DEFAULT '',IT_DISC_PRC FLOAT Not NULL Default 0,IT_DISC_AMT FLOAT Not NULL Default 0");
					goto IL_1cb8;
					IL_1cb8:
					num2 = 421;
					DC_Main.ExeQuteDc("ALTER TABLE APR_IDTL ADD KR_RATE_TYPE VARCHAR(1)Not NULL DEFAULT '',IT_DISC_PRC FLOAT Not NULL Default 0,IT_DISC_AMT FLOAT Not NULL Default 0");
					goto IL_1cc9;
					IL_1cc9:
					num2 = 422;
					DC_Main.ExeQuteDc("ALTER TABLE LBR_ISU_IDTL ADD KR_RATE_TYPE VARCHAR(1)Not NULL DEFAULT '',IT_DISC_PRC FLOAT Not NULL Default 0,IT_DISC_AMT FLOAT Not NULL Default 0");
					goto IL_1cda;
					IL_1cda:
					num2 = 423;
					DC_Main.ExeQuteDc("INSERT INTO COL_MAST(CO_CODE,BOOK_NAME,COL_NAME,COL_NEW_NAME,COL_RPT,YES_NO) VALUES('00','TAG_IDTL','Disc%','Disc%','N','N')");
					goto IL_1ceb;
					IL_1ceb:
					num2 = 424;
					DC_Main.ExeQuteDc("INSERT INTO COL_MAST(CO_CODE,BOOK_NAME,COL_NAME,COL_NEW_NAME,COL_RPT,YES_NO) VALUES('00','TAG_IDTL','DiscAmt','DiscAmt','N','N')");
					goto IL_1cfc;
					IL_1cfc:
					num2 = 425;
					DC_Main.ExeQuteDc("INSERT INTO COL_MAST(CO_CODE,BOOK_NAME,COL_NAME,COL_NEW_NAME,COL_RPT,YES_NO) VALUES('00','TAG_IDTL','KrCon%','KrCon%','N','N')");
					goto IL_1d0d;
					IL_1d0d:
					num2 = 426;
					DC_Main.ExeQuteDc("INSERT INTO COL_MAST(CO_CODE,BOOK_NAME,COL_NAME,COL_NEW_NAME,COL_RPT,YES_NO) VALUES('00','TAG_IDTL','KrP/W','KrP/W','N','N')");
					goto IL_1d1e;
					IL_1d1e:
					num2 = 427;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD STK_LMIT_WITH_DESIGN VARCHAR(1)Not NULL DEFAULT 'N'");
					goto IL_1d2f;
					IL_1d2f:
					num2 = 428;
					DC_Main.ExeQuteDc("ALTER TABLE ITM_WT_MAST ADD IT_DESIGN VARCHAR(20)Not NULL DEFAULT 'N'");
					goto IL_1d40;
					IL_1d40:
					num2 = 429;
					DC_Main.ExeQuteDc("UPDATE ITM_WT_MAST SET IT_DESIGN = 'N' WHERE IT_DESIGN Is NULL");
					goto IL_1d51;
					IL_1d51:
					num2 = 430;
					DC_Main.ExeQuteDc("CREATE TABLE CRNT_DATA(CO_CODE VARCHAR(2),LC_CODE VARCHAR(2),CO_YEAR VARCHAR(10),CO_BOOK VARCHAR(3),VCH_NO VARCHAR(8),SR_NO FLOAT Not NULL DEFAULT 0,VCH_DATE DATE,  HD_VCH_NO VARCHAR(8),AC_CODE VARCHAR(8),AC_NAME VARCHAR(50),VCH_TYPE VARCHAR(5),INOUT_TYPE VARCHAR(1),ENTRY_TYPE VARCHAR(1),BOOK_NAME VARCHAR(30),CRNT_HD_VCH_NO VARCHAR(8), CRNT_NO VARCHAR(8),CRNT_LC VARCHAR(2),CRNT_YRCD VARCHAR(10),CRNT_DBCD VARCHAR(3),CRNT_AC_CODE VARCHAR(10), CRNT_AMT FLOAT Not NULL DEFAULT 0,VCH_TIME DATETIME,  DATA_TRFR VARCHAR(1),EMP_CODE VARCHAR(3),MAIN_USER VARCHAR(15)  PRIMARY KEY (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO))");
					goto IL_1d62;
					IL_1d62:
					num2 = 431;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_1d7b;
					}
					goto IL_1d8c;
					IL_1d7b:
					num2 = 432;
					DC_Main.Dc.Close();
					goto IL_1d8c;
					IL_1d8c:
					num2 = 433;
					DC_Main.ExeQuteDc("ALTER TABLE SL_DATA ADD CRNT_ADJ_AMT FLOAT Not NULL Default 0");
					goto IL_1d9d;
					IL_1d9d:
					num2 = 434;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD ITM_FINE_LOCK VARCHAR(1)Not NULL DEFAULT 'N'");
					goto IL_1dae;
					IL_1dae:
					num2 = 435;
					DC_Main.ExeQuteDc("CREATE TABLE CRNT_DATA(CO_CODE VARCHAR(2),LC_CODE VARCHAR(2),CO_YEAR VARCHAR(10),CO_BOOK VARCHAR(3),VCH_NO VARCHAR(8),SR_NO FLOAT Not NULL DEFAULT 0,VCH_DATE DATE,  HD_VCH_NO VARCHAR(8),AC_CODE VARCHAR(8),AC_NAME VARCHAR(50),VCH_TYPE VARCHAR(5),INOUT_TYPE VARCHAR(1),ENTRY_TYPE VARCHAR(1),BOOK_NAME VARCHAR(30),CRNT_HD_VCH_NO VARCHAR(8), CRNT_NO VARCHAR(8),CRNT_LC VARCHAR(2),CRNT_YRCD VARCHAR(10),CRNT_DBCD VARCHAR(3),CRNT_AC_CODE VARCHAR(10), CRNT_AMT FLOAT Not NULL DEFAULT 0,VCH_TIME DATETIME,  DATA_TRFR VARCHAR(1),EMP_CODE VARCHAR(3),MAIN_USER VARCHAR(15)  PRIMARY KEY (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO))");
					goto IL_1dbf;
					IL_1dbf:
					num2 = 436;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_1dd8;
					}
					goto IL_1de9;
					IL_1dd8:
					num2 = 437;
					DC_Main.Dc.Close();
					goto IL_1de9;
					IL_1de9:
					num2 = 438;
					DC_Main.ExeQuteDc("ALTER TABLE SL_DATA ADD CRNT_ADJ_AMT FLOAT Not NULL Default 0");
					goto IL_1dfa;
					IL_1dfa:
					num2 = 439;
					DC_Main.ExeQuteDc("ALTER TABLE PR_DETL ADD MCX_RATE FLOAT Not NULL Default 0,PRM_AMT FLOAT Not NULL Default 0,PRM_DISC FLOAT Not NULL Default 0");
					goto IL_1e0b;
					IL_1e0b:
					num2 = 440;
					DC_Main.ExeQuteDc("ALTER TABLE KR_DETL ADD MCX_RATE FLOAT Not NULL Default 0,PRM_AMT FLOAT Not NULL Default 0,PRM_DISC FLOAT Not NULL Default 0");
					goto IL_1e1c;
					IL_1e1c:
					num2 = 441;
					DC_Main.ExeQuteDc("ALTER TABLE SL_DETL ADD MCX_RATE FLOAT Not NULL Default 0,PRM_AMT FLOAT Not NULL Default 0,PRM_DISC FLOAT Not NULL Default 0");
					goto IL_1e2d;
					IL_1e2d:
					num2 = 442;
					DC_Main.ExeQuteDc("ALTER TABLE SL_DATA ADD PARTY_FINE FLOAT Not NULL Default 0,IT_TYPE VARCHAR(1)Not NULL DEFAULT ''");
					goto IL_1e3e;
					IL_1e3e:
					num2 = 443;
					DC_Main.ExeQuteDc("ALTER TABLE SL_DATA ADD OZ_RATE FLOAT Not NULL Default 0,OZ_CONV FLOAT Not NULL Default 0,FX_RATE FLOAT Not NULL Default 0,FX_CODE VARCHAR(3)Not NULL DEFAULT '',MTL_RATE FLOAT Not NULL Default 0");
					goto IL_1e4f;
					IL_1e4f:
					num2 = 444;
					DC_Main.ExeQuteDc("ALTER TABLE PR_DATA ADD OZ_RATE FLOAT Not NULL Default 0,OZ_CONV FLOAT Not NULL Default 0,FX_RATE FLOAT Not NULL Default 0,FX_CODE VARCHAR(3)Not NULL DEFAULT '',MTL_RATE FLOAT Not NULL Default 0");
					goto IL_1e60;
					IL_1e60:
					num2 = 445;
					DC_Main.ExeQuteDc("ALTER TABLE KR_DATA ADD OZ_RATE FLOAT Not NULL Default 0,OZ_CONV FLOAT Not NULL Default 0,FX_RATE FLOAT Not NULL Default 0,FX_CODE VARCHAR(3)Not NULL DEFAULT '',MTL_RATE FLOAT Not NULL Default 0");
					goto IL_1e71;
					IL_1e71:
					num2 = 446;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET ADD OZ_CON_VAL FLOAT Not NULL Default 31.1035,FX_RATE FLOAT Not NULL Default 87,FX_CODE VARCHAR(3)Not NULL DEFAULT 'INR'");
					goto IL_1e82;
					IL_1e82:
					num2 = 447;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD PRINT_ZOOM FLOAT Not NULL Default 110");
					goto IL_1e93;
					IL_1e93:
					num2 = 448;
					DC_Main.ExeQuteDc("ALTER TABLE CUT_DETL ADD FINE_TYPE VARCHAR(1)Not NULL DEFAULT ''");
					goto IL_1ea4;
					IL_1ea4:
					num2 = 449;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_1ebd;
					}
					goto IL_1ece;
					IL_1ebd:
					num2 = 450;
					DC_Main.Dc.Close();
					goto IL_1ece;
					IL_1ece:
					num2 = 451;
					DC_Main.ExeQuteDc("ALTER TABLE CUT_DATA ADD FINE_TYPE VARCHAR(1)Not NULL DEFAULT ''");
					goto IL_1edf;
					IL_1edf:
					num2 = 452;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_1ef8;
					}
					goto IL_1f09;
					IL_1ef8:
					num2 = 453;
					DC_Main.Dc.Close();
					goto IL_1f09;
					IL_1f09:
					num2 = 454;
					DC_Main.ExeQuteDc("ALTER TABLE DM_DATA ADD MAIN_IT_CODE VARCHAR(5)Not NULL DEFAULT '',INOUT_TYPE VARCHAR(1)Not NULL DEFAULT ''");
					goto IL_1f1a;
					IL_1f1a:
					num2 = 455;
					DC_Main.ExeQuteDc("ALTER TABLE AD_DATA ADD UPI_NAME VARCHAR(225)Not NULL DEFAULT ''");
					goto IL_1f2b;
					IL_1f2b:
					num2 = 456;
					DC_Main.ExeQuteDc("ALTER TABLE AD_OS ADD UPI_NAME VARCHAR(225)Not NULL DEFAULT ''");
					goto IL_1f3c;
					IL_1f3c:
					num2 = 457;
					DC_Main.ExeQuteDc("ALTER TABLE DM_DATA ADD TBL_CODE VARCHAR(3)Not NULL DEFAULT ''");
					goto IL_1f4d;
					IL_1f4d:
					num2 = 458;
					DC_Main.ExeQuteDc("ALTER TABLE SL_DETL ADD TAX_RVRS VARCHAR(1)Not NULL DEFAULT 'N'");
					goto IL_1f5e;
					IL_1f5e:
					num2 = 459;
					DC_Main.ExeQuteDc("CREATE TABLE USER_REQUEST(CO_CODE VARCHAR(2),LC_CODE VARCHAR(2),CO_YEAR VARCHAR(9),CO_BOOK VARCHAR(3),VCH_NO VARCHAR(8),VCH_DATE DATE,AC_CODE VARCHAR(10),AC_NAME VARCHAR(50),  TOT_AMT FLOAT Not NULL DEFAULT 0,TOT_FINE FLOAT Not NULL DEFAULT 0,ITM_TYPE VARCHAR(1),EMP_CODE VARCHAR(5),USER_NAME VARCHAR(15),EDIT_USER VARCHAR(15),EDIT_RMARK VARCHAR(255)  PRIMARY KEY (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO))");
					goto IL_1f6f;
					IL_1f6f:
					num2 = 460;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_1f88;
					}
					goto IL_1f99;
					IL_1f88:
					num2 = 461;
					DC_Main.Dc.Close();
					goto IL_1f99;
					IL_1f99:
					num2 = 462;
					DC_Main.ExeQuteDc("ALTER TABLE USER_REQUEST ADD REQ_TIME DATETIME");
					goto IL_1faa;
					IL_1faa:
					num2 = 463;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_1fc3;
					}
					goto IL_1fd4;
					IL_1fc3:
					num2 = 464;
					DC_Main.Dc.Close();
					goto IL_1fd4;
					IL_1fd4:
					num2 = 465;
					DC_Main.ExeQuteDc("ALTER TABLE USER_REQUEST ADD REQ_TYPE VARCHAR(1) Not NULL DEFAULT 'E'");
					goto IL_1fe5;
					IL_1fe5:
					num2 = 466;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_1ffe;
					}
					goto IL_200f;
					IL_1ffe:
					num2 = 467;
					DC_Main.Dc.Close();
					goto IL_200f;
					IL_200f:
					num2 = 468;
					DC_Main.ExeQuteDc("ALTER TABLE USER_REQUEST ADD PARMATION_TYPE VARCHAR(1) Not NULL DEFAULT 'P' ");
					goto IL_2020;
					IL_2020:
					num2 = 469;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_2039;
					}
					goto IL_204a;
					IL_2039:
					num2 = 470;
					DC_Main.Dc.Close();
					goto IL_204a;
					IL_204a:
					num2 = 471;
					DC_Main.ExeQuteDc("ALTER TABLE ITEM_MAST ADD TAX_FREE_ITEM VARCHAR(1)Not NULL DEFAULT 'N'");
					goto IL_205b;
					IL_205b:
					num2 = 472;
					DC_Main.ExeQuteDc("ALTER TABLE SL_DATA ADD ZERO_RATED_AMT FLOAT Not NULL Default 0");
					goto IL_206c;
					IL_206c:
					num2 = 473;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_2085;
					}
					goto IL_2096;
					IL_2085:
					num2 = 474;
					DC_Main.Dc.Close();
					goto IL_2096;
					IL_2096:
					num2 = 475;
					DC_Main.ExeQuteDc("ALTER TABLE TAX_DATA ADD ZERO_RATED_AMT FLOAT Not NULL Default 0");
					goto IL_20a7;
					IL_20a7:
					num2 = 476;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_20c0;
					}
					goto IL_20d1;
					IL_20c0:
					num2 = 477;
					DC_Main.Dc.Close();
					goto IL_20d1;
					IL_20d1:
					num2 = 478;
					DC_Main.ExeQuteDc("ALTER TABLE RATE_CUT_REC ADD ITM_STYLE VARCHAR(50)Not NULL DEFAULT ''");
					goto IL_20e2;
					IL_20e2:
					num2 = 479;
					DC_Main.ExeQuteDc("ALTER TABLE LBR_ISU_DETL ADD SL_TYPE VARCHAR(1)Not NULL DEFAULT 'N',KR_OTH_RATE FLOAT Not NULL Default 0,KR_OTH_FINE FLOAT Not NULL Default 0,KR_TOT_FINE FLOAT Not NULL Default 0,KR_GWT_TOUCH FLOAT Not NULL Default 0");
					goto IL_20f3;
					IL_20f3:
					num2 = 480;
					DC_Main.ExeQuteDc("ALTER TABLE LBR_REC_DETL ADD SL_TYPE VARCHAR(1)Not NULL DEFAULT 'N',KR_OTH_RATE FLOAT Not NULL Default 0,KR_OTH_FINE FLOAT Not NULL Default 0,KR_TOT_FINE FLOAT Not NULL Default 0,KR_GWT_TOUCH FLOAT Not NULL Default 0");
					goto IL_2104;
					IL_2104:
					num2 = 481;
					DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_NAME = 'Tag Estimate' WHERE MAIN_SRNO = '05' AND SM_MAIN_NAME = 'Tag Estmate'");
					goto IL_2115;
					IL_2115:
					num2 = 482;
					DC_Main.ExeQuteDc("ALTER TABLE AC_MAST ADD TRN_DATE DATE,CUST_ID_DATE DATE");
					goto IL_2126;
					IL_2126:
					num2 = 483;
					DC_Main.ExeQuteMc("ALTER TABLE CO_MAST ADD MAIL_API VARCHAR(100)Not NULL DEFAULT ''");
					goto IL_2137;
					IL_2137:
					num2 = 484;
					DC_Main.ExeQuteDc("ALTER TABLE CO_MAST ADD MAIL_API VARCHAR(100)Not NULL DEFAULT ''");
					goto IL_2148;
					IL_2148:
					num2 = 485;
					DC_Main.ExeQuteDc("ALTER TABLE PR_DETL ADD RATE_WITH VARCHAR(1)Not NULL DEFAULT 'F'");
					goto IL_2159;
					IL_2159:
					num2 = 486;
					DC_Main.ExeQuteDc("ALTER TABLE KR_DETL ADD RATE_WITH VARCHAR(1)Not NULL DEFAULT 'F'");
					goto IL_216a;
					IL_216a:
					num2 = 487;
					DC_Main.ExeQuteDc("ALTER TABLE TAX_MAST ADD INPUT_TAX_AC VARCHAR(10)Not NULL DEFAULT ''");
					goto IL_217b;
					IL_217b:
					num2 = 488;
					DC_Main.ExeQuteDc("ALTER TABLE SL_DETL_RTN ADD RATE_WITH VARCHAR(1)Not NULL DEFAULT 'N'");
					goto IL_218c;
					IL_218c:
					num2 = 489;
					DC_Main.ExeQuteDc("ALTER TABLE SL_PR_DETL ADD PR_COST FLOAT Not NULL Default 0");
					goto IL_219d;
					IL_219d:
					num2 = 490;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_21b6;
					}
					goto IL_21c7;
					IL_21b6:
					num2 = 491;
					DC_Main.Dc.Close();
					goto IL_21c7;
					IL_21c7:
					num2 = 492;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD CRYSTAL_RPT VARCHAR(1)Not NULL DEFAULT 'O'");
					goto IL_21d8;
					IL_21d8:
					num2 = 493;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD WAPP_API VARCHAR(MAX)Not NULL DEFAULT ''");
					goto IL_21e9;
					IL_21e9:
					num2 = 494;
					DC_Main.ExeQuteDc("ALTER TABLE CO_SET_NEW ADD WAPP_API_MOBILE VARCHAR(25)Not NULL DEFAULT '',WAPP_API_ID VARCHAR(25)Not NULL DEFAULT ''");
					goto IL_21fa;
					IL_21fa:
					num2 = 495;
					DC_Main.ExeQuteDc("CREATE TABLE REMARK_DATA(CO_CODE VARCHAR(2),LC_CODE VARCHAR(2),CO_YEAR VARCHAR(10),CO_BOOK VARCHAR(3),VCH_NO VARCHAR(8),SR_NO FLOAT Not NULL DEFAULT 0,VCH_DATE DATE,  AC_CODE VARCHAR(10),AC_NAME VARCHAR(50),MAIN_BOOK VARCHAR(30)Not NULL DEFAULT '',VCH_REMARK VARCHAR(250)Not NULL DEFAULT ''  PRIMARY KEY (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO))");
					goto IL_220b;
					IL_220b:
					num2 = 496;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_2224;
					}
					goto IL_2235;
					IL_2224:
					num2 = 497;
					DC_Main.Dc.Close();
					goto IL_2235;
					IL_2235:
					num2 = 498;
					DC_Main.ExeQuteDc("ALTER TABLE REMARK_DATA ADD VCH_DATE DATE");
					goto IL_2246;
					IL_2246:
					num2 = 499;
					DC_Main.ExeQuteDc("ALTER TABLE BAR_DETL ADD EMP_CODE VARCHAR(3)Not NULL DEFAULT ''");
					goto IL_2257;
					IL_2257:
					num2 = 500;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_2270;
					}
					goto IL_2281;
					IL_2270:
					num2 = 501;
					DC_Main.Dc.Close();
					goto IL_2281;
					IL_2281:
					num2 = 502;
					DC_Main.ExeQuteDc("ALTER TABLE PR_DETL ADD ITM_LOT VARCHAR(10)Not NULL DEFAULT ''");
					goto IL_2292;
					IL_2292:
					num2 = 503;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_22ab;
					}
					goto IL_22bc;
					IL_22ab:
					num2 = 504;
					DC_Main.Dc.Close();
					goto IL_22bc;
					IL_22bc:
					num2 = 505;
					DC_Main.ExeQuteDc("ALTER TABLE KR_DETL ADD ITM_LOT VARCHAR(10)Not NULL DEFAULT ''");
					goto IL_22cd;
					IL_22cd:
					num2 = 506;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_22e6;
					}
					goto IL_22f7;
					IL_22e6:
					num2 = 507;
					DC_Main.Dc.Close();
					goto IL_22f7;
					IL_22f7:
					num2 = 508;
					DC_Main.ExeQuteDc("ALTER TABLE MFG_IDTL ADD ITM_LOT VARCHAR(10)Not NULL DEFAULT ''");
					goto IL_2308;
					IL_2308:
					num2 = 509;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_2321;
					}
					goto IL_2332;
					IL_2321:
					num2 = 510;
					DC_Main.Dc.Close();
					goto IL_2332;
					IL_2332:
					num2 = 511;
					DC_Main.ExeQuteDc("ALTER TABLE TOUCH_MAST ADD EMP_COM_PRC FLOAT Not NULL Default 0");
					goto IL_2343;
					IL_2343:
					num2 = 512;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_235c;
					}
					goto IL_236d;
					IL_235c:
					num2 = 513;
					DC_Main.Dc.Close();
					goto IL_236d;
					IL_236d:
					num2 = 514;
					DC_Main.ExeQuteDc("ALTER TABLE TOUCH_MAST ADD AC_MEMB_COM_PRC FLOAT Not NULL Default 0");
					goto IL_237e;
					IL_237e:
					num2 = 515;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_2397;
					}
					goto IL_23a8;
					IL_2397:
					num2 = 516;
					DC_Main.Dc.Close();
					goto IL_23a8;
					IL_23a8:
					num2 = 517;
					DC_Main.ExeQuteDc("ALTER TABLE ITEM_MAST ADD AC_MEMB_COM_PRC FLOAT Not NULL Default 0");
					goto IL_23b9;
					IL_23b9:
					num2 = 518;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_23d2;
					}
					goto IL_23e3;
					IL_23d2:
					num2 = 519;
					DC_Main.Dc.Close();
					goto IL_23e3;
					IL_23e3:
					num2 = 520;
					DC_Main.ExeQuteDc("ALTER TABLE SL_DATA ADD AC_MEMB_COM_PRC FLOAT Not NULL Default 0,AC_MEMB_COM_VAL FLOAT Not NULL Default 0,RTN_MEMB_COM_PRC FLOAT Not NULL Default 0,RTN_MEMB_COM_VAL FLOAT Not NULL Default 0");
					goto IL_23f4;
					IL_23f4:
					num2 = 521;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_240d;
					}
					goto IL_241e;
					IL_240d:
					num2 = 522;
					DC_Main.Dc.Close();
					goto IL_241e;
					IL_241e:
					num2 = 523;
					DC_Main.ExeQuteDc("ALTER TABLE SL_DETL ADD AC_MEMB_COM_PRC FLOAT Not NULL Default 0,AC_MEMB_COM_VAL FLOAT Not NULL Default 0");
					goto IL_242f;
					IL_242f:
					num2 = 524;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_2448;
					}
					goto IL_2459;
					IL_2448:
					num2 = 525;
					DC_Main.Dc.Close();
					goto IL_2459;
					IL_2459:
					num2 = 526;
					DC_Main.ExeQuteDc("ALTER TABLE SL_DETL_RTN ADD AC_MEMB_COM_PRC FLOAT Not NULL Default 0,AC_MEMB_COM_VAL FLOAT Not NULL Default 0");
					goto IL_246a;
					IL_246a:
					num2 = 527;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_2483;
					}
					goto IL_2494;
					IL_2483:
					num2 = 528;
					DC_Main.Dc.Close();
					goto IL_2494;
					IL_2494:
					num2 = 529;
					DC_Main.ExeQuteDc("ALTER TABLE AC_MAST ADD AC_WITH_MEMB_COM VARCHAR(1)Not NULL DEFAULT 'N'");
					goto IL_24a5;
					IL_24a5:
					num2 = 530;
					DC_Main.ExeQuteDc("ALTER TABLE SL_DATA ADD MEMB_COM_AC_CODE VARCHAR(10)Not NULL DEFAULT ''");
					goto IL_24b6;
					IL_24b6:
					num2 = 531;
					DC_Main.ExeQuteDc("ALTER TABLE MFG_ISU_REC ADD ITM_LOT VARCHAR(10)Not NULL DEFAULT ''");
					goto IL_24c7;
					IL_24c7:
					num2 = 532;
					DC_Main.ExeQuteDc("ALTER TABLE SL_DETL ADD FIX_WEST_PRC FLOAT Not NULL Default 0");
					goto IL_24d8;
					IL_24d8:
					num2 = 533;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_24f1;
					}
					goto IL_2502;
					IL_24f1:
					num2 = 534;
					DC_Main.Dc.Close();
					goto IL_2502;
					IL_2502:
					num2 = 535;
					DC_Main.ExeQuteDc("ALTER TABLE RATE_CUT_ISU ADD FIX_WEST_PRC FLOAT Not NULL Default 0");
					goto IL_2513;
					IL_2513:
					num2 = 536;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_252c;
					}
					goto IL_253d;
					IL_252c:
					num2 = 537;
					DC_Main.Dc.Close();
					goto IL_253d;
					IL_253d:
					num2 = 538;
					DC_Main.ExeQuteDc("ALTER TABLE RATE_CUT_ISU_REC ADD FIX_WEST_PRC FLOAT Not NULL Default 0");
					goto IL_254e;
					IL_254e:
					num2 = 539;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_2567;
					}
					goto IL_2578;
					IL_2567:
					num2 = 540;
					DC_Main.Dc.Close();
					goto IL_2578;
					IL_2578:
					num2 = 541;
					DC_Main.ExeQuteDc("ALTER TABLE ITEM_MAST ADD ITM_FIX_GHT_PRC FLOAT Not NULL Default 0,ITM_FIX_WEST_PRC FLOAT Not NULL Default 0");
					goto IL_2589;
					IL_2589:
					num2 = 542;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_25a2;
					}
					goto IL_25b3;
					IL_25a2:
					num2 = 543;
					DC_Main.Dc.Close();
					goto IL_25b3;
					IL_25b3:
					num2 = 544;
					DC_Main.ExeQuteDc("ALTER TABLE MAIN_STOCK ADD ITM_DISC FLOAT Not NULL Default 0");
					goto IL_25c4;
					IL_25c4:
					num2 = 545;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_25dd;
					}
					goto IL_25ee;
					IL_25dd:
					num2 = 546;
					DC_Main.Dc.Close();
					goto IL_25ee;
					IL_25ee:
					num2 = 547;
					DC_Main.ExeQuteDc("ALTER TABLE AC_MAST ADD LCS_NO VARCHAR(15)Not NULL DEFAULT ''");
					goto IL_25ff;
					IL_25ff:
					num2 = 548;
					DC_Main.ExeQuteDc("ALTER TABLE COMM_DATA ADD COM_GHT FLOAT Not NULL Default 0,MEMB_AC_CODE VARCHAR(10)Not NULL DEFAULT '',AC_CITY VARCHAR(20)Not NULL DEFAULT '',AC_AREA VARCHAR(25)Not NULL DEFAULT ''");
					goto IL_2610;
					IL_2610:
					num2 = 549;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_2629;
					}
					goto IL_263a;
					IL_2629:
					num2 = 550;
					DC_Main.Dc.Close();
					goto IL_263a;
					IL_263a:
					num2 = 551;
					DC_Main.ExeQuteDc("ALTER TABLE COMM_DATA ADD IT_CODE VARCHAR(5)Not NULL DEFAULT '',ITM_TOUCH FLOAT Not NULL Default 0");
					goto IL_264b;
					IL_264b:
					num2 = 552;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_2664;
					}
					goto IL_2675;
					IL_2664:
					num2 = 553;
					DC_Main.Dc.Close();
					goto IL_2675;
					IL_2675:
					num2 = 554;
					DC_Main.ExeQuteDc("ALTER TABLE AC_MAST ADD AC_SHARE_HOLDER_COM VARCHAR(1)Not NULL DEFAULT 'N'");
					goto IL_2686;
					IL_2686:
					num2 = 555;
					DC_Main.ExeQuteDc("ALTER TABLE SL_DATA ADD WHOUT_COMM_BILL VARCHAR(1)Not NULL DEFAULT 'N'");
					goto IL_2697;
					IL_2697:
					num2 = 556;
					DC_Main.ExeQuteDc("ALTER TABLE DHRN_REC_DETL ADD PACKET_RE_ISU VARCHAR(1)Not NULL DEFAULT 'N'");
					goto IL_26a8;
					IL_26a8:
					num2 = 557;
					DC_Main.ExeQuteDc("ALTER TABLE MFG_DETL ADD ORD_PCS FLOAT Not NULL Default 0,ORD_GWT FLOAT Not NULL Default 0,ORD_OTH_WT FLOAT Not NULL Default 0,ORD_NWT FLOAT Not NULL Default 0");
					goto IL_26b9;
					IL_26b9:
					num2 = 558;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_26d2;
					}
					goto IL_26e3;
					IL_26d2:
					num2 = 559;
					DC_Main.Dc.Close();
					goto IL_26e3;
					IL_26e3:
					num2 = 560;
					DC_Main.ExeQuteDc("ALTER TABLE BAR_CAN_DETL ADD OLD_MRP FLOAT Not NULL Default 0,MRP_MARGIN FLOAT Not NULL Default 0");
					goto IL_26f4;
					IL_26f4:
					num2 = 561;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_270d;
					}
					goto IL_271e;
					IL_270d:
					num2 = 562;
					DC_Main.Dc.Close();
					goto IL_271e;
					IL_271e:
					num2 = 563;
					DC_Main.ExeQuteDc("ALTER TABLE BAR_IDTL ADD HD_VCH_NO VARCHAR(10)DEFAULT ''");
					goto IL_272f;
					IL_272f:
					num2 = 564;
					DC_Main.ExeQuteDc("ALTER TABLE PR_DETL ADD DISC_AMT FLOAT Not NULL Default 0");
					goto IL_2740;
					IL_2740:
					num2 = 565;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_2759;
					}
					goto IL_276a;
					IL_2759:
					num2 = 566;
					DC_Main.Dc.Close();
					goto IL_276a;
					IL_276a:
					num2 = 567;
					DC_Main.ExeQuteDc("ALTER TABLE KR_DETL ADD DISC_AMT FLOAT Not NULL Default 0");
					goto IL_277b;
					IL_277b:
					num2 = 568;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_2794;
					}
					goto IL_27a5;
					IL_2794:
					num2 = 569;
					DC_Main.Dc.Close();
					goto IL_27a5;
					IL_27a5:
					num2 = 570;
					DC_Main.ExeQuteDc("ALTER TABLE GROUP_MAST ADD ADD_TOUCH FLOAT Not NULL Default 0");
					goto IL_27b6;
					IL_27b6:
					num2 = 571;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_27cf;
					}
					goto IL_27e0;
					IL_27cf:
					num2 = 572;
					DC_Main.Dc.Close();
					goto IL_27e0;
					IL_27e0:
					num2 = 573;
					DC_Main.ExeQuteDc("ALTER TABLE SL_DETL ADD DISC_AMT FLOAT Not NULL Default 0");
					goto IL_27f1;
					IL_27f1:
					num2 = 574;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_280a;
					}
					goto IL_281b;
					IL_280a:
					num2 = 575;
					DC_Main.Dc.Close();
					goto IL_281b;
					IL_281b:
					num2 = 576;
					DC_Main.ExeQuteMc("ALTER TABLE CO_MAST ADD RTGS_TYPE VARCHAR(1)Not NULL DEFAULT 'N'");
					goto IL_282c;
					IL_282c:
					num2 = 577;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_2845;
					}
					goto IL_2856;
					IL_2845:
					num2 = 578;
					DC_Main.Dc.Close();
					goto IL_2856;
					IL_2856:
					num2 = 579;
					DC_Main.ExeQuteDc("ALTER TABLE CO_MAST ADD RTGS_TYPE VARCHAR(1)Not NULL DEFAULT 'N'");
					goto IL_2867;
					IL_2867:
					num2 = 580;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_2880;
					}
					goto IL_2891;
					IL_2880:
					num2 = 581;
					DC_Main.Dc.Close();
					goto IL_2891;
					IL_2891:
					num2 = 582;
					DC_Main.ExeQuteDc("ALTER TABLE ITM_LOT_DETL ADD AC_CODE VARCHAR(10)Not NULL DEFAULT ''");
					goto IL_28a2;
					IL_28a2:
					num2 = 583;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_28bb;
					}
					goto IL_28cc;
					IL_28bb:
					num2 = 584;
					DC_Main.Dc.Close();
					goto IL_28cc;
					IL_28cc:
					num2 = 585;
					DC_Main.ExeQuteDc("ALTER TABLE MFG_IDTL ADD ITM_LOT_AC_CODE VARCHAR(10)Not NULL DEFAULT ''");
					goto IL_28dd;
					IL_28dd:
					num2 = 586;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_28f6;
					}
					goto IL_2907;
					IL_28f6:
					num2 = 587;
					DC_Main.Dc.Close();
					goto IL_2907;
					IL_2907:
					num2 = 588;
					DC_Main.ExeQuteDc("ALTER TABLE MFG_DETL ADD ITM_LOT_AC_CODE VARCHAR(10)Not NULL DEFAULT ''");
					goto IL_2918;
					IL_2918:
					num2 = 589;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_2931;
					}
					goto IL_2942;
					IL_2931:
					num2 = 590;
					DC_Main.Dc.Close();
					goto IL_2942;
					end_IL_0001_2:
					break;
				}
				num2 = 596;
				Application.Exit();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 13069;
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
}
