using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DSA
{
	public class FileUtils
	{
		public const string Path = @"..\..\..\Images";

		public static string GetFileExtension(string filePath)
		{
			int lastIndex = filePath.LastIndexOf('.');

			return filePath[lastIndex..];
		}

		public static string GetFileName(string path)
		{
			int lastIndex = path.LastIndexOf('\\') + 1;
			string lastPart = path[lastIndex..];
			return lastPart;
		}

		public static string TraverseDirectories(string path)
		{
			throw new NotImplementedException();
		}

		public static List<string> FindFiles(string path, string extension)
		{
			throw new NotImplementedException();
		}

		public static bool FileExists(string path, string fileName)
		{
			throw new NotImplementedException();
		}

		public static Dictionary<string, int> GetDirectoryStats(string path)
		{
			throw new NotImplementedException();
		}
	}
}
