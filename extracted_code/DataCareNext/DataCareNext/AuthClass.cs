using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DataCareNext;

public class AuthClass
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object _ErrorDetails;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object _InfoDtls;

	public string status_cd { get; set; }

	public AuthError error { get; set; }

	public Data Data { get; set; }

	public object ErrorDetails
	{
		[CompilerGenerated]
		get
		{
			return _ErrorDetails;
		}
		[CompilerGenerated]
		set
		{
			_ErrorDetails = RuntimeHelpers.GetObjectValue(value);
		}
	}

	public object InfoDtls
	{
		[CompilerGenerated]
		get
		{
			return _InfoDtls;
		}
		[CompilerGenerated]
		set
		{
			_InfoDtls = RuntimeHelpers.GetObjectValue(value);
		}
	}

	public int Status { get; set; }
}
