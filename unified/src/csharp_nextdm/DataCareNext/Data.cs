namespace DataCareNext;

public class Data
{
	public string m_AuthToken;

	public string AuthToken
	{
		get
		{
			return m_AuthToken;
		}
		set
		{
			m_AuthToken = value;
		}
	}

	public string ClientId { get; set; }

	public string UserName { get; set; }

	public string Sek { get; set; }

	public string TokenExpiry { get; set; }
}
