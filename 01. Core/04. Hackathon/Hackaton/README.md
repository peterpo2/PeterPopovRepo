# Hackathon

## Description

Your task is to implement methods that work with strings and arrays.

## Getting Started

One person from your buddy group has to _push_ a copy of the [Hackaton](Hackaton/) folder to your buddy group's GitLab's repository.  

After that, all other members of the buddy group should get the folder by _pulling_ it from their buddy group's GitLab repository.  

Now, open the Visual Studio solution contained inside the folder and examine the 2 projects - _Hackaton_ and _Hackaton.Tests_.  


## Requirements

- Your work should be limited to the _ArrayHelpers_, _StringHelpers_ and _Program_ files.
- Do not modify any other existing code.
- You are allowed to create as many new methods as you like.
- **Each member _must_ implement at least 4 methods.**
- **Each member _must_ be able to explain how and why the entire project works the way it does.** 
- Each method **must** have a documentation that contains the following sections:
  - _Description_ - A short summary of what the method is supposed to do.
  - _Parameters_ - The name and type of the method's arguments. 
  - _Returns_ - The type of the returned value, if applicable; otherwise use `void`.
  - _Author_ - The name of the person who has implemented the method.

### Documentation Example

```cs
/// <summary>
/// Concatenates two strings and returns a new string.
/// </summary>
/// <param name="string1">The left part of the new string</param>
/// <param name="string2">The right part of the new string</param>
/// <returns>A string that represents the concatenation of string1's characters followed by string2's characters.</returns>
/// <author>Kiril Stanoev</author>
public static string Concat(string string1, string string2)
{
  return string1 + string2;
}
```

## Constraints
- **Do not** use any of the built-in [string methods](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=netcore-3.1#methods) or [array methods](https://docs.microsoft.com/en-us/dotnet/api/system.array?view=netcore-3.1#methods).

## Hints
- Work as a team and try reusing your methods!
- Add a .gitignore file to your buddy group repo. You can use the one from this repo.

Good luck!
