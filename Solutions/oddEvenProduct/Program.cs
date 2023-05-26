using System;
using System.Linq;
using System.Collections.Generic;

class OddEvenProduct
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<List<int>> list = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            List<int> newList = new List<int>();
            string[] numbers = Console.ReadLine().Split(",");
            foreach (var item in numbers)
            {
                newList.Add(Int32.Parse(item));
            }
            list.Add(newList);
        }

        foreach (var lists in list)
        {
            for (int i = 0; i < lists.Count; i++)
            {
                if (i == lists.Count-1)
                {
                    if (lists[i] < lists[i-1])
                    {
                        Console.WriteLine("false");
                        break;
                    }
                    else 
                    { 
                        Console.WriteLine("true");  
                        break;
                    }
                }
                if (lists[i] > lists[i+1])
                {
                    Console.WriteLine("false");
                    break;
                }
            }
        }

    }
}
