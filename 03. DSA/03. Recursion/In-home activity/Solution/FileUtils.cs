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
			var result = TraverseDirectoriesRecursive(path, 0, new StringBuilder());
			return result;
		}
		private static string TraverseDirectoriesRecursive(string path, int indentDepth, StringBuilder sb)
		{
			string indentation = new string(' ', indentDepth * 2);

			sb.AppendLine($"{indentation}{FileUtils.GetFileName(path)}:");

			foreach (string filePath in Directory.GetFiles(path))
			{
				sb.AppendLine($"{indentation}  {FileUtils.GetFileName(filePath)}");
			}

			foreach (string subDirPath in Directory.GetDirectories(path))
			{
				TraverseDirectoriesRecursive(subDirPath, indentDepth + 1, sb);
			}

			return sb.ToString().Trim();
		}

		public static List<string> FindFiles(string path, string extension)
		{
			var files = FindFilesRecursive(path, extension, new List<string>());
			return files;
		}
		private static List<string> FindFilesRecursive(string path, string extension, List<string> filesList)
		{
			var matchingFiles = Directory.GetFiles(path)
									.Where(f => FileUtils.GetFileExtension(f) == extension)
									.Select(f => FileUtils.GetFileName(f));

			foreach (string fileName in matchingFiles)
			{
				filesList.Add(fileName);
			}

			foreach (string subDir in Directory.GetDirectories(path))
			{
				filesList = FindFilesRecursive(subDir, extension, filesList);
			}

			return filesList;
		}

		public static bool FileExists(string path, string fileName)
		{
			bool exists = Directory.GetFiles(path).Any(fullPath => FileUtils.GetFileName(fullPath) == fileName);

			// Want a certificate?? - Learn Aggregate
			return Directory.GetDirectories(path).Aggregate(exists, (result, subDir) => result || FileExists(subDir, fileName));
		}

		public static Dictionary<string, int> GetDirectoryStats(string path)
		{
			var stats = GetDirectoryStatsRecursive(path, new Dictionary<string, int>());
			return stats;
		}
		private static Dictionary<string, int> GetDirectoryStatsRecursive(string path, Dictionary<string, int> dict)
		{
			var fileExtensions = Directory.GetFiles(path).Select(f => FileUtils.GetFileExtension(f));

			foreach (var fileExtension in fileExtensions)
			{
				if (!dict.ContainsKey(fileExtension))
				{
					dict[fileExtension] = 0;
				}

				dict[fileExtension]++;
			}

			foreach (var subDir in Directory.GetDirectories(path))
			{
				dict = GetDirectoryStatsRecursive(subDir, dict);
			}

			return dict;
		}
	}
}
