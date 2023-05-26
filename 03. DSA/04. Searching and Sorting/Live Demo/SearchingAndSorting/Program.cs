namespace SearchingAndSorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 5, 8, 9, 12, 13, 25 };
            int number = int.Parse(Console.ReadLine());

            array.Contains(5);

            Console.WriteLine(BinarySearch(array,number));
        }


        static int BinarySearch(int[] array, int target) 
        {
            return BinarySearch(array, target, 0, array.Length - 1);
        }

        static int BinarySearch(int[] array, int target,int startIndex,int endIndex) 
        {
            if (startIndex > endIndex) 
            {
                return -1;
            }

            //int middleIndex = startIndex +(endIndex - startIndex)/2;
            int middleIndex = (startIndex + endIndex) / 2;
            int middleValue = array[middleIndex];

            if (middleValue == target)
            {
                return middleIndex;
            }

            else if (target > middleValue) 
            {
                startIndex = middleIndex + 1;
            }
            else if(target < middleValue) 
            {
                endIndex = middleIndex - 1;
            }

            return BinarySearch(array, target, startIndex, endIndex);

        }
    }
}