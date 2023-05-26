using System;
using System.Linq;

namespace DSA
{
	class Program
	{
		static void Main()
		{
			// GetDirectoryStats
			var stats = FileUtils.GetDirectoryStats(FileUtils.Path);
			Console.WriteLine(string.Join(",\n", stats.Select(kvp => @$"{{ ""{kvp.Key}"": {kvp.Value} }}")));
			// Result:
			// { ".jpg": 6 },
			// { ".png": 1 }
			
			// FileExists
			var fileToFind = "img6.png";
			bool exists = FileUtils.FileExists(FileUtils.Path, fileToFind);
			Console.WriteLine($"{fileToFind} exists? {exists}");
			// Result:
			// img6.png exists? True

			// FindFiles
			var filesList = FileUtils.FindFiles(FileUtils.Path, ".jpg");
			Console.WriteLine(string.Join(", ", filesList));
			// Result:
			// img1.jpg, img2.jpg, img3.jpg, img4.jpg, img5.jpg, img7.jpg

			// TraverseDirectories
			var traversalInfo = FileUtils.TraverseDirectories(FileUtils.Path);
			Console.WriteLine(traversalInfo);
			// Result:
			// Images:
			//		img1.jpg
			//		img2.jpg
			//		Album1:
			//			img3.jpg
			//			img4.jpg
			//			Album1.1:
			//				img5.jpg
			//				img6.png
			//		Album2:
			//			img7.jpg
		}
	}
}
