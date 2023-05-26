using System;

class Program
{
    static void Main()
    {
        string text = "Hello World";
        string text1 = "Hello world";
        Console.WriteLine("Equality with ==: " + text == text1);
        Console.WriteLine("Equals(): " + text.Equals(text1));
        Console.WriteLine("Equals() ignore case: " + text.Equals(text1, StringComparison.CurrentCultureIgnoreCase));
        Console.WriteLine("Compare(): " + string.Compare(text, text1, false));
        Console.WriteLine("Compare() ignore case: " + string.Compare(text, text1, true));
        Console.WriteLine("IndexOf() found: " + text.IndexOf('W'));
        Console.WriteLine("IndexOf() NOT found: " + text.IndexOf('w'));

        var splitSymbols = new char[] { ' ', ',' };

        // ["Hello", "World"]
        string[] arr = text.Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine("Length of the array: " + arr.Length);
        Console.WriteLine("Print array elements with string.Join(): " + string.Join(", ", arr));
    }
}
