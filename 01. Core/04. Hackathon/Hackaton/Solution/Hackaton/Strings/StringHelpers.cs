using System;

namespace Hackaton
{
    public class StringHelpers
    {
        /// <summary>
        /// Abbreviates a string using ellipses.
        /// </summary>
        /// <param name="source">The string to modify</param>
        /// <param name="maxLength">Maximum length of the resulting string</param>
        /// <returns>The abbreviated string.</returns>
        public static string Abbreviate(string source, int maxLength)
        {
            if (source.Length <= maxLength)
                return source;

            return Concat(source.Substring(0, maxLength), "...");
        }

        /// <summary>
        /// Capitalizes a string changing the first character to title case.
        /// </summary>
        /// <param name="source">The string to modify</param>
        /// <returns>The capitalized string or empty string if source is empty.</returns>
        public static string Capitalize(string source)
        {
            if (string.IsNullOrEmpty(source))
                return source;

            return char.ToUpper(source[0]) + source.Substring(1);
        }

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

        /// <summary>
        /// Checks if source contains a symbol.
        /// </summary>
        /// <param name="source">The string to check</param>
        /// <param name="symbol">The character to check for</param>
        /// <returns>true if symbol is within source, otherwise false.</returns>
        public static bool Contains(string source, char symbol)
        {
            return FirstIndexOf(source, symbol) != -1;
        }

        /// <summary>
        /// Checks if the string source starts with the given character.
        /// </summary>
        /// <param name="source">The string to inspect</param>
        /// <param name="target">The character to search for</param>
        /// <returns>true if string starts with target, otherwise false.</returns>
        public static bool StartsWith(string source, char target)
        {
            return source.Length != 0 && source[0] == target;
        }


        /// <summary>
        /// Checks if the string source ends with the given character.
        /// </summary>
        /// <param name="source">The string to inspect</param>
        /// <param name="target">The character to search for</param>
        /// <returns>true if string ends with target, otherwise false.</returns>
        public static bool EndsWith(string source, char target)
        {
            return source.Length != 0 && source[source.Length - 1] == target;
        }

        /// <summary>
        /// Finds the first index of target within source.
        /// </summary>
        /// <param name="source">The string to check</param>
        /// <param name="target">The character to check for</param>
        /// <returns>The first index of target within source, otherwise -1.</returns>
        public static int FirstIndexOf(string source, char target)
        {
            var chars = source.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == target)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Finds the first last of target within source.
        /// </summary>
        /// <param name="source">The string to check</param>
        /// <param name="target">The character to check for</param>
        /// <returns>The first last of target within source, otherwise -1.</returns>
        public static int LastIndexOf(string source, char symbol)
        {
            var index = -1;
            var array = source.ToCharArray();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == symbol)
                {
                    index = i;
                }
            }

            return index;
        }

        /// <summary>
        /// Pads string on the left and right sides if it's shorter than <c>length</c>.
        /// </summary>
        /// <param name="source">The string to pad</param>
        /// <param name="length ">The length of the string to achieve</param>
        /// <param name="paddingSymbol">The character used as padding</param>
        /// <returns>The padded string.</returns>
        public static string Pad(string source, int length, char paddingSymbol)
        {
            if (string.IsNullOrEmpty(source) || source.Length >= length)
                return source;

            var result = "";

            var symbolRepeatTimes = (length - source.Length) / 2;

            var leftPadding = Repeat(paddingSymbol.ToString(), symbolRepeatTimes);
            var rightPadding = PadEnd(source, symbolRepeatTimes + source.Length, paddingSymbol);

            result += Concat(leftPadding, rightPadding);

            return result;
        }

        /// <summary>
        /// Pads source on the right side with paddingSymbol enough times to reach <c>length</c>.
        /// </summary>
        /// <param name="source">The string to pad</param>
        /// <param name="length ">The length of the string to achieve</param>
        /// <param name="paddingSymbol">The character used as padding</param>
        /// <returns>The padded string.</returns>
        public static string PadEnd(string source, int length, char paddingSymbol)
        {
            if (string.IsNullOrEmpty(source) || source.Length >= length)
                return source;

            var result = "";

            result += source;

            while (result.Length < length)
            {
                result += paddingSymbol;
            }


            return result;
        }

        /// <summary>
        /// Pads source on the left side with paddingSymbol enough times to reach <c>length</c>.
        /// </summary>
        /// <param name="source">The string to pad</param>
        /// <param name="length ">The length of the string to achieve</param>
        /// <param name="paddingSymbol">The character used as padding</param>
        /// <returns>The padded string.</returns>
        public static string PadStart(string source, int length, char paddingSymbol)
        {
            if (string.IsNullOrEmpty(source) || source.Length >= length)
                return source;

            var result = "";

            while (result.Length < length - source.Length)
            {
                result += paddingSymbol;
            }

            result += source;

            return result;
        }

        /// <summary>
        /// Repeats the given string <c>times</c> times.
        /// </summary>
        /// <param name="source">The string to repeat</param>
        /// <param name="times ">The number of times to repeat the string</param>
        /// <returns>The repeated string.</returns>
        public static string Repeat(string source, int times)
        {
            if (times == 0)
                return source;

            var result = "";

            for (int i = 0; i < times; i++)
            {
                result += source;
            }

            return result;
        }

        /// <summary>
        /// Reverses the <c>source</c> string.
        /// </summary>
        /// <param name="source">The string to reverse</param>
        /// <returns>The reversed string.</returns>
        public static string Reverse(string source)
        {
            var chars = source.ToCharArray();

            var begin = 0;
            var end = chars.Length - 1;
            char temp;

            while (end > begin)
            {
                temp = chars[begin];
                chars[begin] = chars[end];
                chars[end] = temp;
                end--;
                begin++;
            }

            return new string(chars);
        }

        /// <summary>
        /// Returns a new string, starting from <c>start</c> and ending at <c>end</c>.
        /// </summary>
        /// <param name="source">The string to extract a section from</param>
        /// <param name="start">The starting position in source (inclusive)</param>
        /// <param name="end">The end position in source (inclusive)</param>
        /// <returns>The repeated string.</returns>
        public static string Section(string source, int start, int end)
        {
            var result = "";

            for (int i = start; i <= end; i++)
            {
                result += source[i];
            }

            return result;
        }
    }
}
