/*
 * Created by SharpDevelop.
 * User: ErikR
 * Date: 2017-04-11
 * Time: 21:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Reflection;

namespace ATN.Utils.SimpleLog
{
	/// <summary>
	/// Description of Logger.
	/// not implemented yet
	/// </summary>
	public class LogWriter
	{
		private readonly string LOG_FILENAME;
		private readonly string WORKING_DIR;
		
		private readonly string FOLDER;
		private readonly string LOG_FULLPATH;

		private System.Object theLogLock = new System.Object();

		public LogWriter(string filename)
		{
			LOG_FILENAME = filename;
			WORKING_DIR = Directory.GetCurrentDirectory();
		
			FOLDER = WORKING_DIR;
			LOG_FULLPATH = System.IO.Path.Combine(FOLDER, "log", LOG_FILENAME);
		}
		
		public void LogMessageToFile(string msg, bool debug = false)
		{
			lock (theLogLock) {
				WriteToFile(LOG_FULLPATH, msg, debug);
			}
		}
		
		private void WriteToFile(string file, string msg, bool debug)
		{
			var logFileInfo = new FileInfo(file);
			
			var logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
	
			if (!logDirInfo.Exists)
			{
				logDirInfo.Create();
				System.Threading.Thread.Sleep(200); // wait for system release
			}
			
			if (!logFileInfo.Exists) 
			{
				logFileInfo.Create();
				System.Threading.Thread.Sleep(200); //  wait for system release
			}
			
			StreamWriter w = File.AppendText(file);
			if (debug) {
				Debug.WriteLine(msg);

			} else {
				w.WriteLine(msg);
			}
			w.Close();
		}
	}
}
