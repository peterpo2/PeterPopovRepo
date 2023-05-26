using System;

namespace RecursionProblemSolvingA47
{
    public class Program
    {
        static void Main(string[] args)
        {
            string str = "xpix";
            //Console.WriteLine(str.Replace("pi", "3.14"));
            //Console.WriteLine(ChangePi(str));
            var array = new int[] { 1, 2, 20 };
            var result = ArrayTimes10(array, 0) ? "true" : "false";
            Console.WriteLine(result);
        }

        static string ChangePi(string str)
        {
            if (str.Length < 2)
            {
                return str;
            }

            if (str.Substring(0, 2).Equals("pi"))
            {
                return "3.14" + ChangePi(str.Substring(2));
            }

            return str[0] + ChangePi(str.Substring(1));
        }

        static bool ArrayTimes10(int[] array, int index)
        {
            if (index >= array.Length || (index + 1) >= array.Length)
            {
                return false;
            }

            if (array[index + 1] == (array[index] * 10))
            {
                return true;
            }

            return ArrayTimes10(array, index + 1);
        }
    }
} 