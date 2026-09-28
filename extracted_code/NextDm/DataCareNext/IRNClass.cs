using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DataCareNext;

public class IRNClass
{
	public class Errordetail
	{
		public string ErrorCode { get; set; }

		public string ErrorMessage { get; set; }
	}

	public class Infodtl
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private object _Desc;

		public string InfCd { get; set; }

		public object Desc
		{
			[CompilerGenerated]
			get
			{
				return _Desc;
			}
			[CompilerGenerated]
			set
			{
				_Desc = RuntimeHelpers.GetObjectValue(value);
			}
		}
	}

	public class Desc
	{
		public long AckNo { get; set; }

		public string AckDt { get; set; }

		public string Irn { get; set; }
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object _Data;

	public string status_cd { get; set; }

	public ErrorResp error { get; set; }

	public object Data
	{
		[CompilerGenerated]
		get
		{
			return _Data;
		}
		[CompilerGenerated]
		set
		{
			_Data = RuntimeHelpers.GetObjectValue(value);
		}
	}

	public string Status { get; set; }

	public Errordetail[] ErrorDetails { get; set; }

	public Infodtl[] InfoDtls { get; set; }
}
