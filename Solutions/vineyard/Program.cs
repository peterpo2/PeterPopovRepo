using System;
using System.Collections.Generic;
using System.Linq;
namespace Exam
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int colleagues = int.Parse(Console.ReadLine());
            int lengthOfVineyard = int.Parse(Console.ReadLine());
            string vineyard = Console.ReadLine();


            int requiredWineGlasses = Convert.ToInt32(colleagues) * 2; //750ml
            int requiredWineBottles = (int)Math.Ceiling(requiredWineGlasses * (double)150 / (double)750);
            int requiredRakiaGlasses = Convert.ToInt32(colleagues) * 1;//700ml
            int requiredRakiaBottles = (int)Math.Ceiling((requiredRakiaGlasses) * (double)50 / (double)700);
            int perfectVines = 0;
            int averageVines = 0;
            int finalWineReserves = 0;
            int finalRakiaReserves = 0;
            int badQualityVines = 0;
            for (int i = 0; i < vineyard.Length; i++)
            {
                var v = vineyard[i].ToString();
                switch (v)
                {
                    case "X": perfectVines++; break;
                    case "x": averageVines++; break;
                    case "=": badQualityVines++; break;
                    default: break;

                }

            }
            if (perfectVines != 0)
            {
                finalWineReserves = perfectVines * 7;
            }

            if (averageVines != 0)
            {
                
                finalRakiaReserves = (int)Math.Floor(((double)averageVines * 7) / 5);
            }

            if (finalWineReserves >= requiredWineBottles && finalRakiaReserves >= requiredRakiaBottles)
            {
                var wineBottlesLeft = finalWineReserves - requiredWineBottles;
                var rakiaBottlesLeft = finalRakiaReserves - requiredRakiaBottles;
                Console.WriteLine($"Yes! {wineBottlesLeft} bottles of wine and {rakiaBottlesLeft} bottles of rakia remaining for the next party!");
            }
            else
            {
                var wineBottlesRequired = requiredWineBottles - finalWineReserves;
                if (finalRakiaReserves >= requiredRakiaBottles)
                {
                    var rakiaBottles = 0;
                    Console.WriteLine($"No! {wineBottlesRequired} more bottles of wine and {rakiaBottles} more bottles of rakia required!");

                }
                else
                {
                    var rakiaBottlesRequired = requiredRakiaBottles - finalRakiaReserves;
                    Console.WriteLine($"No! {wineBottlesRequired} more bottles of wine and {rakiaBottlesRequired} more bottles of rakia required!");
                }



            }


        }
    }
}