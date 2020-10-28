
using System;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections.Generic;



namespace ATN.Utils.NativeExt.FileExt
{
	/// <summary>
	/// Description of Files.
	/// </summary>
	public static class Extension
	{
		
		public static string GetNameWithoutExtension(this FileInfo sourceFile)
		{
			return Path.GetFileNameWithoutExtension(sourceFile.FullName);
		}
		
		public static string GetPathWithoutExtension(this FileInfo sourceFile)
		{
			return sourceFile.DirectoryName + @"\" + sourceFile.GetNameWithoutExtension();
		}
		
		public static string GetNormalizedPath(this FileInfo sourceFile)
		{
			return Path.GetFullPath(new Uri(sourceFile.FullName).LocalPath)
               .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
               .ToUpperInvariant();
		}
		
		// should be removed
		public static string NormalizedPath(string path)
		{
			return path.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
               .ToUpperInvariant();
		}
		
		public static List<DirectoryInfo> GetConsecutiveSubDirs(string myPath)
		{
			string[] directories = myPath.Split(Path.DirectorySeparatorChar);
			int folderCount = directories.Length;
			
			var d2 = new List<DirectoryInfo>();
			
			string p2 = "";
			
			foreach (string i in directories) {
				p2 = p2 + i + Path.DirectorySeparatorChar;
				
				d2.Add(new DirectoryInfo(p2));
			}
			return d2;
		}
	}
}
