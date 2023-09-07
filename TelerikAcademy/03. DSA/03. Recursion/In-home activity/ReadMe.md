# Files Utils

The `FileUtils.cs` contains several helper methods for working with the file system. Your task is, _using recursion_, to implement all methods that throw a `NotImplementedException()`.

For your convenience we have added a folder called `Images` against which you can test your implementations. In addition, there is a field in the `FileUtils` class called `Path` which points to the `Images` folder.

```cs
public const string Path = @"..\..\..\Images";
```

### 1. Traverse Directories
Write a recursive method that returns all the files and folders in the given _path_.

> Folder and directory are used interchangeably.

```cs
var traversalInfo = FileUtils.TraverseDirectories(FileUtils.Path);
Console.WriteLine(traversalInfo);
```
**Result**
```
Images:
  img1.jpg
  img2.jpg
  Album1:
    img3.jpg
    img4.jpg
    Album1.1:
      img5.jpg
      img6.png
  Album2:
    img7.jpg
```

### 2. Find Files

Given a path to a directory write a recursive method that returns a list of all the files with the given _extension_.

```cs
var filesList = FileUtils.FindFiles(FileUtils.Path, ".jpg");
Console.WriteLine(string.Join(", ", filesList));
```
**Result**
```
img1.jpg, img2.jpg, img3.jpg, img4.jpg, img5.jpg, img7.jpg
```

### 3. File Exists 

Write a recursive method that checks whether a file with the given _fileName_ exists.

```cs
var fileToFind = "img6.png";
bool exists = FileUtils.FileExists(FileUtils.Path, fileToFind);
Console.WriteLine($"{fileToFind} exists? {exists}");
```
**Result**
```
img6.png exists? True
```

### 4. Directory Stats
Write a recursive method that returns the number of files for each extension.

```cs
var stats = FileUtils.GetDirectoryStats(FileUtils.Path);
Console.WriteLine(string.Join(",\n", stats.Select(kvp => @$"{{ ""{kvp.Key}"": {kvp.Value} }}")));
```
**Result**
```
{ ".jpg": 6 },
{ ".png": 1 }
```

### Constraints
- You are allowed to use [Directory.GetDirectories(string path)](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.getdirectories?view=netcore-3.1) and [Directory.GetFiles(string path)](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory.getfiles?view=netcore-3.1)
- You are **not allowed** to change the method signatures