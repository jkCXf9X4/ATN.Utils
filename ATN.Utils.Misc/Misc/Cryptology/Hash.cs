
using System;

namespace ATN.Utils.Misc.Cryptology
{
	/// <summary>
	/// Description of Hash.
	/// </summary>
	public static class Hash
	{
	    public static string GetStringSha256Hash(string text)
	    {
	        if (System.String.IsNullOrEmpty(text))
	            return System.String.Empty;
	
	        using (var sha = new System.Security.Cryptography.SHA256Managed())
	        {
	            byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
	            byte[] hash = sha.ComputeHash(textData);
	            return BitConverter.ToString(hash).Replace("-", System.String.Empty);
	        }
	    }
	    
	    public static string GetTimestampHash()
	    {
	    	return GetStringSha256Hash(DateTime.Now.Ticks.ToString());
	    }
	}
}
