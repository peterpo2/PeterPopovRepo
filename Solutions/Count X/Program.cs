using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_X
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            //int count = CountX(input);
            //Console.WriteLine(count);
            var str = Console.ReadLine();
            Console.WriteLine(CountX(str,0));
        }
        static int CountX(string str, int index)
        {
            if (index == str.Length)
            {
                return 0;
            }
            if (str[index] == 'x')
            {
                return 1 + CountX(str, index+1);
            }
            return CountX(str, index+1);
        }
        //static int CountX(string str)
        //{
        //    if (str == "")
        //    {
        //        return 0;
        //    }
        //    if (str[0] == 'x')
        //    {
        //        return 1 + CountX(str.Substring(1));
        //    }
        //    else
        //    {
        //        return CountX(str.Substring(1));
        //    }
        //}
    }
}