using System;
using System.Threading;


namespace ATN.WinApi
{
	/// <summary>
	/// Description of Clipboaerd.
	/// </summary>
	public static class Clipboard
	{
		
		public static string GetText()
		{
//			IDataObject ClipData = GetDataObject2();
//			if (ClipData == null)
//			{
//				Output.OutputToUser("error, its null");
//				return "";
//			}
//	        if (ClipData.GetDataPresent(DataFormats.Text)) //error
//	        {
//	           return System.Windows.Forms.Clipboard.GetData(DataFormats.Text).ToString();
//	
//	        }
//	        return "Not text";
    
//			return GetText2();
			throw new NotImplementedException();

		}
		
//		public static string [] GetFormat()
//		{
//
//			IDataObject ClipData = GetDataObject2();
//			System.Threading.Thread.Sleep(200);
//
//			string [] formats = ClipData.GetFormats(false);
//			
//			return formats;
//
//		}
		
		
		
//		public static IDataObject GetDataObject2()
//		{
//		IDataObject idat = null;
//		Exception threadEx = null;
//		var staThread = new Thread(
//		    delegate ()
//		    {
//		        try
//		        {
//		            idat = System.Windows.Forms.Clipboard.GetDataObject();
//		        }
//		
//		        catch (Exception ex) 
//		        {
//		            threadEx = ex;            
//		        }
//		    });
//		staThread.SetApartmentState(ApartmentState.STA);
//		staThread.Start();
//		staThread.Join();
//		
//		return idat;
//		
//		}
		
		public static string GetText2()
		{
		string idat = null;
		Exception threadEx = null;
		var staThread = new Thread(
		    delegate ()
		    {
		        try
		        {
		        	idat = System.Windows.Forms.Clipboard.GetText();
		        }
		
		        catch (Exception ex) 
		        {
		            threadEx = ex;            
		        }
		    });
		staThread.SetApartmentState(ApartmentState.STA);
		staThread.Start();
		staThread.Join();
		
		return idat;
		
		}
		
		public static void SetData(object inputObj)
		{
			
		}
		
		public static void SetText(string text)
		{
		Exception threadEx = null;
		var staThread = new Thread(
		    delegate ()
		    {
		        try
		        {
		        	System.Windows.Forms.Clipboard.SetText(text);
		        }
		
		        catch (Exception ex) 
		        {
		            threadEx = ex;            
		        }
		    });
		staThread.SetApartmentState(ApartmentState.STA);
		staThread.Start();
		staThread.Join();
		}

	}
}
